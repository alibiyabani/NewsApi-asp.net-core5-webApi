using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsApi.DataLayer.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        public string CategoryTitle { get; set; }

        public List<News> News { get; set; }

    }
}
