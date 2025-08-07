// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal static class GuidExtensions
    {
        /// <summary>
        /// Overload for Guid.ToString().
        /// </summary>
        /// <remarks>
        /// This method encapsulates the language switch for NetStandard and NetFramework and resolves the error "The behavior of guid.ToString() could vary based on the current user's locale settings"
        /// </remarks>
        public static string ToStringInvariant(this Guid guid, string format)
        {
            return guid.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}
