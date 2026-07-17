using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class AnaSayfa
    {
        [Key] //primary key
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Açiklama { get; set; }
    }
}