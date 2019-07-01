
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The updates profile of a device.
    /// </summary>
    [JsonTransformation]
    public partial class Updates : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Updates class.
        /// </summary>
        public Updates() { }

        /// <summary>
        /// Initializes a new instance of the Updates class.
        /// </summary>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="regularUpdatesAvailable">Set to 'true' if regular
        /// updates are available for the device.</param>
        /// <param name="maintenanceModeUpdatesAvailable">Set to 'true' if
        /// maintenance mode update available.</param>
        /// <param name="isUpdateInProgress">Indicates whether an update is in
        /// progress or not.</param>
        /// <param name="lastUpdatedTime">The time when the last update was
        /// completed.</param>
        public Updates(string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), bool? regularUpdatesAvailable = default(bool?), bool? maintenanceModeUpdatesAvailable = default(bool?), bool? isUpdateInProgress = default(bool?), System.DateTime? lastUpdatedTime = default(System.DateTime?))
            : base(id, name, type, kind)
        {
            RegularUpdatesAvailable = regularUpdatesAvailable;
            MaintenanceModeUpdatesAvailable = maintenanceModeUpdatesAvailable;
            IsUpdateInProgress = isUpdateInProgress;
            LastUpdatedTime = lastUpdatedTime;
        }

        /// <summary>
        /// Gets or sets set to 'true' if regular updates are available for the
        /// device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.regularUpdatesAvailable")]
        public bool? RegularUpdatesAvailable { get; set; }

        /// <summary>
        /// Gets or sets set to 'true' if maintenance mode update available.
        /// </summary>
        [JsonProperty(PropertyName = "properties.maintenanceModeUpdatesAvailable")]
        public bool? MaintenanceModeUpdatesAvailable { get; set; }

        /// <summary>
        /// Gets or sets indicates whether an update is in progress or not.
        /// </summary>
        [JsonProperty(PropertyName = "properties.isUpdateInProgress")]
        public bool? IsUpdateInProgress { get; set; }

        /// <summary>
        /// Gets or sets the time when the last update was completed.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastUpdatedTime")]
        public System.DateTime? LastUpdatedTime { get; set; }

    }
}

