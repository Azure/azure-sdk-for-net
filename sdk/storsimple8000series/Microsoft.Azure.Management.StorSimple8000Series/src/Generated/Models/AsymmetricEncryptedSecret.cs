
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represent the secrets intended for encryption with asymmetric key pair.
    /// </summary>
    public partial class AsymmetricEncryptedSecret
    {
        /// <summary>
        /// Initializes a new instance of the AsymmetricEncryptedSecret class.
        /// </summary>
        public AsymmetricEncryptedSecret() { }

        /// <summary>
        /// Initializes a new instance of the AsymmetricEncryptedSecret class.
        /// </summary>
        /// <param name="value">The value of the secret.</param>
        /// <param name="encryptionAlgorithm">The algorithm used to encrypt
        /// "Value". Possible values include: 'None', 'AES256',
        /// 'RSAES_PKCS1_v_1_5'</param>
        /// <param name="encryptionCertThumbprint">Thumbprint certificate that
        /// was used to encrypt "Value". If the value in unencrypted, it will
        /// be null.</param>
        public AsymmetricEncryptedSecret(string value, EncryptionAlgorithm encryptionAlgorithm, string encryptionCertThumbprint = default(string))
        {
            Value = value;
            EncryptionCertThumbprint = encryptionCertThumbprint;
            EncryptionAlgorithm = encryptionAlgorithm;
        }

        /// <summary>
        /// Gets or sets the value of the secret.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets thumbprint certificate that was used to encrypt
        /// "Value". If the value in unencrypted, it will be null.
        /// </summary>
        [JsonProperty(PropertyName = "encryptionCertThumbprint")]
        public string EncryptionCertThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the algorithm used to encrypt "Value". Possible values
        /// include: 'None', 'AES256', 'RSAES_PKCS1_v_1_5'
        /// </summary>
        [JsonProperty(PropertyName = "encryptionAlgorithm")]
        public EncryptionAlgorithm EncryptionAlgorithm { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Value == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Value");
            }
        }
    }
}

