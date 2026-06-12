// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionBackupCollection : LongTermRetentionBackupCollection, IEnumerable<SubscriptionLongTermRetentionBackupResource>, IAsyncEnumerable<SubscriptionLongTermRetentionBackupResource>
    {
        protected SubscriptionLongTermRetentionBackupCollection()
        {
        }

        internal SubscriptionLongTermRetentionBackupCollection(ArmClient client, ResourceIdentifier id, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) : base(client, id, locationName, longTermRetentionServerName, longTermRetentionDatabaseName)
        {
        }

        IEnumerator<SubscriptionLongTermRetentionBackupResource> IEnumerable<SubscriptionLongTermRetentionBackupResource>.GetEnumerator()
        {
            foreach (LongTermRetentionBackupResource item in GetAll())
            {
                yield return new SubscriptionLongTermRetentionBackupResource(Client, item.Data);
            }
        }

        async IAsyncEnumerator<SubscriptionLongTermRetentionBackupResource> IAsyncEnumerable<SubscriptionLongTermRetentionBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (Page<LongTermRetentionBackupResource> page in GetAllAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
            {
                foreach (LongTermRetentionBackupResource item in page.Values)
                {
                    yield return new SubscriptionLongTermRetentionBackupResource(Client, item.Data);
                }
            }
        }
    }
}
