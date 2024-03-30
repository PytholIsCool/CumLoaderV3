using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.Localization;

namespace HexedBase.API
{
    internal static class HexedBaseStrings
    {
        public static LocalizableString ReturnLocalizableString(this string x)
        {
            LocalizableString @string = LocalizableStringExtensions.Localize(x);
            return @string;
        }
    }
}
