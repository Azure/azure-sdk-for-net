// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    /// <summary>
    /// Entry point to Azure Service Bus management.
    /// </summary>
    public class ServiceBusManager : Manager<IServiceBusManagementClient>, IServiceBusManager
    {
        #region Fluent private collections
        private IServiceBusNamespaces namespaces;
        private IServiceBusOperations operations;
        #endregion


        public ServiceBusManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ServiceBusManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #region ServiceBusManager builder

        public static IServiceBusManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new ServiceBusManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        public static IServiceBusManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new ServiceBusManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IServiceBusManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IServiceBusManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new ServiceBusManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IServiceBusNamespaces Namespaces
        {
            get
            {
                if (namespaces == null)
                {
                    namespaces = new ServiceBusNamespacesImpl(this);
                }
                return namespaces;
            }
        }

        public IServiceBusOperations Operations
        {
            get
            {
                if (operations == null)
                {
                    operations = new ServiceBusOperationsImpl(this);
                }
                return operations;
            }
        }
    }

    public interface IServiceBusManager : IManager<IServiceBusManagementClient>, IBeta
    {
        IServiceBusNamespaces Namespaces { get; }

        IServiceBusOperations Operations { get; }
    }
}

