using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Roller
{
    public static class EnumExt
    {

        public static String ToString<T>(this T? value) where T : struct
        {
            return value.HasValue ? Enum.GetName(typeof(T), value) : null;
        }

        public static T? Parse<T>(this String value) where T : struct
        {
            return Enum.TryParse(value, out T v) ? (T?)v : null;
        }


    }
}
