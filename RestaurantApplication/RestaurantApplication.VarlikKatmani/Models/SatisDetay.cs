using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VarlikKatmani.Models
{

    public class SatisDetay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Adet { get; set; }

        public decimal Tutar { get; set; }

        public int UrunId { get; set; }
        [ForeignKey(nameof(UrunId))]
        public Urun urun { get; set; }


        public int SatisId { get; set; }
        [ForeignKey(nameof(SatisId))]
        public Satis satis { get; set; }
    }
}
