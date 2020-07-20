// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="UsernamePasswordCredential"/>.
    /// </summary>
    public class UsernamePasswordCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// If set to true the credential will store tokens in a persistent cache shared by other user credentials.
        /// </summary>
        public bool EnablePersistentCache { get; set; }
    }
}
