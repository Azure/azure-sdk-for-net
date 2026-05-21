// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compatible parameter names: the TypeSpec generator emits "content" for body params
// and uses camelCase path params (e.g. targetDbName), but the GA 1.0.0 SDK used "input" and
// "targetDBName"/"sqlDBInstanceName". These shims preserve the old param names for source
// compatibility with callers using named arguments.

#pragma warning disable SA1402, CS1591

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DataMigration.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    // ── DatabaseMigrationSqlDBResource ──
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("CancelAsync", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("Cancel", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("RetryAsync", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("Retry", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    public partial class DatabaseMigrationSqlDBResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DatabaseMigrationSqlDBResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="sqlDBInstanceName"> The sqlDBInstanceName. </param>
        /// <param name="targetDBName"> The targetDBName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlDBInstanceName, string targetDBName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDBInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Stop on going migration for the database. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
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
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Stop on going migration for the database. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
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
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retry on going migration for the database. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
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
                    _databaseMigrationsSqlDbClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
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

        /// <summary> Retry on going migration for the database. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
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
                    _databaseMigrationsSqlDbClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
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

    // ── DatabaseMigrationSqlMIResource ──
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("CancelAsync", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("Cancel", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("CutoverAsync", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("Cutover", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    public partial class DatabaseMigrationSqlMIResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DatabaseMigrationSqlMIResource"/> instance. </summary>
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
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }

    // ── DatabaseMigrationSqlVmResource ──
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("CancelAsync", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("Cancel", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("CutoverAsync", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    [CodeGenSuppress("Cutover", typeof(WaitUntil), typeof(MigrationOperationInput), typeof(CancellationToken))]
    public partial class DatabaseMigrationSqlVmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DatabaseMigrationSqlVmResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="sqlVirtualMachineName"> The sqlVirtualMachineName. </param>
        /// <param name="targetDBName"> The targetDBName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineName, string targetDBName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Stop in-progress database migration to SQL VM. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cancel will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<ArmOperation> CancelAsync(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlVmClientDiagnostics.CreateScope("DatabaseMigrationSqlVmResource.Cancel");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlVmRestClient.CreateCancelRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlVmClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Stop in-progress database migration to SQL VM. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cancel will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual ArmOperation Cancel(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlVmClientDiagnostics.CreateScope("DatabaseMigrationSqlVmResource.Cancel");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlVmRestClient.CreateCancelRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlVmClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initiate cutover for in-progress online database migration to SQL VM. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cutover will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<ArmOperation> CutoverAsync(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlVmClientDiagnostics.CreateScope("DatabaseMigrationSqlVmResource.Cutover");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlVmRestClient.CreateCutoverRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlVmClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initiate cutover for in-progress online database migration to SQL VM. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="input"> Required migration operation ID for which cutover will be initiated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual ArmOperation Cutover(WaitUntil waitUntil, MigrationOperationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            using DiagnosticScope scope = _databaseMigrationsSqlVmClientDiagnostics.CreateScope("DatabaseMigrationSqlVmResource.Cutover");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseMigrationsSqlVmRestClient.CreateCutoverRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MigrationOperationInput.ToRequestContent(input), context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataMigrationArmOperation operation = new DataMigrationArmOperation(_databaseMigrationsSqlVmClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
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
