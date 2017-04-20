﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// The Key Vault object identifier.
    /// </summary>
    public class ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault object.
        /// </summary>
        /// <param name="collection">The object collection e.g. 'keys', 'secrets' and 'certificates'.</param>
        /// <param name="identifier">The key vault object identifier.</param>
        /// <returns>True if the identifier belongs to a key vault object. False otherwise.</returns>
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

                if (!string.Equals(baseUri.Segments[1], collection + "/", StringComparison.OrdinalIgnoreCase))
                    return false;

                return true;
            }
            catch (Exception)
            {
            }

            return false;
        }

        private string _vault;
        private string _vaultWithoutScheme;
        private string _name;
        private string _version;

        private string _baseIdentifier;
        private string _identifier;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ObjectIdentifier()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> The vault base URL</param>
        /// <param name="collection">The object collection e.g. 'keys', 'secrets' and 'certificates'.</param>
        /// <param name="name">The object name.</param>
        /// <param name="version"> the version of the object.</param>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="collection">The object collection e.g. 'keys', 'secrets' and 'certificates'.</param>
        /// <param name="identifier">The key vault object identifier.</param>
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

            if (!string.Equals(baseUri.Segments[1], collection + "/", StringComparison.OrdinalIgnoreCase))
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
            protected set { _baseIdentifier = value; }
        }

        /// <summary>
        /// The identifier for an object, includes the objects version.
        /// </summary>
        public string Identifier
        {
            get { return _identifier; }
            protected set { _identifier = value; }
        }

        /// <summary>
        /// The name of the object.
        /// </summary>
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        /// <summary>
        /// The vault containing the object
        /// </summary>
        public string Vault
        {
            get { return _vault; }
            protected set { _vault = value; }
        }

        /// <summary>
        /// The scheme-less vault URL
        /// </summary>
        public string VaultWithoutScheme
        {
            get { return _vaultWithoutScheme; }
            protected set { _vaultWithoutScheme = value; }
        }

        /// <summary>
        /// The version of the object.
        /// </summary>
        public string Version
        {
            get { return _version; }
            protected set { _version = value; }
        }

        public override string ToString()
        {
            return _identifier;
        }
    }

    /// <summary>
    /// The Key Vault key identifier.
    /// </summary>
    public sealed class KeyIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault key.
        /// </summary>
        /// <param name="identifier">The key vault key identifier.</param>
        /// <returns>True if the identifier belongs to a key vault key. False otherwise.</returns>
        public static bool IsKeyIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("keys", identifier);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> The vault base URL</param>
        /// <param name="name"> the name of the key. </param>
        /// <param name="version"> the version of the key.</param>
        public KeyIdentifier(string vaultBaseUrl, string name, string version = "")
            : base(vaultBaseUrl, "keys", name, version)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for key object</param>
        public KeyIdentifier(string identifier)
            : base("keys", identifier)
        {
        }
    }

    /// <summary>
    /// The Key Vault secret identifier.
    /// </summary>
    public sealed class SecretIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault secret.
        /// </summary>
        /// <param name="identifier">The key vault secret identifier.</param>
        /// <returns>True if the identifier belongs to a key vault secret. False otherwise.</returns>
        public static bool IsSecretIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("secrets", identifier);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> the vault base URL</param>
        /// <param name="name">the name of the secret </param>
        /// <param name="version">the version of the secret.</param>
        public SecretIdentifier(string vaultBaseUrl, string name, string version = "")
            : base(vaultBaseUrl, "secrets", name, version)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for secret.</param>
        public SecretIdentifier(string identifier)
            : base("secrets", identifier)
        {
        }
    }

    /// <summary>
    /// The Key Vault deleted key identifier. Aka the recoveryId.
    /// </summary>
    public sealed class DeletedKeyIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault deleted key.
        /// </summary>
        /// <param name="identifier">The key vault deleted key identifier.</param>
        /// <returns>True if the identifier belongs to a key vault deleted key. False otherwise.</returns>
        public static bool IsDeletedKeyIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("deletedkeys", identifier);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> the vault base URL</param>
        /// <param name="name">the name of the deleted key </param>
        public DeletedKeyIdentifier(string vaultBaseUrl, string name)
            : base(vaultBaseUrl, "deletedkeys", name, string.Empty)
        {
            Identifier = BaseIdentifier; // Deleted entities are unversioned.
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for the deleted key. Aka the recoveryId return from deletion.</param>
        public DeletedKeyIdentifier(string identifier)
            : base("deletedkeys", identifier)
        {
            Version = string.Empty;
            Identifier = BaseIdentifier; // Deleted entities are unversioned.
        }
    }

    /// <summary>
    /// The Key Vault deleted secret identifier. Aka the recoveryId.
    /// </summary>
    public sealed class DeletedSecretIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault deleted secret.
        /// </summary>
        /// <param name="identifier">The key vault secret identifier.</param>
        /// <returns>True if the identifier belongs to a key vault deleted secret. False otherwise.</returns>
        public static bool IsDeletedSecretIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("deletedsecrets", identifier);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> the vault base URL</param>
        /// <param name="name">the name of the deleted secret </param>
        public DeletedSecretIdentifier(string vaultBaseUrl, string name)
            : base(vaultBaseUrl, "deletedsecrets", name, string.Empty)
        {
            Identifier = BaseIdentifier; // Deleted entities are unversioned.
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for the deleted secret. Aka the recoveryId return from deletion.</param>
        public DeletedSecretIdentifier(string identifier)
            : base("deletedsecrets", identifier)
        {
            Version = string.Empty;
            Identifier = BaseIdentifier; // Deleted entities are unversioned.
        }
    }

    /// <summary>
    /// The Key Vault certificate identifier.
    /// </summary>
    public sealed class CertificateIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault certificate.
        /// </summary>
        /// <param name="identifier">The key vault certificate identifier.</param>
        /// <returns>True if the identifier belongs to a key vault certificate. False otherwise.</returns>
        public static bool IsCertificateIdentifier(string identifier)
        {
            return ObjectIdentifier.IsObjectIdentifier("certificates", identifier);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> the vault base URL</param>
        /// <param name="name">the name of the certificate.</param>
        /// <param name="version">the version of the certificate.</param>
        public CertificateIdentifier(string vaultBaseUrl, string name, string version = "")
            : base(vaultBaseUrl, "certificates", name, version)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for certificate.</param>
        public CertificateIdentifier(string identifier)
            : base("certificates", identifier)
        {
        }
    }

    /// <summary>
    /// The Key Vault deleted certificate identifier. Aka the recoveryId.
    /// </summary>
    public sealed class DeletedCertificateIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier is a valid KeyVault deleted certificate identifier.
        /// </summary>
        /// <param name="identifier">The key vault certificate identifier.</param>
        /// <returns>True if the identifier is a valid KeyVault deleted certificate. False otherwise.</returns>
        public static bool IsDeletedCertificateIdentifier( string identifier )
        {
            return ObjectIdentifier.IsObjectIdentifier( "deletedcertificates", identifier );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> the vault base URL</param>
        /// <param name="name">the name of the deleted certificate</param>
        public DeletedCertificateIdentifier( string vaultBaseUrl, string name )
            : base( vaultBaseUrl, "deletedcertificates", name, string.Empty )
        {
            Identifier = BaseIdentifier; // Deleted entities are unversioned.
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for the deleted certificate. Aka the recoveryId return from deletion.</param>
        public DeletedCertificateIdentifier( string identifier )
            : base( "deletedcertificates", identifier )
        {
            Version = string.Empty;
            Identifier = BaseIdentifier; // Deleted entities are unversioned.
        }
    }


    /// <summary>
    /// The Key Vault certificate operation identifier.
    /// </summary>
    public sealed class CertificateOperationIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault certificate operation.
        /// </summary>
        /// <param name="identifier">The key vault certificate operation identifier.</param>
        /// <returns>True if the identifier belongs to a key vault certificate operation. False otherwise.</returns>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl"> the vault base url. </param>
        /// <param name="name">the name of the certificate.</param>
        public CertificateOperationIdentifier(string vaultBaseUrl, string name)
            : base(vaultBaseUrl, "certificates", name, "pending")
        {
            BaseIdentifier = Identifier;
            Version = string.Empty;
        }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The identifier for certificate operation identifier. </param>
        public CertificateOperationIdentifier(string identifier)
            : base("certificates", identifier)
        {
            BaseIdentifier = Identifier;
            Version = string.Empty;
        }
    }

    /// <summary>
    /// The Key Vault issuer identifier.
    /// </summary>
    public sealed class CertificateIssuerIdentifier : ObjectIdentifier
    {
        /// <summary>
        /// Verifies whether the identifier belongs to a key vault issuer.
        /// </summary>
        /// <param name="identifier">The key vault issuer identifier.</param>
        /// <returns>True if the identifier belongs to a key vault issuer. False otherwise.</returns>
        public static bool IsIssuerIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                return false;

            Uri baseUri = new Uri(identifier, UriKind.Absolute);

            if (baseUri.Segments.Length != 4 || !string.Equals(baseUri.Segments[1], "certificates/") || !string.Equals(baseUri.Segments[2], "issuers/"))
                return false;

            return true;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultBaseUrl">The vault base URL.</param>
        /// <param name="name">The name of the issuer.</param>
        public CertificateIssuerIdentifier(string vaultBaseUrl, string name)
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException("vaultBaseUrl");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            var baseUri = new Uri(vaultBaseUrl, UriKind.Absolute);

            Name = name;
            Version = string.Empty;
            Vault = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", baseUri.Scheme, baseUri.FullAuthority());
            VaultWithoutScheme = baseUri.Authority;
            BaseIdentifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", Vault, "certificates/issuers", Name);
            Identifier = string.IsNullOrEmpty(Version) ? Name : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Name, Version);
            Identifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", Vault, "certificates/issuers", Identifier);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identifier">The key vault issuer identifier.</param>
        public CertificateIssuerIdentifier(string identifier)
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

            Name = baseUri.Segments[3].Substring(0, baseUri.Segments[3].Length).TrimEnd('/');
            Version = string.Empty;
            Vault = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", baseUri.Scheme, baseUri.FullAuthority());
            VaultWithoutScheme = baseUri.Authority;
            BaseIdentifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", Vault, "certificates/issuers", Name);
            Identifier = string.IsNullOrEmpty(Version) ? Name : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Name, Version);
            Identifier = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}", Vault, "certificates/issuers", Identifier);
        }
    }
}