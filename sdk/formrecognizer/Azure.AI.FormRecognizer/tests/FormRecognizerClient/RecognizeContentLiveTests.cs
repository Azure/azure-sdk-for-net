// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the `StartRecognizeContent` methods in the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(
    FormRecognizerClientOptions.ServiceVersion.V2_0,
    FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class RecognizeContentLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeContentLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task StartRecognizeContentCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeContentOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeContentAsync(stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            FormPageCollection formPages = await operation.WaitForCompletionAsync();
            var formPage = formPages.Single();

            Assert.Greater(formPage.Lines.Count, 0);
            Assert.AreEqual("Contoso", formPage.Lines[0].Text);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform operations.
        /// </summary>
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeContentPopulatesFormPagePdf(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoicePdf);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeContentAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoicePdf);
                operation = await client.StartRecognizeContentFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            var formPage = operation.Value.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the form. We are not testing the service here, but the SDK.

            Assert.AreEqual(LengthUnit.Inch, formPage.Unit);
            Assert.AreEqual(8.5, formPage.Width);
            Assert.AreEqual(11, formPage.Height);
            Assert.AreEqual(0, formPage.TextAngle);
            Assert.AreEqual(18, formPage.Lines.Count);

            var lines = formPage.Lines.ToList();

            for (var lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                var line = lines[lineIndex];

                Assert.NotNull(line.Text, $"Text should not be null in line {lineIndex}.");
                Assert.AreEqual(4, line.BoundingBox.Points.Count(), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
                Assert.Greater(line.Words.Count, 0, $"There should be at least one word in line {lineIndex}.");
                foreach (var item in line.Words)
                {
                    Assert.GreaterOrEqual(item.Confidence, 0);
                }

                Assert.IsNotNull(line.Appearance);
                Assert.IsNotNull(line.Appearance.Style);
                Assert.AreEqual(TextStyleName.Other, line.Appearance.Style.Name);
                Assert.Greater(line.Appearance.Style.Confidence, 0f);
            }

            var table = formPage.Tables.Single();

            Assert.AreEqual(3, table.RowCount);
            Assert.AreEqual(5, table.ColumnCount);
            Assert.AreEqual(4, table.BoundingBox.Points.Count(), $"There should be exactly 4 points in the table bounding box.");

            var cells = table.Cells.ToList();

            Assert.AreEqual(10, cells.Count);

            var expectedText = new string[2, 5]
            {
                { "Invoice Number", "Invoice Date", "Invoice Due Date", "Charges", "VAT ID" },
                { "34278587", "6/18/2017", "6/24/2017", "$56,651.49", "PT" }
            };

            foreach (var cell in cells)
            {
                Assert.GreaterOrEqual(cell.RowIndex, 0, $"Cell with text {cell.Text} should have row index greater than or equal to zero.");
                Assert.Less(cell.RowIndex, table.RowCount, $"Cell with text {cell.Text} should have row index less than {table.RowCount}.");
                Assert.GreaterOrEqual(cell.ColumnIndex, 0, $"Cell with text {cell.Text} should have column index greater than or equal to zero.");
                Assert.Less(cell.ColumnIndex, table.ColumnCount, $"Cell with text {cell.Text} should have column index less than {table.ColumnCount}.");

                if (cell.RowIndex == 0)
                {
                    Assert.IsTrue(cell.IsHeader);
                }
                else
                {
                    Assert.IsFalse(cell.IsHeader, $"Cell with text {cell.Text} should not have been classified as header.");
                }

                // Row = 1 has a row span of 2.
                var expectedRowSpan = cell.RowIndex == 1 ? 2 : 1;
                Assert.AreEqual(expectedRowSpan, cell.RowSpan, $"Cell with text {cell.Text} should have a row span of {expectedRowSpan}.");

                Assert.IsFalse(cell.IsFooter, $"Cell with text {cell.Text} should not have been classified as footer.");
                Assert.GreaterOrEqual(cell.Confidence, 0, $"Cell with text {cell.Text} should have confidence greater or equal to zero.");
                Assert.LessOrEqual(cell.RowIndex, 2, $"Cell with text {cell.Text} should have a row index less than or equal to two.");

                Assert.AreEqual(expectedText[cell.RowIndex, cell.ColumnIndex], cell.Text);
                Assert.Greater(cell.FieldElements.Count, 0, $"Cell with text {cell.Text} should have at least one field element.");
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeContentPopulatesFormPageJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeContentAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartRecognizeContentFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            var formPage = operation.Value.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the form. We are not testing the service here, but the SDK.

            Assert.AreEqual(LengthUnit.Pixel, formPage.Unit);
            Assert.AreEqual(1700, formPage.Width);
            Assert.AreEqual(2200, formPage.Height);
            Assert.AreEqual(0, formPage.TextAngle);
            Assert.AreEqual(54, formPage.Lines.Count);

            var lines = formPage.Lines.ToList();

            for (var lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                var line = lines[lineIndex];

                Assert.NotNull(line.Text, $"Text should not be null in line {lineIndex}.");
                Assert.AreEqual(4, line.BoundingBox.Points.Count(), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
                Assert.Greater(line.Words.Count, 0, $"There should be at least one word in line {lineIndex}.");
                foreach (var item in line.Words)
                {
                    Assert.GreaterOrEqual(item.Confidence, 0);
                }

                Assert.IsNotNull(line.Appearance);
                Assert.IsNotNull(line.Appearance.Style);
                Assert.Greater(line.Appearance.Style.Confidence, 0f);

                if (lineIndex == 45)
                {
                    Assert.AreEqual(TextStyleName.Handwriting, line.Appearance.Style.Name);
                }
                else
                {
                    Assert.AreEqual(TextStyleName.Other, line.Appearance.Style.Name);
                }
            }

            Assert.AreEqual(2, formPage.Tables.Count);

            var sampleTable = formPage.Tables[1];

            Assert.AreEqual(4, sampleTable.RowCount);
            Assert.AreEqual(2, sampleTable.ColumnCount);
            Assert.AreEqual(4, sampleTable.BoundingBox.Points.Count(), $"There should be exactly 4 points in the table bounding box.");

            var cells = sampleTable.Cells.ToList();

            Assert.AreEqual(8, cells.Count);

            var expectedText = new string[4, 2]
            {
                { "SUBTOTAL", "$140.00" },
                { "TAX", "$4.00" },
                { "", ""},
                { "TOTAL", "$144.00" }
            };

            for (int i = 0; i < cells.Count; i++)
            {
                Assert.GreaterOrEqual(cells[i].RowIndex, 0, $"Cell with text {cells[i].Text} should have row index greater than or equal to zero.");
                Assert.Less(cells[i].RowIndex, sampleTable.RowCount, $"Cell with text {cells[i].Text} should have row index less than {sampleTable.RowCount}.");
                Assert.GreaterOrEqual(cells[i].ColumnIndex, 0, $"Cell with text {cells[i].Text} should have column index greater than or equal to zero.");
                Assert.Less(cells[i].ColumnIndex, sampleTable.ColumnCount, $"Cell with text {cells[i].Text} should have column index less than {sampleTable.ColumnCount}.");

                Assert.AreEqual(1, cells[i].RowSpan, $"Cell with text {cells[i].Text} should have a row span of 1.");
                Assert.AreEqual(1, cells[i].ColumnSpan, $"Cell with text {cells[i].Text} should have a column span of 1.");

                Assert.AreEqual(expectedText[cells[i].RowIndex, cells[i].ColumnIndex], cells[i].Text);

                Assert.IsFalse(cells[i].IsFooter, $"Cell with text {cells[i].Text} should not have been classified as footer.");

                if (cells[i].RowIndex == 0)
                {
                    Assert.IsTrue(cells[i].IsHeader);
                }
                else
                {
                    Assert.IsFalse(cells[i].IsHeader, $"Cell with text {cells[i].Text} should not have been classified as header.");
                }

                Assert.GreaterOrEqual(cells[i].Confidence, 0, $"Cell with text {cells[i].Text} should have confidence greater or equal to zero.");

                // Empty row
                if (cells[i].RowIndex != 2)
                {
                    Assert.Greater(cells[i].FieldElements.Count, 0, $"Cell with text {cells[i].Text} should have at least one field element.");
                }
                else
                {
                    Assert.AreEqual(0, cells[i].FieldElements.Count);
                }
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeContentCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeContentAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartRecognizeContentFromUriAsync(uri);
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, formPages.Count);

            for (int pageIndex = 0; pageIndex < formPages.Count; pageIndex++)
            {
                var formPage = formPages[pageIndex];

                ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = formPage.Lines[1];
                var expectedText = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.AreEqual(expectedText, sampleLine.Text);
            }
        }

        [RecordedTest]
        public async Task StartRecognizeContentCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeContentOptions();
            RecognizeContentOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeContentAsync(stream, options);
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync();
            var blankPage = formPages.Single();

            ValidateFormPage(blankPage, includeFieldElements: true, expectedPageNumber: 1);

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
            Assert.AreEqual(0, blankPage.SelectionMarks.Count);
        }

        [RecordedTest]
        public async Task StartRecognizeContentCanParseMultipageFormWithBlankPage()
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeContentAsync(stream);
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync();

            Assert.AreEqual(3, formPages.Count);

            for (int pageIndex = 0; pageIndex < formPages.Count; pageIndex++)
            {
                var formPage = formPages[pageIndex];

                ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                if (pageIndex == 0 || pageIndex == 2)
                {
                    var sampleLine = formPage.Lines[3];
                    var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.AreEqual(expectedText, sampleLine.Text);
                }
            }

            var blankPage = formPages[1];

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        public void StartRecognizeContentFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentFromUriAsync(invalidUri));
            Assert.AreEqual("InvalidImage", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeContentWithSelectionMarks(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeContentAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.FormSelectionMarks);
                operation = await client.StartRecognizeContentFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            var formPage = operation.Value.Single();

            ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: 1);
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public void StartRecognizeContentWithNoSupporttedLanguage()
        {
            var client = CreateFormRecognizerClient();
            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentFromUriAsync(uri, new RecognizeContentOptions() { Language = "not language" }));
            Assert.AreEqual("NotSupportedLanguage", ex.ErrorCode);
        }
    }
}
