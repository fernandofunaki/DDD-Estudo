using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BannerMapper : EntityTypeConfiguration<BannerEntity>
    {
        public BannerMapper()
        {
            ToTable("banner");
            this.HasKey(a => a.Id);
            
            //this.Property(a => a.Dimension.Heigth).HasColumnName("heigth");
            //this.Property(a => a.Dimension.Width).HasColumnName("width");
        }
    }
}
