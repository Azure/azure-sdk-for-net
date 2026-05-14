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
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupCollection : LongTermRetentionManagedInstanceBackupCollection, IEnumerable<SubscriptionLongTermRetentionManagedInstanceBackupResource>, IAsyncEnumerable<SubscriptionLongTermRetentionManagedInstanceBackupResource>
    {
        protected SubscriptionLongTermRetentionManagedInstanceBackupCollection()
        {
        }

        internal SubscriptionLongTermRetentionManagedInstanceBackupCollection(ArmClient client, ResourceIdentifier id, string locationName, string managedInstanceName, string databaseName) : base(client, id, locationName, managedInstanceName, databaseName)
        {
        }

        IEnumerator<SubscriptionLongTermRetentionManagedInstanceBackupResource> IEnumerable<SubscriptionLongTermRetentionManagedInstanceBackupResource>.GetEnumerator()
        {
            foreach (LongTermRetentionManagedInstanceBackupResource item in GetAll())
            {
                yield return new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, item.Data);
            }
        }

        async IAsyncEnumerator<SubscriptionLongTermRetentionManagedInstanceBackupResource> IAsyncEnumerable<SubscriptionLongTermRetentionManagedInstanceBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (Page<LongTermRetentionManagedInstanceBackupResource> page in GetAllAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
            {
                foreach (LongTermRetentionManagedInstanceBackupResource item in page.Values)
                {
                    yield return new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, item.Data);
                }
            }
        }
    }
}
