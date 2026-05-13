// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupCollection : LongTermRetentionManagedInstanceBackupCollection
    {
        protected SubscriptionLongTermRetentionManagedInstanceBackupCollection()
        {
        }

        internal SubscriptionLongTermRetentionManagedInstanceBackupCollection(ArmClient client, ResourceIdentifier id, string locationName, string managedInstanceName, string databaseName) : base(client, id, locationName, managedInstanceName, databaseName)
        {
        }
    }
}
