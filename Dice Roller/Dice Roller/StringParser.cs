using Dice_Roller.Model;
using System;

namespace Dice_Roller
{
    public static class StringParser
    {
        public static Roll Parse(string inputString)
        {
            var processed = inputString.Split('d');     // 3d8kh2+5 
            int amount = int.Parse(processed[0]);       // 3    8kh2+5 
            int? modifier = new int?();
            int diceSides;
            DropKeepType? operationType = new DropKeepType?();
            int? operationAmount = new int?();

            if (inputString.Contains("+") || inputString.Contains("-"))
            {
                int modifierSign = 1;
                if (inputString.Contains("-"))
                {
                    modifierSign = -1;
                }
                processed = processed[1].Split(modifierSign < 0 ? '-' : '+');   // 8kh2   +   5
                modifier = int.Parse(processed[1]) * modifierSign;
            }

            foreach (var type in Enum.GetNames(typeof(DropKeepType)))
            {
                if (processed[0].Contains(type))
                {
                    operationType = (DropKeepType?)Enum.Parse(typeof(DropKeepType), type);
                }
                if (operationType.HasValue)
                {
                    processed = processed[0].Split(new string[] { Enum.GetName(typeof(DropKeepType), operationType) }, StringSplitOptions.None);
                    operationAmount = int.Parse(processed[1]);// 8  kh  2
                    break;
                }
            }

            diceSides = int.Parse(processed[0]);
            return new Roll(amount, diceSides, operationType, operationAmount, modifier);
        }
    }
}
