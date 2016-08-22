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
using System.Linq;

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
            catch (Exception)
            {
            }

            return false;
        }

        protected string _vault;
        protected string _vaultWithoutScheme;
        protected string _name;
        protected string _version;

        protected string _baseIdentifier;
        protected string _identifier;

        protected ObjectIdentifier()
        {
        }

        protected ObjectIdentifier(string vaultBaseUrl, string collection, string name, string version = "")
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException("vaultBaseUrl");

            if (string.IsNullOrEmpty(collection))
                throw new ArgumentNullException("collection");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("keyName");

            var baseUri = new Uri(vaultBaseUrl, UriKind.Absolute);

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

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (baseUri.Segments.Length != 3 && baseUri.Segments.Length != 4)
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", identifier, baseUri.Segments.Length));

            if (!string.Equals(baseUri.Segments[1], collection + "/"))
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}/', found '{2}'", identifier, collection, baseUri.Segments[1]));

            _name = baseUri.Segments[2].Substring(0, baseUri.Segments[2].Length).TrimEnd('/');

            if (baseUri.Segments.Length == 4)
                _version = baseUri.Segments[3].Substring(0, baseUri.Segments[3].Length).TrimEnd('/');
            else _version = string.Empty;

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

        public KeyIdentifier(string vaultBaseUrl, string name, string version = "")
            : base(vaultBaseUrl, "keys", name, version)
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

        public SecretIdentifier(string vaultBaseUrl, string name, string version = "")
            : base(vaultBaseUrl, "secrets", name, version)
        {
        }

        public SecretIdentifier(string identifier)
            : base("secrets", identifier)
        {
        }
    }

    public sealed class CertificateIdentifier : ObjectIdentifier
    {
        public static bool IsCertificateIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("certificates", identifier);
        }

        public CertificateIdentifier(string vaultBaseUrl, string name, string version = "")
            : base(vaultBaseUrl, "certificates", name, version)
        {
        }

        public CertificateIdentifier(string identifier)
            : base("certificates", identifier)
        {
        }
    }

    public sealed class CertificateOperationIdentifier : ObjectIdentifier
    {
        public static bool IsCertificateOperationIdentifier(string identifier)
        {
            var isValid = ObjectIdentifier.IsObjectIdentifier("certificates", identifier);

            Uri baseUri = new Uri(identifier, UriKind.Absolute);

            // 4 segments: host + "certificates" + name + "pending"
            if (baseUri.Segments.Length != 4)
                isValid = false;

            if (!string.Equals(baseUri.Segments[3], "pending"))
                isValid = false;

            return isValid;
        }

        public CertificateOperationIdentifier(string vaultBaseUrl, string name)
            : base(vaultBaseUrl, "certificates", name, "pending")
        {
            _baseIdentifier = _identifier;
            _version = string.Empty;
        }
        
        public CertificateOperationIdentifier(string identifier)
            : base("certificates", identifier)
        {
            _baseIdentifier = _identifier;
            _version = string.Empty;
        }
    }

    public sealed class IssuerIdentifier : ObjectIdentifier
    {
        public static bool IsIssuerIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                return false;

            Uri baseUri = new Uri(identifier, UriKind.Absolute);

            if (baseUri.Segments.Length != 4 || !string.Equals(baseUri.Segments[1], "certificates/") || !string.Equals(baseUri.Segments[2], "issuers/"))
                return false;

            return true;
        }

        public IssuerIdentifier(string vaultBaseUrl, string name)
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException("vaultBaseUrl");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            var baseUri = new Uri(vaultBaseUrl, UriKind.Absolute);

            _name = name;
            _version = string.Empty;
            _vault = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", baseUri.Scheme, baseUri.FullAuthority());
            _vaultWithoutScheme = baseUri.Authority;
            _baseIdentifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, "certificates/issuers", _name);
            _identifier = string.IsNullOrEmpty(_version) ? _name : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _name, _version);
            _identifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, "certificates/issuers", _identifier);
        }

        public IssuerIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException("identifier");

            Uri baseUri = new Uri(identifier, UriKind.Absolute);

            // We expect an identifier with 4 segments: host + "certificates" + "issuers" + name
            if (baseUri.Segments.Length != 4)
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", identifier, baseUri.Segments.Length));

            if (!string.Equals(baseUri.Segments[1], "certificates/"))
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}', found '{2}'", identifier, "certificates/", baseUri.Segments[1]));

            if (!string.Equals(baseUri.Segments[2], "issuers/"))
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}', found '{2}'", identifier, "issuers/", baseUri.Segments[1]));

            _name = baseUri.Segments[3].Substring(0, baseUri.Segments[3].Length).TrimEnd('/');
            _version = string.Empty;
            _vault = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", baseUri.Scheme, baseUri.FullAuthority());
            _vaultWithoutScheme = baseUri.Authority;
            _baseIdentifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, "certificates/issuers", _name);
            _identifier = string.IsNullOrEmpty(_version) ? _name : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _name, _version);
            _identifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", _vault, "certificates/issuers", _identifier);
        }
    }
}