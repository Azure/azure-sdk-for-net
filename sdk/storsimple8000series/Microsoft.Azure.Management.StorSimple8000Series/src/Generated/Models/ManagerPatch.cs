
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
    /// The StorSimple Manager patch.
    /// </summary>
    public partial class ManagerPatch
    {
        /// <summary>
        /// Initializes a new instance of the ManagerPatch class.
        /// </summary>
        public ManagerPatch() { }

        /// <summary>
        /// Initializes a new instance of the ManagerPatch class.
        /// </summary>
        /// <param name="tags">The tags attached to the Manager.</param>
        public ManagerPatch(IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            Tags = tags;
        }

        /// <summary>
        /// Gets or sets the tags attached to the Manager.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

    }
}

