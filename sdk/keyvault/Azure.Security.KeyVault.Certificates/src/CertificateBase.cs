// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateBase : IJsonDeserializable
    {
        private CertificateAttributes _attributes;

        public Uri Id { get; private set; }

        public string Name { get; private set; }

        public Uri VaultUri { get; private set; }

        public string Version { get; private set; }

        public byte[] X509Thumbprint { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        public DateTimeOffset? NotBefore => _attributes.NotBefore;

        public DateTimeOffset? Expires => _attributes.Expires;

        public DateTimeOffset? Created => _attributes.Created;

        public DateTimeOffset? Updated => _attributes.Updated;

        public string RecoveryLevel => _attributes.RecoveryLevel;

        private const string IdPropertyName = "id";
        private const string X509ThumprintPropertyName = "x5t";
        private const string TagsPropertyName = "tags";
        private const string AttributesPropertyName = "attributes";

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch(prop.Name)
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
                    foreach (var tagProp in prop.Value.EnumerateObject())
                    {
                        Tags[tagProp.Name] = tagProp.Value.GetString();
                    }
                    break;
                case AttributesPropertyName:
                    _attributes = new CertificateAttributes();
                    _attributes.ReadProperties(prop.Value);
                    break;
            }
        }

        private void ParseId(string id)
        {
            var idToParse = new Uri(id, UriKind.Absolute); ;

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
