using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Dtos
{
    public class ProductDocumentDto : BaseDto
    {
        public int ProductId { get; set; }
        public string DocumentUrl { get; set; }
    }
}
