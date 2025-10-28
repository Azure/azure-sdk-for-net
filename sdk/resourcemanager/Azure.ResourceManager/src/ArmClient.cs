// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Microsoft.Extensions.Configuration;

namespace Azure.ResourceManager
{
    /// <summary>
    /// The entry point for all ARM clients.
    /// </summary>
    public partial class ArmClient
    {
        private TenantResource _tenant;
        private SubscriptionResource _defaultSubscription;
        private readonly ClientDiagnostics _subscriptionClientDiagnostics;
        private bool? _canUseTagResource;

        internal virtual Dictionary<ResourceType, string> ApiVersionOverrides { get; } = new Dictionary<ResourceType, string>();
        internal ConcurrentDictionary<string, Dictionary<string, string>> ResourceApiVersionCache { get; } = new ConcurrentDictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
        internal ConcurrentDictionary<string, string> NamespaceVersionCache { get; } = new ConcurrentDictionary<string, string>();

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
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public ArmClient(TokenCredential credential) : this(credential, default, default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, string defaultSubscriptionId) : this(credential, defaultSubscriptionId, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, string defaultSubscriptionId, ArmClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new ArmClientOptions();
            ArmEnvironment environment = options.Environment.HasValue ? options.Environment.Value : ArmEnvironment.AzurePublicCloud;

            Argument.AssertNotNull(environment.Endpoint, nameof(environment.Endpoint));

            Endpoint = environment.Endpoint;

            Pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, environment.DefaultScope));

            Diagnostics = options.Diagnostics;
            _subscriptionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager", SubscriptionResource.ResourceType.Namespace, Diagnostics);

            CopyApiVersionOverrides(options);

