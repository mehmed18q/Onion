using Onion.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Music
{
	public class Singer : BaseEntity
	{
		[Display(Name = "نام خواننده")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string SingerName { get; set; } = string.Empty;

		[Display(Name = "تصویر خواننده")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string SingerImage { get; set; } = string.Empty;

		[Display(Name = "فعال / غیرفعال")]
		public bool IsActive { get; set; }

		public virtual ICollection<Song>? Songs { get; set; }
	}
}
