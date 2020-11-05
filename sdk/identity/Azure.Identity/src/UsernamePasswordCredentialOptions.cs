// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="UsernamePasswordCredential"/>.
    /// </summary>
    internal class UsernamePasswordCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// If set to true the credential will store tokens in a persistent cache shared by other user credentials.
        /// </summary>
        public bool EnablePersistentCache { get; set; }

        /// <summary>
        /// If set to true the credential will fall back to storing tokens in an unencrypted file if no OS level user encryption is available.
        /// </summary>
        public bool AllowUnencryptedCache { get; set; }
    }
}
