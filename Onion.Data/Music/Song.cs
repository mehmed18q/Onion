using Onion.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Music
{
	public class Song : BaseEntity
	{
		public int SingerId { get; set; }

		[Display(Name = "نام آهنگ")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string SongName { get; set; }

		[Display(Name = "نام فایل آهنگ")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string SongFileName { get; set; }

		[Display(Name = "نام تصویر آهنگ")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string SongImageName { get; set; }

		[Display(Name = "تاریخ ثبت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public DateTime CreateDate { get; set; }

		[Display(Name = "توضیحات")]
		[MaxLength(2000, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.MultilineText)]
		public required string Description { get; set; }

		[Display(Name = "فعال / غیرفعال")]
		public bool IsActive { get; set; }

		public virtual Singer? Singer { get; set; }

		public virtual ICollection<SongAttractiveness>? SongAttractiveness { get; set; }
	}
}
