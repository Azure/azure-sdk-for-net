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
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupCollection : LongTermRetentionManagedInstanceBackupCollection, IEnumerable<ResourceGroupLongTermRetentionManagedInstanceBackupResource>, IAsyncEnumerable<ResourceGroupLongTermRetentionManagedInstanceBackupResource>
    {
        protected ResourceGroupLongTermRetentionManagedInstanceBackupCollection()
        {
        }

        internal ResourceGroupLongTermRetentionManagedInstanceBackupCollection(ArmClient client, ResourceIdentifier id, string locationName, string managedInstanceName, string databaseName) : base(client, id, locationName, managedInstanceName, databaseName)
        {
        }

        IEnumerator<ResourceGroupLongTermRetentionManagedInstanceBackupResource> IEnumerable<ResourceGroupLongTermRetentionManagedInstanceBackupResource>.GetEnumerator()
        {
            foreach (LongTermRetentionManagedInstanceBackupResource item in GetAll())
            {
                yield return new ResourceGroupLongTermRetentionManagedInstanceBackupResource(Client, item.Data);
            }
        }

        async IAsyncEnumerator<ResourceGroupLongTermRetentionManagedInstanceBackupResource> IAsyncEnumerable<ResourceGroupLongTermRetentionManagedInstanceBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (Page<LongTermRetentionManagedInstanceBackupResource> page in GetAllAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
            {
                foreach (LongTermRetentionManagedInstanceBackupResource item in page.Values)
                {
                    yield return new ResourceGroupLongTermRetentionManagedInstanceBackupResource(Client, item.Data);
                }
            }
        }
    }
}
