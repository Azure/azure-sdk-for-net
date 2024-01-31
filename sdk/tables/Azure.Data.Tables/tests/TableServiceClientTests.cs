// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableServiceClientTests : ClientTestBase
    {
        public TableServiceClientTests(bool isAsync) : base(isAsync)
        { }

        /// <summary>
        /// The table account name.
        /// </summary>
        private static string AccountName = "someaccount";

        private const string Secret = "Kg==";
        private const string TableName = "mytablename";

        /// <summary>
        /// The table endpoint.
        /// </summary>
        private static readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");
        private const string signature = "sv=2019-12-12&ss=t&srt=s&sp=rwdlacu&se=2020-08-28T23:45:30Z&st=2020-08-26T15:45:30Z&spr=https&sig=mySig&tn=someTableName";
        private static readonly Uri _urlWithTableName = new Uri($"https://someaccount.table.core.windows.net/{TableName}");
        private static readonly Uri _devUrlWIthTableName = new Uri($"https://10.0.0.1:10002/{AccountName}/{TableName}/");
        private readonly Uri _urlHttp = new Uri($"http://someaccount.table.core.windows.net");
        private readonly Uri _localHttp = new Uri("http://127.0.0.1:10002/accountName");
        private readonly Uri _localHttpSAS = new Uri($"http://127.0.0.1:10002/accountName?{signature}");

        private TableServiceClient service_Instrumented { get; set; }

        [SetUp]
        public void TestSetup()
        {
            service_Instrumented = InstrumentClient(new TableServiceClient(_url, new AzureSasCredential("sig")));
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(
                () => new TableServiceClient(null, new TableSharedKeyCredential(AccountName, string.Empty)),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should validate the url.");

            Assert.That(
                () => new TableServiceClient(_url, credential: default(TableSharedKeyCredential)),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should validate the TablesSharedKeyCredential.");

            Assert.That(
                () => new TableServiceClient(_urlHttp, new AzureSasCredential("sig")),
                Throws.InstanceOf<ArgumentException>(),
                "The constructor should validate the Uri is https when using a SAS token.");

            Assert.That(
                () => new TableServiceClient(_localHttp, new AzureSasCredential(signature)),
                Throws.Nothing,
                "The constructor should allow local http when using a SAS token.");

            Assert.That(
                () => new TableServiceClient(_localHttpSAS),
                Throws.Nothing,
                "The constructor should allow local http when using a SAS token.");

            Assert.That(
                () => new TableServiceClient(_url, default(AzureSasCredential)),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should not accept a null credential");

            Assert.That(
                () => new TableServiceClient(_url, new TableSharedKeyCredential(AccountName, string.Empty)),
                Throws.Nothing,
                "The constructor should accept valid arguments.");

            Assert.That(
                () => new TableServiceClient(_urlHttp, new TableSharedKeyCredential(AccountName, string.Empty)),
                Throws.Nothing,
                "The constructor should accept an http url.");

            Assert.That(
                () => new TableServiceClient((string)null),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should validate the connectionString");

            Assert.That(
                () => new TableServiceClient("UseDevelopmentStorage=true"),
                Throws.Nothing,
                "The constructor should accept a valid connection string");
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            var service = InstrumentClient(new TableServiceClient(_url, new AzureSasCredential("sig")));

            Assert.That(() => service.GetTableClient(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the table name.");

            Assert.That(async () => await service.CreateTableAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the table name.");

            Assert.That(async () => await service.DeleteTableAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the table name.");
        }

        [Test]
        public void AccountNameCorrectlyReturned()
        {
            Assert.That(
                () => new TableServiceClient(_url, new TableSharedKeyCredential(AccountName, string.Empty)).AccountName,
                Is.EqualTo(AccountName));

            Assert.That(
                () => new TableServiceClient("UseDevelopmentStorage=true").AccountName,
                Is.EqualTo("devstoreaccount1"));
        }

        [Test]
        public void GetSasBuilderPopulatesPermissionsAndExpiry()
        {
            var expiry = DateTimeOffset.Now.AddDays(1);
            var permissions = TableAccountSasPermissions.All;
            var resourceTypes = TableAccountSasResourceTypes.All;

            var sas = service_Instrumented.GetSasBuilder(permissions, resourceTypes, expiry);

            Assert.That(sas.Permissions, Is.EqualTo(permissions.ToPermissionsString()));
            Assert.That(sas.ExpiresOn, Is.EqualTo(expiry));
            Assert.That(sas.ResourceTypes, Is.EqualTo(resourceTypes));
        }

        [Test]
        public void GetSasBuilderPopulatesRawPermissionsAndExpiry()
        {
            var expiry = DateTimeOffset.Now.AddDays(1);
            var permissions = TableAccountSasPermissions.All;
            var resourceTypes = TableAccountSasResourceTypes.All;

            var sas = service_Instrumented.GetSasBuilder(permissions.ToPermissionsString(), resourceTypes, expiry);

            Assert.That(sas.Permissions, Is.EqualTo(permissions.ToPermissionsString()));
            Assert.That(sas.ExpiresOn, Is.EqualTo(expiry));
            Assert.That(sas.ResourceTypes, Is.EqualTo(resourceTypes));
        }

        private static IEnumerable<object[]> TableServiceClients()
        {
            var cred = new TableSharedKeyCredential(AccountName, Secret);
            var sharedKeyClient = new TableServiceClient(_url, cred);
            var connStringClient = new TableServiceClient(
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;");
            yield return new object[] { sharedKeyClient, cred };
            yield return new object[] { connStringClient, cred };
        }

        [TestCaseSource(nameof(TableServiceClients))]
        public void GenerateSasUri(TableServiceClient client, TableSharedKeyCredential cred)
        {
            TableAccountSasPermissions permissions = TableAccountSasPermissions.Add;
            TableAccountSasResourceTypes resourceTypes = TableAccountSasResourceTypes.Container;
            var expires = DateTime.Now.AddDays(1);
            var expectedSas = new TableAccountSasBuilder(permissions, resourceTypes, expires).Sign(cred);

            var actualSas = client.GenerateSasUri(permissions, resourceTypes, expires);

            Assert.AreEqual("?" + expectedSas, actualSas.Query);
        }

        [Test]
        public async Task GetStatisticsHandlesEmptyLAstUpdatedTime(
            [Values("Tue, 23 Mar 2021 18:29:21 GMT", "")]
            string date)
        {
            var response = new MockResponse(200);
            response.SetContent(
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?><StorageServiceStats><GeoReplication><Status>live</Status><LastSyncTime>{date}</LastSyncTime></GeoReplication></StorageServiceStats>");
            var mockTransport = new MockTransport(response);
            var service = InstrumentClient(new TableServiceClient(_url, new AzureSasCredential("sig"), new TableClientOptions { Transport = mockTransport }));

            await service.GetStatisticsAsync();
        }

        [Test]
        public void CreateIfNotExistsThrowsWhenTableBeingDeleted()
        {
            var transport = new MockTransport(
                request => throw new RequestFailedException(
                    (int)HttpStatusCode.Conflict,
                    null,
                    TableErrorCode.TableBeingDeleted.ToString(),
                    null));
            var client = InstrumentClient(
                new TableServiceClient(
                    new Uri($"https://example.com"),
                    new AzureSasCredential("sig"),
                    new TableClientOptions { Transport = transport }));

            Assert.ThrowsAsync<RequestFailedException>(() => client.CreateTableIfNotExistsAsync("table"));
        }

        public static IEnumerable<object[]> ValidConnStrings()
        {
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;", AccountName };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;", AccountName };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};EndpointSuffix=core.windows.net", AccountName };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};EndpointSuffix=core.windows.net", AccountName };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret}", AccountName };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret}", AccountName };
            yield return new object[] { "DefaultEndpointsProtocol=http;AccountName=localhost;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==;TableEndpoint=http://localhost:8902/;", "localhost" };
        }

        [Test]
        [TestCaseSource(nameof(ValidConnStrings))]
        public void AccountNameAndNameForConnStringCtor(string connString, string accountName)
        {
            var client = new TableServiceClient(connString, new TableClientOptions());

            Assert.AreEqual(accountName, client.AccountName);

            var tableClient = client.GetTableClient("someTable");

            Assert.AreEqual(accountName, tableClient.AccountName);
        }

        private static IEnumerable<object[]> TableClientsWithTableNameInUri()
        {
            var tokenTransport = TableAlreadyExistsTransport();
            var tokenTransportDev = TableAlreadyExistsTransport();
            var sharedKeyTransport = TableAlreadyExistsTransport();
            var sharedKeyTransportDev = TableAlreadyExistsTransport();
            var connStrTransport = TableAlreadyExistsTransport();

            var sharedKeyClient = new TableServiceClient(
                _urlWithTableName,
                new TableSharedKeyCredential(AccountName, Secret),
                new TableClientOptions { Transport = sharedKeyTransport });
            var sharedKeyClientDev = new TableServiceClient(
                _devUrlWIthTableName,
                new TableSharedKeyCredential(AccountName, Secret),
                new TableClientOptions { Transport = sharedKeyTransportDev });
            var connStringClient = new TableServiceClient(
                $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/{TableName};",
                new TableClientOptions { Transport = connStrTransport });
            var tokenCredClient = new TableServiceClient(_urlWithTableName, new MockCredential(), new TableClientOptions { Transport = tokenTransport });
            var tokenCredClientDev = new TableServiceClient(_devUrlWIthTableName, new MockCredential(), new TableClientOptions { Transport = tokenTransportDev });

            yield return new object[] { sharedKeyClient, sharedKeyTransport };
            yield return new object[] { sharedKeyClientDev, sharedKeyTransport };
            yield return new object[] { connStringClient, connStrTransport };
            yield return new object[] { tokenCredClient, tokenTransport };
            yield return new object[] { tokenCredClientDev, tokenTransportDev };
        }

        [TestCaseSource(nameof(TableClientsWithTableNameInUri))]
        public void CreateIfNotExistsDoesNotThrowWhenClientConstructedWithUriContainingTableName(TableServiceClient tableClient, MockTransport transport)
        {
            var client = InstrumentClient(tableClient);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.CreateTableIfNotExistsAsync(TableName));

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));

            ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeleteTableAsync(TableName));

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));

            ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.QueryAsync().ToEnumerableAsync());

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));

            ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.CreateTableAsync(TableName));

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));
        }

        private static IEnumerable<object[]> TableServiceClientsAllCtors()
        {
            var sharedKeyCred = new TableSharedKeyCredential(AccountName, Secret);
            var tokenCred = new MockCredential();
            var connString = $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.table.core.windows.net/;";
            var sasCred = new AzureSasCredential(signature);
            var fromTableServiceClient = new TableServiceClient(_url, sharedKeyCred).GetTableClient(TableName);

            yield return new object[] { new TableServiceClient(connString) };
            yield return new object[] { new TableServiceClient(_url, sharedKeyCred) };
            yield return new object[] { new TableServiceClient(_url, tokenCred) };
            yield return new object[] { new TableServiceClient(_url, sasCred) };
            yield return new object[] { new TableServiceClient(new Uri($"{_url}?{signature}")) };
        }

        [TestCaseSource(nameof(TableServiceClientsAllCtors))]
        public void UriPropertyIsPopulated(TableServiceClient client)
        {
            Assert.AreEqual(_url.AbsoluteUri, client.Uri.AbsoluteUri);
            Assert.That(client.Uri.AbsoluteUri, Does.Not.Contain(signature));
        }

        private static MockTransport TableAlreadyExistsTransport() =>
            new(
                _ => throw new RequestFailedException(
                    (int)HttpStatusCode.BadRequest,
                    null,
                    "bad Uri",
                    null));
    }
}
