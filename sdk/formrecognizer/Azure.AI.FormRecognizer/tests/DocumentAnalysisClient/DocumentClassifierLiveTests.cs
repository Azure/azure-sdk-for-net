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

            Assert.IsTrue(operation.HasValue);

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

            Assert.IsTrue(operation.HasValue);

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

            Assert.IsTrue(operation.HasValue);

            ValidateIrs1040ClassifierResult(operation.Value, classifierId);
        }

        private void ValidateGenericClassifierResult(AnalyzeResult analyzeResult, string expectedClassifierId)
        {
            Assert.AreEqual(expectedClassifierId, analyzeResult.ModelId);

            Assert.IsEmpty(analyzeResult.Content);
            Assert.IsEmpty(analyzeResult.Paragraphs);
            Assert.IsEmpty(analyzeResult.Tables);
            Assert.IsEmpty(analyzeResult.KeyValuePairs);
            Assert.IsEmpty(analyzeResult.Styles);
            Assert.IsEmpty(analyzeResult.Languages);

            for (int pageNumber = 1; pageNumber <= analyzeResult.Pages.Count; pageNumber++)
            {
                var page = analyzeResult.Pages[pageNumber - 1];

                Assert.IsEmpty(page.Words);
                Assert.IsEmpty(page.SelectionMarks);
                Assert.IsEmpty(page.Lines);
                Assert.IsEmpty(page.Barcodes);
                Assert.IsEmpty(page.Formulas);

                AssertSingleEmptySpan(page.Spans);

                Assert.AreEqual(pageNumber, page.PageNumber);
            }

            int expectedPageNumber = 1;

            foreach (var document in analyzeResult.Documents)
            {
                Assert.IsEmpty(document.Fields);

                AssertSingleEmptySpan(document.Spans);

                foreach (var region in document.BoundingRegions)
                {
                    Assert.AreEqual(expectedPageNumber++, region.PageNumber);
                    Assert.AreEqual(4, region.BoundingPolygon.Count);
                }

                Assert.GreaterOrEqual(document.Confidence, 0f);
                Assert.LessOrEqual(document.Confidence, 1f);
            }
        }

        private void ValidateIrs1040ClassifierResult(AnalyzeResult analyzeResult, string expectedClassifierId)
        {
            ValidateGenericClassifierResult(analyzeResult, expectedClassifierId);

            Assert.AreEqual(4, analyzeResult.Pages.Count);

            foreach (var page in analyzeResult.Pages)
            {
                Assert.That(page.Angle, Is.EqualTo(0f).Within(0.05f));
                Assert.AreEqual(8.5f, page.Width);
                Assert.AreEqual(11f, page.Height);
                Assert.AreEqual(DocumentPageLengthUnit.Inch, page.Unit);
            }

            Assert.AreEqual(2, analyzeResult.Documents.Count);

            var document0 = analyzeResult.Documents[0];
            var document1 = analyzeResult.Documents[1];

            Assert.AreEqual("IRS-1040-A", document0.DocumentType);
            Assert.AreEqual("IRS-1040-C", document1.DocumentType);
            Assert.AreEqual(2, document0.BoundingRegions.Count);
            Assert.AreEqual(2, document1.BoundingRegions.Count);
        }

        private void AssertSingleEmptySpan(IReadOnlyList<DocumentSpan> spans)
        {
            var span = spans.Single();

            Assert.AreEqual(0, span.Index);
            Assert.AreEqual(0, span.Length);
        }
    }
}
