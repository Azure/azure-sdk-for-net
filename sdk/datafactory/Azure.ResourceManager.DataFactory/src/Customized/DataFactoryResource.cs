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

namespace Azure.ResourceManager.DataFactory
{
    // This partial restores pre-MPG DataFactoryResource API surface:
    //   1. Back-compat string ifNoneMatch overloads ([EditorBrowsable(Never)]) that delegate to the
    //      ETag-based generated methods.
    //   2. GetTriggers/GetTriggersAsync (see the comment on those members). The remaining query
    //      operations are generated directly as Pageable<T> via @@Legacy.markAsPageable in client.tsp.
    public partial class DataFactoryResource
    {
        /// <summary> Gets a factory. </summary>
        /// <param name="ifNoneMatch"> ETag of the factory entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a factory. </summary>
        /// <param name="ifNoneMatch"> ETag of the factory entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a trigger. </summary>
        /// <param name="triggerName"> The trigger name. </param>
        /// <param name="ifNoneMatch"> ETag of the trigger entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryTriggerResource>> GetDataFactoryTriggerAsync(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryTriggerAsync(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a trigger. </summary>
        /// <param name="triggerName"> The trigger name. </param>
        /// <param name="ifNoneMatch"> ETag of the trigger entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryTriggerResource> GetDataFactoryTrigger(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryTrigger(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a integration runtime. </summary>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="ifNoneMatch"> ETag of the integration runtime entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryIntegrationRuntimeResource>> GetDataFactoryIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryIntegrationRuntimeAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a integration runtime. </summary>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="ifNoneMatch"> ETag of the integration runtime entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryIntegrationRuntimeResource> GetDataFactoryIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryIntegrationRuntime(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a linked service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linked service entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryLinkedServiceResource>> GetDataFactoryLinkedServiceAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryLinkedServiceAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a linked service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linked service entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryLinkedServiceResource> GetDataFactoryLinkedService(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryLinkedService(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a dataset. </summary>
        /// <param name="datasetName"> The dataset name. </param>
        /// <param name="ifNoneMatch"> ETag of the dataset entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDatasetResource>> GetDataFactoryDatasetAsync(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDatasetAsync(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a dataset. </summary>
        /// <param name="datasetName"> The dataset name. </param>
        /// <param name="ifNoneMatch"> ETag of the dataset entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDatasetResource> GetDataFactoryDataset(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataset(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="ifNoneMatch"> ETag of the pipeline entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPipelineResource>> GetDataFactoryPipelineAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPipelineAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="ifNoneMatch"> ETag of the pipeline entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPipelineResource> GetDataFactoryPipeline(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPipeline(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a data flow. </summary>
        /// <param name="dataFlowName"> The data flow name. </param>
        /// <param name="ifNoneMatch"> ETag of the data flow entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDataFlowResource>> GetDataFactoryDataFlowAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDataFlowAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a data flow. </summary>
        /// <param name="dataFlowName"> The data flow name. </param>
        /// <param name="ifNoneMatch"> ETag of the data flow entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDataFlowResource> GetDataFactoryDataFlow(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataFlow(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a managed virtual network. </summary>
        /// <param name="managedVirtualNetworkName"> The managed virtual network name. </param>
        /// <param name="ifNoneMatch"> ETag of the managed virtual network entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedVirtualNetworkResource>> GetDataFactoryManagedVirtualNetworkAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryManagedVirtualNetworkAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a managed virtual network. </summary>
        /// <param name="managedVirtualNetworkName"> The managed virtual network name. </param>
        /// <param name="ifNoneMatch"> ETag of the managed virtual network entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedVirtualNetworkResource> GetDataFactoryManagedVirtualNetwork(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryManagedVirtualNetwork(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> The credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryServiceCredentialResource>> GetDataFactoryServiceCredentialAsync(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryServiceCredentialAsync(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> The credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryServiceCredentialResource> GetDataFactoryServiceCredential(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryServiceCredential(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointConnectionResource>> GetDataFactoryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPrivateEndpointConnectionAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointConnectionResource> GetDataFactoryPrivateEndpointConnection(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPrivateEndpointConnection(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a change data capture. </summary>
        /// <param name="changeDataCaptureName"> The change data capture name. </param>
        /// <param name="ifNoneMatch"> ETag of the change data capture entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryChangeDataCaptureResource>> GetDataFactoryChangeDataCaptureAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryChangeDataCaptureAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a change data capture. </summary>
        /// <param name="changeDataCaptureName"> The change data capture name. </param>
        /// <param name="ifNoneMatch"> ETag of the change data capture entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryChangeDataCaptureResource> GetDataFactoryChangeDataCapture(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryChangeDataCapture(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a collection of DataFactoryManagedIdentityCredentials in the DataFactoryResource. </summary>
        /// <returns> An object representing collection of DataFactoryManagedIdentityCredentials and their operations over a DataFactoryManagedIdentityCredentialResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataFactoryManagedIdentityCredentialCollection GetDataFactoryManagedIdentityCredentials()
        {
            return GetCachedClient(client => new DataFactoryManagedIdentityCredentialCollection(client, Id));
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> Credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credentialName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="credentialName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedIdentityCredentialResource>> GetDataFactoryManagedIdentityCredentialAsync(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryManagedIdentityCredentials().GetAsync(credentialName, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> Credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credentialName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="credentialName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedIdentityCredentialResource> GetDataFactoryManagedIdentityCredential(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryManagedIdentityCredentials().Get(credentialName, ifNoneMatch, cancellationToken);
        }

        // Kept custom rather than @@Legacy.markAsPageable: GA returns Pageable<DataFactoryTriggerResource>
        // (the resource wrapper), whereas markAsPageable pages over the TriggerResource data items and
        // would yield Pageable<DataFactoryTriggerData>. This convenience method wraps each data item into
        // its DataFactoryTriggerResource to preserve the previously shipped API surface.
        /// <summary> Query triggers in the factory by criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual Pageable<DataFactoryTriggerResource> GetTriggers(TriggerFilterContent content, CancellationToken cancellationToken = default)
        {
            var response = GetTriggersInternal(content, cancellationToken);
            var items = new System.Collections.Generic.List<DataFactoryTriggerResource>();
            foreach (var data in response.Value.Value)
            {
                items.Add(new DataFactoryTriggerResource(Client, data));
            }
            return new SinglePagePageable<DataFactoryTriggerResource>(items, response.GetRawResponse());
        }

        /// <summary> Query triggers in the factory by criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<DataFactoryTriggerResource> GetTriggersAsync(TriggerFilterContent content, CancellationToken cancellationToken = default)
        {
            return new InternalTriggersAsyncPageable(this, content, cancellationToken);
        }

        private sealed class InternalTriggersAsyncPageable : AsyncPageable<DataFactoryTriggerResource>
        {
            private readonly DataFactoryResource _parent;
            private readonly TriggerFilterContent _content;
            private readonly CancellationToken _cancellationToken;
            public InternalTriggersAsyncPageable(DataFactoryResource parent, TriggerFilterContent content, CancellationToken cancellationToken)
            {
                _parent = parent; _content = content; _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<DataFactoryTriggerResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetTriggersInternalAsync(_content, _cancellationToken).ConfigureAwait(false);
                var items = new System.Collections.Generic.List<DataFactoryTriggerResource>();
                foreach (var data in response.Value.Value)
                {
                    items.Add(new DataFactoryTriggerResource(_parent.Client, data));
                }
                yield return Page<DataFactoryTriggerResource>.FromValues(items, null, response.GetRawResponse());
            }
        }

        internal sealed class DataFactoryTriggerQueryResult
        {
            public IReadOnlyList<DataFactoryTriggerData> Value { get; set; }
            public string ContinuationToken { get; set; }
        }

        private static RequestContext BuildContext(CancellationToken cancellationToken)
        {
            return new RequestContext { CancellationToken = cancellationToken };
        }

        private static List<T> ReadArray<T>(JsonElement parent, string propName, Func<JsonElement, T> reader)
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

        private static string ReadString(JsonElement parent, string propName)
        {
            if (parent.TryGetProperty(propName, out var s) && s.ValueKind == JsonValueKind.String)
            {
                return s.GetString();
            }
            return null;
        }

        private static T ParseAndDeserialize<T>(Response response, Func<JsonElement, T> deserializer)
        {
            using JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
            return deserializer(doc.RootElement);
        }

        internal Response<DataFactoryTriggerQueryResult> GetTriggersInternal(TriggerFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _triggersRestClient.CreateGetTriggersRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, TriggerFilterContent.ToRequestContent(content), context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryTriggerQueryResult
            {
                Value = ReadArray(e, "value", el => DataFactoryTriggerData.DeserializeDataFactoryTriggerData(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }

        internal async Task<Response<DataFactoryTriggerQueryResult>> GetTriggersInternalAsync(TriggerFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _triggersRestClient.CreateGetTriggersRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, TriggerFilterContent.ToRequestContent(content), context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryTriggerQueryResult
            {
                Value = ReadArray(e, "value", el => DataFactoryTriggerData.DeserializeDataFactoryTriggerData(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }
    }
}
