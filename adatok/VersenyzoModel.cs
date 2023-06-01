using Jedlik.EntityFramework.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoverseny.adatok
{
    public class VersenyzoModel
    {
        public int Id { get; set; }
        [Unique]
        public int Rajtszam { get; set; }
        [Required]
        [StringLength(200)]
        public string Nev { get; set; }
        public DateTime? SzuletesiDatum { get; set; }
        [StringLength(20)]
        [Required]
        public string Neme { get; set; }
        public TavolsagModel Tavolsag { get; set; } = null;
        public int TavolsagId { get; set; }
        [StringLength(50)]
        public string Korosztaly { get; set; }
    }
}
