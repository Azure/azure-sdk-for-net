// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    public partial class ContainerDocumentTranslationClientTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerDocumentTranslationClientTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ContainerDocumentTranslationClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Before running this test make sure you have docker application running and then run the Translator container
        [Test]
        [Ignore("Container Test only")]
        public async Task StartSynchronousDocumentTranslation()
        {
            //Once the container is running, note the endpoint it is listening on and update accordingly
            var endpoint = new Uri("http://localhost:5000");

            SingleDocumentTranslationClient client = new SingleDocumentTranslationClient(endpoint);

            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
            DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);

            //make sure this language model "hi" is downloaded
            var response = await client.TranslateAsync("hi", content, "en").ConfigureAwait(false);
            var requestString = File.ReadAllText(filePath);
            var responseString = Encoding.UTF8.GetString(response.Value.ToArray());
            Assert.IsNotEmpty(responseString);
            Assert.IsNotNull(responseString);
            Assert.AreNotEqual(requestString, responseString);
        }
    }
}
