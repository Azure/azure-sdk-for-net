
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
    /// The metadata of the volume container, that is being considered as part
    /// of a failover set.
    /// </summary>
    public partial class VolumeContainerFailoverMetadata
    {
        /// <summary>
        /// Initializes a new instance of the VolumeContainerFailoverMetadata
        /// class.
        /// </summary>
        public VolumeContainerFailoverMetadata() { }

        /// <summary>
        /// Initializes a new instance of the VolumeContainerFailoverMetadata
        /// class.
        /// </summary>
        /// <param name="volumeContainerId">The path ID of the volume
        /// container.</param>
        /// <param name="volumes">The list of metadata of volumes inside the
        /// volume container, which contains valid cloud snapshots.</param>
        public VolumeContainerFailoverMetadata(string volumeContainerId = default(string), IList<VolumeFailoverMetadata> volumes = default(IList<VolumeFailoverMetadata>))
        {
            VolumeContainerId = volumeContainerId;
            Volumes = volumes;
        }

        /// <summary>
        /// Gets or sets the path ID of the volume container.
        /// </summary>
        [JsonProperty(PropertyName = "volumeContainerId")]
        public string VolumeContainerId { get; set; }

        /// <summary>
        /// Gets or sets the list of metadata of volumes inside the volume
        /// container, which contains valid cloud snapshots.
        /// </summary>
        [JsonProperty(PropertyName = "volumes")]
        public IList<VolumeFailoverMetadata> Volumes { get; set; }

    }
}

