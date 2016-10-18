using Microsoft.EntityFrameworkCore;
using StaffMicroService.Models.Entities;

namespace StaffMicroService.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbContextOptions<ApplicationDbContext> options;

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<ContactEmailAddress> ContactEmailAddresses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<MemberPersonalIdentityType> MemberPersonalIdentityTypes { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<SalesBorrower> SalesBorrowers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Staff> Staffs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<UserContact> userContacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> _options) : base(_options)
        {
            options = _options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>()
                .ToTable("contacts")
                .HasKey(m => new {
                    m.contactid,
                    m.personalidentitytypeid
                });

            builder.Entity<ContactEmailAddress>()
                .ToTable("contactemailaddress")
                .HasKey(m => new {
                    m.contactid,
                    m.emailaddressid
                });

            builder.Entity<EmailAddress>()
                .ToTable("emailaddress")
                .HasKey(m => new {
                    m.emailaddressid,
                    m.memberemailaddresstypeid
                });

            builder.Entity<MemberPersonalIdentityType>()
                .ToTable("memberpersonalidentitytypes")
                .HasKey(m => new {
                    m.memberpersonalidentitytypeid,
                    m.personalidentitytypeid
                });

            builder.Entity<SalesBorrower>()
                .ToTable("salesborrowers")
                .HasKey(m => new {
                    m.staffid,
                    m.borrowerid
                });

            builder.Entity<Staff>()
                .ToTable("staff")
                .HasKey(m => new {
                    m.staffid,
                    m.contactid,
                    m.leaderid
                });

            builder.Entity<UserContact>()
                .ToTable("usercontacts")
                .HasKey(m => new {
                    m.userid,
                    m.contactid
                });

            base.OnModelCreating(builder);
        }
    }
}