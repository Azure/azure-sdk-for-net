// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Workaround for generator bug: GetAll returns Response<T> instead of Pageable<T>.
// See https://github.com/Azure/azure-sdk-for-net/issues/56502

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    public partial class ApiManagementPrivateLinkResourceCollection
    {
        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ApiManagementPrivateLinkResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionRestClient.CreateGetPrivateLinkResourcesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
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
            HttpMessage message = _privateEndpointConnectionRestClient.CreateGetPrivateLinkResourcesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
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
