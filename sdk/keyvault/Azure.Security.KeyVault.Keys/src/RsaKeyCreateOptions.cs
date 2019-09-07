// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represents the attributes to assign to an RSA key at creation.
    /// </summary>
    public class RsaKeyCreateOptions : KeyCreateOptions
    {
        /// <summary>
        /// The name of the key to create.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Supported JsonWebKey key types (kty) based on the cryptographic algorithm used for the key.
        /// Possible values 'RSA', 'RSA-HSM.'
        /// </summary>
        public JsonWebKeyType KeyType { get; private set; }

        /// <summary>
        /// Key size in bits. For example: 2048, 3072, or 4096.
        /// </summary>
        public int? KeySize { get; set; }

        /// <summary>
        /// Determines whether or not a hardware key (HSM) is used for creation.
        /// </summary>
        ///
        /// <value><c>true</c> to use a hardware key; <c>false</c> to use a software key</value>
        public bool Hsm { get; private set; }

        /// <summary>
        /// Initializes a new instance of the RsaKeyCreateOptions class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="hsm">Whether to import as a hardware key (HSM) or software key.</param>
        /// <param name="keySize">Key size in bits.</param>
        public RsaKeyCreateOptions(string name, bool hsm, int? keySize = null)
        {
            Name = name;
            Hsm = hsm;
            if(hsm)
            {
                KeyType = JsonWebKeyType.RsaHsm;
            }
            else
            {
                KeyType = JsonWebKeyType.Rsa;
            }

            if(keySize.HasValue)
            {
                KeySize = keySize.Value;
            }
        }
    }
}
