using System.ComponentModel.DataAnnotations;

namespace Onion.Service.DTO.User
{
	public class AdminEditUser
	{
		public int UserId { get; set; }

		[Display(Name = "نام کاربری")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string UserName { get; set; }

		[Display(Name = "ایمیل")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
		public required string Email { get; set; }

		public string CurrentEmail { get; set; } = string.Empty;

		public string CurrentUserName { get; set; } = string.Empty;

		[Display(Name = "فعال / غیرفعال")]
		public bool IsActive { get; set; }
	}

}
