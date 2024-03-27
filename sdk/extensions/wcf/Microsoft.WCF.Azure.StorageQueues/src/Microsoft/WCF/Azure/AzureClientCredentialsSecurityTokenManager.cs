// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.WCF.Azure.Tokens;
using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace Microsoft.WCF.Azure
{
    /// <summary>
    /// Manages Azure credential security tokens for the client.
    /// </summary>
    public class AzureClientCredentialsSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        private AzureClientCredentials _azureClientCredentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureClientCredentialsSecurityTokenManager"/> class.
        /// </summary>
        /// <param name="azureClientCredentials"></param>
        public AzureClientCredentialsSecurityTokenManager(AzureClientCredentials azureClientCredentials) : base(azureClientCredentials)
        {
            _azureClientCredentials = azureClientCredentials;
        }

        /// <summary>
        /// Creates a security token authenticator.
        /// </summary>
        /// <param name="tokenRequirement">The <see cerf="SecurityTokenRequirement">SecurityTokenRequirement</see>.</param>
        /// <param name="outOfBandTokenResolver">When this method returns, contains a <see cref="SecurityTokenResolver">SecurityTokenResolver</see>. This parameter is passed uninitialized.</param>
        /// <returns>The <see cref="SecurityTokenAuthenticator">SecurityTokenAuthenticator</see> object.</returns>
        /// <exception cref="ArgumentNullException">`tokenRequirement` is `null`.</exception>

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        /// <summary>
        /// Creates a security token provider.
        /// </summary>
        /// <param name="tokenRequirement">The <see cref="SecurityTokenRequirement">SecurityTokenRequirement</see>.</param>
        /// <returns>The <see cref="SecurityTokenProvider">SecurityTokenProvider</see> object.</returns>
        /// <exception cref="ArgumentNullException">`tokenRequirement` is `null`.</exception>
        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            ArgumentNullException.ThrowIfNull(tokenRequirement);

            if (tokenRequirement.TokenType.StartsWith(AzureSecurityTokenTypes.Namespace))
                return new AzureSecurityTokenProvider(_azureClientCredentials, tokenRequirement);
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        /// <summary>
        /// Creates a security token serializer.
        /// </summary>
        /// <param name="version">The <see cref="SecurityTokenVersion">SecurityTokenVersion</see> of the security token.</param>
        /// <returns>The <see cref="SecurityTokenSerializer">SecurityTokenSerializer</see> object.</returns>
        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return base.CreateSecurityTokenSerializer(version);
        }
    }
}