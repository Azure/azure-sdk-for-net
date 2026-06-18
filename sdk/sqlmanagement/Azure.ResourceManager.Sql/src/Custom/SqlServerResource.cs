// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerResource
    {
        /// <summary> Backward-compatible overload that accepts the strongly-typed <see cref="VulnerabilityAssessmentName"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SqlServerSqlVulnerabilityAssessmentResource> GetSqlServerSqlVulnerabilityAssessment(VulnerabilityAssessmentName vulnerabilityAssessmentName, CancellationToken cancellationToken = default)
            => GetSqlServerSqlVulnerabilityAssessment(vulnerabilityAssessmentName.ToString(), cancellationToken);

        /// <summary> Backward-compatible overload that accepts the strongly-typed <see cref="VulnerabilityAssessmentName"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<SqlServerSqlVulnerabilityAssessmentResource>> GetSqlServerSqlVulnerabilityAssessmentAsync(VulnerabilityAssessmentName vulnerabilityAssessmentName, CancellationToken cancellationToken = default)
            => GetSqlServerSqlVulnerabilityAssessmentAsync(vulnerabilityAssessmentName.ToString(), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the DevOps auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SqlServerDevOpsAuditingSettingResource> GetSqlServerDevOpsAuditingSetting(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetSqlServerDevOpsAuditingSetting(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the DevOps auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<SqlServerDevOpsAuditingSettingResource>> GetSqlServerDevOpsAuditingSettingAsync(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetSqlServerDevOpsAuditingSettingAsync(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible no-expand overload of <see cref="GetSqlDatabase(string, string, string, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SqlDatabaseResource> GetSqlDatabase(string databaseName, CancellationToken cancellationToken)
            => GetSqlDatabase(databaseName, expand: null, filter: null, cancellationToken);

        /// <summary> Backward-compatible no-expand overload of <see cref="GetSqlDatabaseAsync(string, string, string, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<SqlDatabaseResource>> GetSqlDatabaseAsync(string databaseName, CancellationToken cancellationToken)
            => GetSqlDatabaseAsync(databaseName, expand: null, filter: null, cancellationToken);

        /// <summary> Backward-compatible no-expand overload of <see cref="GetRecoverableDatabase(string, string, string, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<RecoverableDatabaseResource> GetRecoverableDatabase(string databaseName, CancellationToken cancellationToken)
            => GetRecoverableDatabase(databaseName, expand: null, filter: null, cancellationToken);

        /// <summary> Backward-compatible no-expand overload of <see cref="GetRecoverableDatabaseAsync(string, string, string, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<RecoverableDatabaseResource>> GetRecoverableDatabaseAsync(string databaseName, CancellationToken cancellationToken)
            => GetRecoverableDatabaseAsync(databaseName, expand: null, filter: null, cancellationToken);

        /// <summary> Backward-compatible no-expand overload of <see cref="GetRestorableDroppedDatabase(string, string, string, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<RestorableDroppedDatabaseResource> GetRestorableDroppedDatabase(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
            => GetRestorableDroppedDatabase(restorableDroppedDatabaseId, expand: null, filter: null, cancellationToken);

        /// <summary> Backward-compatible no-expand overload of <see cref="GetRestorableDroppedDatabaseAsync(string, string, string, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<RestorableDroppedDatabaseResource>> GetRestorableDroppedDatabaseAsync(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
            => GetRestorableDroppedDatabaseAsync(restorableDroppedDatabaseId, expand: null, filter: null, cancellationToken);

        /// <summary> Backward-compatible alias for <see cref="Create(WaitUntil, TdeCertificate, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation CreateTdeCertificate(WaitUntil waitUntil, TdeCertificate tdeCertificate, CancellationToken cancellationToken = default)
            => Create(waitUntil, tdeCertificate, cancellationToken);

        /// <summary> Backward-compatible alias for <see cref="CreateAsync(WaitUntil, TdeCertificate, CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> CreateTdeCertificateAsync(WaitUntil waitUntil, TdeCertificate tdeCertificate, CancellationToken cancellationToken = default)
            => CreateAsync(waitUntil, tdeCertificate, cancellationToken);

        /// <summary> Backward-compatible alias for <see cref="GetByServer(CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<SqlServerDatabaseReplicationLinkResource> GetReplicationLinks(CancellationToken cancellationToken = default)
            => GetByServer(cancellationToken);

        /// <summary> Backward-compatible alias for <see cref="GetByServerAsync(CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<SqlServerDatabaseReplicationLinkResource> GetReplicationLinksAsync(CancellationToken cancellationToken = default)
            => GetByServerAsync(cancellationToken);

        /// <summary> Backward-compatible alias for <see cref="GetInaccessibleByServer(CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<SqlDatabaseResource> GetInaccessibleDatabases(CancellationToken cancellationToken = default)
            => GetInaccessibleByServer(cancellationToken);

        /// <summary> Backward-compatible alias for <see cref="GetInaccessibleByServerAsync(CancellationToken)"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<SqlDatabaseResource> GetInaccessibleDatabasesAsync(CancellationToken cancellationToken = default)
            => GetInaccessibleByServerAsync(cancellationToken);
    }
}
