// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Moq;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="AnalyzeOperationExtensions.GetUsage"/>
    /// and <see cref="AnalyzeUsageDetails"/>.
    /// </summary>
    [TestFixture]
    public class AnalyzeUsageDetailsTests
    {
        #region GetUsage Extension Method

        [Test]
        public void GetUsage_WhenOperationNotCompleted_ReturnsNull()
        {
            var mockOp = new Mock<Operation<AnalysisResult>>();
            mockOp.Setup(o => o.HasCompleted).Returns(false);

            AnalyzeUsageDetails? usage = mockOp.Object.GetUsage();

            Assert.IsNull(usage);
        }

        [Test]
        public void GetUsage_WhenResponseHasUsage_ReturnsUsageDetails()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesMinimal"": 2,
                    ""documentPagesBasic"": 0,
                    ""documentPagesStandard"": 0,
                    ""audioHours"": 0.0,
                    ""videoHours"": 0.0,
                    ""contextualizationTokens"": 1234,
                    ""tokens"": {
                        ""gpt-4.1-input"": 500,
                        ""gpt-4.1-output"": 100
                    }
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(2, usage!.DocumentPagesMinimal);
            Assert.AreEqual(0, usage.DocumentPagesBasic);
            Assert.AreEqual(0, usage.DocumentPagesStandard);
            Assert.AreEqual(0.0f, usage.AudioHours);
            Assert.AreEqual(0.0f, usage.VideoHours);
            Assert.AreEqual(1234, usage.ContextualizationTokens);
            Assert.AreEqual(2, usage.Tokens.Count);
            Assert.AreEqual(500, usage.Tokens["gpt-4.1-input"]);
            Assert.AreEqual(100, usage.Tokens["gpt-4.1-output"]);
        }

        [Test]
        public void GetUsage_WhenResponseHasNoUsage_ReturnsNull()
        {
            string json = @"{ ""status"": ""Succeeded"", ""result"": {} }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNull(usage);
        }

        [Test]
        public void GetUsage_WhenUsageIsNull_ReturnsNull()
        {
            string json = @"{ ""status"": ""Succeeded"", ""result"": {}, ""usage"": null }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNull(usage);
        }

        [Test]
        public void GetUsage_WhenOperationIsNull_ReturnsNull()
        {
            Operation<AnalysisResult>? operation = null;
            AnalyzeUsageDetails? usage = operation!.GetUsage();

            Assert.IsNull(usage);
        }

        [Test]
        public void GetUsage_WithPartialUsageFields_ReturnsAvailableValues()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesStandard"": 5,
                    ""contextualizationTokens"": 999
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.IsNull(usage!.DocumentPagesMinimal);
            Assert.IsNull(usage.DocumentPagesBasic);
            Assert.AreEqual(5, usage.DocumentPagesStandard);
            Assert.IsNull(usage.AudioHours);
            Assert.IsNull(usage.VideoHours);
            Assert.AreEqual(999, usage.ContextualizationTokens);
            Assert.IsEmpty(usage.Tokens);
        }

        [Test]
        public void GetUsage_WhenResponseContentIsNull_ReturnsNull()
        {
            var mockResponse = new Mock<Response>();
            mockResponse.Setup(r => r.Content).Returns((BinaryData)null!);

            var mockOp = new Mock<Operation<AnalysisResult>>();
            mockOp.Setup(o => o.HasCompleted).Returns(true);
            mockOp.Setup(o => o.GetRawResponse()).Returns(mockResponse.Object);

            AnalyzeUsageDetails? usage = mockOp.Object.GetUsage();

            Assert.IsNull(usage);
        }

        [Test]
        public void GetUsage_WhenResponseIsMalformedJson_ReturnsNull()
        {
            var mockResponse = new Mock<Response>();
            mockResponse.Setup(r => r.Content).Returns(BinaryData.FromString("not valid json"));

            var mockOp = new Mock<Operation<AnalysisResult>>();
            mockOp.Setup(o => o.HasCompleted).Returns(true);
            mockOp.Setup(o => o.GetRawResponse()).Returns(mockResponse.Object);

            AnalyzeUsageDetails? usage = mockOp.Object.GetUsage();

            Assert.IsNull(usage);
        }

        [Test]
        public void GetUsage_WithEmptyUsageObject_ReturnsDefaultValues()
        {
            string json = @"{ ""status"": ""Succeeded"", ""result"": {}, ""usage"": {} }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.IsNull(usage!.DocumentPagesMinimal);
            Assert.IsNull(usage.DocumentPagesBasic);
            Assert.IsNull(usage.DocumentPagesStandard);
            Assert.IsNull(usage.AudioHours);
            Assert.IsNull(usage.VideoHours);
            Assert.IsNull(usage.ContextualizationTokens);
            Assert.IsEmpty(usage.Tokens);
        }

        [Test]
        public void GetUsage_WithEmptyTokensDictionary_ReturnsEmptyTokens()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesMinimal"": 1,
                    ""tokens"": {}
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(1, usage!.DocumentPagesMinimal);
            Assert.IsEmpty(usage.Tokens);
        }

        [Test]
        public void GetUsage_WithNullValuedFields_TreatsAsAbsent()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesMinimal"": null,
                    ""audioHours"": null,
                    ""tokens"": null
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.IsNull(usage!.DocumentPagesMinimal);
            Assert.IsNull(usage.AudioHours);
            Assert.IsEmpty(usage.Tokens);
        }

        [Test]
        public void GetUsage_WithMultipleTokenModels_ReturnsAllTokenEntries()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""tokens"": {
                        ""gpt-4.1-input"": 1000,
                        ""gpt-4.1-cached_input"": 200,
                        ""gpt-4.1-output"": 300,
                        ""text-embedding-3-large-input"": 500
                    }
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(4, usage!.Tokens.Count);
            Assert.AreEqual(1000, usage.Tokens["gpt-4.1-input"]);
            Assert.AreEqual(200, usage.Tokens["gpt-4.1-cached_input"]);
            Assert.AreEqual(300, usage.Tokens["gpt-4.1-output"]);
            Assert.AreEqual(500, usage.Tokens["text-embedding-3-large-input"]);
        }

        [Test]
        public void GetUsage_WithAudioVideoHours_ReturnsFloatValues()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""audioHours"": 1.25,
                    ""videoHours"": 2.75
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(1.25f, usage!.AudioHours);
            Assert.AreEqual(2.75f, usage.VideoHours);
        }

        [Test]
        public void GetUsage_TokensAreReadOnly()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""tokens"": { ""gpt-4.1-input"": 100 }
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.IsInstanceOf<ReadOnlyDictionary<string, int>>(usage!.Tokens);
        }

        [Test]
        public void GetUsage_CalledMultipleTimes_ReturnsSameValues()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesStandard"": 3,
                    ""contextualizationTokens"": 500
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? first = operation.GetUsage();
            AnalyzeUsageDetails? second = operation.GetUsage();

            Assert.IsNotNull(first);
            Assert.IsNotNull(second);
            Assert.AreEqual(first!.DocumentPagesStandard, second!.DocumentPagesStandard);
            Assert.AreEqual(first.ContextualizationTokens, second.ContextualizationTokens);
        }

        [Test]
        public void GetUsage_ZeroValuedFields_AreDistinctFromNull()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesMinimal"": 0,
                    ""documentPagesBasic"": 0,
                    ""documentPagesStandard"": 0,
                    ""audioHours"": 0.0,
                    ""videoHours"": 0.0,
                    ""contextualizationTokens"": 0,
                    ""tokens"": { ""gpt-4.1-input"": 0 }
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(0, usage!.DocumentPagesMinimal);
            Assert.AreEqual(0, usage.DocumentPagesBasic);
            Assert.AreEqual(0, usage.DocumentPagesStandard);
            Assert.AreEqual(0.0f, usage.AudioHours);
            Assert.AreEqual(0.0f, usage.VideoHours);
            Assert.AreEqual(0, usage.ContextualizationTokens);
            Assert.AreEqual(0, usage.Tokens["gpt-4.1-input"]);
        }

        [Test]
        public void GetUsage_WithUnknownJsonProperties_IgnoresExtras()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesStandard"": 1,
                    ""futureField"": ""some-value"",
                    ""anotherNewField"": 42
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(1, usage!.DocumentPagesStandard);
            Assert.IsNull(usage.DocumentPagesMinimal);
        }

        [Test]
        public void GetUsage_WithIntegerAudioHours_ParsesAsFloat()
        {
            // Service may return 1 instead of 1.0 for whole-number floats
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""audioHours"": 2,
                    ""videoHours"": 3
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(2.0f, usage!.AudioHours);
            Assert.AreEqual(3.0f, usage.VideoHours);
        }

        [Test]
        public void GetUsage_WithLargeTokenValues_HandlesCorrectly()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""documentPagesStandard"": 10000,
                    ""contextualizationTokens"": 2000000,
                    ""tokens"": {
                        ""gpt-4.1.input"": 1500000,
                        ""gpt-4.1.output"": 500000
                    }
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(10000, usage!.DocumentPagesStandard);
            Assert.AreEqual(2000000, usage.ContextualizationTokens);
            Assert.AreEqual(1500000, usage.Tokens["gpt-4.1.input"]);
            Assert.AreEqual(500000, usage.Tokens["gpt-4.1.output"]);
        }

        [Test]
        public void GetUsage_WithTokenKeysContainingSpecialChars_PreservesKeys()
        {
            string json = @"{
                ""status"": ""Succeeded"",
                ""result"": {},
                ""usage"": {
                    ""tokens"": {
                        ""gpt-4.1.cached input"": 100,
                        ""text-embedding-3-large.input"": 200,
                        ""model/v2:input"": 50
                    }
                }
            }";

            Operation<AnalysisResult> operation = CreateCompletedOperation(json);
            AnalyzeUsageDetails? usage = operation.GetUsage();

            Assert.IsNotNull(usage);
            Assert.AreEqual(3, usage!.Tokens.Count);
            Assert.AreEqual(100, usage.Tokens["gpt-4.1.cached input"]);
            Assert.AreEqual(200, usage.Tokens["text-embedding-3-large.input"]);
            Assert.AreEqual(50, usage.Tokens["model/v2:input"]);
        }

        [Test]
        public void GetUsage_WhenResponseIsEmptyString_ReturnsNull()
        {
            var mockResponse = new Mock<Response>();
            mockResponse.Setup(r => r.Content).Returns(BinaryData.FromString(""));

            var mockOp = new Mock<Operation<AnalysisResult>>();
            mockOp.Setup(o => o.HasCompleted).Returns(true);
            mockOp.Setup(o => o.GetRawResponse()).Returns(mockResponse.Object);

            AnalyzeUsageDetails? usage = mockOp.Object.GetUsage();

            Assert.IsNull(usage);
        }

        #endregion

        #region ModelFactory

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_CreatesInstance()
        {
            var tokens = new Dictionary<string, int>
            {
                { "gpt-4.1.input", 200 },
                { "gpt-4.1.output", 50 }
            };

            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails(
                documentPagesMinimal: 1,
                documentPagesBasic: 2,
                documentPagesStandard: 3,
                audioHours: 0.5f,
                videoHours: 1.5f,
                contextualizationTokens: 777,
                tokens: tokens);

            Assert.AreEqual(1, usage.DocumentPagesMinimal);
            Assert.AreEqual(2, usage.DocumentPagesBasic);
            Assert.AreEqual(3, usage.DocumentPagesStandard);
            Assert.AreEqual(0.5f, usage.AudioHours);
            Assert.AreEqual(1.5f, usage.VideoHours);
            Assert.AreEqual(777, usage.ContextualizationTokens);
            Assert.AreEqual(200, usage.Tokens["gpt-4.1.input"]);
            Assert.AreEqual(50, usage.Tokens["gpt-4.1.output"]);
        }

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_WithDefaults_ReturnsNulls()
        {
            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails();

            Assert.IsNull(usage.DocumentPagesMinimal);
            Assert.IsNull(usage.DocumentPagesBasic);
            Assert.IsNull(usage.DocumentPagesStandard);
            Assert.IsNull(usage.AudioHours);
            Assert.IsNull(usage.VideoHours);
            Assert.IsNull(usage.ContextualizationTokens);
            Assert.IsNotNull(usage.Tokens);
            Assert.IsEmpty(usage.Tokens);
        }

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_WithNullTokens_ReturnsEmptyTokens()
        {
            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails(
                documentPagesMinimal: 5,
                tokens: null);

            Assert.AreEqual(5, usage.DocumentPagesMinimal);
            Assert.IsNotNull(usage.Tokens);
            Assert.IsEmpty(usage.Tokens);
        }

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_TokensAreReadOnly()
        {
            var tokens = new Dictionary<string, int> { { "model.input", 42 } };

            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails(tokens: tokens);

            Assert.IsInstanceOf<ReadOnlyDictionary<string, int>>(usage.Tokens);
            Assert.AreEqual(42, usage.Tokens["model.input"]);
        }

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_TokensCannotBeModifiedThroughProperty()
        {
            var original = new Dictionary<string, int> { { "model.input", 100 } };

            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails(tokens: original);

            // The Tokens property is IReadOnlyDictionary — callers cannot add/remove via the property
            Assert.IsInstanceOf<ReadOnlyDictionary<string, int>>(usage.Tokens);
            Assert.Throws<NotSupportedException>(() =>
                ((IDictionary<string, int>)usage.Tokens)["new.key"] = 42);
        }

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_MutatingOriginalDictDoesNotAffectInstance()
        {
            var original = new Dictionary<string, int> { { "model.input", 100 } };

            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails(tokens: original);

            // Mutate the original dictionary after creation
            original["model.input"] = 999;
            original["new.key"] = 50;

            // The instance should be isolated from the original dictionary
            Assert.AreEqual(100, usage.Tokens["model.input"]);
            Assert.AreEqual(1, usage.Tokens.Count);
            Assert.IsFalse(usage.Tokens.ContainsKey("new.key"));
        }

        [Test]
        public void ModelFactory_AnalyzeUsageDetails_WithZeroValues_SetsZeros()
        {
            AnalyzeUsageDetails usage = ContentUnderstandingModelFactory.AnalyzeUsageDetails(
                documentPagesMinimal: 0,
                documentPagesBasic: 0,
                documentPagesStandard: 0,
                audioHours: 0.0f,
                videoHours: 0.0f,
                contextualizationTokens: 0);

            Assert.AreEqual(0, usage.DocumentPagesMinimal);
            Assert.AreEqual(0, usage.DocumentPagesBasic);
            Assert.AreEqual(0, usage.DocumentPagesStandard);
            Assert.AreEqual(0.0f, usage.AudioHours);
            Assert.AreEqual(0.0f, usage.VideoHours);
            Assert.AreEqual(0, usage.ContextualizationTokens);
        }

        #endregion

        #region Helpers

        private static Operation<AnalysisResult> CreateCompletedOperation(string json)
        {
            var mockResponse = new Mock<Response>();
            mockResponse.Setup(r => r.Content).Returns(BinaryData.FromString(json));

            var mockOp = new Mock<Operation<AnalysisResult>>();
            mockOp.Setup(o => o.HasCompleted).Returns(true);
            mockOp.Setup(o => o.GetRawResponse()).Returns(mockResponse.Object);

            return mockOp.Object;
        }

        #endregion
    }
}
