// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeBulkActions
{
    /// <summary>
    /// A class representing a BulkAction along with the instance operations that can be performed on it.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Get", typeof(CancellationToken))]
    public partial class BulkActionResource
    {
        /// <summary> Get the status of a LaunchBulkInstancesOperation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OperationStatusResult>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                using var document = await JsonDocument.ParseAsync(result.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = ModelReaderWriter.Read<OperationStatusResult>(BinaryData.FromString(document.RootElement.GetRawText()), ModelSerializationExtensions.WireOptions, AzureResourceManagerComputeBulkActionsContext.Default);
                if (value == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the status of a LaunchBulkInstancesOperation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OperationStatusResult> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                using var document = JsonDocument.Parse(result.ContentStream);
                var value = ModelReaderWriter.Read<OperationStatusResult>(BinaryData.FromString(document.RootElement.GetRawText()), ModelSerializationExtensions.WireOptions, AzureResourceManagerComputeBulkActionsContext.Default);
                if (value == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
