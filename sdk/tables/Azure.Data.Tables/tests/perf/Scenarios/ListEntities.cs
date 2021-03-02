// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public sealed class ListEntities : TablesPerfTest
    {
        public ListEntities(TablePerfOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
           await base.GlobalSetupAsync().ConfigureAwait(false);

            var entities = GenerateEntities();
            TableTransactionalBatch batch = GetBatch();

            int i = 1;
            foreach (var entity in entities)
            {
                switch (Options.EntityType)
                {
                    case EntityType.Simple:
                        batch.AddEntity((SimplePerfEntity)entity);
                        break;
                    case EntityType.Complex:
                        batch.AddEntity((ComplexPerfEntity)entity);
                        break;
                    default:
                        break;
                }

                i++;
                if (i % 100 == 0)
                {
                    // Maximum batch size is 100. Submit the current batch and create a new one.
                    await batch.SubmitBatchAsync();
                    batch = GetBatch();
                }
            }
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

        }
    }
}
