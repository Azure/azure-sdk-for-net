// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    // Generator bug https://github.com/Azure/azure-sdk-for-net/issues/56502:
    // The MPG generator emits the list operation as Response<...ListResult> instead of
    // Pageable<T>/AsyncPageable<T>. Manual paging shims below suppress the broken generated
    // GetAll/GetAllAsync; remove this customization when #56502 is fixed.
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    public partial class ApiManagementPrivateLinkCollection
    {
        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ApiManagementPrivateLinkResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionRestClient.CreateGetPrivateLinkResourcesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            var items = ParsePrivateLinkResources(result);
            var page = Page<ApiManagementPrivateLinkResource>.FromValues(items, null, result);
            return Pageable<ApiManagementPrivateLinkResource>.FromPages(new[] { page });
        }

        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ApiManagementPrivateLinkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionRestClient.CreateGetPrivateLinkResourcesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            var items = ParsePrivateLinkResources(result);
            var page = Page<ApiManagementPrivateLinkResource>.FromValues(items, null, result);
            return AsyncPageable<ApiManagementPrivateLinkResource>.FromPages(new[] { page });
        }

        private IReadOnlyList<ApiManagementPrivateLinkResource> ParsePrivateLinkResources(Response response)
        {
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            var resources = new List<ApiManagementPrivateLinkResource>();
            if (doc.RootElement.TryGetProperty("value", out JsonElement valueArray))
            {
                foreach (JsonElement item in valueArray.EnumerateArray())
                {
                    var data = ApiManagementPrivateLinkResourceData.DeserializeApiManagementPrivateLinkResourceData(item, null);
                    resources.Add(new ApiManagementPrivateLinkResource(Client, data));
                }
            }
            return resources;
        }
    }
}
