﻿using Microsoft.Azure.ApplicationInsights.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights
{
    public partial interface IApplicationInsightsDataClient
    {
        /// <summary>
        /// Additional apps referenced in cross-resource queries.
        /// </summary>
        IList<string> AdditionalApplications { get; set; }

        ApiPreferences Preferences { get; set; }

        /// <summary>
        /// Unique name for the calling application. This is only used for telemetry and debugging.
        /// </summary>
        string NameHeader { get; set; }

        /// <summary>
        /// A unique ID per request. This will be generated per request if not specified.
        /// </summary>
        string RequestId { get; set; }
    }
}
