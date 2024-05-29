using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VarlikKatmani.Enums
{
    public enum Yetki
    {
        [Display(Name = "Personel")]
        Personel = 1,
        [Display(Name = "Müdür")]
        Mudur
    }
}
