using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VarlikKatmani.Models
{
    [Table("tblUrunler")]
    public class Urun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Fiyat { get; set; }
        public int KategoriId { get; set; }

        [ForeignKey(nameof(KategoriId))]
        public Kategori Kategori { get; set; }
    }
}
