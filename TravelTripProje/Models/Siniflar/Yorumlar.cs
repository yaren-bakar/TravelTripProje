using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        [StringLength(100)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta girin.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Yorum boş olamaz.")]
        [StringLength(1000)]
        public string Yorum { get; set; }

        public int Blogid { get; set; }
        public virtual Blog blog { get; set; }
    }
}