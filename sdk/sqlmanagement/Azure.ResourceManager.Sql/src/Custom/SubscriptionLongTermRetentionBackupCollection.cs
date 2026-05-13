// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionBackupCollection : LongTermRetentionBackupCollection
    {
        protected SubscriptionLongTermRetentionBackupCollection()
        {
        }

        internal SubscriptionLongTermRetentionBackupCollection(ArmClient client, ResourceIdentifier id, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) : base(client, id, locationName, longTermRetentionServerName, longTermRetentionDatabaseName)
        {
        }
    }
}
