// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights
{
    // Fix queryOptions forwarding (generator bug #59950)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDeploymentsAsync", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDeployments", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public partial class PolicyRemediationResource
    {
        /// <summary>
        /// Gets all deployments for a remediation at resource scope.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/listDeployments. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Remediations_ListDeploymentsAtResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PolicyRemediationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RemediationDeployment"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RemediationDeployment> GetDeploymentsAsync(PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new RemediationsGetDeploymentsAsyncCollectionResultOfT(
                _remediationsRestClient, Id.Parent.ToString(), Id.Name,
                policyQuerySettings?.Top,
                context, "PolicyRemediationResource.GetDeployments");
        }

        /// <summary>
        /// Gets all deployments for a remediation at resource scope.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/listDeployments. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Remediations_ListDeploymentsAtResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PolicyRemediationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RemediationDeployment"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RemediationDeployment> GetDeployments(PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new RemediationsGetDeploymentsCollectionResultOfT(
                _remediationsRestClient, Id.Parent.ToString(), Id.Name,
                policyQuerySettings?.Top,
                context, "PolicyRemediationResource.GetDeployments");
        }
    }
}
