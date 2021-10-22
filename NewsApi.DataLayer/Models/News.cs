using System;
using System.ComponentModel.DataAnnotations;

namespace NewsApi.DataLayer.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیح کوتاه خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SubTitle { get; set; }

        [Display(Name = "متن خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Body { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Image { get; set; }

        [Display(Name = "وضعیت خبر")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ ثبت خبر")]
        public DateTime SubmitDate { get; set; }


        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SourceId { get; set; }
        public Source Source { get; set; }
    }
}
