// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Azure.Data.Tables.Sas;
using NUnit.Framework;
using Parms = Azure.Data.Tables.TableConstants.Sas.Parameters;

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
        private TableClient client { get; set; }
        private TableEntity entityWithoutPK = new TableEntity { { TableConstants.PropertyNames.RowKey, "row" } };
        private TableEntity entityWithoutRK = new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" } };
        private TableEntity validEntity = new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" }, { TableConstants.PropertyNames.RowKey, "row" } };

        [SetUp]
        public void TestSetup()
        {
            var service_Instrumented = InstrumentClient(new TableServiceClient(new Uri("https://example.com"), new TableClientOptions()));
            client = service_Instrumented.GetTableClient(TableName);
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new TableClient(_url, null, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the tableName.");

            Assert.That(() => new TableClient(null, TableName, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new TableClient(_url, TableName, new TableSharedKeyCredential(AccountName, string.Empty), new TableClientOptions()), Throws.Nothing, "The constructor should accept valid arguments.");

            Assert.That(() => new TableClient(_url, TableName, credential: null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the TablesSharedKeyCredential.");

            Assert.That(() => new TableClient(_urlHttp, TableName), Throws.InstanceOf<ArgumentException>(), "The constructor should validate the Uri is https when using a SAS token.");

            Assert.That(() => new TableClient(_url, TableName), Throws.Nothing, "The constructor should accept a null credential");

            Assert.That(() => new TableClient(_url, TableName, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.Nothing, "The constructor should accept valid arguments.");

            Assert.That(() => new TableClient(_urlHttp, TableName, new TableSharedKeyCredential(AccountName, string.Empty)), Throws.Nothing, "The constructor should accept an http url.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await client.AddEntityAsync<TableEntity>(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the entity is not null.");

            Assert.That(async () => await client.UpsertEntityAsync<TableEntity>(null, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the entity is not null.");
            Assert.That(async () => await client.UpsertEntityAsync(new TableEntity { PartitionKey = null, RowKey = "row" }, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.PartitionKey}.");

            Assert.That(async () => await client.UpsertEntityAsync(new TableEntity { PartitionKey = "partition", RowKey = null }, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.RowKey}.");

            Assert.That(async () => await client.UpdateEntityAsync<TableEntity>(null, new ETag("etag"), TableUpdateMode.Replace), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the entity is not null.");
            Assert.That(async () => await client.UpdateEntityAsync(validEntity, default, TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), "The method should validate the eTag is not null.");

            Assert.That(async () => await client.UpdateEntityAsync(entityWithoutPK, new ETag("etag"), TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.PartitionKey}.");

            Assert.That(async () => await client.UpdateEntityAsync(entityWithoutRK, new ETag("etag"), TableUpdateMode.Replace), Throws.InstanceOf<ArgumentException>(), $"The method should validate the entity has a {TableConstants.PropertyNames.RowKey}.");
        }

        [Test]
        public void GetSasBuilderPopulatesPermissionsAndExpiry()
        {
            var expiry = DateTimeOffset.Now.AddDays(1);
            var permissions = TableSasPermissions.All;

            var sas = client.GetSasBuilder(permissions, expiry);

            Assert.That(sas.Permissions, Is.EqualTo(permissions.ToPermissionsString()));
            Assert.That(sas.ExpiresOn, Is.EqualTo(expiry));
        }

        [Test]
        public void GetSasBuilderPopulatesRawPermissionsAndExpiry()
        {
            var expiry = DateTimeOffset.Now.AddDays(1);
            var permissions = TableSasPermissions.All;

            var sas = client.GetSasBuilder(permissions.ToPermissionsString(), expiry);

            Assert.That(sas.Permissions, Is.EqualTo(permissions.ToPermissionsString()));
            Assert.That(sas.ExpiresOn, Is.EqualTo(expiry));
        }

        [Test]
        public void GetSasBuilderGeneratesCorrectUri()
        {
            var expiry = new DateTimeOffset(2020, 1, 1, 1, 1, 1, TimeSpan.Zero);
            var permissions = TableSasPermissions.All;

            var sas = client.GetSasBuilder(permissions.ToPermissionsString(), expiry);

            const string startIP = "123.45.67.89";
            const string endIP = "123.65.43.21";
            sas.IPRange = new TableSasIPRange(IPAddress.Parse(startIP), IPAddress.Parse(endIP));
            sas.PartitionKeyEnd = "PKEND";
            sas.PartitionKeyStart = "PKSTART";
            sas.RowKeyEnd = "PKEND";
            sas.RowKeyStart = "RKSTART";
            sas.StartsOn = expiry.AddHours(-1);

            string token = sas.Sign(new TableSharedKeyCredential("foo", "Kg=="));

            Assert.That(
                token,
                Is.EqualTo(
                    $"{Parms.TableName}={TableName}&{Parms.StartPartitionKey}={sas.PartitionKeyStart}&{Parms.EndPartitionKey}={sas.PartitionKeyEnd}&{Parms.StartRowKey}={sas.RowKeyStart}&{Parms.EndRowKey}={sas.RowKeyEnd}&{Parms.Version}=2019-02-02&{Parms.StartTime}=2020-01-01T00%3A01%3A01Z&{Parms.ExpiryTime}=2020-01-01T01%3A01%3A01Z&{Parms.IPRange}=123.45.67.89-123.65.43.21&{Parms.Permissions}=raud&{Parms.Signature}=nUfFBSzJ7NckYoHxSeX5nKcVbqJDBJQfPpGffr5Ui2M%3D"));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public void CreatedTableEntityEnumEntitiesThrowNotSupported()
        {
            var entityToCreate = new TableEntity { PartitionKey = "partitionKey", RowKey = "01" };
            entityToCreate["MyFoo"] = Foo.Two;

            // Create the new entities.
            Assert.ThrowsAsync<NotSupportedException>(async () => await client.AddEntityAsync(entityToCreate).ConfigureAwait(false));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public void CreatedEnumPropertiesAreSerializedProperly()
        {
            var entity = new EnumEntity { PartitionKey = "partitionKey", RowKey = "01", Timestamp = DateTime.Now, MyFoo = Foo.Two, ETag = ETag.All };

            // Create the new entities.
            var dictEntity = entity.ToOdataAnnotatedDictionary();

            Assert.That(dictEntity["PartitionKey"], Is.EqualTo(entity.PartitionKey), "The entities should be equivalent");
            Assert.That(dictEntity["RowKey"], Is.EqualTo(entity.RowKey), "The entities should be equivalent");
            Assert.That(dictEntity["MyFoo"], Is.EqualTo(entity.MyFoo.ToString()), "The entities should be equivalent");
        }

        public class EnumEntity : ITableEntity
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
            public Foo MyFoo { get; set; }
        }
        public enum Foo
        {
            One,
            Two
        }
    }
}
