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
    /// A class representing a collection of <see cref="BulkActionResource"/> and their operations.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Get", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ExistsAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Exists", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetIfExistsAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetIfExists", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public partial class BulkActionCollection
    {
        /// <summary> Initializes a new instance of <see cref="BulkActionCollection"/> class with a location. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="location"> The location for the resource. </param>
        internal BulkActionCollection(ArmClient client, ResourceIdentifier id, AzureLocation location) : base(client, id)
        {
            this.TryGetApiVersion(BulkActionResource.ResourceType, out string bulkActionApiVersion);
            _bulkActionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ComputeBulkActions", BulkActionResource.ResourceType.Namespace, Diagnostics);
            _bulkActionsRestClient = new BulkActions(_bulkActionsClientDiagnostics, Pipeline, Endpoint, bulkActionApiVersion ?? "2026-02-01-preview");
            _ = location;
        }

        /// <summary> Get the status of a LaunchBulkInstancesOperation. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OperationStatusResult>> GetAsync(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
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
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OperationStatusResult> Get(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
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

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                switch (result.Status)
                {
                    case 200:
                        return Response.FromValue(true, result);
                    case 404:
                        return Response.FromValue(false, result);
                    default:
                        throw new RequestFailedException(result);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                switch (result.Status)
                {
                    case 200:
                        return Response.FromValue(true, result);
                    case 404:
                        return Response.FromValue(false, result);
                    default:
                        throw new RequestFailedException(result);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<BulkActionResource>> GetIfExistsAsync(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                switch (result.Status)
                {
                    case 200:
                        var resourceId = BulkActionResource.CreateResourceIdentifier(Id.SubscriptionId, location, id);
                        return Response.FromValue(new BulkActionResource(Client, resourceId), result);
                    case 404:
                        return new NoValueResponse<BulkActionResource>(result);
                    default:
                        throw new RequestFailedException(result);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<BulkActionResource> GetIfExists(AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = _bulkActionsRestClient.CreateGetOperationStatusRequest(Guid.Parse(Id.SubscriptionId), location, id, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                switch (result.Status)
                {
                    case 200:
                        var resourceId = BulkActionResource.CreateResourceIdentifier(Id.SubscriptionId, location, id);
                        return Response.FromValue(new BulkActionResource(Client, resourceId), result);
                    case 404:
                        return new NoValueResponse<BulkActionResource>(result);
                    default:
                        throw new RequestFailedException(result);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
