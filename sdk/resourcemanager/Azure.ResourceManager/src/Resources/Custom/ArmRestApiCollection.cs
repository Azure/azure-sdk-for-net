// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class which represents the RestApis for a given azure namespace.
    /// </summary>
    public partial class ArmRestApiCollection : ArmCollection, IEnumerable<ArmRestApi>, IAsyncEnumerable<ArmRestApi>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _nameSpace;
        private readonly ResourceProviderCollection _providerCollection;

        /// <summary> Represents the REST operations. </summary>
        private RestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="ArmRestApiCollection"/> class for mocking. </summary>
        protected ArmRestApiCollection()
        {
        }

        /// <summary> Initializes a new instance of RestApiCollection class. </summary>
        /// <param name="operation"> The resource representing the parent resource. </param>
        /// <param name="nameSpace"> The namespace for the rest apis. </param>
        internal ArmRestApiCollection(ArmResource operation, string nameSpace)
            : base(operation.Client, operation.Id)
        {
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", nameSpace, Diagnostics);
            _nameSpace = nameSpace;
            _providerCollection = new ResourceProviderCollection(Client.GetSubscriptionResource(Id));
        }

        private RestOperations GetRestClient(CancellationToken cancellationToken = default)
        {
            return _restClient ??= new RestOperations(
                _nameSpace,
                _providerCollection.GetApiVersion(new ResourceType($"{_nameSpace}/operations"), cancellationToken),
                _clientDiagnostics,
                Pipeline,
                Diagnostics.ApplicationId,
                Endpoint);
        }

        private async Task<RestOperations> GetRestClientAsync(CancellationToken cancellationToken = default)
        {
            return _restClient ??= new RestOperations(
                _nameSpace,
                await _providerCollection.GetApiVersionAsync(new ResourceType($"{_nameSpace}/operations"), cancellationToken).ConfigureAwait(false),
                _clientDiagnostics,
                Pipeline,
                Diagnostics.ApplicationId,
                Endpoint);
        }

        /// <summary> Gets a list of operations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ArmRestApi" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ArmRestApi> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ArmRestApi> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ArmRestApiCollection.GetAll");
                scope.Start();
                try
                {
                    var response = GetRestClient().List(cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Gets a list of operations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ArmRestApi" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ArmRestApi> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ArmRestApi>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ArmRestApiCollection.GetAll");
                scope.Start();
                try
                {
                    var restClient = await GetRestClientAsync().ConfigureAwait(false);
                    var response = await restClient.ListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<ArmRestApi> IEnumerable<ArmRestApi>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ArmRestApi> IAsyncEnumerable<ArmRestApi>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
