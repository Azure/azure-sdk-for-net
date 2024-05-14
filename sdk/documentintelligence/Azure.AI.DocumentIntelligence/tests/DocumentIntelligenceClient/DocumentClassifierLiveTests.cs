// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentClassifierLiveTests : DocumentIntelligenceLiveTestBase
    {
        public DocumentClassifierLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ClassifyDocumentWithUrlSource()
        {
            var client = CreateDocumentIntelligenceClient();

            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync();

            var content = new ClassifyDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.Irs1040)
            };

            var operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, disposableClassifier.ClassifierId, content);

            Assert.That(operation.HasCompleted);
            Assert.That(operation.HasValue);

            ValidateIrs1040ClassifierResult(operation.Value, disposableClassifier.ClassifierId);
        }

        [RecordedTest]
        public async Task ClassifyDocumentCanParseBlankPage()
        {
            var client = CreateDocumentIntelligenceClient();

            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync();

            var content = new ClassifyDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.Blank)
            };

            var operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, disposableClassifier.ClassifierId, content);

            Assert.That(operation.HasCompleted);
            Assert.That(operation.HasValue);

            ValidateGenericClassifierResult(operation.Value, disposableClassifier.ClassifierId);
        }

        private void ValidateGenericClassifierResult(AnalyzeResult analyzeResult, string classifierId)
        {
            Assert.That(analyzeResult.ModelId, Is.EqualTo(classifierId));
            Assert.That(analyzeResult.ApiVersion, Is.EqualTo(ServiceVersionString));
            Assert.That(analyzeResult.StringIndexType, Is.EqualTo(StringIndexType.TextElements));
            Assert.That(analyzeResult.ContentFormat, Is.Not.EqualTo(default(ContentFormat)));

            Assert.That(analyzeResult.Content, Is.Empty);
            Assert.That(analyzeResult.Paragraphs, Is.Empty);
            Assert.That(analyzeResult.Tables, Is.Empty);
            Assert.That(analyzeResult.Figures, Is.Empty);
            Assert.That(analyzeResult.Lists, Is.Empty);
            Assert.That(analyzeResult.Sections, Is.Empty);
            Assert.That(analyzeResult.KeyValuePairs, Is.Empty);
            Assert.That(analyzeResult.Styles, Is.Empty);
            Assert.That(analyzeResult.Languages, Is.Empty);

            for (int pageNumber = 1; pageNumber <= analyzeResult.Pages.Count; pageNumber++)
            {
                var page = analyzeResult.Pages[pageNumber - 1];

                Assert.That(page.Width, Is.GreaterThan(0f));
                Assert.That(page.Height, Is.GreaterThan(0f));
                Assert.That(page.Unit, Is.Not.EqualTo(default(LengthUnit)));

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
                Assert.That(document.DocType, Is.Not.Null);
                Assert.That(document.DocType, Is.Not.Empty);
                Assert.That(document.Fields, Is.Empty);

                AssertSingleEmptySpan(document.Spans);

                foreach (var region in document.BoundingRegions)
                {
                    Assert.That(region.PageNumber, Is.EqualTo(expectedPageNumber++));
                    Assert.That(region.Polygon.Count, Is.EqualTo(8));
                }

                Assert.That(document.Confidence, Is.GreaterThanOrEqualTo(0f));
                Assert.That(document.Confidence, Is.LessThanOrEqualTo(1f));
            }
        }

        private void ValidateIrs1040ClassifierResult(AnalyzeResult analyzeResult, string classifierId)
        {
            ValidateGenericClassifierResult(analyzeResult, classifierId);

            Assert.That(analyzeResult.ContentFormat, Is.EqualTo(ContentFormat.Text));

            Assert.That(analyzeResult.Pages.Count, Is.EqualTo(4));

            foreach (var page in analyzeResult.Pages)
            {
                Assert.That(page.Angle, Is.EqualTo(0f).Within(0.05f));
                Assert.That(page.Width, Is.EqualTo(8.5f));
                Assert.That(page.Height, Is.EqualTo(11f));
                Assert.That(page.Unit, Is.EqualTo(LengthUnit.Inch));
            }

            var document = analyzeResult.Documents.Single();

            Assert.That(document.DocType, Is.EqualTo("IRS-1040-A"));
            Assert.That(document.BoundingRegions.Count, Is.EqualTo(4));
        }

        private void AssertSingleEmptySpan(IReadOnlyList<DocumentSpan> spans)
        {
            var span = spans.Single();

            Assert.That(span.Offset, Is.EqualTo(0));
            Assert.That(span.Length, Is.EqualTo(0));
        }
    }
}
