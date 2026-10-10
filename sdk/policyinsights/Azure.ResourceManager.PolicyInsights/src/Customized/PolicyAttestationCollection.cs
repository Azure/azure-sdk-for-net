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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAllAsync", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAll", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public partial class PolicyAttestationCollection
    {
        /// <summary>
        /// Gets all attestations for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/attestations. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Attestations_ListForResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyAttestationResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyAttestationResource> GetAllAsync(PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<PolicyAttestationData, PolicyAttestationResource>(new AttestationsGetForResourceAsyncCollectionResultOfT(
                _attestationsRestClient, Id.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "PolicyAttestationCollection.GetAll"), data => new PolicyAttestationResource(Client, data));
        }

        /// <summary>
        /// Gets all attestations for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/attestations. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Attestations_ListForResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyAttestationResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyAttestationResource> GetAll(PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<PolicyAttestationData, PolicyAttestationResource>(new AttestationsGetForResourceCollectionResultOfT(
                _attestationsRestClient, Id.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "PolicyAttestationCollection.GetAll"), data => new PolicyAttestationResource(Client, data));
        }
    }
}
