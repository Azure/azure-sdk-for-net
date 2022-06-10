// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Cryptography.Models
{
    /// <summary>
    /// Transformation mode for a given <see cref="IAuthenticatedCryptographicTransform"/>.
    /// </summary>
    internal enum TransformMode
    {
        /// <summary>
        /// Encryption mode.
        /// </summary>
        Encrypt,

        /// <summary>
        /// Decryption mode.
        /// </summary>
        Decrypt,
    }
}
