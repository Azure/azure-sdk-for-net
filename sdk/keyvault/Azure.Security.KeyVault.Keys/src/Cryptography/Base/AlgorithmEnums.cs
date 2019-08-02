using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Cryptography.Base
{
    /// <summary>
    /// 
    /// </summary>
    public enum EncryptionAlgorithmKind
    {
        /// <summary>
        /// 
        /// </summary>
        Aes128CbcHmacSha256,

        /// <summary>
        /// 
        /// </summary>
        Aes192CbcHmacSha384,

        /// <summary>
        /// 
        /// </summary>
        Aes256CbcHmacSha512,

        /// <summary>
        /// 
        /// </summary>
        AesCbc,

        /// <summary>
        /// 
        /// </summary>
        AesCbcHmacSha2,

        /// <summary>
        /// 
        /// </summary>
        AesKw,

        /// <summary>
        /// 
        /// </summary>
        AesKw128,

        /// <summary>
        /// 
        /// </summary>
        AesKw192,

        /// <summary>
        /// 
        /// </summary>
        AesKw256,

        /// <summary>
        /// 
        /// </summary>
        Ecdsa,

        /// <summary>
        /// 
        /// </summary>
        Es256,
        /// <summary>
        /// 
        /// </summary>
        RsaOaep,

        /// <summary>
        /// 
        /// </summary>
        Rsa15,

        /// <summary>
        /// 
        /// </summary>
        Rsa256,

        /// <summary>
        /// 
        /// </summary>
        RsaOaep256,

        /// <summary>
        /// 
        /// </summary>
        NotSupported
    }
}
