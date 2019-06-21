
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
    /// The access control record.
    /// </summary>
    [JsonTransformation]
    public partial class AccessControlRecord : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the AccessControlRecord class.
        /// </summary>
        public AccessControlRecord() { }

        /// <summary>
        /// Initializes a new instance of the AccessControlRecord class.
        /// </summary>
        /// <param name="initiatorName">The iSCSI initiator name (IQN).</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="volumeCount">The number of volumes using the access
        /// control record.</param>
        public AccessControlRecord(string initiatorName, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), int? volumeCount = default(int?))
            : base(id, name, type, kind)
        {
            InitiatorName = initiatorName;
            VolumeCount = volumeCount;
        }

        /// <summary>
        /// Gets or sets the iSCSI initiator name (IQN).
        /// </summary>
        [JsonProperty(PropertyName = "properties.initiatorName")]
        public string InitiatorName { get; set; }

        /// <summary>
        /// Gets the number of volumes using the access control record.
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
            if (InitiatorName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "InitiatorName");
            }
        }
    }
}

