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
    /// The suite of tests for the <see cref="FormLayoutClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [LiveOnly]
    public class FormLayoutClientLiveTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormLayoutClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormLayoutClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Verifies that the <see cref="FormLayoutClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform operations.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false, Ignore = "The Invoice_1.pdf hasn't been uploaded to GitHub yet.")]
        public async Task StartExtractLayoutsPopulatesExtractedLayoutPage(bool useStream)
        {
            var client = CreateInstrumentedClient();
            Operation<IReadOnlyList<ExtractedLayoutPage>> operation;

            if (useStream)
            {
                using var stream = new FileStream(TestEnvironment.RetrieveInvoicePath(1), FileMode.Open);
                operation = await client.StartExtractLayoutsAsync(stream, ContentType.Jpeg);
            }
            else
            {
                var uri = new Uri(TestEnvironment.RetrieveInvoiceUri(1));
                operation = await client.StartExtractLayoutsAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var layoutPage = operation.Value.Single();

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the form. We are not testing the service here, but the SDK.

            Assert.AreEqual(1, layoutPage.PageNumber);

            var rawPage = layoutPage.RawExtractedPage;

            Assert.AreEqual(1, rawPage.Page);
            Assert.AreEqual(LengthUnit.Inch, rawPage.Unit);
            Assert.AreEqual(8.5, rawPage.Width);
            Assert.AreEqual(11, rawPage.Height);
            Assert.AreEqual(0, rawPage.Angle);
            Assert.AreEqual(18, rawPage.Lines.Count);

            var lines = rawPage.Lines.ToList();

            for (var lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                var line = lines[lineIndex];

                Assert.NotNull(line.Text, $"Text should not be null in line {lineIndex}.");
                Assert.Greater(line.Words.Count, 0, $"There should be at least one word in line {lineIndex}.");
                Assert.AreEqual(4, line.BoundingBox.Points.Count(), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
            }

            var table = layoutPage.Tables.Single();

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

                Assert.Greater(cell.RawExtractedItems.Count, 0, $"Cell with text {cell.Text} should have at least one extracted item.");
            }
        }

        /// <summary>
        /// Creates a <see cref="FormLayoutClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormLayoutClient" />.</returns>
        private FormLayoutClient CreateInstrumentedClient()
        {
            var endpointEnvironmentVariable = Environment.GetEnvironmentVariable(TestEnvironment.EndpointEnvironmentVariableName);
            var keyEnvironmentVariable = Environment.GetEnvironmentVariable(TestEnvironment.ApiKeyEnvironmentVariableName);

            Assert.NotNull(endpointEnvironmentVariable);
            Assert.NotNull(keyEnvironmentVariable);

            var endpoint = new Uri(endpointEnvironmentVariable);
            var credential = new FormRecognizerApiKeyCredential(keyEnvironmentVariable);
            var client = new FormLayoutClient(endpoint, credential);

            return InstrumentClient(client);
        }
    }
}
