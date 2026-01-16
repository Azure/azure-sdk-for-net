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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-businessCard",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.That(result.Paragraphs.Count, Is.EqualTo(4));

            // Check just one paragraph to make sure we're parsing them.

            DocumentParagraph sampleParagraph = result.Paragraphs[0];

            Assert.That(sampleParagraph.Content, Is.EqualTo("Dr. Avery Smith Senior Researcher Cloud & Al Department"));
            Assert.That(sampleParagraph.Role, Is.Null);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.That(document, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.That(document.DocumentType, Is.EqualTo("businessCard"));

            Assert.That(document.Fields, Is.Not.Null);

            Assert.That(document.Fields.ContainsKey("ContactNames"), Is.True);
            Assert.That(document.Fields.ContainsKey("JobTitles"), Is.True);
            Assert.That(document.Fields.ContainsKey("Departments"), Is.True);
            Assert.That(document.Fields.ContainsKey("Emails"), Is.True);
            Assert.That(document.Fields.ContainsKey("Websites"), Is.True);
            Assert.That(document.Fields.ContainsKey("MobilePhones"), Is.True);
            Assert.That(document.Fields.ContainsKey("WorkPhones"), Is.True);
            Assert.That(document.Fields.ContainsKey("Faxes"), Is.True);
            Assert.That(document.Fields.ContainsKey("Addresses"), Is.True);
            Assert.That(document.Fields.ContainsKey("CompanyNames"), Is.True);

            var contactNames = document.Fields["ContactNames"].Value.AsList();
            Assert.That(contactNames.Count, Is.EqualTo(1));
            Assert.That(contactNames.FirstOrDefault().Content, Is.EqualTo("Dr. Avery Smith"));

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.That(contactNamesDict.ContainsKey("FirstName"), Is.True);
            Assert.That(contactNamesDict["FirstName"].Value.AsString(), Is.EqualTo("Avery"));

            Assert.That(contactNamesDict.ContainsKey("LastName"), Is.True);
            Assert.That(contactNamesDict["LastName"].Value.AsString(), Is.EqualTo("Smith"));

            var jobTitles = document.Fields["JobTitles"].Value.AsList();
            Assert.That(jobTitles.Count, Is.EqualTo(1));
            Assert.That(jobTitles.FirstOrDefault().Value.AsString(), Is.EqualTo("Senior Researcher"));

            var departments = document.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.That(departments.FirstOrDefault().Value.AsString(), Is.EqualTo("Cloud & Al Department"));

            var emails = document.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.That(emails.FirstOrDefault().Value.AsString(), Is.EqualTo("avery.smith@contoso.com"));

            var websites = document.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.That(websites.FirstOrDefault().Value.AsString(), Is.EqualTo("https://www.contoso.com/"));

            var mobilePhones = document.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.That(mobilePhones.FirstOrDefault().FieldType, Is.EqualTo(DocumentFieldType.PhoneNumber));

            var otherPhones = document.Fields["WorkPhones"].Value.AsList();
            Assert.That(otherPhones.Count, Is.EqualTo(1));
            Assert.That(otherPhones.FirstOrDefault().FieldType, Is.EqualTo(DocumentFieldType.PhoneNumber));

            var faxes = document.Fields["Faxes"].Value.AsList();
            Assert.That(faxes.Count, Is.EqualTo(1));
            Assert.That(faxes.FirstOrDefault().FieldType, Is.EqualTo(DocumentFieldType.PhoneNumber));

            var addresses = document.Fields["Addresses"].Value.AsList();
            Assert.That(addresses.Count, Is.EqualTo(1));

            AddressValue address = addresses.First().Value.AsAddress();
            Assert.That(address.City, Is.EqualTo("London"));
            Assert.That(address.CountryRegion, Is.Null);
            Assert.That(address.HouseNumber, Is.EqualTo("2"));
            Assert.That(address.PoBox, Is.Null);
            Assert.That(address.PostalCode, Is.EqualTo("W2 6BD"));
            Assert.That(address.Road, Is.EqualTo("Kingdom Street"));
            Assert.That(address.State, Is.Null);
            Assert.That(address.StreetAddress, Is.EqualTo("2 Kingdom Street"));

            var companyNames = document.Fields["CompanyNames"].Value.AsList();
            Assert.That(companyNames.Count, Is.EqualTo(1));
            Assert.That(companyNames.FirstOrDefault().Value.AsString(), Is.EqualTo("Contoso"));
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

            Assert.That(result.Documents.Count, Is.EqualTo(2));

            for (int documentIndex = 0; documentIndex < result.Documents.Count; documentIndex++)
            {
                var analyzedDocument = result.Documents[documentIndex];
                var expectedPageNumber = documentIndex + 1;

                Assert.That(analyzedDocument, Is.Not.Null);

                ValidateAnalyzedDocument(
                    analyzedDocument,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                Assert.That(analyzedDocument.Fields.ContainsKey("Emails"), Is.True);

                DocumentField sampleField = analyzedDocument.Fields["Emails"];

                Assert.That(sampleField.FieldType, Is.EqualTo(DocumentFieldType.List));

                var field = sampleField.Value.AsList().Single();

                if (documentIndex == 0)
                {
                    Assert.That(field.Content, Is.EqualTo("johnsinger@contoso.com"));
                }
                else if (documentIndex == 1)
                {
                    Assert.That(field.Content, Is.EqualTo("avery.smith@contoso.com"));
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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();
            DocumentPage page = result.Pages.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.

            Assert.That(document.DocumentType, Is.Not.Empty);
            Assert.That(page.Height, Is.EqualTo(2200));
            Assert.That(page.PageNumber, Is.EqualTo(1));
            Assert.That(page.Unit, Is.EqualTo(DocumentPageLengthUnit.Pixel));
            Assert.That(page.Width, Is.EqualTo(1700));

            Assert.That(document.Fields, Is.Not.Null);
            var name = "PurchaseOrderNumber";
            Assert.That(document.Fields[name], Is.Not.Null);
            Assert.That(document.Fields[name].FieldType, Is.EqualTo(DocumentFieldType.String));
            Assert.That(document.Fields[name].Content, Is.EqualTo("948284"));
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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();
            DocumentPage page = result.Pages.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.
            Assert.That(document.DocumentType, Is.Not.Empty);
            Assert.That(document.Fields, Is.Not.Null);
            var name = "AMEX_SELECTION_MARK";
            Assert.That(document.Fields[name], Is.Not.Null);
            Assert.That(document.Fields[name].FieldType, Is.EqualTo(DocumentFieldType.SelectionMark));
            Assert.That(document.Fields[name].Value.AsSelectionMarkState(), Is.EqualTo(DocumentSelectionMarkState.Selected));
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

            Assert.That(document.Fields["Contact"].Value.AsString(), Is.EqualTo("Jamie@southridgevideo.com"));
            Assert.That(document.Fields["CompanyName"].Value.AsString(), Is.EqualTo("Southridge Video"));
            Assert.That(document.Fields["Gold"].Value.AsString(), Is.EqualTo("$1,500"));
            Assert.That(document.Fields["Bronze"].Value.AsString(), Is.EqualTo("$1,000"));

            Assert.That(result.Pages.Count, Is.EqualTo(2));

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                DocumentPage page = result.Pages[pageIndex];

                // Basic sanity test to make sure pages are ordered correctly.

                DocumentLine sampleLine = page.Lines[1];
                var expectedContent = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.That(sampleLine.Content, Is.EqualTo(expectedContent));
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

                    Assert.That(page.Lines.Any(l => l.Content.Contains(expectedContent)), Is.True);
                }
            }

            DocumentPage blankPage = result.Pages[1];

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Words.Count, Is.EqualTo(0));
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

            Assert.That(fields.Values.Any(field =>
                field.FieldType == DocumentFieldType.Unknown && field.ExpectedFieldType == DocumentFieldType.String), Is.True);
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

            Assert.That(result.Paragraphs, Is.Empty);
            Assert.That(result.KeyValuePairs, Is.Empty);
            Assert.That(result.Styles, Is.Empty);
            Assert.That(result.Tables, Is.Empty);

            AnalyzedDocument blankDocument = result.Documents.Single();

            Assert.That(blankDocument.Spans, Is.Empty);

            DocumentPage blankPage = result.Pages.Single();

            Assert.That(blankPage.Lines, Is.Empty);
            Assert.That(blankPage.Words, Is.Empty);
            Assert.That(blankPage.SelectionMarks, Is.Empty);
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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidRequest"));
        }

        [RecordedTest]
        public async Task AnalyzeDocumentFromUriWithCustomModelThrowsForNonExistingContent()
        {
            var client = CreateDocumentAnalysisClient();

            await using var customModel = await BuildDisposableDocumentModelAsync();

            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, customModel.ModelId, invalidUri));
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidRequest"));
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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;
            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the document. We are not testing the service here, but the SDK.

            Assert.That(page.Unit, Is.EqualTo(DocumentPageLengthUnit.Pixel));
            Assert.That(page.Width, Is.EqualTo(1700));
            Assert.That(page.Height, Is.EqualTo(2200));
            Assert.That(page.Angle, Is.EqualTo(0));
            Assert.That(page.Lines.Count, Is.EqualTo(54));

            foreach (DocumentLine line in page.Lines)
            {
                Assert.That(line.Content, Is.Not.Null);
            }

            foreach (DocumentWord word in page.Words)
            {
                Assert.That(word.Content, Is.Not.Null);
                Assert.That(word.Confidence, Is.GreaterThanOrEqualTo(0));
            }

            DocumentStyle style = result.Styles.First();

            Assert.That(style.IsHandwritten, Is.True);

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                Assert.That(result.Paragraphs.Count, Is.EqualTo(52));
            }
            else
            {
                Assert.That(result.Paragraphs.Count, Is.EqualTo(38));
            }

            DocumentParagraph sampleParagraph = result.Paragraphs[1];

            Assert.That(sampleParagraph.Content, Is.EqualTo("Hero Limited"));
            Assert.That(sampleParagraph.Role, Is.EqualTo(ParagraphRole.Title));

            Assert.That(result.Tables.Count, Is.EqualTo(2));

            DocumentTable sampleTable = result.Tables[1];

            Assert.That(sampleTable.RowCount, Is.EqualTo(3));
            Assert.That(sampleTable.ColumnCount, Is.EqualTo(2));

            var cells = sampleTable.Cells.ToList();

            Assert.That(cells.Count, Is.EqualTo(6));

            var expectedContent = new string[3, 2]
            {
                { "SUBTOTAL", "$140.00" },
                { "TAX", "$4.00" },
                { "TOTAL", "$144.00" }
            };

            for (int i = 0; i < cells.Count; i++)
            {
                Assert.That(cells[i].RowIndex, Is.GreaterThanOrEqualTo(0), $"Cell with content {cells[i].Content} should have row index greater than or equal to zero.");
                Assert.That(cells[i].RowIndex, Is.LessThan(sampleTable.RowCount), $"Cell with content {cells[i].Content} should have row index less than {sampleTable.RowCount}.");
                Assert.That(cells[i].ColumnIndex, Is.GreaterThanOrEqualTo(0), $"Cell with content {cells[i].Content} should have column index greater than or equal to zero.");
                Assert.That(cells[i].ColumnIndex, Is.LessThan(sampleTable.ColumnCount), $"Cell with content {cells[i].Content} should have column index less than {sampleTable.ColumnCount}.");

                Assert.That(cells[i].RowSpan, Is.EqualTo(1), $"Cell with content {cells[i].Content} should have a row span of 1.");
                Assert.That(cells[i].ColumnSpan, Is.EqualTo(1), $"Cell with content {cells[i].Content} should have a column span of 1.");

                Assert.That(cells[i].Content, Is.EqualTo(expectedContent[cells[i].RowIndex, cells[i].ColumnIndex]));
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

            Assert.That(operation.HasValue, Is.True);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-idDocument",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            var document = operation.Value.Documents.Single();

            Assert.That(document, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the ID document. We are not testing the service here, but the SDK.

            Assert.That(document.DocumentType, Is.EqualTo("idDocument.driverLicense"));

            Assert.That(document.Fields, Is.Not.Null);

            Assert.That(document.Fields.ContainsKey("Address"), Is.True);
            Assert.That(document.Fields.ContainsKey("CountryRegion"), Is.True);
            Assert.That(document.Fields.ContainsKey("DateOfBirth"), Is.True);
            Assert.That(document.Fields.ContainsKey("DateOfExpiration"), Is.True);
            Assert.That(document.Fields.ContainsKey("DocumentNumber"), Is.True);
            Assert.That(document.Fields.ContainsKey("FirstName"), Is.True);
            Assert.That(document.Fields.ContainsKey("LastName"), Is.True);
            Assert.That(document.Fields.ContainsKey("Region"), Is.True);
            Assert.That(document.Fields.ContainsKey("Sex"), Is.True);

            AddressValue address = document.Fields["Address"].Value.AsAddress();
            Assert.That(address.City, Is.EqualTo("YOUR CITY"));
            Assert.That(address.CountryRegion, Is.Null);
            Assert.That(address.HouseNumber, Is.Null);
            Assert.That(address.PoBox, Is.Null);
            Assert.That(address.PostalCode, Is.EqualTo("99999-1234"));
            Assert.That(address.Road, Is.EqualTo("123 STREET ADDRESS"));
            Assert.That(address.State, Is.EqualTo("WA"));
            Assert.That(address.StreetAddress, Is.EqualTo("123 STREET ADDRESS"));

            Assert.That(document.Fields["CountryRegion"].Value.AsCountryRegion(), Is.EqualTo("USA"));

            var dateOfBirth = document.Fields["DateOfBirth"].Value.AsDate();
            Assert.That(dateOfBirth.Day, Is.EqualTo(6));
            Assert.That(dateOfBirth.Month, Is.EqualTo(1));
            Assert.That(dateOfBirth.Year, Is.EqualTo(1958));

            var dateOfExpiration = document.Fields["DateOfExpiration"].Value.AsDate();
            Assert.That(dateOfExpiration.Day, Is.EqualTo(12));
            Assert.That(dateOfExpiration.Month, Is.EqualTo(8));
            Assert.That(dateOfExpiration.Year, Is.EqualTo(2020));
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

            Assert.That(operation.HasValue, Is.True);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-invoice",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.That(document, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.That(document.DocumentType, Is.EqualTo("invoice"));

            Assert.That(document.Fields, Is.Not.Null);

            Assert.That(document.Fields.ContainsKey("AmountDue"), Is.True);
            Assert.That(document.Fields.ContainsKey("BillingAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("BillingAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("CustomerAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("CustomerAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("CustomerId"), Is.True);
            Assert.That(document.Fields.ContainsKey("CustomerName"), Is.True);
            Assert.That(document.Fields.ContainsKey("DueDate"), Is.True);
            Assert.That(document.Fields.ContainsKey("InvoiceDate"), Is.True);
            Assert.That(document.Fields.ContainsKey("InvoiceId"), Is.True);
            Assert.That(document.Fields.ContainsKey("InvoiceTotal"), Is.True);
            Assert.That(document.Fields.ContainsKey("Items"), Is.True);
            Assert.That(document.Fields.ContainsKey("PreviousUnpaidBalance"), Is.True);
            Assert.That(document.Fields.ContainsKey("PurchaseOrder"), Is.True);
            Assert.That(document.Fields.ContainsKey("RemittanceAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("RemittanceAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("ServiceAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("ServiceAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("ServiceEndDate"), Is.True);
            Assert.That(document.Fields.ContainsKey("ServiceStartDate"), Is.True);
            Assert.That(document.Fields.ContainsKey("ShippingAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("ShippingAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("SubTotal"), Is.True);
            Assert.That(document.Fields.ContainsKey("TotalTax"), Is.True);
            Assert.That(document.Fields.ContainsKey("VendorAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("VendorAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("VendorName"), Is.True);

            ValidateCurrencyValue(document.Fields["AmountDue"].Value.AsCurrency(), 610.00, "$", "USD");

            AddressValue billingAddress = document.Fields["BillingAddress"].Value.AsAddress();
            Assert.That(billingAddress.City, Is.EqualTo("Redmond"));
            Assert.That(billingAddress.CountryRegion, Is.Null);
            Assert.That(billingAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(billingAddress.PoBox, Is.Null);
            Assert.That(billingAddress.PostalCode, Is.EqualTo("98052"));
            Assert.That(billingAddress.Road, Is.EqualTo("Bill St"));
            Assert.That(billingAddress.State, Is.EqualTo("WA"));
            Assert.That(billingAddress.StreetAddress, Is.EqualTo("123 Bill St"));

            AddressValue customerAddress = document.Fields["CustomerAddress"].Value.AsAddress();
            Assert.That(customerAddress.City, Is.EqualTo("Redmond"));
            Assert.That(customerAddress.CountryRegion, Is.Null);
            Assert.That(customerAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(customerAddress.PoBox, Is.Null);
            Assert.That(customerAddress.PostalCode, Is.EqualTo("98052"));
            Assert.That(customerAddress.Road, Is.EqualTo("Other St"));
            Assert.That(customerAddress.State, Is.EqualTo("WA"));
            Assert.That(customerAddress.StreetAddress, Is.EqualTo("123 Other St"));

            Assert.That(document.Fields["BillingAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Finance"));
            Assert.That(document.Fields["CustomerAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Corp"));
            Assert.That(document.Fields["CustomerId"].Value.AsString(), Is.EqualTo("CID-12345"));
            Assert.That(document.Fields["CustomerName"].Value.AsString(), Is.EqualTo("MICROSOFT CORPORATION"));

            var dueDate = document.Fields["DueDate"].Value.AsDate();
            Assert.That(dueDate.Day, Is.EqualTo(15));
            Assert.That(dueDate.Month, Is.EqualTo(12));
            Assert.That(dueDate.Year, Is.EqualTo(2019));

            var invoiceDate = document.Fields["InvoiceDate"].Value.AsDate();
            Assert.That(invoiceDate.Day, Is.EqualTo(15));
            Assert.That(invoiceDate.Month, Is.EqualTo(11));
            Assert.That(invoiceDate.Year, Is.EqualTo(2019));

            Assert.That(document.Fields["InvoiceId"].Value.AsString(), Is.EqualTo("INV-100"));
            ValidateCurrencyValue(document.Fields["InvoiceTotal"].Value.AsCurrency(), 110.00, "$", "USD");
            ValidateCurrencyValue(document.Fields["PreviousUnpaidBalance"].Value.AsCurrency(), 500.00, "$", "USD");
            Assert.That(document.Fields["PurchaseOrder"].Value.AsString(), Is.EqualTo("PO-3333"));

            AddressValue remittanceAddress = document.Fields["RemittanceAddress"].Value.AsAddress();
            Assert.That(remittanceAddress.City, Is.EqualTo("New York"));
            Assert.That(remittanceAddress.CountryRegion, Is.Null);
            Assert.That(remittanceAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(remittanceAddress.PoBox, Is.Null);
            Assert.That(remittanceAddress.PostalCode, Is.EqualTo("10001"));
            Assert.That(remittanceAddress.Road, Is.EqualTo("Remit St"));
            Assert.That(remittanceAddress.State, Is.EqualTo("NY"));
            Assert.That(remittanceAddress.StreetAddress, Is.EqualTo("123 Remit St"));

            Assert.That(document.Fields["RemittanceAddressRecipient"].Value.AsString(), Is.EqualTo("Contoso Billing"));

            AddressValue serviceAddress = document.Fields["ServiceAddress"].Value.AsAddress();
            Assert.That(serviceAddress.City, Is.EqualTo("Redmond"));
            Assert.That(serviceAddress.CountryRegion, Is.Null);
            Assert.That(serviceAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(serviceAddress.PoBox, Is.Null);
            Assert.That(serviceAddress.PostalCode, Is.EqualTo("98052"));
            Assert.That(serviceAddress.Road, Is.EqualTo("Service St"));
            Assert.That(serviceAddress.State, Is.EqualTo("WA"));
            Assert.That(serviceAddress.StreetAddress, Is.EqualTo("123 Service St"));

            Assert.That(document.Fields["ServiceAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Services"));

            var serviceEndDate = document.Fields["ServiceEndDate"].Value.AsDate();
            Assert.That(serviceEndDate.Day, Is.EqualTo(14));
            Assert.That(serviceEndDate.Month, Is.EqualTo(11));
            Assert.That(serviceEndDate.Year, Is.EqualTo(2019));

            var serviceStartDate = document.Fields["ServiceStartDate"].Value.AsDate();
            Assert.That(serviceStartDate.Day, Is.EqualTo(14));
            Assert.That(serviceStartDate.Month, Is.EqualTo(10));
            Assert.That(serviceStartDate.Year, Is.EqualTo(2019));

            AddressValue shippingAddress = document.Fields["ShippingAddress"].Value.AsAddress();
            Assert.That(shippingAddress.City, Is.EqualTo("Redmond"));
            Assert.That(shippingAddress.CountryRegion, Is.Null);
            Assert.That(shippingAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(shippingAddress.PoBox, Is.Null);
            Assert.That(shippingAddress.PostalCode, Is.EqualTo("98052"));
            Assert.That(shippingAddress.Road, Is.EqualTo("Ship St"));
            Assert.That(shippingAddress.State, Is.EqualTo("WA"));
            Assert.That(shippingAddress.StreetAddress, Is.EqualTo("123 Ship St"));

            Assert.That(document.Fields["ShippingAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Delivery"));
            ValidateCurrencyValue(document.Fields["SubTotal"].Value.AsCurrency(), 100.00, "$", "USD");
            ValidateCurrencyValue(document.Fields["TotalTax"].Value.AsCurrency(), 10.00, "$", "USD");

            AddressValue vendorAddress = document.Fields["VendorAddress"].Value.AsAddress();
            Assert.That(vendorAddress.City, Is.EqualTo("New York"));
            Assert.That(vendorAddress.CountryRegion, Is.Null);
            Assert.That(vendorAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(vendorAddress.PoBox, Is.Null);
            Assert.That(vendorAddress.PostalCode, Is.EqualTo("10001"));
            Assert.That(vendorAddress.Road, Is.EqualTo("456th St"));
            Assert.That(vendorAddress.State, Is.EqualTo("NY"));
            Assert.That(vendorAddress.StreetAddress, Is.EqualTo("123 456th St"));

            Assert.That(document.Fields["VendorAddressRecipient"].Value.AsString(), Is.EqualTo("Contoso Headquarters"));
            Assert.That(document.Fields["VendorName"].Value.AsString(), Is.EqualTo("CONTOSO LTD."));

            var expectedItems = new List<(double Amount, DateTimeOffset Date, string Description, string ProductCode, double Quantity, string Unit, double UnitPrice, string UnitPriceCode)>()
            {
                (60f, DateTimeOffset.Parse("2021-04-03 00:00:00+00:00"), "Consulting Services", "A123", 2, "hours", 30, "USD"),
                (30f, DateTimeOffset.Parse("2021-05-03 00:00:00+00:00"), "Document Fee", "B456", 3, null, 10, "USD"),
                (10f, DateTimeOffset.Parse("2021-06-03 00:00:00+00:00"), "Printing Fee", "C789", 10, "pages", 1, "USD")
            };

            // Include a bit of tolerance when comparing double types.

            var items = document.Fields["Items"].Value.AsList();

            Assert.That(items.Count, Is.EqualTo(expectedItems.Count));

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

                Assert.That(dateField, Is.Not.Null);
                DateTimeOffset date = dateField.Value.AsDate();

                var expectedItem = expectedItems[itemIndex];

                ValidateCurrencyValue(amount, expectedItem.Amount, "$", "USD", $"Amount mismatch in item with index {itemIndex}.");
                Assert.That(date, Is.EqualTo(expectedItem.Date), $"Date mismatch in item with index {itemIndex}.");
                Assert.That(description, Is.EqualTo(expectedItem.Description), $"Description mismatch in item with index {itemIndex}.");
                Assert.That(productCode, Is.EqualTo(expectedItem.ProductCode), $"ProductCode mismatch in item with index {itemIndex}.");
                Assert.That(unit, Is.EqualTo(expectedItem.Unit), $"Unit mismatch in item with index {itemIndex}.");
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

            Assert.That(document, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.That(document.DocumentType, Is.EqualTo("invoice"));

            Assert.That(document.Fields, Is.Not.Null);

            Assert.That(document.Fields.ContainsKey("VendorName"), Is.True);
            Assert.That(document.Fields.ContainsKey("RemittanceAddressRecipient"), Is.True);
            Assert.That(document.Fields.ContainsKey("RemittanceAddress"), Is.True);

            DocumentField vendorName = document.Fields["VendorName"];
            Assert.That(vendorName.BoundingRegions.First().PageNumber, Is.EqualTo(2));
            Assert.That(vendorName.Value.AsString(), Is.EqualTo("Southridge Video"));

            DocumentField addressRecipient = document.Fields["RemittanceAddressRecipient"];
            Assert.That(addressRecipient.BoundingRegions.First().PageNumber, Is.EqualTo(1));
            Assert.That(addressRecipient.Value.AsString(), Is.EqualTo("Contoso Ltd."));

            DocumentField addressField = document.Fields["RemittanceAddress"];
            Assert.That(addressField.BoundingRegions.First().PageNumber, Is.EqualTo(1));

            AddressValue address = addressField.Value.AsAddress();
            Assert.That(address.City, Is.EqualTo("Birch"));
            Assert.That(address.CountryRegion, Is.Null);
            Assert.That(address.HouseNumber, Is.EqualTo("2345"));
            Assert.That(address.PoBox, Is.Null);
            Assert.That(address.PostalCode, Is.EqualTo("98123"));
            Assert.That(address.Road, Is.EqualTo("Dogwood Lane"));
            Assert.That(address.State, Is.EqualTo("Kansas"));
            Assert.That(address.StreetAddress, Is.EqualTo("2345 Dogwood Lane"));
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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-layout",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the document. We are not testing the service here, but the SDK.

            Assert.That(page.Unit, Is.EqualTo(DocumentPageLengthUnit.Inch));
            Assert.That(page.Width, Is.EqualTo(8.5));
            Assert.That(page.Height, Is.EqualTo(11));
            Assert.That(page.Angle, Is.EqualTo(0));
            Assert.That(page.Lines.Count, Is.EqualTo(18));

            DocumentParagraph sampleParagraph = result.Paragraphs[0];

            Assert.That(sampleParagraph.Content, Is.EqualTo("Contoso"));
            Assert.That(sampleParagraph.Role, Is.Null);

            DocumentTable table = result.Tables.Single();

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                Assert.That(table.RowCount, Is.EqualTo(2));
            }
            else
            {
                Assert.That(table.RowCount, Is.EqualTo(3));
            }

            Assert.That(table.ColumnCount, Is.EqualTo(5));

            var cells = table.Cells.ToList();

            Assert.That(cells.Count, Is.EqualTo(10));

            var expectedContent = new string[2, 5]
            {
                { "Invoice Number", "Invoice Date", "Invoice Due Date", "Charges", "VAT ID" },
                { "34278587", "6/18/2017", "6/24/2017", "$56,651.49", "PT" }
            };

            foreach (DocumentTableCell cell in cells)
            {
                Assert.That(cell.RowIndex, Is.GreaterThanOrEqualTo(0), $"Cell with content {cell.Content} should have row index greater than or equal to zero.");
                Assert.That(cell.RowIndex, Is.LessThan(table.RowCount), $"Cell with content {cell.Content} should have row index less than {table.RowCount}.");
                Assert.That(cell.ColumnIndex, Is.GreaterThanOrEqualTo(0), $"Cell with content {cell.Content} should have column index greater than or equal to zero.");
                Assert.That(cell.ColumnIndex, Is.LessThan(table.ColumnCount), $"Cell with content {cell.Content} should have column index less than {table.ColumnCount}.");

                if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
                {
                    Assert.That(cell.RowSpan, Is.EqualTo(1), $"Cell with content {cell.Content} should have a row span of 1.");
                }
                else
                {
                    // Row = 1 has a row span of 2.
                    var expectedRowSpan = cell.RowIndex == 1 ? 2 : 1;

                    Assert.That(cell.RowSpan, Is.EqualTo(expectedRowSpan), $"Cell with content {cell.Content} should have a row span of {expectedRowSpan}.");
                }

                Assert.That(cell.RowIndex, Is.LessThanOrEqualTo(2), $"Cell with content {cell.Content} should have a row index less than or equal to two.");
                Assert.That(cell.Content, Is.EqualTo(expectedContent[cell.RowIndex, cell.ColumnIndex]));
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

            Assert.That(result.Pages.Count, Is.EqualTo(2));

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                DocumentPage page = result.Pages[pageIndex];

                ValidatePage(
                    page,
                    expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = page.Lines[1];
                var expectedContent = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.That(sampleLine.Content, Is.EqualTo(expectedContent));
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

            Assert.That(result.Pages.Count, Is.EqualTo(3));

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

                    Assert.That(page.Lines.Any(l => l.Content.Contains(expectedContent)), Is.True);
                }
            }

            var blankPage = result.Pages[1];

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Words.Count, Is.EqualTo(0));
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

            Assert.That(operation.HasValue, Is.True);

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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-read",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the document. We are not testing the service here, but the SDK.

            Assert.That(page.Unit, Is.EqualTo(DocumentPageLengthUnit.Inch));
            Assert.That(page.Width, Is.EqualTo(8.5));
            Assert.That(page.Height, Is.EqualTo(11));
            Assert.That(page.Angle, Is.EqualTo(0));
            Assert.That(page.Lines.Count, Is.EqualTo(18));
            Assert.That(result.Tables, Is.Empty);

            Assert.That(result.Languages, Is.Not.Empty);
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

            Assert.That(operation.HasValue, Is.True);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-receipt",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.That(document, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the receipt. We are not testing the service here, but the SDK.

            Assert.That(document.DocumentType, Is.EqualTo("receipt.retailMeal"));

            Assert.That(document.Fields, Is.Not.Null);

            Assert.That(document.Fields.ContainsKey("MerchantAddress"), Is.True);
            Assert.That(document.Fields.ContainsKey("MerchantName"), Is.True);
            Assert.That(document.Fields.ContainsKey("MerchantPhoneNumber"), Is.True);
            Assert.That(document.Fields.ContainsKey("TransactionDate"), Is.True);
            Assert.That(document.Fields.ContainsKey("TransactionTime"), Is.True);
            Assert.That(document.Fields.ContainsKey("Items"), Is.True);
            Assert.That(document.Fields.ContainsKey("Subtotal"), Is.True);
            Assert.That(document.Fields.ContainsKey("TotalTax"), Is.True);
            Assert.That(document.Fields.ContainsKey("Total"), Is.True);

            Assert.That(document.Fields["MerchantName"].Value.AsString(), Is.EqualTo("Contoso"));

            AddressValue merchantAddress = document.Fields["MerchantAddress"].Value.AsAddress();
            Assert.That(merchantAddress.City, Is.EqualTo("Redmond"));
            Assert.That(merchantAddress.CountryRegion, Is.Null);
            Assert.That(merchantAddress.HouseNumber, Is.EqualTo("123"));
            Assert.That(merchantAddress.PoBox, Is.Null);
            Assert.That(merchantAddress.PostalCode, Is.EqualTo("98052"));
            Assert.That(merchantAddress.Road, Is.EqualTo("Main Street"));
            Assert.That(merchantAddress.State, Is.EqualTo("WA"));
            Assert.That(merchantAddress.StreetAddress, Is.EqualTo("123 Main Street"));

            Assert.That(document.Fields["MerchantPhoneNumber"].Content, Is.EqualTo("123-456-7890"));

            var date = document.Fields["TransactionDate"].Value.AsDate();
            var time = document.Fields["TransactionTime"].Value.AsTime();

            Assert.That(date.Day, Is.EqualTo(10));
            Assert.That(date.Month, Is.EqualTo(6));
            Assert.That(date.Year, Is.EqualTo(2019));

            Assert.That(time.Hours, Is.EqualTo(13));
            Assert.That(time.Minutes, Is.EqualTo(59));
            Assert.That(time.Seconds, Is.EqualTo(0));

            var expectedItems = new List<(int? Quantity, string Description, double? Price, double? TotalPrice)>()
            {
                (1, "Surface Pro 6", null, 999.00),
                (1, "SurfacePen", null, 99.99)
            };

            // Include a bit of tolerance when comparing double types.

            var items = document.Fields["Items"].Value.AsList();

            Assert.That(items.Count, Is.EqualTo(expectedItems.Count));

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

                Assert.That(quantity, Is.EqualTo(expectedItem.Quantity), $"Quantity mismatch in item with index {itemIndex}.");
                Assert.That(description, Is.EqualTo(expectedItem.Description), $"Description mismatch in item with index {itemIndex}.");
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

            Assert.That(result.Documents.Count, Is.EqualTo(2));

            for (int documentIndex = 0; documentIndex < result.Documents.Count; documentIndex++)
            {
                var analyzedDocument = result.Documents[documentIndex];
                var expectedPageNumber = documentIndex + 1;

                Assert.That(analyzedDocument, Is.Not.Null);

                ValidateAnalyzedDocument(
                    analyzedDocument,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                var sampleField = analyzedDocument.Fields["Total"];
                Assert.That(sampleField.Content, Is.Not.Null);

                if (documentIndex == 0)
                {
                    Assert.That(sampleField.Content, Is.EqualTo("$14.50"));
                }
                else if (documentIndex == 1)
                {
                    Assert.That(sampleField.Content, Is.EqualTo("$ 1203.39"));
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

            Assert.That(result.Pages.Count, Is.EqualTo(3));

            for (int pageIndex = 0; pageIndex < result.Pages.Count; pageIndex++)
            {
                var page = result.Pages[pageIndex];
                var expectedPageNumber = pageIndex + 1;

                Assert.That(page, Is.Not.Null);

                // Basic sanity test to make sure pages are ordered correctly.

                if (pageIndex == 0 || pageIndex == 2)
                {
                    var expectedContent = pageIndex == 0 ? "$14.50" : "1203.39";

                    Assert.That(page.Words.Any(w => w.Content == expectedContent), Is.True);
                }
            }

            var blankPage = result.Pages[1];

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Words.Count, Is.EqualTo(0));
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

            Assert.That(operation.HasValue, Is.True);

            AnalyzeResult result = operation.Value;

            DocumentLine line = result.Pages[0].Lines[45];
            IReadOnlyList<DocumentWord> words = line.GetWords();

            Assert.That(line.Content, Is.EqualTo("Do not Jostle Box. Unpack carefully. Enjoy."));
            Assert.That(words.Count, Is.EqualTo(7));
            Assert.That(words[0].Content, Is.EqualTo("Do"));
            Assert.That(words[1].Content, Is.EqualTo("not"));
            Assert.That(words[2].Content, Is.EqualTo("Jostle"));
            Assert.That(words[3].Content, Is.EqualTo("Box."));
            Assert.That(words[4].Content, Is.EqualTo("Unpack"));
            Assert.That(words[5].Content, Is.EqualTo("carefully."));
            Assert.That(words[6].Content, Is.EqualTo("Enjoy."));

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                line = result.Pages[0].Lines[52];
            }
            else
            {
                line = result.Pages[0].Lines[46];
            }

            words = line.GetWords();

            Assert.That(line.Content, Is.EqualTo("Jupiter Book Supply will refund you 50% per book if returned within 60 days of reading and"));
            Assert.That(words.Count, Is.EqualTo(17));
            Assert.That(words[0].Content, Is.EqualTo("Jupiter"));
            Assert.That(words[1].Content, Is.EqualTo("Book"));
            Assert.That(words[2].Content, Is.EqualTo("Supply"));
            Assert.That(words[3].Content, Is.EqualTo("will"));
            Assert.That(words[4].Content, Is.EqualTo("refund"));
            Assert.That(words[5].Content, Is.EqualTo("you"));
            Assert.That(words[6].Content, Is.EqualTo("50%"));
            Assert.That(words[7].Content, Is.EqualTo("per"));
            Assert.That(words[8].Content, Is.EqualTo("book"));
            Assert.That(words[9].Content, Is.EqualTo("if"));
            Assert.That(words[10].Content, Is.EqualTo("returned"));
            Assert.That(words[11].Content, Is.EqualTo("within"));
            Assert.That(words[12].Content, Is.EqualTo("60"));
            Assert.That(words[13].Content, Is.EqualTo("days"));
            Assert.That(words[14].Content, Is.EqualTo("of"));
            Assert.That(words[15].Content, Is.EqualTo("reading"));
            Assert.That(words[16].Content, Is.EqualTo("and"));
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
            Assert.That(document, Is.Not.Null);
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

            Assert.That(result.KeyValuePairs, Is.Empty);
            Assert.That(result.Styles, Is.Empty);
            Assert.That(result.Tables, Is.Empty);

            if (result.Documents.Count > 0)
            {
                AnalyzedDocument blankDocument = result.Documents.Single();

                Assert.That(blankDocument.Fields, Is.Empty);
            }

            DocumentPage blankPage = result.Pages.Single();

            Assert.That(blankPage.Lines, Is.Empty);
            Assert.That(blankPage.Words, Is.Empty);
            Assert.That(blankPage.SelectionMarks, Is.Empty);
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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidRequest"));
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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidRequest"));
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

            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidArgument"));
        }

        #endregion

        private void ValidateAnalyzeResult(AnalyzeResult result, string modelId, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.That(result.ModelId, Is.EqualTo(modelId));

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

                Assert.That(kvp.Key, Is.Not.Null);

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

            Assert.That(currentPageNumber - 1, Is.EqualTo(expectedLastPageNumber));

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
                Assert.That(language.Locale, Is.Not.Null);
            }
        }

        private void ValidateAnalyzedDocument(AnalyzedDocument document, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.That(document.DocumentType, Is.Not.Null);
            Assert.That(document.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.005));

            foreach (BoundingRegion region in document.BoundingRegions)
            {
                ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
            }

            Assert.That(document.Fields, Is.Not.Null);

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
            Assert.That(region, Is.Not.Null);
            Assert.That(region.BoundingPolygon, Is.Not.Null);

            if (region.BoundingPolygon.Count != 0)
            {
                Assert.That(region.BoundingPolygon.Count, Is.EqualTo(4));
            }

            Assert.That(region.PageNumber, Is.GreaterThanOrEqualTo(expectedFirstPageNumber).Or.LessThanOrEqualTo(expectedLastPageNumber));
        }

        private void ValidatePage(DocumentPage page, int expectedPageNumber)
        {
            Assert.That(page.PageNumber, Is.EqualTo(expectedPageNumber));

            Assert.That(page.Width, Is.GreaterThan(0.0));
            Assert.That(page.Height, Is.GreaterThan(0.0));

            Assert.That(page.Angle, Is.GreaterThan(-180.0).Within(0.01));
            Assert.That(page.Angle, Is.LessThanOrEqualTo(180.0).Within(0.01));

            Assert.That(page.Lines, Is.Not.Null);

            foreach (DocumentLine line in page.Lines)
            {
                Assert.That(line.BoundingPolygon, Is.Not.Null);
                Assert.That(line.BoundingPolygon.Count, Is.EqualTo(4));
            }

            ValidateSpanListsAreSortedAndDontOverlap(page.Lines.Select(l => l.Spans).ToList());

            Assert.That(page.Words, Is.Not.Null);

            foreach (DocumentWord word in page.Words)
            {
                Assert.That(word.BoundingPolygon, Is.Not.Null);
                Assert.That(word.BoundingPolygon.Count, Is.EqualTo(4));

                Assert.That(word.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(word.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }

            ValidateSpansAreSortedAndDontOverlap(page.Words.Select(w => w.Span).ToList());

            Assert.That(page.SelectionMarks, Is.Not.Null);

            foreach (DocumentSelectionMark selectionMark in page.SelectionMarks)
            {
                Assert.That(selectionMark.BoundingPolygon, Is.Not.Null);
                Assert.That(selectionMark.BoundingPolygon.Count, Is.EqualTo(4));

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

            Assert.That(table.ColumnCount, Is.GreaterThan(0));
            Assert.That(table.RowCount, Is.GreaterThan(0));

            foreach (DocumentTableCell cell in table.Cells)
            {
                foreach (BoundingRegion region in cell.BoundingRegions)
                {
                    ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                }

                Assert.That(cell.ColumnIndex, Is.GreaterThanOrEqualTo(0));
                Assert.That(cell.RowIndex, Is.GreaterThanOrEqualTo(0));
                Assert.That(cell.ColumnSpan, Is.GreaterThanOrEqualTo(1));
                Assert.That(cell.RowSpan, Is.GreaterThanOrEqualTo(1));
                Assert.That(cell.Content, Is.Not.Null);
            }
        }

        private void ValidateSpansAreSortedAndDontOverlap(IReadOnlyList<DocumentSpan> spans)
        {
            for (int i = 0; i < spans.Count - 1; i++)
            {
                Assert.That(spans[i + 1].Index, Is.GreaterThanOrEqualTo(spans[i].Index + spans[i].Length));
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

                Assert.That(firstNextSpan.Index, Is.GreaterThanOrEqualTo(lastCurrentSpan.Index + lastCurrentSpan.Length));
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
            Assert.That(value.Symbol, Is.EqualTo(expectedSymbol), message);

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)
            {
                Assert.That(value.Code, Is.EqualTo(expectedCode), message);
            }
            else
            {
                Assert.That(value.Code, Is.Null, message);
            }
        }
    }
}
