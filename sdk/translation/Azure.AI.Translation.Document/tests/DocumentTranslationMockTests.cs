// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    public class DocumentTranslationMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public DocumentTranslationMockTests(bool isAsync) : base(isAsync)
        {
        }

        private DocumentTranslationClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new DocumentTranslationClientOptions()
            {
                Transport = transport
            };

            return new DocumentTranslationClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);
        }

        [Test]
        public void StartTranslationWithCategoryId()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/batches/215c9633-fca1-4821-ab29-70e4e2fbacc7"));

            var input = new DocumentTranslationInput(new Uri("http://source"), new Uri("http://target"), "fr");
            input.AddTarget(new Uri("http://target2"), "es", categoryId: "myCategoryId");

            var startTranslationDetails = new TranslationBatch(new List<DocumentTranslationInput> { input });
            using RequestContent content = (RequestContent)startTranslationDetails;

            var contentString = GetString(content);
            string category = contentString.Substring(contentString.IndexOf("category"), 23);

            var expectedContent = "category\":\"myCategoryId";
            Assert.AreEqual(expectedContent, category);
        }

        [Test]
        public void StartTranslationWithDeploymentName()
        {
            var input = new DocumentTranslationInput(new Uri("http://source"), new Uri("http://target"), "fr");
            input.Targets[0].DeploymentName = "myDeployment";

            var startTranslationDetails = new TranslationBatch(new List<DocumentTranslationInput> { input });
            using RequestContent content = (RequestContent)startTranslationDetails;

            var contentString = GetString(content);

            Assert.IsTrue(
                contentString.Contains("\"deploymentName\":\"myDeployment\""),
                $"Expected serialized content to contain the deploymentName property. Actual: {contentString}");
        }

        [Test]
        public void DocumentStatusResultDeserializesDeploymentName()
        {
            string json =
                "{" +
                "\"path\":\"https://target/doc.txt\"," +
                "\"sourcePath\":\"https://source/doc.txt\"," +
                "\"createdDateTimeUtc\":\"2026-03-01T00:00:00.0000000Z\"," +
                "\"lastActionDateTimeUtc\":\"2026-03-01T00:05:00.0000000Z\"," +
                "\"status\":\"Succeeded\"," +
                "\"to\":\"es\"," +
                "\"progress\":1.0," +
                "\"id\":\"doc-1\"," +
                "\"characterCharged\":100," +
                "\"deploymentName\":\"myDeployment\"" +
                "}";

            DocumentStatusResult result = ModelReaderWriter.Read<DocumentStatusResult>(BinaryData.FromString(json));

            Assert.AreEqual("myDeployment", result.DeploymentName);
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
