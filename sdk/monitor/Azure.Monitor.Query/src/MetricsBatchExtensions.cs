// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Metrics Batch Query Extension methods
    /// </summary>
    internal static partial class MetricsBatchExtensions
    {
        /// <summary>
        /// Join a collection of strings into a single comma separated string.
        /// If the collection is null or empty, a null string will be returned.
        /// </summary>
        /// <param name="items">The items to join.</param>
        /// <returns>The items joined together by commas.</returns>
        internal static string CommaJoin(this IEnumerable<string> items) =>
            items != null && items.Any() ? string.Join(",", items) : null;

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
    }
}
