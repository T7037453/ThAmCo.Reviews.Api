using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using ThAmCo.Reviews.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ReviewContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbPath = System.IO.Path.Join(path, "reviews.db");
        options.UseSqlite($"Data Source={dbPath}");
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();

    }
    else
    {
        var ps = builder.Configuration.GetConnectionString("ReviewsContext");
        options.UseSqlServer(ps);
    }
});

builder.Services
     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Authority"];
        options.Audience = builder.Configuration["Auth:Audience"];
    });
builder.Services.AddAuthorization();


//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseAuthentication();

app.UseAuthorization();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.UseSwagger();
//    //app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

var responseMessage = app.Configuration["Message"] ?? "";

app.MapPost("/reviews", async (ReviewContext ctx, ReviewDto dto) =>
{
    var review = new Review { Id = dto.Id, Title = dto.Title, productId = dto.productId, productReviewContent = dto.productReviewContent, productReviewRating = dto.productReviewRating, anonymized = dto.anonymized, firstName = dto.firstName };
    await ctx.AddAsync(review);
    await ctx.SaveChangesAsync();
    return responseMessage;
});


app.MapGet("/reviews", async (ReviewContext ctx,[FromQuery(Name = "id")] int? id) =>
{
    return await ctx.Reviews.Where(r => r.productId == id).ToListAsync();
});

app.MapGet("/allreviews", async (ReviewContext ctx) =>
{
    return await ctx.Reviews.ToListAsync();
});

//app.MapGet("/reviews/{id}", [Authorize] async (ReviewContext ctx, int id) =>
//{
//    return await ctx.Reviews.FindAsync(id);
//});

//app.UseAuthorization();

//app.MapControllers();

app.Run();

