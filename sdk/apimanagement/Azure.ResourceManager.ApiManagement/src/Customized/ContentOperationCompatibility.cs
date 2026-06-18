// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceResource
    {
        /// <inheritdoc />
        public virtual AsyncPageable<ApiManagementContentType> GetContentTypesAsync(CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementContentTypeResource, ApiManagementContentType>(
                GetApiManagementContentTypes().GetAllAsync(cancellationToken),
                resource => ToContentType(resource.Data));

        /// <inheritdoc />
        public virtual Pageable<ApiManagementContentType> GetContentTypes(CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementContentTypeResource, ApiManagementContentType>(
                GetApiManagementContentTypes().GetAll(cancellationToken),
                resource => ToContentType(resource.Data));

        /// <inheritdoc />
        public virtual async Task<Response<ApiManagementContentType>> GetContentTypeAsync(string contentTypeId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementContentTypeResource> response = await GetApiManagementContentTypes().GetAsync(contentTypeId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToContentType(response.Value.Data), response.GetRawResponse());
        }

        /// <inheritdoc />
        public virtual Response<ApiManagementContentType> GetContentType(string contentTypeId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementContentTypeResource> response = GetApiManagementContentTypes().Get(contentTypeId, cancellationToken);
            return Response.FromValue(ToContentType(response.Value.Data), response.GetRawResponse());
        }

        /// <inheritdoc />
        public virtual async Task<Response<ApiManagementContentType>> CreateOrUpdateContentTypeAsync(string contentTypeId, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));

            ContentType contentTypeRestClient = CreateContentTypeRestClient(out ClientDiagnostics diagnostics);
            return await SendContentTypeRequestAsync(
                diagnostics,
                "ApiManagementServiceResource.CreateOrUpdateContentType",
                context => contentTypeRestClient.CreateCreateOrUpdateContentTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, EmptyJsonContent(), ifMatch, context),
                cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Response<ApiManagementContentType> CreateOrUpdateContentType(string contentTypeId, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));

            ContentType contentTypeRestClient = CreateContentTypeRestClient(out ClientDiagnostics diagnostics);
            return SendContentTypeRequest(
                diagnostics,
                "ApiManagementServiceResource.CreateOrUpdateContentType",
                context => contentTypeRestClient.CreateCreateOrUpdateContentTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, EmptyJsonContent(), ifMatch, context),
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<Response> DeleteContentTypeAsync(string contentTypeId, ETag ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));

            ContentType contentTypeRestClient = CreateContentTypeRestClient(out ClientDiagnostics diagnostics);
            return await SendResponseRequestAsync(
                diagnostics,
                "ApiManagementServiceResource.DeleteContentType",
                context => contentTypeRestClient.CreateDeleteContentTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, ifMatch.ToString(), context),
                cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Response DeleteContentType(string contentTypeId, ETag ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));

            ContentType contentTypeRestClient = CreateContentTypeRestClient(out ClientDiagnostics diagnostics);
            return SendResponseRequest(
                diagnostics,
                "ApiManagementServiceResource.DeleteContentType",
                context => contentTypeRestClient.CreateDeleteContentTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, ifMatch.ToString(), context),
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual AsyncPageable<ApiManagementContentItem> GetContentItemsAsync(string contentTypeId, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementContentItemResource, ApiManagementContentItem>(
                GetContentItemCollection(contentTypeId).GetAllAsync(cancellationToken),
                resource => ToContentItem(resource.Data));

        /// <inheritdoc />
        public virtual Pageable<ApiManagementContentItem> GetContentItems(string contentTypeId, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementContentItemResource, ApiManagementContentItem>(
                GetContentItemCollection(contentTypeId).GetAll(cancellationToken),
                resource => ToContentItem(resource.Data));

        /// <inheritdoc />
        public virtual async Task<Response<ApiManagementContentItem>> GetContentItemAsync(string contentTypeId, string contentItemId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementContentItemResource> response = await GetContentItemCollection(contentTypeId).GetAsync(contentItemId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToContentItem(response.Value.Data), response.GetRawResponse());
        }

        /// <inheritdoc />
        public virtual Response<ApiManagementContentItem> GetContentItem(string contentTypeId, string contentItemId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementContentItemResource> response = GetContentItemCollection(contentTypeId).Get(contentItemId, cancellationToken);
            return Response.FromValue(ToContentItem(response.Value.Data), response.GetRawResponse());
        }

        /// <inheritdoc />
        public virtual async Task<Response<ApiManagementContentItem>> CreateOrUpdateContentItemAsync(string contentTypeId, string contentItemId, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));
            Argument.AssertNotNullOrEmpty(contentItemId, nameof(contentItemId));

            ContentItem contentItemRestClient = CreateContentItemRestClient(out ClientDiagnostics diagnostics);
            return await SendContentItemRequestAsync(
                diagnostics,
                "ApiManagementServiceResource.CreateOrUpdateContentItem",
                context => contentItemRestClient.CreateCreateOrUpdateContentItemRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, contentItemId, EmptyJsonContent(), ifMatch, context),
                cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Response<ApiManagementContentItem> CreateOrUpdateContentItem(string contentTypeId, string contentItemId, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));
            Argument.AssertNotNullOrEmpty(contentItemId, nameof(contentItemId));

            ContentItem contentItemRestClient = CreateContentItemRestClient(out ClientDiagnostics diagnostics);
            return SendContentItemRequest(
                diagnostics,
                "ApiManagementServiceResource.CreateOrUpdateContentItem",
                context => contentItemRestClient.CreateCreateOrUpdateContentItemRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, contentItemId, EmptyJsonContent(), ifMatch, context),
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<Response> DeleteContentItemAsync(string contentTypeId, string contentItemId, ETag ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));
            Argument.AssertNotNullOrEmpty(contentItemId, nameof(contentItemId));

            ContentItem contentItemRestClient = CreateContentItemRestClient(out ClientDiagnostics diagnostics);
            return await SendResponseRequestAsync(
                diagnostics,
                "ApiManagementServiceResource.DeleteContentItem",
                context => contentItemRestClient.CreateDeleteContentItemRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, contentItemId, ifMatch.ToString(), context),
                cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Response DeleteContentItem(string contentTypeId, string contentItemId, ETag ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));
            Argument.AssertNotNullOrEmpty(contentItemId, nameof(contentItemId));

            ContentItem contentItemRestClient = CreateContentItemRestClient(out ClientDiagnostics diagnostics);
            return SendResponseRequest(
                diagnostics,
                "ApiManagementServiceResource.DeleteContentItem",
                context => contentItemRestClient.CreateDeleteContentItemRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, contentItemId, ifMatch.ToString(), context),
                cancellationToken);
        }

        private static RequestContent EmptyJsonContent() => RequestContent.Create(BinaryData.FromString("{}"));

        private static ApiManagementContentType ToContentType(ApiManagementContentTypeData data)
            => data is null ? null : new ApiManagementContentType(data.Id?.ToString(), data.Name, data.ResourceType, data.ContentTypeIdentifier, data.ContentTypeName, data.Description, data.Schema, data.Version, default);

        private static ApiManagementContentItem ToContentItem(ApiManagementContentItemData data)
            => data is null ? null : new ApiManagementContentItem(data.Id?.ToString(), data.Name, data.ResourceType, data.Properties, default);

        private ApiManagementContentItemCollection GetContentItemCollection(string contentTypeId)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));

            ResourceIdentifier contentTypeResourceId = ApiManagementContentTypeResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, contentTypeId);
            return new ApiManagementContentTypeResource(Client, contentTypeResourceId).GetApiManagementContentItems();
        }

        private ContentType CreateContentTypeRestClient(out ClientDiagnostics diagnostics)
        {
            TryGetApiVersion(ApiManagementContentTypeResource.ResourceType, out string apiVersion);
            diagnostics = new ClientDiagnostics("Azure.ResourceManager.ApiManagement", ApiManagementContentTypeResource.ResourceType.Namespace, Diagnostics);
            return new ContentType(diagnostics, Pipeline, Endpoint, apiVersion ?? "2025-09-01-preview");
        }

        private async Task<Response<ApiManagementContentType>> SendContentTypeRequestAsync(ClientDiagnostics diagnostics, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            Response response = await SendResponseRequestAsync(diagnostics, scopeName, createMessage, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(DeserializeContentType(response), response);
        }

        private Response<ApiManagementContentType> SendContentTypeRequest(ClientDiagnostics diagnostics, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            Response response = SendResponseRequest(diagnostics, scopeName, createMessage, cancellationToken);
            return Response.FromValue(DeserializeContentType(response), response);
        }

        private static ApiManagementContentType DeserializeContentType(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return ApiManagementContentType.DeserializeApiManagementContentType(document.RootElement, new ModelReaderWriterOptions("W"));
        }

        private async Task<Response<ApiManagementContentItem>> SendContentItemRequestAsync(ClientDiagnostics diagnostics, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            Response response = await SendResponseRequestAsync(diagnostics, scopeName, createMessage, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(DeserializeContentItem(response), response);
        }

        private Response<ApiManagementContentItem> SendContentItemRequest(ClientDiagnostics diagnostics, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            Response response = SendResponseRequest(diagnostics, scopeName, createMessage, cancellationToken);
            return Response.FromValue(DeserializeContentItem(response), response);
        }

        private static ApiManagementContentItem DeserializeContentItem(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return ApiManagementContentItem.DeserializeApiManagementContentItem(document.RootElement, new ModelReaderWriterOptions("W"));
        }

        private async Task<Response> SendResponseRequestAsync(ClientDiagnostics diagnostics, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response SendResponseRequest(ClientDiagnostics diagnostics, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
