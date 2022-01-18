// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of Tenant and their operations over their parent.
    /// </summary>
    public class TenantCollection : ArmCollection, IEnumerable<Tenant>, IAsyncEnumerable<Tenant>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TenantsRestOperations _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantCollection"/> class for mocking.
        /// </summary>
        protected TenantCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantCollection"/> class.
        /// </summary>
        /// <param name="client"></param>
        internal TenantCollection(ArmClient client)
            : base(client)
        {
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", Tenant.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Tenant.ResourceType, out var version);
            _restClient = new TenantsRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, version);
        }

        /// <summary> Gets the tenants for your account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Tenant> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Tenant>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(cancellationToken).ConfigureAwait(false);
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
                using var scope = _clientDiagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
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
                using var scope = _clientDiagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.List(cancellationToken);
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
                using var scope = _clientDiagnostics.CreateScope("TenantCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.ListNextPage(nextLink, cancellationToken);
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

        IEnumerator<Tenant> IEnumerable<Tenant>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Tenant> IAsyncEnumerable<Tenant>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
