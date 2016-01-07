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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Common.Authentication.Authentication
{
    /// <summary>
    /// Token provider for resources that use the refresh token
    /// </summary>
    public abstract class RefreshTokenProvider : Microsoft.Rest.ITokenProvider
    {
        protected RefreshTokenProvider(string authority, bool validateAuthority, TokenCache cache,
            string defaultResourceId, string targetResourceId, string clientId)
        {
            Context = new AuthenticationContext(authority, validateAuthority, cache);
            DefaultResourceId = defaultResourceId;
            TargetResourceId = targetResourceId;
            ClientId = clientId;
        }

        protected RefreshTokenProvider(AzureContext context, string domain,
            AzureEnvironment.Endpoint targetEndpoint, string clientId) 
            : this(context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory) + domain, 
            !context.Environment.OnPremise, 
            new TokenCache(context.TokenCache), 
            context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId), 
            targetEndpoint == AzureEnvironment.Endpoint.Graph? 
            context.Environment.GetEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId) : 
            context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId), 
            clientId)
        {
        }
        protected string DefaultResourceId { get; set; }
        protected string TargetResourceId { get; set; }
        protected string ClientId { get; set; }
        protected abstract string GetRefreshToken(string defaultResourceId);

        protected  AuthenticationContext Context { get; set; }

        public static AuthenticationContext GetAuthenticationContext(string authority, bool validateAuthority, TokenCache cache)
        {
            return new AuthenticationContext(authority, validateAuthority, cache);
        }

        public Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            var refresh = GetRefreshToken(DefaultResourceId);
            var result = Context.AcquireTokenByRefreshToken(refresh, ClientId, TargetResourceId);
            return Task.FromResult(new AuthenticationHeaderValue(result.AccessTokenType, result.AccessToken));
        }
    }
}
