// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG generator regression workaround: the regenerated DataFactoryIntegrationRuntimeResource
// class no longer emits the public Query convenience methods
// (GetAllIntegrationRuntimeObjectMetadata, GetOutboundNetworkDependencies). This file
// re-implements the `*Internal` helper methods consumed by the customizations in
// DataFactoryIntegrationRuntimeResource.cs by sending the REST message through the shared
// HTTP pipeline and manually deserializing the JSON payload.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryIntegrationRuntimeResource
    {
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
