using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data.Common.SeedUtilities
{
    public class RandomGenerator
    {
        private Random random = new Random();

        public int GetRandomInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomNumericString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(this.random.Next(1, 10));
            }

            return sb.ToString();
        }
    }
}
