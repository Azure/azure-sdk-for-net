// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Monitor.Query.Logs
{
    /// <summary>
    /// Metrics Client Extension methods
    /// </summary>
    internal static partial class MonitorTypeExtensions
    {
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
