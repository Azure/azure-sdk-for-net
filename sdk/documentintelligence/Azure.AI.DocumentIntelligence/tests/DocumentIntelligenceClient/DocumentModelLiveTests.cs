// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentModelLiveTests : DocumentIntelligenceLiveTestBase
    {
        public DocumentModelLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AnalyzeDocumentWithUrlSource()
        {
            var client = CreateDocumentIntelligenceClient();

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", content);

            Assert.That(operation.HasCompleted);
            Assert.That(operation.HasValue);

            ValidateContosoReceiptAnalyzeResult(operation.Value);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentWithBase64Source()
        {
            var client = CreateDocumentIntelligenceClient();

            var content = new AnalyzeDocumentContent()
            {
                Base64Source = DocumentIntelligenceTestEnvironment.CreateBinaryData(TestFile.ContosoReceipt)
            };

            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", content);

            Assert.That(operation.HasCompleted);
            Assert.That(operation.HasValue);

            ValidateContosoReceiptAnalyzeResult(operation.Value);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentCanParseBlankPage()
        {
            var client = CreateDocumentIntelligenceClient();

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.Blank)
            };

            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", content);

            Assert.That(operation.HasCompleted);
            Assert.That(operation.HasValue);

            var result = operation.Value;

            ValidateGenericAnalyzeResult(operation.Value, "prebuilt-receipt");

            Assert.That(result.Content, Is.Empty);
            Assert.That(result.Paragraphs, Is.Empty);
            Assert.That(result.Tables, Is.Empty);
            Assert.That(result.Figures, Is.Empty);
            Assert.That(result.Lists, Is.Empty);
            Assert.That(result.Sections, Is.Empty);
            Assert.That(result.KeyValuePairs, Is.Empty);
            Assert.That(result.Styles, Is.Empty);
            Assert.That(result.Languages, Is.Empty);
            Assert.That(result.Documents, Is.Empty);

            var page = result.Pages.Single();

            Assert.That(page.Words, Is.Empty);
            Assert.That(page.SelectionMarks, Is.Empty);
            Assert.That(page.Lines, Is.Empty);
            Assert.That(page.Barcodes, Is.Empty);
            Assert.That(page.Formulas, Is.Empty);

            AssertSingleEmptySpan(page.Spans);
        }

        private void ValidateGenericAnalyzeResult(AnalyzeResult analyzeResult, string modelId)
        {
            Assert.That(analyzeResult.ModelId, Is.EqualTo(modelId));
            Assert.That(analyzeResult.ApiVersion, Is.EqualTo(ServiceVersionString));
            Assert.That(analyzeResult.StringIndexType, Is.EqualTo(StringIndexType.TextElements));
            Assert.That(analyzeResult.ContentFormat, Is.Not.EqualTo(default(ContentFormat)));

            for (int pageNumber = 1; pageNumber <= analyzeResult.Pages.Count; pageNumber++)
            {
                var page = analyzeResult.Pages[pageNumber - 1];

                Assert.That(page.Width, Is.GreaterThan(0f));
                Assert.That(page.Height, Is.GreaterThan(0f));
                Assert.That(page.Unit, Is.Not.EqualTo(default(LengthUnit)));
                Assert.That(page.PageNumber, Is.EqualTo(pageNumber));
            }

            int expectedPageNumber = 1;

            foreach (var document in analyzeResult.Documents)
            {
                Assert.That(document.DocType, Is.Not.Null);
                Assert.That(document.DocType, Is.Not.Empty);

                foreach (var region in document.BoundingRegions)
                {
                    Assert.That(region.PageNumber, Is.EqualTo(expectedPageNumber++));
                    Assert.That(region.Polygon.Count, Is.EqualTo(8));
                }

                Assert.That(document.Confidence, Is.GreaterThanOrEqualTo(0f));
                Assert.That(document.Confidence, Is.LessThanOrEqualTo(1f));
            }
        }

        private void ValidateContosoReceiptAnalyzeResult(AnalyzeResult analyzeResult)
        {
            ValidateGenericAnalyzeResult(analyzeResult, "prebuilt-receipt");

            Assert.That(analyzeResult.ContentFormat, Is.EqualTo(ContentFormat.Text));

            var document = analyzeResult.Documents.Single();

            Assert.That(document.DocType, Is.EqualTo("receipt.retailMeal"));

            var documentSpan = document.Spans.Single();

            Assert.That(documentSpan.Offset, Is.EqualTo(0));
            Assert.That(documentSpan.Length, Is.EqualTo(analyzeResult.Content.Length));

            var merchantAddressField = document.Fields["MerchantAddress"];
            var merchantNameField = document.Fields["MerchantName"];
            var merchantPhoneNumberField = document.Fields["MerchantPhoneNumber"];
            var transactionDateField = document.Fields["TransactionDate"];
            var transactionTimeField = document.Fields["TransactionTime"];
            var totalField = document.Fields["Total"];

            Assert.That(merchantAddressField.Type, Is.EqualTo(DocumentFieldType.Address));
            Assert.That(merchantNameField.Type, Is.EqualTo(DocumentFieldType.String));
            Assert.That(merchantPhoneNumberField.Type, Is.EqualTo(DocumentFieldType.PhoneNumber));
            Assert.That(transactionDateField.Type, Is.EqualTo(DocumentFieldType.Date));
            Assert.That(transactionTimeField.Type, Is.EqualTo(DocumentFieldType.Time));
            Assert.That(totalField.Type, Is.EqualTo(DocumentFieldType.Currency));

            var merchantAddress = merchantAddressField.ValueAddress;
            var merchantName = merchantNameField.ValueString;
            var merchantPhoneNumber = merchantPhoneNumberField.ValuePhoneNumber;
            var transactionDate = transactionDateField.ValueDate.Value;
            var transactionTime = transactionTimeField.ValueTime.Value;
            var total = totalField.ValueCurrency;

            Assert.That(merchantAddress.City, Is.EqualTo("Redmond"));
            Assert.That(merchantAddress.CountryRegion, Is.Null);
            Assert.That(merchantAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(merchantAddress.PoBox, Is.Null);
            Assert.That(merchantAddress.PostalCode, Is.EqualTo("98052"));
            Assert.That(merchantAddress.Road, Is.EqualTo("Main Street"));
            Assert.That(merchantAddress.State, Is.EqualTo("WA"));
            Assert.That(merchantAddress.StreetAddress, Is.EqualTo("123 Main Street"));

            Assert.That(merchantName, Is.EqualTo("Contoso"));
            Assert.That(merchantPhoneNumber, Is.EqualTo("+11234567890"));

            Assert.That(transactionDate.Year, Is.EqualTo(2019));
            Assert.That(transactionDate.Month, Is.EqualTo(6));
            Assert.That(transactionDate.Day, Is.EqualTo(10));

            Assert.That(transactionTime.Hours, Is.EqualTo(13));
            Assert.That(transactionTime.Minutes, Is.EqualTo(59));
            Assert.That(transactionTime.Seconds, Is.EqualTo(0));

            Assert.That(total.Amount, Is.EqualTo(1203.39).Within(0.0001));
            Assert.That(total.CurrencyCode, Is.EqualTo("USD"));
            Assert.That(total.CurrencySymbol, Is.EqualTo("$"));
        }

        private void AssertSingleEmptySpan(IReadOnlyList<DocumentSpan> spans)
        {
            var span = spans.Single();

            Assert.That(span.Offset, Is.EqualTo(0));
            Assert.That(span.Length, Is.EqualTo(0));
        }
    }
}
