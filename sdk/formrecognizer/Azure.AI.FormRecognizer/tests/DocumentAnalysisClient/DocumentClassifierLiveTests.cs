// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the document classifier methods in the <see cref="DocumentAnalysisClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ServiceVersion(Min = DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)]
    internal class DocumentClassifierLiveTests : DocumentAnalysisLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentClassifierLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentClassifierLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ClassifyDocument(bool useTokenCredential)
        {
            var client = CreateDocumentAnalysisClient(useTokenCredential);
            var classifierId = Recording.GenerateId();
            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync(classifierId);
            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Irs1040);
            ClassifyDocumentOperation operation;

            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, classifierId, stream);
            }

            Assert.That(operation.HasValue, Is.True);

            ValidateIrs1040ClassifierResult(operation.Value, classifierId);
        }

        [RecordedTest]
        public async Task ClassifyDocumentCanParseBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            var classifierId = Recording.GenerateId();
            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync(classifierId);
            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Blank);
            ClassifyDocumentOperation operation;

            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, classifierId, stream);
            }

            Assert.That(operation.HasValue, Is.True);

            ValidateGenericClassifierResult(operation.Value, classifierId);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ClassifyDocumentFromUri(bool useTokenCredential)
        {
            var client = CreateDocumentAnalysisClient(useTokenCredential);
            var classifierId = Recording.GenerateId();
            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync(classifierId);
            var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Irs1040);
            var operation = await client.ClassifyDocumentFromUriAsync(WaitUntil.Completed, classifierId, uri);

            Assert.That(operation.HasValue, Is.True);

            ValidateIrs1040ClassifierResult(operation.Value, classifierId);
        }

        private void ValidateGenericClassifierResult(AnalyzeResult analyzeResult, string expectedClassifierId)
        {
            Assert.Multiple(() =>
            {
                Assert.That(analyzeResult.ModelId, Is.EqualTo(expectedClassifierId));

                Assert.That(analyzeResult.Content, Is.Empty);
                Assert.That(analyzeResult.Paragraphs, Is.Empty);
                Assert.That(analyzeResult.Tables, Is.Empty);
                Assert.That(analyzeResult.KeyValuePairs, Is.Empty);
                Assert.That(analyzeResult.Styles, Is.Empty);
                Assert.That(analyzeResult.Languages, Is.Empty);
            });

            for (int pageNumber = 1; pageNumber <= analyzeResult.Pages.Count; pageNumber++)
            {
                var page = analyzeResult.Pages[pageNumber - 1];

                Assert.That(page.Words, Is.Empty);
                Assert.That(page.SelectionMarks, Is.Empty);
                Assert.That(page.Lines, Is.Empty);
                Assert.That(page.Barcodes, Is.Empty);
                Assert.That(page.Formulas, Is.Empty);

                AssertSingleEmptySpan(page.Spans);

                Assert.That(page.PageNumber, Is.EqualTo(pageNumber));
            }

            int expectedPageNumber = 1;

            foreach (var document in analyzeResult.Documents)
            {
                Assert.That(document.Fields, Is.Empty);

                AssertSingleEmptySpan(document.Spans);

                foreach (var region in document.BoundingRegions)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(region.PageNumber, Is.EqualTo(expectedPageNumber++));
                        Assert.That(region.BoundingPolygon, Has.Count.EqualTo(4));
                    });
                }

                Assert.That(document.Confidence, Is.GreaterThanOrEqualTo(0f));
                Assert.That(document.Confidence, Is.LessThanOrEqualTo(1f));
            }
        }

        private void ValidateIrs1040ClassifierResult(AnalyzeResult analyzeResult, string expectedClassifierId)
        {
            ValidateGenericClassifierResult(analyzeResult, expectedClassifierId);

            Assert.That(analyzeResult.Pages, Has.Count.EqualTo(4));

            foreach (var page in analyzeResult.Pages)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(page.Angle, Is.EqualTo(0f).Within(0.05f));
                    Assert.That(page.Width, Is.EqualTo(8.5f));
                    Assert.That(page.Height, Is.EqualTo(11f));
                    Assert.That(page.Unit, Is.EqualTo(DocumentPageLengthUnit.Inch));
                });
            }

            Assert.That(analyzeResult.Documents, Has.Count.EqualTo(2));

            var document0 = analyzeResult.Documents[0];
            var document1 = analyzeResult.Documents[1];

            Assert.Multiple(() =>
            {
                Assert.That(document0.DocumentType, Is.EqualTo("IRS-1040-A"));
                Assert.That(document1.DocumentType, Is.EqualTo("IRS-1040-C"));
                Assert.That(document0.BoundingRegions, Has.Count.EqualTo(2));
                Assert.That(document1.BoundingRegions, Has.Count.EqualTo(2));
            });
        }

        private void AssertSingleEmptySpan(IReadOnlyList<DocumentSpan> spans)
        {
            var span = spans.Single();

            Assert.Multiple(() =>
            {
                Assert.That(span.Index, Is.EqualTo(0));
                Assert.That(span.Length, Is.EqualTo(0));
            });
        }
    }
}
