
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The bandwidth setting.
    /// </summary>
    [JsonTransformation]
    public partial class BandwidthSetting : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the BandwidthSetting class.
        /// </summary>
        public BandwidthSetting() { }

        /// <summary>
        /// Initializes a new instance of the BandwidthSetting class.
        /// </summary>
        /// <param name="schedules">The schedules.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="volumeCount">The number of volumes that uses the
        /// bandwidth setting.</param>
        public BandwidthSetting(IList<BandwidthSchedule> schedules, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), int? volumeCount = default(int?))
            : base(id, name, type, kind)
        {
            Schedules = schedules;
            VolumeCount = volumeCount;
        }

        /// <summary>
        /// Gets or sets the schedules.
        /// </summary>
        [JsonProperty(PropertyName = "properties.schedules")]
        public IList<BandwidthSchedule> Schedules { get; set; }

        /// <summary>
        /// Gets the number of volumes that uses the bandwidth setting.
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumeCount")]
        public int? VolumeCount { get; protected set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Schedules == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Schedules");
            }
            if (Schedules != null)
            {
                foreach (var element in Schedules)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}

