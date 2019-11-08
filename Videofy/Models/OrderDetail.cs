using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }

        [DataType(DataType.Currency)] //Format input to currency data type
        [Column(TypeName = "decimal(18, 2)")] //Round decimal to 2 places
        public decimal Price { get; set; }

        // Creates references for foreign key for these models (check the db View Designer)
        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}
