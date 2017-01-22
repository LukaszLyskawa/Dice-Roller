using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dice_Roller.RandomProvider
{
    public class SystemRandom : IRandomProvider
    {
        private static Lazy<Random> rand = new Lazy<Random>(() => new Random());
        public async Task<int> RandomNumberAsync(int from, int to)
        {
            return await Task.Run(() =>
            {
                return rand.Value.Next(from, to);
            });
        }
        public async Task<List<int>> RandomNumberAsync(int from, int to, int amount = 1)
        {
            if (amount <= 0) throw new ArgumentException("Value should be more or equal 1", "amount");
            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                randomNumbers.Add(await RandomNumberAsync(from, to));
            }
            return randomNumbers;
        }
    }
}
