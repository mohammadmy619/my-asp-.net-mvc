using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLaayer
{
    public class pagegroup
    {
        //[Key]
        //public int GroupID { get; set; }

        //[Display(Name="عنوان گروه")]
        //[Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        //[MaxLength(150)]
        //public string GroupTitle { get; set; }
         [Key]
        public int GroupID { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }


        //Navigation Property
        public virtual List<page> Pages { get; set; }

        public pagegroup()
        {
            
        }
    }
}
