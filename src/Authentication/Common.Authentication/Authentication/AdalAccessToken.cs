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
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Common.Authentication
{
        /// <summary>
        /// Implementation of <see cref="IAccessToken"/> using data from ADAL
        /// </summary>
        internal class AdalAccessToken : IAccessToken
        {
            internal readonly AdalConfiguration Configuration;
            internal AuthenticationResult AuthResult;
            private readonly ITokenProvider _tokenProvider;
            private readonly Action<AdalAccessToken> _renewer;
            private string _userId;

            public AdalAccessToken(AuthenticationResult authResult, UserTokenProvider tokenProvider, AdalConfiguration configuration)
            {
                AuthResult = authResult;
                _tokenProvider = tokenProvider;
                _renewer = tokenProvider.Renew;
                Configuration = configuration;
                _userId = AuthResult.UserInfo.DisplayableId;
            }

            public AdalAccessToken(AuthenticationResult authResult, RefreshTokenProvider tokenProvider, AdalConfiguration configuration, string userId)
            {
                AuthResult = authResult;
                _tokenProvider = tokenProvider;
                _renewer = tokenProvider.Renew;
                Configuration = configuration;
                _userId = userId;
            }

            public void AuthorizeRequest(Action<string, string> authTokenSetter)
            {
                _renewer(this);
                authTokenSetter(AuthResult.AccessTokenType, AuthResult.AccessToken);
            }

            public string AccessToken { get { return AuthResult.AccessToken; } }
            public string UserId { get { return _userId; } }

            public string TenantId { get { return AuthResult.TenantId?? Configuration.AdDomain; } }

            public LoginType LoginType
            {
                get
                {
                    if (AuthResult.UserInfo != null && AuthResult.UserInfo.IdentityProvider != null)
                    {
                        return LoginType.LiveId;
                    }
                    return LoginType.OrgId;
                }
            }
        }}
