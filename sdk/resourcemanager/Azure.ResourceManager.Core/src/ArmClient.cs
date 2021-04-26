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

            ClientOptions = options?.Clone() ?? new ArmClientOptions();
            DefaultSubscription = string.IsNullOrWhiteSpace(defaultSubscriptionId)
                ? GetDefaultSubscription()
                : GetSubscriptions().TryGet(defaultSubscriptionId);
            ClientOptions.ApiVersions.SetProviderClient(credential, baseUri, DefaultSubscription.Id.SubscriptionId);
        }

        /// <summary>
        /// Gets the default Azure subscription.
        /// </summary>
        public virtual Subscription DefaultSubscription { get; private set; }

        /// <summary>
        /// Gets the Azure Resource Manager client options.
        /// </summary>
        protected virtual ArmClientOptions ClientOptions { get; private set; }

        /// <summary>
        /// Gets the Azure credential.
        /// </summary>
        protected virtual TokenCredential Credential { get; private set; }

        /// <summary>
        /// Gets the base URI of the service.
        /// </summary>
        protected virtual Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets the Azure subscriptions.
        /// </summary>
        /// <returns> Subscription container. </returns>
        public virtual SubscriptionContainer GetSubscriptions()
        {
            return new SubscriptionContainer(new ClientContext(ClientOptions, Credential, BaseUri));
        }

        /// <summary>
        /// Gets a resource group operations object.
        /// </summary>
        /// <param name="id"> The id of the resourcegroup </param>
        /// <returns> Resource operations of the resource. </returns>
        public ResourceGroupOperations GetResourceGroupOperations(ResourceGroupResourceIdentifier id)
        {
            return new ResourceGroupOperations(new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri), id.SubscriptionId), id.ResourceGroupName);
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
            var subOp = new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri), subscription);
            var rgOp = subOp.GetResourceGroups().Get(resourceGroup);
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
