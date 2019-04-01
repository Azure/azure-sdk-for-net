
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
    /// The request object for triggering a failover of volume containers, from
    /// a source device to a target device.
    /// </summary>
    public partial class FailoverRequest
    {
        /// <summary>
        /// Initializes a new instance of the FailoverRequest class.
        /// </summary>
        public FailoverRequest() { }

        /// <summary>
        /// Initializes a new instance of the FailoverRequest class.
        /// </summary>
        /// <param name="targetDeviceId">The ARM path ID of the device which
        /// will act as the failover target.</param>
        /// <param name="volumeContainers">The list of path IDs of the volume
        /// containers which needs to be failed-over to the target
        /// device.</param>
        public FailoverRequest(string targetDeviceId = default(string), IList<string> volumeContainers = default(IList<string>))
        {
            TargetDeviceId = targetDeviceId;
            VolumeContainers = volumeContainers;
        }

        /// <summary>
        /// Gets or sets the ARM path ID of the device which will act as the
        /// failover target.
        /// </summary>
        [JsonProperty(PropertyName = "targetDeviceId")]
        public string TargetDeviceId { get; set; }

        /// <summary>
        /// Gets or sets the list of path IDs of the volume containers which
        /// needs to be failed-over to the target device.
        /// </summary>
        [JsonProperty(PropertyName = "volumeContainers")]
        public IList<string> VolumeContainers { get; set; }

    }
}

