using System;
using System.Collections.Generic;
using System.Net.Http;
using Dice_Roller.Util;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Dice_Roller.RandomProvider
{
    public class RandomOrgProvider : IRandomProvider
    {
        const string URL = "https://www.random.org/integers/?num={2:d}&min={0:d}&max={1:d}&col=1&base=10&format=plain&rnd=new";


        public async Task<int> RandomNumberAsync(int from, int to)
        {
            try
            {
                using (var client = new RandomOrgHttpClient())
                {
                    Debug.WriteLine(string.Format(URL, from, to, 1));
                    return int.Parse(await client.GetStringAsync(string.Format(URL, from, to, 1)));
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        public async Task<List<int>> RandomNumberAsync(int from, int to, int amount = 1)
        {
            if (amount <= 0) throw new ArgumentException("Value should be more or equal 1", "amount");
            List<int> result = new List<int>();
            try
            {
                using (var client = new RandomOrgHttpClient())
                {
                    foreach (var numberString in (await client.GetStringAsync(string.Format(URL, from, to, amount))).TrimEnd('\n').Split('\n'))
                    {
                        result.Add(int.Parse(numberString));
                    }
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}
