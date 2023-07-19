using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// A trace events query result.
    /// </summary>
    public class EventsTraceResults : EventsResults
    {
        /// <summary>
        /// Gets or sets contents of the events query result.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public new IList<EventsTraceResult> Value { get; set; }
    }
}
