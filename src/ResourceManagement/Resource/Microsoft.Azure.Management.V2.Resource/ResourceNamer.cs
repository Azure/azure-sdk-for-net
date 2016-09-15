using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource
{
    public class ResourceNamer
    {
        private readonly string randName;
        private static string[] formats = new string[] { "M/d/yyyy h:mm:ss tt" };

        /**
         * Creates ResourceNamer.
         *
         * @param name the randName
         */
        public ResourceNamer(string name)
        {
            this.randName = name.ToLower() + Guid.NewGuid().ToString("N").Substring(0, 3).ToLower();
        }

        /**
         * Gets a random name.
         *
         * @param prefix the prefix to be used if possible
         * @param maxLen the max length for the random generated name
         * @return the random name
         */
        public string RandomName(String prefix, int maxLen)
        {
            prefix = prefix.ToLower();
            int minRandomnessLength = 5;
            if (maxLen <= minRandomnessLength)
            {
                return RandomString(maxLen);
            }

            if (maxLen <= prefix.Length + minRandomnessLength)
            {
                return RandomString(maxLen);
            }

            var millis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            var jan1970millis = DateTime.ParseExact("1/1/1970 0:00:00 AM", ResourceNamer.formats,
                                    new CultureInfo("en-US"), DateTimeStyles.None).Ticks / TimeSpan.TicksPerMillisecond;
            String minRandomString = ((millis - jan1970millis) % 100000L).ToString();
            if (maxLen <= (prefix.Length + randName.Length + minRandomnessLength))
            {
                var str1 = prefix + minRandomString;
                return str1 + RandomString((maxLen - str1.Length) / 2);
            }

            string str = prefix + randName + minRandomString;
            return str + RandomString((maxLen - str.Length) / 2);
        }

        private string RandomString(int length)
        {
            String str = "";
            while (str.Length < length)
            {
                str += Guid.NewGuid().ToString("N").Substring(0, Math.Min(32, length)).ToLower();
            }
            return str;
        }

        /**
         * Gets a random name.
         *
         * @param prefix the prefix to be used if possible
         * @param maxLen the maximum length for the random generated name
         * @return the random name
         */
        public static string RandomResourceName(String prefix, int maxLen)
        {
            ResourceNamer namer = new ResourceNamer("");
            return namer.RandomName(prefix, maxLen);
        }
    }
}
