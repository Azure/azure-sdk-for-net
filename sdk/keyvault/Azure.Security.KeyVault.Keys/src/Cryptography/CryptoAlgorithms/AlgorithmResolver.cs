// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.CryptoAlgorithms
{
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class AlgorithmResolver
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, string> SupportedAlgorithmMap { get; }

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, string> NotSupportedAlgorithmMap { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public AlgorithmResolver()
        {
            SupportedAlgorithmMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            NotSupportedAlgorithmMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            string[] definedAlgoNames = Enum.GetNames(typeof(EncryptionAlgorithmKind));
            foreach(string algoName in definedAlgoNames)
            {
                if(!SupportedAlgorithmMap.ContainsKey(algoName))
                {
                    SupportedAlgorithmMap.Add(algoName, algoName);
                }
            }
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public virtual string ResolveAlgorithmName(string algorithmName)
        {
            string validAlgorithmName = string.Empty;
            if(IsAlgorithmSupported(algorithmName))
            {
                validAlgorithmName = SupportedAlgorithmMap[algorithmName];
            }

            return validAlgorithmName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public virtual bool IsAlgorithmSupported(string algorithmName)
        {
            return SupportedAlgorithmMap.ContainsKey(algorithmName);
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    internal class AsymmetricAlgorithmResolver : AlgorithmResolver
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public AsymmetricAlgorithmResolver() : base() { }
        #endregion

        #region Public Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public override string ResolveAlgorithmName(string algorithmName)
        {
            return base.ResolveAlgorithmName(algorithmName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public override bool IsAlgorithmSupported(string algorithmName)
        {
            return IsAsymmetricAlgorithm(algorithmName);
        }

        #endregion

        #region private functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        private bool IsAsymmetricAlgorithm(string algorithmName)
        {
            return SupportedAlgorithmMap.ContainsKey(algorithmName);
        }

        private bool IsAsymmetricAlgorithm(EncryptionAlgorithmKind algoKind)
        {
            return SupportedAlgorithmMap.ContainsKey(ResolveAlgorithmName(algoKind.ToString()));
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    internal class SymmetricAlgorithmResolver : AlgorithmResolver
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        #endregion

        #region Public Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public override string ResolveAlgorithmName(string algorithmName)
        {
            return base.ResolveAlgorithmName(algorithmName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public override bool IsAlgorithmSupported(string algorithmName)
        {
            return IsSymmetricAlgorithm(algorithmName);
        }
        #endregion

        #region private functions
        bool IsSymmetricAlgorithm(string algorithmName)
        {
            return SupportedAlgorithmMap.ContainsKey(algorithmName);
        }

        bool IsSymmetricAlgorithm(EncryptionAlgorithmKind algoKind)
        {
            return SupportedAlgorithmMap.ContainsKey(ResolveAlgorithmName(algoKind.ToString()));
        }

        #endregion
    }
}
