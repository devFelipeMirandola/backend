using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace reposbackend.CrossCutting
{
    public static class StringExtensions
    {
        public static string OnlyNumbers(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var regexOnlyNumber = new Regex(@"[^\d]");

                return regexOnlyNumber.Match(input).Success ? regexOnlyNumber.Replace(input, "").Trim() : input;
            }
            return string.Empty;
        }
    }
}