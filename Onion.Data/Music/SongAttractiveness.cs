using Onion.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Music
{
	public class SongAttractiveness : BaseEntity
	{
		public int SongId { get; set; }

		[MaxLength(50, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public required string UserIP { get; set; }

		public Song? Song { get; set; }
		public AttractivenessType AttractivenessType { get; set; }
	}
}
