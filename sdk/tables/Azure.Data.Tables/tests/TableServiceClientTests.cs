// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Data.Tables;
using NUnit.Framework;

namespace Azure.Tables.Tests
{
    public class TableServiceClientTests
    {
        /// <summary>
        /// The table account name.
        /// </summary>
        private readonly string _accountName = "someaccount";

        /// <summary>
        /// The table endpoint.
        /// </summary>
        private readonly Uri _url = new Uri($"https://someaccount.table.core.windows.net");

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new TableServiceClient(null, new TablesSharedKeyCredential(_accountName, string.Empty)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new TableServiceClient(_url, null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the TablesSharedKeyCredential.");

            Assert.That(() => new TableServiceClient(_url, new TablesSharedKeyCredential(_accountName, string.Empty)), Throws.Nothing, "The constructor should validate the url.");
        }
    }
}
