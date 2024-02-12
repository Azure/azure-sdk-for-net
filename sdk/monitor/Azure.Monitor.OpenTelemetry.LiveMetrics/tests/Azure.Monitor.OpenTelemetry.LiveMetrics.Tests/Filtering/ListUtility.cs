// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering.Tests
{
    internal static class ListUtility
    {
        public static string? GetValue(this IList<KeyValuePairString> list, string key)
        {
            foreach (var item in list)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}
