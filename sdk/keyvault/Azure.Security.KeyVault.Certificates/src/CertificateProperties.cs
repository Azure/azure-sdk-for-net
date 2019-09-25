// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateProperties : IJsonDeserializable
    {
        private const string IdPropertyName = "id";
        private const string X509ThumprintPropertyName = "x5t";
        private const string TagsPropertyName = "tags";
        private const string AttributesPropertyName = "attributes";

        private CertificateAttributes _attributes;

        /// <summary>
        /// The Id of the certificate.
        /// </summary>
        public Uri Id { get; private set; }

        /// <summary>
        /// The name of the certificate.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Uri of the vault in which the certificate is stored.
        /// </summary>
        public Uri VaultUri { get; private set; }

        /// <summary>
        /// The version of the certificate.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// The digital thumbprint of the certificate which can be used to uniquely identify it.
        /// </summary>
        public byte[] X509Thumbprint { get; private set; }

        /// <summary>
        /// The tags applied to the certificate.
        /// </summary>
        public IDictionary<string, string> Tags { get; private set; }

        /// <summary>
        /// Specifies if the certificate is currently enabled.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Gets or sets not before date in UTC.
        /// </summary>
        public DateTimeOffset? NotBefore => _attributes.NotBefore;

        /// <summary>
        /// Gets or sets expiry date in UTC.
        /// </summary>
        public DateTimeOffset? Expires => _attributes.Expires;

        /// <summary>
        /// Gets creation time in UTC.
        /// </summary>
        public DateTimeOffset? Created => _attributes.Created;

        /// <summary>
        /// Gets last updated time in UTC.
        /// </summary>
        public DateTimeOffset? Updated => _attributes.Updated;

        /// <summary>
        /// Gets reflects the deletion recovery level currently in effect for
        /// secrets in the current vault. If it contains 'Purgeable', the
        /// secret can be permanently deleted by a privileged user; otherwise,
        /// only the system can purge the secret, at the end of the retention
        /// interval. Possible values include: 'Purgeable',
        /// 'Recoverable+Purgeable', 'Recoverable',
        /// 'Recoverable+ProtectedSubscription'
        /// </summary>
        public string RecoveryLevel => _attributes.RecoveryLevel;

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
                    ParseId(id);
                    break;

                case X509ThumprintPropertyName:
                    X509Thumbprint = Base64Url.Decode(prop.Value.GetString());
                    break;

                case TagsPropertyName:
                    Tags = new Dictionary<string, string>();
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

        private void ParseId(string id)
        {
            var idToParse = new Uri(id, UriKind.Absolute);

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "certificates" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'certificates/', found '{1}'", id, idToParse.Segments[1]));

            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
            Version = (idToParse.Segments.Length == 4) ? idToParse.Segments[3].TrimEnd('/') : null;
        }

    }
}
