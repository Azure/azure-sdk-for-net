// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerDevOpsAuditingSettingCollection
    {
        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SqlServerDevOpsAuditingSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string devOpsAuditingSettingsName, SqlServerDevOpsAuditingSettingData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), data, cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlServerDevOpsAuditingSettingResource> CreateOrUpdate(WaitUntil waitUntil, string devOpsAuditingSettingsName, SqlServerDevOpsAuditingSettingData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), data, cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SqlServerDevOpsAuditingSettingResource>> GetAsync(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetAsync(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlServerDevOpsAuditingSettingResource> Get(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => Get(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => ExistsAsync(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => Exists(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<SqlServerDevOpsAuditingSettingResource>> GetIfExistsAsync(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SqlServerDevOpsAuditingSettingResource> GetIfExists(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetIfExists(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);
    }
}
