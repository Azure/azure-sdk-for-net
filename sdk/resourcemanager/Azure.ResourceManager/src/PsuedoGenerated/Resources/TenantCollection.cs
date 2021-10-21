// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of Tenant and their operations over their parent.
    /// </summary>
    public class TenantCollection : ArmCollection, IEnumerable<Tenant>, IAsyncEnumerable<Tenant>
    {
        private ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantCollection"/> class for mocking.
        /// </summary>
        protected TenantCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantCollection"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        internal TenantCollection(ClientContext clientContext)
            : base(clientContext)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        private TenantsRestOperations RestClient => new TenantsRestOperations(Diagnostics, Pipeline, ClientOptions, BaseUri);

        private ClientDiagnostics Diagnostics => _clientDiagnostics ??= new ClientDiagnostics(ClientOptions);

        /// <summary> Gets the tenants for your account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Tenant> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Tenant>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new Tenant(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Tenant>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new Tenant(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the tenants for your account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Tenant> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Tenant> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = RestClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new Tenant(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Tenant> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new Tenant(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Iterates through all Tenant.
        /// </summary>
        public IEnumerator<Tenant> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <summary>
        /// Iterates through all Tenant.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public IAsyncEnumerator<Tenant> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
