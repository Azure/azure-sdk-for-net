// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupResource : LongTermRetentionManagedInstanceBackupResource
    {
        public static new readonly ResourceType ResourceType = LongTermRetentionManagedInstanceBackupResource.ResourceType;

        protected ResourceGroupLongTermRetentionManagedInstanceBackupResource()
        {
        }

        internal ResourceGroupLongTermRetentionManagedInstanceBackupResource(ArmClient client, ManagedInstanceLongTermRetentionBackupData data) : base(client, data)
        {
        }

        internal ResourceGroupLongTermRetentionManagedInstanceBackupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
