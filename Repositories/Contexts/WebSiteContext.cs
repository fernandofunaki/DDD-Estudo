using Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Authentication;

namespace Repositories
{

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public sealed class WebSiteContext : IdentityDbContext<ApplicationUser>, IContext
    {
        public DbSet<BannerEntity> Banners { get; set; }
    
        public WebSiteContext()
            : base("name=WebSiteContext", throwIfV1Schema: false)
        {
            Database.SetInitializer<WebSiteContext>(null);
            Config();
        }

        private void Config()
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.AutoDetectChangesEnabled = true;
            base.Configuration.ValidateOnSaveEnabled = false;
        }

        public WebSiteContext(System.Data.Common.DbConnection conn)
            : base(conn, true)
        {
            Database.SetInitializer<WebSiteContext>(null);
            Config();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BannerMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
