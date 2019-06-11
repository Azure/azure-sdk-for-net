
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The request object for fetching the list of failover targets (eligible
    /// devices for failover).
    /// </summary>
    public partial class ListFailoverTargetsRequest
    {
        /// <summary>
        /// Initializes a new instance of the ListFailoverTargetsRequest class.
        /// </summary>
        public ListFailoverTargetsRequest() { }

        /// <summary>
        /// Initializes a new instance of the ListFailoverTargetsRequest class.
        /// </summary>
        /// <param name="volumeContainers">The list of path IDs of the volume
        /// containers that needs to be failed-over, for which we want to fetch
        /// the eligible targets.</param>
        public ListFailoverTargetsRequest(IList<string> volumeContainers = default(IList<string>))
        {
            VolumeContainers = volumeContainers;
        }

        /// <summary>
        /// Gets or sets the list of path IDs of the volume containers that
        /// needs to be failed-over, for which we want to fetch the eligible
        /// targets.
        /// </summary>
        [JsonProperty(PropertyName = "volumeContainers")]
        public IList<string> VolumeContainers { get; set; }

    }
}

