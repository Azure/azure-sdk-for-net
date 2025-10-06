// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="EnvironmentCredential"/>.
    /// </summary>
    public class EnvironmentCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants
    {
        /// <summary>
        /// The ID of the tenant to which the credential will authenticate by default. This value defaults to the value of the environment variable AZURE_TENANT_ID.
        /// </summary>
        internal string TenantId { get; set; } = EnvironmentVariables.TenantId;

        /// <summary>
        /// The client ID (app ID) of the service pricipal the credential will authenticate. This value defaults to the value of the environment variable AZURE_CLIENT_ID.
        /// </summary>
        internal string ClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// The client secret used to authenticate the service pricipal. This value defaults to the value of the environment variable AZURE_CLIENT_SECRET.
        /// </summary>
        internal string ClientSecret { get; set; } = EnvironmentVariables.ClientSecret;

        /// <summary>
        /// The path to the client certificate used to authenticate the service pricipal. This value defaults to the value of the environment variable AZURE_CLIENT_CERTIFICATE_PATH.
        /// </summary>
        internal string ClientCertificatePath { get; set; } = EnvironmentVariables.ClientCertificatePath;

        /// <summary>
        /// The password of the client certificate used to authenticate the service pricipal. This value defaults to the value of the environment variable AZURE_CLIENT_CERTIFICATE_PASSWORD.
        /// </summary>
        internal string ClientCertificatePassword { get; set; } = EnvironmentVariables.ClientCertificatePassword;

        /// <summary>
        /// Will include x5c header in client claims when acquiring a token to enable certificate subject name / issuer based authentication. This value defaults to the value of the environment variable AZURE_CLIENT_SEND_CERTIFICATE_CHAIN.
        /// </summary>
        internal bool SendCertificateChain { get; set; } = EnvironmentVariables.ClientSendCertificateChain;

        /// <summary>
        /// The username of the user account the credential will authenticate. This value defaults to the value of the environment variable AZURE_USERNAME.
        /// </summary>
        internal string Username { get; set; } = EnvironmentVariables.Username;

        /// <summary>
        /// The password of used to authenticate the user. This value defaults to the value of the environment variable AZURE_PASSWORD.
        /// </summary>
        internal string Password { get; set; } = EnvironmentVariables.Password;

        /// <summary>
        /// MSAL client to be used for testing.
        /// </summary>
        internal MsalConfidentialClient MsalConfidentialClient { get; set;}

        /// <summary>
        /// MSAL client to be used for testing.
        /// </summary>
        internal MsalPublicClient MsalPublicClient { get; set;}

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <summary>
        /// Specifies tenants in addition to the specified <see cref="TenantId"/> for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no value is specified for <see cref="TenantId"/>, this option will have no effect on that authentication method, and the credential will acquire tokens for any requested tenant when using that method.
        /// </summary>
        /// <remarks>
        /// Defaults to the value of environment variable <c>AZURE_ADDITIONALLY_ALLOWED_TENANTS</c>. Values can be a semi-colon delimited list of tenant IDs , or '*' to denote any tenant ID.
        /// </remarks>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = EnvironmentVariables.AdditionallyAllowedTenants;
    }
}
