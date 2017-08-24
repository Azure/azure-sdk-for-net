// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
namespace Microsoft.Azure.Management.CognitiveServices.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.CognitiveServices;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    public class CognitiveServicesManager : Manager<ICognitiveServicesManagementClient>, ICognitiveServicesManager, IBeta
    {
        #region ctrs
        private CognitiveServicesManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new CognitiveServicesManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }
        #endregion
        #region CognitiveServicesManager builder
        /// <summary>
        /// Creates an instance of CognitiveServicesManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the CognitiveServicesManager</returns>
        public static ICognitiveServicesManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
        return Authenticate(RestClient.Configure()
                .WithEnvironment(credentials.Environment)
                .WithCredentials(credentials)
                .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                .Build(), subscriptionId);
        }
        /// <summary>
        /// Creates an instance of CognitiveServicesManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the CognitiveServicesManager</returns>
        public static ICognitiveServicesManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new CognitiveServicesManager(restClient, subscriptionId);
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
            ICognitiveServicesManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }
        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of CognitiveServicesManager that exposes CognitiveServices management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <returns>the interface exposing CognitiveServices management API entry points that work in a subscription</returns>
            public ICognitiveServicesManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new CognitiveServicesManager(BuildRestClient(credentials), subscriptionId);
            }
        }
        #endregion
    }
    /// <summary>
    /// Entry point to Azure CognitiveServices resource management.
    /// </summary>
    public interface ICognitiveServicesManager : IManager<ICognitiveServicesManagementClient>
    {
    }
}
