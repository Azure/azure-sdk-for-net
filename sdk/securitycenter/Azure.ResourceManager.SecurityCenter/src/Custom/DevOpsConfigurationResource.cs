// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // TODO: Remove after https://github.com/Azure/azure-sdk-for-net/issues/59425.
    // Custom operation-result helpers use AOT-safe deserialization until the generator emits them correctly.
    public partial class DevOpsConfigurationResource
    {
        /// <summary>
        /// Get devops long running operation result.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/operationResults/{operationResultId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DevOpsConfigurations_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-11-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operationResultId"> The operation result id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationResultId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationResultId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<OperationStatusResult>> GetAsync(string operationResultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationResultId, nameof(operationResultId));

            using DiagnosticScope scope = _devOpsOperationResultsClientDiagnostics.CreateScope("DevOpsConfigurationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _devOpsOperationResultsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, operationResultId, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(DeserializeOperationStatusResult(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get devops long running operation result.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/operationResults/{operationResultId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DevOpsConfigurations_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-11-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operationResultId"> The operation result id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationResultId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationResultId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<OperationStatusResult> Get(string operationResultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationResultId, nameof(operationResultId));

            using DiagnosticScope scope = _devOpsOperationResultsClientDiagnostics.CreateScope("DevOpsConfigurationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _devOpsOperationResultsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, operationResultId, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(DeserializeOperationStatusResult(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static OperationStatusResult DeserializeOperationStatusResult(Response response)
        {
            return ModelReaderWriter.Read<OperationStatusResult>(response.Content, ModelSerializationExtensions.WireOptions, AzureResourceManagerContext.Default);
        }
    }
}
