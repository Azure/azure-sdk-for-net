// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    // Fix queryOptions forwarding (generator bug #59950)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAllAsync", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAll", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public partial class MockablePolicyInsightsTenantResource
    {
        /// <summary>
        /// Get a list of the policy metadata resources.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.PolicyInsights/policyMetadata. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyMetadataNonResourceOperationGroup_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SlimPolicyMetadata"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SlimPolicyMetadata> GetAllAsync(PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyMetadataGetAllAsyncCollectionResultOfT(
                PolicyMetadataRestClient, queryOptions?.Top,
                context, "MockablePolicyInsightsTenantResource.GetAll");
        }

        /// <summary>
        /// Get a list of the policy metadata resources.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.PolicyInsights/policyMetadata. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyMetadataNonResourceOperationGroup_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SlimPolicyMetadata"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SlimPolicyMetadata> GetAll(PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyMetadataGetAllCollectionResultOfT(
                PolicyMetadataRestClient, queryOptions?.Top,
                context, "MockablePolicyInsightsTenantResource.GetAll");
        }
    }
}
