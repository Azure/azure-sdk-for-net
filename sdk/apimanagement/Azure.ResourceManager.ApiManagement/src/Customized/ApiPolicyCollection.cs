// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
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
    public partial class ApiPolicyCollection
    {
        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ApiPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _apiPolicyRestClient.CreateGetByApiRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            PolicyListResult listResult = PolicyListResult.FromResponse(result);
            var items = listResult.Value.Select(d => new ApiPolicyResource(Client, d)).ToList();
            var page = Page<ApiPolicyResource>.FromValues(items, null, result);
            return Pageable<ApiPolicyResource>.FromPages(new[] { page });
        }

        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ApiPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _apiPolicyRestClient.CreateGetByApiRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            PolicyListResult listResult = PolicyListResult.FromResponse(result);
            var items = listResult.Value.Select(d => new ApiPolicyResource(Client, d)).ToList();
            var page = Page<ApiPolicyResource>.FromValues(items, null, result);
            return AsyncPageable<ApiPolicyResource>.FromPages(new[] { page });
        }
    }
}
