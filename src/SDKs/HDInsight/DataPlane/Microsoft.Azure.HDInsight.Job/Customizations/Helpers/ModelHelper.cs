// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal static class ModelHelper
    {
        internal static int MaxStringSizeForUrlEscapeData = 32766;

        internal static string GetStatusDirectory(string status)
        {
            var statusDir = status;
            if (string.IsNullOrWhiteSpace(statusDir))
            {
                // Format of status directory: 2009-06-15T13-45-30-<guid>
                statusDir = DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture);

                // Can't create a directory with char ":" in azure storage
                statusDir = statusDir.Replace(':', '-');
                statusDir = string.Format("{0}-{1}", statusDir, Guid.NewGuid().ToString());
            }

            return statusDir;
        }

        internal static string ConvertItemsToString(IEnumerable<KeyValuePair<string, string>> args)
        {
            var strings = (from kvp in args
                           select kvp.Key.EscapeDataString() + "=" + kvp.Value.EscapeDataString()).ToList();
            return string.Join("&", strings);
        }

        internal static string EscapeDataString(this string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return string.Empty;
            }

            var escapeString = string.Empty;
            int i = 0;

            while (i < inputValue.Length / MaxStringSizeForUrlEscapeData)
            {
                escapeString += Uri.EscapeDataString(inputValue.Substring(MaxStringSizeForUrlEscapeData * i, MaxStringSizeForUrlEscapeData));
                i++;
            }

            escapeString += Uri.EscapeDataString(inputValue.Substring(MaxStringSizeForUrlEscapeData * i));

            return escapeString;
        }

        internal static IEnumerable<KeyValuePair<string, string>> BuildNameValueList(string paramName, IEnumerable<KeyValuePair<string, string>> nameValuePairs)
        {
            List<KeyValuePair<string, string>> retval = new List<KeyValuePair<string, string>>();

            foreach (var kvp in nameValuePairs)
            {
                retval.Add(new KeyValuePair<string, string>(paramName, kvp.Key + "=" + kvp.Value));
            }
            return retval;
        }

        internal static IEnumerable<KeyValuePair<string, string>> BuildList(string type, IEnumerable<string> args)
        {
            List<KeyValuePair<string, string>> retval = new List<KeyValuePair<string, string>>();

            foreach (var arg in args)
            {
                retval.Add(new KeyValuePair<string, string>(type, arg));
            }
            return retval;
        }

        internal static string BuildListToCommaSeparatedString(IEnumerable<string> input)
        {
            return string.Join(",", input.ToArray());
        }

        internal static void Delay(TimeSpan duration)
        {
            Task.Delay(duration).Wait();
        }
    }
}
