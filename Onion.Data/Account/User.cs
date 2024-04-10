using Onion.Data.Access;
using Onion.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Account
{
	public class User : BaseEntity
	{
		[Display(Name = "نام کاربری")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		public string UserName { get; set; } = string.Empty;

		[Display(Name = "ایمیل")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		[EmailAddress(ErrorMessage = "لطفا {0} معتبری وارد نمایید.")]
		public string Email { get; set; } = string.Empty;

		[Display(Name = "کلمه عبور")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		public string Password { get; set; } = string.Empty;

		public string ActiveCode { get; set; } = string.Empty;

		public bool IsActive { get; set; }

		public virtual ICollection<UserRole>? UserRoles { get; set; }
	}
}
