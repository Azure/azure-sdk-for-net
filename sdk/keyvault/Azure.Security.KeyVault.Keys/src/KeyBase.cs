// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyBase
    {
        private KeyAttributes _attributes;
        
        public string Name { get; private set; }
        public Uri VaultId { get; private set; }
        public Uri VaultUri { get; private set; }
        public string Version { get; private set; }
        public bool Managed { get; private set; }
        public IDictionary<string, string> Tags { get; set; }

        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        public DateTime? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        public DateTime? Expires { get => _attributes.Expires; set => _attributes.Expires = value; }

        public DateTime? Created => _attributes.Created;

        public DateTime? Updated => _attributes.Updated;

        public string RecoveryLevel => _attributes.RecoveryLevel;

        public KeyBase(string name)
        {
            Name = name;
        }

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
    }
}
