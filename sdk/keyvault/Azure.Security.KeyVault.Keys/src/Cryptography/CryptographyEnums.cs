using Azure.Security.KeyVault.Cryptography.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Cryptography
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
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "RSA-OAEP-256", rfcInfo: @"https://tools.ietf.org/html/draft-ietf-jose-json-web-algorithms")]
        RsaOaep256,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        NotSupported
    }

    /// <summary>
    /// 
    /// </summary>
    public enum KeyWrapAlogirthmKind
    {
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
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "RSA-OAEP-256", rfcInfo: @"https://tools.ietf.org/html/draft-ietf-jose-json-web-algorithms")]
        RsaOaep256,

        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        NotSupported
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SignatureAlgorithmKind
    {
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        RS256,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        RS384,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        RS512,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        PS256,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        PS384,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        PS512,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        ES256,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        ES384,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        ES512,
        /// <summary>
        /// 
        /// </summary>
        [AlgorithmKindMetadata(algorithmNameOnTheWire: "")]
        ES256K,

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
        [Description("/encrypt")]
        Encrypt,
        [Description("/decrypt")]
        Decrypt,
        [Description("/wrapkey")]
        WrapKey,
        [Description("/unwrapkey")]
        UnWrapKey,
        [Description("/sign")]
        Sign,
        [Description("/verify")]
        Verify
    }

    #endregion
}