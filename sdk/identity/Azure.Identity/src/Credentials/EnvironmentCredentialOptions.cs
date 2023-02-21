// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="EnvironmentCredential"/>.
    /// </summary>
    public class EnvironmentCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTokenCachePersistenceOptions
    {
        /// <summary>
        /// The ID of the tenant to which the credential will authenticate by default. This value defaults to the value of the environment variable AZURE_TENANT_ID.
        /// </summary>
        public string TenantId { get; set; } = EnvironmentVariables.TenantId;

        /// <summary>
        /// The client ID (app ID) of the service pricipal the credential will authenticate. This value defaults to the value of the environment variable AZURE_CLIENT_ID.
        /// </summary>
        public string ClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// The client secret used to authenticate the service pricipal. This value defaults to the value of the environment variable AZURE_CLIENT_SECRET.
        /// </summary>
        public string ClientSecret { get; set; } = EnvironmentVariables.ClientSecret;

        /// <summary>
        /// The path to the client certificate used to authenticate the service pricipal. This value defaults to the value of the environment variable AZURE_CLIENT_CERTIFICATE_PATH.
        /// </summary>
        public string ClientCertificatePath { get; set; } = EnvironmentVariables.ClientCertificatePath;

        /// <summary>
        /// The password of the client certificate used to authenticate the service pricipal. This value defaults to the value of the environment variable AZURE_CLIENT_CERTIFICATE_PASSWORD.
        /// </summary>
        public string ClientCertificatePassword { get; set; } = EnvironmentVariables.ClientCertificatePassword;

        /// <summary>
        /// Will include x5c header in client claims when acquiring a token to enable certificate subject name / issuer based authentication. This value defaults to the value of the environment variable AZURE_CLIENT_SEND_CERTIFICATE_CHAIN.
        /// </summary>
        public bool SendCertificateChain { get; set; } = EnvironmentVariables.ClientSendCertificateChain;

        /// <summary>
        /// The username of the user account the credeential will authenticate. This value defaults to the value of the environment variable AZURE_USERNAME.
        /// </summary>
        public string Username { get; set; } = EnvironmentVariables.Username;

        /// <summary>
        /// The password of used to authenticate the user. This value defaults to the value of the environment variable AZURE_PASSWORD.
        /// </summary>
        public string Password { get; set; } = EnvironmentVariables.Password;

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <inheritdoc/>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = EnvironmentVariables.AdditionallyAllowedTenants;

        /// <inheritdoc/>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
