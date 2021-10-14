// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;
using Azure.Identity;
using NUnit.Framework;
using Parms = Azure.Data.Tables.TableConstants.Sas.Parameters;

namespace Azure.Data.Tables.Tests
{
    public class TableClientTests : ClientTestBase
    {
        public TableClientTests(bool isAsync) : base(isAsync)
        { }

        private const string TableName = "someTableName";
        private const string AccountName = "someaccount";
        private static readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");
        private static readonly Uri _urlWithTableName = new Uri($"https://someaccount.table.core.windows.net/" + TableName);
        private readonly Uri _urlHttp = new Uri($"http://someaccount.table.core.windows.net");
        private MockTransport _transport;
        private TableClient client { get; set; }
        private const string Secret = "Kg==";
        private TableEntity entityWithoutPK = new TableEntity { { TableConstants.PropertyNames.RowKey, "row" } };
        private TableEntity entityWithoutRK = new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" } };

        private TableEntity validEntity =
            new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" }, { TableConstants.PropertyNames.RowKey, "row" } };

        private const string signature = "sv=2019-12-12&ss=t&srt=s&sp=rwdlacu&se=2020-08-28T23:45:30Z&st=2020-08-26T15:45:30Z&spr=https&sig=mySig&tn=someTableName";

        [SetUp]
        public void TestSetup()
        {
            _transport = new MockTransport(request => new MockResponse(204));
            var service_Instrumented = InstrumentClient(
                new TableServiceClient(
                    new Uri($"https://example.com?{signature}"),
                    new AzureSasCredential("sig"),
                    new TableClientOptions { Transport = _transport }));
            client = service_Instrumented.GetTableClient(TableName);
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.Catch<ArgumentException>(
                () => new TableClient(_url, null, new TableSharedKeyCredential(AccountName, string.Empty)),
                "The constructor should validate the tableName.");

            Assert.That(
                () => new TableClient(null, TableName, new TableSharedKeyCredential(AccountName, string.Empty)),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should validate the url.");

            Assert.That(
                () => new TableClient(_url, TableName, new TableSharedKeyCredential(AccountName, string.Empty), new TableClientOptions()),
                Throws.Nothing,
                "The constructor should accept valid arguments.");

            Assert.That(
                () => new TableClient(_url, TableName, null),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should validate the TablesSharedKeyCredential.");

            Assert.That(
                () => new TableClient(_urlHttp, new AzureSasCredential(signature)),
                Throws.InstanceOf<ArgumentException>(),
                "The constructor should validate the Uri is https when using a SAS token.");

            Assert.That(
                () => new TableClient(_urlHttp, TableName, null),
                Throws.InstanceOf<ArgumentException>(),
                "The constructor should not accept a null credential");

            Assert.That(
                () => new TableClient(_urlHttp, TableName, default(TokenCredential)),
                Throws.InstanceOf<ArgumentException>(),
                "The constructor should not accept a null credential");

            Assert.That(
                () => new TableClient(_url, TableName, new TableSharedKeyCredential(AccountName, string.Empty)),
                Throws.Nothing,
                "The constructor should accept valid arguments.");

            Assert.That(
                () => new TableClient(_urlHttp, TableName, new TableSharedKeyCredential(AccountName, string.Empty)),
                Throws.Nothing,
                "The constructor should accept an http url.");

            Assert.That(
                () => new TableClient(_urlHttp, TableName, new DefaultAzureCredential(), new TableClientOptions()),
                Throws.Nothing,
                "The constructor should accept valid arguments.");
        }

        public static IEnumerable<object[]> ValidConnStrings()
        {
            yield return new object[]
            {
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;",
                AccountName,
                TableName
            };
            yield return new object[]
            {
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.microsoft.scloud:443/;",
                AccountName,
                TableName
            };
            yield return new object[]
            {
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.microsoft.scloud:443/{TableName};",
                AccountName,
                TableName
            };
            yield return new object[]
            {
                $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;", AccountName, TableName
            };
            yield return new object[]
            {
                $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.microsoft.scloud:443/;",
                AccountName,
                TableName
            };
            yield return new object[]
            {
                $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.microsoft.scloud:443/;",
                AccountName,
                AccountName
            };
            yield return new object[]
            {
                $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.microsoft.scloud:443/{AccountName};",
                AccountName,
                AccountName
            };
            yield return new object[]
            {
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};EndpointSuffix=core.windows.net", AccountName, TableName
            };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};EndpointSuffix=core.windows.net", AccountName, TableName };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret}", AccountName, TableName };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret}", AccountName, TableName };
            yield return new object[] { $"UseDevelopmentStorage=true", TableConstants.ConnectionStrings.DevStoreAccountName, TableName };
        }

        [Test]
        [TestCaseSource(nameof(ValidConnStrings))]
        public void AccountNameAndNameForConnStringCtor(string connString, string expectedAccountName, string expectedTableName)
        {
            var client = new TableClient(connString, expectedTableName, new TableClientOptions());

            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedAccountName, client.AccountName);
                    Assert.AreEqual(expectedTableName, client.Name);
                });
        }

        [Test]
        public void AccountNameAndNameForUriCtor()
        {
            var client = new TableClient(_url, TableName, new TableSharedKeyCredential(AccountName, string.Empty), new TableClientOptions());

            Assert.AreEqual(AccountName, client.AccountName);
            Assert.AreEqual(TableName, client.Name);
        }

        [Test]
        public void NoCredCtor()
        {
            var client = new TableClient(new Uri($"{_url}/{TableName}?{signature}"));

            Assert.AreEqual(AccountName, client.AccountName);
            Assert.AreEqual(TableName, client.Name);
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(
                async () => await client.AddEntityAsync<TableEntity>(null),
                Throws.InstanceOf<ArgumentNullException>(),
                "The method should validate the entity is not null.");

            Assert.That(
                async () => await client.UpsertEntityAsync<TableEntity>(null, TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentNullException>(),
                "The method should validate the entity is not null.");
            Assert.That(
                async () => await client.UpsertEntityAsync(new TableEntity { PartitionKey = null, RowKey = "row" }, TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentException>(),
                $"The method should validate the entity has a {TableConstants.PropertyNames.PartitionKey}.");

            Assert.That(
                async () => await client.UpsertEntityAsync(new TableEntity { PartitionKey = "partition", RowKey = null }, TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentException>(),
                $"The method should validate the entity has a {TableConstants.PropertyNames.RowKey}.");

            Assert.That(
                async () => await client.UpdateEntityAsync<TableEntity>(null, new ETag("etag"), TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentNullException>(),
                "The method should validate the entity is not null.");
            Assert.That(
                async () => await client.UpdateEntityAsync(validEntity, default, TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentException>(),
                "The method should validate the eTag is not null.");

            Assert.That(
                async () => await client.UpdateEntityAsync(entityWithoutPK, new ETag("etag"), TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentException>(),
                $"The method should validate the entity has a {TableConstants.PropertyNames.PartitionKey}.");

            Assert.That(
                async () => await client.UpdateEntityAsync(entityWithoutRK, new ETag("etag"), TableUpdateMode.Replace),
                Throws.InstanceOf<ArgumentException>(),
                $"The method should validate the entity has a {TableConstants.PropertyNames.RowKey}.");
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
                token.StartsWith(
                    $"{Parms.TableName}={TableName.ToLowerInvariant()}&{Parms.StartPartitionKey}={sas.PartitionKeyStart}&{Parms.EndPartitionKey}={sas.PartitionKeyEnd}&{Parms.StartRowKey}={sas.RowKeyStart}&{Parms.EndRowKey}={sas.RowKeyEnd}&{Parms.Version}=2019-02-02&{Parms.StartTime}=2020-01-01T00%3A01%3A01Z&{Parms.ExpiryTime}=2020-01-01T01%3A01%3A01Z&{Parms.IPRange}=123.45.67.89-123.65.43.21&{Parms.Permissions}=raud&{Parms.Signature}="));
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

        [Test]
        public void CreatedTableEntityPropertiesAreSerializedProperly()
        {
            var entity = new TableEntity { PartitionKey = "partitionKey", RowKey = "01", Timestamp = DateTime.Now, ETag = ETag.All };
            entity["MyFoo"] = "Bar";

            var dictEntity = entity.ToOdataAnnotatedDictionary();

            Assert.That(dictEntity["PartitionKey"], Is.EqualTo(entity.PartitionKey), "The entities should be equivalent");
            Assert.That(dictEntity["RowKey"], Is.EqualTo(entity.RowKey), "The entities should be equivalent");
            Assert.That(dictEntity["MyFoo"], Is.EqualTo(entity["MyFoo"].ToString()), "The entities should be equivalent");
            Assert.That(dictEntity.Keys, Is.EquivalentTo(new[] { "PartitionKey", "RowKey", "MyFoo" }), "Only PK, RK, and user properties should be sent");
        }

        [Test]
        public void CreatedEnumPropertiesAreSerializedProperly()
        {
            var entity = new EnumEntity
            {
                PartitionKey = "partitionKey",
                RowKey = "01",
                Timestamp = DateTime.Now,
                MyFoo = Foo.Two,
                MyNullableFoo = null,
                ETag = ETag.All
            };

            // Create the new entities.
            var dictEntity = entity.ToOdataAnnotatedDictionary();

            Assert.That(dictEntity["PartitionKey"], Is.EqualTo(entity.PartitionKey), "The entities should be equivalent");
            Assert.That(dictEntity["RowKey"], Is.EqualTo(entity.RowKey), "The entities should be equivalent");
            Assert.That(dictEntity["MyFoo"], Is.EqualTo(entity.MyFoo.ToString()), "The entities should be equivalent");
            Assert.That(dictEntity["MyNullableFoo"], Is.EqualTo(entity.MyNullableFoo), "The entities should be equivalent");
            Assert.That(dictEntity.TryGetValue(TableConstants.PropertyNames.Timestamp, out var _), Is.False, "Only PK, RK, and user properties should be sent");
        }

        [Test]
        public void EnumPropertiesAreDeSerializedProperly()
        {
            var entity = new EnumEntity
            {
                PartitionKey = "partitionKey",
                RowKey = "01",
                Timestamp = DateTime.Now,
                MyFoo = Foo.Two,
                MyNullableFoo = null,
                MyNullableFoo2 = NullableFoo.Two,
                ETag = ETag.All
            };

            // Create the new entities.
            var dictEntity = entity.ToOdataAnnotatedDictionary();
            var deserializedEntity = dictEntity.ToTableEntity<EnumEntity>();
            Assert.That(deserializedEntity.PartitionKey, Is.EqualTo(entity.PartitionKey), "The entities should be equivalent");
            Assert.That(deserializedEntity.RowKey, Is.EqualTo(entity.RowKey), "The entities should be equivalent");
            Assert.That(deserializedEntity.MyFoo.ToString(), Is.EqualTo(entity.MyFoo.ToString()), "The entities should be equivalent");
            Assert.That(deserializedEntity.MyNullableFoo.ToString(), Is.EqualTo(entity.MyNullableFoo.ToString()), "The entities should be equivalent");
            Assert.That(deserializedEntity.MyNullableFoo2.ToString(), Is.EqualTo(entity.MyNullableFoo2.ToString()), "The entities should be equivalent");
            Assert.That(dictEntity.TryGetValue(TableConstants.PropertyNames.Timestamp, out var _), Is.False, "Only PK, RK, and user properties should be sent");
        }

        [Test]
        public void RoundTripContinuationTokenWithPartitionKeyAndRowKey()
        {
            var response = new MockResponse(200);
            (string NextPartitionKey, string NextRowKey) expected = ("next-pk", "next-rk");
            response.AddHeader(new HttpHeader("x-ms-continuation-NextPartitionKey", expected.NextPartitionKey));
            response.AddHeader(new HttpHeader("x-ms-continuation-NextRowKey", expected.NextRowKey));
            var headers = new TableQueryEntitiesHeaders(response);

            var continuationToken = TableClient.CreateContinuationTokenFromHeaders(headers);
            var actual = TableClient.ParseContinuationToken(continuationToken);

            Assert.That(continuationToken, Is.EqualTo("next-pk next-rk"));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RoundTripContinuationTokenWithPartitionKeyAndNoRowKey()
        {
            var response = new MockResponse(200);
            (string NextPartitionKey, string NextRowKey) expected = ("next-pk", null);
            response.AddHeader(new HttpHeader("x-ms-continuation-NextPartitionKey", expected.NextPartitionKey));
            var headers = new TableQueryEntitiesHeaders(response);

            var continuationToken = TableClient.CreateContinuationTokenFromHeaders(headers);
            var actual = TableClient.ParseContinuationToken(continuationToken);

            Assert.That(continuationToken, Is.EqualTo("next-pk "));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NullContinuationTokenReturnsWhenWithNoPartitionKeyAndNoRowKey()
        {
            var response = new MockResponse(200);
            (string NextPartitionKey, string NextRowKey) expected = (null, null);
            var headers = new TableQueryEntitiesHeaders(response);

            var continuationToken = TableClient.CreateContinuationTokenFromHeaders(headers);
            var actual = TableClient.ParseContinuationToken(continuationToken);

            Assert.That(continuationToken, Is.Null);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void HandlesEmptyStringContinuationToken()
        {
            (string NextPartitionKey, string NextRowKey) expected = (null, null);

            var actual = TableClient.ParseContinuationToken(" ");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task ValidateUri()
        {
            await client.UpdateEntityAsync(new TableEntity("pkā", "rk"), ETag.All).ConfigureAwait(false);
            Assert.AreEqual(
                $"https://example.com/someTableName(PartitionKey='{Uri.EscapeDataString("pkā")}',RowKey='rk')?{signature}&$format=application%2Fjson%3Bodata%3Dminimalmetadata",
                _transport.Requests[0].Uri.ToString());
        }

        [Test]
        public void CreateIfNotExistsThrowsWhenTableBeingDeleted()
        {
            _transport = new MockTransport(
                request => throw new RequestFailedException(
                    (int)HttpStatusCode.Conflict,
                    null,
                    TableErrorCode.TableBeingDeleted.ToString(),
                    null));
            var service_Instrumented = InstrumentClient(
                new TableServiceClient(
                    new Uri($"https://example.com?{signature}"),
                    new AzureSasCredential("sig"),
                    new TableClientOptions { Transport = _transport }));
            client = service_Instrumented.GetTableClient(TableName);

            Assert.ThrowsAsync<RequestFailedException>(() => client.CreateIfNotExistsAsync());
        }

        private static IEnumerable<object[]> TableClientsWithTableNameInUri()
        {
            var tokenTransport = TableAlreadyExistsTransport();
            var sharedKeyTransport = TableAlreadyExistsTransport();
            var connStrTransport = TableAlreadyExistsTransport();
            var devTransport = TableAlreadyExistsTransport();

            var sharedKeyClient = new TableClient(_url, TableName, new TableSharedKeyCredential(AccountName, Secret), new TableClientOptions { Transport = sharedKeyTransport });
            var connStringClient = new TableClient(
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;",
                TableName,
                new TableClientOptions { Transport = connStrTransport });
            var devStorageClient = new TableClient("UseDevelopmentStorage=true", TableName, new TableClientOptions { Transport = devTransport });
            var tokenCredClient = new TableClient(_url, TableName, new MockCredential(), new TableClientOptions { Transport = tokenTransport });

            yield return new object[] { sharedKeyClient, sharedKeyTransport };
            yield return new object[] { connStringClient, connStrTransport };
            yield return new object[] { devStorageClient, devTransport };
            yield return new object[] { tokenCredClient, tokenTransport };
        }

        [TestCaseSource(nameof(TableClientsWithTableNameInUri))]
        public void CreateIfNotExistsDoesNotThrowWhenClientConstructedWithUriContainingTableName(TableClient tableClient, MockTransport transport)
        {
            client = InstrumentClient(tableClient);

            client.CreateIfNotExistsAsync();

            Assert.That(transport.SingleRequest.Uri.Path, Does.Not.Contain(TableName), "Path should not contain the table name");
        }

        private static IEnumerable<object[]> TableClients()
        {
            var cred = new TableSharedKeyCredential(AccountName, Secret);
            var devCred = new TableSharedKeyCredential(TableConstants.ConnectionStrings.DevStoreAccountName, TableConstants.ConnectionStrings.DevStoreAccountKey);
            var sharedKeyClient = new TableClient(_url, TableName, cred);
            var connStringClient = new TableClient(
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;",
                TableName);
            var devStorageClient = new TableClient("UseDevelopmentStorage=true", TableName);
            yield return new object[] { sharedKeyClient, cred };
            yield return new object[] { connStringClient, cred };
            yield return new object[] { devStorageClient, devCred };
        }

        [TestCaseSource(nameof(TableClients))]
        public void GenerateSasUri(TableClient client, TableSharedKeyCredential cred)
        {
            TableSasPermissions permissions = TableSasPermissions.Add;
            var expires = DateTime.Now.AddDays(1);
            var expectedSas = new TableSasBuilder(TableName, permissions, expires).Sign(cred);

            var actualSas = client.GenerateSasUri(permissions, expires);

            Assert.AreEqual("?" + expectedSas, actualSas.Query);
        }

        private static MockTransport TableAlreadyExistsTransport() =>
            new(
                _ => throw new RequestFailedException(
                    (int)HttpStatusCode.Conflict,
                    null,
                    TableErrorCode.TableAlreadyExists.ToString(),
                    null));

        public class EnumEntity : ITableEntity
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
            public Foo MyFoo { get; set; }
            public NullableFoo? MyNullableFoo { get; set; }
            public NullableFoo? MyNullableFoo2 { get; set; }
        }

        public enum Foo
        {
            One,
            Two
        }

        public enum NullableFoo
        {
            One,
            Two
        }
    }
}
