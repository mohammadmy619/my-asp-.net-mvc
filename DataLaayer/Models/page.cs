using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLaayer;
using System.Web.Mvc;

namespace DataLaayer
{
    public class page
    {

        //[Key]
        //public int PageID { get; set; }
        //[Display(Name = "گروه صفحه")]
        //[Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        //public int GroupID { get; set; }

        //[Display(Name = "متن")]
        //[Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        //[MaxLength(250)]

        //public string Title { get; set; }
        //public string ShortDescription { get; set; }
        //[Display(Name = "")]
        //[Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        //public string text { get; set; }
        //[Display(Name = "")]

        //public string Visit { get; set; }
        //[Display(Name = "")]

        //public string ImageName { get; set; }
        //[Display(Name = "")]

        //public bool ShowInSlider { get; set; }
        //[Display(Name = "")]

        //public DateTime CreateDate { get; set; }
        [Key]
        public int PageID { get; set; }

        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]


        public string Text { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "تاریخ ایجاد")]
         [DisplayFormat(DataFormatString="{0:yyyy/mm/dd}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "کلمات کلیدی")]

        public string Tages { get; set; }

        public virtual pagegroup PageGroup { get; set; }

        public virtual List<pagecamment> PageComments { get; set; }

        public page()
        {
            
        }

    }
}
