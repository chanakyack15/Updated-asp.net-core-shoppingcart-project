using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CartDetail
    {
        [Key]
        public int Cid { get; set; }

        public string cName { get; set; }

        public string  cPrice { get; set; }
    }
}
