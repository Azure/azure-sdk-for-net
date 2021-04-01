// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The entry point for all ARM clients.
    /// </summary>
    public class ArmClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        internal const string DefaultUri = "https://management.azure.com";

        private TenantOperations _tenant;
        /// <summary>
        /// Get the tenant operations <see cref="TenantOperations"/> class.
        /// </summary>
        public TenantOperations Tenant => _tenant ??= new TenantOperations(ClientOptions, Credential, BaseUri);

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class for mocking.
        /// </summary>
        protected ArmClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, ArmClientOptions options = default)
            : this(null, null, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception> 
        public ArmClient(
            string defaultSubscriptionId,
            TokenCredential credential,
            ArmClientOptions options = default)
            : this(defaultSubscriptionId, null, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="baseUri"> The base URI of the Azure management endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(
            Uri baseUri,
            TokenCredential credential,
            ArmClientOptions options = default)
            : this(null, baseUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        private ArmClient(
            string defaultSubscriptionId,
            Uri baseUri,
            TokenCredential credential,
            ArmClientOptions options)
        {
            Credential = credential;
            BaseUri = baseUri;
            if (credential is null)
                throw new ArgumentNullException(nameof(credential));

            ClientOptions = options ?? new ArmClientOptions();
            DefaultSubscription = string.IsNullOrWhiteSpace(defaultSubscriptionId)
                ? GetDefaultSubscription()
                : GetSubscriptionOperations(defaultSubscriptionId).Get().Value;
            ClientOptions.ApiVersions.SetProviderClient(credential, baseUri, DefaultSubscription.Id.SubscriptionId);
        }

        /// <summary>
        /// Gets the default Azure subscription.
        /// </summary>
        public virtual Subscription DefaultSubscription { get; private set; }

        /// <summary>
        /// Gets the Azure Resource Manager client options.
        /// </summary>
        private ArmClientOptions ClientOptions;

        /// <summary>
        /// Gets the Azure credential.
        /// </summary>
        private TokenCredential Credential;

        /// <summary>
        /// Gets the base URI of the service.
        /// </summary>
        private Uri BaseUri;

        /// <summary>
        /// Gets the Azure subscription operations.
        /// </summary>
        /// <param name="subscriptionGuid"> The guid of the subscription. </param>
        /// <returns> Subscription operations. </returns>
        public virtual SubscriptionOperations GetSubscriptionOperations(string subscriptionGuid) => new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri), subscriptionGuid);

        /// <summary>
        /// Gets the Azure subscriptions.
        /// </summary>
        /// <returns> Subscription container. </returns>
        public virtual SubscriptionContainer GetSubscriptions()
        {
            return new SubscriptionContainer(new ClientContext(ClientOptions, Credential, BaseUri));
        }

        /// <summary>
        /// Gets resource group operations.
        /// </summary>
        /// <param name="subscriptionGuid"> The id of the Azure subscription. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <returns> Resource group operations. </returns>
        public virtual ResourceGroupOperations GetResourceGroupOperations(string subscriptionGuid, string resourceGroupName)
        {
            return GetSubscriptionOperations(subscriptionGuid).GetResourceGroupOperations(resourceGroupName);
        }

        /// <summary>
        /// Gets resource group operations.
        /// </summary>
        /// <param name="resourceGroupId"> The resource identifier of the resource group. </param>
        /// <returns> Resource group operations. </returns>
        public virtual ResourceGroupOperations GetResourceGroupOperations(ResourceGroupResourceIdentifier resourceGroupId)
        {
            return GetSubscriptionOperations(resourceGroupId.SubscriptionId).GetResourceGroupOperations(resourceGroupId.ResourceGroupName);
        }

        /// <summary>
        /// Gets resource operations base.
        /// </summary>
        /// <typeparam name="T"> The type of the underlying model this class wraps. </typeparam>
        /// <param name="subscription"> The id of the Azure subscription. </param>
        /// <param name="resourceGroup"> The resource group name. </param>
        /// <param name="name"> The resource type name. </param>
        /// <returns> Resource operations of the resource. </returns>
        public virtual T GetResourceOperations<T>(string subscription, string resourceGroup, string name)
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
            var sub = GetSubscriptions().List().FirstOrDefault();
            if (sub is null)
                throw new Exception("No subscriptions found for the given credentials");
            return sub;
        }
    }
}
