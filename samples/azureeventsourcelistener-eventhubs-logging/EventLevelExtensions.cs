using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace AzureEventSourceListenerEventHubsLogging
{
    internal static class EventLevelExtensions
    {
        internal static SeverityLevel GetSeverityLevel(this EventLevel eventEntry)
        {
            switch (eventEntry)
            {
                case EventLevel.Verbose:
                    return SeverityLevel.Verbose;
                case EventLevel.Informational:
                    return SeverityLevel.Information;
                case EventLevel.Warning:
                    return SeverityLevel.Warning;
                case EventLevel.Error:
                    return SeverityLevel.Error;
                case EventLevel.Critical:
                    return SeverityLevel.Critical;
                default:
                    return SeverityLevel.Information;
            }
        }
    }
}
