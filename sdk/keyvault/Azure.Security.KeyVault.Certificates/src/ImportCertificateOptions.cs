// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Options for a certificate to be imported into Azure Key Vault.
    /// </summary>
    public class ImportCertificateOptions : IJsonSerializable
    {
        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode("value");
        private static readonly JsonEncodedText s_policyPropertyNameBytes = JsonEncodedText.Encode("policy");
        private static readonly JsonEncodedText s_passwordPropertyNameBytes = JsonEncodedText.Encode("pwd");
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode("attributes");
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode("enabled");
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode("tags");
        private static readonly JsonEncodedText s_preserveCertificateOrderPropertyNameBytes = JsonEncodedText.Encode("preserveCertOrder");

        private Dictionary<string, string> _tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportCertificateOptions"/> class.
        /// </summary>
        /// <param name="name">A name for the imported certificate.</param>
        /// <param name="certificate">The PFX or ASCII PEM-formatted value of the certificate containing both the X.509 certificates and the private key.</param>
        /// <remarks>
        /// If importing an ASCII PEM-formatted certificate, you must also create a <see cref="CertificatePolicy"/> with <see cref="CertificatePolicy.ContentType"/>
        /// set to <see cref="CertificateContentType.Pem"/>, and set the <see cref="Policy"/> property. If the <see cref="Policy"/> property or
        /// <see cref="CertificatePolicy.ContentType"/> property is not set, <see cref="CertificateContentType.Pkcs12"/> is assumed and the import will fail.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="certificate"/> is null.</exception>
        public ImportCertificateOptions(string name, byte[] certificate)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(certificate, nameof(certificate));

            Name = name;
            Certificate = certificate;
        }

        /// <summary>
        /// Gets the name of the certificate to import.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the PFX or ASCII PEM-formatted value of the certificate containing both the X.509 certificates and the private key.
        /// </summary>
        public byte[] Certificate { get; }

        /// <summary>
        /// Gets or sets the policy which governs the lifecycle of the imported certificate and its properties when it is rotated.
        /// </summary>
        /// <remarks>
        /// If setting the policy, <see cref="CertificatePolicy.ContentType"/> must be set to a valid <see cref="CertificateContentType"/> value.
        /// </remarks>
        public CertificatePolicy Policy { get; set; }

        /// <summary>
        /// Gets or sets the password protecting the certificate specified in the Value.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the merged certificate should be enabled. If null, the server default will be used.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets the tags to be applied to the imported certificate. Although this collection cannot be set, it can be modified
        ///  or initialized with a <see href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer">collection initializer</see>.
        /// </summary>
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

        /// <summary>
        /// Gets or sets a value indicating whether the certificate chain preserves its original order.
        /// The default value is false, which sets the leaf certificate at index 0.
        /// </summary>
        public bool? PreserveCertificateOrder { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Certificate != null)
            {
                if (Policy != null && Policy.ContentType == CertificateContentType.Pem)
                {
                    string value = Encoding.ASCII.GetString(Certificate);
                    json.WriteString(s_valuePropertyNameBytes, value);
                }
                else
                {
                    json.WriteBase64String(s_valuePropertyNameBytes, Certificate);
                }
            }

            if (!string.IsNullOrEmpty(Password))
            {
                json.WriteString(s_passwordPropertyNameBytes, Password);
            }

            if (Policy != null)
            {
                json.WriteStartObject(s_policyPropertyNameBytes);

                ((IJsonSerializable)Policy).WriteProperties(json);

                json.WriteEndObject();
            }

            if (Enabled.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }

            if (!_tags.IsNullOrEmpty())
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in _tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            if (PreserveCertificateOrder.HasValue)
            {
                json.WriteBoolean(s_preserveCertificateOrderPropertyNameBytes, PreserveCertificateOrder.Value);
            }
        }
    }
}
