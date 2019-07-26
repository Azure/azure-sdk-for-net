// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Base
{
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class AlgorithmInfo
    {
        #region const
        /// <summary>
        /// 
        /// </summary>
        public const int Aes128CbcHmacSha256 = 100;

        /// <summary>
        /// 
        /// </summary>
        public const int Ecdsa = 200;

        /// <summary>
        /// 
        /// </summary>
        public const int Rsa15 = 300;

        #endregion

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected int AlgorithmId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected string AlgorithmName { get; set; }

        #region private properties
        /// <summary>
        /// 
        /// </summary>
        Dictionary<int, string> AlgorithmMap { get; set; }

        #endregion

        #endregion


        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected AlgorithmInfo()
        {
            AlgorithmMap = new Dictionary<int, string>()
            {
                { Aes128CbcHmacSha256, "Aes128CbcHmacSha256" },
                { Ecdsa, "Ecdsa" }
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmId"></param>
        protected AlgorithmInfo(int algorithmId) : this()
        {
            if(IsAlgorithmSupported(algorithmId))
            {
                AlgorithmId = algorithmId;
                AlgorithmName = AlgorithmMap[algorithmId];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        protected AlgorithmInfo(string algorithmName)
        {
            Check.NotNull(algorithmName, nameof(algorithmName));

            if(IsAlgorithmSupported(algorithmName))
            {

            }

        }
        #endregion

        #region Public Functions

        #endregion

        #region private functions
        bool IsAlgorithmSupported(int algorithmId)
        {
            return AlgorithmMap.ContainsKey(algorithmId);
        }

        bool IsAlgorithmSupported(string algorithmName)
        {
            return AlgorithmMap.ContainsValue(algorithmName);
        }
        #endregion

    }
}
