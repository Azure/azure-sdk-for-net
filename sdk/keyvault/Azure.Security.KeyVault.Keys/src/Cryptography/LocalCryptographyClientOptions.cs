// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options that allow you to configure the <see cref="CryptographyClient"/> for local-only operations.
    /// </summary>
    /// <remarks>
    /// Properties to configure remote features such as <see cref="ClientOptions.Retry"/> and <see cref="ClientOptions.Transport"/> are ignored.
    /// When <see cref="CryptographyClient"/> is created with an instance of <see cref="LocalCryptographyClientOptions"/> it can only perform operations locally.
    /// </remarks>
    [SuppressMessage("Usage", "AZC0008:ClientOptions should have a nested enum called ServiceVersion", Justification = "Will not make remote calls by design")]
    public class LocalCryptographyClientOptions : ClientOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCryptographyClientOptions"/> class.
        /// </summary>
        public LocalCryptographyClientOptions()
        {
        }
    }
}
