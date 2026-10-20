// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class DataTransferDataSourceSinkTests
    {
        [TestCaseSource(nameof(DataTransferModels))]
        public void PublicConstructorSetsComponent(DataTransferDataSourceSink model, string expectedComponent)
        {
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model));

            Assert.That(document.RootElement.GetProperty("component").GetString(), Is.EqualTo(expectedComponent));
        }

        private static object[] DataTransferModels =>
        [
            new object[] { new CosmosSqlDataTransferDataSourceSink("database", "container"), "CosmosDBSql" },
            new object[] { new CosmosMongoDataTransferDataSourceSink("database", "collection"), "CosmosDBMongo" },
            new object[] { new CosmosCassandraDataTransferDataSourceSink("keyspace", "table"), "CosmosDBCassandra" },
        ];
    }
}
