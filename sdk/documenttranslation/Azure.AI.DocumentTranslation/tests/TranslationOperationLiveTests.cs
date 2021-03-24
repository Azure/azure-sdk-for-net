// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public class TranslationOperationLiveTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationOperationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public TranslationOperationLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        private List<string> Documents = new List<string>
        {
            "This is the first english test document",
            "This is the second english test document"
        };

        [RecordedTest]
        public async Task TranslationOperationTestAsync()
        {
            Uri source = await CreateSourceContainerAsync(Documents);
            Uri target = await CreateTargetContainerAsync();

            var client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, operation.DocumentsTotal);
            Assert.AreEqual(2, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
        }
    }
}
