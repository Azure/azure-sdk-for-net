// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PolicyInsights
{
    // Fix queryOptions forwarding (generator bug #59950)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDeploymentsAsync", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDeployments", typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
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

        /// <summary> Deletes an existing remediation at individual resource scope. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<PolicyRemediationResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _remediationsClientDiagnostics.CreateScope("PolicyRemediationResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _remediationsRestClient.CreateDeleteAtResourceRequest(Id.Parent.ToString(), Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PolicyRemediationData> response = Response.FromValue(PolicyRemediationData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PolicyInsightsArmOperation<PolicyRemediationResource> operation = new PolicyInsightsArmOperation<PolicyRemediationResource>(Response.FromValue(new PolicyRemediationResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes an existing remediation at individual resource scope. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<PolicyRemediationResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _remediationsClientDiagnostics.CreateScope("PolicyRemediationResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _remediationsRestClient.CreateDeleteAtResourceRequest(Id.Parent.ToString(), Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PolicyRemediationData> response = Response.FromValue(PolicyRemediationData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PolicyInsightsArmOperation<PolicyRemediationResource> operation = new PolicyInsightsArmOperation<PolicyRemediationResource>(Response.FromValue(new PolicyRemediationResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
