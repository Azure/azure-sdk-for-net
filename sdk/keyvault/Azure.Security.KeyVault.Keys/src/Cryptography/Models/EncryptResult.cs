// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class EncryptResult
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Ciphertext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] AuthenticationTag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Algorithm { get; set; }
    }
}
