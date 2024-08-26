using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }



        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class method to ensure Identity entities are configured correctly
            //base.OnModelCreating(modelBuilder);

          

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Cart>()
            //    .HasMany(c => c.Products)
            //    .WithOne(cp => cp.Cart)
            //    .HasForeignKey(cp => cp.CartId);


        }

    }
}