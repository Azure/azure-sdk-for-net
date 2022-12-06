﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizeEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeEntitiesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string EnglishDocument1 = "Microsoft was founded by Bill Gates and Paul Allen.";
        private const string EnglishDocument2 = "My cat and my dog might need to see a veterinarian.";

        private const string SpanishDocument1 = "Microsoft fue fundado por Bill Gates y Paul Allen.";

        private static readonly List<string> s_batchConvenienceDocuments = new List<string>
        {
            EnglishDocument1,
            EnglishDocument2
        };

        private static readonly List<TextDocumentInput> s_batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", EnglishDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", SpanishDocument1)
            {
                 Language = "es",
            }
        };

        private static readonly List<string> s_document1ExpectedOutput = new List<string>
        {
            "Microsoft",
            "Bill Gates",
            "Paul Allen"
        };

        private static readonly List<string> s_document2ExpectedOutput = new List<string>
        {
            "veterinarian"
        };

        [RecordedTest]
        public async Task RecognizeEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(SpanishDocument1, "es");

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesWithSubCategoryTest()
        {
            TextAnalyticsRequestOptions options = new TextAnalyticsRequestOptions() { ModelVersion = "2020-04-01" };
            TextAnalyticsClient client = GetClient();
            string document = "I had a wonderful trip to Seattle last week.";

            RecognizeEntitiesResultCollection result = await client.RecognizeEntitiesBatchAsync(new List<string>() { document }, options: options );

            var documentResult = result.FirstOrDefault();
            Assert.IsFalse(documentResult.HasError);

            Assert.GreaterOrEqual(documentResult.Entities.Count, 3);

            foreach (CategorizedEntity entity in documentResult.Entities)
            {
                if (entity.Text == "last week")
                    Assert.AreEqual("DateRange", entity.SubCategory);
            }

            // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
            Assert.IsFalse(options.IncludeStatistics);
            Assert.AreEqual("2020-04-01", options.ModelVersion);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public void RecognizeEntitiesBatchWithInvalidDocumentBatch()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "document 1",
                "document 2",
                "document 3",
                "document 4",
                "document 5",
                "document 6"
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.RecognizeEntitiesBatchAsync(documents));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocumentBatch, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedOutput },
                { "1", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsRequestOptions options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments, "en", options);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedOutput },
                { "1", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);

            // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
            Assert.IsTrue(options.IncludeStatistics);
            Assert.IsNull(options.ModelVersion);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchDocuments);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "2", s_document1ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsRequestOptions options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchDocuments, options);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "2", s_document1ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);

            // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
            Assert.IsTrue(options.IncludeStatistics);
            Assert.IsNull(options.ModelVersion);
        }

        [RecordedTest]
        public void RecognizeEntitiesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.RecognizeEntitiesBatchAsync(documents));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].Entities.Count());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [RecordedTest]
        [Ignore("LRO not implemented")]
        public async Task RecognizeEntitiesWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>()
                {
                    new RecognizeEntitiesAction()
                    {
                        DisableServiceLogs = true,
                        ActionName = "RecognizeEntitiesWithDisabledServiceLogs"
                    },
                    new RecognizeEntitiesAction()
                    {
                        ActionName = "RecognizeEntities"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> RecognizeEntitiesActionsResults = resultCollection.RecognizeEntitiesResults;

            Assert.IsNotNull(RecognizeEntitiesActionsResults);

            IList<string> expected = new List<string> { "RecognizeEntities", "RecognizeEntitiesWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, RecognizeEntitiesActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task RecognizeEntitiesBatchDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true });

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedOutput },
                { "1", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void RecognizeEntitiesBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.AreEqual("TextAnalyticsRequestOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task RecognizeEntitiesBatchWithResolutionsTest()
        {
            TextAnalyticsRequestOptions options = new() { ModelVersion = "2022-10-01-preview" };
            TextAnalyticsClient client = GetClient();

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(new List<TextDocumentInput>() {
                new TextDocumentInput("1", "The dog is 14 inches tall and weighs 20 lbs. It is 5 years old."),
                new TextDocumentInput("2", "This is the first aircraft of its kind. It can fly at over 1,300 meter per second and carry 65-80 passengers."),
                new TextDocumentInput("3", "The apartment is 840 sqft. and it has 2 bedrooms. It costs 2,000 US dollars per month and will be available on 11/01/2022."),
                new TextDocumentInput("4", "Mix 1 cup of sugar. Bake for approximately 60 minutes in an oven preheated to 350 degrees F."),
                new TextDocumentInput("5", "They retrieved 200 terabytes of data between October 24th, 2022 and October 28th, 2022."),
            }, options: options);

            RecognizeEntitiesResult result1 = results.Where(result => result.Id == "1").FirstOrDefault();
            Assert.NotNull(result1);
            Assert.False(result1.HasError);
            Assert.That(result1.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is AgeResolution)));
            Assert.That(result1.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is LengthResolution)));
            Assert.That(result1.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is WeightResolution)));

            foreach (CategorizedEntity entity in result1.Entities)
            {
                Assert.IsNotNull(entity.Resolutions);

                BaseResolution resolution = entity.Resolutions.FirstOrDefault();

                if (resolution is AgeResolution age)
                {
                    Assert.AreEqual(5, age.Value);
                    Assert.AreEqual(AgeUnit.Year, age.Unit);
                }

                if (resolution is LengthResolution length)
                {
                    Assert.AreEqual(14, length.Value);
                    Assert.AreEqual(LengthUnit.Inch, length.Unit);
                }

                if (resolution is WeightResolution weight)
                {
                    Assert.AreEqual(20, weight.Value);
                    Assert.AreEqual(WeightUnit.Pound, weight.Unit);
                }
            }

            RecognizeEntitiesResult result2 = results.Where(result => result.Id == "2").FirstOrDefault();
            Assert.NotNull(result2);
            Assert.False(result2.HasError);
            Assert.That(result2.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is OrdinalResolution)));
            Assert.That(result2.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is SpeedResolution)));
            Assert.That(result2.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is NumericRangeResolution)));

            foreach (CategorizedEntity entity in result2.Entities)
            {
                Assert.IsNotNull(entity.Resolutions);

                BaseResolution resolution = entity.Resolutions.FirstOrDefault();

                if (resolution is OrdinalResolution ordinal)
                {
                    Assert.AreEqual("1", ordinal.Value);
                    Assert.AreEqual(RelativeTo.Start, ordinal.RelativeTo);
                    Assert.AreEqual("1", ordinal.Offset);
                }

                if (resolution is SpeedResolution speed)
                {
                    Assert.AreEqual(1300, speed.Value);
                    // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/32356
                    // Assert.AreEqual(SpeedUnit.MilesPerHour, speed.Unit);
                }

                if (resolution is NumericRangeResolution numericRange)
                {
                    Assert.AreEqual(65, numericRange.Minimum);
                    Assert.AreEqual(80, numericRange.Maximum);
                    Assert.AreEqual(RangeKind.Number, numericRange.RangeKind);
                }
            }

            RecognizeEntitiesResult result3 = results.Where(result => result.Id == "3").FirstOrDefault();
            Assert.NotNull(result3);
            Assert.False(result3.HasError);
            Assert.That(result3.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is AreaResolution)));
            Assert.That(result3.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is NumberResolution)));
            Assert.That(result3.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is CurrencyResolution)));
            Assert.That(result3.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is DateTimeResolution)));

            foreach (CategorizedEntity entity in result3.Entities)
            {
                Assert.IsNotNull(entity.Resolutions);

                BaseResolution resolution = entity.Resolutions.FirstOrDefault();

                if (resolution is AreaResolution area)
                {
                    Assert.AreEqual(840, area.Value);
                    Assert.AreEqual(AreaUnit.SquareFoot, area.Unit);
                }

                if (resolution is NumberResolution number)
                {
                    Assert.AreEqual(2, number.Value);
                    Assert.AreEqual(NumberKind.Integer, number.NumberKind);
                }

                if (resolution is CurrencyResolution currency)
                {
                    Assert.AreEqual(2000, currency.Value);
                    // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/32357
                    // Assert.AreEqual("USD", currency.Iso4217);
                    Assert.AreEqual("United States dollar", currency.Unit);
                }

                if (resolution is DateTimeResolution dateTime)
                {
                    Assert.AreEqual("2022-11-01", dateTime.Value);
                    Assert.AreEqual("2022-11-01", dateTime.Timex);
                    Assert.IsNull(dateTime.Modifier);
                }
            }

            RecognizeEntitiesResult result4 = results.Where(result => result.Id == "4").FirstOrDefault();
            Assert.NotNull(result4);
            Assert.False(result4.HasError);
            Assert.That(result4.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is VolumeResolution)));
            Assert.That(result4.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is TemporalSpanResolution)));
            Assert.That(result4.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is TemperatureResolution)));

            foreach (CategorizedEntity entity in result4.Entities)
            {
                Assert.IsNotNull(entity.Resolutions);

                BaseResolution resolution = entity.Resolutions.FirstOrDefault();

                if (resolution is VolumeResolution volume)
                {
                    Assert.AreEqual(1, volume.Value);
                    Assert.AreEqual(VolumeUnit.Cup, volume.Unit);
                }

                if (resolution is TemporalSpanResolution temporalSpan)
                {
                    Assert.AreEqual("PT60M", temporalSpan.Duration);
                    Assert.IsNull(temporalSpan.Begin);
                    Assert.IsNull(temporalSpan.End);
                    Assert.IsNull(temporalSpan.Modifier);
                }

                if (resolution is TemperatureResolution temperature)
                {
                    Assert.AreEqual(350, temperature.Value);
                    Assert.AreEqual(TemperatureUnit.Fahrenheit, temperature.Unit);
                }
            }

            RecognizeEntitiesResult result5 = results.Where(result => result.Id == "5").FirstOrDefault();
            Assert.NotNull(result5);
            Assert.False(result5.HasError);
            Assert.That(result5.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is InformationResolution)));
            Assert.That(result5.Entities.Any(entity => entity.Resolutions.Any(resolution => resolution is TemporalSpanResolution)));

            foreach (CategorizedEntity entity in result5.Entities)
            {
                Assert.IsNotNull(entity.Resolutions);

                BaseResolution resolution = entity.Resolutions.FirstOrDefault();

                if (resolution is InformationResolution information)
                {
                    Assert.AreEqual(200, information.Value);
                    Assert.AreEqual(InformationUnit.Terabyte, information.Unit);
                }

                if (resolution is TemporalSpanResolution temporalSpan)
                {
                    Assert.AreEqual("P4D", temporalSpan.Duration);
                    Assert.AreEqual("2022-10-24", temporalSpan.Begin);
                    Assert.AreEqual("2022-10-28", temporalSpan.End);
                    Assert.IsNull(temporalSpan.Modifier);
                }
            }
        }

        private void ValidateInDocumenResult(CategorizedEntityCollection entities, List<string> minimumExpectedOutput)
        {
            Assert.IsNotNull(entities.Warnings);
            Assert.GreaterOrEqual(entities.Count, minimumExpectedOutput.Count);
            foreach (CategorizedEntity entity in entities)
            {
                Assert.That(entity.Text, Is.Not.Null.And.Not.Empty);
                Assert.IsTrue(minimumExpectedOutput.Contains(entity.Text, StringComparer.OrdinalIgnoreCase));
                Assert.IsNotNull(entity.Category);
                Assert.GreaterOrEqual(entity.ConfidenceScore, 0.0);
                Assert.GreaterOrEqual(entity.Offset, 0);
                Assert.Greater(entity.Length, 0);

                if (entity.SubCategory != null)
                {
                    Assert.IsNotEmpty(entity.SubCategory);
                }

                Assert.IsNotNull(entity.Resolutions);
            }
        }

        private void ValidateBatchDocumentsResult(RecognizeEntitiesResultCollection results, Dictionary<string, List<string>> minimumExpectedOutput, bool includeStatistics = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            if (includeStatistics)
            {
                Assert.IsNotNull(results.Statistics);
                Assert.Greater(results.Statistics.DocumentCount, 0);
                Assert.Greater(results.Statistics.TransactionCount, 0);
                Assert.GreaterOrEqual(results.Statistics.InvalidDocumentCount, 0);
                Assert.GreaterOrEqual(results.Statistics.ValidDocumentCount, 0);
            }
            else
                Assert.IsNull(results.Statistics);

            foreach (RecognizeEntitiesResult entitiesInDocument in results)
            {
                Assert.That(entitiesInDocument.Id, Is.Not.Null.And.Not.Empty);

                Assert.False(entitiesInDocument.HasError);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.IsNotNull(entitiesInDocument.Statistics);

                if (includeStatistics)
                {
                    Assert.GreaterOrEqual(entitiesInDocument.Statistics.CharacterCount, 0);
                    Assert.Greater(entitiesInDocument.Statistics.TransactionCount, 0);
                }
                else
                {
                    Assert.AreEqual(0, entitiesInDocument.Statistics.CharacterCount);
                    Assert.AreEqual(0, entitiesInDocument.Statistics.TransactionCount);
                }

                ValidateInDocumenResult(entitiesInDocument.Entities, minimumExpectedOutput[entitiesInDocument.Id]);
            }
        }
    }
}
