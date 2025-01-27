// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Mgmt.Models
{
    internal class SingletonResourceSuffix
    {
        public static SingletonResourceSuffix Parse(string[] segments)
        {
            // put the segments in pairs
            var pairs = new List<(string Key, string Value)>();
            for (int i = 0; i < segments.Length; i += 2)
            {
                pairs.Add((segments[i], segments[i + 1]));
            }

            return new SingletonResourceSuffix(pairs);
        }

        private IReadOnlyList<(string Key, string Value)> _pairs;

        private SingletonResourceSuffix(IReadOnlyList<(string Key, string Value)> pairs)
        {
            _pairs = pairs;
        }
    }
}
