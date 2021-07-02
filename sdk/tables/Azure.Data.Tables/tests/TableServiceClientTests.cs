// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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
        private readonly string _accountName = "someaccount";

        private const string Secret = "Kg==";

        /// <summary>
        /// The table endpoint.
        /// </summary>
        private readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");

        private readonly Uri _urlHttp = new Uri($"http://someaccount.table.core.windows.net");

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
                () => new TableServiceClient(null, new TableSharedKeyCredential(_accountName, string.Empty)),
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
                () => new TableServiceClient(_url, default(AzureSasCredential)),
                Throws.InstanceOf<ArgumentNullException>(),
                "The constructor should not accept a null credential");

            Assert.That(
                () => new TableServiceClient(_url, new TableSharedKeyCredential(_accountName, string.Empty)),
                Throws.Nothing,
                "The constructor should accept valid arguments.");

            Assert.That(
                () => new TableServiceClient(_urlHttp, new TableSharedKeyCredential(_accountName, string.Empty)),
                Throws.Nothing,
                "The constructor should accept an http url.");
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

        [Test]
        public void GenerateSasUri()
        {
            TableAccountSasPermissions permissions = TableAccountSasPermissions.Add;
            TableAccountSasResourceTypes resourceTypes = TableAccountSasResourceTypes.Container;
            var expires = DateTime.Now.AddDays(1);
            var cred = new TableSharedKeyCredential(_accountName, Secret);
            var client = new TableServiceClient(_url, cred);

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
    }
}
