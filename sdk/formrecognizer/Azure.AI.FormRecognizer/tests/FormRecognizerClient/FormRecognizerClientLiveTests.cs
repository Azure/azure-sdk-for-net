// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class FormRecognizerClientLiveTests : FormRecognizerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public void FormRecognizerClientCannotAuthenticateWithFakeApiKey()
        {
            var client = CreateFormRecognizerClient(apiKey: "fakeKey");

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentAsync(stream));
            }
        }

        #region StartRecognizeContent

        [Test]
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

            FormPageCollection formPages = await operation.WaitForCompletionAsync(PollingInterval);
            var formPage = formPages.Single();

            Assert.Greater(formPage.Lines.Count, 0);
            Assert.AreEqual("Contoso", formPage.Lines[0].Text);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform operations.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
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

            await operation.WaitForCompletionAsync(PollingInterval);
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
                Assert.AreEqual(TextStyle.Other, line.Appearance.Style.Name);
                Assert.Greater(line.Appearance.Style.Confidence, 0f);
            }

            var table = formPage.Tables.Single();

            Assert.AreEqual(3, table.RowCount);
            Assert.AreEqual(6, table.ColumnCount);
            Assert.AreEqual(4, table.BoundingBox.Points.Count(), $"There should be exactly 4 points in the table bounding box.");

            var cells = table.Cells.ToList();

            Assert.AreEqual(11, cells.Count);

            var expectedText = new string[2, 6]
            {
                { "Invoice Number", "Invoice Date", "Invoice Due Date", "Charges", "", "VAT ID" },
                { "34278587", "6/18/2017", "6/24/2017", "$56,651.49", "", "PT" }
            };

            foreach (var cell in cells)
            {
                Assert.GreaterOrEqual(cell.RowIndex, 0, $"Cell with text {cell.Text} should have row index greater than or equal to zero.");
                Assert.Less(cell.RowIndex, table.RowCount, $"Cell with text {cell.Text} should have row index less than {table.RowCount}.");
                Assert.GreaterOrEqual(cell.ColumnIndex, 0, $"Cell with text {cell.Text} should have column index greater than or equal to zero.");
                Assert.Less(cell.ColumnIndex, table.ColumnCount, $"Cell with text {cell.Text} should have column index less than {table.ColumnCount}.");

                // Column = 3 has a column span of 2.
                var expectedColumnSpan = cell.ColumnIndex == 3 ? 2 : 1;
                Assert.AreEqual(expectedColumnSpan, cell.ColumnSpan, $"Cell with text {cell.Text} should have a column span of {expectedColumnSpan}.");

                // Row = 1 and columns 0-4 have a row span of 2.
                var expectedRowSpan = (cell.RowIndex == 1 && cell.ColumnIndex != 5) ? 2 : 1;
                Assert.AreEqual(expectedRowSpan, cell.RowSpan, $"Cell with text {cell.Text} should have a row span of {expectedRowSpan}.");

                Assert.IsFalse(cell.IsFooter, $"Cell with text {cell.Text} should not have been classified as footer.");
                Assert.IsFalse(cell.IsHeader, $"Cell with text {cell.Text} should not have been classified as header.");

                Assert.GreaterOrEqual(cell.Confidence, 0, $"Cell with text {cell.Text} should have confidence greater or equal to zero.");
                Assert.LessOrEqual(cell.RowIndex, 2, $"Cell with text {cell.Text} should have a row index less than or equal to two.");

                // row = 2, column = 5 has empty text and no elements
                if (cell.RowIndex == 2 && cell.ColumnIndex == 5)
                {
                    Assert.IsEmpty(cell.Text);
                    Assert.AreEqual(0, cell.FieldElements.Count);
                }
                else
                {
                    Assert.AreEqual(expectedText[cell.RowIndex, cell.ColumnIndex], cell.Text);
                    Assert.Greater(cell.FieldElements.Count, 0, $"Cell with text {cell.Text} should have at least one field element.");
                }
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
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

            await operation.WaitForCompletionAsync(PollingInterval);
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
                    Assert.AreEqual(TextStyle.Handwriting, line.Appearance.Style.Name);
                }
                else
                {
                    Assert.AreEqual(TextStyle.Other, line.Appearance.Style.Name);
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
                Assert.IsFalse(cells[i].IsHeader, $"Cell with text {cells[i].Text} should not have been classified as header.");

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

        [Test]
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

            FormPageCollection formPages = await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
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

            FormPageCollection formPages = await operation.WaitForCompletionAsync(PollingInterval);
            var blankPage = formPages.Single();

            ValidateFormPage(blankPage, includeFieldElements: true, expectedPageNumber: 1);

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
            Assert.AreEqual(0, blankPage.SelectionMarks.Count);
        }

        [Test]
        public async Task StartRecognizeContentCanParseMultipageFormWithBlankPage()
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeContentAsync(stream);
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
        public void StartRecognizeContentThrowsForDamagedFile()
        {
            var client = CreateFormRecognizerClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentAsync(stream));
            Assert.AreEqual("InvalidImage", ex.ErrorCode);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeContentFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentFromUriAsync(invalidUri));
            Assert.AreEqual("FailedToDownloadImage", ex.ErrorCode);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
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

            await operation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(operation.HasValue);

            var formPage = operation.Value.Single();

            ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: 1);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("1-2", 2)]
        public async Task StartRecognizeContentWithOnePageArgument(string pages, int expected)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeContentAsync(stream, new RecognizeContentOptions() { Pages = new List<string> { pages } });
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(expected, formPages.Count);
        }

        [Test]
        [TestCase("1", "3", 2)]
        [TestCase("1-2", "3", 3)]
        public async Task StartRecognizeContentWithMultiplePageArgument(string page1, string page2, int expected)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeContentAsync(stream, new RecognizeContentOptions() { Pages = new List<string> { page1, page2 } });
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(expected, formPages.Count);
        }

        [Test]
        [TestCase("en")]
        [TestCase("")]
        public async Task StartRecognizeContentWithLanguage(string language)
        {
            var client = CreateFormRecognizerClient();
            RecognizeContentOperation operation;

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
            operation = await client.StartRecognizeContentFromUriAsync(uri, new RecognizeContentOptions() { Language = language } );

            await operation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(operation.HasValue);

            var formPage = operation.Value.Single();

            ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: 1);
        }

        [Test]
        public void StartRecognizeContentWithNoSupporttedLanguage()
        {
            var client = CreateFormRecognizerClient();
            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentFromUriAsync(uri, new RecognizeContentOptions() { Language = "not language" }) );
            Assert.AreEqual("NotSupportedLanguage", ex.ErrorCode);
        }

        #endregion

        #region StartRecognizeReceipts

        [Test]
        public async Task StartRecognizeReceiptsCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeReceiptsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeReceiptsAsync(stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync(PollingInterval);

            RecognizedForm form = formPage.Single();
            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis of receipts.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeReceiptsPopulatesExtractedReceiptJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeReceiptsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeReceiptsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.ReceiptJpg);
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri, default);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the receipt. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:receipt", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("ReceiptType"));
            Assert.True(form.Fields.ContainsKey("MerchantAddress"));
            Assert.True(form.Fields.ContainsKey("MerchantName"));
            Assert.True(form.Fields.ContainsKey("MerchantPhoneNumber"));
            Assert.True(form.Fields.ContainsKey("TransactionDate"));
            Assert.True(form.Fields.ContainsKey("TransactionTime"));
            Assert.True(form.Fields.ContainsKey("Items"));
            Assert.True(form.Fields.ContainsKey("Subtotal"));
            Assert.True(form.Fields.ContainsKey("Tax"));
            Assert.True(form.Fields.ContainsKey("Total"));

            Assert.AreEqual("Itemized", form.Fields["ReceiptType"].Value.AsString());
            Assert.AreEqual("Contoso Contoso", form.Fields["MerchantName"].Value.AsString());
            Assert.AreEqual("123 Main Street Redmond, WA 98052", form.Fields["MerchantAddress"].Value.AsString());
            Assert.AreEqual("123-456-7890", form.Fields["MerchantPhoneNumber"].ValueData.Text);

            var date = form.Fields["TransactionDate"].Value.AsDate();
            var time = form.Fields["TransactionTime"].Value.AsTime();

            Assert.AreEqual(10, date.Day);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(2019, date.Year);

            Assert.AreEqual(13, time.Hours);
            Assert.AreEqual(59, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            var expectedItems = new List<(int? Quantity, string Name, float? Price, float? TotalPrice)>()
            {
                (null, "8GB RAM (Black)", null, 999.00f),
                (1, "SurfacePen", null, 99.99f)
            };

            // Include a bit of tolerance when comparing float types.

            var items = form.Fields["Items"].Value.AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].Value.AsDictionary();

                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("Name", out var nameField);
                receiptItemInfo.TryGetValue("Price", out var priceField);
                receiptItemInfo.TryGetValue("TotalPrice", out var totalPriceField);

                var quantity = quantityField == null ? null : (float?)quantityField.Value.AsFloat();
                var name = nameField == null ? null : nameField.Value.AsString();
                var price = priceField == null ? null : (float?)priceField.Value.AsFloat();
                var totalPrice = totalPriceField == null ? null : (float?)totalPriceField.Value.AsFloat();

                var expectedItem = expectedItems[itemIndex];

                Assert.AreEqual(expectedItem.Quantity, quantity, $"Quantity mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Name, name, $"Name mismatch in item with index {itemIndex}.");
                Assert.That(price, Is.EqualTo(expectedItem.Price).Within(0.0001), $"Price mismatch in item with index {itemIndex}.");
                Assert.That(totalPrice, Is.EqualTo(expectedItem.TotalPrice).Within(0.0001), $"Total price mismatch in item with index {itemIndex}.");
            }

            Assert.That(form.Fields["Subtotal"].Value.AsFloat(), Is.EqualTo(1098.99).Within(0.0001));
            Assert.That(form.Fields["Tax"].Value.AsFloat(), Is.EqualTo(104.40).Within(0.0001));
            Assert.That(form.Fields["Total"].Value.AsFloat(), Is.EqualTo(1203.39).Within(0.0001));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeReceiptsPopulatesExtractedReceiptPng(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeReceiptsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptPng);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeReceiptsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.ReceiptPng);
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri, default);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the receipt. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:receipt", form.FormType);

            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("ReceiptType"));
            Assert.True(form.Fields.ContainsKey("MerchantAddress"));
            Assert.True(form.Fields.ContainsKey("MerchantName"));
            Assert.True(form.Fields.ContainsKey("MerchantPhoneNumber"));
            Assert.True(form.Fields.ContainsKey("TransactionDate"));
            Assert.True(form.Fields.ContainsKey("TransactionTime"));
            Assert.True(form.Fields.ContainsKey("Items"));
            Assert.True(form.Fields.ContainsKey("Subtotal"));
            Assert.True(form.Fields.ContainsKey("Tax"));
            Assert.True(form.Fields.ContainsKey("Tip"));
            Assert.True(form.Fields.ContainsKey("Total"));

            Assert.AreEqual("Itemized", form.Fields["ReceiptType"].Value.AsString());
            Assert.AreEqual("Contoso Contoso", form.Fields["MerchantName"].Value.AsString());
            Assert.AreEqual("123 Main Street Redmond, WA 98052", form.Fields["MerchantAddress"].Value.AsString());
            Assert.AreEqual("987-654-3210", form.Fields["MerchantPhoneNumber"].ValueData.Text);

            var date = form.Fields["TransactionDate"].Value.AsDate();
            var time = form.Fields["TransactionTime"].Value.AsTime();

            Assert.AreEqual(10, date.Day);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(2020, date.Year);

            Assert.AreEqual(13, time.Hours);
            Assert.AreEqual(59, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            var expectedItems = new List<(int? Quantity, string Name, float? Price, float? TotalPrice)>()
            {
                (1, "Cappuccino", null, 2.20f),
                (1, "BACON & EGGS", null, 9.50f)
            };

            // Include a bit of tolerance when comparing float types.

            var items = form.Fields["Items"].Value.AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].Value.AsDictionary();

                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("Name", out var nameField);
                receiptItemInfo.TryGetValue("Price", out var priceField);
                receiptItemInfo.TryGetValue("TotalPrice", out var totalPriceField);

                var quantity = quantityField == null ? null : (float?)quantityField.Value.AsFloat();
                var name = nameField == null ? null : nameField.Value.AsString();
                var price = priceField == null ? null : (float?)priceField.Value.AsFloat();
                var totalPrice = totalPriceField == null ? null : (float?)totalPriceField.Value.AsFloat();

                var expectedItem = expectedItems[itemIndex];

                Assert.AreEqual(expectedItem.Quantity, quantity, $"Quantity mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Name, name, $"Name mismatch in item with index {itemIndex}.");
                Assert.That(price, Is.EqualTo(expectedItem.Price).Within(0.0001), $"Price mismatch in item with index {itemIndex}.");
                Assert.That(totalPrice, Is.EqualTo(expectedItem.TotalPrice).Within(0.0001), $"Total price mismatch in item with index {itemIndex}.");
            }

            Assert.That(form.Fields["Subtotal"].Value.AsFloat(), Is.EqualTo(11.70).Within(0.0001));
            Assert.That(form.Fields["Tax"].Value.AsFloat(), Is.EqualTo(1.17).Within(0.0001));
            Assert.That(form.Fields["Tip"].Value.AsFloat(), Is.EqualTo(1.63).Within(0.0001));
            Assert.That(form.Fields["Total"].Value.AsFloat(), Is.EqualTo(14.50).Within(0.0001));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeReceiptsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeReceiptsOptions() { IncludeFieldElements = true };
            RecognizeReceiptsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeReceiptsAsync(stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(2, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                Assert.NotNull(recognizedForm);

                ValidatePrebuiltForm(
                    recognizedForm,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                if (formIndex == 0)
                {
                    var sampleField = recognizedForm.Fields["MerchantAddress"];

                    Assert.IsNotNull(sampleField.ValueData);
                    Assert.AreEqual("2345 Dogwood Lane Birch, Kansas 98123", sampleField.ValueData.Text);
                }
                else if (formIndex == 1)
                {
                    Assert.IsFalse(recognizedForm.Fields.TryGetValue("MerchantAddress", out _));
                }
            }
        }

        [Test]
        public async Task StartRecognizeReceiptsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeReceiptsOptions() { IncludeFieldElements = true };
            RecognizeReceiptsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeReceiptsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var blankForm = recognizedForms.Single();

            ValidatePrebuiltForm(
                blankForm,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        public async Task StartRecognizeReceiptsCanParseMultipageFormWithBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeReceiptsOptions() { IncludeFieldElements = true };
            RecognizeReceiptsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeReceiptsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(3, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                Assert.NotNull(recognizedForm);

                ValidatePrebuiltForm(
                    recognizedForm,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                if (formIndex == 0 || formIndex == 2)
                {
                    var sampleField = recognizedForm.Fields["MerchantName"];
                    var expectedValueData = formIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.IsNotNull(sampleField.ValueData);
                    Assert.AreEqual(expectedValueData, sampleField.ValueData.Text);
                }
            }

            var blankForm = recognizedForms[1];

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        public void StartRecognizeReceiptsThrowsForDamagedFile()
        {
            var client = CreateFormRecognizerClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeReceiptsAsync(stream));
            Assert.AreEqual("BadArgument", ex.ErrorCode);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeReceiptsFromUriAsync(invalidUri));
            Assert.AreEqual("FailedToDownloadImage", ex.ErrorCode);
        }

        [Test]
        [TestCase("en-US")]
        [TestCase("")]
        public async Task StartRecognizeReceiptsWithSupportedLocale(string locale)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeReceiptsOptions()
            {
                IncludeFieldElements = true,
                Locale = locale
            };
            RecognizeReceiptsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeReceiptsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var receipt = recognizedForms.Single();

            ValidatePrebuiltForm(
                receipt,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.Greater(receipt.Fields.Count, 0);

            var receiptPage = receipt.Pages.Single();

            Assert.Greater(receiptPage.Lines.Count, 0);
            Assert.AreEqual(0, receiptPage.SelectionMarks.Count);
            Assert.AreEqual(0, receiptPage.Tables.Count);
        }

        [Test]
        public void StartRecognizeReceiptsWithWrongLocale()
        {
            var client = CreateFormRecognizerClient();

            var receiptUri = FormRecognizerTestEnvironment.CreateUri(TestFile.ReceiptJpg);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeReceiptsFromUriAsync(receiptUri, new RecognizeReceiptsOptions() { Locale = "not-locale" }));
            Assert.AreEqual("UnsupportedLocale", ex.ErrorCode);
        }

        #endregion

        #region StartRecognizeBusinessCards

        [Test]
        public async Task StartRecognizeBusinessCardsCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeBusinessCardsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeBusinessCardsAsync(stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync(PollingInterval);

            RecognizedForm form = formPage.Single();
            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false) ]
        public async Task StartRecognizeBusinessCardsPopulatesExtractedJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeBusinessCardsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeBusinessCardsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessCardJpg);
                operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:businesscard", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("ContactNames"));
            Assert.True(form.Fields.ContainsKey("JobTitles"));
            Assert.True(form.Fields.ContainsKey("Departments"));
            Assert.True(form.Fields.ContainsKey("Emails"));
            Assert.True(form.Fields.ContainsKey("Websites"));
            Assert.True(form.Fields.ContainsKey("MobilePhones"));
            Assert.True(form.Fields.ContainsKey("OtherPhones"));
            Assert.True(form.Fields.ContainsKey("Faxes"));
            Assert.True(form.Fields.ContainsKey("Addresses"));
            Assert.True(form.Fields.ContainsKey("CompanyNames"));

            var contactNames = form.Fields["ContactNames"].Value.AsList();
            Assert.AreEqual(1, contactNames.Count);
            Assert.AreEqual("Dr. Avery Smith", contactNames.FirstOrDefault().ValueData.Text);
            Assert.AreEqual(1, contactNames.FirstOrDefault().ValueData.PageNumber);

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.True(contactNamesDict.ContainsKey("FirstName"));
            Assert.AreEqual("Avery", contactNamesDict["FirstName"].Value.AsString());

            Assert.True(contactNamesDict.ContainsKey("LastName"));
            Assert.AreEqual("Smith", contactNamesDict["LastName"].Value.AsString());

            var jobTitles = form.Fields["JobTitles"].Value.AsList();
            Assert.AreEqual(1, jobTitles.Count);
            Assert.AreEqual("Senior Researcher", jobTitles.FirstOrDefault().Value.AsString());

            var departments = form.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.AreEqual("Cloud & Al Department", departments.FirstOrDefault().Value.AsString());

            var emails = form.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.AreEqual("avery.smith@contoso.com", emails.FirstOrDefault().Value.AsString());

            var websites = form.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.AreEqual("https://www.contoso.com/", websites.FirstOrDefault().Value.AsString());

            // Update validation when https://github.com/Azure/azure-sdk-for-python/issues/14300 is fixed
            var mobilePhones = form.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, mobilePhones.FirstOrDefault().Value.ValueType);

            var otherPhones = form.Fields["OtherPhones"].Value.AsList();
            Assert.AreEqual(1, otherPhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, otherPhones.FirstOrDefault().Value.ValueType);

            var faxes = form.Fields["Faxes"].Value.AsList();
            Assert.AreEqual(1, faxes.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, faxes.FirstOrDefault().Value.ValueType);

            var addresses = form.Fields["Addresses"].Value.AsList();
            Assert.AreEqual(1, addresses.Count);
            Assert.AreEqual("2 Kingdom Street Paddington, London, W2 6BD", addresses.FirstOrDefault().Value.AsString());

            var companyNames = form.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.AreEqual("Contoso", companyNames.FirstOrDefault().Value.AsString());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeBusinessCardsPopulatesExtractedPng(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeBusinessCardsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeBusinessCardsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessCardtPng);
                operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:businesscard", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("ContactNames"));
            Assert.True(form.Fields.ContainsKey("JobTitles"));
            Assert.True(form.Fields.ContainsKey("Departments"));
            Assert.True(form.Fields.ContainsKey("Emails"));
            Assert.True(form.Fields.ContainsKey("Websites"));
            Assert.True(form.Fields.ContainsKey("MobilePhones"));
            Assert.True(form.Fields.ContainsKey("OtherPhones"));
            Assert.True(form.Fields.ContainsKey("Faxes"));
            Assert.True(form.Fields.ContainsKey("Addresses"));
            Assert.True(form.Fields.ContainsKey("CompanyNames"));

            var contactNames = form.Fields["ContactNames"].Value.AsList();
            Assert.AreEqual(1, contactNames.Count);
            Assert.AreEqual("Dr. Avery Smith", contactNames.FirstOrDefault().ValueData.Text);
            Assert.AreEqual(1, contactNames.FirstOrDefault().ValueData.PageNumber);

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.True(contactNamesDict.ContainsKey("FirstName"));
            Assert.AreEqual("Avery", contactNamesDict["FirstName"].Value.AsString());

            Assert.True(contactNamesDict.ContainsKey("LastName"));
            Assert.AreEqual("Smith", contactNamesDict["LastName"].Value.AsString());

            var jobTitles = form.Fields["JobTitles"].Value.AsList();
            Assert.AreEqual(1, jobTitles.Count);
            Assert.AreEqual("Senior Researcher", jobTitles.FirstOrDefault().Value.AsString());

            var departments = form.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.AreEqual("Cloud & Al Department", departments.FirstOrDefault().Value.AsString());

            var emails = form.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.AreEqual("avery.smith@contoso.com", emails.FirstOrDefault().Value.AsString());

            var websites = form.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.AreEqual("https://www.contoso.com/", websites.FirstOrDefault().Value.AsString());

            // Update validation when https://github.com/Azure/azure-sdk-for-python/issues/14300 is fixed
            var mobilePhones = form.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, mobilePhones.FirstOrDefault().Value.ValueType);

            var otherPhones = form.Fields["OtherPhones"].Value.AsList();
            Assert.AreEqual(1, otherPhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, otherPhones.FirstOrDefault().Value.ValueType);

            var faxes = form.Fields["Faxes"].Value.AsList();
            Assert.AreEqual(1, faxes.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, faxes.FirstOrDefault().Value.ValueType);

            var addresses = form.Fields["Addresses"].Value.AsList();
            Assert.AreEqual(1, addresses.Count);
            Assert.AreEqual("2 Kingdom Street Paddington, London, W2 6BD", addresses.FirstOrDefault().Value.AsString());

            var companyNames = form.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.AreEqual("Contoso", companyNames.FirstOrDefault().Value.AsString());
        }

        [Test]
        public async Task StartRecognizeBusinessCardsIncludeFieldElements()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeBusinessCardsOptions() { IncludeFieldElements = true };
            RecognizeBusinessCardsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var businessCardsForm = recognizedForms.Single();

            ValidatePrebuiltForm(
                businessCardsForm,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
       }

        [Test]
        public async Task StartRecognizeBusinessCardsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeBusinessCardsOptions() { IncludeFieldElements = true };
            RecognizeBusinessCardsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var blankForm = recognizedForms.Single();

            ValidatePrebuiltForm(
                blankForm,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
            Assert.AreEqual(0, blankPage.SelectionMarks.Count);
        }

        [Test]
        public void StartRecognizeBusinessCardsThrowsForDamagedFile()
        {
            var client = CreateFormRecognizerClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeBusinessCardsAsync(stream));
            Assert.AreEqual("BadArgument", ex.ErrorCode);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeBusinessCardsFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeBusinessCardsFromUriAsync(invalidUri));
            Assert.AreEqual("FailedToDownloadImage", ex.ErrorCode);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeBusinessCardsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeBusinessCardsOptions() { IncludeFieldElements = true };
            RecognizeBusinessCardsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessMultipage);
                operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(2, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                Assert.NotNull(recognizedForm);

                ValidatePrebuiltForm(
                    recognizedForm,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                Assert.IsTrue(recognizedForm.Fields.ContainsKey("Emails"));
                FormField sampleFields = recognizedForm.Fields["Emails"];
                Assert.AreEqual(FieldValueType.List, sampleFields.Value.ValueType);
                var field = sampleFields.Value.AsList().Single();

                if (formIndex == 0)
                {
                    Assert.AreEqual("johnsinger@contoso.com", field.ValueData.Text);
                }
                else if (formIndex == 1)
                {
                    Assert.AreEqual("avery.smith@contoso.com", field.ValueData.Text);
                }

                // Check for ContactNames.Page value
                Assert.IsTrue(recognizedForm.Fields.ContainsKey("ContactNames"));
                FormField contactNameField = recognizedForm.Fields["ContactNames"].Value.AsList().Single();
                Assert.AreEqual(formIndex + 1, contactNameField.ValueData.PageNumber);
            }
        }

        #endregion

        #region StartRecognizeInvoices

        [Test]
        public async Task StartRecognizeInvoicesCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoicePdf);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync(PollingInterval);

            RecognizedForm form = formPage.Single();
            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeInvoicesPopulatesExtractedPdf(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeInvoicesOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoicePdf);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeInvoicesAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoicePdf);
                operation = await client.StartRecognizeInvoicesFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:invoice", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("VendorName"));
            Assert.True(form.Fields.ContainsKey("CustomerAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("VendorAddress"));
            Assert.True(form.Fields.ContainsKey("CustomerAddress"));
            Assert.True(form.Fields.ContainsKey("InvoiceId"));
            Assert.True(form.Fields.ContainsKey("InvoiceDate"));
            Assert.True(form.Fields.ContainsKey("DueDate"));
            Assert.True(form.Fields.ContainsKey("InvoiceTotal"));
            Assert.True(form.Fields.ContainsKey("CustomerName"));

            Assert.AreEqual("Contoso", form.Fields["VendorName"].Value.AsString());
            Assert.AreEqual("Microsoft", form.Fields["CustomerAddressRecipient"].Value.AsString());
            Assert.AreEqual("1 Redmond way Suite 6000 Redmond, WA 99243", form.Fields["VendorAddress"].Value.AsString());
            Assert.AreEqual("1020 Enterprise Way Sunnayvale, CA 87659", form.Fields["CustomerAddress"].Value.AsString());
            Assert.AreEqual("Microsoft", form.Fields["CustomerName"].Value.AsString());

            Assert.That(form.Fields["InvoiceTotal"].Value.AsFloat(), Is.EqualTo(56651.49f).Within(0.0001));

            var invoiceDate = form.Fields["InvoiceDate"].Value.AsDate();
            Assert.AreEqual(18, invoiceDate.Day);
            Assert.AreEqual(6, invoiceDate.Month);
            Assert.AreEqual(2017, invoiceDate.Year);

            var dueDate = form.Fields["DueDate"].Value.AsDate();
            Assert.AreEqual(24, dueDate.Day);
            Assert.AreEqual(6, dueDate.Month);
            Assert.AreEqual(2017, dueDate.Year);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeInvoicesPopulatesExtractedTiff(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeInvoicesOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeInvoicesAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceLeTiff);
                operation = await client.StartRecognizeInvoicesFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: false,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:invoice", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("VendorName"));
            Assert.True(form.Fields.ContainsKey("CustomerAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("VendorAddress"));
            Assert.True(form.Fields.ContainsKey("CustomerAddress"));
            Assert.True(form.Fields.ContainsKey("InvoiceId"));
            Assert.True(form.Fields.ContainsKey("InvoiceDate"));
            Assert.True(form.Fields.ContainsKey("DueDate"));
            Assert.True(form.Fields.ContainsKey("InvoiceTotal"));
            Assert.True(form.Fields.ContainsKey("CustomerName"));

            Assert.AreEqual("Contoso", form.Fields["VendorName"].Value.AsString());
            Assert.AreEqual("Microsoft", form.Fields["CustomerAddressRecipient"].Value.AsString());
            Assert.AreEqual("1 Redmond way Suite 6000 Redmond, WA 99243", form.Fields["VendorAddress"].Value.AsString());
            Assert.AreEqual("1020 Enterprise Way Sunnayvale, CA 87659", form.Fields["CustomerAddress"].Value.AsString());
            Assert.AreEqual("Microsoft", form.Fields["CustomerName"].Value.AsString());

            Assert.That(form.Fields["InvoiceTotal"].Value.AsFloat(), Is.EqualTo(56651.49f).Within(0.0001));

            var invoiceDate = form.Fields["InvoiceDate"].Value.AsDate();
            Assert.AreEqual(18, invoiceDate.Day);
            Assert.AreEqual(6, invoiceDate.Month);
            Assert.AreEqual(2017, invoiceDate.Year);

            var dueDate = form.Fields["DueDate"].Value.AsDate();
            Assert.AreEqual(24, dueDate.Day);
            Assert.AreEqual(6, dueDate.Month);
            Assert.AreEqual(2017, dueDate.Year);
        }

        [Test]
        public async Task StartRecognizeInvoicesIncludeFieldElements()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeInvoicesOptions() { IncludeFieldElements = true };
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var invoicesform = recognizedForms.Single();

            ValidatePrebuiltForm(
                invoicesform,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [Test]
        public async Task StartRecognizeInvoicesCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var blankForm = recognizedForms.Single();

            ValidatePrebuiltForm(
                blankForm,
                includeFieldElements: false,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
            Assert.AreEqual(0, blankPage.SelectionMarks.Count);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeInvoicesCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeInvoicesOptions() { IncludeFieldElements = true };
            RecognizeInvoicesOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeInvoicesAsync(stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartRecognizeInvoicesFromUriAsync(uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var form = recognizedForms.Single();

            Assert.NotNull(form);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:invoice", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(2, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("VendorName"));
            Assert.True(form.Fields.ContainsKey("RemittanceAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("RemittanceAddress"));

            FormField vendorName = form.Fields["VendorName"];
            Assert.AreEqual(2, vendorName.ValueData.PageNumber);
            Assert.AreEqual("Southridge Video", vendorName.Value.AsString());

            FormField addressRecepient = form.Fields["RemittanceAddressRecipient"];
            Assert.AreEqual(1, addressRecepient.ValueData.PageNumber);
            Assert.AreEqual("Contoso Ltd.", addressRecepient.Value.AsString());

            FormField address = form.Fields["RemittanceAddress"];
            Assert.AreEqual(1, address.ValueData.PageNumber);
            Assert.AreEqual("2345 Dogwood Lane Birch, Kansas 98123", address.Value.AsString());

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2);
        }

        [Test]
        public void StartRecognizeInvoicesThrowsForDamagedFile()
        {
            var client = CreateFormRecognizerClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeInvoicesAsync(stream));
            Assert.AreEqual("BadArgument", ex.ErrorCode);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeInvoicesFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeInvoicesFromUriAsync(invalidUri));
            Assert.AreEqual("FailedToDownloadImage", ex.ErrorCode);
        }

        [Test]
        [TestCase("en-US")]
        [TestCase("")]
        public async Task StartRecognizeInvoicesWithSupportedLocale(string locale)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeInvoicesOptions()
            {
                IncludeFieldElements = true,
                Locale = locale
            };
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var invoice = recognizedForms.Single();

            ValidatePrebuiltForm(
                invoice,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.Greater(invoice.Fields.Count, 0);

            var receiptPage = invoice.Pages.Single();

            Assert.Greater(receiptPage.Lines.Count, 0);
            Assert.AreEqual(0, receiptPage.SelectionMarks.Count);
            Assert.AreEqual(1, receiptPage.Tables.Count);
        }

        [Test]
        public void StartRecognizeInvoicesWithWrongLocale()
        {
            var client = CreateFormRecognizerClient();

            var receiptUri = FormRecognizerTestEnvironment.CreateUri(TestFile.ReceiptJpg);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeInvoicesFromUriAsync(receiptUri, new RecognizeInvoicesOptions() { Locale = "not-locale" }));
            Assert.AreEqual("UnsupportedLocale", ex.ErrorCode);
        }

        #endregion

        #region StartRecognizeCustomForms

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsCanAuthenticateWithTokenCredential(bool useTrainingLabels)
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels);
            RecognizeCustomFormsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync(PollingInterval);

            RecognizedForm form = formPage.Single();
            Assert.NotNull(form);

            if (useTrainingLabels)
            {
                ValidateModelWithLabelsForm(
                                form,
                                trainedModel.ModelId,
                                includeFieldElements: false,
                                expectedFirstPageNumber: 1,
                                expectedLastPageNumber: 1,
                                isComposedModel: false);
            }
            else
            {
                ValidateModelWithNoLabelsForm(
                                form,
                                trainedModel.ModelId,
                                includeFieldElements: false,
                                expectedFirstPageNumber: 1,
                                expectedLastPageNumber: 1);
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis based on a custom labeled model.
        /// </summary>
        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task StartRecognizeCustomFormsWithLabels(bool useStream, bool includeFieldElements)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions { IncludeFieldElements = includeFieldElements };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.GreaterOrEqual(operation.Value.Count, 1);

            RecognizedForm form = operation.Value.Single();

            ValidateModelWithLabelsForm(
                form,
                trainedModel.ModelId,
                includeFieldElements: includeFieldElements,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1,
                isComposedModel: false);

            // Testing that we shuffle things around correctly so checking only once per property.

            Assert.IsNotEmpty(form.FormType);
            Assert.IsTrue(form.FormTypeConfidence.HasValue);
            Assert.AreEqual(1, form.Pages.Count);
            Assert.AreEqual(2200, form.Pages[0].Height);
            Assert.AreEqual(1, form.Pages[0].PageNumber);
            Assert.AreEqual(LengthUnit.Pixel, form.Pages[0].Unit);
            Assert.AreEqual(1700, form.Pages[0].Width);

            Assert.IsNotNull(form.Fields);
            var name = "PurchaseOrderNumber";
            Assert.IsNotNull(form.Fields[name]);
            Assert.AreEqual(FieldValueType.String, form.Fields[name].Value.ValueType);
            Assert.AreEqual("948284", form.Fields[name].ValueData.Text);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabelsAndSelectionMarks(bool includeFieldElements)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions { IncludeFieldElements = includeFieldElements };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.SelectionMarks);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.GreaterOrEqual(operation.Value.Count, 1);

            RecognizedForm form = operation.Value.Single();

            ValidateRecognizedForm(form, includeFieldElements: includeFieldElements,
                expectedFirstPageNumber: 1, expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.
            Assert.IsNotEmpty(form.FormType);
            Assert.IsNotNull(form.Fields);
            var name = "AMEX_SELECTION_MARK";
            Assert.IsNotNull(form.Fields[name]);
            Assert.AreEqual(FieldValueType.SelectionMark, form.Fields[name].Value.ValueType);
            Assert.AreEqual("Selected", form.Fields[name].ValueData.Text);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.MultipageFiles);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var recognizedForm = recognizedForms.Single();

            ValidateModelWithLabelsForm(
                recognizedForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2,
                isComposedModel: false);

            // Check some values to make sure that fields from both pages are being populated.

            Assert.AreEqual("Jamie@southridgevideo.com", recognizedForm.Fields["Contact"].Value.AsString());
            Assert.AreEqual("Southridge Video", recognizedForm.Fields["CompanyName"].Value.AsString());
            Assert.AreEqual("$1,500", recognizedForm.Fields["Gold"].Value.AsString());
            Assert.AreEqual("$1,000", recognizedForm.Fields["Bronze"].Value.AsString());

            Assert.AreEqual(2, recognizedForm.Pages.Count);

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                var formPage = recognizedForm.Pages[pageIndex];

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = formPage.Lines[1];
                var expectedText = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.AreEqual(expectedText, sampleLine.Text);
            }
        }

        [Test]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var recognizedForm = recognizedForms.Single();

            ValidateModelWithLabelsForm(
                recognizedForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1,
                isComposedModel: false);

            var blankPage = recognizedForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipageFormWithBlankPage(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipageBlank);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var recognizedForm = recognizedForms.Single();

            ValidateModelWithLabelsForm(
                recognizedForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 3,
                isComposedModel: false);

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                if (pageIndex == 0 || pageIndex == 2)
                {
                    var formPage = recognizedForm.Pages[pageIndex];
                    var sampleLine = formPage.Lines[3];
                    var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.AreEqual(expectedText, sampleLine.Text);
                }
            }

            var blankPage = recognizedForm.Pages[1];

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseDifferentTypeOfForm()
        {
            var client = CreateFormRecognizerClient();
            RecognizeCustomFormsOperation operation;

            // Use Form_<id>.<ext> files for training with labels.

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            // Attempt to recognize a different type of form: Invoice_1.pdf. This form does not contain all the labels
            // the newly trained model expects.

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoicePdf);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
            }

            RecognizedFormCollection forms = await operation.WaitForCompletionAsync(PollingInterval);
            var fields = forms.Single().Fields;

            // Verify that we got back at least one null field to make sure we hit the code path we want to test.

            Assert.IsTrue(fields.Any(kvp => kvp.Value == null));
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis based on a custom labeled model.
        /// </summary>
        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task StartRecognizeCustomFormsWithoutLabels(bool useStream, bool includeFieldElements)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions { IncludeFieldElements = includeFieldElements };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.GreaterOrEqual(operation.Value.Count, 1);

            RecognizedForm form = operation.Value.Single();

            ValidateModelWithNoLabelsForm(
                form,
                trainedModel.ModelId,
                includeFieldElements: includeFieldElements,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            //testing that we shuffle things around correctly so checking only once per property

            Assert.AreEqual("form-0", form.FormType);
            Assert.IsFalse(form.FormTypeConfidence.HasValue);
            Assert.AreEqual(1, form.Pages.Count);
            Assert.AreEqual(2200, form.Pages[0].Height);
            Assert.AreEqual(1, form.Pages[0].PageNumber);
            Assert.AreEqual(LengthUnit.Pixel, form.Pages[0].Unit);
            Assert.AreEqual(1700, form.Pages[0].Width);

            Assert.IsNotNull(form.Fields);
            var name = "field-0";
            Assert.IsNotNull(form.Fields[name]);
            Assert.IsNotNull(form.Fields[name].LabelData.Text);
            Assert.AreEqual(FieldValueType.String, form.Fields[name].Value.ValueType);

            // Disable this verification for now.
            // Issue https://github.com/Azure/azure-sdk-for-net/issues/15075
            // Assert.AreEqual("Hero Limited", form.Fields[name].LabelData.Text);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/12319")]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false, ContainerType.MultipageFiles);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(2, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateModelWithNoLabelsForm(
                    recognizedForm,
                    trainedModel.ModelId,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                var expectedLabelData = formIndex == 0 ? "__Address__1" : "Company Name:";
                var expectedValueData = formIndex == 0 ? "Contoso Ltd. 2345 Dogwood Lane Birch, Kansas 98123" : "Southridge Video";

                FormField fieldInPage = recognizedForm.Fields.Values.Where(field => field.LabelData.Text.Contains(expectedLabelData)).FirstOrDefault();
                Assert.IsNotNull(fieldInPage);
                Assert.IsNotNull(fieldInPage.ValueData);
                Assert.AreEqual(expectedValueData, fieldInPage.ValueData.Text);
            }
        }

        [Test]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            var blankForm = recognizedForms.Single();

            ValidateModelWithNoLabelsForm(
                blankForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/12319")]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipageFormWithBlankPage(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipageBlank);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(3, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateModelWithNoLabelsForm(
                    recognizedForm,
                    trainedModel.ModelId,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                if (formIndex == 0 || formIndex == 2)
                {
                    var expectedValueData = formIndex == 0 ? "300.00" : "3000.00";

                    FormField fieldInPage = recognizedForm.Fields.Values.Where(field => field.LabelData.Text.Contains("Subtotal:")).FirstOrDefault();
                    Assert.IsNotNull(fieldInPage);
                    Assert.IsNotNull(fieldInPage.ValueData);
                    Assert.AreEqual(expectedValueData, fieldInPage.ValueData.Text);
                }
            }

            var blankForm = recognizedForms[1];

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsThrowsForDamagedFile(bool useTrainingLabels)
        {
            var client = CreateFormRecognizerClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels);
            var operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync(PollingInterval));

            Assert.AreEqual("2005", ex.ErrorCode);

            Assert.True(operation.HasCompleted);
            Assert.False(operation.HasValue);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsFromUriThrowsForNonExistingContent(bool useTrainingLabels)
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels);

            var operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, invalidUri);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync(PollingInterval));

            Assert.AreEqual("2003", ex.ErrorCode);
            Assert.True(operation.HasCompleted);
            Assert.False(operation.HasValue);
        }

        #endregion

        private void ValidateFormPage(FormPage formPage, bool includeFieldElements, int expectedPageNumber)
        {
            Assert.AreEqual(expectedPageNumber, formPage.PageNumber);

            Assert.Greater(formPage.Width, 0.0);
            Assert.Greater(formPage.Height, 0.0);

            Assert.That(formPage.TextAngle, Is.GreaterThan(-180.0).Within(0.01));
            Assert.That(formPage.TextAngle, Is.LessThanOrEqualTo(180.0).Within(0.01));

            Assert.NotNull(formPage.Lines);

            if (!includeFieldElements)
            {
                Assert.AreEqual(0, formPage.Lines.Count);
            }

            foreach (var line in formPage.Lines)
            {
                Assert.AreEqual(expectedPageNumber, line.PageNumber);
                Assert.NotNull(line.BoundingBox.Points);
                Assert.AreEqual(4, line.BoundingBox.Points.Length);
                Assert.NotNull(line.Text);

                Assert.NotNull(line.Words);
                Assert.Greater(line.Words.Count, 0);

                foreach (var word in line.Words)
                {
                    Assert.AreEqual(expectedPageNumber, word.PageNumber);
                    Assert.NotNull(word.BoundingBox.Points);
                    Assert.AreEqual(4, word.BoundingBox.Points.Length);
                    Assert.NotNull(word.Text);

                    Assert.That(word.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                    Assert.That(word.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
                }
            }

            Assert.NotNull(formPage.Tables);

            foreach (var table in formPage.Tables)
            {
                Assert.AreEqual(expectedPageNumber, table.PageNumber);
                Assert.Greater(table.ColumnCount, 0);
                Assert.Greater(table.RowCount, 0);
                // Currently not true for CustomForms. Issue https://github.com/Azure/azure-sdk-for-net/issues/16827
                // Assert.AreEqual(4, table.BoundingBox.Points.Count());

                Assert.NotNull(table.Cells);

                foreach (var cell in table.Cells)
                {
                    Assert.AreEqual(expectedPageNumber, cell.PageNumber);
                    Assert.NotNull(cell.BoundingBox.Points);
                    Assert.AreEqual(4, cell.BoundingBox.Points.Length);

                    Assert.GreaterOrEqual(cell.ColumnIndex, 0);
                    Assert.GreaterOrEqual(cell.RowIndex, 0);
                    Assert.GreaterOrEqual(cell.ColumnSpan, 1);
                    Assert.GreaterOrEqual(cell.RowSpan, 1);

                    Assert.That(cell.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                    Assert.That(cell.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

                    Assert.NotNull(cell.Text);
                    Assert.NotNull(cell.FieldElements);

                    if (!includeFieldElements)
                    {
                        Assert.AreEqual(0, cell.FieldElements.Count);
                    }

                    foreach (var element in cell.FieldElements)
                    {
                        Assert.AreEqual(expectedPageNumber, element.PageNumber);
                        Assert.NotNull(element.BoundingBox.Points);
                        Assert.AreEqual(4, element.BoundingBox.Points.Length);

                        Assert.NotNull(element.Text);
                        Assert.True(element is FormWord || element is FormLine);
                    }
                }
            }

            Assert.NotNull(formPage.SelectionMarks);

            foreach (var selectionMark in formPage.SelectionMarks)
            {
                Assert.AreEqual(expectedPageNumber, selectionMark.PageNumber);
                Assert.NotNull(selectionMark.BoundingBox.Points);
                Assert.AreEqual(4, selectionMark.BoundingBox.Points.Length);
                Assert.IsNull(selectionMark.Text);
                Assert.NotNull(selectionMark.State);
                Assert.That(selectionMark.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(selectionMark.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }
        }

        private void ValidatePrebuiltForm(RecognizedForm recognizedForm, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(recognizedForm.FormType);
            Assert.IsTrue(recognizedForm.FormTypeConfidence.HasValue);
            Assert.AreEqual(1.0f, recognizedForm.FormTypeConfidence.Value);
            Assert.IsNull(recognizedForm.ModelId);

            ValidateRecognizedForm(recognizedForm, includeFieldElements, expectedFirstPageNumber, expectedLastPageNumber);
        }

        private void ValidateModelWithNoLabelsForm(RecognizedForm recognizedForm, string modelId, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(recognizedForm.FormType);
            Assert.IsFalse(recognizedForm.FormTypeConfidence.HasValue);
            Assert.IsNotNull(recognizedForm.ModelId);
            Assert.AreEqual(modelId, recognizedForm.ModelId);

            ValidateRecognizedForm(recognizedForm, includeFieldElements, expectedFirstPageNumber, expectedLastPageNumber);
        }

        private void ValidateModelWithLabelsForm(RecognizedForm recognizedForm, string modelId, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber, bool isComposedModel)
        {
            Assert.NotNull(recognizedForm.FormType);
            Assert.IsTrue(recognizedForm.FormTypeConfidence.HasValue);
            Assert.IsNotNull(recognizedForm.ModelId);

            if (!isComposedModel)
                Assert.AreEqual(modelId, recognizedForm.ModelId);
            else
                Assert.AreNotEqual(modelId, recognizedForm.ModelId);

            ValidateRecognizedForm(recognizedForm, includeFieldElements, expectedFirstPageNumber, expectedLastPageNumber);
        }

        private void ValidateRecognizedForm(RecognizedForm recognizedForm, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.AreEqual(expectedFirstPageNumber, recognizedForm.PageRange.FirstPageNumber);
            Assert.AreEqual(expectedLastPageNumber, recognizedForm.PageRange.LastPageNumber);

            Assert.NotNull(recognizedForm.Pages);
            Assert.AreEqual(expectedLastPageNumber - expectedFirstPageNumber + 1, recognizedForm.Pages.Count);

            int expectedPageNumber = expectedFirstPageNumber;

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                var formPage = recognizedForm.Pages[pageIndex];
                ValidateFormPage(formPage, includeFieldElements, expectedPageNumber);

                expectedPageNumber++;
            }

            Assert.NotNull(recognizedForm.Fields);

            foreach (var field in recognizedForm.Fields.Values)
            {
                if (field == null)
                {
                    continue;
                }

                Assert.NotNull(field.Name);

                Assert.That(field.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(field.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

                ValidateFieldData(field.LabelData, includeFieldElements);
                ValidateFieldData(field.ValueData, includeFieldElements);
            }
        }

        private void ValidateFieldData(FieldData fieldData, bool includeFieldElements)
        {
            if (fieldData == null)
            {
                return;
            }

            Assert.Greater(fieldData.PageNumber, 0);

            Assert.NotNull(fieldData.BoundingBox.Points);

            if (fieldData.BoundingBox.Points.Length != 0)
            {
                Assert.AreEqual(4, fieldData.BoundingBox.Points.Length);
            }

            Assert.NotNull(fieldData.Text);
            Assert.NotNull(fieldData.FieldElements);

            if (!includeFieldElements)
            {
                Assert.AreEqual(0, fieldData.FieldElements.Count);
            }
        }
    }
}
