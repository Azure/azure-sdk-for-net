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
using Azure.ResourceManager.DataMigration.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(bool?), typeof(CancellationToken))]

    public partial class DatabaseMigrationSqlVmResource
    {
        /// <summary>
        /// Delete Database Migration resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseMigrationSqlVms_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DatabaseMigrationSqlVmResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="force"> Optional force delete boolean. If this is provided as true, migration will be deleted even if active. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<DatabaseMigrationSqlVmResource>> DeleteAsync(WaitUntil waitUntil, bool? force = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseMigrationsSqlVmClientDiagnostics.CreateScope("DatabaseMigrationSqlVmResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _databaseMigrationsSqlVmRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, force, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation<DatabaseMigrationSqlVmResource> operation = new DataMigrationArmOperation<DatabaseMigrationSqlVmResource>(
                    new DatabaseMigrationSqlVmResourceOperationSource(Client),
                    _databaseMigrationsSqlVmClientDiagnostics,
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
        /// Delete Database Migration resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DatabaseMigrationSqlVms_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DatabaseMigrationSqlVmResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="force"> Optional force delete boolean. If this is provided as true, migration will be deleted even if active. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<DatabaseMigrationSqlVmResource> Delete(WaitUntil waitUntil, bool? force = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseMigrationsSqlVmClientDiagnostics.CreateScope("DatabaseMigrationSqlVmResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _databaseMigrationsSqlVmRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, force, context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation<DatabaseMigrationSqlVmResource> operation = new DataMigrationArmOperation<DatabaseMigrationSqlVmResource>(
                    new DatabaseMigrationSqlVmResourceOperationSource(Client),
                    _databaseMigrationsSqlVmClientDiagnostics,
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
