// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public sealed class AddSimpleEntities : TablesPerfTest
    {
        public AddSimpleEntities(TablePerfOptions options) : base(options)
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
                    await Client.AddEntityAsync(entity, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    Client.AddEntity(entity, cancellationToken: cancellationToken);
                }
            }
        }
    }
}
