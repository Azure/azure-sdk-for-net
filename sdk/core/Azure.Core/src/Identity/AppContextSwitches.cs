// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// First-party-only feature switches resolved from <see cref="System.AppContext"/> with an environment
    /// variable fallback. These are intentionally not exposed on the public API surface.
    /// </summary>
    internal static class AppContextSwitches
    {
        /// <summary>
        /// The <see cref="System.AppContext"/> switch name that enables mTLS proof-of-possession token
        /// acquisition for <see cref="ClientCertificateCredential"/>.
        /// </summary>
        internal const string EnableClientCertificateMtlsProofOfPossessionSwitchName = "Azure.Identity.EnableClientCertificateMtlsProofOfPossession";

        /// <summary>
        /// The environment variable that enables mTLS proof-of-possession token acquisition for
        /// <see cref="ClientCertificateCredential"/>.
        /// </summary>
        internal const string EnableClientCertificateMtlsProofOfPossessionEnvVar = "AZURE_IDENTITY_ENABLE_CLIENT_CERTIFICATE_MTLS_POP";

        /// <summary>
        /// When <c>true</c> (the default), <see cref="ClientCertificateCredential"/> can request an mTLS
        /// proof-of-possession token when proof-of-possession was requested by the caller. Set the switch or
        /// environment variable to <c>false</c> to force bearer tokens. Intended for first-party callers only.
        /// The <see cref="System.AppContext"/> switch takes priority over the environment variable.
        /// </summary>
        public static bool EnableClientCertificateMtlsProofOfPossession
            => AppContextSwitchHelper.GetConfigValue(
                EnableClientCertificateMtlsProofOfPossessionSwitchName,
                EnableClientCertificateMtlsProofOfPossessionEnvVar,
                defaultValue: true);
    }
}
