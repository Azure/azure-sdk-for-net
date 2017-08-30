
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
    /// The time settings of a device.
    /// </summary>
    [JsonTransformation]
    public partial class TimeSettings : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the TimeSettings class.
        /// </summary>
        public TimeSettings() { }

        /// <summary>
        /// Initializes a new instance of the TimeSettings class.
        /// </summary>
        /// <param name="timeZone">The timezone of device, like '(UTC -06:00)
        /// Central America'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="primaryTimeServer">The primary Network Time Protocol
        /// (NTP) server name, like 'time.windows.com'.</param>
        /// <param name="secondaryTimeServer">The secondary Network Time
        /// Protocol (NTP) server name, like 'time.contoso.com'. It's
        /// optional.</param>
        public TimeSettings(string timeZone, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), string primaryTimeServer = default(string), IList<string> secondaryTimeServer = default(IList<string>))
            : base(id, name, type, kind)
        {
            TimeZone = timeZone;
            PrimaryTimeServer = primaryTimeServer;
            SecondaryTimeServer = secondaryTimeServer;
        }

        /// <summary>
        /// Gets or sets the timezone of device, like '(UTC -06:00) Central
        /// America'
        /// </summary>
        [JsonProperty(PropertyName = "properties.timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the primary Network Time Protocol (NTP) server name,
        /// like 'time.windows.com'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.primaryTimeServer")]
        public string PrimaryTimeServer { get; set; }

        /// <summary>
        /// Gets or sets the secondary Network Time Protocol (NTP) server name,
        /// like 'time.contoso.com'. It's optional.
        /// </summary>
        [JsonProperty(PropertyName = "properties.secondaryTimeServer")]
        public IList<string> SecondaryTimeServer { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (TimeZone == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TimeZone");
            }
        }
    }
}

