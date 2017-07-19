// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    public class ResourceNamer : IResourceNamer
    {
        private readonly string randName;
        private static string[] formats = new string[] { "M/d/yyyy h:mm:ss tt" };
        private static Random random = new Random();

        public ResourceNamer(string name)
        {
            lock (random)
            {
                this.randName = name.ToLower() + Guid.NewGuid().ToString("N").Substring(0, 3).ToLower();
            }
        }

        public virtual string RandomName(string prefix, int maxLen)
        {
            lock (random)
            {
                prefix = prefix.ToLower();
                int minRandomnessLength = 5;
                string minRandomString = random.Next(0, 100000).ToString("D5");

                if (maxLen < (prefix.Length + randName.Length + minRandomnessLength))
                {
                    var str1 = prefix + minRandomString;
                    return str1 + RandomString((maxLen - str1.Length) / 2);
                }

                string str = prefix + randName + minRandomString;
                return str + RandomString((maxLen - str.Length) / 2);
            }
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

        public virtual string RandomGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
