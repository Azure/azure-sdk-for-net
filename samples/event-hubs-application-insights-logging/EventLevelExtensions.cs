// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ApplicationInsights.DataContracts;
using System.Diagnostics.Tracing;

namespace AzureEventSourceListenerEventHubsLogging
{
    /// <summary>
    /// Severity level extensions for <see cref="EventLevel"/>.
    /// </summary>
    static class EventLevelExtensions
    {
        /// <summary>
        /// Convert the  <see cref="EventLevel"/> value to the right <see cref="SeverityLevel"/> value.
        /// </summary>
        /// <param name="eventLevel">The <see cref="EventLevel"/>.</param>
        /// <returns>Return the mapped <see cref="SeverityLevel"/>.</returns>
        internal static SeverityLevel GetSeverityLevel(this EventLevel eventLevel)
        {
            switch (eventLevel)
            {
                case EventLevel.LogAlways:
                    return SeverityLevel.Verbose;
                case EventLevel.Critical:
                    return SeverityLevel.Critical;
                case EventLevel.Error:
                    return SeverityLevel.Error;
                case EventLevel.Warning:
                    return SeverityLevel.Warning;
                case EventLevel.Informational:
                    return SeverityLevel.Information;
                case EventLevel.Verbose:
                    return SeverityLevel.Verbose;
                default:
                    return SeverityLevel.Information;
            }
        }
    }
}