using Microsoft.Azure.ApplicationInsights.Query.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Microsoft.Azure.ApplicationInsights.Query
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
