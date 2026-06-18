// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ApiManagement
{
    // MPG currently emits some HEAD action methods as raw Response methods or collection Exists methods.
    // These partials preserve the old AutoRest Response<bool> resource-level surface where no generated
    // method with the same signature exists in the current source.
    public partial class ApiManagementGatewayResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetGatewayApiEntityTagAsync(string apiId, CancellationToken cancellationToken = default)
        {
            Response response = await GetGatewayApiEntityTagRawAsync(apiId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> GetGatewayApiEntityTag(string apiId, CancellationToken cancellationToken = default)
        {
            Response response = GetGatewayApiEntityTagRaw(apiId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }
    }

    public partial class ApiManagementGroupResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckGroupUserEntityExistsAsync(string userId, CancellationToken cancellationToken = default)
        {
            Response response = await CheckGroupUserEntityExistsRawAsync(userId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckGroupUserEntityExists(string userId, CancellationToken cancellationToken = default)
        {
            Response response = CheckGroupUserEntityExistsRaw(userId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }
    }

    public partial class ApiManagementNotificationResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckNotificationRecipientUserEntityExistsAsync(string userId, CancellationToken cancellationToken = default)
        {
            Response response = await CheckNotificationRecipientUserEntityExistsRawAsync(userId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckNotificationRecipientUserEntityExists(string userId, CancellationToken cancellationToken = default)
        {
            Response response = CheckNotificationRecipientUserEntityExistsRaw(userId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckNotificationRecipientEmailEntityExistsAsync(string email, CancellationToken cancellationToken = default)
        {
            Response response = await CheckNotificationRecipientEmailEntityExistsRawAsync(email, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckNotificationRecipientEmailEntityExists(string email, CancellationToken cancellationToken = default)
        {
            Response response = CheckNotificationRecipientEmailEntityExistsRaw(email, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }
    }

    public partial class ApiManagementProductResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckProductApiEntityExistsAsync(string apiId, CancellationToken cancellationToken = default)
        {
            Response response = await CheckProductApiEntityExistsRawAsync(apiId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckProductApiEntityExists(string apiId, CancellationToken cancellationToken = default)
        {
            Response response = CheckProductApiEntityExistsRaw(apiId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckProductGroupEntityExistsAsync(string groupId, CancellationToken cancellationToken = default)
        {
            Response response = await CheckProductGroupEntityExistsRawAsync(groupId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckProductGroupEntityExists(string groupId, CancellationToken cancellationToken = default)
        {
            Response response = CheckProductGroupEntityExistsRaw(groupId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }
    }

    public partial class ServiceWorkspaceGroupResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckEntityExistsWorkspaceGroupUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            Response response = await CheckEntityExistsAsync(userId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckEntityExistsWorkspaceGroupUser(string userId, CancellationToken cancellationToken = default)
        {
            Response response = CheckEntityExists(userId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }
    }

    public partial class ServiceWorkspaceNotificationResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckEntityExistsWorkspaceNotificationRecipientUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            Response response = await CheckEntityExistsWorkspaceNotificationRecipientUserRawAsync(userId, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckEntityExistsWorkspaceNotificationRecipientUser(string userId, CancellationToken cancellationToken = default)
        {
            Response response = CheckEntityExistsWorkspaceNotificationRecipientUserRaw(userId, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual async Task<Response<bool>> CheckEntityExistsWorkspaceNotificationRecipientEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            Response response = await CheckEntityExistsWorkspaceNotificationRecipientEmailRawAsync(email, cancellationToken).ConfigureAwait(false);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }

        /// <inheritdoc />
        public virtual Response<bool> CheckEntityExistsWorkspaceNotificationRecipientEmail(string email, CancellationToken cancellationToken = default)
        {
            Response response = CheckEntityExistsWorkspaceNotificationRecipientEmailRaw(email, cancellationToken);
            return GetEntityTagCompatibility.ToExistsResponse(response);
        }
    }

    public partial class ApiTagResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityStateByApiAsync(CancellationToken cancellationToken = default)
            => await new ApiTagCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityStateByApi(CancellationToken cancellationToken = default)
            => new ApiTagCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken);
    }

    public partial class ApiOperationTagResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityStateByOperationAsync(CancellationToken cancellationToken = default)
            => await new ApiOperationTagCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityStateByOperation(CancellationToken cancellationToken = default)
            => new ApiOperationTagCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken);
    }

    public partial class ApiManagementProductTagResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityStateByProductAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementProductTagCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityStateByProduct(CancellationToken cancellationToken = default)
            => new ApiManagementProductTagCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken);
    }

    public partial class ApiManagementTagResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityStateAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementTagCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityState(CancellationToken cancellationToken = default)
            => new ApiManagementTagCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken);
    }

    public partial class ServiceWorkspaceTagResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityStateAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceTagCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityState(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceTagCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken);
    }

    public partial class ApiManagementServiceResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetContentItemEntityTagAsync(string contentTypeId, string contentItemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));
            Argument.AssertNotNullOrEmpty(contentItemId, nameof(contentItemId));

            ContentItem contentItemRestClient = CreateContentItemRestClient(out ClientDiagnostics diagnostics);
            return await GetEntityTagCompatibility.SendHeadAsync(
                diagnostics,
                Pipeline,
                "ApiManagementServiceResource.GetContentItemEntityTag",
                context => contentItemRestClient.CreateGetContentItemEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, contentItemId, context),
                cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Response<bool> GetContentItemEntityTag(string contentTypeId, string contentItemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentTypeId, nameof(contentTypeId));
            Argument.AssertNotNullOrEmpty(contentItemId, nameof(contentItemId));

            ContentItem contentItemRestClient = CreateContentItemRestClient(out ClientDiagnostics diagnostics);
            return GetEntityTagCompatibility.SendHead(
                diagnostics,
                Pipeline,
                "ApiManagementServiceResource.GetContentItemEntityTag",
                context => contentItemRestClient.CreateGetContentItemEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, contentTypeId, contentItemId, context),
                cancellationToken);
        }

        private ContentItem CreateContentItemRestClient(out ClientDiagnostics diagnostics)
        {
            TryGetApiVersion(ApiManagementContentItemResource.ResourceType, out string apiVersion);
            diagnostics = new ClientDiagnostics("Azure.ResourceManager.ApiManagement", ApiManagementContentItemResource.ResourceType.Namespace, Diagnostics);
            return new ContentItem(diagnostics, Pipeline, Endpoint, apiVersion ?? "2025-09-01-preview");
        }
    }
}
