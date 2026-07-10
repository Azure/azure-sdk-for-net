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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<DatabaseMigrationSqlMIResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(bool?), typeof(CancellationToken))]
    public partial class DatabaseMigrationSqlMIResource
    {
        /// <summary> Delete Database Migration resource. </summary>
        public virtual async Task<ArmOperation<DatabaseMigrationSqlMIResource>> DeleteAsync(WaitUntil waitUntil, bool? force = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseMigrationsSqlMiClientDiagnostics.CreateScope("DatabaseMigrationSqlMIResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _databaseMigrationsSqlMiRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, force, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation<DatabaseMigrationSqlMIResource> operation = new DataMigrationArmOperation<DatabaseMigrationSqlMIResource>(new DatabaseMigrationSqlMIResourceOperationSource(Client), _databaseMigrationsSqlMiClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary> Delete Database Migration resource. </summary>
        public virtual ArmOperation<DatabaseMigrationSqlMIResource> Delete(WaitUntil waitUntil, bool? force = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseMigrationsSqlMiClientDiagnostics.CreateScope("DatabaseMigrationSqlMIResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _databaseMigrationsSqlMiRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, force, context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation<DatabaseMigrationSqlMIResource> operation = new DataMigrationArmOperation<DatabaseMigrationSqlMIResource>(new DatabaseMigrationSqlMIResourceOperationSource(Client), _databaseMigrationsSqlMiClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
