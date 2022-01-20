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
    public partial class ArmClient
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
                new Subscription(ClientOptions, Credential, BaseUri, Pipeline, ResourceIdentifier.Root.AppendChildResource(Subscription.ResourceType.Type, defaultSubscriptionId));
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

        /// <summary> Gets a collection of GenericResources. </summary>
        /// <returns> An object representing collection of GenericResources and their operations. </returns>
        public virtual GenericResourceCollection GetGenericResources() => _tenant.GetGenericResources();

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<ProviderData> GetTenantProviders(int? top = null, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantProviders(top, expand, cancellationToken);

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ProviderData> GetTenantProvidersAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantProvidersAsync(top, expand, cancellationToken);

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ProviderData> GetTenantProvider(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantProvider(resourceProviderNamespace, expand, cancellationToken);

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ProviderData>> GetTenantProviderAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default) => await _tenant.GetTenantProviderAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the management group collection for this tenant.
        /// </summary>
        /// <returns> A collection of the management groups. </returns>
        public virtual ManagementGroupCollection GetManagementGroups() => _tenant.GetManagementGroups();
    }
}
