// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The entry point for all ARM clients.
    /// </summary>
    public class AzureResourceManagerClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        internal const string DefaultUri = "https://management.azure.com";

        private readonly TokenCredential _credentials;

        private readonly Uri _baseUri;
        private TenantOperations _tenant;

        /// <summary>
        /// Get the tenant operations <see cref="TenantOperations"/> class.
        /// </summary>
        public TenantOperations Tenant => _tenant ??= new TenantOperations(ClientOptions, DefaultSubscription, _credentials, _baseUri);

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureResourceManagerClient"/> class for mocking.
        /// </summary>
        protected AzureResourceManagerClient()
            : this(null, null, new DefaultAzureCredential(), new AzureResourceManagerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureResourceManagerClient"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        public AzureResourceManagerClient(AzureResourceManagerClientOptions options = default)
            : this(null, null, new DefaultAzureCredential(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureResourceManagerClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        public AzureResourceManagerClient(TokenCredential credential, AzureResourceManagerClientOptions options = default)
            : this(null, null, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureResourceManagerClient"/> class.
        /// </summary>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        public AzureResourceManagerClient(string defaultSubscriptionId, TokenCredential credential, AzureResourceManagerClientOptions options = default)
            : this(defaultSubscriptionId, null, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureResourceManagerClient"/> class.
        /// </summary>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        public AzureResourceManagerClient(Uri baseUri, TokenCredential credential, AzureResourceManagerClientOptions options = default)
            : this(null, baseUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureResourceManagerClient"/> class.
        /// </summary>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        private AzureResourceManagerClient(string defaultSubscriptionId, Uri baseUri, TokenCredential credential, AzureResourceManagerClientOptions options = default)
        {
            _credentials = credential;
            _baseUri = baseUri;
            ClientOptions = options ?? new AzureResourceManagerClientOptions();

            if (string.IsNullOrWhiteSpace(defaultSubscriptionId))
            {
                DefaultSubscription = GetDefaultSubscription();
            }
            else
            {
                DefaultSubscription = GetSubscriptionOperations(defaultSubscriptionId).Get().Value;
            }

            ApiVersionOverrides = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets the Api version overrides.
        /// </summary>
        public Dictionary<string, string> ApiVersionOverrides { get; private set; }

        /// <summary>
        /// Gets the default Azure subscription.
        /// </summary>
        public Subscription DefaultSubscription { get; private set; }

        /// <summary>
        /// Gets the Azure resource manager client options.
        /// </summary>
        internal AzureResourceManagerClientOptions ClientOptions { get; }

        /// <summary>
        /// Gets the Azure subscription operations.
        /// </summary>
        /// <param name="subscriptionGuid"> The guid of the subscription. </param>
        /// <returns> Subscription operations. </returns>
        public SubscriptionOperations GetSubscriptionOperations(string subscriptionGuid) => new SubscriptionOperations(
            ClientOptions,
            subscriptionGuid,
            _credentials,
            _baseUri);

        /// <summary>
        /// Gets the Azure subscriptions.
        /// </summary>
        /// <returns> Subscription container. </returns>
        public SubscriptionContainer GetSubscriptionContainer()
        {
            return new SubscriptionContainer(ClientOptions, _credentials, _baseUri);
        }

        /// <summary>
        /// Gets resource group operations.
        /// </summary>
        /// <param name="subscriptionGuid"> The id of the Azure subscription. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <returns> Resource group operations. </returns>
        public ResourceGroupOperations GetResourceGroupOperations(string subscriptionGuid, string resourceGroupName)
        {
            return GetSubscriptionOperations(subscriptionGuid).GetResourceGroupOperations(resourceGroupName);
        }

        /// <summary>
        /// Gets resource group operations.
        /// </summary>
        /// <param name="resourceGroupId"> The resource identifier of the resource group. </param>
        /// <returns> Resource group operations. </returns>
        public ResourceGroupOperations GetResourceGroupOperations(ResourceIdentifier resourceGroupId)
        {
            return GetSubscriptionOperations(resourceGroupId.Subscription).GetResourceGroupOperations(resourceGroupId.ResourceGroup);
        }

        /// <summary>
        /// Gets resource operations base.
        /// </summary>
        /// <typeparam name="T"> The type of the underlying model this class wraps. </typeparam>
        /// <param name="subscription"> The id of the Azure subscription. </param>
        /// <param name="resourceGroup"> The resource group name. </param>
        /// <param name="name"> The resource type name. </param>
        /// <returns> Resource operations of the resource. </returns>
        public T GetResourceOperations<T>(string subscription, string resourceGroup, string name)
            where T : OperationsBase
        {
            var rgOp = GetSubscriptionOperations(subscription).GetResourceGroupOperations(resourceGroup);
            return Activator.CreateInstance(
                typeof(T),
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new object[] { rgOp, name },
                CultureInfo.InvariantCulture) as T;
        }

        private Subscription GetDefaultSubscription()
        {
            var sub = GetSubscriptionContainer().List().FirstOrDefault();
            if (sub is null)
                throw new Exception("No subscriptions found for the given credentials");
            return sub;
        }
    }
}
