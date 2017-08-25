// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.Fluent.ServiceBus;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    public class MonitorManager : Manager<IMonitorManagementClient>, IMonitorManager, IBeta
    {
        public IMonitorClient InnerEx { get; }
        
        #region ctrs

        private static IMonitorManagementClient GetInnerClient(RestClient restClient, string subscriptionId)
        {
            return new MonitorManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            };
        }
        
        private MonitorManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, GetInnerClient(restClient, subscriptionId))
        {
            InnerEx = new MonitorClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            };
        }
        
        #endregion
        
        #region MonitorManager builder
        /// <summary>
        /// Creates an instance of MonitorManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the MonitorManager</returns>
        public static IMonitorManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return Authenticate(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                        .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }
        
        /// <summary>
        /// Creates an instance of MonitorManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the MonitorManager</returns>
        public static IMonitorManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new MonitorManager(restClient, subscriptionId);
        }
        
        /// <summary>
        /// Get a Configurable instance that can be used to create StorageManager with optional configuration.
        /// </summary>
        /// <returns>the instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }
        #endregion
        
        #region IConfigurable and it's implementation
        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IMonitorManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }
        
        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of MonitorManager that exposes Monitor management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <returns>the interface exposing Monitor management API entry points that work in a subscription</returns>
            public IMonitorManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new MonitorManager(BuildRestClient(credentials), subscriptionId);
            }
        }
        #endregion
    }
    
    /// <summary>
    /// Entry point to Azure Monitor.
    /// </summary>
    public interface IMonitorManager : IManager<IMonitorManagementClient>
    {
        IMonitorClient InnerEx { get; }
    }
}
