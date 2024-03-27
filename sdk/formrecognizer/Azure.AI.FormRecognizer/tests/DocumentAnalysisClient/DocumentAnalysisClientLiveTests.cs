// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

using TestFile = Azure.AI.FormRecognizer.Tests.TestFile;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DocumentAnalysisClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DocumentAnalysisClientLiveTests : DocumentAnalysisLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentAnalysisClientLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        #region Business Cards

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35243")]
        public async Task AnalyzeDocumentPopulatesExtractedBusinessCardJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-businessCard", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.BusinessCardJpg);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-businessCard", uri);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-businessCard",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.AreEqual(4, result.Paragraphs.Count);

            // Check just one paragraph to make sure we're parsing them.

            DocumentParagraph sampleParagraph = result.Paragraphs[0];

            Assert.AreEqual("Dr. Avery Smith Senior Researcher Cloud & Al Department", sampleParagraph.Content);
            Assert.IsNull(sampleParagraph.Role);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.AreEqual("businessCard", document.DocumentType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("ContactNames"));
            Assert.True(document.Fields.ContainsKey("JobTitles"));
            Assert.True(document.Fields.ContainsKey("Departments"));
            Assert.True(document.Fields.ContainsKey("Emails"));
            Assert.True(document.Fields.ContainsKey("Websites"));
            Assert.True(document.Fields.ContainsKey("MobilePhones"));
            Assert.True(document.Fields.ContainsKey("WorkPhones"));
            Assert.True(document.Fields.ContainsKey("Faxes"));
            Assert.True(document.Fields.ContainsKey("Addresses"));
            Assert.True(document.Fields.ContainsKey("CompanyNames"));

            var contactNames = document.Fields["ContactNames"].Value.AsList();
            Assert.AreEqual(1, contactNames.Count);
            Assert.AreEqual("Dr. Avery Smith", contactNames.FirstOrDefault().Content);

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.True(contactNamesDict.ContainsKey("FirstName"));
            Assert.AreEqual("Avery", contactNamesDict["FirstName"].Value.AsString());

            Assert.True(contactNamesDict.ContainsKey("LastName"));
            Assert.AreEqual("Smith", contactNamesDict["LastName"].Value.AsString());

            var jobTitles = document.Fields["JobTitles"].Value.AsList();
            Assert.AreEqual(1, jobTitles.Count);
            Assert.AreEqual("Senior Researcher", jobTitles.FirstOrDefault().Value.AsString());

            var departments = document.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.AreEqual("Cloud & Al Department", departments.FirstOrDefault().Value.AsString());

            var emails = document.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.AreEqual("avery.smith@contoso.com", emails.FirstOrDefault().Value.AsString());

            var websites = document.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.AreEqual("https://www.contoso.com/", websites.FirstOrDefault().Value.AsString());

            var mobilePhones = document.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.AreEqual(DocumentFieldType.PhoneNumber, mobilePhones.FirstOrDefault().FieldType);

            var otherPhones = document.Fields["WorkPhones"].Value.AsList();
            Assert.AreEqual(1, otherPhones.Count);
            Assert.AreEqual(DocumentFieldType.PhoneNumber, otherPhones.FirstOrDefault().FieldType);

            var faxes = document.Fields["Faxes"].Value.AsList();
            Assert.AreEqual(1, faxes.Count);
            Assert.AreEqual(DocumentFieldType.PhoneNumber, faxes.FirstOrDefault().FieldType);

            var addresses = document.Fields["Addresses"].Value.AsList();
            Assert.AreEqual(1, addresses.Count);

            AddressValue address = addresses.First().Value.AsAddress();
            Assert.AreEqual("London", address.City);
            Assert.Null(address.CountryRegion);
            Assert.AreEqual("2", address.HouseNumber);
            Assert.Null(address.PoBox);
            Assert.AreEqual("W2 6BD", address.PostalCode);
            Assert.AreEqual("Kingdom Street", address.Road);
            Assert.Null(address.State);
            Assert.AreEqual("2 Kingdom Street", address.StreetAddress);

            var companyNames = document.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.AreEqual("Contoso", companyNames.FirstOrDefault().Value.AsString());
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentCanParseMultipageBusinessCard(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.BusinessMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-businessCard", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.BusinessMultipage);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-businessCard", uri);
            }

            AnalyzeResult result = operation.Value;

            Assert.AreEqual(2, result.Documents.Count);

            for (int documentIndex = 0; documentIndex < result.Documents.Count; documentIndex++)
            {
                var analyzedDocument = result.Documents[documentIndex];
                var expectedPageNumber = documentIndex + 1;

                Assert.NotNull(analyzedDocument);

                ValidateAnalyzedDocument(
                    analyzedDocument,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                Assert.IsTrue(analyzedDocument.Fields.ContainsKey("Emails"));

                DocumentField sampleField = analyzedDocument.Fields["Emails"];

                Assert.AreEqual(DocumentFieldType.List, sampleField.FieldType);

                var field = sampleField.Value.AsList().Single();

                if (documentIndex == 0)
                {
                    Assert.AreEqual("johnsinger@contoso.com", field.Content);
                }
                else if (documentIndex == 1)
                {
                    Assert.AreEqual("avery.smith@contoso.com", field.Content);
                }
            }
        }

        #endregion

        #region Custom

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentWithCustomModel(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            await using var customModel = await BuildDisposableDocumentModelAsync();

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, customModel.ModelId, stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, customModel.ModelId, uri);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();
            DocumentPage page = result.Pages.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.

            Assert.IsNotEmpty(document.DocumentType);
            Assert.AreEqual(2200, page.Height);
            Assert.AreEqual(1, page.PageNumber);
            Assert.AreEqual(DocumentPageLengthUnit.Pixel, page.Unit);
            Assert.AreEqual(1700, page.Width);

            Assert.IsNotNull(document.Fields);
            var name = "PurchaseOrderNumber";
            Assert.IsNotNull(document.Fields[name]);
            Assert.AreEqual(DocumentFieldType.String, document.Fields[name].FieldType);
            Assert.AreEqual("948284", document.Fields[name].Content);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentWithCustomModelWithSelectionMarks()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            await using var customModel = await BuildDisposableDocumentModelAsync(ContainerType.SelectionMarks);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, customModel.ModelId, stream);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();
            DocumentPage page = result.Pages.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.
            Assert.IsNotEmpty(document.DocumentType);
            Assert.IsNotNull(document.Fields);
            var name = "AMEX_SELECTION_MARK";
            Assert.IsNotNull(document.Fields[name]);
            Assert.AreEqual(DocumentFieldType.SelectionMark, document.Fields[name].FieldType);
            Assert.AreEqual(DocumentSelectionMarkState.Selected, document.Fields[name].Value.AsSelectionMarkState());
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentWithCustomModelCanParseMultipageDocument(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            await using var customModel = await BuildDisposableDocumentModelAsync(ContainerType.MultipageFiles);

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, customModel.ModelId, stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, customModel.ModelId, uri);
            }

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2);

            // Check some values to make sure that fields from both pages are being populated.

            Assert.AreEqual("Jamie@southridgevideo.com", document.Fields["Contact"].Value.AsString());
            Assert.AreEqual("Southridge Video", document.Fields["CompanyName"].Value.AsString());
            Assert.AreEqual("$1,500", document.Fields["Gold"].Value.AsString());
            Assert.AreEqual("$1,000", document.Fields["Bronze"].Value.AsString());

            Assert.AreEqual(2, result.Pages.Count);

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                DocumentPage page = result.Pages[pageIndex];

                // Basic sanity test to make sure pages are ordered correctly.

                DocumentLine sampleLine = page.Lines[1];
                var expectedContent = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.AreEqual(expectedContent, sampleLine.Content);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentWithCustomModelCanParseMultipageDocumentWithBlankPage(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            await using var customModel = await BuildDisposableDocumentModelAsync();

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, customModel.ModelId, stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipageBlank);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, customModel.ModelId, uri);
            }

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 3);

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                if (pageIndex == 0 || pageIndex == 2)
                {
                    var page = result.Pages[pageIndex];
                    var expectedContent = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.True(page.Lines.Any(l => l.Content.Contains(expectedContent)));
                }
            }

            DocumentPage blankPage = result.Pages[1];

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Words.Count);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentWithCustomModelCanParseDifferentTypeOfDocument()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            // Use Form_<id>.<ext> files for building model.

            await using var customModel = await BuildDisposableDocumentModelAsync();

            // Attempt to recognize a different type of document: Invoice_1.pdf. This document does not contain all the labels
            // the newly built model expects.

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoicePdf);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, customModel.ModelId, stream);
            }

            AnalyzeResult result = operation.Value;
            var fields = result.Documents.Single().Fields;

            // Verify that we got back at least one missing field to make sure we hit the code path we want to test.
            // The missing field is returned with its type set to Unknown.

            Assert.IsTrue(fields.Values.Any(field =>
                field.FieldType == DocumentFieldType.Unknown && field.ExpectedFieldType == DocumentFieldType.String));
        }

        [RecordedTest]
        [Ignore("Service error. Issue https://github.com/Azure/azure-sdk-for-net/issues/24995")]
        public async Task AnalyzeDocumentWithCustomModelCanParseBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            await using var customModel = await BuildDisposableDocumentModelAsync();

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, customModel.ModelId, stream);
            }

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.IsEmpty(result.Paragraphs);
            Assert.IsEmpty(result.KeyValuePairs);
            Assert.IsEmpty(result.Styles);
            Assert.IsEmpty(result.Tables);

            AnalyzedDocument blankDocument = result.Documents.Single();

            Assert.IsEmpty(blankDocument.Spans);

            DocumentPage blankPage = result.Pages.Single();

            Assert.IsEmpty(blankPage.Lines);
            Assert.IsEmpty(blankPage.Words);
            Assert.IsEmpty(blankPage.SelectionMarks);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentWithCustomModelThrowsForDamagedFile()
        {
            var client = CreateDocumentAnalysisClient();

            await using var customModel = await BuildDisposableDocumentModelAsync();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentAsync(WaitUntil.Started, customModel.ModelId, stream));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentFromUriWithCustomModelThrowsForNonExistingContent()
        {
            var client = CreateDocumentAnalysisClient();

            await using var customModel = await BuildDisposableDocumentModelAsync();

            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, customModel.ModelId, invalidUri));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion

        #region Document

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentPopulatesDocumentPageJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-document", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-document", uri);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;
            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the document. We are not testing the service here, but the SDK.

            Assert.AreEqual(DocumentPageLengthUnit.Pixel, page.Unit);
            Assert.AreEqual(1700, page.Width);
            Assert.AreEqual(2200, page.Height);
            Assert.AreEqual(0, page.Angle);
            Assert.AreEqual(54, page.Lines.Count);

            foreach (DocumentLine line in page.Lines)
            {
                Assert.NotNull(line.Content);
            }

            foreach (DocumentWord word in page.Words)
            {
                Assert.NotNull(word.Content);
                Assert.GreaterOrEqual(word.Confidence, 0);
            }

            DocumentStyle style = result.Styles.First();

            Assert.True(style.IsHandwritten);

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                Assert.AreEqual(52, result.Paragraphs.Count);
            }
            else
            {
                Assert.AreEqual(38, result.Paragraphs.Count);
            }

            DocumentParagraph sampleParagraph = result.Paragraphs[1];

            Assert.AreEqual("Hero Limited", sampleParagraph.Content);
            Assert.AreEqual(ParagraphRole.Title, sampleParagraph.Role);

            Assert.AreEqual(2, result.Tables.Count);

            DocumentTable sampleTable = result.Tables[1];

            Assert.AreEqual(3, sampleTable.RowCount);
            Assert.AreEqual(2, sampleTable.ColumnCount);

            var cells = sampleTable.Cells.ToList();

            Assert.AreEqual(6, cells.Count);

            var expectedContent = new string[3, 2]
            {
                { "SUBTOTAL", "$140.00" },
                { "TAX", "$4.00" },
                { "TOTAL", "$144.00" }
            };

            for (int i = 0; i < cells.Count; i++)
            {
                Assert.GreaterOrEqual(cells[i].RowIndex, 0, $"Cell with content {cells[i].Content} should have row index greater than or equal to zero.");
                Assert.Less(cells[i].RowIndex, sampleTable.RowCount, $"Cell with content {cells[i].Content} should have row index less than {sampleTable.RowCount}.");
                Assert.GreaterOrEqual(cells[i].ColumnIndex, 0, $"Cell with content {cells[i].Content} should have column index greater than or equal to zero.");
                Assert.Less(cells[i].ColumnIndex, sampleTable.ColumnCount, $"Cell with content {cells[i].Content} should have column index less than {sampleTable.ColumnCount}.");

                Assert.AreEqual(1, cells[i].RowSpan, $"Cell with content {cells[i].Content} should have a row span of 1.");
                Assert.AreEqual(1, cells[i].ColumnSpan, $"Cell with content {cells[i].Content} should have a column span of 1.");

                Assert.AreEqual(expectedContent[cells[i].RowIndex, cells[i].ColumnIndex], cells[i].Content);
            }

            ValidateAnalyzeResult(
                result,
                "prebuilt-document",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        #endregion

        #region Identity Documents

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentPopulatesExtractedIdDocumentJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-idDocument", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.DriverLicenseJpg);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-idDocument", uri);
            }

            Assert.IsTrue(operation.HasValue);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-idDocument",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            var document = operation.Value.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the ID document. We are not testing the service here, but the SDK.

            Assert.AreEqual("idDocument.driverLicense", document.DocumentType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("Address"));
            Assert.True(document.Fields.ContainsKey("CountryRegion"));
            Assert.True(document.Fields.ContainsKey("DateOfBirth"));
            Assert.True(document.Fields.ContainsKey("DateOfExpiration"));
            Assert.True(document.Fields.ContainsKey("DocumentNumber"));
            Assert.True(document.Fields.ContainsKey("FirstName"));
            Assert.True(document.Fields.ContainsKey("LastName"));
            Assert.True(document.Fields.ContainsKey("Region"));
            Assert.True(document.Fields.ContainsKey("Sex"));

            AddressValue address = document.Fields["Address"].Value.AsAddress();
            Assert.AreEqual("YOUR CITY", address.City);
            Assert.Null(address.CountryRegion);
            Assert.Null(address.HouseNumber);
            Assert.Null(address.PoBox);
            Assert.AreEqual("99999-1234", address.PostalCode);
            Assert.AreEqual("123 STREET ADDRESS", address.Road);
            Assert.AreEqual("WA", address.State);
            Assert.AreEqual("123 STREET ADDRESS", address.StreetAddress);

            Assert.That(document.Fields["CountryRegion"].Value.AsCountryRegion(), Is.EqualTo("USA"));

            var dateOfBirth = document.Fields["DateOfBirth"].Value.AsDate();
            Assert.AreEqual(6, dateOfBirth.Day);
            Assert.AreEqual(1, dateOfBirth.Month);
            Assert.AreEqual(1958, dateOfBirth.Year);

            var dateOfExpiration = document.Fields["DateOfExpiration"].Value.AsDate();
            Assert.AreEqual(12, dateOfExpiration.Day);
            Assert.AreEqual(8, dateOfExpiration.Month);
            Assert.AreEqual(2020, dateOfExpiration.Year);
        }

        #endregion

        #region Invoices

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentPopulatesExtractedInvoiceJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceJpg);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-invoice", uri);
            }

            Assert.IsTrue(operation.HasValue);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-invoice",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("invoice", document.DocumentType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("AmountDue"));
            Assert.True(document.Fields.ContainsKey("BillingAddress"));
            Assert.True(document.Fields.ContainsKey("BillingAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("CustomerAddress"));
            Assert.True(document.Fields.ContainsKey("CustomerAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("CustomerId"));
            Assert.True(document.Fields.ContainsKey("CustomerName"));
            Assert.True(document.Fields.ContainsKey("DueDate"));
            Assert.True(document.Fields.ContainsKey("InvoiceDate"));
            Assert.True(document.Fields.ContainsKey("InvoiceId"));
            Assert.True(document.Fields.ContainsKey("InvoiceTotal"));
            Assert.True(document.Fields.ContainsKey("Items"));
            Assert.True(document.Fields.ContainsKey("PreviousUnpaidBalance"));
            Assert.True(document.Fields.ContainsKey("PurchaseOrder"));
            Assert.True(document.Fields.ContainsKey("RemittanceAddress"));
            Assert.True(document.Fields.ContainsKey("RemittanceAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("ServiceAddress"));
            Assert.True(document.Fields.ContainsKey("ServiceAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("ServiceEndDate"));
            Assert.True(document.Fields.ContainsKey("ServiceStartDate"));
            Assert.True(document.Fields.ContainsKey("ShippingAddress"));
            Assert.True(document.Fields.ContainsKey("ShippingAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("SubTotal"));
            Assert.True(document.Fields.ContainsKey("TotalTax"));
            Assert.True(document.Fields.ContainsKey("VendorAddress"));
            Assert.True(document.Fields.ContainsKey("VendorAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("VendorName"));

            ValidateCurrencyValue(document.Fields["AmountDue"].Value.AsCurrency(), 610.00, "$", "USD");

            AddressValue billingAddress = document.Fields["BillingAddress"].Value.AsAddress();
            Assert.AreEqual("Redmond", billingAddress.City);
            Assert.Null(billingAddress.CountryRegion);
            Assert.AreEqual("123", billingAddress.HouseNumber);
            Assert.Null(billingAddress.PoBox);
            Assert.AreEqual("98052", billingAddress.PostalCode);
            Assert.AreEqual("Bill St", billingAddress.Road);
            Assert.AreEqual("WA", billingAddress.State);
            Assert.AreEqual("123 Bill St", billingAddress.StreetAddress);

            AddressValue customerAddress = document.Fields["CustomerAddress"].Value.AsAddress();
            Assert.AreEqual("Redmond", customerAddress.City);
            Assert.Null(customerAddress.CountryRegion);
            Assert.AreEqual("123", customerAddress.HouseNumber);
            Assert.Null(customerAddress.PoBox);
            Assert.AreEqual("98052", customerAddress.PostalCode);
            Assert.AreEqual("Other St", customerAddress.Road);
            Assert.AreEqual("WA", customerAddress.State);
            Assert.AreEqual("123 Other St", customerAddress.StreetAddress);

            Assert.AreEqual("Microsoft Finance", document.Fields["BillingAddressRecipient"].Value.AsString());
            Assert.AreEqual("Microsoft Corp", document.Fields["CustomerAddressRecipient"].Value.AsString());
            Assert.AreEqual("CID-12345", document.Fields["CustomerId"].Value.AsString());
            Assert.AreEqual("MICROSOFT CORPORATION", document.Fields["CustomerName"].Value.AsString());

            var dueDate = document.Fields["DueDate"].Value.AsDate();
            Assert.AreEqual(15, dueDate.Day);
            Assert.AreEqual(12, dueDate.Month);
            Assert.AreEqual(2019, dueDate.Year);

            var invoiceDate = document.Fields["InvoiceDate"].Value.AsDate();
            Assert.AreEqual(15, invoiceDate.Day);
            Assert.AreEqual(11, invoiceDate.Month);
            Assert.AreEqual(2019, invoiceDate.Year);

            Assert.AreEqual("INV-100", document.Fields["InvoiceId"].Value.AsString());
            ValidateCurrencyValue(document.Fields["InvoiceTotal"].Value.AsCurrency(), 110.00, "$", "USD");
            ValidateCurrencyValue(document.Fields["PreviousUnpaidBalance"].Value.AsCurrency(), 500.00, "$", "USD");
            Assert.AreEqual("PO-3333", document.Fields["PurchaseOrder"].Value.AsString());

            AddressValue remittanceAddress = document.Fields["RemittanceAddress"].Value.AsAddress();
            Assert.AreEqual("New York", remittanceAddress.City);
            Assert.Null(remittanceAddress.CountryRegion);
            Assert.AreEqual("123", remittanceAddress.HouseNumber);
            Assert.Null(remittanceAddress.PoBox);
            Assert.AreEqual("10001", remittanceAddress.PostalCode);
            Assert.AreEqual("Remit St", remittanceAddress.Road);
            Assert.AreEqual("NY", remittanceAddress.State);
            Assert.AreEqual("123 Remit St", remittanceAddress.StreetAddress);

            Assert.AreEqual("Contoso Billing", document.Fields["RemittanceAddressRecipient"].Value.AsString());

            AddressValue serviceAddress = document.Fields["ServiceAddress"].Value.AsAddress();
            Assert.AreEqual("Redmond", serviceAddress.City);
            Assert.Null(serviceAddress.CountryRegion);
            Assert.AreEqual("123", serviceAddress.HouseNumber);
            Assert.Null(serviceAddress.PoBox);
            Assert.AreEqual("98052", serviceAddress.PostalCode);
            Assert.AreEqual("Service St", serviceAddress.Road);
            Assert.AreEqual("WA", serviceAddress.State);
            Assert.AreEqual("123 Service St", serviceAddress.StreetAddress);

            Assert.AreEqual("Microsoft Services", document.Fields["ServiceAddressRecipient"].Value.AsString());

            var serviceEndDate = document.Fields["ServiceEndDate"].Value.AsDate();
            Assert.AreEqual(14, serviceEndDate.Day);
            Assert.AreEqual(11, serviceEndDate.Month);
            Assert.AreEqual(2019, serviceEndDate.Year);

            var serviceStartDate = document.Fields["ServiceStartDate"].Value.AsDate();
            Assert.AreEqual(14, serviceStartDate.Day);
            Assert.AreEqual(10, serviceStartDate.Month);
            Assert.AreEqual(2019, serviceStartDate.Year);

            AddressValue shippingAddress = document.Fields["ShippingAddress"].Value.AsAddress();
            Assert.AreEqual("Redmond", shippingAddress.City);
            Assert.Null(shippingAddress.CountryRegion);
            Assert.AreEqual("123", shippingAddress.HouseNumber);
            Assert.Null(shippingAddress.PoBox);
            Assert.AreEqual("98052", shippingAddress.PostalCode);
            Assert.AreEqual("Ship St", shippingAddress.Road);
            Assert.AreEqual("WA", shippingAddress.State);
            Assert.AreEqual("123 Ship St", shippingAddress.StreetAddress);

            Assert.AreEqual("Microsoft Delivery", document.Fields["ShippingAddressRecipient"].Value.AsString());
            ValidateCurrencyValue(document.Fields["SubTotal"].Value.AsCurrency(), 100.00, "$", "USD");
            ValidateCurrencyValue(document.Fields["TotalTax"].Value.AsCurrency(), 10.00, "$", "USD");

            AddressValue vendorAddress = document.Fields["VendorAddress"].Value.AsAddress();
            Assert.AreEqual("New York", vendorAddress.City);
            Assert.Null(vendorAddress.CountryRegion);
            Assert.AreEqual("123", vendorAddress.HouseNumber);
            Assert.Null(vendorAddress.PoBox);
            Assert.AreEqual("10001", vendorAddress.PostalCode);
            Assert.AreEqual("456th St", vendorAddress.Road);
            Assert.AreEqual("NY", vendorAddress.State);
            Assert.AreEqual("123 456th St", vendorAddress.StreetAddress);

            Assert.AreEqual("Contoso Headquarters", document.Fields["VendorAddressRecipient"].Value.AsString());
            Assert.AreEqual("CONTOSO LTD.", document.Fields["VendorName"].Value.AsString());

            var expectedItems = new List<(double Amount, DateTimeOffset Date, string Description, string ProductCode, double Quantity, string Unit, double UnitPrice, string UnitPriceCode)>()
            {
                (60f, DateTimeOffset.Parse("2021-04-03 00:00:00+00:00"), "Consulting Services", "A123", 2, "hours", 30, "USD"),
                (30f, DateTimeOffset.Parse("2021-05-03 00:00:00+00:00"), "Document Fee", "B456", 3, null, 10, "USD"),
                (10f, DateTimeOffset.Parse("2021-06-03 00:00:00+00:00"), "Printing Fee", "C789", 10, "pages", 1, "USD")
            };

            // Include a bit of tolerance when comparing double types.

            var items = document.Fields["Items"].Value.AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].Value.AsDictionary();

                receiptItemInfo.TryGetValue("Amount", out var amountField);
                receiptItemInfo.TryGetValue("Date", out var dateField);
                receiptItemInfo.TryGetValue("Description", out var descriptionField);
                receiptItemInfo.TryGetValue("ProductCode", out var productCodeField);
                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("UnitPrice", out var unitPricefield);
                receiptItemInfo.TryGetValue("Unit", out var unitfield);

                CurrencyValue amount = amountField.Value.AsCurrency();
                string description = descriptionField.Value.AsString();
                string productCode = productCodeField.Value.AsString();
                double quantity = quantityField.Value.AsDouble();
                CurrencyValue unitPrice = unitPricefield.Value.AsCurrency();
                string unit = unitfield?.Value.AsString();

                Assert.IsNotNull(dateField);
                DateTimeOffset date = dateField.Value.AsDate();

                var expectedItem = expectedItems[itemIndex];

                ValidateCurrencyValue(amount, expectedItem.Amount, "$", "USD", $"Amount mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Date, date, $"Date mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Description, description, $"Description mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.ProductCode, productCode, $"ProductCode mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Unit, unit, $"Unit mismatch in item with index {itemIndex}.");
                Assert.That(quantity, Is.EqualTo(expectedItem.Quantity).Within(0.0001), $"Quantity mismatch in item with index {itemIndex}.");
                ValidateCurrencyValue(unitPrice, expectedItem.UnitPrice, "$", expectedItem.UnitPriceCode, $"UnitPrice mismatch in item with index {itemIndex}.");
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35243")]
        public async Task AnalyzeDocumentCanParseMultipageInvoice(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-invoice", uri);
            }

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-invoice",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2);

            var document = result.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("invoice", document.DocumentType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("VendorName"));
            Assert.True(document.Fields.ContainsKey("RemittanceAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("RemittanceAddress"));

            DocumentField vendorName = document.Fields["VendorName"];
            Assert.AreEqual(2, vendorName.BoundingRegions.First().PageNumber);
            Assert.AreEqual("Southridge Video", vendorName.Value.AsString());

            DocumentField addressRecipient = document.Fields["RemittanceAddressRecipient"];
            Assert.AreEqual(1, addressRecipient.BoundingRegions.First().PageNumber);
            Assert.AreEqual("Contoso Ltd.", addressRecipient.Value.AsString());

            DocumentField addressField = document.Fields["RemittanceAddress"];
            Assert.AreEqual(1, addressField.BoundingRegions.First().PageNumber);

            AddressValue address = addressField.Value.AsAddress();
            Assert.AreEqual("Birch", address.City);
            Assert.Null(address.CountryRegion);
            Assert.AreEqual("2345", address.HouseNumber);
            Assert.Null(address.PoBox);
            Assert.AreEqual("98123", address.PostalCode);
            Assert.AreEqual("Dogwood Lane", address.Road);
            Assert.AreEqual("Kansas", address.State);
            Assert.AreEqual("2345 Dogwood Lane", address.StreetAddress);
        }

        #endregion

        #region Layout

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentPopulatesLayoutPagePdf(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoicePdf);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoicePdf);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", uri);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-layout",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the document. We are not testing the service here, but the SDK.

            Assert.AreEqual(DocumentPageLengthUnit.Inch, page.Unit);
            Assert.AreEqual(8.5, page.Width);
            Assert.AreEqual(11, page.Height);
            Assert.AreEqual(0, page.Angle);
            Assert.AreEqual(18, page.Lines.Count);

            DocumentParagraph sampleParagraph = result.Paragraphs[0];

            Assert.AreEqual("Contoso", sampleParagraph.Content);
            Assert.IsNull(sampleParagraph.Role);

            DocumentTable table = result.Tables.Single();

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                Assert.AreEqual(2, table.RowCount);
            }
            else
            {
                Assert.AreEqual(3, table.RowCount);
            }

            Assert.AreEqual(5, table.ColumnCount);

            var cells = table.Cells.ToList();

            Assert.AreEqual(10, cells.Count);

            var expectedContent = new string[2, 5]
            {
                { "Invoice Number", "Invoice Date", "Invoice Due Date", "Charges", "VAT ID" },
                { "34278587", "6/18/2017", "6/24/2017", "$56,651.49", "PT" }
            };

            foreach (DocumentTableCell cell in cells)
            {
                Assert.GreaterOrEqual(cell.RowIndex, 0, $"Cell with content {cell.Content} should have row index greater than or equal to zero.");
                Assert.Less(cell.RowIndex, table.RowCount, $"Cell with content {cell.Content} should have row index less than {table.RowCount}.");
                Assert.GreaterOrEqual(cell.ColumnIndex, 0, $"Cell with content {cell.Content} should have column index greater than or equal to zero.");
                Assert.Less(cell.ColumnIndex, table.ColumnCount, $"Cell with content {cell.Content} should have column index less than {table.ColumnCount}.");

                if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
                {
                    Assert.AreEqual(1, cell.RowSpan, $"Cell with content {cell.Content} should have a row span of 1.");
                }
                else
                {
                    // Row = 1 has a row span of 2.
                    var expectedRowSpan = cell.RowIndex == 1 ? 2 : 1;

                    Assert.AreEqual(expectedRowSpan, cell.RowSpan, $"Cell with content {cell.Content} should have a row span of {expectedRowSpan}.");
                }

                Assert.LessOrEqual(cell.RowIndex, 2, $"Cell with content {cell.Content} should have a row index less than or equal to two.");
                Assert.AreEqual(expectedContent[cell.RowIndex, cell.ColumnIndex], cell.Content);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentCanParseMultipageLayout(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", uri);
            }

            AnalyzeResult result = operation.Value;

            Assert.AreEqual(2, result.Pages.Count);

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                DocumentPage page = result.Pages[pageIndex];

                ValidatePage(
                    page,
                    expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = page.Lines[1];
                var expectedContent = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.AreEqual(expectedContent, sampleLine.Content);
            }
        }

        [RecordedTest]
        public async Task AnalyzeDocumentCanParseMultipageLayoutWithBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream);
            }

            AnalyzeResult result = operation.Value;

            Assert.AreEqual(3, result.Pages.Count);

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                var page = result.Pages[pageIndex];

                ValidatePage(
                    page,
                    expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                if (pageIndex == 0 || pageIndex == 2)
                {
                    var expectedContent = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.True(page.Lines.Any(l => l.Content.Contains(expectedContent)));
                }
            }

            var blankPage = result.Pages[1];

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Words.Count);
        }

        [RecordedTest]
        public async Task AnalyzeDocumentLayoutWithSelectionMarks()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            ValidatePage(
                result.Pages.Single(),
                expectedPageNumber: 1);
        }

        #endregion

        #region Read

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentCanReadPageAndLanguage(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            var options = new AnalyzeDocumentOptions()
            {
                Features = { DocumentAnalysisFeature.Languages }
            };
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoicePdf);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-read", stream, options);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoicePdf);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-read", uri, options);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-read",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the document. We are not testing the service here, but the SDK.

            Assert.AreEqual(DocumentPageLengthUnit.Inch, page.Unit);
            Assert.AreEqual(8.5, page.Width);
            Assert.AreEqual(11, page.Height);
            Assert.AreEqual(0, page.Angle);
            Assert.AreEqual(18, page.Lines.Count);
            Assert.IsEmpty(result.Tables);

            Assert.IsNotEmpty(result.Languages);
        }

        #endregion

        #region Receipts

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentPopulatesExtractedReceiptJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.ReceiptJpg);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-receipt", uri);
            }

            Assert.IsTrue(operation.HasValue);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-receipt",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the receipt. We are not testing the service here, but the SDK.

            Assert.AreEqual("receipt.retailMeal", document.DocumentType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("MerchantAddress"));
            Assert.True(document.Fields.ContainsKey("MerchantName"));
            Assert.True(document.Fields.ContainsKey("MerchantPhoneNumber"));
            Assert.True(document.Fields.ContainsKey("TransactionDate"));
            Assert.True(document.Fields.ContainsKey("TransactionTime"));
            Assert.True(document.Fields.ContainsKey("Items"));
            Assert.True(document.Fields.ContainsKey("Subtotal"));
            Assert.True(document.Fields.ContainsKey("TotalTax"));
            Assert.True(document.Fields.ContainsKey("Total"));

            Assert.AreEqual("Contoso", document.Fields["MerchantName"].Value.AsString());

            AddressValue merchantAddress = document.Fields["MerchantAddress"].Value.AsAddress();
            Assert.AreEqual("Redmond", merchantAddress.City);
            Assert.Null(merchantAddress.CountryRegion);
            Assert.AreEqual("123", merchantAddress.HouseNumber);
            Assert.Null(merchantAddress.PoBox);
            Assert.AreEqual("98052", merchantAddress.PostalCode);
            Assert.AreEqual("Main Street", merchantAddress.Road);
            Assert.AreEqual("WA", merchantAddress.State);
            Assert.AreEqual("123 Main Street", merchantAddress.StreetAddress);

            Assert.AreEqual("123-456-7890", document.Fields["MerchantPhoneNumber"].Content);

            var date = document.Fields["TransactionDate"].Value.AsDate();
            var time = document.Fields["TransactionTime"].Value.AsTime();

            Assert.AreEqual(10, date.Day);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(2019, date.Year);

            Assert.AreEqual(13, time.Hours);
            Assert.AreEqual(59, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            var expectedItems = new List<(int? Quantity, string Description, double? Price, double? TotalPrice)>()
            {
                (1, "Surface Pro 6", null, 999.00),
                (1, "SurfacePen", null, 99.99)
            };

            // Include a bit of tolerance when comparing double types.

            var items = document.Fields["Items"].Value.AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].Value.AsDictionary();

                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("Description", out var descriptionField);
                receiptItemInfo.TryGetValue("Price", out var priceField);
                receiptItemInfo.TryGetValue("TotalPrice", out var totalPriceField);

                var quantity = quantityField == null ? null : (double?)quantityField.Value.AsDouble();
                var description = descriptionField == null ? null : descriptionField.Value.AsString();
                var price = priceField == null ? null : (double?)priceField.Value.AsDouble();
                var totalPrice = totalPriceField == null ? null : (double?)totalPriceField.Value.AsDouble();

                var expectedItem = expectedItems[itemIndex];

                Assert.AreEqual(expectedItem.Quantity, quantity, $"Quantity mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Description, description, $"Description mismatch in item with index {itemIndex}.");
                Assert.That(price, Is.EqualTo(expectedItem.Price).Within(0.0001), $"Price mismatch in item with index {itemIndex}.");
                Assert.That(totalPrice, Is.EqualTo(expectedItem.TotalPrice).Within(0.0001), $"Total price mismatch in item with index {itemIndex}.");
            }

            Assert.That(document.Fields["Subtotal"].Value.AsDouble(), Is.EqualTo(1098.99).Within(0.0001));
            Assert.That(document.Fields["TotalTax"].Value.AsDouble(), Is.EqualTo(104.40).Within(0.0001));
            Assert.That(document.Fields["Total"].Value.AsDouble(), Is.EqualTo(1203.39).Within(0.0001));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnalyzeDocumentCanParseMultipageReceipt(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.ReceiptMultipage);
                operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-receipt", uri);
            }

            AnalyzeResult result = operation.Value;

            Assert.AreEqual(2, result.Documents.Count);

            for (int documentIndex = 0; documentIndex < result.Documents.Count; documentIndex++)
            {
                var analyzedDocument = result.Documents[documentIndex];
                var expectedPageNumber = documentIndex + 1;

                Assert.NotNull(analyzedDocument);

                ValidateAnalyzedDocument(
                    analyzedDocument,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                var sampleField = analyzedDocument.Fields["Total"];
                Assert.IsNotNull(sampleField.Content);

                if (documentIndex == 0)
                {
                    Assert.AreEqual("$14.50", sampleField.Content);
                }
                else if (documentIndex == 1)
                {
                    Assert.AreEqual("$ 1203.39", sampleField.Content);
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeDocumentCanParseMultipageReceiptWithBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceipMultipageWithBlankPage);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", stream);
            }

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-receipt",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 3);

            Assert.AreEqual(3, result.Pages.Count);

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                var page = result.Pages[pageIndex];
                var expectedPageNumber = pageIndex + 1;

                Assert.NotNull(page);

                // Basic sanity test to make sure pages are ordered correctly.

                if (pageIndex == 0 || pageIndex == 2)
                {
                    var expectedContent = pageIndex == 0 ? "$14.50" : "1203.39";

                    Assert.True(page.Words.Any(w => w.Content == expectedContent));
                }
            }

            var blankPage = result.Pages[1];

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Words.Count);
        }

        #endregion

        #region Other
        [RecordedTest]
        public async Task DocumentLineGetWordsExtractsAllWords()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Form1);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream);
            }

            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            DocumentLine line = result.Pages[0].Lines[45];
            IReadOnlyList<DocumentWord> words = line.GetWords();

            Assert.AreEqual("Do not Jostle Box. Unpack carefully. Enjoy.", line.Content);
            Assert.AreEqual(7, words.Count);
            Assert.AreEqual("Do", words[0].Content);
            Assert.AreEqual("not", words[1].Content);
            Assert.AreEqual("Jostle", words[2].Content);
            Assert.AreEqual("Box.", words[3].Content);
            Assert.AreEqual("Unpack", words[4].Content);
            Assert.AreEqual("carefully.", words[5].Content);
            Assert.AreEqual("Enjoy.", words[6].Content);

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                line = result.Pages[0].Lines[52];
            }
            else
            {
                line = result.Pages[0].Lines[46];
            }

            words = line.GetWords();

            Assert.AreEqual("Jupiter Book Supply will refund you 50% per book if returned within 60 days of reading and", line.Content);
            Assert.AreEqual(17, words.Count);
            Assert.AreEqual("Jupiter", words[0].Content);
            Assert.AreEqual("Book", words[1].Content);
            Assert.AreEqual("Supply", words[2].Content);
            Assert.AreEqual("will", words[3].Content);
            Assert.AreEqual("refund", words[4].Content);
            Assert.AreEqual("you", words[5].Content);
            Assert.AreEqual("50%", words[6].Content);
            Assert.AreEqual("per", words[7].Content);
            Assert.AreEqual("book", words[8].Content);
            Assert.AreEqual("if", words[9].Content);
            Assert.AreEqual("returned", words[10].Content);
            Assert.AreEqual("within", words[11].Content);
            Assert.AreEqual("60", words[12].Content);
            Assert.AreEqual("days", words[13].Content);
            Assert.AreEqual("of", words[14].Content);
            Assert.AreEqual("reading", words[15].Content);
            Assert.AreEqual("and", words[16].Content);
        }
        #endregion

        #region Common

        [RecordedTest]
        public void DocumentAnalysisClientCannotAuthenticateWithFakeApiKey()
        {
            var client = CreateDocumentAnalysisClient(apiKey: "fakeKey");

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Form1);
            using (Recording.DisableRequestBodyRecording())
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentAsync(WaitUntil.Started, "prebuilt-layout", stream));
            }
        }

        [RecordedTest]
        public async Task AnalyzeDocumentCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentAnalysisClient(useTokenCredential: true);
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-receipt",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            AnalyzedDocument document = result.Documents.Single();
            Assert.NotNull(document);
        }

        [RecordedTest]
        [TestCase("prebuilt-businessCard")]
        [TestCase("prebuilt-document")]
        [TestCase("prebuilt-idDocument")]
        [TestCase("prebuilt-invoice")]
        [TestCase("prebuilt-layout")]
        [TestCase("prebuilt-receipt")]
        public async Task AnalyzeDocumentWithPrebuiltCanParseBlankPage(string modelId)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, modelId, stream);
            }

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                modelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.IsEmpty(result.KeyValuePairs);
            Assert.IsEmpty(result.Styles);
            Assert.IsEmpty(result.Tables);

            if (result.Documents.Count > 0)
            {
                AnalyzedDocument blankDocument = result.Documents.Single();

                Assert.IsEmpty(blankDocument.Fields);
            }

            DocumentPage blankPage = result.Pages.Single();

            Assert.IsEmpty(blankPage.Lines);
            Assert.IsEmpty(blankPage.Words);
            Assert.IsEmpty(blankPage.SelectionMarks);
        }

        [RecordedTest]
        [TestCase("prebuilt-businessCard")]
        [TestCase("prebuilt-document")]
        [TestCase("prebuilt-idDocument")]
        [TestCase("prebuilt-invoice")]
        [TestCase("prebuilt-layout")]
        [TestCase("prebuilt-receipt")]
        public void AnalyzeDocumentWithPrebuiltThrowsForDamagedFile(string modelId)
        {
            var client = CreateDocumentAnalysisClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentAsync(WaitUntil.Started, modelId, stream));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase("prebuilt-businessCard")]
        [TestCase("prebuilt-document")]
        [TestCase("prebuilt-idDocument")]
        [TestCase("prebuilt-invoice")]
        [TestCase("prebuilt-layout")]
        [TestCase("prebuilt-receipt")]
        public void AnalyzeDocumentFromUriWithPrebuiltThrowsForNonExistingContent(string modelId)
        {
            var client = CreateDocumentAnalysisClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, modelId, invalidUri));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase("prebuilt-businessCard")]
        [TestCase("prebuilt-document")]
        [TestCase("prebuilt-idDocument")]
        [TestCase("prebuilt-invoice")]
        [TestCase("prebuilt-layout")]
        [TestCase("prebuilt-receipt")]
        public void AnalyzeDocumentWithPrebuiltThrowsWithWrongLocale(string modelId)
        {
            var client = CreateDocumentAnalysisClient();
            var options = new AnalyzeDocumentOptions() { Locale = "not-locale" };

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            RequestFailedException ex;

            using (Recording.DisableRequestBodyRecording())
            {
                ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentAsync(WaitUntil.Started, modelId, stream, options));
            }

            Assert.AreEqual("InvalidArgument", ex.ErrorCode);
        }

        #endregion

        private void ValidateAnalyzeResult(AnalyzeResult result, string modelId, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.AreEqual(modelId, result.ModelId);

            // Check Analyzed Documents.

            foreach (AnalyzedDocument document in result.Documents)
            {
                ValidateAnalyzedDocument(document, expectedFirstPageNumber, expectedLastPageNumber);
            }

            // Check Document Key-Value Pairs.

            foreach (DocumentKeyValuePair kvp in result.KeyValuePairs)
            {
                Assert.That(kvp.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(kvp.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

                Assert.NotNull(kvp.Key);

                foreach (BoundingRegion region in kvp.Key.BoundingRegions)
                {
                    ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                }

                if (kvp.Value != null)
                {
                    foreach (BoundingRegion region in kvp.Value.BoundingRegions)
                    {
                        ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                    }
                }
            }

            // Check Document Pages.

            int currentPageNumber = expectedFirstPageNumber;

            foreach (DocumentPage page in result.Pages)
            {
                ValidatePage(page, currentPageNumber++);
            }

            Assert.AreEqual(expectedLastPageNumber, currentPageNumber - 1);

            // Check Paragraphs.

            foreach (DocumentParagraph paragraph in result.Paragraphs)
            {
                foreach (BoundingRegion region in paragraph.BoundingRegions)
                {
                    ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                }
            }

            // Check Document Styles.

            foreach (DocumentStyle style in result.Styles)
            {
                Assert.That(style.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(style.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }

            // Check Document Tables.

            foreach (DocumentTable table in result.Tables)
            {
                ValidateTable(table, expectedFirstPageNumber, expectedLastPageNumber);
            }

            // Check Document Languages.

            foreach (DocumentLanguage language in result.Languages)
            {
                Assert.That(language.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(language.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
                Assert.NotNull(language.Locale);
            }
        }

        private void ValidateAnalyzedDocument(AnalyzedDocument document, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(document.DocumentType);
            Assert.That(document.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.005));

            foreach (BoundingRegion region in document.BoundingRegions)
            {
                ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
            }

            Assert.NotNull(document.Fields);

            foreach (DocumentField field in document.Fields.Values)
            {
                if (field == null)
                {
                    continue;
                }

                // TODO: confidence should be returned.
                if (field.Confidence != null)
                {
                    Assert.That(field.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                    Assert.That(field.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
                }

                foreach (BoundingRegion region in field.BoundingRegions)
                {
                    ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                }
            }
        }

        private void ValidateBoundingRegion(BoundingRegion region, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(region);
            Assert.NotNull(region.BoundingPolygon);

            if (region.BoundingPolygon.Count != 0)
            {
                Assert.AreEqual(4, region.BoundingPolygon.Count);
            }

            Assert.That(region.PageNumber, Is.GreaterThanOrEqualTo(expectedFirstPageNumber).Or.LessThanOrEqualTo(expectedLastPageNumber));
        }

        private void ValidatePage(DocumentPage page, int expectedPageNumber)
        {
            Assert.AreEqual(expectedPageNumber, page.PageNumber);

            Assert.Greater(page.Width, 0.0);
            Assert.Greater(page.Height, 0.0);

            Assert.That(page.Angle, Is.GreaterThan(-180.0).Within(0.01));
            Assert.That(page.Angle, Is.LessThanOrEqualTo(180.0).Within(0.01));

            Assert.NotNull(page.Lines);

            foreach (DocumentLine line in page.Lines)
            {
                Assert.NotNull(line.BoundingPolygon);
                Assert.AreEqual(4, line.BoundingPolygon.Count);
            }

            ValidateSpanListsAreSortedAndDontOverlap(page.Lines.Select(l => l.Spans).ToList());

            Assert.NotNull(page.Words);

            foreach (DocumentWord word in page.Words)
            {
                Assert.NotNull(word.BoundingPolygon);
                Assert.AreEqual(4, word.BoundingPolygon.Count);

                Assert.That(word.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(word.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }

            ValidateSpansAreSortedAndDontOverlap(page.Words.Select(w => w.Span).ToList());

            Assert.NotNull(page.SelectionMarks);

            foreach (DocumentSelectionMark selectionMark in page.SelectionMarks)
            {
                Assert.NotNull(selectionMark.BoundingPolygon);
                Assert.AreEqual(4, selectionMark.BoundingPolygon.Count);

                Assert.That(selectionMark.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(selectionMark.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }
        }

        private void ValidateTable(DocumentTable table, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            foreach (BoundingRegion region in table.BoundingRegions)
            {
                ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
            }

            Assert.Greater(table.ColumnCount, 0);
            Assert.Greater(table.RowCount, 0);

            foreach (DocumentTableCell cell in table.Cells)
            {
                foreach (BoundingRegion region in cell.BoundingRegions)
                {
                    ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                }

                Assert.GreaterOrEqual(cell.ColumnIndex, 0);
                Assert.GreaterOrEqual(cell.RowIndex, 0);
                Assert.GreaterOrEqual(cell.ColumnSpan, 1);
                Assert.GreaterOrEqual(cell.RowSpan, 1);
                Assert.NotNull(cell.Content);
            }
        }

        private void ValidateSpansAreSortedAndDontOverlap(IReadOnlyList<DocumentSpan> spans)
        {
            for (int i = 0; i < spans.Count - 1; i++)
            {
                Assert.GreaterOrEqual(spans[i + 1].Index, spans[i].Index + spans[i].Length);
            }
        }

        private void ValidateSpanListsAreSortedAndDontOverlap(IReadOnlyList<IReadOnlyList<DocumentSpan>> spanLists)
        {
            for (int i = 0; i < spanLists.Count - 1; i++)
            {
                IReadOnlyList<DocumentSpan> currentSpans = spanLists[i];
                IReadOnlyList<DocumentSpan> nextSpans = spanLists[i + 1];

                ValidateSpansAreSortedAndDontOverlap(currentSpans);

                DocumentSpan lastCurrentSpan = currentSpans.Last();
                DocumentSpan firstNextSpan = nextSpans.First();

                Assert.GreaterOrEqual(firstNextSpan.Index, lastCurrentSpan.Index + lastCurrentSpan.Length);
            }

            // Could be empty if document page contained no lines, for example.
            if (spanLists.Count > 0)
            {
                ValidateSpansAreSortedAndDontOverlap(spanLists.Last());
            }
        }

        private void ValidateCurrencyValue(CurrencyValue value, double expectedAmount, string expectedSymbol, string expectedCode, string message = null)
        {
            Assert.That(value.Amount, Is.EqualTo(expectedAmount).Within(0.0001), message);
            Assert.AreEqual(expectedSymbol, value.Symbol, message);

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                Assert.AreEqual(expectedCode, value.Code, message);
            }
            else
            {
                Assert.Null(value.Code, message);
            }
        }
    }
}
