// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary>
    /// A Class representing a MySqlFlexibleServer along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MySqlFlexibleServerResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetMySqlFlexibleServerResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetMySqlFlexibleServer method.
    /// </summary>
    public partial class MySqlFlexibleServerResource : ArmResource
    {
        /// <summary>
        /// Exports the backup of the given server by creating a backup if not existing.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/backupAndExport</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupAndExport_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The required parameters for creating and exporting backup of the given server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<MySqlFlexibleServerBackupAndExportResult>> CreateBackupAndExportAsync(WaitUntil waitUntil, MySqlFlexibleServerBackupAndExportContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _backupAndExportClientDiagnostics.CreateScope("MySqlFlexibleServerResource.CreateBackupAndExport");
            scope.Start();
            try
            {
                var response = await _backupAndExportRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new FlexibleServersArmOperation2<MySqlFlexibleServerBackupAndExportResult>(new MySqlFlexibleServerBackupAndExportResultOperationSource(), _backupAndExportClientDiagnostics, Pipeline, _backupAndExportRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location)
                {
                    ResourceId = Id,
                    Endpoint = Endpoint,
                    Diagnostics = Diagnostics,
                    Pipeline = Pipeline
                };
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Exports the backup of the given server by creating a backup if not existing.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/backupAndExport</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupAndExport_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The required parameters for creating and exporting backup of the given server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<MySqlFlexibleServerBackupAndExportResult> CreateBackupAndExport(WaitUntil waitUntil, MySqlFlexibleServerBackupAndExportContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _backupAndExportClientDiagnostics.CreateScope("MySqlFlexibleServerResource.CreateBackupAndExport");
            scope.Start();
            try
            {
                var response = _backupAndExportRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new FlexibleServersArmOperation2<MySqlFlexibleServerBackupAndExportResult>(new MySqlFlexibleServerBackupAndExportResultOperationSource(), _backupAndExportClientDiagnostics, Pipeline, _backupAndExportRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location)
                {
                    ResourceId = Id,
                    Endpoint = Endpoint,
                    Diagnostics = Diagnostics,
                    Pipeline = Pipeline
                };
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
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
