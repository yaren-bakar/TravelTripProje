using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> Deger1 { get; set; }  //tek viewden 2 tabloyada erişmemizi sağlar
        public IEnumerable<Yorumlar>Deger2 { get; set; }
    }
}