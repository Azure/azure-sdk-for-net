// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// <see cref="CertificateProperties"/> contains identity and other basic properties of a <see cref="KeyVaultCertificate"/>.
    /// </summary>
    public class CertificateProperties : IJsonDeserializable
    {
        private const string IdPropertyName = "id";
        private const string X509ThumprintPropertyName = "x5t";
        private const string TagsPropertyName = "tags";
        private const string AttributesPropertyName = "attributes";

        private CertificateAttributes _attributes;
        private Dictionary<string, string> _tags;

        internal CertificateProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateProperties"/> class.
        /// </summary>
        /// <param name="name">The name of the certificate.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public CertificateProperties(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateProperties"/> class.
        /// </summary>
        /// <param name="id">The identifier of the certificate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public CertificateProperties(Uri id)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
            ParseId(id);
        }

        /// <summary>
        /// Gets the identifier of the certificate.
        /// </summary>
        public Uri Id { get; internal set; }

        /// <summary>
        /// Gets the name of the certificate.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault in which the certificate is stored.
        /// </summary>
        public Uri VaultUri { get; internal set; }

        /// <summary>
        /// Gets the version of the certificate.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// Gets the digital thumbprint of the certificate which can be used to uniquely identify it.
        /// </summary>
        public byte[] X509Thumbprint { get; internal set; }

        /// <summary>
        /// Gets the tags applied to the certificate.
        /// </summary>
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

        /// <summary>
        /// Gets or sets a value indicating whether the certificate is currently enabled. If null, the server default will be used.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate will be valid.
        /// </summary>
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; internal set => _attributes.NotBefore = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate will expire.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get => _attributes.ExpiresOn; internal set => _attributes.ExpiresOn = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get => _attributes.CreatedOn; internal set => _attributes.CreatedOn = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get => _attributes.UpdatedOn; internal set => _attributes.UpdatedOn = value; }

        /// <summary>
        /// Gets the number of days a certificate is retained before being deleted for a soft delete-enabled Key Vault.
        /// </summary>
        public int? RecoverableDays { get => _attributes.RecoverableDays; internal set => _attributes.RecoverableDays = value; }

        /// <summary>
        /// Gets the recovery level currently in effect for certificates in the Key Vault.
        /// If <c>Purgeable</c>, the certificates can be permanently deleted by an authorized user;
        /// otherwise, only the service can purge the certificates at the end of the retention interval.
        /// </summary>
        /// <value>Possible values include <c>Purgeable</c>, <c>Recoverable+Purgeable</c>, <c>Recoverable</c>, and <c>Recoverable+ProtectedSubscription</c>.</value>
        public string RecoveryLevel { get => _attributes.RecoveryLevel; internal set => _attributes.RecoveryLevel = value; }

        internal bool HasTags => _tags != null;

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        internal void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case IdPropertyName:
                    var id = prop.Value.GetString();
                    Id = new Uri(id);
                    ParseId(Id);
                    break;

                case X509ThumprintPropertyName:
                    X509Thumbprint = Base64Url.Decode(prop.Value.GetString());
                    break;

                case TagsPropertyName:
                    foreach (JsonProperty tagProp in prop.Value.EnumerateObject())
                    {
                        Tags[tagProp.Name] = tagProp.Value.GetString();
                    }
                    break;

                case AttributesPropertyName:
                    _attributes.ReadProperties(prop.Value);
                    break;
            }
        }

        private void ParseId(Uri idToParse)
        {
            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", idToParse, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "certificates" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'certificates/', found '{1}'", idToParse, idToParse.Segments[1]));

            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
            Version = (idToParse.Segments.Length == 4) ? idToParse.Segments[3].TrimEnd('/') : null;
        }
    }
}
