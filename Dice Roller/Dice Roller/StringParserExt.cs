using Dice_Roller.Model;

namespace Dice_Roller
{
    public static class StringParserExt
    {
        public static Roll ParseRoll(this string inputString)
        {
            return StringParser.Parse(inputString);
        }
    }
}
