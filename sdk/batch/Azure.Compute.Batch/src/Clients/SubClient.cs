// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Compute.Batch.Models;

namespace Azure.Compute.Batch
{
    public abstract class SubClient
    {
        protected internal delegate Response GetOperation(string id, string select, string expand, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> GetOperationAsync(string id, string select, string expand, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate Response ParentedGetOperation(string parentId, string id, string select, string expand, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> ParentedGetOperationAsync(string parentId, string id, string select, string expand, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate Pageable<BinaryData> ListOperation(string filter, string select, string expand, int? maxResults, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate AsyncPageable<BinaryData> ListOperationAsync(string filter, string select, string expand, int? maxResults, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate Pageable<BinaryData> ParentedListOperation(string parentId, string filter, string select, string expand, int? maxResults, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate AsyncPageable<BinaryData> ParentedListOperationAsync(string parentId, string filter, string select, string expand, int? maxResults, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate Response AddOperation(RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> AddOperationAsync(RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate Response ParentedAddOperation(string parentId, RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> ParentedAddOperationAsync(string parentId, RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestContext context);
        protected internal delegate Response UpdateOperation(string id, RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> UpdateOperationAsync(string id, RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate Response ParentedUpdateOperation(string parentId, string id, RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> ParentedUpdateOperationAsync(string parentId, string id, RequestContent content, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);

        protected internal delegate Response SimpleOperation(string id, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> SimpleOperationAsync(string id, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate Response ParentedSimpleOperation(string parentid, string id, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);
        protected internal delegate System.Threading.Tasks.Task<Response> ParentedSimpleOperationAsync(string parentId, string id, int? timeout, Guid? clientRequestId, bool? returnClientRequestId, DateTimeOffset? ocpDate, RequestConditions requestConditions, RequestContext context);

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

        protected internal Response<T> HandleGet<T>(string id, GetOptions options, GetOperation operation, Func<JsonElement, T> deserialize)
        {
            Response response = operation(id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
            return HandleResponse(response, deserialize);
        }

        protected internal async System.Threading.Tasks.Task<Response<T>> HandleGetAsync<T>(string id, GetOptions options, GetOperationAsync operation, Func<JsonElement, T> deserialize)
        {
            Response response = await operation(id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
            return HandleResponse(response, deserialize);
        }

        protected internal Response<T> HandleGet<T>(string parentId, string id, GetOptions options, ParentedGetOperation operation, Func<JsonElement, T> deserialize)
        {
            Response response = operation(parentId, id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
            return HandleResponse(response, deserialize);
        }

        protected internal async System.Threading.Tasks.Task<Response<T>> HandleGetAsync<T>(string parentId, string id, GetOptions options, ParentedGetOperationAsync operation, Func<JsonElement, T> deserialize)
        {
            Response response = await operation(parentId, id, options?.Select, options?.Expand, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
            return HandleResponse(response, deserialize);
        }

        protected internal Pageable<T> HandleList<T>(ListOptions options, ListOperation operation, Func<JsonElement, T> deserialize)
        {
            Pageable<BinaryData> data = operation(options?.Filter, options?.Select, options?.Expand, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.Context);
            return HandleList(data, deserialize);
        }

        protected internal AsyncPageable<T> HandleListAsync<T>(ListOptions options, ListOperationAsync operation, Func<JsonElement, T> deserialize)
        {
            AsyncPageable<BinaryData> data = operation(options?.Filter, options?.Select, options?.Expand, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.Context);
            return HandleListAsync(data, deserialize);
        }

        protected internal Pageable<T> HandleList<T>(Pageable<BinaryData> data, Func<JsonElement, T> deserialize)
        {
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

        protected internal AsyncPageable<T> HandleListAsync<T>(AsyncPageable<BinaryData> data, Func<JsonElement, T> deserialize)
        {
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

        protected internal Pageable<T> HandleList<T>(string parentId, ListOptions options, ParentedListOperation operation, Func<JsonElement, T> deserialize)
        {
            Pageable<BinaryData> data = operation(parentId, options?.Filter, options?.Select, options?.Expand, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.Context);
            return HandleList(data, deserialize);
        }

        protected internal AsyncPageable<T> HandleListAsync<T>(string parentId, ListOptions options, ParentedListOperationAsync operation, Func<JsonElement, T> deserialize)
        {
            AsyncPageable<BinaryData> data = operation(parentId, options?.Filter, options?.Select, options?.Expand, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.Context);
            return HandleListAsync(data, deserialize);
        }

        protected Response HandleAdd(object contentObj, AddOperation add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return add(content, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleAddAsync(object contentObj, AddOperationAsync add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await add(content, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleAdd(string parentId, object contentObj, ParentedAddOperation add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return add(parentId, content, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleAddAsync(string parentId, object contentObj, ParentedAddOperationAsync add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await add(parentId, content, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleAddCollection(string parentId, IEnumerable<object> contentList, ParentedAddOperation add)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentList);
            return add(parentId, content, null, null, null, null, null);
        }

        protected Response HandleUpdate(string id, object contentObj, UpdateOperation update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return update(id, content, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleUpdateAsync(string id, object contentObj, UpdateOperationAsync update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await update(id, content, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleUpdate(string parentId, string id, object contentObj, ParentedUpdateOperation update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return update(parentId, id, content, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandleUpdateAsync(string parentId, string id, object contentObj, ParentedUpdateOperationAsync update)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await update(parentId, id, content, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandlePatch(string id, object contentObj, UpdateOperation patch)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return patch(id, content, null, null, null, null, null, null);
        }

        protected async System.Threading.Tasks.Task<Response> HandlePatchAsync(string id, object contentObj, UpdateOperationAsync patch)
        {
            RequestContent content = ModelHelpers.ToRequestContent(contentObj);
            return await patch(id, content, null, null, null, null, null, null).ConfigureAwait(false);
        }

        protected Response HandleDelete(string id, BaseOptions options, SimpleOperation delete)
        {
            return delete(id, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
        }

        protected async System.Threading.Tasks.Task<Response> HandleDeleteAsync(string id, BaseOptions options, SimpleOperationAsync delete)
        {
            return await delete(id, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
        }

        protected Response HandleDelete(string parentId, string id, BaseOptions options, ParentedSimpleOperation delete)
        {
            return delete(parentId, id, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
        }

        protected async System.Threading.Tasks.Task<Response> HandleDeleteAsync(string parentId, string id, BaseOptions options, ParentedSimpleOperationAsync delete)
        {
            return await delete(parentId, id, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
        }

        protected Response<bool> HandleExists(string id, BaseOptions options, SimpleOperation exists)
        {
            Response response = exists(id, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context);
            return CheckExists(response);
        }

        protected async System.Threading.Tasks.Task<Response<bool>> HandleExistsAsync(string id, BaseOptions options, SimpleOperationAsync exists)
        {
            Response response = await exists(id, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate, options?.RequestConditions, options?.Context).ConfigureAwait(false);
            return CheckExists(response);
        }

        private Response<bool> CheckExists(Response response)
        {
            bool exists = response.Status == 200;
            return Response.FromValue(exists, response);
        }
    }
}
