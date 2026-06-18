// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec constructor/property list follows the latest wire schema, but the GA SDK exposed a different constructor or property signature; CodeGenSuppress lets this partial provide the GA shape explicitly.
    // AOT compatibility customization: generated operation-result methods use the
    // reflection-based ModelReaderWriter.Read overload, which fails net10 trim/AOT analysis.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
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
        /// <description> DevOpsConfigurations_DevOpsOperationResultsGet. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-11-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DevOpsConfigurationResource"/>. </description>
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
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<OperationStatusResult> response = Response.FromValue(ModelReaderWriter.Read<OperationStatusResult>(result.Content, ModelSerializationExtensions.WireOptions, AzureResourceManagerContext.Default), result);
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
        /// Get devops long running operation result.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/operationResults/{operationResultId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DevOpsConfigurations_DevOpsOperationResultsGet. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-11-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DevOpsConfigurationResource"/>. </description>
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
                Response result = Pipeline.ProcessMessage(message, context);
                Response<OperationStatusResult> response = Response.FromValue(ModelReaderWriter.Read<OperationStatusResult>(result.Content, ModelSerializationExtensions.WireOptions, AzureResourceManagerContext.Default), result);
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
