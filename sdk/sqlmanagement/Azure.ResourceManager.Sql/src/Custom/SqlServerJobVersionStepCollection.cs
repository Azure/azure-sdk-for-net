// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlServerJobVersionStepCollection : SqlServerJobStepCollection, IEnumerable<SqlServerJobVersionStepResource>, IAsyncEnumerable<SqlServerJobVersionStepResource>
    {
        protected SqlServerJobVersionStepCollection()
        {
        }

        IEnumerator<SqlServerJobVersionStepResource> IEnumerable<SqlServerJobVersionStepResource>.GetEnumerator()
        {
            foreach (SqlServerJobStepResource item in GetAll())
            {
                yield return new SqlServerJobVersionStepResource(Client, item.Data);
            }
        }

        async IAsyncEnumerator<SqlServerJobVersionStepResource> IAsyncEnumerable<SqlServerJobVersionStepResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (Page<SqlServerJobStepResource> page in GetAllAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
            {
                foreach (SqlServerJobStepResource item in page.Values)
                {
                    yield return new SqlServerJobVersionStepResource(Client, item.Data);
                }
            }
        }
    }
}
