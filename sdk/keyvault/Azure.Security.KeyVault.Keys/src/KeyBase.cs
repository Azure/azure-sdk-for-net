// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyBase : Model
    {
        internal KeyBase() { }
        public KeyBase(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));
            Name = name;
        }

        private KeyAttributes _attributes;
        
        public string Name { get; private set; }
        public Uri VaultId { get; private set; }
        public Uri VaultUri { get; private set; }
        public string Version { get; private set; }
        public bool Managed { get; private set; }
        public IDictionary<string, string> Tags { get; set; }

        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        public DateTimeOffset? Expires { get => _attributes.Expires; set => _attributes.Expires = value; }

        public DateTimeOffset? Created => _attributes.Created;

        public DateTimeOffset? Updated => _attributes.Updated;

        public string RecoveryLevel => _attributes.RecoveryLevel;

        private const string KeyIdPropertyName = "kid";
        private const string ManagedPropertyName = "managed";
        private const string AttributesPropertyName = "attributes";
        private const string TagsPropertyName = "tags";

        protected void ParseId(string id)
        {
            var idToParse = new Uri(id, UriKind.Absolute); ;

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "keys" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'keys/', found '{1}'", id, idToParse.Segments[1]));

            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
            Version = (idToParse.Segments.Length == 4) ? idToParse.Segments[3].TrimEnd('/') : null;
        }

        internal override void WriteProperties(Utf8JsonWriter json) { }
        
        internal override void ReadProperties(JsonElement json)
        {
            foreach(JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        ParseId(prop.Value.GetString());
                        break;
                    case ManagedPropertyName:
                        Managed = prop.Value.GetBoolean();
                        break;
                    case AttributesPropertyName:
                        _attributes.ReadProperties(prop.Value);
                        break;
                    case TagsPropertyName:
                        Tags = new Dictionary<string, string>();
                        foreach (var tagProp in prop.Value.EnumerateObject())
                        {
                            Tags[tagProp.Name] = tagProp.Value.GetString();
                        }
                        break;
                }
            }
        }
    }
}
