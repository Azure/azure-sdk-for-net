// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Security.KeyVault.Secrets
{
    internal struct ObjectId
    {
        public Uri Id { get; set; }

        public Uri VaultUri { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public void ParseId(string collection, string id) => ParseId(collection, new Uri(id, UriKind.Absolute));

        public void ParseId(string collection, Uri id)
        {
            Id = id;

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (Id.Segments.Length != 3 && Id.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, Id.Segments.Length));

            if (!string.Equals(Id.Segments[1], collection + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}/', found '{2}'", id, collection, Id.Segments[1]));

            VaultUri = new Uri($"{Id.Scheme}://{Id.Authority}");
            Name = Id.Segments[2].Trim('/');
            Version = (Id.Segments.Length == 4) ? Id.Segments[3].TrimEnd('/') : null;
        }
    }
}
