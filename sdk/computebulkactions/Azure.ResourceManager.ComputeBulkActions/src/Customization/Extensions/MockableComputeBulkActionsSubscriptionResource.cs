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
using Azure.ResourceManager.ComputeBulkActions.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeBulkActions.Mocking
{
    /// <summary> A class to add extension methods to <see cref="Azure.ResourceManager.Resources.SubscriptionResource"/>. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetOperationStatusAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetOperationStatus", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public partial class MockableComputeBulkActionsSubscriptionResource
    {
        /// <summary> Get the status of a LaunchBulkInstancesOperation. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OperationStatusResult>> GetOperationStatusAsync(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = BulkActionsClientDiagnostics.CreateScope("MockableComputeBulkActionsSubscriptionResource.GetOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = BulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<OperationStatusResult> response = Response.FromValue(ReadOperationStatusResult(result), result);
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

        /// <summary> Get the status of a LaunchBulkInstancesOperation. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OperationStatusResult> GetOperationStatus(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = BulkActionsClientDiagnostics.CreateScope("MockableComputeBulkActionsSubscriptionResource.GetOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = BulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<OperationStatusResult> response = Response.FromValue(ReadOperationStatusResult(result), result);
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

        private static OperationStatusResult ReadOperationStatusResult(Response result)
        {
            // Work around a management generator issue: framework response types are emitted with the
            // contextless ModelReaderWriter.Read<T>(BinaryData) overload, which fails AOT/trimming analysis.
            return ModelReaderWriter.Read<OperationStatusResult>(
                result.Content,
                ModelSerializationExtensions.WireOptions,
                AzureResourceManagerComputeBulkActionsContext.Default);
        }
    }
}
