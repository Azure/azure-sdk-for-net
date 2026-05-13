// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class ResourceGroupLongTermRetentionBackupResource : LongTermRetentionBackupResource
    {
        protected ResourceGroupLongTermRetentionBackupResource()
        {
        }

        internal ResourceGroupLongTermRetentionBackupResource(ArmClient client, LongTermRetentionBackupData data) : base(client, data)
        {
        }

        internal ResourceGroupLongTermRetentionBackupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
