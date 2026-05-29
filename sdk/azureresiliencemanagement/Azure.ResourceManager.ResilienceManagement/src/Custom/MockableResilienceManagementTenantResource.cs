// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResilienceManagement.Mocking
{
    // The generated Get/GetAsync for OperationStatus_Get emit the contextless overload
    // ModelReaderWriter.Read<OperationStatusResult>(result.Content), which carries
    // RequiresUnreferencedCode and triggers IL2026 under <IsAotCompatible>true</IsAotCompatible>.
    // Suppress and re-emit with the context-aware overload, with OperationStatusResult
    // registered on AzureResourceManagerResilienceManagementContext in the partial sibling file.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class MockableResilienceManagementTenantResource
    {
        /// <summary>
        /// Returns the current status of an async operation.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.AzureResilienceManagement/locations/{location}/operationStatuses/{operationId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OperationStatus_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="operationId"> The ID of an ongoing async operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<OperationStatusResult>> GetAsync(string location, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = OperationStatusClientDiagnostics.CreateScope("MockableResilienceManagementTenantResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = OperationStatusRestClient.CreateGetRequest(location, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<OperationStatusResult> response = Response.FromValue(
                    ModelReaderWriter.Read<OperationStatusResult>(result.Content, ModelSerializationExtensions.WireOptions, AzureResourceManagerResilienceManagementContext.Default),
                    result);
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
        /// Returns the current status of an async operation.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.AzureResilienceManagement/locations/{location}/operationStatuses/{operationId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OperationStatus_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="operationId"> The ID of an ongoing async operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<OperationStatusResult> Get(string location, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = OperationStatusClientDiagnostics.CreateScope("MockableResilienceManagementTenantResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = OperationStatusRestClient.CreateGetRequest(location, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<OperationStatusResult> response = Response.FromValue(
                    ModelReaderWriter.Read<OperationStatusResult>(result.Content, ModelSerializationExtensions.WireOptions, AzureResourceManagerResilienceManagementContext.Default),
                    result);
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
