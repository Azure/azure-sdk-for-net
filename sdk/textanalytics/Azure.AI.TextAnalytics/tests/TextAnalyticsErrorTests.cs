// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsErrorTests : SyncAsyncPolicyTestBase
    {
        public TextAnalyticsErrorTests(bool isAsync) : base(isAsync) { }

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
                        ""innererror"": {
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
            Assert.IsTrue(result.Error.ErrorCode.ToString().Equals(TextAnalyticsErrorCode.InvalidDocument, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(result.Error.Message, "Document text is empty.");
        }
    }
}
