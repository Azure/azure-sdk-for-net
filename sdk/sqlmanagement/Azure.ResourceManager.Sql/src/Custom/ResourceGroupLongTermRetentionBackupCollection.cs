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
    public partial class ResourceGroupLongTermRetentionBackupCollection : LongTermRetentionBackupCollection, IEnumerable<ResourceGroupLongTermRetentionBackupResource>, IAsyncEnumerable<ResourceGroupLongTermRetentionBackupResource>
    {
        protected ResourceGroupLongTermRetentionBackupCollection()
        {
        }

        internal ResourceGroupLongTermRetentionBackupCollection(ArmClient client, ResourceIdentifier id, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) : base(client, id, locationName, longTermRetentionServerName, longTermRetentionDatabaseName)
        {
        }

        IEnumerator<ResourceGroupLongTermRetentionBackupResource> IEnumerable<ResourceGroupLongTermRetentionBackupResource>.GetEnumerator()
        {
            foreach (LongTermRetentionBackupResource item in GetAll())
            {
                yield return new ResourceGroupLongTermRetentionBackupResource(Client, item.Data);
            }
        }

        async IAsyncEnumerator<ResourceGroupLongTermRetentionBackupResource> IAsyncEnumerable<ResourceGroupLongTermRetentionBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (Page<LongTermRetentionBackupResource> page in GetAllAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
            {
                foreach (LongTermRetentionBackupResource item in page.Values)
                {
                    yield return new ResourceGroupLongTermRetentionBackupResource(Client, item.Data);
                }
            }
        }
    }
}
