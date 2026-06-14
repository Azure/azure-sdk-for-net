// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // Compatibility shim preserving the GA node-report content operation return type as BinaryData.
    [CodeGenSuppress("GetContentNodeReport", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetContentNodeReportAsync", typeof(string), typeof(CancellationToken))]
    public partial class DscNodeResource
    {
        /// <summary>
        /// Retrieve the Dsc node reports by node id and report id.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}/content. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DscNodes_GetContent. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportId"> The report id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="reportId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="reportId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<BinaryData>> GetContentNodeReportAsync(string reportId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportId, nameof(reportId));

            using DiagnosticScope scope = _nodeReportsClientDiagnostics.CreateScope("DscNodeResource.GetContentNodeReport");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _nodeReportsRestClient.CreateGetContentNodeReportRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportId, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(response.Content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Dsc node reports by node id and report id.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}/content. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DscNodes_GetContent. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportId"> The report id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="reportId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="reportId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<BinaryData> GetContentNodeReport(string reportId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportId, nameof(reportId));

            using DiagnosticScope scope = _nodeReportsClientDiagnostics.CreateScope("DscNodeResource.GetContentNodeReport");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _nodeReportsRestClient.CreateGetContentNodeReportRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportId, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
