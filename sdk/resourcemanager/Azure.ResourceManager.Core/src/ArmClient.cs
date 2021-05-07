﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using Azure.Core;
using Azure.Core.Pipeline;

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
        public TenantOperations Tenant => _tenant ??= new TenantOperations(ClientOptions, Credential, BaseUri, Pipeline);

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
            : this(null, new Uri(DefaultUri), credential, options)
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
            : this(defaultSubscriptionId, new Uri(DefaultUri), credential, options)
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
            if (credential is null)
                throw new ArgumentNullException(nameof(credential));

            Credential = credential;
            BaseUri = baseUri ?? new Uri(DefaultUri);
            ClientOptions = options?.Clone() ?? new ArmClientOptions();
            Pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);

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
        /// Gets the HTTP pipeline.
        /// </summary>
        protected virtual HttpPipeline Pipeline { get; private set; }

        /// <summary>
        /// Gets the Azure subscriptions.
        /// </summary>
        /// <returns> Subscription container. </returns>
        public virtual SubscriptionContainer GetSubscriptions()
        {
            return new SubscriptionContainer(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline));
        }

        /// <summary>
        /// Gets a resource group operations object.
        /// </summary>
        /// <param name="id"> The id of the resourcegroup </param>
        /// <returns> Resource operations of the resource. </returns>
        public ResourceGroupOperations GetResourceGroupOperations(ResourceGroupResourceIdentifier id)
        {
            return new ResourceGroupOperations(new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id.SubscriptionId), id.ResourceGroupName);
        }

        private Subscription GetDefaultSubscription()
        {
            var sub = GetSubscriptions().List().FirstOrDefault();
            if (sub is null)
                throw new Exception("No subscriptions found for the given credentials");
            return sub;
        }

        /// <summary>
        /// Gets a container representing all resources as generic objects in the current tenant.
        /// </summary>
        /// <returns> GenericResource container. </returns>
        public GenericResourceOperations GetGenericResourcesOperations(TenantResourceIdentifier id)
        {
            return new GenericResourceOperations(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id);
        }
    }
}
