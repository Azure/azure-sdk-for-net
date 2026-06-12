// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerDevOpsAuditingSettingCollection
    {
        public virtual Task<NullableResponse<SqlServerDevOpsAuditingSettingResource>> GetIfExistsAsync(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);

        public virtual NullableResponse<SqlServerDevOpsAuditingSettingResource> GetIfExists(string devOpsAuditingSettingsName, CancellationToken cancellationToken = default)
            => GetIfExists(new DevOpsAuditingSettingsName(devOpsAuditingSettingsName), cancellationToken);
    }
}
