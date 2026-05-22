// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG generator regression workaround: the regenerated DataFactoryResource class no longer emits
// the public Query convenience methods that the SDK customizations on `main` exposed
// (e.g. GetActivityRun, GetPipelineRuns, GetTriggers, GetTriggerRuns, GetPrivateLinkResources).
// The generator now only emits the REST request-builders. This file re-implements the
// `*Internal` helper methods consumed by DataFactoryResource.cs. They:
//   1. Build the REST message via the generator-emitted CreateGet*Request,
//   2. Send via the shared HTTP pipeline,
//   3. Deserialize the JSON payload into the existing model types,
//   4. Return Response<T> with an internal wrapper that exposes Value and ContinuationToken.

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
    public partial class DataFactoryResource
    {
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
