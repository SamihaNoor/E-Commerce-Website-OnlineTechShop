//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineTechShop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TechShopDbEntities : DbContext
    {
        public TechShopDbEntities()
            : base("name=TechShopDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BuyingAgent> BuyingAgents { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Old_Products> Old_Products { get; set; }
        public virtual DbSet<OrderData> OrderDatas { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Purchase_Log> Purchase_Log { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Sales_Log> Sales_Log { get; set; }
        public virtual DbSet<SalesExecutive> SalesExecutives { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
    }
}
