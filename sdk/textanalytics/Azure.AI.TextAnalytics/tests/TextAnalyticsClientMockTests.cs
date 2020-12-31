// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public TextAnalyticsClientMockTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new TextAnalyticsClientOptions
            {
                Transport = transport
            };

            var client = InstrumentClient(new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options));

            return client;
        }

        [Test]
        public async Task RecognizeEntitiesResultsSorted_NoErrors()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""1"",
                            ""entities"": [
                                {
                                    ""name"": ""Microsoft"",
                                    ""matches"": [
                                        {
                                            ""text"": ""Microsoft"",
                                            ""offset"": 0,
                                            ""length"": 9,
                                            ""confidenceScore"": 0.26
                                        }
                                    ],
                                    ""language"": ""en"",
                                    ""id"": ""Microsoft"",
                                    ""url"": ""https://en.wikipedia.org/wiki/Microsoft"",
                                    ""dataSource"": ""Wikipedia""
                                }
                            ],
                            ""warnings"": []
                        },
                        {
                            ""id"": ""2"",
                            ""entities"": [
                                {
                                    ""name"": ""Microsoft"",
                                    ""matches"": [
                                        {
                                            ""text"": ""Microsoft"",
                                            ""offset"": 0,
                                            ""length"": 9,
                                            ""confidenceScore"": 0.26
                                        }
                                    ],
                                    ""language"": ""en"",
                                    ""id"": ""Microsoft"",
                                    ""url"": ""https://en.wikipedia.org/wiki/Microsoft"",
                                    ""dataSource"": ""Wikipedia""
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020-02-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "Microsoft was founded"),
                new TextDocumentInput("2", "Microsoft was founded"),
            };

            var response = await client.RecognizeEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions());
            var resultCollection = response.Value;

            Assert.AreEqual("1", resultCollection[0].Id);
            Assert.AreEqual("2", resultCollection[1].Id);
        }

        [Test]
        public async Task RecognizeEntitiesResultsSorted_WithErrors()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""2"",
                            ""entities"": [
                                {
                                    ""name"": ""Microsoft"",
                                    ""matches"": [
                                        {
                                            ""text"": ""Microsoft"",
                                            ""offset"": 0,
                                            ""length"": 9,
                                            ""confidenceScore"": 0.26
                                        }
                                    ],
                                    ""language"": ""en"",
                                    ""id"": ""Microsoft"",
                                    ""url"": ""https://en.wikipedia.org/wiki/Microsoft"",
                                    ""dataSource"": ""Wikipedia""
                                }
                            ],
                            ""warnings"": []
                        },
                        {
                            ""id"": ""3"",
                            ""entities"": [
                                {
                                    ""name"": ""Microsoft"",
                                    ""matches"": [
                                        {
                                            ""text"": ""Microsoft"",
                                            ""offset"": 0,
                                            ""length"": 9,
                                            ""confidenceScore"": 0.26
                                        }
                                    ],
                                    ""language"": ""en"",
                                    ""id"": ""Microsoft"",
                                    ""url"": ""https://en.wikipedia.org/wiki/Microsoft"",
                                    ""dataSource"": ""Wikipedia""
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [
                        {
                            ""id"": ""4"",
                            ""error"": {
                                ""code"": ""InvalidArgument"",
                                ""message"": ""Invalid document in request."",
                                ""innererror"": {
                                    ""code"": ""InvalidDocument"",
                                    ""message"": ""Document text is empty.""
                                }
                            }
                        },
                        {
                            ""id"": ""5"",
                            ""error"": {
                                ""code"": ""InvalidArgument"",
                                ""message"": ""Invalid document in request."",
                                ""innererror"": {
                                    ""code"": ""InvalidDocument"",
                                    ""message"": ""Document text is empty.""
                                }
                            }
                        }
                    ],
                    ""modelVersion"": ""2020-02-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("4", "TextDocument1"),
                new TextDocumentInput("5", "TextDocument2"),
                new TextDocumentInput("2", "TextDocument3"),
                new TextDocumentInput("3", "TextDocument4"),
            };

            var response = await client.RecognizeEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions());
            var resultCollection = response.Value;

            Assert.AreEqual("4", resultCollection[0].Id);
            Assert.AreEqual("5", resultCollection[1].Id);
            Assert.AreEqual("2", resultCollection[2].Id);
            Assert.AreEqual("3", resultCollection[3].Id);
        }

        [Test]
        public async Task DetectedLanguageNullName()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                    {
                        ""id"": ""1"",
                        ""detectedLanguage"": {
                            ""name"": null,
                            ""iso6391Name"": ""en"",
                            ""confidenceScore"": 1
                            },
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020 -07-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1", "Hello world")
                {
                     CountryHint = "us",
                }
            };

            DetectLanguageResultCollection response = await client.DetectLanguageBatchAsync(documents);

            Assert.IsNull(response.FirstOrDefault().PrimaryLanguage.Name);
            Assert.IsNotNull(response.FirstOrDefault().PrimaryLanguage.Iso6391Name);
        }

        [Test]
        public async Task DetectedLanguageNullIso6391Name()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                    {
                        ""id"": ""1"",
                        ""detectedLanguage"": {
                            ""name"": ""English"",
                            ""iso6391Name"": null,
                            ""confidenceScore"": 1
                            },
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020 -07-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1", "Hello world")
                {
                     CountryHint = "us",
                }
            };

            DetectLanguageResultCollection response = await client.DetectLanguageBatchAsync(documents);

            Assert.IsNotNull(response.FirstOrDefault().PrimaryLanguage.Name);
            Assert.IsNull(response.FirstOrDefault().PrimaryLanguage.Iso6391Name);
        }

        // We shipped TA 5.0.0 Text == string.Empty if the service returned a null value for Text.
        // We want to verify behavior is the same after code auto generated.
        [Test]
        public async Task AnalyzeSentimentNullText()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""1"",
                            ""sentiment"": ""neutral"",
                            ""confidenceScores"": {
                                ""positive"": 0.1,
                                ""neutral"": 0.88,
                                ""negative"": 0.02
                            },
                            ""sentences"": [
                                {
                                ""sentiment"": ""neutral"",
                                    ""confidenceScores"": {
                                    ""positive"": 0.1,
                                        ""neutral"": 0.88,
                                        ""negative"": 0.02
                                    },
                                    ""offset"": 0,
                                    ""length"": 18,
                                    ""text"": null
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020 -04-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            DocumentSentiment response = await client.AnalyzeSentimentAsync("today is a hot day");

            Assert.AreEqual(string.Empty, response.Sentences.FirstOrDefault().Text);
        }

        [Test]
        public void AnalyzeSentimentNotSupportedSentenceSentiment()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""1"",
                            ""sentiment"": ""neutral"",
                            ""confidenceScores"": {
                                ""positive"": 0.1,
                                ""neutral"": 0.88,
                                ""negative"": 0.02
                            },
                            ""sentences"": [
                                {
                                ""sentiment"": ""confusion"",
                                    ""confidenceScores"": {
                                    ""positive"": 0.1,
                                        ""neutral"": 0.88,
                                        ""negative"": 0.02
                                    },
                                    ""offset"": 0,
                                    ""length"": 18,
                                    ""text"": ""today is a hot day""
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020 -04-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            Assert.ThrowsAsync<ArgumentException>(async () => await client.AnalyzeSentimentAsync("today is a hot day"));
        }

        [Test]
        public async Task AnalyzeSentimentMixedSentenceSentiment()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""1"",
                            ""sentiment"": ""neutral"",
                            ""confidenceScores"": {
                                ""positive"": 0.1,
                                ""neutral"": 0.88,
                                ""negative"": 0.02
                            },
                            ""sentences"": [
                                {
                                ""sentiment"": ""mixed"",
                                    ""confidenceScores"": {
                                    ""positive"": 0.1,
                                        ""neutral"": 0.88,
                                        ""negative"": 0.02
                                    },
                                    ""offset"": 0,
                                    ""length"": 18,
                                    ""text"": ""today is a hot day""
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020 -04-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            DocumentSentiment response = await client.AnalyzeSentimentAsync("today is a hot day");

            Assert.AreEqual(TextSentiment.Mixed, response.Sentences.FirstOrDefault().Sentiment);
        }

        [Test]
        public async Task AnalyzeSentimentOpinionInOtherSentence()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""1"",
                            ""sentiment"": ""positive"",
                            ""confidenceScores"": {
                                ""positive"": 0.5,
                                ""neutral"": 0.0,
                                ""negative"": 0.5
                            },
                            ""sentences"": [
                                {
                                    ""sentiment"": ""positive"",
                                    ""confidenceScores"": {
                                        ""positive"": 1.0,
                                        ""neutral"": 0.0,
                                        ""negative"": 0.0
                                    },
                                    ""offset"": 0,
                                    ""length"": 30,
                                    ""text"": ""The park was clean."",
                                    ""aspects"": [
                                        {
                                            ""sentiment"": ""positive"",
                                            ""confidenceScores"": {
                                                ""positive"": 1.0,
                                                ""negative"": 0.0
                                            },
                                            ""offset"": 4,
                                            ""length"": 4,
                                            ""text"": ""park"",
                                            ""relations"": [
                                                {
                                                    ""relationType"": ""opinion"",
                                                    ""ref"": ""#/documents/0/sentences/0/opinions/0""
                                                }
                                            ]
                                        }
                                    ],
                                    ""opinions"": [
                                        {
                                            ""sentiment"": ""positive"",
                                            ""confidenceScores"": {
                                                ""positive"": 1.0,
                                                ""negative"": 0.0
                                            },
                                            ""offset"": 13,
                                            ""length"": 5,
                                            ""text"": ""clean"",
                                            ""isNegated"": false
                                        }
                                    ]
                                },
                                {
                                    ""sentiment"": ""positive"",
                                    ""confidenceScores"": {
                                        ""positive"": 0.0,
                                        ""neutral"": 0.0,
                                        ""negative"": 1.0
                                    },
                                    ""offset"": 31,
                                    ""length"": 23,
                                    ""text"": ""It was clean."",
                                    ""aspects"": [
                                        {
                                            ""sentiment"": ""positive"",
                                            ""confidenceScores"": {
                                                ""positive"": 0.0,
                                                ""negative"": 1.0
                                            },
                                            ""offset"": 35,
                                            ""length"": 4,
                                            ""text"": ""park"",
                                            ""relations"": [
                                                {
                                                    ""relationType"": ""opinion"",
                                                    ""ref"": ""#/documents/0/sentences/0/opinions/0""
                                                }
                                            ]
                                        }
                                    ],
                                    ""opinions"": []
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020-04-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            DocumentSentiment response = await client.AnalyzeSentimentAsync("The park was clean. It was clean.");

            MinedOpinion minedOpinionS1 = response.Sentences.ElementAt(0).MinedOpinions.FirstOrDefault();
            Assert.AreEqual("park", minedOpinionS1.Aspect.Text);
            Assert.AreEqual(TextSentiment.Positive, minedOpinionS1.Aspect.Sentiment);
            Assert.AreEqual("clean", minedOpinionS1.Opinions.FirstOrDefault().Text);

            MinedOpinion minedOpinionS2 = response.Sentences.ElementAt(1).MinedOpinions.FirstOrDefault();
            Assert.AreEqual("park", minedOpinionS2.Aspect.Text);
            Assert.AreEqual(TextSentiment.Positive, minedOpinionS2.Aspect.Sentiment);
            Assert.AreEqual("clean", minedOpinionS2.Opinions.FirstOrDefault().Text);
        }

        [Test]
        public async Task RecognizeEntitiesNullCategory()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""0"",
                            ""entities"": [
                                {
                                ""text"": ""Microsoft"",
                                    ""category"": null,
                                    ""offset"": 0,
                                    ""length"": 9,
                                    ""confidenceScore"": 0.81
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020 -04-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            CategorizedEntityCollection response = await client.RecognizeEntitiesAsync("Microsoft was founded");

            Assert.IsNotNull(response.FirstOrDefault().Category);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesNullText()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""0"",
                            ""entities"": [
                                {
                                    ""name"": ""Microsoft"",
                                    ""matches"": [
                                        {
                                            ""text"": null,
                                            ""offset"": 0,
                                            ""length"": 9,
                                            ""confidenceScore"": 0.26
                                        }
                                    ],
                                    ""language"": ""en"",
                                    ""id"": ""Microsoft"",
                                    ""url"": ""https://en.wikipedia.org/wiki/Microsoft"",
                                    ""dataSource"": ""Wikipedia""
                                }
                            ],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [],
                    ""modelVersion"": ""2020-02-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = "Microsoft was founded";

            LinkedEntityCollection response = await client.RecognizeLinkedEntitiesAsync(documents);

            Assert.AreEqual(string.Empty, response.FirstOrDefault().Matches.FirstOrDefault().Text);
        }

        [Test]
        public async Task DeserializeTextAnalyticsError()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""documents"": [
                        {
                            ""id"": ""0"",
                            ""keyPhrases"": [],
                            ""warnings"": []
                        }
                    ],
                    ""errors"": [
                        {
                            ""id"": ""1"",
                            ""error"": {
                                ""code"": ""InvalidArgument"",
                                ""message"": ""Invalid document in request."",
                                ""innererror"": {
                                    ""code"": ""InvalidDocument"",
                                    ""message"": ""Document text is empty.""
                                }
                            }
                        }
                    ],
                    ""modelVersion"": ""2020-07-01""
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>()
            {
                "Something smells",
                ""
            };

            ExtractKeyPhrasesResultCollection result = await client.ExtractKeyPhrasesBatchAsync(documents);
            var resultError = result[1];
            Assert.IsTrue(resultError.HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultError.Error.ErrorCode.ToString());
            Assert.AreEqual("Document text is empty.", resultError.Error.Message);
        }
    }
}
