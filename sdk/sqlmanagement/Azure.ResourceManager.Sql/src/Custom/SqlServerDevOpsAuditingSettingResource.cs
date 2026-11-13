// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerDevOpsAuditingSettingResource
    {
        /// <summary> Backward-compatible overload that accepts a <see cref="string"/> for the auditing setting name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string devOpsAuditingSettingsName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, new DevOpsAuditingSettingsName(devOpsAuditingSettingsName));
    }
}
