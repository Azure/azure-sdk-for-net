// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure
{
    /// <summary>
    /// Class for token based credentials associated with a particular subscription.
    /// </summary>
    public class TokenCloudCredentials : SubscriptionCloudCredentials
    {
        // The Microsoft Azure Subscription ID.
        private readonly string _subscriptionId = null;

        /// <summary>
        /// Gets subscription ID which uniquely identifies Microsoft Azure 
        /// subscription. The subscription ID forms part of the URI for 
        /// every call that you make to the Service Management API.
        /// </summary>
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }

        /// <summary>
        /// Gets or sets secure token used to authenticate against Microsoft Azure API. 
        /// No anonymous requests are allowed.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCloudCredentials"/>
        /// class with subscription ID.
        /// </summary>
        /// <param name="subscriptionId">The Subscription ID.</param>
        /// <param name="token">Valid JSON Web Token (JWT).</param>
        public TokenCloudCredentials(string subscriptionId, string token)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException("subscriptionId");
            }
            else if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            _subscriptionId = subscriptionId;
            Token = token;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCloudCredentials"/>
        /// class without subscription ID.
        /// </summary>
        /// <param name="token">Valid JSON Web Token (JWT).</param>
        public TokenCloudCredentials(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            Token = token;
        }

        /// <summary>
        /// Attempt to create token credentials from a collection of
        /// settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>
        /// TokenCloudCredentials is created, null otherwise.
        /// </returns>
        [Obsolete("Deprecated method. Use public constructor instead.")]
        public static TokenCloudCredentials Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            
            if (!settings.ContainsKey("token"))
            {
                return null;
            }

            if (settings.ContainsKey("SubscriptionId"))
            {
                return new TokenCloudCredentials(settings["SubscriptionId"].ToString(), 
                    settings["token"].ToString());
            }
            else
            {
                return new TokenCloudCredentials(settings["token"].ToString());
            }
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has completed.
        /// </returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
