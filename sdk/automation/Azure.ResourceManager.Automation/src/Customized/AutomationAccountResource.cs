// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Automation.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // TypeSpec now places DSC compilation job stream operations on the SDK-only DscCompilationJobResource shape.
    // Keep the GA AutomationAccountResource methods so callers can pass jobId directly without using that generated resource.
    public partial class AutomationAccountResource
    {
        /// <summary>
        /// Retrieve all the job streams for the compilation Job.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automation_GetDscCompilationJobStreams</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomationJobStream"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AutomationJobStream> GetDscCompilationJobStreamsAsync(Guid jobId, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AutomationAccountGetDscCompilationJobStreamsAsyncCollectionResultOfT(
                _automationAccountRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                jobId,
                context,
                "AutomationAccountResource.GetDscCompilationJobStreams");
        }

        /// <summary>
        /// Retrieve all the job streams for the compilation Job.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automation_GetDscCompilationJobStreams</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomationJobStream"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AutomationJobStream> GetDscCompilationJobStreams(Guid jobId, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AutomationAccountGetDscCompilationJobStreamsCollectionResultOfT(
                _automationAccountRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                jobId,
                context,
                "AutomationAccountResource.GetDscCompilationJobStreams");
        }

        /// <summary>
        /// Retrieve the job stream identified by job stream id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams/{jobStreamId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automation_GetStreamDscCompilationJob</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="jobStreamId"> The job stream id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AutomationJobStream>> GetStreamDscCompilationJobAsync(Guid jobId, string jobStreamId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _automationAccountClientDiagnostics.CreateScope("AutomationAccountResource.GetStreamDscCompilationJob");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _automationAccountRestClient.CreateGetStreamDscCompilationJobRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, jobId, jobStreamId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<AutomationJobStream> response = Response.FromValue(AutomationJobStream.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the job stream identified by job stream id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams/{jobStreamId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automation_GetStreamDscCompilationJob</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="jobStreamId"> The job stream id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AutomationJobStream> GetStreamDscCompilationJob(Guid jobId, string jobStreamId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _automationAccountClientDiagnostics.CreateScope("AutomationAccountResource.GetStreamDscCompilationJob");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _automationAccountRestClient.CreateGetStreamDscCompilationJobRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, jobId, jobStreamId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<AutomationJobStream> response = Response.FromValue(AutomationJobStream.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
