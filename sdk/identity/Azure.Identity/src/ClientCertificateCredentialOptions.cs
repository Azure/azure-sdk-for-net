﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ClientCertificateCredential"/>.
    /// </summary>
    public class ClientCertificateCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {

        /// <summary>
        /// If set to true the credential will store tokens in a cache persisted to the machine, protected to the current user, which can be shared by other credentials and processes.
        /// </summary>
        public bool EnablePersistentCache { get; set; }

        /// <summary>
        /// If set to true the credential will fall back to storing tokens in an unencrypted file if no OS level user encryption is available.
        /// </summary>
        public bool AllowUnencryptedCache { get; set; }

        /// <summary>
        /// Will include x5c header to enable subject name / issuer based authentication for the <see cref="ClientCertificateCredential"/>.
        /// </summary>
        public bool IncludeX5CClaimHeader { get; set; }
    }
}
