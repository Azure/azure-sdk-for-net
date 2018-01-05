using Microsoft.Azure.OperationalInsights.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.OperationalInsights
{
    public partial interface IOperationalInsightsDataClient : System.IDisposable
    {
        /// <summary>
        /// Additional workspaces referenced in cross-resource queries.
        /// </summary>
        IList<string> AdditionalWorkspaces { get; set; }

        /// <summary>
        /// Query preferences.
        /// </summary>
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
