// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/>.
    /// </summary>
    public class InteractiveBrowserCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Prevents the <see cref="InteractiveBrowserCredential"/> from automatically prompting the user. If automatic authentication is disabled a AuthenticationRequiredException will be thrown from <see cref="InteractiveBrowserCredential.GetToken"/> and <see cref="InteractiveBrowserCredential.GetTokenAsync"/> in the case that
        /// user interaction is necessary. The application is responsible for handling this exception, and calling <see cref="InteractiveBrowserCredential.Authenticate(CancellationToken)"/> or <see cref="InteractiveBrowserCredential.AuthenticateAsync(CancellationToken)"/> to authenticate the user interactively.
        /// </summary>
        public bool DisableAutomaticAuthentication { get; set; }

        /// <summary>
        /// The tenant id the user will be authenticated to. If not specified the user will be authenticated to the home tenant.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The client id of the application used to authenticate the user. If not specified the user will be authenticated with an azure development application.
        /// </summary>
        public string ClientId { get; set; } = Constants.DeveloperSignOnClientId;

        /// <summary>
        /// The <see cref="AuthenticationProfile"/> captured from a previous authentication.
        /// </summary>
        public AuthenticationProfile AuthenticationProfile { get; set; }
    }
}
