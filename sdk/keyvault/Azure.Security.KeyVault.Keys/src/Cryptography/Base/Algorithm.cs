// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography
{
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.CryptoAlgorithms;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for all Algorithms used in the Key Vault .NET SDK
    /// </summary>
    public abstract class Algorithm
    {
        #region const
        #endregion

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string AlgorithmName { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected Algorithm() { }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class EncryptionAlgorithm : Algorithm
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public EncryptionAlgorithmKindEnum AlgorithmType { get; }

        /// <summary>
        /// 
        /// </summary>
        //public string AlgorithmName { get; private set; }

        #region private properties
        protected virtual AlgorithmResolver AlgorithmResolver { get; set; }

        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected EncryptionAlgorithm() : base()
        {
            //AlgorithmResolver = new AlgorithmResolver();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmType"></param>
        public EncryptionAlgorithm(EncryptionAlgorithmKindEnum algorithmType) : this()
        {
            AlgorithmType = algorithmType;
            AlgorithmName = AlgorithmResolver.ResolveAlgorithmName(algorithmType.ToString());
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class AsymmetricEncryptionAlgorithm : EncryptionAlgorithm
    {
        #region const

        #endregion

        #region fields
        AlgorithmResolver _algoResolver;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected override AlgorithmResolver AlgorithmResolver
        {
            get
            {
                if(_algoResolver == null)
                {
                    _algoResolver = new AsymmetricAlgorithmResolver();
                }

                return _algoResolver;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmType"></param>
        public AsymmetricEncryptionAlgorithm(EncryptionAlgorithmKindEnum algorithmType) : base(algorithmType)
        {
            //AlgoResolver.AlgorithmCategory = AlgorithmCategoryEnum.Asymmetric;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Create an encryptor for the specified key
        /// </summary>
        /// <param name="key">The key used to create the encryptor</param>
        /// <returns>An ICryptoTransform for encrypting data</returns>
        public abstract ICryptoTransform CreateEncryptor(AsymmetricAlgorithm key);

        /// <summary>
        /// Create a decryptor for the specified key
        /// </summary>
        /// <param name="key">The key used to create decryptor</param>
        /// <returns>An ICryptoTransform for encrypting data</returns>
        public abstract ICryptoTransform CreateDecryptor(AsymmetricAlgorithm key);
        #endregion

        #region private functions

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class SymmetricEncryptionAlgorithm : EncryptionAlgorithm
    {

        #region const

        #endregion

        #region fields
        AlgorithmResolver _algoResolver;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected override AlgorithmResolver AlgorithmResolver
        {
            get
            {
                if (_algoResolver == null)
                {
                    _algoResolver = new SymmetricAlgorithmResolver();
                }

                return _algoResolver;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmType"></param>
        public SymmetricEncryptionAlgorithm(EncryptionAlgorithmKindEnum algorithmType) : base(algorithmType)
        {
            //AlgoResolver.AlgorithmCategory = AlgorithmCategoryEnum.Symmetric;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Create an encryptor for the specified key
        /// </summary>
        /// <param name="key">The key material to be used</param>
        /// <param name="iv">The initialization vector to be used</param>
        /// <param name="authenticationData">The authentication data to be used with authenticating encryption algorithms (ignored for non-authenticating algorithms)</param>
        /// <returns>An ICryptoTranform for encrypting data</returns>
        public abstract ICryptoTransform CreateEncryptor(byte[] key, byte[] iv, byte[] authenticationData);

        /// <summary>
        /// Create a decryptor for the specified key
        /// </summary>
        /// <param name="key">The key material to be used</param>
        /// <param name="iv">The initialization vector to be used</param>
        /// <param name="authenticationData">The authentication data to be used with authenticating encryption algorithms (ignored for non-authenticating algorithms)</param>
        /// <param name="authenticationTag">The authentication tag to verify when using authenticating encryption algorithms (ignored for non-authenticating algorithms)</param>
        /// <returns>An ICryptoTransform for decrypting data</returns>
        public abstract ICryptoTransform CreateDecryptor(byte[] key, byte[] iv, byte[] authenticationData, byte[] authenticationTag);
        #endregion

        #region private functions

        #endregion
    }
}
