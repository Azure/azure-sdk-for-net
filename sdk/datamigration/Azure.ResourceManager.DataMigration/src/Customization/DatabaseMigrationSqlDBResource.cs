// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DataMigration.Models;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: GA used param name 'input' (not 'content') and
    // param casing 'sqlDBInstanceName'/'targetDBName' (not 'sqlDbInstanceName'/'targetDbName').
    // @@clientName(operation::parameters.body) doesn't resolve this issue
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CreateResourceIdentifier")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Cancel")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CancelAsync")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Retry")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("RetryAsync")]
    public partial class DatabaseMigrationSqlDBResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="sqlDBInstanceName"> The sqlDBInstanceName. </param>
        /// <param name="targetDBName"> The targetDBName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlDBInstanceName, string targetDBName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDBInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary>
        /// Stop on going migration for the database.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cancel. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseMigrationSqlDbs_Cancel. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DatabaseMigrationSqlDBResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="input"> Required migration operation ID for which cancel will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<ArmOperation> CancelAsync(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            using DiagnosticScope scope = _databaseMigrationsSqlDbClientDiagnostics.CreateScope("DatabaseMigrationSqlDBResource.Cancel");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlDbRestClient.CreateCancelRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlDbClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Stop on going migration for the database.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cancel. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseMigrationSqlDbs_Cancel. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DatabaseMigrationSqlDBResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="input"> Required migration operation ID for which cancel will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual ArmOperation Cancel(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            using DiagnosticScope scope = _databaseMigrationsSqlDbClientDiagnostics.CreateScope("DatabaseMigrationSqlDBResource.Cancel");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlDbRestClient.CreateCancelRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlDbClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Retry on going migration for the database.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/retry. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseMigrationSqlDbs_Retry. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DatabaseMigrationSqlDBResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="input"> Required migration operation ID for which retry will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<ArmOperation<DatabaseMigrationSqlDBResource>> RetryAsync(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            using DiagnosticScope scope = _databaseMigrationsSqlDbClientDiagnostics.CreateScope("DatabaseMigrationSqlDBResource.Retry");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlDbRestClient.CreateRetryRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation<DatabaseMigrationSqlDBResource> operation = new DataMigrationArmOperation<DatabaseMigrationSqlDBResource>(
                    new DatabaseMigrationSqlDBOperationSource(Client),
                    _databaseMigrationsSqlDbClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
        /// Retry on going migration for the database.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/retry. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseMigrationSqlDbs_Retry. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DatabaseMigrationSqlDBResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="input"> Required migration operation ID for which retry will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual ArmOperation<DatabaseMigrationSqlDBResource> Retry(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            using DiagnosticScope scope = _databaseMigrationsSqlDbClientDiagnostics.CreateScope("DatabaseMigrationSqlDBResource.Retry");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlDbRestClient.CreateRetryRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation<DatabaseMigrationSqlDBResource> operation = new DataMigrationArmOperation<DatabaseMigrationSqlDBResource>(
                    new DatabaseMigrationSqlDBOperationSource(Client),
                    _databaseMigrationsSqlDbClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
