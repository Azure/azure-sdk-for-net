// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql
{
    // Suppressing the string type parameter overloads for job version related APIs, since the jobVersion is the name of the resource SqlServerJobVersion which should be string but the definition in the spec is int, MPG can not handle this scenario correctly.
    // To mitigate this, we alternate the type of the jobVersion paramater in the API spec to string, and add back the int overloads in the code as backward compatibility. And suppress the string overloads in the codegen since they are not expected to be used directly.
    // Open Github issue for MPG: https://github.com/Azure/azure-sdk-for-net/issues/60105, once the issue is resolved, we can remove the int overloads and the suppression attributes in the code.
    [CodeGenSuppress("GetSqlServerJobVersionAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSqlServerJobVersion", typeof(string), typeof(CancellationToken))]
    public partial class SqlServerJobResource
    {
        /// <summary> Gets a job version. </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<SqlServerJobVersionResource>> GetSqlServerJobVersionAsync(int jobVersion, CancellationToken cancellationToken = default)
        {
            return await GetSqlServerJobVersions().GetAsync(jobVersion, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a job version. </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<SqlServerJobVersionResource> GetSqlServerJobVersion(int jobVersion, CancellationToken cancellationToken = default)
        {
            return GetSqlServerJobVersions().Get(jobVersion, cancellationToken);
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Starts an elastic job execution.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/start. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Jobs_Create. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlServerJobResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<SqlServerJobExecutionResource>> CreateJobExecutionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobExecutionsClientDiagnostics.CreateScope("SqlServerJobResource.CreateJobExecution");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobExecutionsRestClient.CreateStartJobExecutionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                SqlArmOperation<SqlServerJobExecutionResource> operation = new SqlArmOperation<SqlServerJobExecutionResource>(
                    new SqlServerJobExecutionResourceOperationSource(Client),
                    _jobExecutionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
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

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Starts an elastic job execution.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/start. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Jobs_Create. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlServerJobResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlServerJobExecutionResource> CreateJobExecution(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobExecutionsClientDiagnostics.CreateScope("SqlServerJobResource.CreateJobExecution");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobExecutionsRestClient.CreateStartJobExecutionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                SqlArmOperation<SqlServerJobExecutionResource> operation = new SqlArmOperation<SqlServerJobExecutionResource>(
                    new SqlServerJobExecutionResourceOperationSource(Client),
                    _jobExecutionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
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
