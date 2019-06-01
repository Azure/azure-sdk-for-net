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
        public KeyBase(string name)
        {
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

        private void ParseId(string id)
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

        internal override void WriteProperties(ref Utf8JsonWriter json) { }
        
        internal override void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("kid", out JsonElement kid))
            {
                ParseId(kid.GetString());
            }

            if (json.TryGetProperty("managed", out JsonElement managed))
            {
                Managed = managed.GetBoolean();
            }

            if (json.TryGetProperty("attributes", out JsonElement attributes))
            {
                _attributes.ReadProperties(attributes);
            }

            if (json.TryGetProperty("tags", out JsonElement tags))
            {
                Tags = new Dictionary<string, string>();

                foreach (var prop in tags.EnumerateObject())
                {
                    Tags[prop.Name] = prop.Value.GetString();
                }
            }
        }
    }
}
