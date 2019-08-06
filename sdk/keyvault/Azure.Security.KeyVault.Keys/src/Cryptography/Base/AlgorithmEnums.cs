using Azure.Security.KeyVault.Cryptography.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Cryptography.Base
{
    #region AlgorithmKind Enum
    /// <summary>
    /// 
    /// </summary>
    public enum EncryptionAlgorithmKind
    {
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        Aes128CbcHmacSha256,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        Aes192CbcHmacSha384,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        Aes256CbcHmacSha512,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        AesCbc,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        AesCbcHmacSha2,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        AesKw,

        /// <summary>g
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        AesKw128,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        AesKw192,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        AesKw256,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        Ecdsa,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        Es256,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "RSA-OAEP")]
        RsaOaep,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "RSA1_5")]
        Rsa15,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        Rsa256,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "RSA-OAEP-256",rfcInfo: @"https://tools.ietf.org/html/draft-ietf-jose-json-web-algorithms")]
        RsaOaep256,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        NotSupported
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class AlgorithmKindMetadataAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string AlgorithmNameOnWire { get; set; }

        public string RFCUrlInfo { get; set; }

        public AlgorithmKindMetadataAttribute(string algorithmNameOnTheWire, string rfcInfo = "")
        {
            if(string.IsNullOrWhiteSpace(algorithmNameOnTheWire))
            {
                AlgorithmNameOnWire = string.Empty;
            }
            else
            {
                AlgorithmNameOnWire = algorithmNameOnTheWire;
            }

            RFCUrlInfo = rfcInfo;
        }
    }

    #endregion

    #region CryptoOpertaionKind Enum

    internal enum CryptoOperationKind
    {
        [DescriptionAttribute("/encrypt")]
        Encrypt,
        [DescriptionAttribute("/decrypt")]
        Decrypt,
        [DescriptionAttribute("/wrapkey")]
        WrapKey,
        [DescriptionAttribute("/unwrapkey")]
        UnWrapKey,
        [DescriptionAttribute("/sign")]
        Sign,
        [DescriptionAttribute("/verify")]
        Verify
    }

    #endregion
}