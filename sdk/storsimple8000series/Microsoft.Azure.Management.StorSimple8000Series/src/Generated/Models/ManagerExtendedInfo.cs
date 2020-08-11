
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
    /// The extended info of the manager.
    /// </summary>
    [JsonTransformation]
    public partial class ManagerExtendedInfo : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the ManagerExtendedInfo class.
        /// </summary>
        public ManagerExtendedInfo() { }

        /// <summary>
        /// Initializes a new instance of the ManagerExtendedInfo class.
        /// </summary>
        /// <param name="integrityKey">Represents the CIK of the
        /// resource.</param>
        /// <param name="algorithm">Represents the encryption algorithm used to
        /// encrypt the keys. None - if Key is saved in plain text format.
        /// Algorithm name - if key is encrypted</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="version">The version of the extended info being
        /// persisted.</param>
        /// <param name="encryptionKey">Represents the CEK of the
        /// resource.</param>
        /// <param name="encryptionKeyThumbprint">Represents the Cert
        /// thumbprint that was used to encrypt the CEK.</param>
        /// <param name="portalCertificateThumbprint">Represents the portal
        /// thumbprint which can be used optionally to encrypt the entire data
        /// before storing it.</param>
        /// <param name="etag">The etag of the resource.</param>
        public ManagerExtendedInfo(string integrityKey, string algorithm, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), string version = default(string), string encryptionKey = default(string), string encryptionKeyThumbprint = default(string), string portalCertificateThumbprint = default(string), string etag = default(string))
            : base(id, name, type, kind)
        {
            Version = version;
            IntegrityKey = integrityKey;
            EncryptionKey = encryptionKey;
            EncryptionKeyThumbprint = encryptionKeyThumbprint;
            PortalCertificateThumbprint = portalCertificateThumbprint;
            Algorithm = algorithm;
            Etag = etag;
        }

        /// <summary>
        /// Gets or sets the version of the extended info being persisted.
        /// </summary>
        [JsonProperty(PropertyName = "properties.version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets represents the CIK of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.integrityKey")]
        public string IntegrityKey { get; set; }

        /// <summary>
        /// Gets or sets represents the CEK of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.encryptionKey")]
        public string EncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets represents the Cert thumbprint that was used to
        /// encrypt the CEK.
        /// </summary>
        [JsonProperty(PropertyName = "properties.encryptionKeyThumbprint")]
        public string EncryptionKeyThumbprint { get; set; }

        /// <summary>
        /// Gets or sets represents the portal thumbprint which can be used
        /// optionally to encrypt the entire data before storing it.
        /// </summary>
        [JsonProperty(PropertyName = "properties.portalCertificateThumbprint")]
        public string PortalCertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets represents the encryption algorithm used to encrypt
        /// the keys. None - if Key is saved in plain text format. Algorithm
        /// name - if key is encrypted
        /// </summary>
        [JsonProperty(PropertyName = "properties.algorithm")]
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the etag of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (IntegrityKey == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IntegrityKey");
            }
            if (Algorithm == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Algorithm");
            }
        }
    }
}

