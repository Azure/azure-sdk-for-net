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
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Utilities.HttpRecorder;
using Microsoft.WindowsAzure.Common;
using Microsoft.Azure.Common.Extensions.Factories;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.Azure.Common.Extensions;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockClientFactory : ClientFactory
    {
        private readonly bool throwWhenNotAvailable;

        public List<object> ManagementClients { get; private set; }

        public MockClientFactory(IEnumerable<object> clients, bool throwIfClientNotSpecified = true)
        {
            ManagementClients = clients.ToList();
            throwWhenNotAvailable = throwIfClientNotSpecified;
        }

        public override TClient CreateClient<TClient>(AzureSubscription subscription, AzureEnvironment.Endpoint endpoint)
        {
            SubscriptionCloudCredentials creds = new TokenCloudCredentials(subscription.Id.ToString(), "fake_token");
            if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Playback)
            {
                ProfileClient profileClient = new ProfileClient();
                AzureContext context = new AzureContext()
                {
                    Account = profileClient.GetAccount(subscription.Account),
                    Environment = profileClient.GetEnvironmentOrDefault(subscription.Environment),
                    Subscription = subscription
                };

                creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            }

            Uri endpointUri = (new ProfileClient()).Profile.Environments[subscription.Environment].GetEndpointAsUri(endpoint);
            return CreateCustomClient<TClient>(creds, endpointUri);
        }

        public override TClient CreateCustomClient<TClient>(params object[] parameters)
        {
            TClient client = ManagementClients.FirstOrDefault(o => o is TClient) as TClient;
            if (client == null)
            {
                if (throwWhenNotAvailable)
                {
                    throw new ArgumentException(
                        string.Format("TestManagementClientHelper class wasn't initialized with the {0} client.",
                            typeof(TClient).Name));
                }
                else
                {
                    var realClient = base.CreateCustomClient<TClient>(parameters);
                    var newRealClient = realClient.WithHandler(HttpMockServer.CreateInstance());
                    realClient.Dispose();
                    return newRealClient;
                }
            }

            return client;
        }

        public override HttpClient CreateHttpClient(string serviceUrl, HttpMessageHandler effectiveHandler)
        {
            if (serviceUrl == null)
            {
                throw new ArgumentNullException("serviceUrl");
            }
            if (effectiveHandler == null)
            {
                throw new ArgumentNullException("effectiveHandler");
            }
            var mockHandler = HttpMockServer.CreateInstance();
            mockHandler.InnerHandler = effectiveHandler;

            HttpClient client = new HttpClient(mockHandler)
            {
                BaseAddress = new Uri(serviceUrl),
                MaxResponseContentBufferSize = 30 * 1024 * 1024
            };

            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }
    }
}
