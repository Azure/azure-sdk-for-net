// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task AnalyzeDocumentAsync()
        {
            #region Snippet:DocumentAnalysisCreateMocks
            var mockClient = new Mock<DocumentAnalysisClient>();
            var mockOperation = new Mock<AnalyzeDocumentOperation>();
            #endregion

            #region Snippet:DocumentAnalysisSetUpClientMock
            var fakeModelId = Guid.NewGuid().ToString();
            var fakeDocumentUri = new Uri("https://fake.document.uri");

            mockClient.Setup(client => client.AnalyzeDocumentFromUriAsync(
                    WaitUntil.Completed,
                    fakeModelId,
                    fakeDocumentUri,
                    It.IsAny<AnalyzeDocumentOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(mockOperation.Object));
            #endregion

            #region Snippet:DocumentAnalysisSetUpOperationMock
            var fieldValue = DocumentAnalysisModelFactory.DocumentFieldValueWithDoubleFieldType(150.0);

            var fieldPolygon = new List<PointF>()
            {
                new PointF(1f, 2f), new PointF(2f, 2f), new PointF(2f, 1f), new PointF(1f, 1f)
            };
            var fieldRegion = DocumentAnalysisModelFactory.BoundingRegion(1, fieldPolygon);
            var fieldRegions = new List<BoundingRegion>() { fieldRegion };

            var fieldSpans = new List<DocumentSpan>()
            {
                DocumentAnalysisModelFactory.DocumentSpan(25, 32)
            };

            var field = DocumentAnalysisModelFactory.DocumentField(DocumentFieldType.Double, fieldValue, "$150.00", fieldRegions, fieldSpans, confidence: 0.85f);
            var fields = new Dictionary<string, DocumentField>
            {
                { "totalPrice", field }
            };

            var documentPolygon = new List<PointF>()
            {
                new PointF(0f, 10f), new PointF(10f, 10f), new PointF(10f, 0f), new PointF(0f, 0f)
            };
            var documentRegion = DocumentAnalysisModelFactory.BoundingRegion(1, documentPolygon);
            var documentRegions = new List<BoundingRegion>() { documentRegion };

            var documentSpans = new List<DocumentSpan>()
            {
                DocumentAnalysisModelFactory.DocumentSpan(0, 105)
            };

            var document = DocumentAnalysisModelFactory.AnalyzedDocument("groceries:groceries", documentRegions, documentSpans, fields, 0.95f);
            var documents = new List<AnalyzedDocument>() { document };

            var result = DocumentAnalysisModelFactory.AnalyzeResult("groceries", documents: documents);

            mockOperation.SetupGet(op => op.Value)
                .Returns(result);
            #endregion

            #region Snippet:DocumentAnalysisUseMocks
            bool isExpensive = await IsExpensiveAsync(fakeModelId, fakeDocumentUri, mockClient.Object);
            Assert.IsTrue(isExpensive);
            #endregion
        }

        #region Snippet:DocumentAnalysisMethodToTest
        private static async Task<bool> IsExpensiveAsync(string modelId, Uri documentUri, DocumentAnalysisClient client)
        {
            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, modelId, documentUri);
            AnalyzedDocument document = operation.Value.Documents[0];

            if (document.Fields.TryGetValue("totalPrice", out DocumentField totalPriceField)
                && totalPriceField.FieldType == DocumentFieldType.Double)
            {
                return totalPriceField.Confidence > 0.7f && totalPriceField.Value.AsDouble() > 100.0;
            }
            else
            {
                return false;
            }
        }
        #endregion

        [RecordedTest]
        public async Task GetDocumentModelsAsync()
        {
            var mockClient = new Mock<DocumentModelAdministrationClient>();

            var page = Page<DocumentModelSummary>.FromValues(new[]
            {
                DocumentAnalysisModelFactory.DocumentModelSummary("groceries", "Analyzes groceries lists",
                    DateTimeOffset.Parse("2022-09-01T00:00:00Z")),
                DocumentAnalysisModelFactory.DocumentModelSummary("custom_invoices", "Analyzes custom invoices",
                    DateTimeOffset.Parse("2022-09-15T00:00:00Z"))
            }, null, Mock.Of<Response>());

            mockClient.Setup(client => client.GetDocumentModelsAsync(
                    It.IsAny<CancellationToken>()))
                .Returns(AsyncPageable<DocumentModelSummary>.FromPages(new[] { page }));

            DocumentModelAdministrationClient client = mockClient.Object;

            // Get the IDs of all models created before 2022/September/10.

            var dateLimit = DateTimeOffset.Parse("2022-09-10T00:00:00Z");
            var oldModelIds = new List<string>();

            await foreach (DocumentModelSummary modelSummary in client.GetDocumentModelsAsync())
            {
                if (modelSummary.CreatedOn < dateLimit)
                {
                    oldModelIds.Add(modelSummary.ModelId);
                }
            }

            Assert.AreEqual(1, oldModelIds.Count);
            Assert.AreEqual("groceries", oldModelIds[0]);
        }
    }
}
