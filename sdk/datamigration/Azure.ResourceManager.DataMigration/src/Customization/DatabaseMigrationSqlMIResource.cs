// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DataMigration.Models;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: GA used param name 'input' (not 'content') and
    // param casing 'targetDBName' (not 'targetDbName').
    // @@clientName(operation::parameters.body) doesn't resolve this issue
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CreateResourceIdentifier")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Cancel")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CancelAsync")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Cutover")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CutoverAsync")]
    public partial class DatabaseMigrationSqlMIResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="managedInstanceName"> The managedInstanceName. </param>
        /// <param name="targetDBName"> The targetDBName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string targetDBName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Stop in-progress database migration to SQL Managed Instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cancel will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<ArmOperation> CancelAsync(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlMiClientDiagnostics.CreateScope("DatabaseMigrationSqlMIResource.Cancel");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlMiRestClient.CreateCancelRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlMiClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed) { await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false); }
                return operation;
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary> Stop in-progress database migration to SQL Managed Instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cancel will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual ArmOperation Cancel(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlMiClientDiagnostics.CreateScope("DatabaseMigrationSqlMIResource.Cancel");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlMiRestClient.CreateCancelRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlMiClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed) { operation.WaitForCompletionResponse(cancellationToken); }
                return operation;
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary> Initiate cutover for in-progress online database migration to SQL Managed Instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cutover will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<ArmOperation> CutoverAsync(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlMiClientDiagnostics.CreateScope("DatabaseMigrationSqlMIResource.Cutover");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlMiRestClient.CreateCutoverRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlMiClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed) { await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false); }
                return operation;
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary> Initiate cutover for in-progress online database migration to SQL Managed Instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cutover will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual ArmOperation Cutover(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlMiClientDiagnostics.CreateScope("DatabaseMigrationSqlMIResource.Cutover");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlMiRestClient.CreateCutoverRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlMiClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed) { operation.WaitForCompletionResponse(cancellationToken); }
                return operation;
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }
    }
}
