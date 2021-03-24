// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public class TranslationOperationLiveTests : DocumentTranslationLiveTestBase
    {
        public TranslationOperationLiveTests(bool isAsync) : base(isAsync) { }

        private List<string> Documents = new List<string>
        {
            "This is the first english test document",
            "This is the second english test document"
        };

        [Test]
        public async Task TranslationOperationTest()
        {
            Uri source = await CreateSourceContainerAsync(Documents);
            Uri target = await CreateTargetContainerAsync();
            Uri endpoint = new Uri(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var client = new DocumentTranslationClient(endpoint, credential);

            var input = new DocumentTranslationInput(source, target, "fr");
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, operation.DocumentsTotal);
            Assert.AreEqual(2, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
        }
    }
}
