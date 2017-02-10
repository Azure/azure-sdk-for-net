// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System.Security;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    public class MockAccessTokenProvider : ITokenProvider
    {
        public AdalConfiguration AdalConfiguration { get; set; }

        private readonly IAccessToken accessToken;

        public MockAccessTokenProvider(string token)
            : this(token, "user@live.com")
        { }

        public MockAccessTokenProvider(string token, string userId)
        {
            this.accessToken = new MockAccessToken()
            {
                AccessToken = token,
                UserId = userId
            };
        }

        public IAccessToken GetAccessToken(AdalConfiguration config, ShowDialog promptBehavior, string userId, SecureString password,
            AzureAccount.AccountType credentialType)
        {
            AdalConfiguration = config;
            return this.accessToken;
        }

        public IAccessToken GetAccessTokenWithCertificate(AdalConfiguration config, string clientId, string certificateThumbprint, AzureAccount.AccountType credentialType)
        {
            AdalConfiguration = config;
            return this.accessToken;
        }
    }
}