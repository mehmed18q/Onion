using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Common
{
	public enum AttractivenessType
	{
		[Display(Name = "مشاهده")]
		Visit,
		[Display(Name = "پسندیدن")]
		Like
	}
}
