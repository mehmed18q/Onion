﻿namespace Onion.Web.Utilities.Generators
{
	public static class StringGenerator
	{
		public static string GenerateGuidName()
		{
			return Guid.NewGuid().ToString("N");
		}
	}
}
