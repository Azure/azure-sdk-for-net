﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of Tenant and their operations over their parent.
    /// </summary>
    public class TenantContainer : ContainerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantContainer"/> class for mocking.
        /// </summary>
        protected TenantContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantContainer"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        internal TenantContainer(ClientContext clientContext)
            : base(clientContext)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        private TenantsRestOperations RestClient => new TenantsRestOperations(Diagnostics, Pipeline, BaseUri);

        /// <summary> Gets the tenants for your account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Tenant> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Tenant>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantContainer.List");
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
                using var scope = Diagnostics.CreateScope("TenantContainer.List");
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
        public virtual Pageable<Tenant> List(CancellationToken cancellationToken = default)
        {
            Page<Tenant> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantContainer.List");
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
                using var scope = Diagnostics.CreateScope("TenantContainer.List");
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
    }
}
