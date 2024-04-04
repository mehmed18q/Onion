using Onion.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Access
{
    public class Role : BaseEntity
    {
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "نام سیستمی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
