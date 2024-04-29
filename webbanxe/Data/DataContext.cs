using Microsoft.EntityFrameworkCore;
using webbanxe.Areas.Admin.Models;
using webbanxe.Models;

namespace webbanxe.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<view_Post_Menu> PostMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<TypeBike> TypeBike { get; set; }
        public DbSet<Bike> Bike { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Accessary> Accessaries {get;set;}
        public DbSet<Notification> Notification { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
