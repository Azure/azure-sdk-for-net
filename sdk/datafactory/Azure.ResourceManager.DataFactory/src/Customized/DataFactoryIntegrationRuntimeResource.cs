// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.DataFactory.Models;

#pragma warning disable CS1591

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryIntegrationRuntimeResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryIntegrationRuntimeResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryIntegrationRuntimeResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Get a SSIS integration runtime object metadata. </summary>
        /// <param name="content"> The parameters for getting a SSIS object metadata. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls(true)]
        public virtual Pageable<SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadata(GetSsisObjectMetadataContent content = null, CancellationToken cancellationToken = default)
        {
            var response = GetAllIntegrationRuntimeObjectMetadataInternal(content, cancellationToken);
            return new SinglePagePageable<SsisObjectMetadata>(System.Linq.Enumerable.ToList(response.Value.Value), response.GetRawResponse());
        }

        /// <summary> Get a SSIS integration runtime object metadata. </summary>
        /// <param name="content"> The parameters for getting a SSIS object metadata. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadataAsync(GetSsisObjectMetadataContent content = null, CancellationToken cancellationToken = default)
        {
            return new InternalAllIntegrationRuntimeObjectMetadataAsyncPageable(this, content, cancellationToken);
        }

        private sealed class InternalAllIntegrationRuntimeObjectMetadataAsyncPageable : AsyncPageable<SsisObjectMetadata>
        {
            private readonly DataFactoryIntegrationRuntimeResource _parent;
            private readonly GetSsisObjectMetadataContent _content;
            private readonly CancellationToken _cancellationToken;
            public InternalAllIntegrationRuntimeObjectMetadataAsyncPageable(DataFactoryIntegrationRuntimeResource parent, GetSsisObjectMetadataContent content, CancellationToken cancellationToken)
            {
                _parent = parent;
                _content = content;
                _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<SsisObjectMetadata>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetAllIntegrationRuntimeObjectMetadataInternalAsync(_content, _cancellationToken).ConfigureAwait(false);
                yield return Page<SsisObjectMetadata>.FromValues(System.Linq.Enumerable.ToList(response.Value.Value), null, response.GetRawResponse());
            }
        }

        /// <summary> Gets the list of outbound network dependencies for a given Azure-SSIS integration runtime. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls(true)]
        public virtual Pageable<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependencies(CancellationToken cancellationToken = default)
        {
            var response = GetOutboundNetworkDependenciesInternal(cancellationToken);
            return new SinglePagePageable<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint>(System.Linq.Enumerable.ToList(response.Value.Value), response.GetRawResponse());
        }

        /// <summary> Gets the list of outbound network dependencies for a given Azure-SSIS integration runtime. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesAsync(CancellationToken cancellationToken = default)
        {
            return new InternalOutboundNetworkDependenciesAsyncPageable(this, cancellationToken);
        }

        private sealed class InternalOutboundNetworkDependenciesAsyncPageable : AsyncPageable<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint>
        {
            private readonly DataFactoryIntegrationRuntimeResource _parent;
            private readonly CancellationToken _cancellationToken;
            public InternalOutboundNetworkDependenciesAsyncPageable(DataFactoryIntegrationRuntimeResource parent, CancellationToken cancellationToken)
            {
                _parent = parent;
                _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetOutboundNetworkDependenciesInternalAsync(_cancellationToken).ConfigureAwait(false);
                yield return Page<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint>.FromValues(System.Linq.Enumerable.ToList(response.Value.Value), null, response.GetRawResponse());
            }
        }
    }
}
