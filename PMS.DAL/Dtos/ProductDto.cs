using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Dtos
{
    public class ProductDto:BaseDto
    {
      
        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [DisplayName("Kateqoriya seç")]
        public int ProductCategoryId { get; set; }
        public List<ProductCategoryDto> CategoryDtos { get; set; }
 
        [Display(Name = "Qısa məzmun")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Marka")]
        public string Marka { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Birim qiyməti")]
        public decimal UnitOfPrice { get; set; }
        [DisplayName("Toplam miqdarı")]
        public int TotalCount { get; set; }

        [DisplayName("Rəsmlər")]
        public string PorfileDocPath { get; set; }
        public List<ProductDocumentDto> ProductDocuments { get; set; }

    }
}
