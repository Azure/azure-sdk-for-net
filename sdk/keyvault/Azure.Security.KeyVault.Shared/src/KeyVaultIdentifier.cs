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

        public static KeyVaultIdentifier Parse(string collection, Uri id)
        {
            KeyVaultIdentifier identifier = Parse(id);

            if (!string.Equals(identifier.Collection, collection + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}/', found '{2}'", id, collection, identifier.Collection));

            return identifier;
        }

        public static KeyVaultIdentifier Parse(Uri id)
        {
            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (id.Segments.Length != 3 && id.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, id.Segments.Length));

            KeyVaultIdentifier identifier = new KeyVaultIdentifier
            {

                Id = id,
                VaultUri = new Uri($"{id.Scheme}://{id.Authority}"),
                Collection = id.Segments[1].Trim('/'),
                Name = id.Segments[2].Trim('/'),
                Version = (id.Segments.Length == 4) ? id.Segments[3].TrimEnd('/') : null
            };

            return identifier;
        }
    }
}
