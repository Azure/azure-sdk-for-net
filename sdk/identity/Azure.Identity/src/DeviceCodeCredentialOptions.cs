// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="DeviceCodeCredential"/>.
    /// </summary>
    public class DeviceCodeCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// Prevents the <see cref="DeviceCodeCredential"/> from automatically prompting the user. If automatic authentication is disabled a AuthenticationRequiredException will be thrown from <see cref="DeviceCodeCredential.GetToken"/> and <see cref="DeviceCodeCredential.GetTokenAsync"/> in the case that
        /// user interaction is necessary. The application is responsible for handling this exception, and calling <see cref="DeviceCodeCredential.Authenticate(CancellationToken)"/> or <see cref="DeviceCodeCredential.AuthenticateAsync(CancellationToken)"/> to authenticate the user interactively.
        /// </summary>
        internal bool DisableAutomaticAuthentication { get; set; }

        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified the user will be authenticated to their home tenant.
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
        /// The <see cref="Identity.AuthenticationRecord"/> captured from a previous authentication.
        /// </summary>
        internal AuthenticationRecord AuthenticationRecord { get; set; }

        /// <summary>
        /// The callback which will be executed to display the device code login details to the user. In not specified the device code and login instructions will be printed to the console.
        /// </summary>
        public Func<DeviceCodeInfo, CancellationToken, Task> DeviceCodeCallback { get; set; }

        bool ITokenCacheOptions.EnablePersistentCache => EnablePersistentCache;

        bool ITokenCacheOptions.AllowUnencryptedCache => AllowUnencryptedCache;
    }
}
