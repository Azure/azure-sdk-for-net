// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.CosmosDB.Models;

// MPG codegen drops Collection.CreateOrUpdate for DatabaseAccount because
// `DatabaseAccountGetResults.tsp` declares the PUT op via the low-level
// `Azure.ResourceManager.Foundations.ArmCreateOperation<...>` template (chosen so the
// request body type `DatabaseAccountCreateUpdateParameters` can differ from the
// resource model `DatabaseAccountGetResults`). TCGC's resource-method classifier does
// not recognize this template and tags the op with `kind: "List"` instead of
// `kind: "Create"` (see tspCodeModel.json for `Microsoft.DocumentDB.DatabaseAccounts.createOrUpdate`).
// As a result `ResourceCollectionClientProvider.BuildCreateOrUpdateMethods` short-circuits
// (_create == null) and CosmosDBAccountCollection.CreateOrUpdate / CreateOrUpdateAsync
// are never emitted.
//
// Re-emit them here against the generated `DatabaseAccounts.CreateCreateOrUpdateRequest`
// rest method, with LRO final-state-via Location to match the spec's
// `ArmLroLocationHeader<FinalResult = DatabaseAccountGetResults>`.

namespace Azure.ResourceManager.CosmosDB
{
    public partial class CosmosDBAccountCollection
    {
        /// <summary>
        /// Creates or updates an Azure Cosmos DB database account. The "Update" method is preferred when performing updates on an account.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseAccounts_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-11-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CosmosDBAccountResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="content"> The parameters to provide for the current database account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<CosmosDBAccountResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string accountName, CosmosDBAccountCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _databaseAccountsClientDiagnostics.CreateScope("CosmosDBAccountCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseAccountsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, accountName, CosmosDBAccountCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CosmosDBArmOperation<CosmosDBAccountResource> operation = new CosmosDBArmOperation<CosmosDBAccountResource>(
                    new CosmosDBAccountOperationSource(Client),
                    _databaseAccountsClientDiagnostics,
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

        /// <summary>
        /// Creates or updates an Azure Cosmos DB database account. The "Update" method is preferred when performing updates on an account.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseAccounts_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-11-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CosmosDBAccountResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="content"> The parameters to provide for the current database account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<CosmosDBAccountResource> CreateOrUpdate(WaitUntil waitUntil, string accountName, CosmosDBAccountCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _databaseAccountsClientDiagnostics.CreateScope("CosmosDBAccountCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseAccountsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, accountName, CosmosDBAccountCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                CosmosDBArmOperation<CosmosDBAccountResource> operation = new CosmosDBArmOperation<CosmosDBAccountResource>(
                    new CosmosDBAccountOperationSource(Client),
                    _databaseAccountsClientDiagnostics,
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
