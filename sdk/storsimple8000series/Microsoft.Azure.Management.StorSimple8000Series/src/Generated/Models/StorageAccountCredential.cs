
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
    /// The storage account credential.
    /// </summary>
    [JsonTransformation]
    public partial class StorageAccountCredential : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the StorageAccountCredential class.
        /// </summary>
        public StorageAccountCredential() { }

        /// <summary>
        /// Initializes a new instance of the StorageAccountCredential class.
        /// </summary>
        /// <param name="endPoint">The storage endpoint</param>
        /// <param name="sslStatus">Signifies whether SSL needs to be enabled
        /// or not. Possible values include: 'Enabled', 'Disabled'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="accessKey">The details of the storage account
        /// password.</param>
        /// <param name="volumesCount">The count of volumes using this storage
        /// account credential.</param>
        public StorageAccountCredential(string endPoint, SslStatus sslStatus, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), AsymmetricEncryptedSecret accessKey = default(AsymmetricEncryptedSecret), int? volumesCount = default(int?))
            : base(id, name, type, kind)
        {
            EndPoint = endPoint;
            SslStatus = sslStatus;
            AccessKey = accessKey;
            VolumesCount = volumesCount;
        }

        /// <summary>
        /// Gets or sets the storage endpoint
        /// </summary>
        [JsonProperty(PropertyName = "properties.endPoint")]
        public string EndPoint { get; set; }

        /// <summary>
        /// Gets or sets signifies whether SSL needs to be enabled or not.
        /// Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.sslStatus")]
        public SslStatus SslStatus { get; set; }

        /// <summary>
        /// Gets or sets the details of the storage account password.
        /// </summary>
        [JsonProperty(PropertyName = "properties.accessKey")]
        public AsymmetricEncryptedSecret AccessKey { get; set; }

        /// <summary>
        /// Gets the count of volumes using this storage account credential.
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumesCount")]
        public int? VolumesCount { get; protected set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (EndPoint == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EndPoint");
            }
            if (AccessKey != null)
            {
                AccessKey.Validate();
            }
        }
    }
}

