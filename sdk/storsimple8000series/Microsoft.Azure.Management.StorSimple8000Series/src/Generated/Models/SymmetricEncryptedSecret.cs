
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents the secrets encrypted using Symmetric Encryption Key.
    /// </summary>
    public partial class SymmetricEncryptedSecret
    {
        /// <summary>
        /// Initializes a new instance of the SymmetricEncryptedSecret class.
        /// </summary>
        public SymmetricEncryptedSecret() { }

        /// <summary>
        /// Initializes a new instance of the SymmetricEncryptedSecret class.
        /// </summary>
        /// <param name="value">The value of the secret itself. If the secret
        /// is in plaintext or null then EncryptionAlgorithm will be
        /// none.</param>
        /// <param name="encryptionAlgorithm">The algorithm used to encrypt the
        /// "Value". Possible values include: 'None', 'AES256',
        /// 'RSAES_PKCS1_v_1_5'</param>
        /// <param name="valueCertificateThumbprint">The thumbprint of the cert
        /// that was used to encrypt "Value".</param>
        public SymmetricEncryptedSecret(string value, EncryptionAlgorithm encryptionAlgorithm, string valueCertificateThumbprint = default(string))
        {
            Value = value;
            ValueCertificateThumbprint = valueCertificateThumbprint;
            EncryptionAlgorithm = encryptionAlgorithm;
        }

        /// <summary>
        /// Gets or sets the value of the secret itself. If the secret is in
        /// plaintext or null then EncryptionAlgorithm will be none.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the thumbprint of the cert that was used to encrypt
        /// "Value".
        /// </summary>
        [JsonProperty(PropertyName = "valueCertificateThumbprint")]
        public string ValueCertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the algorithm used to encrypt the "Value". Possible
        /// values include: 'None', 'AES256', 'RSAES_PKCS1_v_1_5'
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

