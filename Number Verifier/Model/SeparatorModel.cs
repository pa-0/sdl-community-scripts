﻿namespace Sdl.Community.NumberVerifier.Model
{
	public class SeparatorModel
	{
		public string MatchValue { get; set; }
		public string ThousandSeparators { get; set; }
		public string DecimalSeparators { get; set; }
		public bool NoSeparator { get; set; }
		public string CustomSeparators { get; set; }
		public int LengthCommaOrCustomSep { get; set; }
		public int LengthPeriodOrCustomSep { get; set; }
	}
}