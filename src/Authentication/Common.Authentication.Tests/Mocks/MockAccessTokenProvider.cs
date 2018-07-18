// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
    }
}