//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Class for token based credentials associated with a particular subscription.
    /// </summary>
    public class TokenCloudCredentials : SubscriptionCloudCredentials
    {
        // The Windows Azure Subscription ID.
        private readonly string _subscriptionId = null;

        /// <summary>
        /// Gets subscription ID which uniquely identifies Windows Azure 
        /// subscription. The subscription ID forms part of the URI for 
        /// every call that you make to the Service Management API.
        /// </summary>
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }

        /// <summary>
        /// Gets or sets secure token used to authenticate against Windows Azure API. 
        /// No anonymous requests are allowed.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets token type. Default is Bearer.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCloudCredentials"/>
        /// class.
        /// </summary>
        /// <param name="subscriptionId">The Subscription ID.</param>
        /// <param name="token">Valid JSON Web Token (JWT).</param>
        public TokenCloudCredentials(string subscriptionId, string token)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            else if (subscriptionId.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("subscriptionId");
            }
            else if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            else if (token.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("token");
            }

            _subscriptionId = subscriptionId;
            Token = token;
            TokenType = "Bearer";
        }

        /// <summary>
        /// Attempt to create token credentials from a collection of
        /// settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>
        /// TokenCloudCredentials is created, null otherwise.
        /// </returns>
        public static TokenCloudCredentials Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            string subscriptionId = ConfigurationHelper.GetString(settings, "SubscriptionId", false);
            string token = ConfigurationHelper.GetString(settings, "Token", false);

            if (subscriptionId != null && token != null)
            {
                return new TokenCloudCredentials(subscriptionId, token);
            }

            return null;
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has completed.
        /// </returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(TokenType, Token);
            });
        }
    }
}
