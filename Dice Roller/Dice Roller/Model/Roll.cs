using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dice_Roller.Model
{
    public class Roll
    {
        public int amount { get; private set; }
        public DropKeepType? operationType { get; private set; }
        public int operationAmount { get; private set; }
        public int modifier { get; private set; }

        public int DiceNumber { get; private set; }
        public int DiceSides { get; private set; }
        public List<Dice> dice { get; private set; }
        public int RollResult { get; private set; }

        public Roll(string rollString)
        {

        }

        public Roll(int? amount, int diceSides, DropKeepType? operationType, int? operationAmount, int? modifier)
        {
            this.amount = amount.HasValue ? amount.Value : 1;
            DiceSides = diceSides;
            this.operationType = operationType;
            this.operationAmount = operationAmount.HasValue ? operationAmount.Value : 0;
            this.modifier = modifier.HasValue ? modifier.Value : 0;
        }

        public async Task<int> MakeTheRoll(IRandomProvider random)
        {
            int result = 0;
            List<int> results = await random.RandomNumberAsync(1, DiceSides, DiceNumber);
            foreach (var r in results)
            {
                result += r;
            }
            return result;
        }
    }
}
