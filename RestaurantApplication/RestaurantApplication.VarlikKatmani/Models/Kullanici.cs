using RestaurantApplication.VarlikKatmani.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VarlikKatmani.Models
{
    [Table("tblKullanici")]
    public class Kullanici
    {
        [Key]
        public string Eposta { get; set; } //her kullanıcının kendine göre 1 epostası olur
        public string Parola { get; set; }
        public string Ad { get; set; } 
        public string Soyad { get; set; }
        public Yetki Yetki { get; set; } 
    }
}
