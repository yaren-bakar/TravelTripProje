using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(4000, ErrorMessage = "Açıklama çok uzun.")]
        public string Açiklama { get; set; }

        public string BlogImage { get; set; }

        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}