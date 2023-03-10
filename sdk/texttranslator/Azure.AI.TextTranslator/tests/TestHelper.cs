// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;

namespace Azure.AI.TextTranslator.Tests
{
    internal class TestHelper
    {
        internal static int EditDistance(string s1, string s2)
        {
            int n1 = s1.Length;
            int n2 = s2.Length;
            return Distance(s1, s2, n1, n2);
        }

        internal static int Distance(string s1, string s2, int n1, int n2)
        {
            if (n1 == 0)
            {
                return n2;
            }

            if (n2 == 0)
            {
                return n1;
            }

            if (s1[n1 - 1] == s2[n2 - 1])
            {
                return Distance(s1, s2, n1 - 1, n2 - 1);
            }

            var nums = new int[] { Distance(s1, s2, n1, n2 - 1), Distance(s1, s2, n1 - 1, n2), Distance(s1, s2, n1 - 1, n2 - 1) };

            return 1 + nums.Min();
        }
    }
}
