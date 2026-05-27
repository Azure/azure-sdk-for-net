// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Workaround for generator bug: GetAll returns Response<PolicyListResult> instead of Pageable<T>.
// See https://github.com/Azure/azure-sdk-for-net/issues/56502

#nullable disable

using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    public partial class ApiOperationPolicyCollection
    {
        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ApiOperationPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _apiOperationPolicyRestClient.CreateGetByOperationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            PolicyListResult listResult = PolicyListResult.FromResponse(result);
            var items = listResult.Value.Select(d => new ApiOperationPolicyResource(Client, d)).ToList();
            var page = Page<ApiOperationPolicyResource>.FromValues(items, null, result);
            return Pageable<ApiOperationPolicyResource>.FromPages(new[] { page });
        }

        /// <summary> Gets all resources in this collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ApiOperationPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _apiOperationPolicyRestClient.CreateGetByOperationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            PolicyListResult listResult = PolicyListResult.FromResponse(result);
            var items = listResult.Value.Select(d => new ApiOperationPolicyResource(Client, d)).ToList();
            var page = Page<ApiOperationPolicyResource>.FromValues(items, null, result);
            return AsyncPageable<ApiOperationPolicyResource>.FromPages(new[] { page });
        }
    }
}
