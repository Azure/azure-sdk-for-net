// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager
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
        private Tenant _tenant;

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
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential)
            : this(null, new Uri(DefaultUri), credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, ArmClientOptions options)
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
        public ArmClient(
            string defaultSubscriptionId,
            Uri baseUri,
            TokenCredential credential,
            ArmClientOptions options = default)
        {
            if (credential is null)
                throw new ArgumentNullException(nameof(credential));

            Credential = credential;
            BaseUri = baseUri ?? new Uri(DefaultUri);
            options ??= new ArmClientOptions();
            if (options.Diagnostics.IsTelemetryEnabled)
                options.AddPolicy(new MgmtTelemetryPolicy(this, options), HttpPipelinePosition.PerRetry);
            Pipeline = ManagementPipelineBuilder.Build(Credential, options.Scope, options);

            ClientOptions = options.Clone();

            _tenant = new Tenant(ClientOptions, Credential, BaseUri, Pipeline);
            _defaultSubscription = string.IsNullOrWhiteSpace(defaultSubscriptionId) ? null :
                new Subscription(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), ResourceIdentifier.Root.AppendChildResource(Subscription.ResourceType.Type, defaultSubscriptionId));
            ClientOptions.ApiVersions.SetProviderClient(this);
        }

        private Subscription _defaultSubscription;

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
        /// <returns> Subscription collection. </returns>
        public virtual SubscriptionCollection GetSubscriptions()  => _tenant.GetSubscriptions();

        /// <summary>
        /// Gets the tenants.
        /// </summary>
        /// <returns> Tenant collection. </returns>
        public virtual TenantCollection GetTenants()
        {
            return new TenantCollection(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline));
        }

        /// <summary>
        /// Gets a resource group operations object.
        /// </summary>
        /// <param name="id"> The id of the resourcegroup. </param>
        /// <returns> Resource operations of the resourcegroup. </returns>
        public virtual ResourceGroup GetResourceGroup(ResourceIdentifier id)
        {
            return new ResourceGroup(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id);
        }

        /// <summary>
        /// Gets a subscription operations object.
        /// </summary>
        /// <param name="id"> The id of the subscription. </param>
        /// <returns> Resource operations of the subscription. </returns>
        public virtual Subscription GetSubscription(ResourceIdentifier id)
        {
            return new Subscription(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id);
        }

        /// <summary>
        /// Gets a feature operations object.
        /// </summary>
        /// <param name="id"> The id of the feature. </param>
        /// <returns> Resource operations of the feature. </returns>
        public virtual Feature GetFeature(ResourceIdentifier id)
        {
            return new Feature(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id);
        }

        /// <summary>
        /// Gets a Provider operations object.
        /// </summary>
        /// <param name="id"> The id of the Provider. </param>
        /// <returns> Resource operations of the Provider. </returns>
        public virtual Provider GetProvider(ResourceIdentifier id)
        {
            return new Provider(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id);
        }

        /// <summary>
        /// Gets a PredefinedTag operations object.
        /// </summary>
        /// <param name="id"> The id of the PredefinedTag. </param>
        /// <returns> Resource operations of the PredefinedTag. </returns>
        public virtual PredefinedTag GetPreDefinedTag(ResourceIdentifier id)
        {
            return new PredefinedTag(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), id);
        }

        /// <summary>
        /// Gets the default subscription.
        /// </summary>
        /// <returns> Resource operations of the Subscription. </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Subscription GetDefaultSubscription(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            using var scope = new ClientDiagnostics(ClientOptions).CreateScope("ArmClient.GetDefaultSubscription");
            scope.Start();
            try
            {
                if (_defaultSubscription == null)
                {
                    _defaultSubscription = GetSubscriptions().GetAll(cancellationToken).FirstOrDefault();
                }
                else if (_defaultSubscription.HasData)
                {
                    return _defaultSubscription;
                }
                else
                {
                    _defaultSubscription = _defaultSubscription.Get(cancellationToken);
                }
                if (_defaultSubscription is null)
                {
                    throw new InvalidOperationException("No subscriptions found for the given credentials");
                }
                return _defaultSubscription;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the default subscription.
        /// </summary>
        /// <returns> Resource operations of the Subscription. </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Subscription> GetDefaultSubscriptionAsync(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            using var scope = new ClientDiagnostics(ClientOptions).CreateScope("ArmClient.GetDefaultSubscription");
            scope.Start();
            try
            {
                if (_defaultSubscription == null)
                {
                    _defaultSubscription = await GetSubscriptions().GetAllAsync(cancellationToken).FirstOrDefaultAsync(_ => true, cancellationToken).ConfigureAwait(false);
                }
                else if (_defaultSubscription.HasData)
                {
                    return _defaultSubscription;
                }
                else
                {
                    _defaultSubscription = await _defaultSubscription.GetAsync(cancellationToken).ConfigureAwait(false);
                }
                if (_defaultSubscription is null)
                {
                    throw new InvalidOperationException("No subscriptions found for the given credentials");
                }
                return _defaultSubscription;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Provides a way to reuse the protected client context.
        /// </summary>
        /// <typeparam name="T"> The actual type returned by the delegate. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns> Whatever the delegate returns. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary>
        /// Get the operations for a list of specific resources.
        /// </summary>
        /// <param name="ids"> A list of the IDs of the resources to retrieve. </param>
        /// <returns> The list of operations that can be performed over the GenericResources. </returns>
        public virtual IReadOnlyList<GenericResource> GetGenericResources(params ResourceIdentifier[] ids)
        {
            return GetGenericResourceOperationsInternal(ids);
        }

        /// <summary>
        /// Get the operations for a list of specific resources.
        /// </summary>
        /// <param name="ids"> A list of the IDs of the resources to retrieve. </param>
        /// <returns> The list of operations that can be performed over the GenericResources. </returns>
        public virtual IReadOnlyList<GenericResource> GetGenericResources(IEnumerable<ResourceIdentifier> ids)
        {
            return GetGenericResourceOperationsInternal(ids);
        }

        /// <summary>
        /// Get the operations for a list of specific resources.
        /// </summary>
        /// <param name="ids"> A list of the IDs of the resources to retrieve. </param>
        /// <returns> The list of operations that can be performed over the GenericResources. </returns>
        public virtual IReadOnlyList<GenericResource> GetGenericResources(params string[] ids)
        {
            return GetGenericResourceOperationsInternal(ids.Select(id => new ResourceIdentifier(id)));
        }

        /// <summary>
        /// Get the operations for a list of specific resources.
        /// </summary>
        /// <param name="ids"> A list of the IDs of the resources to retrieve. </param>
        /// <returns> The list of operations that can be performed over the GenericResources. </returns>
        public virtual IReadOnlyList<GenericResource> GetGenericResources(IEnumerable<string> ids)
        {
            return GetGenericResourceOperationsInternal(ids.Select(id => new ResourceIdentifier(id)));
        }

        private IReadOnlyList<GenericResource> GetGenericResourceOperationsInternal(IEnumerable<ResourceIdentifier> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var genericResourceOperations = new ChangeTrackingList<GenericResource>();
            foreach (string id in ids)
            {
                genericResourceOperations.Add(new GenericResource(GetDefaultSubscription(), new ResourceIdentifier(id)));
            }
            return genericResourceOperations;
        }

        /// <summary>
        /// Get the operations for an specific resource.
        /// </summary>
        /// <param name="id"> The id of the resource to retrieve. </param>
        /// <returns> The operations that can be performed over a specific GenericResource. </returns>
        public virtual GenericResource GetGenericResource(ResourceIdentifier id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return new GenericResource(GetDefaultSubscription(), id);
        }

        /// <summary>
        /// Gets the RestApi definition for a given Azure namespace.
        /// </summary>
        /// <param name="azureNamespace"> The namespace to get the rest API for. </param>
        /// <returns> A collection representing the rest apis for the namespace. </returns>
        public virtual RestApiCollection GetRestApis(string azureNamespace)
        {
            return new RestApiCollection(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), azureNamespace);
        }

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<ProviderInfo> GetTenantProviders(int? top = null, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantProviders(top, expand, cancellationToken);

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ProviderInfo> GetTenantProvidersAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantProvidersAsync(top, expand, cancellationToken);

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ProviderInfo> GetTenantProvider(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantProvider(resourceProviderNamespace, expand, cancellationToken);

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ProviderInfo>> GetTenantProviderAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default) => await _tenant.GetTenantProviderAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the management group collection for this tenant.
        /// </summary>
        /// <returns> A collection of the management groups. </returns>
        public virtual ManagementGroupCollection GetManagementGroups() => _tenant.GetManagementGroups();

        /// <summary>
        /// Gets the management group operations object associated with the id.
        /// </summary>
        /// <param name="id"> The id of the management group operations. </param>
        /// <returns> A client to perform operations on the management group. </returns>
        public virtual ManagementGroup GetManagementGroup(ResourceIdentifier id) => _tenant.GetManagementGroup(id);
    }
}
