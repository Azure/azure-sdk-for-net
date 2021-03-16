// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public class DocumentTranslationClientLiveTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentTranslationClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public void ClientCannotAuthenticateWithFakeApiKey()
        {
            var client = GetClient(credential: new AzureKeyCredential("fakeKey"));

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetDocumentFormatsAsync());
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task GetDocumentFormatsTestAsync()
        {
            var client = GetClient();

            var pepe = await client.GetDocumentFormatsAsync();
            Assert.GreaterOrEqual(pepe.Value.Count, 0);
        }
    }
}
