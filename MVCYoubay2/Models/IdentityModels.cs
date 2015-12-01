using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace MVCYoubay2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string USER_TYPE { get; set; }
        public long youBayUserId { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string countryOfResidence { get; set; }
        //public string email { get; set; }
        public string emailActivationToken { get; set; }
        public string FirstName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isBanned { get; set; }
        public string lastName { get; set; }
        //public string phoneNumber { get; set; }
        public Nullable<float> complaintPercentage { get; set; }
        public Nullable<float> gamificationScore { get; set; }
        public string sellerBadges { get; set; }
        public string sellerDescription { get; set; }
        public Nullable<bool> sellerIsSuspiciousFlag { get; set; }
        public string sellerLogo { get; set; }
        public Nullable<float> totalSales { get; set; }
        public Nullable<bool> canAddAdvertisement { get; set; }
        public Nullable<bool> canExportData { get; set; }
        public Nullable<bool> canManageCategories { get; set; }
        public Nullable<bool> canManageManagers { get; set; }
        public Nullable<bool> canModerateSellersAndBuyers { get; set; }
        public Nullable<float> accountBalance { get; set; }
        public string addressCity { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string buyerBadges { get; set; }
        public Nullable<bool> iSMale { get; set; }
        public Nullable<float> totalSpending { get; set; }
        public Nullable<long> customizedAds_customizedAdsId { get; set; }
        public virtual ICollection<t_auction> t_auction { get; set; }
        public virtual t_customizedads t_customizedads { get; set; }
        public virtual ICollection<t_historyofviews> t_historyofviews { get; set; }
        public virtual ICollection<t_orderandreview> t_orderandreview { get; set; }
        public virtual ICollection<t_product> t_product { get; set; }
        public virtual ICollection<t_product> t_product1 { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<t_assistantitems> t_assistantitems { get; set; }
        public DbSet<t_auction> t_auction { get; set; }
        public DbSet<t_category> t_category { get; set; }
        public DbSet<t_customizedads> t_customizedads { get; set; }
        public DbSet<t_historyofviews> t_historyofviews { get; set; }
        public DbSet<t_orderandreview> t_orderandreview { get; set; }
        public DbSet<t_product> t_product { get; set; }
        public DbSet<t_producthistory> t_producthistory { get; set; }
        public DbSet<t_specialpromotion> t_specialpromotion { get; set; }
        public DbSet<t_subcategory> t_subcategory { get; set; }

        public System.Data.Entity.DbSet<MVCYoubay2.Models.Cart> Carts { get; set; }
    }
}