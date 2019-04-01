
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
    /// The failover set on a device.
    /// </summary>
    public partial class FailoverSet
    {
        /// <summary>
        /// Initializes a new instance of the FailoverSet class.
        /// </summary>
        public FailoverSet() { }

        /// <summary>
        /// Initializes a new instance of the FailoverSet class.
        /// </summary>
        /// <param name="volumeContainers">The list of meta data of volume
        /// containers, which are part of the failover set.</param>
        /// <param name="eligibilityResult">The eligibility result of the
        /// failover set, for failover.</param>
        public FailoverSet(IList<VolumeContainerFailoverMetadata> volumeContainers = default(IList<VolumeContainerFailoverMetadata>), FailoverSetEligibilityResult eligibilityResult = default(FailoverSetEligibilityResult))
        {
            VolumeContainers = volumeContainers;
            EligibilityResult = eligibilityResult;
        }

        /// <summary>
        /// Gets or sets the list of meta data of volume containers, which are
        /// part of the failover set.
        /// </summary>
        [JsonProperty(PropertyName = "volumeContainers")]
        public IList<VolumeContainerFailoverMetadata> VolumeContainers { get; set; }

        /// <summary>
        /// Gets or sets the eligibility result of the failover set, for
        /// failover.
        /// </summary>
        [JsonProperty(PropertyName = "eligibilityResult")]
        public FailoverSetEligibilityResult EligibilityResult { get; set; }

    }
}