            _tenant = new TenantResource(this);
            _defaultSubscription = string.IsNullOrWhiteSpace(defaultSubscriptionId) ? null :
                new SubscriptionResource(this, SubscriptionResource.CreateResourceIdentifier(defaultSubscriptionId));
        }

        internal void RegisterConfigReload(IConfiguration configuration)
        {
            configuration.GetReloadToken().RegisterChangeCallback(state =>
            {
                var newDefaultSubscription = configuration["DefaultSubscriptionId"];
                _defaultSubscription = newDefaultSubscription is null
                    ? null
                    : new SubscriptionResource(this, SubscriptionResource.CreateResourceIdentifier(newDefaultSubscription));
            }, null);
        }

        internal virtual bool CanUseTagResource(CancellationToken cancellationToken = default)
        {
            if (_canUseTagResource == null)
            {
                var tagRp = GetDefaultSubscription(cancellationToken).GetResourceProvider(TagResource.ResourceType.Namespace, cancellationToken: cancellationToken);
                _canUseTagResource = tagRp.Value.Data.ResourceTypes.Any(rp => rp.ResourceType == TagResource.ResourceType.Type);
            }
            return _canUseTagResource.Value;
        }

        internal virtual async Task<bool> CanUseTagResourceAsync(CancellationToken cancellationToken = default)
        {
            if (_canUseTagResource == null)
            {
                var defaultSubscription = await GetDefaultSubscriptionAsync(cancellationToken).ConfigureAwait(false);
                var tagRp = await defaultSubscription.GetResourceProviderAsync(TagResource.ResourceType.Namespace, cancellationToken: cancellationToken).ConfigureAwait(false);
                _canUseTagResource = tagRp.Value.Data.ResourceTypes.Any(rp => rp.ResourceType == TagResource.ResourceType.Type);
            }
            return _canUseTagResource.Value;
        }

        private void CopyApiVersionOverrides(ArmClientOptions options)
        {
            foreach (var keyValuePair in options.ResourceApiVersionOverrides)
            {
                ApiVersionOverrides.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        /// <summary>
        /// Gets the api version override if it has been set for the current client options.
        /// </summary>
        /// <param name="resourceType"> The resource type to get the version for. </param>
        /// <param name="apiVersion"> The api version to variable to set. </param>
        internal virtual bool TryGetApiVersion(ResourceType resourceType, out string apiVersion)
        {
            return ApiVersionOverrides.TryGetValue(resourceType, out apiVersion);
        }

        /// <summary>
        /// Gets the diagnostic options used for this client.
        /// </summary>
        internal virtual DiagnosticsOptions Diagnostics { get; }

        /// <summary>
        /// Gets the base URI of the service.
        /// </summary>
        internal virtual Uri Endpoint { get; private set; }

        /// <summary>
        /// Gets the HTTP pipeline.
        /// </summary>
        internal virtual HttpPipeline Pipeline { get; private set; }

        /// <summary>
        /// Gets the Azure subscriptions.
        /// </summary>
        /// <returns> Subscription collection. </returns>
        public virtual SubscriptionCollection GetSubscriptions() => _tenant.GetSubscriptions();

        /// <summary>
        /// Gets the tenants.
        /// </summary>
        /// <returns> Tenant collection. </returns>
        public virtual TenantCollection GetTenants()
        {
            return new TenantCollection(this);
        }

        /// <summary>
        /// Gets the default subscription.
        /// </summary>
        /// <returns> Resource operations of the Subscription. </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual SubscriptionResource GetDefaultSubscription(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            using var scope = _subscriptionClientDiagnostics.CreateScope("ArmClient.GetDefaultSubscription");
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
        public virtual async Task<SubscriptionResource> GetDefaultSubscriptionAsync(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            using var scope = _subscriptionClientDiagnostics.CreateScope("ArmClient.GetDefaultSubscription");
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

        /// <summary> Gets a collection of GenericResources. </summary>
        /// <returns> An object representing collection of GenericResources and their operations. </returns>
        public virtual GenericResourceCollection GetGenericResources() => _tenant.GetGenericResources();

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> [This parameter is no longer supported.] The number of results to return. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Pageable<TenantResourceProvider> GetTenantResourceProviders(int? top, string expand, CancellationToken cancellationToken = default) => _tenant.GetTenantResourceProviders(expand, cancellationToken);

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> [This parameter is no longer supported.] The number of results to return. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual AsyncPageable<TenantResourceProvider> GetTenantResourceProvidersAsync(int? top, string expand, CancellationToken cancellationToken = default) => _tenant.GetTenantResourceProvidersAsync(expand, cancellationToken);

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<TenantResourceProvider> GetTenantResourceProviders(string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantResourceProviders(expand, cancellationToken);

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<TenantResourceProvider> GetTenantResourceProvidersAsync(string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantResourceProvidersAsync(expand, cancellationToken);

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<TenantResourceProvider> GetTenantResourceProvider(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default) => _tenant.GetTenantResourceProvider(resourceProviderNamespace, expand, cancellationToken);

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<TenantResourceProvider>> GetTenantResourceProviderAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default) => await _tenant.GetTenantResourceProviderAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the management group collection for this tenant.
        /// </summary>
        /// <returns> A collection of the management groups. </returns>
        public virtual ManagementGroupCollection GetManagementGroups() => _tenant.GetManagementGroups();

        /// <summary>
        /// Gets a client using this instance of ArmClient to copy the client settings from.
        /// </summary>
        /// <typeparam name="T"> The type of <see cref="ArmResource"/> that will be constructed. </typeparam>
        /// <param name="resourceFactory"> Delegate method that will construct the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual T GetResourceClient<T>(Func<T> resourceFactory)
            where T : ArmResource
        {
            return resourceFactory();
        }

        private readonly ConcurrentDictionary<Type, object> _clientCache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Gets a cached client to use for extension methods.
        /// </summary>
        /// <typeparam name="T"> The type of client to get. </typeparam>
        /// <param name="clientFactory"> The constructor factory for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual T GetCachedClient<T>(Func<ArmClient, T> clientFactory)
            where T : class
        {
            return _clientCache.GetOrAdd(typeof(T), (type) => { return clientFactory(this); }) as T;
        }
    }
}
