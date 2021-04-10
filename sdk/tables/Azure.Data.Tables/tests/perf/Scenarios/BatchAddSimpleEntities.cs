// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public sealed class BatchAddSimpleEntities : TablesPerfTest
    {
        public BatchAddSimpleEntities(TablePerfOptions options) : base(options)
        { }

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
            var entities = GenerateEntities<SimplePerfEntity>();

            foreach (var entity in entities)
            {
                if (async)
                {
                    await BatchInsertEntitiesAsync(entities, cancellationToken);
                }
                else
                {
                    BatchInsertEntities(entities, cancellationToken);
                }
            }
        }
    }
}
