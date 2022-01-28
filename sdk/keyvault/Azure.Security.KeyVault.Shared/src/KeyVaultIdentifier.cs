// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Security.KeyVault
{
    internal struct KeyVaultIdentifier
    {
        public const string SecretsCollection = "secrets";
        public const string KeysCollection = "keys";
        public const string CertificatesCollection = "certificates";

        public Uri Id { get; private set; }

        public Uri VaultUri { get; set; }

        public string Name { get; set; }

        public string Collection { get; set; }

        public string Version { get; set; }

        public static KeyVaultIdentifier Parse(Uri id)
        {
            if (TryParse(id ?? throw new ArgumentNullException(nameof(id)), out KeyVaultIdentifier identifier))
            {
                return identifier;
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, id.Segments.Length));
        }

        public static KeyVaultIdentifier ParseWithCollection(Uri id, string collection)
        {
            KeyVaultIdentifier identifier = Parse(id);
            if (!string.Equals(identifier.Collection, collection, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}/', found '{2}'", id, collection, identifier.Collection));
            }

            return identifier;
        }

        public static bool TryParse(Uri id, out KeyVaultIdentifier identifier)
        {
            if (id is null)
            {
                identifier = default;
                return false;
            }

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            string[] segments = id.Segments;
            if (segments.Length != 3 && segments.Length != 4)
            {
                identifier = default;
                return false;
            }

            identifier = new KeyVaultIdentifier
            {
                Id = id,
                VaultUri = new Uri($"{id.Scheme}://{id.Authority}"),
                Collection = segments[1].Trim('/'),
                Name = segments[2].Trim('/'),
                Version = (segments.Length == 4) ? segments[3].TrimEnd('/') : null
            };

            return true;
        }
    }
}
