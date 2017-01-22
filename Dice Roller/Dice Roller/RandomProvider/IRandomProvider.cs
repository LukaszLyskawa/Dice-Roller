using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dice_Roller
{
    public interface IRandomProvider
    {
        Task<int> RandomNumberAsync(int from, int to);
        Task<List<int>> RandomNumberAsync(int from, int to, int amount);
    }
}
