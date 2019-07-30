// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography
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
        Dictionary<string, int> AlgorithmMap { get; set; }

        #endregion

        #endregion


        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected AlgorithmInfo()
        {
            //EqualityComparer<string> ec = new 
            AlgorithmMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { nameof(Aes128CbcHmacSha256),Aes128CbcHmacSha256 },
                { nameof(Ecdsa), Ecdsa }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        protected AlgorithmInfo(string algorithmName) : this()
        {
            Check.NotNull(algorithmName, nameof(algorithmName));

            //Nullable<KeyValuePair<string, 

            if (IsAlgorithmSupported(algorithmName))
            {
                AlgorithmName = algorithmName;
            }

        }

        #endregion

        #region Public Functions
        //public static T GetAlgorithmInfo<T>(AlgorithmType algorithmType) where T: Algorithm
        //{

        //}
        #endregion

        #region private functions
        bool IsAlgorithmSupported(string algorithmName)
        {
            return AlgorithmMap.ContainsKey(algorithmName);
        }

        bool IsAlgorithmSupported(int algorithmId)
        {
            return AlgorithmMap.ContainsValue(algorithmId);
        }

        Nullable<KeyValuePair<string, int>> GetAlgorithmMap(string algorithmName)
        {
            Check.NotNull(algorithmName, nameof(algorithmName));
            Nullable<KeyValuePair<string, int>> kv = AlgorithmMap.FirstOrDefault<KeyValuePair<string, int>>((item) => item.Key.Equals(algorithmName, StringComparison.OrdinalIgnoreCase));
            return kv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        KeyValuePair<string, int> GetAlgorithmMap()
        {
            //algorithmId = algorithmId + 1;
            return new KeyValuePair<string, int>("foo", 1);
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public enum AlgorithmType
        {
            /// <summary>
            /// 
            /// </summary>
            DES,

            /// <summary>
            /// 
            /// </summary>
            RSA
        }
    }

    //#region Symmteric
    ///// <summary>
    ///// 
    ///// </summary>
    //interface ISymmetricType
    //{
    //    int DES { get; private set; }
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    //public class AlgorithmType
    //{

    //}
    //#endregion
}
