// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionBackupResource : LongTermRetentionBackupResource
    {
        public static new readonly ResourceType ResourceType = LongTermRetentionBackupResource.ResourceType;

        protected SubscriptionLongTermRetentionBackupResource()
        {
        }

        internal SubscriptionLongTermRetentionBackupResource(ArmClient client, LongTermRetentionBackupData data) : base(client, data)
        {
        }

        internal SubscriptionLongTermRetentionBackupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
