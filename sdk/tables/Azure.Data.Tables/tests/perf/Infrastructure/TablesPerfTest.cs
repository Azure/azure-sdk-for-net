// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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

        protected TableTransactionalBatch GetBatch() => _client?.CreateTransactionalBatch(PartitionKey);

        private TableClient _client;

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

            _client = new TableClient(
                 new Uri(serviceUri),
                 TableName,
                 new TableSharedKeyCredential(accountName, accountKey),
                 new TableClientOptions());

            await _client.CreateIfNotExistsAsync().ConfigureAwait(false);

            await base.GlobalSetupAsync().ConfigureAwait(false);
        }

        public override async Task GlobalCleanupAsync()
        {
            await _client.DeleteAsync().ConfigureAwait(false);

            await base.GlobalCleanupAsync().ConfigureAwait(false);
        }

        protected IEnumerable<ITableEntity> GenerateEntities() => Options.EntityType switch
        {
            EntityType.Simple => Enumerable.Range(1, Options.Count).Select(n =>
                {
                    string number = n.ToString();
                    return new SimplePerfEntity
                    {
                        PartitionKey = PartitionKey,
                        RowKey = n.ToString("D4"),
                        StringTypeProperty1 = stringValue,
                        StringTypeProperty2 = stringValue,
                        StringTypeProperty3 = stringValue,
                        StringTypeProperty4 = stringValue,
                        StringTypeProperty5 = stringValue,
                        StringTypeProperty6 = stringValue,
                        StringTypeProperty7 = stringValue,
                    };
                }),
            EntityType.Complex => Enumerable.Range(1, Options.Count).Select(n =>
                {
                    string number = n.ToString();
                    return new ComplexPerfEntity
                    {
                        PartitionKey = PartitionKey,
                        RowKey = n.ToString("D4"),
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
}
