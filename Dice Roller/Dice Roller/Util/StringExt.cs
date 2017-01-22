namespace Dice_Roller.Util
{
    internal static class StringExt
    {
        internal static int CountChar(this string input, char c)
        {
            int count = 0;
            for(int i = 0, size = input.Length; i < size; i++)
            {
                if (input[i] == c)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
