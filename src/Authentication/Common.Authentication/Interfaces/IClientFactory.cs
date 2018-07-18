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

using Hyak.Common;
using Microsoft.Azure.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Common.Authentication
{
    public interface IClientFactory
    {
        TClient CreateClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>;

        TClient CreateClient<TClient>(AzureProfile profile, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>;

        TClient CreateClient<TClient>(AzureProfile profile, AzureSubscription subscription, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>;

        TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>;

        HttpClient CreateHttpClient(string endpoint, ICredentials credentials);

        HttpClient CreateHttpClient(string endpoint, HttpMessageHandler effectiveHandler);

        void AddAction(IClientAction action);

        void RemoveAction(Type actionType);

        /// <summary>
        /// Adds user agent to UserAgents collection with empty version.
        /// </summary>
        /// <param name="productName">Product name.</param>
        void AddUserAgent(string productName);

        /// <summary>
        /// Adds user agent to UserAgents collection.
        /// </summary>
        /// <param name="productName">Product name.</param>
        /// <param name="productVersion">Product version.</param>
        void AddUserAgent(string productName, string productVersion);

        /// <summary>
        /// Gets a hash set of user agents to be included in created clients.
        /// </summary>
        HashSet<ProductInfoHeaderValue> UserAgents { get; }
    }
}
