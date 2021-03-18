// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public sealed class ListSimpleEntities : TablesPerfTest
    {
        public ListSimpleEntities(TablePerfOptions options) : base(options)
        { }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync().ConfigureAwait(false);

            var entities = GenerateEntities<SimplePerfEntity>();
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

        internal Task RunInternalAsync(bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                return Client.QueryAsync<SimplePerfEntity>(cancellationToken: cancellationToken).ToEnumerableAsync();
            }
            else
            {
                Client.Query<SimplePerfEntity>(cancellationToken: cancellationToken).ToList();
                return Task.CompletedTask;
            }
        }
    }
}
