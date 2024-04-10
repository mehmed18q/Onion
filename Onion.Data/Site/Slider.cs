﻿using Onion.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Site
{
	public class Slider : BaseEntity
	{
		[Display(Name = "عنوان")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string Title { get; set; }

		[Display(Name = "توضیحات")]
		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string Description { get; set; }

		[MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string ImageName { get; set; }

		[Display(Name = "فعال / غیرفعال")]
		public bool IsActive { get; set; }
	}
}
