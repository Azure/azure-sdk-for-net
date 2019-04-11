// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// This abstract base class can be extended to implement additional token providers.
    /// </summary>
    public abstract class TokenProvider : ITokenProvider
    {
        /// <summary>
        /// Construct a TokenProvider based on a sharedAccessSignature.
        /// </summary>
        /// <param name="sharedAccessSignature">The shared access signature</param>
        /// <returns>A TokenProvider initialized with the shared access signature</returns>
        /// <remarks><see cref="TokenProvider.GetTokenAsync(string, TimeSpan)"/> parameters will not be used 
        /// to manipulate target URL and token TTL.</remarks>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string sharedAccessSignature)
        {
            return new SharedAccessSignatureTokenProvider(sharedAccessSignature);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <returns>A TokenProvider initialized with the provided RuleId and Password</returns>
        /// <remarks>Default token TTL is 1 hour and token scope is at entity level.</remarks>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenTimeToLive">The token time to live</param>
        /// <returns>A TokenProvider initialized with the provided keyName and key.</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenTimeToLive);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenScope">The tokenScope of tokens to request.</param>
        /// <returns>A TokenProvider initialized with the provided keyName and key</returns>
        /// <remarks>Default token TTL is 1 hour.</remarks>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TokenScope tokenScope)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenScope);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenTimeToLive">The token time to live</param> 
        /// <param name="tokenScope">The tokenScope of tokens to request.</param>
        /// <returns>A TokenProvider initialized with the provided RuleId and Password</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive, TokenScope tokenScope)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenTimeToLive, tokenScope);
        }

        /// <summary>Creates an Azure Active Directory token provider.</summary>
        /// <param name="authContext">AuthenticationContext for AAD.</param>
        /// <param name="clientCredential">The app credential.</param>
        /// <returns>The <see cref="TokenProvider" /> for returning Json web token.</returns>
        public static TokenProvider CreateAadTokenProvider(AuthenticationContext authContext, ClientCredential clientCredential)
        {
            if (authContext == null)
            {
                throw new ArgumentNullException(nameof(authContext));
            }

            if (clientCredential == null)
            {
                throw new ArgumentNullException(nameof(clientCredential));
            }

            return new AzureActiveDirectoryTokenProvider(authContext, clientCredential);
        }

        /// <summary>Creates an Azure Active Directory token provider.</summary>
        /// <param name="authContext">AuthenticationContext for AAD.</param>
        /// <param name="clientId">ClientId for AAD.</param>
        /// <param name="redirectUri">The redirectUri on Client App.</param>
        /// <param name="platformParameters">Platform parameters</param>
        /// <param name="userIdentifier">User Identifier</param>
        /// <returns>The <see cref="TokenProvider" /> for returning Json web token.</returns>
        public static TokenProvider CreateAadTokenProvider(
            AuthenticationContext authContext,
            string clientId,
            Uri redirectUri,
            IPlatformParameters platformParameters,
            UserIdentifier userIdentifier = null)
        {
            if (authContext == null)
            {
                throw new ArgumentNullException(nameof(authContext));
            }

            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (redirectUri == null)
            {
                throw new ArgumentNullException(nameof(redirectUri));
            }

            if (platformParameters == null)
            {
                throw new ArgumentNullException(nameof(platformParameters));
            }

            return new AzureActiveDirectoryTokenProvider(authContext, clientId, redirectUri, platformParameters, userIdentifier);
        }

#if !UAP10_0
        /// <summary>Creates an Azure Active Directory token provider.</summary>
        /// <param name="authContext">AuthenticationContext for AAD.</param>
        /// <param name="clientAssertionCertificate">The client assertion certificate credential.</param>
        /// <returns>The <see cref="TokenProvider" /> for returning Json web token.</returns>
        public static TokenProvider CreateAadTokenProvider(AuthenticationContext authContext, ClientAssertionCertificate clientAssertionCertificate)
        {
            if (authContext == null)
            {
                throw new ArgumentNullException(nameof(authContext));
            }

            if (clientAssertionCertificate == null)
            {
                throw new ArgumentNullException(nameof(clientAssertionCertificate));
            }

            return new AzureActiveDirectoryTokenProvider(authContext, clientAssertionCertificate);
        }
#endif

        /// <summary>Creates Azure Managed Service Identity token provider.</summary>
        /// <returns>The <see cref="TokenProvider" /> for returning Json web token.</returns>
        public static TokenProvider CreateManagedServiceIdentityTokenProvider()
        {
            return new ManagedServiceIdentityTokenProvider();
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The timeout value for how long it takes to get the security token (not the token time to live).</param>
        /// <remarks>This parameter <paramref name="timeout"/> is here for compatibility, but is not currently used.</remarks>
        public abstract Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout);
    }
}
