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
        /// The <see cref="System.AppContext"/> switch name that disables mTLS proof-of-possession token
        /// acquisition for <see cref="ClientCertificateCredential"/>.
        /// </summary>
        internal const string DisableClientCertificateMtlsProofOfPossessionSwitchName = "Azure.Identity.DisableClientCertificateMtlsProofOfPossession";

        /// <summary>
        /// The environment variable that disables mTLS proof-of-possession token acquisition for
        /// <see cref="ClientCertificateCredential"/>.
        /// </summary>
        internal const string DisableClientCertificateMtlsProofOfPossessionEnvVar = "AZURE_IDENTITY_DISABLE_CLIENT_CERTIFICATE_MTLS_POP";

        /// <summary>
        /// When <c>true</c>, <see cref="ClientCertificateCredential"/> requests a bearer token even when
        /// proof-of-possession was requested by the caller. Intended for first-party callers only. The
        /// <see cref="System.AppContext"/> switch takes priority over the environment variable.
        /// </summary>
        public static bool DisableClientCertificateMtlsProofOfPossession
            => AppContextSwitchHelper.GetConfigValue(
                DisableClientCertificateMtlsProofOfPossessionSwitchName,
                DisableClientCertificateMtlsProofOfPossessionEnvVar);
    }
}
