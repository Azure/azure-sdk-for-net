// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables.Tests;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public abstract class TablesPerfTest : PerfTest<TablePerfOptions>
    {
        private const string stringValue = "This is a string";
        private Guid guid = Guid.NewGuid();
        private DateTime dt = DateTime.UtcNow;
        private byte[] binary = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        private static TablesTestEnvironment _environment = new TablesTestEnvironment();
        private const string PartitionKey = "performance";
        private const string TableName = "perfTestTable";

        protected TablesTestEnvironment TestEnvironment => _environment;

        protected TableTransactionalBatch GetBatch() => Client?.CreateTransactionalBatch(PartitionKey);

        protected TableClient Client {get; private set; }

        public TablesPerfTest(TablePerfOptions options) : base(options)
        { }

        public override async Task GlobalSetupAsync()
        {
            var serviceUri = Options.EndpointType switch
            {
                TableEndpointType.Storage => TestEnvironment.StorageUri,
                TableEndpointType.CosmosTable => TestEnvironment.CosmosUri,
                _ => throw new NotSupportedException("Unknown endpoint type")
            };

            var accountName = Options.EndpointType switch
            {
                TableEndpointType.Storage => TestEnvironment.StorageAccountName,
                TableEndpointType.CosmosTable => TestEnvironment.CosmosAccountName,
                _ => throw new NotSupportedException("Unknown endpoint type")
            };

            var accountKey = Options.EndpointType switch
            {
                TableEndpointType.Storage => TestEnvironment.PrimaryStorageAccountKey,
                TableEndpointType.CosmosTable => TestEnvironment.PrimaryCosmosAccountKey,
                _ => throw new NotSupportedException("Unknown endpoint type")
            };

            Client = new TableClient(
                 new Uri(serviceUri),
                 TableName,
                 new TableSharedKeyCredential(accountName, accountKey),
                 new TableClientOptions());

            await Client.CreateIfNotExistsAsync().ConfigureAwait(false);

            await base.GlobalSetupAsync().ConfigureAwait(false);
        }

        public override async Task GlobalCleanupAsync()
        {
            await Client.DeleteAsync().ConfigureAwait(false);

            await base.GlobalCleanupAsync().ConfigureAwait(false);
        }

        protected IEnumerable<T> GenerateEntities<T>() where T : class, ITableEntity, new()
        {
            var entity = new T();
            return entity switch
            {
                SimplePerfEntity _ => (IEnumerable<T>)Enumerable.Range(1, Options.Count).Select(n =>
                    {
                        string number = n.ToString();
                        return new SimplePerfEntity
                        {
                            PartitionKey = PartitionKey,
                            RowKey = Guid.NewGuid().ToString(),
                            StringTypeProperty1 = stringValue,
                            StringTypeProperty2 = stringValue,
                            StringTypeProperty3 = stringValue,
                            StringTypeProperty4 = stringValue,
                            StringTypeProperty5 = stringValue,
                            StringTypeProperty6 = stringValue,
                            StringTypeProperty7 = stringValue,
                        };
                    }),
                ComplexPerfEntity _ => (IEnumerable<T>)Enumerable.Range(1, Options.Count).Select(n =>
                    {
                        string number = n.ToString();
                        return new ComplexPerfEntity
                        {
                            PartitionKey = PartitionKey,
                            RowKey = Guid.NewGuid().ToString(),
                            StringTypeProperty = "This is a string",
                            DatetimeTypeProperty = dt,
                            GuidTypeProperty = guid,
                            BinaryTypeProperty = binary,
                            Int64TypeProperty = 1234L,
                            DoubleTypeProperty = 1234.5,
                            IntTypeProperty = 1234,
                        };
                    }),
                _ => throw new InvalidOperationException("Unknown entity type")
            };
        }

        protected async Task BatchInsertEntitiesAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken) where T : class, ITableEntity, new()
        {
            await BatchInsertEntitiesInternalAsync(true, entities, cancellationToken).ConfigureAwait(false);
        }
        protected void BatchInsertEntities<T>(IEnumerable<T> entities, CancellationToken cancellationToken) where T : class, ITableEntity, new()
        {
            BatchInsertEntitiesInternalAsync(false, entities, cancellationToken).GetAwaiter().GetResult();
        }

        protected async Task BatchInsertEntitiesInternalAsync<T>(bool async, IEnumerable<T> entities, CancellationToken cancellationToken) where T : class, ITableEntity, new()
        {
            TableTransactionalBatch batch = GetBatch();

            int i = 1;
            foreach (T entity in entities)
            {
                batch.AddEntity(entity);
                i++;
                if (i % 100 == 0 || i == Options.Count)
                {
                    // Maximum batch size is 100. Submit the current batch and create a new one.
                    if (async)
                    {
                        await batch.SubmitBatchAsync(cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        batch.SubmitBatch(cancellationToken);
                    }
                    batch = GetBatch();
                }
            }
        }
    }
}
