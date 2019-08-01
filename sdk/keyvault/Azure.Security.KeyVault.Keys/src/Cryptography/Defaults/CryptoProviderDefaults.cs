// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Defaults
{
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.CryptoAlgorithms;
    using Azure.Security.KeyVault.Cryptography.Interface;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class CryptoProviderDefaults : IKeyVaultDefault
    {
        #region const
        const string CRYPTO_DEFAULT_NAME = "CryptoProviderDefaults";
        #endregion

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public virtual string DefaultCategoryName { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public EncryptionAlgorithmKindEnum EncryptionAlgorithm { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public EncryptionAlgorithmKindEnum KeyWrapAlgorithm { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public EncryptionAlgorithmKindEnum SignatureAlgorithm { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected CryptoProviderDefaults() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptionAlgorithm"></param>
        /// <param name="keyWrapAlgorithm"></param>
        /// <param name="signatureAlgorithm"></param>
        /// <param name="defaultCategoryName"></param>
        public CryptoProviderDefaults(EncryptionAlgorithmKindEnum encryptionAlgorithm, EncryptionAlgorithmKindEnum keyWrapAlgorithm, EncryptionAlgorithmKindEnum signatureAlgorithm, string defaultCategoryName) : this()
        {
            EncryptionAlgorithm = encryptionAlgorithm;
            KeyWrapAlgorithm = keyWrapAlgorithm;
            SignatureAlgorithm = signatureAlgorithm;

            if(string.IsNullOrWhiteSpace(defaultCategoryName))
            {
                DefaultCategoryName = CRYPTO_DEFAULT_NAME;
            }
            else
            {
                DefaultCategoryName = defaultCategoryName;
            }
        }
        #endregion

        #region Public Functions

        #endregion

        #region private functions

        #endregion

    }
}
