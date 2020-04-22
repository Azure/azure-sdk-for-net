// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [LiveOnly]
    public class FormRecognizerClientLiveTests : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        private readonly Uri _containerUri;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerClientLiveTests(bool isAsync) : base(isAsync)
        {
            _containerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            _endpoint = new Uri(TestEnvironment.Endpoint);
            _credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            Assert.NotNull(_endpoint);
            Assert.NotNull(_credential);
        }

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedClient()
        {
            return InstrumentClient(new FormRecognizerClient(_endpoint, _credential));
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
            var client = CreateInstrumentedClient();
            Operation<IReadOnlyList<FormPage>> operation;

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.RetrieveInvoicePath(1, ContentType.Pdf), FileMode.Open);
                operation = await client.StartRecognizeContentAsync(stream);
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

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeContentFromUriThrowsForNonExistingContent()
        {
            var client = CreateInstrumentedClient();
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
            var client = CreateInstrumentedClient();
            Operation<IReadOnlyList<RecognizedReceipt>> operation;

            if (useStream)
            {
                using var stream = new FileStream(FormRecognizerTestEnvironment.JpgReceiptPath, FileMode.Open);
                operation = await client.StartRecognizeReceiptsAsync(stream);
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

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        public void StartRecognizeReceiptsFromUriThrowsForNonExistingContent()
        {
            var client = CreateInstrumentedClient();
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
            var client = CreateInstrumentedClient();
            RecognizeCustomFormsOperation operation;

            string modelId = await GetModelIdAsync(useLabels: true);

            try
            {
                if (useStream)
                {
                    using var stream = new FileStream(FormRecognizerTestEnvironment.FormPath, FileMode.Open);
                    operation = await client.StartRecognizeCustomFormsAsync(modelId, stream);
                }
                else
                {
                    var uri = new Uri(FormRecognizerTestEnvironment.FormUri);
                    operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, uri);
                }

                await operation.WaitForCompletionAsync();

                Assert.IsTrue(operation.HasValue);
                Assert.GreaterOrEqual(operation.Value.Count, 1);

                RecognizedForm form = operation.Value.FirstOrDefault();

                //testing that we shuffle things around correctly so checking only once per property

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
                Assert.IsNotNull(form.Fields[name].Confidence);
                Assert.AreEqual(FieldValueType.StringType, form.Fields[name].Value.Type);
                Assert.AreEqual("948284", form.Fields[name].ValueText.Text);
            }
            finally
            {
                DeleteModel(modelId);
            }

        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomForms(bool useStream)
        {
            var client = CreateInstrumentedClient();
            RecognizeCustomFormsOperation operation;

            string modelId = await GetModelIdAsync();

            try
            {
                if (useStream)
                {
                    using var stream = new FileStream(FormRecognizerTestEnvironment.FormPath, FileMode.Open);
                    operation = await client.StartRecognizeCustomFormsAsync(modelId, stream);
                }
                else
                {
                    var uri = new Uri(FormRecognizerTestEnvironment.FormUri);
                    operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, uri);
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
                Assert.IsNotNull(form.Fields[name].Confidence);
                Assert.IsNotNull(form.Fields[name].LabelText.Text);
                Assert.AreEqual(FieldValueType.StringType, form.Fields[name].Value.Type);
                Assert.AreEqual("Hero Limited", form.Fields[name].LabelText.Text);
            }
            finally
            {
                DeleteModel(modelId);
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsFromUriThrowsForNonExistingContent(bool useLabels)
        {
            var client = CreateInstrumentedClient();
            var invalidUri = new Uri("https://idont.ex.ist");
            var modelId = await GetModelIdAsync(useLabels);

            try
            {
                var operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, invalidUri);
                RequestFailedException capturedException = default;

                try
                {
                    await operation.WaitForCompletionAsync();
                }
                catch (RequestFailedException ex)
                {
                    capturedException = ex;
                }

                string expectedErrorCode = useLabels ? "3003" : "2003";

                Assert.NotNull(capturedException);
                Assert.AreEqual(expectedErrorCode, capturedException.ErrorCode);

                Assert.True(operation.HasCompleted);
                Assert.True(operation.HasValue);
                Assert.AreEqual(0, operation.Value.Count);
            }
            finally
            {
                DeleteModel(modelId);
            }
        }

        [Test]
        public void CreateFormTrainingClientFromFormRecognizerClient()
        {
            FormRecognizerClient client = CreateInstrumentedClient();
            FormTrainingClient trainingClient = client.GetFormTrainingClient();
            Assert.IsNotNull(trainingClient);
        }

        /// <summary>
        ///  For testing purposes, we are training our models using the client library functionalities.
        ///  Please note that models can also be trained using a graphical user interface
        ///  such as the Form Recognizer Labeling Tool found here:
        ///  <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/label-tool"/>.
        /// </summary>
        private async Task<string> GetModelIdAsync(bool useLabels = false)
        {
            FormTrainingClient trainingClient = InstrumentClient(new FormTrainingClient(_endpoint, _credential));
            TrainingOperation trainedModel = await trainingClient.StartTrainingAsync(_containerUri, useLabels);
            await trainedModel.WaitForCompletionAsync();
            Assert.IsTrue(trainedModel.HasValue);

            return trainedModel.Value.ModelId;
        }

        private async void DeleteModel(string modelId)
        {
            FormTrainingClient trainingClient = InstrumentClient(new FormTrainingClient(_endpoint, _credential));
            await trainingClient.DeleteModelAsync(modelId).ConfigureAwait(false);
        }
    }
}
