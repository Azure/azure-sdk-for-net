// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsErrorTests : SyncAsyncPolicyTestBase
    {
        public TextAnalyticsErrorTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task ConvertTextAnalyticsErrorToException()
        {
            var mockResponse = new MockResponse(200);
            TextAnalyticsError error = new TextAnalyticsError("TestErrorCode", "TestMessage", "TestTarget");
            var exception = await mockResponse.CreateRequestFailedExceptionAsync(error);

            Assert.AreEqual("TestErrorCode", exception.ErrorCode);
            StringAssert.Contains("TestMessage", exception.Message);
            StringAssert.Contains("TestTarget", exception.Message);
        }

        [Test]
        public void DeserializeTextAnalyticsError()
        {
            var errors = @"
                {
                ""errors"": [
                    {
                      ""id"": ""2"",
                      ""error"": {
                        ""code"": ""InvalidArgument"",
                        ""innerError"": {
                            ""code"": ""InvalidDocument"",
                            ""message"": ""Document text is empty.""
                            },
                        ""message"": ""Invalid document in request.""
                        }
                    }
                ]
                }
                ";

            using JsonDocument json = JsonDocument.Parse(errors);
            TextAnalyticsResult result = TextAnalyticsServiceSerializer.ReadDocumentErrors(json.RootElement).FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Error);
            Assert.AreEqual(result.Error.ErrorCode, "InvalidDocument");
            Assert.AreEqual(result.Error.Message, "Document text is empty.");
        }
    }
}
