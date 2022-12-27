using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Reviews.Api.Data
{
        public class ReviewContext : DbContext
        {
            public DbSet<Review> Reviews { get; set; } = null!;

            public ReviewContext(DbContextOptions<ReviewContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.Entity<Review>(x =>
                {
                    x.Property(p => p.Id).IsRequired();
                    x.Property(p => p.Title).IsRequired();
                    x.Property(p => p.productId).IsRequired();
                    x.Property(p => p.productReviewContent).IsRequired();
                    x.Property(p => p.productReviewRating).IsRequired();
                    x.Property(p => p.displayReview).IsRequired();
                    x.Property(p => p.anonymized).IsRequired();
                    x.Property(p => p.firstName).IsRequired();


                });
            }
        }
    }
