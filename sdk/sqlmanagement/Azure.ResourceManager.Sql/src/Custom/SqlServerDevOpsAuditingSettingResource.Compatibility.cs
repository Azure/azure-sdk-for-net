// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerDevOpsAuditingSettingResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string devOpsAuditingSettingsName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, new DevOpsAuditingSettingsName(devOpsAuditingSettingsName));
    }
}
