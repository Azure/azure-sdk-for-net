﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockClientFactory : IClientFactory
    {
        public List<object> ManagementClients { get; private set; }

        public MockClientFactory(IEnumerable<object> clients)
        {
            ManagementClients = clients.ToList();
        }

        public TClient CreateClient<TClient>(AzureSMProfile profile, AzureSubscription subscription, AzureEnvironment.Endpoint endpoint) 
            where TClient : ServiceClient<TClient>
        {
            SubscriptionCloudCredentials creds = new TokenCloudCredentials(subscription.Id.ToString(), "fake_token");
            Uri endpointUri = profile.Environments[subscription.Environment].GetEndpointAsUri(endpoint);
            return CreateCustomClient<TClient>(creds, endpointUri);
        }

        public TClient CreateClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint) 
            where TClient : ServiceClient<TClient>
        {
            SubscriptionCloudCredentials creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            return CreateCustomClient<TClient>(creds, context.Environment.GetEndpointAsUri(endpoint));
        }

        public TClient CreateClient<TClient>(AzureSMProfile profile, AzureEnvironment.Endpoint endpoint) 
            where TClient : ServiceClient<TClient>
        {
            return CreateClient<TClient>(profile.Context, endpoint);
        }

        public TClient CreateCustomClient<TClient>(params object[] parameters) 
            where TClient : ServiceClient<TClient>
        {
            return ManagementClients.FirstOrDefault(o => o is TClient) as TClient;
        }

        public HttpClient CreateHttpClient(string serviceUrl, HttpMessageHandler effectiveHandler)
        {
            throw new NotImplementedException();
        }

        public HttpClient CreateHttpClient(string endpoint, System.Net.ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public void AddAction(IClientAction action)
        {
            throw new NotImplementedException();
        }

        public void RemoveAction(Type actionType)
        {
            throw new NotImplementedException();
        }

        public void AddHandler<T>(T handler) where T : DelegatingHandler, ICloneable
        {
            throw new NotImplementedException();
        }

        public void RemoveHandler(Type handlerType)
        {
            throw new NotImplementedException();
        }

        public HashSet<System.Net.Http.Headers.ProductInfoHeaderValue> UserAgents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TClient CreateArmClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint) where TClient : Rest.ServiceClient<TClient>
        {
            var creds = AzureSession.AuthenticationFactory.GetServiceClientCredentials(context);
            return CreateCustomArmClient<TClient>(creds, context.Environment.GetEndpointAsUri(endpoint));
        }

        public TClient CreateCustomArmClient<TClient>(params object[] parameters) where TClient : Rest.ServiceClient<TClient>
        {
            return ManagementClients.FirstOrDefault(o => o is TClient) as TClient;
        }


        public void AddUserAgent(string productName)
        {
            AddUserAgent(productName, "");
        }

        public void AddUserAgent(string productName, string productVersion)
        {
            this.UserAgents.Add(new ProductInfoHeaderValue(productName, productVersion));
        }
    }
}
