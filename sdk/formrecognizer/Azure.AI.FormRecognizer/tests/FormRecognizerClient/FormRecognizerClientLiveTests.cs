﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public FormRecognizerClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedFormRecognizerClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var options = Recording.InstrumentClientOptions(new FormRecognizerClientOptions());
            var client = new FormRecognizerClient(endpoint, credential, options);

            return InstrumentClient(client);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform operations.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeContentPopulatesFormPage(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            RecognizeContentOperation operation;

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.RetrieveInvoicePath(1, ContentType.Pdf), FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeContentAsync(stream);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.RetrieveInvoiceUri(1));
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

                Assert.NotNull(line.Text, $"Text should not be null in line {lineIndex}. ");
                Assert.AreEqual(4, line.BoundingBox.Points.Count(), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
                Assert.Greater(line.Words.Count, 0, $"There should be at least one word in line {lineIndex}.");
                foreach (var item in line.Words)
                {
                    Assert.GreaterOrEqual(item.Confidence, 0);
                }
            }

            var table = formPage.Tables.Single();

            Assert.AreEqual(2, table.RowCount);
            Assert.AreEqual(6, table.ColumnCount);

            var cells = table.Cells.ToList();

            Assert.AreEqual(10, cells.Count);

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

                // There's a single cell in the table (row = 1, column = 3) that has a column span of 2.

                var expectedColumnSpan = (cell.RowIndex == 1 && cell.ColumnIndex == 3) ? 2 : 1;

                Assert.AreEqual(1, cell.RowSpan, $"Cell with text {cell.Text} should have a row span of 1.");
                Assert.AreEqual(expectedColumnSpan, cell.ColumnSpan, $"Cell with text {cell.Text} should have a column span of {expectedColumnSpan}.");

                Assert.AreEqual(expectedText[cell.RowIndex, cell.ColumnIndex], cell.Text);

                Assert.IsFalse(cell.IsFooter, $"Cell with text {cell.Text} should not have been classified as footer.");
                Assert.IsFalse(cell.IsHeader, $"Cell with text {cell.Text} should not have been classified as header.");

                Assert.GreaterOrEqual(cell.Confidence, 0, $"Cell with text {cell.Text} should have confidence greater or equal to zero.");
                Assert.LessOrEqual(cell.RowIndex, 1, $"Cell with text {cell.Text} should have a row index less than or equal to one.");

                Assert.Greater(cell.TextContent.Count, 0, $"Cell with text {cell.Text} should have text content.");
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false, Ignore = "File has not been uploaded to GitHub yet.")]
        public async Task StartRecognizeContentCanParseMultipagedForm(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var filename = "multipage_invoice_noblank.pdf";
            RecognizeContentOperation operation;

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.CreatePath(filename), FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeContentAsync(stream);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.CreateUri(filename));
                operation = await client.StartRecognizeContentFromUriAsync(uri);
            }

            FormPageCollection formPages = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, formPages.Count);

            var line0 = formPages[0].Lines;
            var line1 = formPages[1].Lines;

            for (int pageIndex = 0; pageIndex < formPages.Count; pageIndex++)
            {
                var formPage = formPages[pageIndex];

                ValidateFormPage(formPage, includeTextContent: true, expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = formPage.Lines[3];
                var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                Assert.AreEqual(expectedText, sampleLine.Text);
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeContentFromUriThrowsForNonExistingContent()
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentFromUriAsync(invalidUri));
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis of receipts.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeReceiptsPopulatesExtractedReceipt(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            RecognizeReceiptsOperation operation;

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.JpgReceiptPath, FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeReceiptsAsync(stream);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.JpgReceiptUri);
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri, default);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var receipt = operation.Value.Single().AsUSReceipt();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the receipt. We are not testing the service here, but the SDK.

            Assert.AreEqual(USReceiptType.Itemized, receipt.ReceiptType);
            Assert.That(receipt.ReceiptTypeConfidence, Is.EqualTo(0.66).Within(0.01));

            Assert.AreEqual(1, receipt.RecognizedForm.PageRange.FirstPageNumber);
            Assert.AreEqual(1, receipt.RecognizedForm.PageRange.LastPageNumber);

            Assert.AreEqual("Contoso Contoso", (string)receipt.MerchantName);
            Assert.AreEqual("123 Main Street Redmond, WA 98052", (string)receipt.MerchantAddress);
            Assert.AreEqual("123-456-7890", (string)receipt.MerchantPhoneNumber.ValueText);

            Assert.IsNotNull(receipt.TransactionDate);
            Assert.IsNotNull(receipt.TransactionTime);

            var date = receipt.TransactionDate.Value;
            var time = receipt.TransactionTime.Value;

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

            Assert.AreEqual(expectedItems.Count, receipt.Items.Count);

            for (var itemIndex = 0; itemIndex < receipt.Items.Count; itemIndex++)
            {
                var receiptItem = receipt.Items[itemIndex];
                var expectedItem = expectedItems[itemIndex];

                Assert.AreEqual(expectedItem.Quantity, receiptItem.Quantity == null? null : (float?)receiptItem.Quantity, $"{receiptItem.Quantity} mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Name, (string)receiptItem.Name, $"{receiptItem.Name} mismatch in item with index {itemIndex}.");
                Assert.That(receiptItem.Price == null? null : (float?)receiptItem.Price, Is.EqualTo(expectedItem.Price).Within(0.0001), $"{receiptItem.Price} mismatch in item with index {itemIndex}.");
                Assert.That(receiptItem.TotalPrice == null? null: (float?)receiptItem.TotalPrice, Is.EqualTo(expectedItem.TotalPrice).Within(0.0001), $"{receiptItem.TotalPrice} mismatch in item with index {itemIndex}.");
            }

            Assert.That((float?)receipt.Subtotal, Is.EqualTo(1098.99).Within(0.0001));
            Assert.That((float?)receipt.Tax, Is.EqualTo(104.40).Within(0.0001));
            Assert.IsNull(receipt.Tip);
            Assert.That((float?)receipt.Total, Is.EqualTo(1203.39).Within(0.0001));
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true, Ignore = "File has not been uploaded to GitHub yet.")]
        [TestCase(false, false, Ignore = "File has not been uploaded to GitHub yet.")]
        public async Task StartRecognizeReceiptsCanParseMultipagedForm(bool useStream, bool includeTextContent)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = includeTextContent };
            var filename = "multipage_invoice_noblank.pdf";
            RecognizeReceiptsOperation operation;

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.CreatePath(filename), FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeReceiptsAsync(stream, options);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.CreateUri(filename));
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri, options);
            }

            RecognizedReceiptCollection recognizedReceipts = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, recognizedReceipts.Count);

            for (int receiptIndex = 0; receiptIndex < recognizedReceipts.Count; receiptIndex++)
            {
                var recognizedReceipt = recognizedReceipts[receiptIndex];
                var expectedPageNumber = receiptIndex + 1;

                Assert.AreEqual("en-US", recognizedReceipt.ReceiptLocale);
                Assert.NotNull(recognizedReceipt.RecognizedForm);

                ValidateRecognizedForm(recognizedReceipt.RecognizedForm, includeTextContent,
                    expectedFirstPageNumber: expectedPageNumber, expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleField = recognizedReceipt.RecognizedForm.Fields["MerchantName"];
                var expectedValueText = receiptIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                Assert.IsNotNull(sampleField.ValueText);
                Assert.AreEqual(expectedValueText, sampleField.ValueText.Text);
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsFromUriThrowsForNonExistingContent()
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeReceiptsFromUriAsync(invalidUri));
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis based on a custom labeled model.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabels(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.FormPath, FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.FormUri);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.GreaterOrEqual(operation.Value.Count, 1);

            RecognizedForm form = operation.Value.FirstOrDefault();

            // Testing that we shuffle things around correctly so checking only once per property.

            Assert.AreEqual("custom:form", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);
            Assert.AreEqual(1, form.Pages.Count);
            Assert.AreEqual(2200, form.Pages[0].Height);
            Assert.AreEqual(1, form.Pages[0].PageNumber);
            Assert.AreEqual(LengthUnit.Pixel, form.Pages[0].Unit);
            Assert.AreEqual(1700, form.Pages[0].Width);

            Assert.IsNotNull(form.Fields);
            var name = "PurchaseOrderNumber";
            Assert.IsNotNull(form.Fields[name]);
            Assert.AreEqual(FieldValueType.StringType, form.Fields[name].Value.Type);
            Assert.AreEqual("948284", form.Fields[name].ValueText.Text);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        [Ignore("Blocked by #11821, since some fields cannot be parsed.")]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipagedForms(bool useStream, bool includeTextContent)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = includeTextContent };
            var filename = "multipage_invoice_noblank.pdf";
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.CreatePath(filename), FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.CreateUri(filename));
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateRecognizedForm(recognizedForm, includeTextContent,
                expectedFirstPageNumber: 1, expectedLastPageNumber: 2);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                // Basic sanity test to make sure pages are ordered correctly.
                // TODO: implement sanity check once #11821 is solved.
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis based on a custom labeled model.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithoutLabels(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.FormPath, FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.FormUri);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.GreaterOrEqual(operation.Value.Count, 1);

            RecognizedForm form = operation.Value.FirstOrDefault();

            //testing that we shuffle things around correctly so checking only once per property

            Assert.AreEqual("form-0", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);
            Assert.AreEqual(1, form.Pages.Count);
            Assert.AreEqual(2200, form.Pages[0].Height);
            Assert.AreEqual(1, form.Pages[0].PageNumber);
            Assert.AreEqual(LengthUnit.Pixel, form.Pages[0].Unit);
            Assert.AreEqual(1700, form.Pages[0].Width);

            Assert.IsNotNull(form.Fields);
            var name = "field-0";
            Assert.IsNotNull(form.Fields[name]);
            Assert.IsNotNull(form.Fields[name].LabelText.Text);
            Assert.AreEqual(FieldValueType.StringType, form.Fields[name].Value.Type);
            Assert.AreEqual("Hero Limited", form.Fields[name].LabelText.Text);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true, Ignore = "File has not been uploaded to GitHub yet.")]
        [TestCase(false, false, Ignore = "File has not been uploaded to GitHub yet.")]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipagedForms(bool useStream, bool includeTextContent)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = includeTextContent };
            var filename = "multipage_invoice_noblank.pdf";
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.CreatePath(filename), FileMode.Open);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = new Uri(FormRecognizerTestEnvironment.CreateUri(filename));
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateRecognizedForm(recognizedForm, includeTextContent,
                    expectedFirstPageNumber: expectedPageNumber, expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleField = recognizedForm.Fields["field-0"];
                var expectedValueText = formIndex == 0 ? "300.00" : "3000.00";

                Assert.IsNotNull(sampleField.LabelText);
                Assert.AreEqual("Subtotal:", sampleField.LabelText.Text);
                Assert.IsNotNull(sampleField.ValueText);
                Assert.AreEqual(expectedValueText, sampleField.ValueText.Text);
            }
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
            var client = CreateInstrumentedFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels);

            var operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, invalidUri);
            RequestFailedException capturedException = default;

            try
            {
                await operation.WaitForCompletionAsync();
            }
            catch (RequestFailedException ex)
            {
                capturedException = ex;
            }

            string expectedErrorCode = useTrainingLabels ? "3003" : "2003";

            Assert.NotNull(capturedException);
            Assert.AreEqual(expectedErrorCode, capturedException.ErrorCode);

            Assert.True(operation.HasCompleted);
            Assert.True(operation.HasValue);
            Assert.AreEqual(0, operation.Value.Count);
        }

        private void ValidateFormPage(FormPage formPage, bool includeTextContent, int expectedPageNumber)
        {
            Assert.AreEqual(expectedPageNumber, formPage.PageNumber);

            Assert.Greater(formPage.Width, 0.0);
            Assert.Greater(formPage.Height, 0.0);

            Assert.That(formPage.TextAngle, Is.GreaterThan(-180.0).Within(0.01));
            Assert.That(formPage.TextAngle, Is.LessThanOrEqualTo(180.0).Within(0.01));

            Assert.NotNull(formPage.Lines);

            if (includeTextContent)
            {
                Assert.Greater(formPage.Lines.Count, 0);
            }
            else
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
                    Assert.NotNull(cell.TextContent);

                    if (includeTextContent)
                    {
                        Assert.Greater(cell.TextContent.Count, 0);
                    }
                    else
                    {
                        Assert.AreEqual(0, cell.TextContent.Count);
                    }

                    foreach (var content in cell.TextContent)
                    {
                        Assert.AreEqual(expectedPageNumber, content.PageNumber);
                        Assert.NotNull(content.BoundingBox.Points);
                        Assert.AreEqual(4, content.BoundingBox.Points.Length);

                        Assert.NotNull(content.Text);
                        Assert.True(content is FormWord || content is FormLine);
                    }
                }
            }
        }

        private void ValidateRecognizedForm(RecognizedForm recognizedForm, bool includeTextContent, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(recognizedForm.FormType);
            Assert.AreEqual(expectedFirstPageNumber, recognizedForm.PageRange.FirstPageNumber);
            Assert.AreEqual(expectedLastPageNumber, recognizedForm.PageRange.LastPageNumber);

            Assert.NotNull(recognizedForm.Pages);
            Assert.AreEqual(expectedLastPageNumber - expectedFirstPageNumber + 1, recognizedForm.Pages.Count);

            int expectedPageNumber = expectedFirstPageNumber;

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                var formPage = recognizedForm.Pages[pageIndex];
                ValidateFormPage(formPage, includeTextContent, expectedPageNumber);

                expectedPageNumber++;
            }

            Assert.NotNull(recognizedForm.Fields);

            foreach (var field in recognizedForm.Fields.Values)
            {
                Assert.NotNull(field.Name);

                Assert.That(field.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(field.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

                var labelText = field.LabelText;

                if (labelText != null)
                {
                    Assert.Greater(labelText.PageNumber, 0);

                    if (labelText.BoundingBox.Points != null)
                    {
                        Assert.AreEqual(4, labelText.BoundingBox.Points.Length);
                    }

                    Assert.NotNull(labelText.TextContent);

                    if (!includeTextContent)
                    {
                        Assert.AreEqual(0, labelText.TextContent.Count);
                    }
                }

                var valueText = field.ValueText;

                Assert.NotNull(valueText);

                if (valueText.BoundingBox.Points != null)
                {
                    Assert.AreEqual(4, valueText.BoundingBox.Points.Length);
                }

                Assert.NotNull(valueText.TextContent);

                if (!includeTextContent)
                {
                    Assert.AreEqual(0, valueText.TextContent.Count);
                }
            }
        }
    }
}
