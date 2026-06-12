// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DataFactory.Models;

#pragma warning disable CS1591

namespace Azure.ResourceManager.DataFactory
{
    // MPG generator regression workaround. This partial restores pre-MPG
    // DataFactoryIntegrationRuntimeResource API surface the regenerated class no longer emits:
    //   1. Back-compat string ifNoneMatch overloads ([EditorBrowsable(Never)]) that delegate to the
    //      ETag-based generated methods.
    //   2. The public Query convenience methods (GetAllIntegrationRuntimeObjectMetadata,
    //      GetOutboundNetworkDependencies) plus their *Internal helpers and result wrappers: the
    //      generator now emits only the REST request-builders, so the helpers send the message through
    //      the shared pipeline and deserialize the JSON payload into the existing model types.
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

        internal sealed class IntegrationRuntimeObjectMetadataResult
        {
            public IReadOnlyList<SsisObjectMetadata> Value { get; set; }
        }

        internal sealed class IntegrationRuntimeOutboundNetworkDependenciesResult
        {
            public IReadOnlyList<IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> Value { get; set; }
        }

        private static RequestContext BuildContext(CancellationToken cancellationToken)
        {
            return new RequestContext { CancellationToken = cancellationToken };
        }

        private static List<T> ReadArrayProperty<T>(JsonElement parent, string propName, Func<JsonElement, T> reader)
        {
            var list = new List<T>();
            if (parent.TryGetProperty(propName, out var arr) && arr.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in arr.EnumerateArray())
                {
                    list.Add(reader(item));
                }
            }
            return list;
        }

        internal Response<IntegrationRuntimeObjectMetadataResult> GetAllIntegrationRuntimeObjectMetadataInternal(GetSsisObjectMetadataContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            RequestContent requestContent = content != null ? GetSsisObjectMetadataContent.ToRequestContent(content) : null;
            using HttpMessage message = _integrationRuntimeObjectMetadataRestClient.CreateGetAllIntegrationRuntimeObjectMetadataRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, requestContent, context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            using JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
            var list = ReadArrayProperty(doc.RootElement, "value", el => SsisObjectMetadata.DeserializeSsisObjectMetadata(el, ModelSerializationExtensions.WireOptions));
            return Response.FromValue(new IntegrationRuntimeObjectMetadataResult { Value = list }, response);
        }

        internal async Task<Response<IntegrationRuntimeObjectMetadataResult>> GetAllIntegrationRuntimeObjectMetadataInternalAsync(GetSsisObjectMetadataContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            RequestContent requestContent = content != null ? GetSsisObjectMetadataContent.ToRequestContent(content) : null;
            using HttpMessage message = _integrationRuntimeObjectMetadataRestClient.CreateGetAllIntegrationRuntimeObjectMetadataRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, requestContent, context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            using JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
            var list = ReadArrayProperty(doc.RootElement, "value", el => SsisObjectMetadata.DeserializeSsisObjectMetadata(el, ModelSerializationExtensions.WireOptions));
            return Response.FromValue(new IntegrationRuntimeObjectMetadataResult { Value = list }, response);
        }

        internal Response<IntegrationRuntimeOutboundNetworkDependenciesResult> GetOutboundNetworkDependenciesInternal(CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _integrationRuntimesRestClient.CreateGetOutboundNetworkDependenciesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            using JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
            var list = ReadArrayProperty(doc.RootElement, "value", el => IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint.DeserializeIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint(el, ModelSerializationExtensions.WireOptions));
            return Response.FromValue(new IntegrationRuntimeOutboundNetworkDependenciesResult { Value = list }, response);
        }

        internal async Task<Response<IntegrationRuntimeOutboundNetworkDependenciesResult>> GetOutboundNetworkDependenciesInternalAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _integrationRuntimesRestClient.CreateGetOutboundNetworkDependenciesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            using JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
            var list = ReadArrayProperty(doc.RootElement, "value", el => IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint.DeserializeIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint(el, ModelSerializationExtensions.WireOptions));
            return Response.FromValue(new IntegrationRuntimeOutboundNetworkDependenciesResult { Value = list }, response);
        }
    }
}
