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

using System;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Common.Authentication.Authentication
{
    public class UserRefreshTokenProvider : RefreshTokenProvider
    {
        private UserIdentifier _userId;

        protected override string GetRefreshToken(string defaultResourceId)
        {
            var result = Context.AcquireTokenSilent(defaultResourceId, ClientId, _userId);
            return result.RefreshToken;
        }

        public UserRefreshTokenProvider(string userId, string authority, bool validateAuthority, TokenCache cache, string defaultResourceId, string targetResourceId, string clientId) : base(authority, validateAuthority, cache, defaultResourceId, targetResourceId, clientId)
        {
            _userId = new UserIdentifier(userId, UserIdentifierType.RequiredDisplayableId);
        }

        public UserRefreshTokenProvider(AzureContext context, string domain, AzureEnvironment.Endpoint targetEndpoint, string clientId) : base(context, domain, targetEndpoint, clientId)
        {
            _userId = new UserIdentifier(context.Account.Id, UserIdentifierType.RequiredDisplayableId);
        }
    }
}
