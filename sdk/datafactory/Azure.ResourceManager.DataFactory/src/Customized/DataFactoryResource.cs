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
    // MPG generator regression workaround. This partial restores pre-MPG DataFactoryResource API
    // surface the regenerated class no longer emits:
    //   1. Back-compat string ifNoneMatch overloads ([EditorBrowsable(Never)]) that delegate to the
    //      ETag-based generated methods.
    //   2. The public Query convenience methods (GetActivityRun, GetPipelineRuns, GetTriggers,
    //      GetTriggerRuns, GetPrivateLinkResources) plus their *Internal helpers and result wrappers:
    //      the generator now emits only the REST request-builders, so the helpers build the message via
    //      the generated CreateGet*Request, send it through the shared pipeline, and deserialize the
    //      JSON payload into the existing model types.
    public partial class DataFactoryResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryTriggerResource>> GetDataFactoryTriggerAsync(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryTriggerAsync(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryTriggerResource> GetDataFactoryTrigger(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryTrigger(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryIntegrationRuntimeResource>> GetDataFactoryIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryIntegrationRuntimeAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryIntegrationRuntimeResource> GetDataFactoryIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryIntegrationRuntime(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryLinkedServiceResource>> GetDataFactoryLinkedServiceAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryLinkedServiceAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryLinkedServiceResource> GetDataFactoryLinkedService(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryLinkedService(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDatasetResource>> GetDataFactoryDatasetAsync(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDatasetAsync(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDatasetResource> GetDataFactoryDataset(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataset(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPipelineResource>> GetDataFactoryPipelineAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPipelineAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPipelineResource> GetDataFactoryPipeline(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPipeline(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDataFlowResource>> GetDataFactoryDataFlowAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDataFlowAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDataFlowResource> GetDataFactoryDataFlow(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataFlow(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedVirtualNetworkResource>> GetDataFactoryManagedVirtualNetworkAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryManagedVirtualNetworkAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedVirtualNetworkResource> GetDataFactoryManagedVirtualNetwork(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryManagedVirtualNetwork(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryServiceCredentialResource>> GetDataFactoryServiceCredentialAsync(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryServiceCredentialAsync(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryServiceCredentialResource> GetDataFactoryServiceCredential(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryServiceCredential(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointConnectionResource>> GetDataFactoryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPrivateEndpointConnectionAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointConnectionResource> GetDataFactoryPrivateEndpointConnection(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPrivateEndpointConnection(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryChangeDataCaptureResource>> GetDataFactoryChangeDataCaptureAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryChangeDataCaptureAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

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

        /// <summary> Get activity runs by query criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual Pageable<PipelineActivityRunInformation> GetActivityRun(string runId, RunFilterContent content, CancellationToken cancellationToken = default)
        {
            var response = GetActivityRunInternal(runId, content, cancellationToken);
            return new SinglePagePageable<PipelineActivityRunInformation>(System.Linq.Enumerable.ToList(response.Value.Value), response.GetRawResponse());
        }

        /// <summary> Get activity runs by query criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<PipelineActivityRunInformation> GetActivityRunAsync(string runId, RunFilterContent content, CancellationToken cancellationToken = default)
        {
            return new InternalActivityRunAsyncPageable(this, runId, content, cancellationToken);
        }

        private sealed class InternalActivityRunAsyncPageable : AsyncPageable<PipelineActivityRunInformation>
        {
            private readonly DataFactoryResource _parent;
            private readonly string _runId;
            private readonly RunFilterContent _content;
            private readonly CancellationToken _cancellationToken;
            public InternalActivityRunAsyncPageable(DataFactoryResource parent, string runId, RunFilterContent content, CancellationToken cancellationToken)
            {
                _parent = parent; _runId = runId; _content = content; _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<PipelineActivityRunInformation>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetActivityRunInternalAsync(_runId, _content, _cancellationToken).ConfigureAwait(false);
                yield return Page<PipelineActivityRunInformation>.FromValues(System.Linq.Enumerable.ToList(response.Value.Value), null, response.GetRawResponse());
            }
        }

        /// <summary> Query pipeline runs in the factory by criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual Pageable<DataFactoryPipelineRunInfo> GetPipelineRuns(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            var response = GetPipelineRunsInternal(content, cancellationToken);
            return new SinglePagePageable<DataFactoryPipelineRunInfo>(System.Linq.Enumerable.ToList(response.Value.Value), response.GetRawResponse());
        }

        /// <summary> Query pipeline runs in the factory by criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<DataFactoryPipelineRunInfo> GetPipelineRunsAsync(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            return new InternalPipelineRunsAsyncPageable(this, content, cancellationToken);
        }

        private sealed class InternalPipelineRunsAsyncPageable : AsyncPageable<DataFactoryPipelineRunInfo>
        {
            private readonly DataFactoryResource _parent;
            private readonly RunFilterContent _content;
            private readonly CancellationToken _cancellationToken;
            public InternalPipelineRunsAsyncPageable(DataFactoryResource parent, RunFilterContent content, CancellationToken cancellationToken)
            {
                _parent = parent; _content = content; _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<DataFactoryPipelineRunInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetPipelineRunsInternalAsync(_content, _cancellationToken).ConfigureAwait(false);
                yield return Page<DataFactoryPipelineRunInfo>.FromValues(System.Linq.Enumerable.ToList(response.Value.Value), null, response.GetRawResponse());
            }
        }

        /// <summary> Gets the private link resources. </summary>
        [ForwardsClientCalls(true)]
        public virtual Pageable<DataFactoryPrivateLinkResource> GetPrivateLinkResources(CancellationToken cancellationToken = default)
        {
            var response = GetPrivateLinkResourcesInternal(cancellationToken);
            return new SinglePagePageable<DataFactoryPrivateLinkResource>(System.Linq.Enumerable.ToList(response.Value.Value), response.GetRawResponse());
        }

        /// <summary> Gets the private link resources. </summary>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<DataFactoryPrivateLinkResource> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            return new InternalPrivateLinkResourcesAsyncPageable(this, cancellationToken);
        }

        private sealed class InternalPrivateLinkResourcesAsyncPageable : AsyncPageable<DataFactoryPrivateLinkResource>
        {
            private readonly DataFactoryResource _parent;
            private readonly CancellationToken _cancellationToken;
            public InternalPrivateLinkResourcesAsyncPageable(DataFactoryResource parent, CancellationToken cancellationToken)
            {
                _parent = parent; _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<DataFactoryPrivateLinkResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetPrivateLinkResourcesInternalAsync(_cancellationToken).ConfigureAwait(false);
                yield return Page<DataFactoryPrivateLinkResource>.FromValues(System.Linq.Enumerable.ToList(response.Value.Value), null, response.GetRawResponse());
            }
        }

        /// <summary> Query trigger runs by query criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual Pageable<DataFactoryTriggerRun> GetTriggerRuns(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            var response = GetTriggerRunsInternal(content, cancellationToken);
            return new SinglePagePageable<DataFactoryTriggerRun>(System.Linq.Enumerable.ToList(response.Value.Value), response.GetRawResponse());
        }

        /// <summary> Query trigger runs by query criteria. </summary>
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<DataFactoryTriggerRun> GetTriggerRunsAsync(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            return new InternalTriggerRunsAsyncPageable(this, content, cancellationToken);
        }

        private sealed class InternalTriggerRunsAsyncPageable : AsyncPageable<DataFactoryTriggerRun>
        {
            private readonly DataFactoryResource _parent;
            private readonly RunFilterContent _content;
            private readonly CancellationToken _cancellationToken;
            public InternalTriggerRunsAsyncPageable(DataFactoryResource parent, RunFilterContent content, CancellationToken cancellationToken)
            {
                _parent = parent; _content = content; _cancellationToken = cancellationToken;
            }
            [ForwardsClientCalls]
            public override async System.Collections.Generic.IAsyncEnumerable<Page<DataFactoryTriggerRun>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _parent.GetTriggerRunsInternalAsync(_content, _cancellationToken).ConfigureAwait(false);
                yield return Page<DataFactoryTriggerRun>.FromValues(System.Linq.Enumerable.ToList(response.Value.Value), null, response.GetRawResponse());
            }
        }

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

        internal sealed class PipelineActivityRunsResult
        {
            public IReadOnlyList<PipelineActivityRunInformation> Value { get; set; }
            public string ContinuationToken { get; set; }
        }

        internal sealed class DataFactoryPipelineRunsQueryResult
        {
            public IReadOnlyList<DataFactoryPipelineRunInfo> Value { get; set; }
            public string ContinuationToken { get; set; }
        }

        internal sealed class DataFactoryTriggerQueryResult
        {
            public IReadOnlyList<DataFactoryTriggerData> Value { get; set; }
            public string ContinuationToken { get; set; }
        }

        internal sealed class DataFactoryTriggerRunsQueryResult
        {
            public IReadOnlyList<DataFactoryTriggerRun> Value { get; set; }
            public string ContinuationToken { get; set; }
        }

        internal sealed class DataFactoryPrivateLinkResources
        {
            public IReadOnlyList<DataFactoryPrivateLinkResource> Value { get; set; }
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

        internal Response<PipelineActivityRunsResult> GetActivityRunInternal(string runId, RunFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _activityRunsRestClient.CreateGetActivityRunRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, runId, RunFilterContent.ToRequestContent(content), context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new PipelineActivityRunsResult
            {
                Value = ReadArray(e, "value", el => PipelineActivityRunInformation.DeserializePipelineActivityRunInformation(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }

        internal async Task<Response<PipelineActivityRunsResult>> GetActivityRunInternalAsync(string runId, RunFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _activityRunsRestClient.CreateGetActivityRunRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, runId, RunFilterContent.ToRequestContent(content), context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new PipelineActivityRunsResult
            {
                Value = ReadArray(e, "value", el => PipelineActivityRunInformation.DeserializePipelineActivityRunInformation(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }

        internal Response<DataFactoryPipelineRunsQueryResult> GetPipelineRunsInternal(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _pipelineRunsRestClient.CreateGetPipelineRunsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, RunFilterContent.ToRequestContent(content), context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryPipelineRunsQueryResult
            {
                Value = ReadArray(e, "value", el => DataFactoryPipelineRunInfo.DeserializeDataFactoryPipelineRunInfo(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }

        internal async Task<Response<DataFactoryPipelineRunsQueryResult>> GetPipelineRunsInternalAsync(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _pipelineRunsRestClient.CreateGetPipelineRunsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, RunFilterContent.ToRequestContent(content), context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryPipelineRunsQueryResult
            {
                Value = ReadArray(e, "value", el => DataFactoryPipelineRunInfo.DeserializeDataFactoryPipelineRunInfo(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }

        internal Response<DataFactoryPrivateLinkResources> GetPrivateLinkResourcesInternal(CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _privateLinkResourcesRestClient.CreateGetPrivateLinkResourcesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryPrivateLinkResources
            {
                Value = ReadArray(e, "value", el => DataFactoryPrivateLinkResource.DeserializeDataFactoryPrivateLinkResource(el, ModelSerializationExtensions.WireOptions)),
            });
            return Response.FromValue(result, response);
        }

        internal async Task<Response<DataFactoryPrivateLinkResources>> GetPrivateLinkResourcesInternalAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _privateLinkResourcesRestClient.CreateGetPrivateLinkResourcesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryPrivateLinkResources
            {
                Value = ReadArray(e, "value", el => DataFactoryPrivateLinkResource.DeserializeDataFactoryPrivateLinkResource(el, ModelSerializationExtensions.WireOptions)),
            });
            return Response.FromValue(result, response);
        }

        internal Response<DataFactoryTriggerRunsQueryResult> GetTriggerRunsInternal(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _triggerRunsRestClient.CreateGetTriggerRunsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, RunFilterContent.ToRequestContent(content), context);
            Response response = Pipeline.ProcessMessage(message, context);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryTriggerRunsQueryResult
            {
                Value = ReadArray(e, "value", el => DataFactoryTriggerRun.DeserializeDataFactoryTriggerRun(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
        }

        internal async Task<Response<DataFactoryTriggerRunsQueryResult>> GetTriggerRunsInternalAsync(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            RequestContext context = BuildContext(cancellationToken);
            using HttpMessage message = _triggerRunsRestClient.CreateGetTriggerRunsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, RunFilterContent.ToRequestContent(content), context);
            Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            if (response.Status >= 400) throw new RequestFailedException(response);
            var result = ParseAndDeserialize(response, e => new DataFactoryTriggerRunsQueryResult
            {
                Value = ReadArray(e, "value", el => DataFactoryTriggerRun.DeserializeDataFactoryTriggerRun(el, ModelSerializationExtensions.WireOptions)),
                ContinuationToken = ReadString(e, "continuationToken"),
            });
            return Response.FromValue(result, response);
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
