// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Azure.Monitor.Query.Metrics
{
    /// <summary>
    /// Metrics Client Extension methods
    /// </summary>
    internal static partial class MetricsClientExtensions
    {
        /// <summary>
        /// Join a collection of strings into a single comma separated string.
        /// If the collection is null or empty, a null string will be returned.
        /// </summary>
        /// <param name="items">The items to join.</param>
        /// <returns>The items joined together by commas.</returns>
        internal static string CommaJoin(this IEnumerable<string> items) =>
            items != null && items.Any() ? string.Join(",", items) : null;

        internal static string ToIsoString(this DateTimeOffset value)
        {
            if (value.Offset == TimeSpan.Zero)
            {
                // Some Azure service required 0-offset dates to be formatted without the
                // -00:00 part
                const string roundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
                return value.ToString(roundtripZFormat, CultureInfo.InvariantCulture);
            }

            return value.ToString("O", CultureInfo.InvariantCulture);
        }

        internal static string ToIsoString(this DateTimeOffset? value) => value?.ToIsoString();
    }
}
