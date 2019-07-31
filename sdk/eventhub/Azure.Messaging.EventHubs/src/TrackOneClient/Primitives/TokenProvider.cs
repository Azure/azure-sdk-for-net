// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TrackOne
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using TrackOne.Primitives;

    /// <summary>
    /// This abstract base class can be extended to implement additional token providers.
    /// </summary>
    internal abstract class TokenCredential : TokenCredential
    {
        /// <summary>
        /// Construct a TokenCredential based on a sharedAccessSignature.
        /// </summary>
        /// <param name="sharedAccessSignature">The shared access signature</param>
        /// <returns>A TokenCredential initialized with the shared access signature</returns>
        public static TokenCredential CreateSharedAccessSignatureTokenProvider(string sharedAccessSignature)
        {
            return new SharedAccessSignatureTokenProvider(sharedAccessSignature);
        }

        /// <summary>
        /// Construct a TokenCredential based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <returns>A TokenCredential initialized with the provided RuleId and Password</returns>
        public static TokenCredential CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey);
        }

        //internal static TokenCredential CreateIoTTokenProvider(string keyName, string sharedAccessKey)
        //{
        //    return new IoTTokenProvider(keyName, sharedAccessKey, DefaultTokenTimeout);
        //}

        /// <summary>
        /// Construct a TokenCredential based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenTimeToLive">The token time to live</param>
        /// <returns>A TokenCredential initialized with the provided RuleId and Password</returns>
        public static TokenCredential CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenTimeToLive);
        }

        /// <summary>
        /// Construct a TokenCredential based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenScope">The tokenScope of tokens to request.</param>
        /// <returns>A TokenCredential initialized with the provided RuleId and Password</returns>
        public static TokenCredential CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TokenScope tokenScope)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenScope);
        }

        /// <summary>
        /// Construct a TokenCredential based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenTimeToLive">The token time to live</param>
        /// <param name="tokenScope">The tokenScope of tokens to request.</param>
        /// <returns>A TokenCredential initialized with the provided RuleId and Password</returns>
        public static TokenCredential CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive, TokenScope tokenScope)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenTimeToLive, tokenScope);
        }


#if ALLOW_CERTIFICATE_IDENTITY
        /// <summary>Creates an Azure Active Directory token provider.</summary>
        /// <param name="authContext">AuthenticationContext for AAD.</param>
        /// <param name="clientCredential">The app credential.</param>
        /// <returns>The <see cref="TokenCredential" /> for returning Json web token.</returns>
        public static TokenCredential CreateAadTokenProvider(AuthenticationContext authContext, ClientCredential clientCredential)
        {
            Guard.ArgumentNotNull(nameof(authContext), authContext);
            Guard.ArgumentNotNull(nameof(clientCredential), clientCredential);

            return new AzureActiveDirectoryTokenProvider(authContext, clientCredential);
        }
#endif

        /// <summary>Creates an Azure Active Directory token provider.</summary>
        /// <param name="authContext">AuthenticationContext for AAD.</param>
        /// <param name="clientId">ClientId for AAD.</param>
        /// <param name="redirectUri">The redirectUri on Client App.</param>
        /// <param name="platformParameters">Platform parameters</param>
        /// <param name="userIdentifier">User Identifier</param>
        /// <returns>The <see cref="TokenCredential" /> for returning Json web token.</returns>
        public static TokenCredential CreateAadTokenProvider(
            AuthenticationContext authContext,
            string clientId,
            Uri redirectUri,
            IPlatformParameters platformParameters,
            UserIdentifier userIdentifier = null)
        {
            Guard.ArgumentNotNull(nameof(authContext), authContext);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(clientId), clientId);
            Guard.ArgumentNotNull(nameof(redirectUri), redirectUri);
            Guard.ArgumentNotNull(nameof(platformParameters), platformParameters);

            return new AzureActiveDirectoryTokenProvider(authContext, clientId, redirectUri, platformParameters, userIdentifier);
        }

#if ALLOW_CERTIFICATE_IDENTITY
        /// <summary>Creates an Azure Active Directory token provider.</summary>
        /// <param name="authContext">AuthenticationContext for AAD.</param>
        /// <param name="clientAssertionCertificate">The client assertion certificate credential.</param>
        /// <returns>The <see cref="TokenCredential" /> for returning Json web token.</returns>
        public static TokenCredential CreateAadTokenProvider(AuthenticationContext authContext, ClientAssertionCertificate clientAssertionCertificate)
        {
            Guard.ArgumentNotNull(nameof(authContext), authContext);
            Guard.ArgumentNotNull(nameof(clientAssertionCertificate), clientAssertionCertificate);

            return new AzureActiveDirectoryTokenProvider(authContext, clientAssertionCertificate);
        }
#endif

        /// <summary>Creates Azure Managed Service Identity token provider.</summary>
        /// <returns>The <see cref="TokenCredential" /> for returning Json web token.</returns>
        public static TokenCredential CreateManagedServiceIdentityTokenProvider()
        {
            return new ManagedServiceIdentityTokenProvider();
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns></returns>
        public abstract Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout);
    }
}
