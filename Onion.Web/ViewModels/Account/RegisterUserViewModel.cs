using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Onion.Web.ViewModels.Account
{
	public class RegisterUserViewModel
	{
		[Display(Name = "نام کاربری")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		public string UserName { get; set; } = string.Empty;

		[Display(Name = "ایمیل")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		[EmailAddress(ErrorMessage = "لطفا {0} معتبری وارد نمایید.")]
		[Remote("IsExistUserByEmail", "Validate", ErrorMessage = "کاربری با این ایمیل وجود دارد.")]
		public string Email { get; set; } = string.Empty;

		[Display(Name = "کلمه عبور")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;

		[Display(Name = "تکرار کلمه عبور")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمی تواند بیشتر از {1} باشد.")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
		[Compare(nameof(Password), ErrorMessage = "کلمه های عبور مغایرت دارند")]
		[DataType(DataType.Password)]
		public string RePassword { get; set; } = string.Empty;
	}
}
