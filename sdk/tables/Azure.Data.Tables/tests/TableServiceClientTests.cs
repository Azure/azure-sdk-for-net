// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using NUnit.Framework;

namespace Azure.Tables.Tests
{
    public class TableServiceClientTests : ClientTestBase
    {

        public TableServiceClientTests(bool isAsync) : base(isAsync)
        {

        }

        /// <summary>
        /// The table account name.
        /// </summary>
        private readonly string _accountName = "someaccount";

        /// <summary>
        /// The table endpoint.
        /// </summary>
        private readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");
        private readonly Uri _urlHttp = new Uri($"http://someaccount.table.core.windows.net");

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new TableServiceClient(null, new TableSharedKeyCredential(_accountName, string.Empty)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new TableServiceClient(_url, credential: null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the TablesSharedKeyCredential.");

            Assert.That(() => new TableServiceClient(_urlHttp), Throws.InstanceOf<ArgumentException>(), "The constructor should validate the Uri is https when using a SAS token.");

            Assert.That(() => new TableServiceClient(_url), Throws.Nothing, "The constructor should accept a null credential");

            Assert.That(() => new TableServiceClient(_url, new TableSharedKeyCredential(_accountName, string.Empty)), Throws.Nothing, "The constructor should accept valid arguments.");

            Assert.That(() => new TableServiceClient(_urlHttp, new TableSharedKeyCredential(_accountName, string.Empty)), Throws.Nothing, "The constructor should accept an http url.");
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            var service = InstrumentClient(new TableServiceClient(_url));

            Assert.That(() => service.GetTableClient(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the table name.");

            Assert.That(async () => await service.CreateTableAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the table name.");

            Assert.That(async () => await service.DeleteTableAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate the table name.");
        }
    }
}
