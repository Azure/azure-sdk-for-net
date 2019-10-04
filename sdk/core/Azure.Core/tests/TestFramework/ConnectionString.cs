// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Testing
{
    public class ConnectionString
    {
        public IDictionary<string, string> Pairs { get; }

        public ConnectionString(IDictionary<string, string> pairs)
        {
            Pairs = pairs;
        }

        public static ConnectionString Parse(string connectionString)
        {
            SortedDictionary<string, string> pairs = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var pair in connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var indexOfEquals = pair.IndexOf('=');
                if (indexOfEquals == -1)
                {
                    throw new InvalidOperationException($"Invalid connection string segment '{pair}'");
                }

                var key = pair.Substring(0, indexOfEquals);
                var value = pair.Substring(indexOfEquals + 1, pair.Length - indexOfEquals - 1);

                if (pairs.ContainsKey(key))
                {
                    throw new InvalidOperationException($"Duplicated key '{key}'");
                }

                pairs[key] = value;
            }

            return new ConnectionString(pairs);
        }

        public ConnectionString Clone()
        {
            return new ConnectionString(new SortedDictionary<string, string>(Pairs, StringComparer.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in Pairs)
            {
                stringBuilder.Append(pair.Key).Append('=').Append(pair.Value).Append(';');
            }
            return stringBuilder.ToString();
        }
    }
}
