// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.HybridData.Models
{
    /// <summary> The encryption algorithm used to encrypt data. </summary>
    public enum SupportedEncryptionAlgorithm
    {
        /// <summary> None. </summary>
        None,
#pragma warning disable CA1707
        /// <summary> RSA1_5. </summary>
        [CodeGenMember("RSA15")]
        Rsa1_5,
        /// <summary> RSA_OAEP. </summary>
        [CodeGenMember("RsaOaep")]
        Rsa_Oaep,
#pragma warning restore CA1707
        /// <summary> PlainText. </summary>
        PlainText
    }
}
