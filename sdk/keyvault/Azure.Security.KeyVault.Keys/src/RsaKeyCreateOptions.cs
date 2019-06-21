// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represent the key specific attributes needed in order to create a RSA key.
    /// </summary>
    public class RsaKeyCreateOptions : KeyCreateOptions
    {
        /// <summary>
        /// Name of the key.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of key to create.
        /// </summary>
        public KeyType KeyType { get; private set; }

        /// <summary>
        /// Key size in bits. For example: 2048, 3072, or 4096.
        /// </summary>
        public int? KeySize { get; set; }

        /// <summary>
        /// Whether it is a hardware key (HSM) or software key.
        /// </summary>
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
            
            if(hsm)
            {
                KeyType = KeyType.RsaHsm;
            }
            else
            {
                KeyType = KeyType.Rsa;
            }

            if(keySize.HasValue)
            {
                KeySize = keySize.Value;
            }
        }
    }
}
