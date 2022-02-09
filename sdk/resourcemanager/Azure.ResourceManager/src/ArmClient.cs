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
        private static readonly Uri _defaultUri = new Uri("https://management.azure.com");
        private Tenant _tenant;
        private Subscription _defaultSubscription;
        private readonly ClientDiagnostics _subscriptionClientDiagnostics;

        private Dictionary<ResourceType, string> ApiVersionOverrides { get; } = new Dictionary<ResourceType, string>();

        internal ConcurrentDictionary<string, Dictionary<string, string>> ResourceApiVersionCache { get; } = new ConcurrentDictionary<string, Dictionary<string, string>>();
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
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, ArmClientOptions options = default) : this(credential, null, _defaultUri, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, string defaultSubscriptionId, ArmClientOptions options = default) : this(credential, defaultSubscriptionId, _defaultUri, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClient"/> class.
        /// </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="defaultSubscriptionId"> The id of the default Azure subscription. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="TokenCredential"/> is null. </exception>
        public ArmClient(TokenCredential credential, string defaultSubscriptionId, Uri baseUri, ArmClientOptions options = default)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(baseUri, nameof(baseUri));

            BaseUri = baseUri;
            options ??= new ArmClientOptions();

            if (options.Diagnostics.IsTelemetryEnabled)
            {
                Pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, options.Scope), new MgmtTelemetryPolicy(this, options));
            }
            else
            {
                Pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, options.Scope));
            }

            DiagnosticOptions = options.Diagnostics;
            _subscriptionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager", Subscription.ResourceType.Namespace, DiagnosticOptions);

            CopyApiVersionOverrides(options);

            _tenant = new Tenant(this);
            _defaultSubscription = string.IsNullOrWhiteSpace(defaultSubscriptionId) ? null :
                new Subscription(this, Subscription.CreateResourceIdentifier(defaultSubscriptionId));
        }

        private void CopyApiVersionOverrides(ArmClientOptions options)
        {
            foreach (var keyValuePair in options.ResourceApiVersionOverrides)
            {
                ApiVersionOverrides.Add(keyValuePair.Key, keyValuePair.Value);
                if (!ResourceApiVersionCache.TryGetValue(keyValuePair.Key.Namespace, out var apiVersionCache))
                {
                    apiVersionCache = new Dictionary<string, string>();
                    ResourceApiVersionCache.TryAdd(keyValuePair.Key.Namespace, apiVersionCache);
                }
                apiVersionCache.Add(keyValuePair.Key.Type, keyValuePair.Value);
            }
        }

        /// <summary>
        /// Gets the api version override if it has been set for the current client options.
        /// </summary>
        /// <param name="resourceType"> The resource type to get the version for. </param>
        /// <param name="apiVersion"> The api version to variable to set. </param>
        public bool TryGetApiVersion(ResourceType resourceType, out string apiVersion)
        {
            return ApiVersionOverrides.TryGetValue(resourceType, out apiVersion);
        }

        /// <summary>
        /// Gets the diagnostic options used for this client.
        /// </summary>
        internal virtual DiagnosticsOptions DiagnosticOptions { get; }

        /// <summary>
        /// Gets the base URI of the service.
        /// </summary>
        internal virtual Uri BaseUri { get; private set; }

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
        public virtual Subscription GetDefaultSubscription(CancellationToken cancellationToken = default)
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
        public virtual async Task<Subscription> GetDefaultSubscriptionAsync(CancellationToken cancellationToken = default)
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
        /// Gets a client using this instance of ArmClient to copy the client settings from.
        /// </summary>
        /// <typeparam name="T"> The type of <see cref="ArmResource"/> that will be constructed. </typeparam>
        /// <param name="ctor"> Delegate method that will construct the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual T GetClient<T>(Func<T> ctor)
            where T : ArmResource
        {
            return ctor();
        }
    }
}
