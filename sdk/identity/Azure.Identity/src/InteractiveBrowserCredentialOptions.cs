// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/>.
    /// </summary>
    public class InteractiveBrowserCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// Prevents the <see cref="InteractiveBrowserCredential"/> from automatically prompting the user. If automatic authentication is disabled a AuthenticationRequiredException will be thrown from <see cref="InteractiveBrowserCredential.GetToken"/> and <see cref="InteractiveBrowserCredential.GetTokenAsync"/> in the case that
        /// user interaction is necessary. The application is responsible for handling this exception, and calling <see cref="InteractiveBrowserCredential.Authenticate(CancellationToken)"/> or <see cref="InteractiveBrowserCredential.AuthenticateAsync(CancellationToken)"/> to authenticate the user interactively.
        /// </summary>
        internal bool DisableAutomaticAuthentication { get; set; }

        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified the user will be authenticated to the home tenant.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The client ID of the application used to authenticate the user. If not specified the user will be authenticated with an Azure development application.
        /// </summary>
        public string ClientId { get; set; } = Constants.DeveloperSignOnClientId;

        /// <summary>
        /// If set to true the credential will store tokens in a cache persisted to the machine, protected to the current user, which can be shared by other credentials and processes.
        /// </summary>
        internal bool EnablePersistentCache { get; set; }

        /// <summary>
        /// If set to true the credential will fall back to storing tokens in an unencrypted file if no OS level user encryption is available.
        /// </summary>
        internal bool AllowUnencryptedCache { get; set; }

        /// <summary>
        /// Uri where the STS will call back the application with the security token. This parameter is not required if the caller is not using a custom <see cref="ClientId"/>. In
        /// the case that the caller is using their own <see cref="ClientId"/> the value must match the redirect url specified when creating the application registration.
        /// </summary>
        public Uri RedirectUri { get; set; }

        /// <summary>
        /// The <see cref="Identity.AuthenticationRecord"/> captured from a previous authentication.
        /// </summary>
        internal AuthenticationRecord AuthenticationRecord { get; set; }

        bool ITokenCacheOptions.EnablePersistentCache => EnablePersistentCache;

        bool ITokenCacheOptions.AllowUnencryptedCache => AllowUnencryptedCache;
    }
}
