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

namespace Azure.AI.TextAnalytics.Legacy.Tests
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
            var options = new TextAnalyticsClientOptions(TextAnalyticsClientOptions.ServiceVersion.V3_1)
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

            Assert.That(resultCollection[0].Id, Is.EqualTo("1"));
            Assert.That(resultCollection[1].Id, Is.EqualTo("2"));
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

            Assert.That(resultCollection[0].Id, Is.EqualTo("4"));
            Assert.That(resultCollection[1].Id, Is.EqualTo("5"));
            Assert.That(resultCollection[2].Id, Is.EqualTo("2"));
            Assert.That(resultCollection[3].Id, Is.EqualTo("3"));
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

            TextAnalytics.DocumentSentiment response = await client.AnalyzeSentimentAsync("today is a hot day");

            Assert.That(response.Sentences.FirstOrDefault().Text, Is.Empty);
        }

        [Test]
        public async Task AnalyzeSentimentAssessmentInOtherSentence()
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
                                    ""targets"": [
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
                                                    ""relationType"": ""assessment"",
                                                    ""ref"": ""#/documents/0/sentences/0/assessments/0""
                                                }
                                            ]
                                        }
                                    ],
                                    ""assessments"": [
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
                                    ""targets"": [
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
                                                    ""relationType"": ""assessment"",
                                                    ""ref"": ""#/documents/0/sentences/0/assessments/0""
                                                }
                                            ]
                                        }
                                    ],
                                    ""assessments"": []
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

            TextAnalytics.DocumentSentiment response = await client.AnalyzeSentimentAsync("The park was clean. It was clean.");

            SentenceOpinion opinionS1 = response.Sentences.ElementAt(0).Opinions.FirstOrDefault();
            Assert.That(opinionS1.Target.Text, Is.EqualTo("park"));
            Assert.That(opinionS1.Target.Sentiment, Is.EqualTo(TextSentiment.Positive));
            Assert.That(opinionS1.Assessments.FirstOrDefault().Text, Is.EqualTo("clean"));

            SentenceOpinion opinionS2 = response.Sentences.ElementAt(1).Opinions.FirstOrDefault();
            Assert.That(opinionS2.Target.Text, Is.EqualTo("park"));
            Assert.That(opinionS2.Target.Sentiment, Is.EqualTo(TextSentiment.Positive));
            Assert.That(opinionS2.Assessments.FirstOrDefault().Text, Is.EqualTo("clean"));
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

            Assert.That(response.FirstOrDefault().Matches.FirstOrDefault().Text, Is.Empty);
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
            Assert.That(resultError.HasError, Is.True);
            Assert.That(resultError.Error.ErrorCode.ToString(), Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
            Assert.That(resultError.Error.Message, Is.EqualTo("Document text is empty."));
        }

        [Test]
        public void StartAnalyzeHealthcareEntitiesWithDisplayNameLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = CreateTestClient(new MockTransport());
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeHealthcareEntitiesAsync(new[] { "test" }, options: new AnalyzeHealthcareEntitiesOptions { DisplayName = "test" }));

            Assert.That(ex.Message, Is.EqualTo("AnalyzeHealthcareEntitiesOptions.DisplayName is not available in API version v3.1. Use service API version 2022-05-01 or newer."));
        }
    }
}
