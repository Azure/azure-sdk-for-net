// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
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

        internal static string CommaJoin(IEnumerable<MetricAggregationType> aggregations)
        {
            string result = "";
            if (aggregations == null)
            {
                return result;
            }
            for (int i = 0; i < aggregations.Count(); i++)
            {
                result += aggregations.ElementAt(i).ToString();
                if (i < aggregations.Count() - 1)
                {
                    result += ",";
                }
            }
            return result;
        }

        /// <summary>
        /// Split a collection of strings by commas.
        /// </summary>
        /// <param name="value">The value to split.</param>
        /// <returns>A collection of individual values.</returns>
        internal static IList<string> CommaSplit(string value) =>
            string.IsNullOrEmpty(value) ?
                new List<string>() :
                // TODO: #10600 - Verify we don't need to worry about escaping
                new List<string>(value.Split(','));

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
