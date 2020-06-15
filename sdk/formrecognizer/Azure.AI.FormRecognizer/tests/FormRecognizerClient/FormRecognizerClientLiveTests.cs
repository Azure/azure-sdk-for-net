// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
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
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedFormRecognizerClient(bool useTokenCredential = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = Recording.InstrumentClientOptions(new FormRecognizerClientOptions());
            FormRecognizerClient client;

            if (useTokenCredential)
            {
                client = new FormRecognizerClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
                client = new FormRecognizerClient(endpoint, credential, options);
            }

            return InstrumentClient(client);
        }

        [Test]
        public async Task FormRecognizerClientCanAuthenticateWithTokenCredential()
        {
            var client = CreateInstrumentedFormRecognizerClient(useTokenCredential: true);
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
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeContentPopulatesFormPage(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
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
        [TestCase(false)]
        public async Task StartRecognizeContentCanParseMultipageForm(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
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

                ValidateFormPage(formPage, includeTextContent: true, expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = formPage.Lines[3];
                var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                Assert.AreEqual(expectedText, sampleLine.Text);
            }
        }

        [Test]
        public async Task StartRecognizeContentCanParseMultipageFormWithBlankPage()
        {
            var client = CreateInstrumentedFormRecognizerClient();
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

                ValidateFormPage(formPage, includeTextContent: true, expectedPageNumber: pageIndex + 1);

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

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single().RecognizedForm;

            Assert.NotNull(form);

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
            Assert.AreEqual("123-456-7890", form.Fields["MerchantPhoneNumber"].ValueText.Text);

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
        public async Task StartRecognizeReceiptsCanParseMultipageForm(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
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

            RecognizedReceiptCollection recognizedReceipts = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, recognizedReceipts.Count);

            for (int receiptIndex = 0; receiptIndex < recognizedReceipts.Count; receiptIndex++)
            {
                var recognizedReceipt = recognizedReceipts[receiptIndex];
                var expectedPageNumber = receiptIndex + 1;

                Assert.NotNull(recognizedReceipt.RecognizedForm);

                ValidateRecognizedForm(recognizedReceipt.RecognizedForm, includeTextContent: true,
                    expectedFirstPageNumber: expectedPageNumber, expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleField = recognizedReceipt.RecognizedForm.Fields["MerchantName"];
                var expectedValueText = receiptIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                Assert.IsNotNull(sampleField.ValueText);
                Assert.AreEqual(expectedValueText, sampleField.ValueText.Text);
            }
        }

        [Test]
        public async Task StartRecognizeReceiptsCanParseMultipageFormWithBlankPage()
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
            RecognizeReceiptsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeReceiptsAsync(stream, options);
            }

            RecognizedReceiptCollection recognizedReceipts = await operation.WaitForCompletionAsync();

            Assert.AreEqual(3, recognizedReceipts.Count);

            for (int receiptIndex = 0; receiptIndex < recognizedReceipts.Count; receiptIndex++)
            {
                var recognizedReceipt = recognizedReceipts[receiptIndex];
                var expectedPageNumber = receiptIndex + 1;

                Assert.NotNull(recognizedReceipt.RecognizedForm);

                ValidateRecognizedForm(recognizedReceipt.RecognizedForm, includeTextContent: true,
                    expectedFirstPageNumber: expectedPageNumber, expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                if (receiptIndex == 0 || receiptIndex == 2)
                {
                    var sampleField = recognizedReceipt.RecognizedForm.Fields["MerchantName"];
                    var expectedValueText = receiptIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.IsNotNull(sampleField.ValueText);
                    Assert.AreEqual(expectedValueText, sampleField.ValueText.Text);
                }
            }

            var blankForm = recognizedReceipts[1].RecognizedForm;

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
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
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
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
            Assert.AreEqual(FieldValueType.String, form.Fields[name].Value.Type);
            Assert.AreEqual("948284", form.Fields[name].ValueText.Text);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipageForm(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

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

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateRecognizedForm(recognizedForm, includeTextContent: true,
                expectedFirstPageNumber: 1, expectedLastPageNumber: 2);

            // Add fields assertions when https://github.com/Azure/azure-sdk-for-net/issues/12139
            // is solved.

            // Basic sanity test to make sure pages are ordered correctly.

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                var formPage = recognizedForm.Pages[pageIndex];
                var sampleLine = formPage.Lines[3];
                var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                Assert.AreEqual(expectedText, sampleLine.Text);
            }
        }

        [Test]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseBlankPage()
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateRecognizedForm(recognizedForm, includeTextContent: true,
                expectedFirstPageNumber: 1, expectedLastPageNumber: 1);

            var blankPage = recognizedForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        [Test]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipageFormWithBlankPage()
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateRecognizedForm(recognizedForm, includeTextContent: true,
                expectedFirstPageNumber: 1, expectedLastPageNumber: 3);

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
            var client = CreateInstrumentedFormRecognizerClient();
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

            RecognizedFormCollection forms = await operation.WaitForCompletionAsync();
            var fields = forms.Single().Fields;

            // Verify that we got back at least one null field to make sure we hit the code path we want to test.

            Assert.IsTrue(fields.Any(kvp => kvp.Value == null));
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
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
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
            Assert.AreEqual(FieldValueType.String, form.Fields[name].Value.Type);
            Assert.AreEqual("Hero Limited", form.Fields[name].LabelText.Text);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false, Ignore = "Service returning 'Unsupported media type' error.")]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipageForm(bool useStream)
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

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

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateRecognizedForm(recognizedForm, includeTextContent: true,
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

        [Test]
        [Ignore("Service bug: information about the blank page is not being returned.")]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipageFormWithBlankPage()
        {
            var client = CreateInstrumentedFormRecognizerClient();
            var options = new RecognizeOptions() { IncludeTextContent = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.AreEqual(3, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateRecognizedForm(recognizedForm, includeTextContent: true,
                    expectedFirstPageNumber: expectedPageNumber, expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                if (formIndex == 0 || formIndex == 2)
                {
                    var sampleField = recognizedForm.Fields["field-0"];
                    var expectedValueText = formIndex == 0 ? "300.00" : "3000.00";

                    Assert.IsNotNull(sampleField.LabelText);
                    Assert.AreEqual("Subtotal:", sampleField.LabelText.Text);
                    Assert.IsNotNull(sampleField.ValueText);
                    Assert.AreEqual(expectedValueText, sampleField.ValueText.Text);
                }
            }

            var blankForm = recognizedForms[1];

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        [TestCase(true, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/12319")]
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
            Assert.False(operation.HasValue);
            Assert.Throws<RequestFailedException>(() => operation.Value.GetType());
        }

        private void ValidateFormPage(FormPage formPage, bool includeTextContent, int expectedPageNumber)
        {
            Assert.AreEqual(expectedPageNumber, formPage.PageNumber);

            Assert.Greater(formPage.Width, 0.0);
            Assert.Greater(formPage.Height, 0.0);

            Assert.That(formPage.TextAngle, Is.GreaterThan(-180.0).Within(0.01));
            Assert.That(formPage.TextAngle, Is.LessThanOrEqualTo(180.0).Within(0.01));

            Assert.NotNull(formPage.Lines);

            if (!includeTextContent)
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
                if (field == null)
                {
                    continue;
                }

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
