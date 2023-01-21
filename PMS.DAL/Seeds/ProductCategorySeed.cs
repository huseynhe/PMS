using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Seeds
{
    class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            //builder.HasData(
            //     new ProductCategory()
            //     {
            //         Id = 1,
            //         Name = "Smartfonlar",
            //         Description = "Akıllı telefonlar",
            //         InsertDate = DateTime.Now
            //     },
            //    new ProductCategory()
            //    {
            //        Id = 2,
            //        Name = "TV, audio, video",
            //        Description = "TV akksesorlari",
            //        InsertDate = DateTime.Now
            //    }
            //    );
        }
    }
}
