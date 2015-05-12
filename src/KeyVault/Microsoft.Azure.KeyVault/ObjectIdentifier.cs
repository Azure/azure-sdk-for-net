//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Globalization;

namespace Microsoft.Azure.KeyVault
{
    public class ObjectIdentifier
    {
        protected static bool IsObjectIdentifier(string collection, string identifier)
        {
            if (string.IsNullOrEmpty(collection))
                throw new ArgumentNullException("collection");

            if (string.IsNullOrEmpty(identifier))
                return false;

            try
            {
                Uri baseUri = new Uri(identifier, UriKind.Absolute);

                // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
                if (baseUri.Segments.Length != 3 && baseUri.Segments.Length != 4)
                    return false;

                if (!string.Equals(baseUri.Segments[1], collection + "/"))
                    return false;

                return true;
            }
            catch (UriFormatException)
            {
            }

            return false;
        }

        private readonly string _vault;
        private readonly string _vaultWithoutScheme;
        private readonly string _name;
        private readonly string _version;

        private readonly string _baseIdentifier;
        private readonly string _identifier;

        protected ObjectIdentifier(string vault, string collection, string name, string version = null)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(collection))
                throw new ArgumentNullException("collection");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("keyName");

            var baseUri = new Uri(vault, UriKind.Absolute);

            _name = name;
            _version = version;
            _vault = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", baseUri.Scheme, baseUri.FullAuthority());
            _vaultWithoutScheme = baseUri.Authority;
            _baseIdentifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, collection, _name);
            _identifier = string.IsNullOrEmpty(_version) ? _name : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _name, _version);
            _identifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, collection, _identifier);
        }

        protected ObjectIdentifier(string collection, string identifier)
        {
            if (string.IsNullOrEmpty(collection))
                throw new ArgumentNullException("collection");

            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException("identifier");

            Uri baseUri = new Uri(identifier, UriKind.Absolute);

            // We expect and identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (baseUri.Segments.Length != 3 && baseUri.Segments.Length != 4)
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", identifier, baseUri.Segments.Length));

            if (!string.Equals(baseUri.Segments[1], collection + "/"))
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}/', found '{2}'", identifier, collection, baseUri.Segments[1]));

            _name = baseUri.Segments[2].Substring(0, baseUri.Segments[2].Length).TrimEnd('/');

            if (baseUri.Segments.Length == 4)
                _version = baseUri.Segments[3].Substring(0, baseUri.Segments[3].Length).TrimEnd('/');

            _vault = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", baseUri.Scheme, baseUri.FullAuthority());
            _vaultWithoutScheme = baseUri.Authority;
            _baseIdentifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, collection, _name);
            _identifier = string.IsNullOrEmpty(_version) ? _name : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _name, _version);
            _identifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, collection, _identifier);
        }

        /// <summary>
        /// The base identifier for an object, does not include the object version.
        /// </summary>
        public string BaseIdentifier
        {
            get { return _baseIdentifier; }
        }

        /// <summary>
        /// The identifier for an object, includes the objects version.
        /// </summary>
        public string Identifier
        {
            get { return _identifier; }
        }

        /// <summary>
        /// The name of the object.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// The vault containing the object
        /// </summary>
        public string Vault
        {
            get { return _vault; }
        }

        public string VaultWithoutScheme
        {
            get { return _vaultWithoutScheme; }
        }

        /// <summary>
        /// The version of the object.
        /// </summary>
        public string Version
        {
            get { return _version; }
        }

        public override string ToString()
        {
            return _identifier;
        }
    }

    public sealed class KeyIdentifier : ObjectIdentifier
    {
        public static bool IsKeyIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("keys", identifier);
        }

        public KeyIdentifier(string vault, string name, string version = null)
            : base(vault, "keys", name, version)
        {
        }

        public KeyIdentifier(string identifier)
            : base("keys", identifier)
        {
        }
    }

    public sealed class SecretIdentifier : ObjectIdentifier
    {
        public static bool IsSecretIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("secrets", identifier);
        }

        public SecretIdentifier(string vault, string name, string version = null)
            : base(vault, "secrets", name, version)
        {
        }

        public SecretIdentifier(string identifier)
            : base("secrets", identifier)
        {
        }
    }
}