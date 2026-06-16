// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseResource
    {
        /// <summary> Cancels the asynchronous operation on the database. </summary>
        /// <param name="operationId"> The operation identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response CancelDatabaseOperation(Guid operationId, CancellationToken cancellationToken = default)
            => Cancel(operationId, cancellationToken);

        /// <summary> Cancels the asynchronous operation on the database. </summary>
        /// <param name="operationId"> The operation identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> CancelDatabaseOperationAsync(Guid operationId, CancellationToken cancellationToken = default)
            => await CancelAsync(operationId, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates or updates a database extension. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the extension. </param>
        /// <param name="sqlDatabaseExtension"> The database extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ImportExportExtensionsOperationResult> CreateOrUpdateDatabaseExtension(WaitUntil waitUntil, string extensionName, SqlDatabaseExtension sqlDatabaseExtension, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, extensionName, sqlDatabaseExtension, cancellationToken);

        /// <summary> Creates or updates a database extension. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the extension. </param>
        /// <param name="sqlDatabaseExtension"> The database extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ImportExportExtensionsOperationResult>> CreateOrUpdateDatabaseExtensionAsync(WaitUntil waitUntil, string extensionName, SqlDatabaseExtension sqlDatabaseExtension, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, extensionName, sqlDatabaseExtension, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates a restore point for a database. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="createDatabaseRestorePointDefinition"> The definition for creating the restore point. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlServerDatabaseRestorePointResource> CreateRestorePoint(WaitUntil waitUntil, CreateDatabaseRestorePointDefinition createDatabaseRestorePointDefinition, CancellationToken cancellationToken = default)
            => Create(waitUntil, createDatabaseRestorePointDefinition, cancellationToken);

        /// <summary> Creates a restore point for a database. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="createDatabaseRestorePointDefinition"> The definition for creating the restore point. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<SqlServerDatabaseRestorePointResource>> CreateRestorePointAsync(WaitUntil waitUntil, CreateDatabaseRestorePointDefinition createDatabaseRestorePointDefinition, CancellationToken cancellationToken = default)
            => await CreateAsync(waitUntil, createDatabaseRestorePointDefinition, cancellationToken).ConfigureAwait(false);

        /// <summary> Gets a collection of <see cref="SqlDatabaseBlobAuditingPolicyResource"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SqlDatabaseBlobAuditingPolicyCollection GetSqlDatabaseBlobAuditingPolicies()
        {
            return GetCachedClient(client => new SqlDatabaseBlobAuditingPolicyCollection(client, Id));
        }
    }
}
