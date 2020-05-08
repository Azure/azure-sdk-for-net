// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="DeviceCodeCredential"/>.
    /// </summary>
    public class DeviceCodeCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Prevents the <see cref="DeviceCodeCredential"/> from automatically prompting the user. If automatic authentication is disabled a AuthenticationRequiredException will be thrown from <see cref="DeviceCodeCredential.GetToken"/> and <see cref="DeviceCodeCredential.GetTokenAsync"/> in the case that
        /// user interaction is necessary. The application is responsible for handling this exception, and calling <see cref="DeviceCodeCredential.Authenticate(CancellationToken)"/> or <see cref="DeviceCodeCredential.AuthenticateAsync(CancellationToken)"/> to authenticate the user interactively.
        /// </summary>
        public bool DisableAutomaticAuthentication { get; set; }

        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified the user will be authenticated to their home tenant.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The client ID of the application used to authenticate the user. If not specified the user will be authenticated with an Azure development application.
        /// </summary>
        public string ClientId { get; set; } = Constants.DeveloperSignOnClientId;

        /// <summary>
        /// If set to true the credential will store tokens in a persistent cache shared by other user credentials.
        /// </summary>
        public bool EnablePersistentCache { get; set; }

        /// <summary>
        /// The <see cref="Identity.AuthenticationRecord"/> captured from a previous authentication.
        /// </summary>
        public AuthenticationRecord AuthenticationRecord { get; set; }
    }
}
