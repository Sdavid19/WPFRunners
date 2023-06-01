using Jedlik.EntityFramework.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoverseny.adatok
{
    public class TavolsagModel
    {
        public int Id { get; set; }
        [Required]
        [Unique]
        [StringLength(50)]
        public string Megnevezes { get; set; }
    }
}
