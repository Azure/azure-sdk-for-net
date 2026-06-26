// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve GA add-bulk/delete-bulk shapes. Add-bulk was pageable in GA, while the
    // TypeSpec operation is an LRO action with an array final result; delete-bulk also needs manual
    // enumerable body serialization to match the generated REST client request contract.
    [CodeGenSuppress("AddBulkAsync", typeof(WaitUntil), typeof(IEnumerable<RaiBlocklistItemBulkContent>), typeof(CancellationToken))]
    [CodeGenSuppress("AddBulk", typeof(WaitUntil), typeof(IEnumerable<RaiBlocklistItemBulkContent>), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteBulkAsync", typeof(WaitUntil), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteBulk", typeof(WaitUntil), typeof(IEnumerable<string>), typeof(CancellationToken))]
    public partial class RaiBlocklistResource
    {
        /// <summary> Add multiple blocklist items to the specified blocklist associated with the Azure OpenAI connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> Properties describing the custom blocklist items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<RaiBlocklistItemResource> AddBulkAsync(WaitUntil waitUntil, IEnumerable<RaiBlocklistItemBulkContent> body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<RaiBlocklistItemData, RaiBlocklistItemResource>(new RaiBlocklistResourceAddBulkAsyncCollectionResult(
                _connectionRaiBlocklistItemRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Parent.Name,
                Id.Parent.Name,
                Id.Name,
                body,
                context), data => new RaiBlocklistItemResource(Client, data));
        }

        /// <summary> Add multiple blocklist items to the specified blocklist associated with the Azure OpenAI connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> Properties describing the custom blocklist items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<RaiBlocklistItemResource> AddBulk(WaitUntil waitUntil, IEnumerable<RaiBlocklistItemBulkContent> body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<RaiBlocklistItemData, RaiBlocklistItemResource>(new RaiBlocklistResourceAddBulkCollectionResult(
                _connectionRaiBlocklistItemRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Parent.Name,
                Id.Parent.Name,
                Id.Name,
                body,
                context), data => new RaiBlocklistItemResource(Client, data));
        }

        /// <summary> Delete multiple blocklist items from the specified blocklist associated with the Azure OpenAI connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteBulkAsync(WaitUntil waitUntil, IEnumerable<string> body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = _connectionRaiBlocklistItemClientDiagnostics.CreateScope("RaiBlocklistResource.DeleteBulk");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = MachineLearningSerializationHelpers.CreateStringEnumerableContent(body);
                HttpMessage message = _connectionRaiBlocklistItemRestClient.CreateDeleteBulkRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, content, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                MachineLearningArmOperation operation = new MachineLearningArmOperation(_connectionRaiBlocklistItemClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete multiple blocklist items from the specified blocklist associated with the Azure OpenAI connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation DeleteBulk(WaitUntil waitUntil, IEnumerable<string> body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = _connectionRaiBlocklistItemClientDiagnostics.CreateScope("RaiBlocklistResource.DeleteBulk");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = MachineLearningSerializationHelpers.CreateStringEnumerableContent(body);
                HttpMessage message = _connectionRaiBlocklistItemRestClient.CreateDeleteBulkRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, content, context);
                Response response = Pipeline.ProcessMessage(message, context);
                MachineLearningArmOperation operation = new MachineLearningArmOperation(_connectionRaiBlocklistItemClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
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
