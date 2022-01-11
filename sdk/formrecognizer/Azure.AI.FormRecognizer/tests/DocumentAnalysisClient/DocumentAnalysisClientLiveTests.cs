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
    [ClientTestFixture(
     DocumentAnalysisClientOptions.ServiceVersion.V2021_09_30_preview)]
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
        public async Task StartAnalyzeDocumentPopulatesExtractedBusinessCardJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-businessCard", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.BusinessCardJpg);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-businessCard", uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            ValidateAnalyzeResult(
                operation.Value,
                "prebuilt-businessCard",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            AnalyzedDocument document = operation.Value.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:businesscard", document.DocType);

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

            var contactNames = document.Fields["ContactNames"].AsList();
            Assert.AreEqual(1, contactNames.Count);
            Assert.AreEqual("Dr. Avery Smith", contactNames.FirstOrDefault().Content);

            var contactNamesDict = contactNames.FirstOrDefault().AsDictionary();

            Assert.True(contactNamesDict.ContainsKey("FirstName"));
            Assert.AreEqual("Avery", contactNamesDict["FirstName"].AsString());

            Assert.True(contactNamesDict.ContainsKey("LastName"));
            Assert.AreEqual("Smith", contactNamesDict["LastName"].AsString());

            var jobTitles = document.Fields["JobTitles"].AsList();
            Assert.AreEqual(1, jobTitles.Count);
            Assert.AreEqual("Senior Researcher", jobTitles.FirstOrDefault().AsString());

            var departments = document.Fields["Departments"].AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.AreEqual("Cloud & Al Department", departments.FirstOrDefault().AsString());

            var emails = document.Fields["Emails"].AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.AreEqual("avery.smith@contoso.com", emails.FirstOrDefault().AsString());

            var websites = document.Fields["Websites"].AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.AreEqual("https://www.contoso.com/", websites.FirstOrDefault().AsString());

            var mobilePhones = document.Fields["MobilePhones"].AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.AreEqual(DocumentFieldType.PhoneNumber, mobilePhones.FirstOrDefault().ValueType);

            var otherPhones = document.Fields["WorkPhones"].AsList();
            Assert.AreEqual(1, otherPhones.Count);
            Assert.AreEqual(DocumentFieldType.PhoneNumber, otherPhones.FirstOrDefault().ValueType);

            var faxes = document.Fields["Faxes"].AsList();
            Assert.AreEqual(1, faxes.Count);
            Assert.AreEqual(DocumentFieldType.PhoneNumber, faxes.FirstOrDefault().ValueType);

            var addresses = document.Fields["Addresses"].AsList();
            Assert.AreEqual(1, addresses.Count);
            Assert.AreEqual("2 Kingdom Street Paddington, London, W2 6BD", addresses.FirstOrDefault().AsString());

            var companyNames = document.Fields["CompanyNames"].AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.AreEqual("Contoso", companyNames.FirstOrDefault().AsString());
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentCanParseMultipageBusinessCard(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.BusinessMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-businessCard", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.BusinessMultipage);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-businessCard", uri);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

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

                Assert.AreEqual(DocumentFieldType.List, sampleField.ValueType);

                var field = sampleField.AsList().Single();

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
        public async Task StartAnalyzeDocumentWithCustomModel(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId);

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartAnalyzeDocumentFromUriAsync(customModel.ModelId, uri);
            }

            await operation.WaitForCompletionAsync();

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

            Assert.IsNotEmpty(document.DocType);
            Assert.AreEqual(2200, page.Height);
            Assert.AreEqual(1, page.PageNumber);
            Assert.AreEqual(LengthUnit.Pixel, page.Unit);
            Assert.AreEqual(1700, page.Width);

            Assert.IsNotNull(document.Fields);
            var name = "PurchaseOrderNumber";
            Assert.IsNotNull(document.Fields[name]);
            Assert.AreEqual(DocumentFieldType.String, document.Fields[name].ValueType);
            Assert.AreEqual("948284", document.Fields[name].Content);
        }

        [RecordedTest]
        public async Task StartAnalyzeDocumentWithCustomModelWithLabelsAndSelectionMarks()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId, ContainerType.SelectionMarks);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
            }

            await operation.WaitForCompletionAsync();

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
            Assert.IsNotEmpty(document.DocType);
            Assert.IsNotNull(document.Fields);
            var name = "AMEX_SELECTION_MARK";
            Assert.IsNotNull(document.Fields[name]);
            Assert.AreEqual(DocumentFieldType.SelectionMark, document.Fields[name].ValueType);
            Assert.AreEqual(SelectionMarkState.Selected, document.Fields[name].AsSelectionMarkState());
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentWithCustomModelCanParseMultipageForm(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId, ContainerType.MultipageFiles);

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartAnalyzeDocumentFromUriAsync(customModel.ModelId, uri);
            }

            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;
            AnalyzedDocument document = result.Documents.Single();

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2);

            // Check some values to make sure that fields from both pages are being populated.

            Assert.AreEqual("Jamie@southridgevideo.com", document.Fields["Contact"].AsString());
            Assert.AreEqual("Southridge Video", document.Fields["CompanyName"].AsString());
            Assert.AreEqual("$1,500", document.Fields["Gold"].AsString());
            Assert.AreEqual("$1,000", document.Fields["Bronze"].AsString());

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
        [Ignore("Service error. Issue https://github.com/Azure/azure-sdk-for-net/issues/24995")]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentWithCustomModelCanParseMultipageFormWithBlankPage(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId);

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipageBlank);
                operation = await client.StartAnalyzeDocumentFromUriAsync(customModel.ModelId, uri);
            }

            await operation.WaitForCompletionAsync();

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
        [Ignore("Service error. Issue https://github.com/Azure/azure-sdk-for-net/issues/24995")]
        public async Task StartAnalyzeDocumentWithCustomModelCanParseDifferentTypeOfForm()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            // Use Form_<id>.<ext> files for building model.

            await using var customModel = await CreateDisposableBuildModelAsync(modelId);

            // Attempt to recognize a different type of document: Invoice_1.pdf. This document does not contain all the labels
            // the newly built model expects.

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoicePdf);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
            }

            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;
            var fields = result.Documents.Single().Fields;

            // Verify that we got back at least one missing field to make sure we hit the code path we want to test.
            // The missing field is returned with its value set to null.

            Assert.IsTrue(fields.Values.Any(field =>
                field.ValueType == DocumentFieldType.String && field.AsString() == null));
        }

        [RecordedTest]
        public async Task StartAnalyzeDocumentWithCustomModelWithTableDynamicRows()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId, ContainerType.TableVariableRows);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.FormTableDynamicRows);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
            }

            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [RecordedTest]
        public async Task StartAnalyzeDocumentWithCustomModelWithTableFixedRows()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId, ContainerType.TableFixedRows);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.FormTableFixedRows);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync(customModel.ModelId, stream);
            }

            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                customModel.ModelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [RecordedTest]
        [Ignore("Service error. Issue https://github.com/Azure/azure-sdk-for-net/issues/24995")]
        public async Task StartAnalyzeDocumentWithCustomModelCanParseBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();
            AnalyzeDocumentOperation operation;

            await using var customModel = await CreateDisposableBuildModelAsync(modelId);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync(modelId, stream);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

            ValidateAnalyzeResult(
                result,
                modelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.IsEmpty(result.Entities);
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
        public async Task StartAnalyzeDocumentWithCustomModelThrowsForDamagedFile()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();

            await using var customModel = await CreateDisposableBuildModelAsync(modelId);

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeDocumentAsync(modelId, stream));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        public async Task StartAnalyzeDocumentFromUriWithCustomModelThrowsForNonExistingContent()
        {
            var client = CreateDocumentAnalysisClient();
            var modelId = Recording.GenerateId();

            await using var customModel = await CreateDisposableBuildModelAsync(modelId);

            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeDocumentFromUriAsync(modelId, invalidUri));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion

        #region Document

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentPopulatesDocumentPageJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-document", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-document", uri);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;
            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the form. We are not testing the service here, but the SDK.

            Assert.AreEqual(LengthUnit.Pixel, page.Unit);
            Assert.AreEqual(1700, page.Width);
            Assert.AreEqual(2200, page.Height);
            Assert.AreEqual(0, page.Angle);
            Assert.AreEqual(54, page.Lines.Count);

            var lines = page.Lines.ToList();

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

            Assert.AreEqual(2, result.Tables.Count);

            DocumentTable sampleTable = result.Tables[1];

            Assert.AreEqual(4, sampleTable.RowCount);
            Assert.AreEqual(2, sampleTable.ColumnCount);

            var cells = sampleTable.Cells.ToList();

            Assert.AreEqual(8, cells.Count);

            var expectedContent = new string[4, 2]
            {
                { "SUBTOTAL", "$140.00" },
                { "TAX", "$4.00" },
                { "", ""},
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
        public async Task StartAnalyzeDocumentPopulatesExtractedIdDocumentJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-idDocument", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.DriverLicenseJpg);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-idDocument", uri);
            }

            await operation.WaitForCompletionAsync();

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

            Assert.AreEqual("prebuilt:idDocument:driverLicense", document.DocType);

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

            Assert.AreEqual("123 STREET ADDRESS YOUR CITY WA 99999-1234", document.Fields["Address"].AsString());
            Assert.AreEqual("WDLABCD456DG", document.Fields["DocumentNumber"].AsString());
            Assert.AreEqual("LIAM R.", document.Fields["FirstName"].AsString());
            Assert.AreEqual("TALBOT", document.Fields["LastName"].AsString());
            Assert.AreEqual("Washington", document.Fields["Region"].AsString());
            Assert.AreEqual("M", document.Fields["Sex"].AsString());

            Assert.That(document.Fields["CountryRegion"].AsCountryRegion(), Is.EqualTo("USA"));

            var dateOfBirth = document.Fields["DateOfBirth"].AsDate();
            Assert.AreEqual(6, dateOfBirth.Day);
            Assert.AreEqual(1, dateOfBirth.Month);
            Assert.AreEqual(1958, dateOfBirth.Year);

            var dateOfExpiration = document.Fields["DateOfExpiration"].AsDate();
            Assert.AreEqual(12, dateOfExpiration.Day);
            Assert.AreEqual(8, dateOfExpiration.Month);
            Assert.AreEqual(2020, dateOfExpiration.Year);
        }

        #endregion

        #region Invoices

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentPopulatesExtractedInvoiceJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-invoice", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceJpg);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-invoice", uri);
            }

            await operation.WaitForCompletionAsync();

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

            Assert.AreEqual("prebuilt:invoice", document.DocType);

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

            Assert.That(document.Fields["AmountDue"].AsDouble(), Is.EqualTo(610.00).Within(0.0001));
            Assert.AreEqual("123 Bill St, Redmond WA, 98052", document.Fields["BillingAddress"].AsString());
            Assert.AreEqual("Microsoft Finance", document.Fields["BillingAddressRecipient"].AsString());
            Assert.AreEqual("123 Other St, Redmond WA, 98052", document.Fields["CustomerAddress"].AsString());
            Assert.AreEqual("Microsoft Corp", document.Fields["CustomerAddressRecipient"].AsString());
            Assert.AreEqual("CID-12345", document.Fields["CustomerId"].AsString());
            Assert.AreEqual("MICROSOFT CORPORATION", document.Fields["CustomerName"].AsString());

            var dueDate = document.Fields["DueDate"].AsDate();
            Assert.AreEqual(15, dueDate.Day);
            Assert.AreEqual(12, dueDate.Month);
            Assert.AreEqual(2019, dueDate.Year);

            var invoiceDate = document.Fields["InvoiceDate"].AsDate();
            Assert.AreEqual(15, invoiceDate.Day);
            Assert.AreEqual(11, invoiceDate.Month);
            Assert.AreEqual(2019, invoiceDate.Year);

            Assert.AreEqual("INV-100", document.Fields["InvoiceId"].AsString());
            Assert.That(document.Fields["InvoiceTotal"].AsDouble(), Is.EqualTo(110.00).Within(0.0001));
            Assert.That(document.Fields["PreviousUnpaidBalance"].AsDouble(), Is.EqualTo(500.00).Within(0.0001));
            Assert.AreEqual("PO-3333", document.Fields["PurchaseOrder"].AsString());
            Assert.AreEqual("123 Remit St New York, NY, 10001", document.Fields["RemittanceAddress"].AsString());
            Assert.AreEqual("Contoso Billing", document.Fields["RemittanceAddressRecipient"].AsString());
            Assert.AreEqual("123 Service St, Redmond WA, 98052", document.Fields["ServiceAddress"].AsString());
            Assert.AreEqual("Microsoft Services", document.Fields["ServiceAddressRecipient"].AsString());

            var serviceEndDate = document.Fields["ServiceEndDate"].AsDate();
            Assert.AreEqual(14, serviceEndDate.Day);
            Assert.AreEqual(11, serviceEndDate.Month);
            Assert.AreEqual(2019, serviceEndDate.Year);

            var serviceStartDate = document.Fields["ServiceStartDate"].AsDate();
            Assert.AreEqual(14, serviceStartDate.Day);
            Assert.AreEqual(10, serviceStartDate.Month);
            Assert.AreEqual(2019, serviceStartDate.Year);

            Assert.AreEqual("123 Ship St, Redmond WA, 98052", document.Fields["ShippingAddress"].AsString());
            Assert.AreEqual("Microsoft Delivery", document.Fields["ShippingAddressRecipient"].AsString());
            Assert.That(document.Fields["SubTotal"].AsDouble(), Is.EqualTo(100.00).Within(0.0001));
            Assert.That(document.Fields["TotalTax"].AsDouble(), Is.EqualTo(10.00).Within(0.0001));
            Assert.AreEqual("123 456th St New York, NY, 10001", document.Fields["VendorAddress"].AsString());
            Assert.AreEqual("Contoso Headquarters", document.Fields["VendorAddressRecipient"].AsString());
            Assert.AreEqual("CONTOSO LTD.", document.Fields["VendorName"].AsString());

            var expectedItems = new List<(double? Amount, DateTime Date, string Description, string ProductCode, double? Quantity, string Unit, double? UnitPrice)>()
            {
                (60f, DateTime.Parse("2021-03-04 00:00:00"), "Consulting Services", "A123", 2, "hours", 30),
                (30f, DateTime.Parse("2021-03-05 00:00:00"), "Document Fee", "B456", 3, null, 10),
                (10f, DateTime.Parse("2021-03-06 00:00:00"), "Printing Fee", "C789", 10, "pages", 1)
            };

            // Include a bit of tolerance when comparing double types.

            var items = document.Fields["Items"].AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].AsDictionary();

                receiptItemInfo.TryGetValue("Amount", out var amountField);
                receiptItemInfo.TryGetValue("Date", out var dateField);
                receiptItemInfo.TryGetValue("Description", out var descriptionField);
                receiptItemInfo.TryGetValue("ProductCode", out var productCodeField);
                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("UnitPrice", out var unitPricefield);
                receiptItemInfo.TryGetValue("Unit", out var unitfield);

                double? amount = amountField.AsDouble();
                string description = descriptionField.AsString();
                string productCode = productCodeField.AsString();
                double? quantity = quantityField?.AsDouble();
                double? unitPrice = unitPricefield.AsDouble();
                string unit = unitfield?.AsString();

                Assert.IsNotNull(dateField);
                DateTime date = dateField.AsDate();

                var expectedItem = expectedItems[itemIndex];

                Assert.That(amount, Is.EqualTo(expectedItem.Amount).Within(0.0001), $"Amount mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Date, date, $"Date mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Description, description, $"Description mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.ProductCode, productCode, $"ProductCode mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Unit, unit, $"Unit mismatch in item with index {itemIndex}.");
                Assert.That(quantity, Is.EqualTo(expectedItem.Quantity).Within(0.0001), $"Quantity mismatch in item with index {itemIndex}.");
                Assert.That(unitPrice, Is.EqualTo(expectedItem.UnitPrice).Within(0.0001), $"UnitPrice price mismatch in item with index {itemIndex}.");
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentCanParseMultipageInvoice(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-invoice", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-invoice", uri);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

            ValidateAnalyzeResult(
                result,
                "prebuilt-invoice",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2);

            var document = result.Documents.Single();

            Assert.NotNull(document);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:invoice", document.DocType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("VendorName"));
            Assert.True(document.Fields.ContainsKey("RemittanceAddressRecipient"));
            Assert.True(document.Fields.ContainsKey("RemittanceAddress"));

            DocumentField vendorName = document.Fields["VendorName"];
            Assert.AreEqual(2, vendorName.BoundingRegions.First().PageNumber);
            Assert.AreEqual("Southridge Video", vendorName.AsString());

            DocumentField addressRecepient = document.Fields["RemittanceAddressRecipient"];
            Assert.AreEqual(1, addressRecepient.BoundingRegions.First().PageNumber);
            Assert.AreEqual("Contoso Ltd.", addressRecepient.AsString());

            DocumentField address = document.Fields["RemittanceAddress"];
            Assert.AreEqual(1, address.BoundingRegions.First().PageNumber);
            Assert.AreEqual("2345 Dogwood Lane Birch, Kansas 98123", address.AsString());
        }

        #endregion

        #region Layout

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentPopulatesLayoutPagePdf(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoicePdf);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-layout", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoicePdf);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-layout", uri);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            ValidateAnalyzeResult(
                result,
                "prebuilt-layout",
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            DocumentPage page = result.Pages.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the form. We are not testing the service here, but the SDK.

            Assert.AreEqual(LengthUnit.Inch, page.Unit);
            Assert.AreEqual(8.5, page.Width);
            Assert.AreEqual(11, page.Height);
            Assert.AreEqual(0, page.Angle);
            Assert.AreEqual(18, page.Lines.Count);

            DocumentTable table = result.Tables.Single();

            Assert.AreEqual(3, table.RowCount);
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

                // Row = 1 has a row span of 2.
                var expectedRowSpan = cell.RowIndex == 1 ? 2 : 1;

                Assert.AreEqual(expectedRowSpan, cell.RowSpan, $"Cell with content {cell.Content} should have a row span of {expectedRowSpan}.");
                Assert.LessOrEqual(cell.RowIndex, 2, $"Cell with content {cell.Content} should have a row index less than or equal to two.");
                Assert.AreEqual(expectedContent[cell.RowIndex, cell.ColumnIndex], cell.Content);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentCanParseMultipageLayout(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-layout", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-layout", uri);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

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
        public async Task StartAnalyzeDocumentCanParseMultipageLayoutWithBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync("prebuilt-layout", stream);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

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
        public async Task StartAnalyzeDocumentLayoutWithSelectionMarks()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync("prebuilt-layout", stream);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            AnalyzeResult result = operation.Value;

            ValidatePage(
                result.Pages.Single(),
                expectedPageNumber: 1);
        }

        #endregion

        #region Receipts

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentPopulatesExtractedReceiptJpg(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-receipt", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.ReceiptJpg);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-receipt", uri);
            }

            await operation.WaitForCompletionAsync();

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

            Assert.AreEqual("prebuilt:receipt", document.DocType);

            Assert.NotNull(document.Fields);

            Assert.True(document.Fields.ContainsKey("ReceiptType"));
            Assert.True(document.Fields.ContainsKey("MerchantAddress"));
            Assert.True(document.Fields.ContainsKey("MerchantName"));
            Assert.True(document.Fields.ContainsKey("MerchantPhoneNumber"));
            Assert.True(document.Fields.ContainsKey("TransactionDate"));
            Assert.True(document.Fields.ContainsKey("TransactionTime"));
            Assert.True(document.Fields.ContainsKey("Items"));
            Assert.True(document.Fields.ContainsKey("Subtotal"));
            Assert.True(document.Fields.ContainsKey("Tax"));
            Assert.True(document.Fields.ContainsKey("Total"));

            Assert.AreEqual("Itemized", document.Fields["ReceiptType"].AsString());
            Assert.AreEqual("Contoso", document.Fields["MerchantName"].AsString());
            Assert.AreEqual("123 Main Street Redmond, WA 98052", document.Fields["MerchantAddress"].AsString());
            Assert.AreEqual("123-456-7890", document.Fields["MerchantPhoneNumber"].Content);

            var date = document.Fields["TransactionDate"].AsDate();
            var time = document.Fields["TransactionTime"].AsTime();

            Assert.AreEqual(10, date.Day);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(2019, date.Year);

            Assert.AreEqual(13, time.Hours);
            Assert.AreEqual(59, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            var expectedItems = new List<(int? Quantity, string Name, double? Price, double? TotalPrice)>()
            {
                (1, "Surface Pro 6", null, 999.00),
                (1, "SurfacePen", null, 99.99)
            };

            // Include a bit of tolerance when comparing double types.

            var items = document.Fields["Items"].AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].AsDictionary();

                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("Name", out var nameField);
                receiptItemInfo.TryGetValue("Price", out var priceField);
                receiptItemInfo.TryGetValue("TotalPrice", out var totalPriceField);

                var quantity = quantityField == null ? null : (double?)quantityField.AsDouble();
                var name = nameField == null ? null : nameField.AsString();
                var price = priceField == null ? null : (double?)priceField.AsDouble();
                var totalPrice = totalPriceField == null ? null : (double?)totalPriceField.AsDouble();

                var expectedItem = expectedItems[itemIndex];

                Assert.AreEqual(expectedItem.Quantity, quantity, $"Quantity mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Name, name, $"Name mismatch in item with index {itemIndex}.");
                Assert.That(price, Is.EqualTo(expectedItem.Price).Within(0.0001), $"Price mismatch in item with index {itemIndex}.");
                Assert.That(totalPrice, Is.EqualTo(expectedItem.TotalPrice).Within(0.0001), $"Total price mismatch in item with index {itemIndex}.");
            }

            Assert.That(document.Fields["Subtotal"].AsDouble(), Is.EqualTo(1098.99).Within(0.0001));
            Assert.That(document.Fields["Tax"].AsDouble(), Is.EqualTo(104.40).Within(0.0001));
            Assert.That(document.Fields["Total"].AsDouble(), Is.EqualTo(1203.39).Within(0.0001));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartAnalyzeDocumentCanParseMultipageReceipt(bool useStream)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            if (useStream)
            {
                using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceipMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartAnalyzeDocumentAsync("prebuilt-receipt", stream);
                }
            }
            else
            {
                var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.ReceipMultipage);
                operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-receipt", uri);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

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
                    Assert.AreEqual("$14,50", sampleField.Content);
                }
                else if (documentIndex == 1)
                {
                    Assert.AreEqual("$ 1203.39", sampleField.Content);
                }
            }
        }

        [RecordedTest]
        public async Task StartAnalyzeDocumentCanParseMultipageReceiptWithBlankPage()
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceipMultipageWithBlankPage);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync("prebuilt-receipt", stream);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

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
                    var expectedContent = pageIndex == 0 ? "$14,50" : "1203.39";

                    Assert.True(page.Words.Any(w => w.Content == expectedContent));
                }
            }

            var blankPage = result.Pages[1];

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Words.Count);
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
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeDocumentAsync("prebuilt-layout", stream));
            }
        }

        [RecordedTest]
        public async Task StartAnalyzeDocumentCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentAnalysisClient(useTokenCredential: true);
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync("prebuilt-receipt", stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            AnalyzeResult result = await operation.WaitForCompletionAsync();

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
        public async Task StartAnalyzeDocumentWithPrebuiltCanParseBlankPage(string modelId)
        {
            var client = CreateDocumentAnalysisClient();
            AnalyzeDocumentOperation operation;

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartAnalyzeDocumentAsync(modelId, stream);
            }

            AnalyzeResult result = await operation.WaitForCompletionAsync();

            ValidateAnalyzeResult(
                result,
                modelId,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.IsEmpty(result.Entities);
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
        public void StartAnalyzeDocumentWithPrebuiltThrowsForDamagedFile(string modelId)
        {
            var client = CreateDocumentAnalysisClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeDocumentAsync(modelId, stream));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase("prebuilt-businessCard")]
        [TestCase("prebuilt-document")]
        [TestCase("prebuilt-idDocument")]
        [TestCase("prebuilt-invoice")]
        [TestCase("prebuilt-layout")]
        [TestCase("prebuilt-receipt")]
        public void StartAnalyzeDocumentFromUriWithPrebuiltThrowsForNonExistingContent(string modelId)
        {
            var client = CreateDocumentAnalysisClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeDocumentFromUriAsync(modelId, invalidUri));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase("prebuilt-businessCard")]
        [TestCase("prebuilt-document")]
        [TestCase("prebuilt-idDocument")]
        [TestCase("prebuilt-invoice")]
        [TestCase("prebuilt-layout")]
        [TestCase("prebuilt-receipt")]
        public void StartAnalyzeDocumentWithPrebuiltThrowsWithWrongLocale(string modelId)
        {
            var client = CreateDocumentAnalysisClient();
            var options = new AnalyzeDocumentOptions() { Locale = "not-locale" };

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            RequestFailedException ex;

            using (Recording.DisableRequestBodyRecording())
            {
                ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeDocumentAsync(modelId, stream, options));
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

            // Check Document Entities.

            foreach (DocumentEntity entity in result.Entities)
            {
                ValidateEntity(entity, expectedFirstPageNumber, expectedLastPageNumber);
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

                Assert.NotNull(kvp.Value);

                foreach (BoundingRegion region in kvp.Value.BoundingRegions)
                {
                    ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
                }
            }

            // Check Document Pages.

            int currentPageNumber = expectedFirstPageNumber;

            foreach (DocumentPage page in result.Pages)
            {
                ValidatePage(page, currentPageNumber++);
            }

            Assert.AreEqual(expectedLastPageNumber, currentPageNumber - 1);

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
        }

        private void ValidateAnalyzedDocument(AnalyzedDocument document, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(document.DocType);
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
            Assert.NotNull(region.BoundingBox.Points);

            if (region.BoundingBox.Points.Length != 0)
            {
                Assert.AreEqual(4, region.BoundingBox.Points.Length);
            }

            Assert.That(region.PageNumber, Is.GreaterThanOrEqualTo(expectedFirstPageNumber).Or.LessThanOrEqualTo(expectedLastPageNumber));
        }

        private void ValidateEntity(DocumentEntity entity, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(entity);

            foreach (BoundingRegion region in entity.BoundingRegions)
            {
                ValidateBoundingRegion(region, expectedFirstPageNumber, expectedLastPageNumber);
            }

            Assert.That(entity.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
            Assert.That(entity.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

            Assert.NotNull(entity.Category);
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
                Assert.NotNull(line.BoundingBox.Points);
                Assert.AreEqual(4, line.BoundingBox.Points.Length);
            }

            Assert.NotNull(page.Words);

            foreach (DocumentWord word in page.Words)
            {
                Assert.NotNull(word.BoundingBox.Points);
                Assert.AreEqual(4, word.BoundingBox.Points.Length);

                Assert.That(word.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(word.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }

            Assert.NotNull(page.SelectionMarks);

            foreach (DocumentSelectionMark selectionMark in page.SelectionMarks)
            {
                Assert.NotNull(selectionMark.BoundingBox.Points);
                Assert.AreEqual(4, selectionMark.BoundingBox.Points.Length);

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
    }
}
