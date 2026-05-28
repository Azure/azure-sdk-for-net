// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
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
        private const string signature = "sv=2019-12-12&ss=t&srt=s&sp=rwdlacu&se=2020-08-28T23:45:30Z&st=2020-08-26T15:45:30Z&spr=https&sig=mySig&tn=someTableName";
        private static readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");
        private static readonly Uri _urlWithTableName = new Uri($"https://someaccount.table.core.windows.net/" + TableName);
        private readonly Uri _urlHttp = new Uri($"http://someaccount.table.core.windows.net");
        private readonly Uri _localHttp = new Uri("http://127.0.0.1:10002/accountName/tableName");
        private readonly Uri _localHttpSAS = new Uri($"http://127.0.0.1:10002/accountName/tableName?{signature}");
        private MockTransport _transport;
        private TableClient client { get; set; }
        private const string Secret = "Kg==";
        private TableEntity entityWithoutPK = new TableEntity { { TableConstants.PropertyNames.RowKey, "row" } };
        private TableEntity entityWithoutRK = new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" } };
        private TableEntity validEntity =
            new TableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" }, { TableConstants.PropertyNames.RowKey, "row" } };

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
                () => new TableClient(_localHttp, new AzureSasCredential(signature)),
                Throws.Nothing,
                "The constructor should allow local http when using a SAS token.");

            Assert.That(
                () => new TableClient(_localHttp),
                Throws.Nothing,
                "The constructor should allow local http when using a SAS token.");

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
                    $"{Parms.TableName}={TableName}&{Parms.StartPartitionKey}={sas.PartitionKeyStart}&{Parms.EndPartitionKey}={sas.PartitionKeyEnd}&{Parms.StartRowKey}={sas.RowKeyStart}&{Parms.EndRowKey}={sas.RowKeyEnd}&{Parms.Version}={sas.Version}&{Parms.StartTime}=2020-01-01T00%3A01%3A01Z&{Parms.ExpiryTime}=2020-01-01T01%3A01%3A01Z&{Parms.IPRange}=123.45.67.89-123.65.43.21&{Parms.Permissions}=raud&{Parms.Signature}="));
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

        // This test validates that a table entity with an enum property that has an unknown enum value is not deserialized.
        [Test]
        public void EnumPropertiesWithUnknownValuesAreNotDeserialized()
        {
            Foo foo = (Foo)3;
            NullableFoo? nullableFoo = (NullableFoo)3;
            var entity = new EnumEntity
            {
                PartitionKey = "partitionKey",
                RowKey = "01",
                Timestamp = DateTime.Now,
                MyFoo = foo,
                MyNullableFoo = nullableFoo,
                ETag = ETag.All
            };

            // Create the new entities.
            var dictEntity = entity.ToOdataAnnotatedDictionary();
            var deserializedEntity = dictEntity.ToTableEntity<EnumEntity>();
            Assert.That(deserializedEntity.PartitionKey, Is.EqualTo(entity.PartitionKey), "The entities should be equivalent");
            Assert.That(deserializedEntity.RowKey, Is.EqualTo(entity.RowKey), "The entities should be equivalent");
            Assert.That(deserializedEntity.MyFoo.ToString(), Is.EqualTo(default(Foo).ToString()), "The non-existing enum value should not be deserialized.");
            Assert.IsNull(deserializedEntity.MyNullableFoo, "The non-existing nullable enum value should not be deserialized.");
            Assert.IsNull(deserializedEntity.MyNullableFoo2, "The entities should be equivalent.");
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
            _transport = TableAlreadyExistsTransport(TableErrorCode.TableBeingDeleted);
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
            var tokenTransport = TableAlreadyExistsTransport(TableErrorCode.TableAlreadyExists);
            var tokenTransport2 = TableAlreadyExistsTransport(TableErrorCode.TableAlreadyExists);
            var sharedKeyTransport = TableAlreadyExistsTransport(TableErrorCode.TableAlreadyExists);
            var connStrTransport = TableAlreadyExistsTransport(TableErrorCode.TableAlreadyExists);
            var devTransport = TableAlreadyExistsTransport(TableErrorCode.TableAlreadyExists);

            var sharedKeyClient = new TableClient(_urlWithTableName, TableName, new TableSharedKeyCredential(AccountName, Secret), new TableClientOptions { Transport = sharedKeyTransport });
            var connStringClient = new TableClient(
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;",
                TableName,
                new TableClientOptions { Transport = connStrTransport });
            var devStorageClient = new TableClient("UseDevelopmentStorage=true", TableName, new TableClientOptions { Transport = devTransport });
            var tokenCredClient = new TableClient(_urlWithTableName, TableName, new MockCredential(), new TableClientOptions { Transport = tokenTransport });
            var tokenCredClientFromServiceClient = new TableServiceClient(_urlWithTableName, new MockCredential(), new TableClientOptions { Transport = tokenTransport2 }).GetTableClient(TableName);

            yield return new object[] { sharedKeyClient, sharedKeyTransport };
            yield return new object[] { connStringClient, connStrTransport };
            yield return new object[] { devStorageClient, devTransport };
            yield return new object[] { tokenCredClient, tokenTransport };
            yield return new object[] { tokenCredClientFromServiceClient, tokenTransport2 };
        }

        [TestCaseSource(nameof(TableClientsWithTableNameInUri))]
        public async Task CreateIfNotExistsDoesNotThrowWhenClientConstructedWithUriContainingTableName(TableClient tableClient, MockTransport transport)
        {
            client = InstrumentClient(tableClient);

            await client.CreateIfNotExistsAsync();

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
            var fromTableServiceClient = new TableServiceClient(_url, cred).GetTableClient(TableName);
            yield return new object[] { sharedKeyClient, cred };
            yield return new object[] { connStringClient, cred };
            yield return new object[] { devStorageClient, devCred };
            yield return new object[] { fromTableServiceClient, cred };
        }

        [TestCaseSource(nameof(TableClients))]
        public void GenerateSasUri(TableClient client, TableSharedKeyCredential cred)
        {
            TableSasPermissions permissions = TableSasPermissions.Add;
            var expires = DateTime.Now.AddDays(1);
            var expectedSas = new TableSasBuilder(TableName, permissions, expires).Sign(cred);

            var actualSas = client.GenerateSasUri(permissions, expires);

            Assert.AreEqual("?" + expectedSas, actualSas.Query);
            CollectionAssert.Contains(actualSas.Segments, TableName);
        }

        private static IEnumerable<object[]> TableClientsAllCtors(bool useEmulator)
        {
            Uri url;
            string connectionString;
            TableSharedKeyCredential sharedKeyCred;

            if (useEmulator)
            {
                url = new Uri("http://127.0.0.1:10002/devstoreaccount1");
                connectionString = "UseDevelopmentStorage=true";
                sharedKeyCred = new TableSharedKeyCredential("devstoreaccount1", "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==");
            }
            else
            {
                url = _url;
                connectionString = $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.core.windows.net/;";
                sharedKeyCred = new TableSharedKeyCredential(AccountName, Secret);
            }

            var tokenCred = new MockCredential();
            var sasCred = new AzureSasCredential(signature);
            var fromTableServiceClient = new TableServiceClient(url, sharedKeyCred).GetTableClient(TableName);

            yield return new object[] { new TableClient(connectionString, TableName) };
            yield return new object[] { new TableClient(url, TableName, sharedKeyCred) };
            yield return new object[] { new TableClient(url, TableName, tokenCred) };
            yield return new object[] { new TableClient(url, sasCred) };
            yield return new object[] { new TableClient(new Uri($"{url}?{signature}")) };
            yield return new object[] { fromTableServiceClient };
        }

        [TestCaseSource(nameof(TableClientsAllCtors), new object[] { false })]
        public void UriPropertyIsPopulated(TableClient client)
        {
            Assert.AreEqual(_urlWithTableName, client.Uri);
            Assert.That(client.Uri.AbsoluteUri, Does.Not.Contain(signature));
        }

        [TestCaseSource(nameof(TableClientsAllCtors), new object[] { true })]
        public void UriPropertyIsPopulatedForEmulator(TableClient client)
        {
            Assert.AreEqual(new Uri("http://127.0.0.1:10002/devstoreaccount1/" + TableName), client.Uri);
            Assert.That(client.Uri.AbsoluteUri, Does.Not.Contain(signature));
        }

        [Test]
        [NonParallelizable]
        public async Task CreateClientRespectsSingleQuoteEscapeCompatSwitch(
            [Values(true, false, null)] bool? setDisableSwitch,
            [Values(true, false, null)] bool? setDisableEnvVar)
        {
            TestAppContextSwitch ctx = null;
            TestEnvVar env = null;
            string getEntityResponse =
                "{\"odata.etag\": \"2021-03-23T18%3A28%3A39.9160983Z\", \"PartitionKey\": \"somPartition\", \"RowKey\": \"01\", \"Timestamp\": \"2021-03-23T18:28:39.9160983Z\"}";
            try
            {
                if (setDisableSwitch.HasValue)
                {
                    ctx = new TestAppContextSwitch(TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnGetEntitySwitchName, setDisableSwitch.Value.ToString());
                }
                if (setDisableEnvVar.HasValue)
                {
                    env = new TestEnvVar(TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnGetEntityEnvVar, setDisableEnvVar.Value.ToString());
                }
                var response = new MockResponse(200);
                response.SetContent(getEntityResponse);
                var transport = new MockTransport(_ => response);
                var client = new TableClient(_url, TableName, new MockCredential(), new TableClientOptions { Transport = transport });

                await client.GetEntityAsync<TableEntity>("fo'o", "ba'r");

                if (setDisableSwitch.HasValue)
                {
                    if (setDisableSwitch.Value)
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Not.Contain("''"));
                    }
                    else
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Contain("''"));
                    }
                }
                else
                {
                    if (setDisableEnvVar.HasValue && setDisableEnvVar.Value)
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Not.Contain("''"));
                    }
                    else
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Contain("''"));
                    }
                }
            }
            finally
            {
                ctx?.Dispose();
                env?.Dispose();
            }
        }

        [Test]
        [NonParallelizable]
        public async Task CreateClientRespectsSingleQuoteEscapeCompatSwitchForDelete(
            [Values(true, false, null)] bool? setDisableSwitch,
            [Values(true, false, null)] bool? setDisableEnvVar)
        {
            TestAppContextSwitch ctx = null;
            TestEnvVar env = null;
            try
            {
                if (setDisableSwitch.HasValue)
                {
                    ctx = new TestAppContextSwitch(TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnDeleteEntitySwitchName, setDisableSwitch.Value.ToString());
                }
                if (setDisableEnvVar.HasValue)
                {
                    env = new TestEnvVar(TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnDeleteEntityEnvVar, setDisableEnvVar.Value.ToString());
                }
                var response = new MockResponse(204);
                var transport = new MockTransport(_ => response);
                var client = new TableClient(_url, TableName, new MockCredential(), new TableClientOptions { Transport = transport });

                await client.DeleteEntityAsync("fo'o", "ba'r");

                if (setDisableSwitch.HasValue)
                {
                    if (setDisableSwitch.Value)
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Not.Contain("''"));
                    }
                    else
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Contain("''"));
                    }
                }
                else
                {
                    if (setDisableEnvVar.HasValue && setDisableEnvVar.Value)
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Not.Contain("''"));
                    }
                    else
                    {
                        Assert.That(WebUtility.UrlDecode(transport.SingleRequest.Uri.PathAndQuery), Does.Contain("''"));
                    }
                }
            }
            finally
            {
                ctx?.Dispose();
                env?.Dispose();
            }
        }

        [Test]
        public async Task LoggedQueryParameters()
        {
            _transport = new MockTransport(request => new MockResponse(200));
            var options = TableClientOptions.DefaultOptions;
            options.Transport = _transport;
            var service_Instrumented = InstrumentClient(
                new TableServiceClient(
                    new Uri($"https://example.com?{signature}"),
                    new AzureSasCredential("sig"),
                    options));
            client = service_Instrumented.GetTableClient(TableName);

            var messages = new List<string>();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (args, message) => messages.Add(string.Format(message, args)),
                level: EventLevel.Verbose);

            try
            {
                await client.QueryAsync<TableEntity>(filter: "myFilter", maxPerPage: 987, select: new[] { "mySelect" }).ToEnumerableAsync().ConfigureAwait(false);
            }
            catch {/* don't throw */}

            var message = messages.First(m => m.StartsWith("Request"));
            Assert.That(message, Does.Contain("myFilter"), "Path should not redact 'filter");
            Assert.That(message, Does.Contain("987"), "Path should not redact 'top");
            Assert.That(message, Does.Contain("mySelect"), "Path should not redact 'select");
        }

        private static MockTransport TableAlreadyExistsTransport(TableErrorCode errorCode)
        {
            MockResponse conflictResponse = new((int)HttpStatusCode.Conflict);
            conflictResponse.SetContent(@$"{{
  ""odata.error"": {{
    ""code"": ""{errorCode}"",
    ""message"": {{
      ""lang"": ""en-US"",
      ""value"": ""Table is being deleted.\nRequestId:7c2a1319-5002-0065-0b0e-502b52000000\nTime:2022-04-14T14:44:00.1021472Z""
    }}
  }}
}}");
            return new(_ => conflictResponse);
        }

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
