
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsApi.DataLayer.Models
{
    public class Source
    {
        [Key]
        public int SourceId { get; set; }

        [Display(Name ="منبع خبر")]
        public string NewsSource { get; set; }

        public List<News> News { get; set; }

    }
}
