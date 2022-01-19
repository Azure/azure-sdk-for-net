// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public class Tenant : ArmResource
    {
        private readonly ProviderRestOperations _providerRestOperations;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TenantData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class for mocking.
        /// </summary>
        protected Tenant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="tenantData"> The data model representing the generic azure resource. </param>
        internal Tenant(ArmResource operations, TenantData tenantData)
            : base(operations, ResourceIdentifier.Root)
        {
            _data = tenantData;
            HasData = true;
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Provider.ResourceType, out var version);
            _providerRestOperations = new ProviderRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, Guid.Empty.ToString(), BaseUri, version);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal Tenant(ArmClient armClient)
            : base(armClient, ResourceIdentifier.Root)
        {
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Provider.ResourceType, out var version);
            _providerRestOperations = new ProviderRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, Guid.Empty.ToString(), BaseUri, version);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary>
        /// The resource type for subscription
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/tenants";

        /// <summary>
        /// Gets whether or not the current instance has data.
        /// </summary>
        public bool HasData { get; }

        /// <summary>
        /// Gets the tenant data model.
        /// </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual TenantData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data you must call Get first");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
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
            return func(BaseUri, ArmClient.Credential, ClientOptions, Pipeline);
        }

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ProviderInfo> GetTenantProviders(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<ProviderInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("Tenant.GetTenantProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = _providerRestOperations.ListAtTenantScope(top, expand, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ProviderInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("Tenant.GetTenantProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = _providerRestOperations.ListAtTenantScopeNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ProviderInfo> GetTenantProvidersAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ProviderInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("Tenant.GetTenantProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = await _providerRestOperations.ListAtTenantScopeAsync(top, expand, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ProviderInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("Tenant.GetTenantProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = await _providerRestOperations.ListAtTenantScopeNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<ProviderInfo> GetTenantProvider(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Tenant.GetTenantProvider");
            scope.Start();

            try
            {
                return _providerRestOperations.GetAtTenantScope(resourceProviderNamespace, expand, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual async Task<Response<ProviderInfo>> GetTenantProviderAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Tenant.GetTenantProvider");
            scope.Start();

            try
            {
                return await _providerRestOperations.GetAtTenantScopeAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the management group collection for this tenant.
        /// </summary>
        /// <returns> A collection of the management groups. </returns>
        public virtual ManagementGroupCollection GetManagementGroups()
        {
            return new ManagementGroupCollection(this);
        }

        /// <summary>
        /// Gets the managmeent group operations object associated with the id.
        /// </summary>
        /// <param name="id"> The id of the management group operations. </param>
        /// <returns> A client to perform operations on the management group. </returns>
        internal ManagementGroup GetManagementGroup(ResourceIdentifier id)
        {
            ManagementGroup.ValidateResourceId(id);
            return new ManagementGroup(this, id);
        }

        /// <summary>
        /// Gets the subscription collection for this tenant.
        /// </summary>
        /// <returns> A collection of the subscriptions. </returns>
        public virtual SubscriptionCollection GetSubscriptions()
        {
            return new SubscriptionCollection(this);
        }
    }
}
