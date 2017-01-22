using System.Net.Http;
using System.Net.Http.Headers;

namespace Dice_Roller.Util
{
    class RandomOrgHttpClient : HttpClient
    {
        public RandomOrgHttpClient()
        {
            DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("why_is_this_needed", "wtf"));
        }
    }
}
