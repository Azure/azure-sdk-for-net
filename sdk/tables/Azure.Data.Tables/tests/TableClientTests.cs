// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Tables.Tests
{
    public class TableClientTests : ClientTestBase
    {
        public TableClientTests(bool isAsync) : base(isAsync)
        { }

        private const string TableName = "someTableName";
        private const string AccountName = "someaccount";
        private readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");
        private readonly Uri _urlHttp = new Uri($"http://someaccount.table.core.windows.net");
        private TableClient client_Instrumented { get; set; }
        private TableEntity entityWithoutPK = new TableEntity { { TableConstants.PropertyNames.RowKey, "row" } };
        private TableEntity entityWithoutRK = new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" } };
        private TableEntity validEntity = new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" }, { TableConstants.PropertyNames.RowKey, "row" } };

        [SetUp]
        public void TestSetup()
        {
            var service_Instrumented = InstrumentClient(new TableServiceClient(new Uri("https://example.com")));
            client_Instrumented = service_Instrumented.GetTableClient(TableName);
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new TableClient(null, _url, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the tableName.");

            Assert.That(() => new TableClient(TableName, null, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new TableClient(TableName, _url, new TableSharedKeyCredential(AccountName, string.Empty), new TableClientOptions()), Throws.Nothing, "The constructor should accept valid arguments.");

            Assert.That(() => new TableClient(TableName, _url, credential: null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the TablesSharedKeyCredential.");

            Assert.That(() => new TableClient(TableName, _urlHttp), Throws.InstanceOf<ArgumentException>(), "The constructor should validate the Uri is https when using a SAS token.");

            Assert.That(() => new TableClient(TableName, _url), Throws.Nothing, "The constructor should accept a null credential");

            Assert.That(() => new TableClient(TableName, _url, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.Nothing, "The constructor should accept valid arguments.");

            Assert.That(() => new TableClient(TableName, _urlHttp, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.Nothing, "The constructor should accept an http url.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await client_Instrumented.AddEntityAsync<TableEntity>(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the entity is not null.");

            Assert.That(async () => await client_Instrumented.UpsertEntityAsync<TableEntity>(null, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the entity is not null.");
            Assert.That(async () => await client_Instrumented.UpsertEntityAsync(new TableEntity { PartitionKey = null, RowKey = "row" }, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.PartitionKey}.");

            Assert.That(async () => await client_Instrumented.UpsertEntityAsync(new TableEntity { PartitionKey = "partition", RowKey = null }, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.RowKey}.");

            Assert.That(async () => await client_Instrumented.UpdateEntityAsync<TableEntity>(null, new ETag("etag"), TableUpdateMode.Replace), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the entity is not null.");
            Assert.That(async () => await client_Instrumented.UpdateEntityAsync(validEntity, default, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), "The method should validate the eTag is not null.");

            Assert.That(async () => await client_Instrumented.UpdateEntityAsync(entityWithoutPK, new ETag("etag"), TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.PartitionKey}.");

            Assert.That(async () => await client_Instrumented.UpdateEntityAsync(entityWithoutRK, new ETag("etag"), TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.RowKey}.");
        }

        [Test]
        public void GetSasBuilderPopulatesPermissionsAndExpiry()
        {
            var expiry = DateTimeOffset.Now.AddDays(1);
            var permissions = TableSasPermissions.All;

            var sas = client_Instrumented.GetSasBuilder(permissions, expiry);

            Assert.That(sas.Permissions, Is.EqualTo(permissions.ToPermissionsString()));
            Assert.That(sas.ExpiresOn, Is.EqualTo(expiry));
        }

        [Test]
        public void GetSasBuilderPopulatesRawPermissionsAndExpiry()
        {
            var expiry = DateTimeOffset.Now.AddDays(1);
            var permissions = TableSasPermissions.All;

            var sas = client_Instrumented.GetSasBuilder(permissions.ToPermissionsString(), expiry);

            Assert.That(sas.Permissions, Is.EqualTo(permissions.ToPermissionsString()));
            Assert.That(sas.ExpiresOn, Is.EqualTo(expiry));
        }
    }
}
