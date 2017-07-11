
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The source details at which the alert was raised
    /// </summary>
    public partial class AlertSource
    {
        /// <summary>
        /// Initializes a new instance of the AlertSource class.
        /// </summary>
        public AlertSource() { }

        /// <summary>
        /// Initializes a new instance of the AlertSource class.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="timeZone">The time zone of the source</param>
        /// <param name="alertSourceType">The source type of the alert.
        /// Possible values include: 'Resource', 'Device'</param>
        public AlertSource(string name = default(string), string timeZone = default(string), AlertSourceType? alertSourceType = default(AlertSourceType?))
        {
            Name = name;
            TimeZone = timeZone;
            AlertSourceType = alertSourceType;
        }

        /// <summary>
        /// Gets or sets the name of the source
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the time zone of the source
        /// </summary>
        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the source type of the alert. Possible values include:
        /// 'Resource', 'Device'
        /// </summary>
        [JsonProperty(PropertyName = "alertSourceType")]
        public AlertSourceType? AlertSourceType { get; set; }

    }
}

