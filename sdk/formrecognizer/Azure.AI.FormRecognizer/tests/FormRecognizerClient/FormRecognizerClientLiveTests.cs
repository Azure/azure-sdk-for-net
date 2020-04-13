// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
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
    public class FormRecognizerClientLiveTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerClientLiveTests(bool isAsync) : base(isAsync)
        {
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
                using var stream = new FileStream(TestEnvironment.RetrieveInvoicePath(1), FileMode.Open);
                operation = await client.StartRecognizeContentAsync(stream, ContentType.Jpeg);
            }
            else
            {
                var uri = new Uri(TestEnvironment.RetrieveInvoiceUri(1));
                operation = await client.StartRecognizeContentFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var formPage = operation.Value.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the form. We are not testing the service here, but the SDK.

            Assert.AreEqual(1, formPage.PageNumber);
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
                Assert.Greater(line.Words.Count, 0, $"There should be at least one word in line {lineIndex}.");
                Assert.AreEqual(4, line.BoundingBox.Points.Count(), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
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

                Assert.GreaterOrEqual(cell.Confidence, 0, $"Cell with text {cell.Text} should have confidence greater than or equal to zero.");
                Assert.LessOrEqual(cell.RowIndex, 1, $"Cell with text {cell.Text} should have confidence less than or equal to one.");

                Assert.Greater(cell.TextContent.Count, 0, $"Cell with text {cell.Text} should have text content.");
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform operations.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeReceiptsPopulatesExtractedReceipt(bool useStream)
        {
            var client = CreateInstrumentedClient();
            Operation<IReadOnlyList<ExtractedReceipt>> operation;

            if (useStream)
            {
                using var stream = new FileStream(TestEnvironment.ReceiptPath, FileMode.Open);
                operation = await client.StartRecognizeReceiptsAsync(stream, ContentType.Jpeg);
            }
            else
            {
                var uri = new Uri(TestEnvironment.ReceiptUri);
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var receipt = operation.Value.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the receipt. We are not testing the service here, but the SDK.

            Assert.AreEqual(1, receipt.StartPageNumber);
            Assert.AreEqual(1, receipt.EndPageNumber);

            Assert.AreEqual("Contoso Contoso", receipt.MerchantName);
            Assert.AreEqual("123 Main Street Redmond, WA 98052", receipt.MerchantAddress);
            Assert.AreEqual("123-456-7890", receipt.MerchantPhoneNumber);

            Assert.IsNotNull(receipt.TransactionDate);
            Assert.IsNotNull(receipt.TransactionTime);

            var date = receipt.TransactionDate.Value;
            var time = receipt.TransactionTime.Value;

            Assert.AreEqual(10, date.Day);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(2019, date.Year);

            Assert.AreEqual(13, time.Hour);
            Assert.AreEqual(59, time.Minute);
            Assert.AreEqual(0, time.Second);

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

                Assert.AreEqual(expectedItem.Quantity, receiptItem.Quantity, $"{receiptItem.Quantity} mismatch in item with index {itemIndex}.");
                Assert.AreEqual(expectedItem.Name, receiptItem.Name, $"{receiptItem.Name} mismatch in item with index {itemIndex}.");
                Assert.That(receiptItem.Price, Is.EqualTo(expectedItem.Price).Within(0.0001), $"{receiptItem.Price} mismatch in item with index {itemIndex}.");
                Assert.That(receiptItem.TotalPrice, Is.EqualTo(expectedItem.TotalPrice).Within(0.0001), $"{receiptItem.TotalPrice} mismatch in item with index {itemIndex}.");
            }

            Assert.That(receipt.Subtotal, Is.EqualTo(1098.99).Within(0.0001));
            Assert.That(receipt.Tax, Is.EqualTo(104.40).Within(0.0001));
            Assert.IsNull(receipt.Tip);
            Assert.That(receipt.Total, Is.EqualTo(1203.39).Within(0.0001));
        }

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateInstrumentedClient()
        {
            var endpointEnvironmentVariable = Environment.GetEnvironmentVariable(TestEnvironment.EndpointEnvironmentVariableName);
            var keyEnvironmentVariable = Environment.GetEnvironmentVariable(TestEnvironment.ApiKeyEnvironmentVariableName);

            Assert.NotNull(endpointEnvironmentVariable);
            Assert.NotNull(keyEnvironmentVariable);

            var endpoint = new Uri(endpointEnvironmentVariable);
            var credential = new AzureKeyCredential(keyEnvironmentVariable);
            var client = new FormRecognizerClient(endpoint, credential);

            return InstrumentClient(client);
        }
    }
}
