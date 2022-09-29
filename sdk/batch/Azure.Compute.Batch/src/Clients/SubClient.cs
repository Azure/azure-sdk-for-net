// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Compute.Batch.Models;

namespace Azure.Compute.Batch
{
    public abstract class SubClient
    {
        public Func<Response, BinaryData> ContentHandler { get; set; }

        protected virtual BinaryData GetContent(Response response)
        {
            return ContentHandler(response) ?? response.Content;
        }

        private Response<T> HandleResponse<T>(Response response, Func<JsonElement, T> deserialize)
        {
            T model = deserialize(JsonDocument.Parse(response.Content).RootElement);
            return Response.FromValue(model, response);
        }

        protected internal Response<T> HandleGet<T>(string id, GetOptions options, Func<string, string, string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> operation, Func<JsonElement, T> deserialize)
        {
            Response response = operation(id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
            return HandleResponse(response, deserialize);
        }

        protected internal async System.Threading.Tasks.Task<Response<T>> HandleGetAsync<T>(string id, GetOptions options, Func<string, string, string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> operation, Func<JsonElement, T> deserialize)
        {
            Response response = await operation(id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
            return HandleResponse(response, deserialize);
        }

        protected internal Response<T> HandleGet<T>(string parentId, string id, GetOptions options, Func<string, string, string, string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> operation, Func<JsonElement, T> deserialize)
        {
            Response response = operation(parentId, id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
            return HandleResponse(response, deserialize);
        }

        protected internal async System.Threading.Tasks.Task<Response<T>> HandleGetAsync<T>(string parentId, string id, GetOptions options, Func<string, string, string, string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> operation, Func<JsonElement, T> deserialize)
        {
            Response response = await operation(parentId, id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
            return HandleResponse(response, deserialize);
        }

        protected internal Pageable<T> HandleList<T>(ListOptions options, Func<string, string, string, int?, int?, Guid?, bool?, DateTimeOffset?, RequestContext, Pageable<BinaryData>> operation, Func<JsonElement, T> deserialize)
        {
            Pageable<BinaryData> data = operation(options?.Filter, options?.Select, options?.Expand, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.Context);
            return PageableHelpers.Select(data, response =>
            {
                JsonElement root = JsonDocument.Parse(response.Content).RootElement;
                List<T> items = new List<T>();
                foreach (JsonElement item in root.GetProperty("value").EnumerateArray())
                {
                    items.Add(deserialize(item));
                }

                return items;
            });
        }

        protected internal Pageable<T> HandleList<T>(string parentId, ListOptions options, Func<string, string, string, string, int?, int?, Guid?, bool?, DateTimeOffset?, RequestContext, Pageable<BinaryData>> operation, Func<JsonElement, T> deserialize)
        {
            Pageable<BinaryData> data = operation(parentId, options?.Filter, options?.Select, options?.Expand, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.Context);
            return PageableHelpers.Select(data, response =>
            {
                JsonElement root = JsonDocument.Parse(response.Content).RootElement;
                List<T> items = new List<T>();
                foreach (JsonElement item in root.GetProperty("value").EnumerateArray())
                {
                    items.Add(deserialize(item));
                }

                return items;
            });
        }

        protected Response HandleAdd(object contentObj, Func<RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestContext, Response> add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return add(content, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleAddAsync(object contentObj, Func<RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestContext, System.Threading.Tasks.Task<Response>> add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await add(content, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleAdd(string parentId, object contentObj, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestContext, Response> add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return add(parentId, content, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleAddAsync(string parentId, object contentObj, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestContext, System.Threading.Tasks.Task<Response>> add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await add(parentId, content, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleAddCollection(string parentId, IEnumerable<object> contentList, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestContext, Response> add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentList);
            return add(parentId, content, null, null, null, null, null);
        }

        protected Response HandleUpdate(string id, object contentObj, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return update(id, content, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleUpdateAsync(string id, object contentObj, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await update(id, content, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleUpdate(string parentId, string id, object contentObj, Func<string, string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return update(parentId, id, content, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleUpdateAsync(string parentId, string id, object contentObj, Func<string, string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await update(parentId, id, content, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandlePatch(string id, object contentObj, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> patch)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return patch(id, content, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandlePatchAsync(string id, object contentObj, Func<string, RequestContent, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> patch)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await patch(id, content, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleDelete(string id, Func<string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> delete)
        {
            return delete(id, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleDeleteAsync(string id, Func<string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> delete)
        {
            return await delete(id, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleDelete(string parentId, string id, Func<string, string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, Response> delete)
        {
            return delete(parentId, id, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleDeleteAsync(string parentId, string id, Func<string, string, int?, Guid?, bool?, DateTimeOffset?, RequestConditions, RequestContext, System.Threading.Tasks.Task<Response>> delete)
        {
            return await delete(parentId, id, null, null, null, null, null, null).ConfigureAwait(false);
        }
    }
}
