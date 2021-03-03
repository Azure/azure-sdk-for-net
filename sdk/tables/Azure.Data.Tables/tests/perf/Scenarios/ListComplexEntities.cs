// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public sealed class ListComplexEntities : TablesPerfTest
    {
        public ListComplexEntities(TablePerfOptions options) : base(options)
        { }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync().ConfigureAwait(false);

            var entities = GenerateEntities<ComplexPerfEntity>();
            await BatchInsertEntitiesAsync(entities, default).ConfigureAwait(false);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            RunInternalAsync(false, cancellationToken).GetAwaiter().GetResult();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await RunInternalAsync(true, cancellationToken).ConfigureAwait(false);
        }

        internal async Task RunInternalAsync(bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                await Client.QueryAsync<ComplexPerfEntity>(cancellationToken: cancellationToken).ToEnumerableAsync().ConfigureAwait(false);
            }
            else
            {
                Client.Query<ComplexPerfEntity>(cancellationToken: cancellationToken).ToList();
            }
        }
    }
}
