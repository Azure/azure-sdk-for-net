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

            Assert.That(formPage.Lines.Count, Is.GreaterThan(0));
            Assert.That(formPage.Lines[0].Text, Is.EqualTo("Contoso"));
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
            Assert.That(operation.HasValue, Is.True);

            var formPage = operation.Value.Single();

            Assert.Multiple(() =>
            {
                // The expected values are based on the values returned by the service, and not the actual
                // values present in the form. We are not testing the service here, but the SDK.

                Assert.That(formPage.Unit, Is.EqualTo(LengthUnit.Inch));
                Assert.That(formPage.Width, Is.EqualTo(8.5));
                Assert.That(formPage.Height, Is.EqualTo(11));
                Assert.That(formPage.TextAngle, Is.EqualTo(0));
                Assert.That(formPage.Lines, Has.Count.EqualTo(18));
            });

            var lines = formPage.Lines.ToList();

            for (var lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                var line = lines[lineIndex];

                Assert.Multiple(() =>
                {
                    Assert.That(line.Text, Is.Not.Null, $"Text should not be null in line {lineIndex}.");
                    Assert.That(line.BoundingBox.Points.Count(), Is.EqualTo(4), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
                    Assert.That(line.Words.Count, Is.GreaterThan(0), $"There should be at least one word in line {lineIndex}.");
                });
                foreach (var item in line.Words)
                {
                    Assert.That(item.Confidence, Is.GreaterThanOrEqualTo(0));
                }

                Assert.That(line.Appearance, Is.Not.Null);
                Assert.That(line.Appearance.Style, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(line.Appearance.Style.Name, Is.EqualTo(TextStyleName.Other));
                    Assert.That(line.Appearance.Style.Confidence, Is.GreaterThan(0f));
                });
            }

            var table = formPage.Tables.Single();

            Assert.Multiple(() =>
            {
                Assert.That(table.RowCount, Is.EqualTo(3));
                Assert.That(table.ColumnCount, Is.EqualTo(5));
                Assert.That(table.BoundingBox.Points.Count(), Is.EqualTo(4), $"There should be exactly 4 points in the table bounding box.");
            });

            var cells = table.Cells.ToList();

            Assert.That(cells, Has.Count.EqualTo(10));

            var expectedText = new string[2, 5]
            {
                { "Invoice Number", "Invoice Date", "Invoice Due Date", "Charges", "VAT ID" },
                { "34278587", "6/18/2017", "6/24/2017", "$56,651.49", "PT" }
            };

            foreach (var cell in cells)
            {
                Assert.That(cell.RowIndex, Is.GreaterThanOrEqualTo(0), $"Cell with text {cell.Text} should have row index greater than or equal to zero.");
                Assert.Multiple(() =>
                {
                    Assert.That(cell.RowIndex, Is.LessThan(table.RowCount), $"Cell with text {cell.Text} should have row index less than {table.RowCount}.");
                    Assert.That(cell.ColumnIndex, Is.GreaterThanOrEqualTo(0), $"Cell with text {cell.Text} should have column index greater than or equal to zero.");
                });
                Assert.That(cell.ColumnIndex, Is.LessThan(table.ColumnCount), $"Cell with text {cell.Text} should have column index less than {table.ColumnCount}.");

                if (cell.RowIndex == 0)
                {
                    Assert.That(cell.IsHeader, Is.True);
                }
                else
                {
                    Assert.That(cell.IsHeader, Is.False, $"Cell with text {cell.Text} should not have been classified as header.");
                }

                // Row = 1 has a row span of 2.
                var expectedRowSpan = cell.RowIndex == 1 ? 2 : 1;
                Assert.Multiple(() =>
                {
                    Assert.That(cell.RowSpan, Is.EqualTo(expectedRowSpan), $"Cell with text {cell.Text} should have a row span of {expectedRowSpan}.");

                    Assert.That(cell.IsFooter, Is.False, $"Cell with text {cell.Text} should not have been classified as footer.");
                    Assert.That(cell.Confidence, Is.GreaterThanOrEqualTo(0), $"Cell with text {cell.Text} should have confidence greater or equal to zero.");
                    Assert.That(cell.RowIndex, Is.LessThanOrEqualTo(2), $"Cell with text {cell.Text} should have a row index less than or equal to two.");

                    Assert.That(cell.Text, Is.EqualTo(expectedText[cell.RowIndex, cell.ColumnIndex]));
                    Assert.That(cell.FieldElements.Count, Is.GreaterThan(0), $"Cell with text {cell.Text} should have at least one field element.");
                });
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
            Assert.That(operation.HasValue, Is.True);

            var formPage = operation.Value.Single();

            Assert.Multiple(() =>
            {
                // The expected values are based on the values returned by the service, and not the actual
                // values present in the form. We are not testing the service here, but the SDK.

                Assert.That(formPage.Unit, Is.EqualTo(LengthUnit.Pixel));
                Assert.That(formPage.Width, Is.EqualTo(1700));
                Assert.That(formPage.Height, Is.EqualTo(2200));
                Assert.That(formPage.TextAngle, Is.EqualTo(0));
                Assert.That(formPage.Lines, Has.Count.EqualTo(54));
            });

            var lines = formPage.Lines.ToList();

            for (var lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                var line = lines[lineIndex];

                Assert.Multiple(() =>
                {
                    Assert.That(line.Text, Is.Not.Null, $"Text should not be null in line {lineIndex}.");
                    Assert.That(line.BoundingBox.Points.Count(), Is.EqualTo(4), $"There should be exactly 4 points in the bounding box in line {lineIndex}.");
                    Assert.That(line.Words.Count, Is.GreaterThan(0), $"There should be at least one word in line {lineIndex}.");
                });
                foreach (var item in line.Words)
                {
                    Assert.That(item.Confidence, Is.GreaterThanOrEqualTo(0));
                }

                Assert.That(line.Appearance, Is.Not.Null);
                Assert.That(line.Appearance.Style, Is.Not.Null);
                Assert.That(line.Appearance.Style.Confidence, Is.GreaterThan(0f));

                if (lineIndex == 45)
                {
                    Assert.That(TextStyleName.Handwriting, Is.EqualTo(line.Appearance.Style.Name));
                }
                else
                {
                    Assert.That(TextStyleName.Other, Is.EqualTo(line.Appearance.Style.Name));
                }
            }

            Assert.That(formPage.Tables.Count, Is.EqualTo(2));

            var sampleTable = formPage.Tables[1];

            Assert.That(sampleTable.RowCount, Is.EqualTo(4));
            Assert.That(sampleTable.ColumnCount, Is.EqualTo(2));
            Assert.That(sampleTable.BoundingBox.Points.Count(), Is.EqualTo(4), $"There should be exactly 4 points in the table bounding box.");

            var cells = sampleTable.Cells.ToList();

            Assert.That(cells.Count, Is.EqualTo(8));

            var expectedText = new string[4, 2]
            {
                { "SUBTOTAL", "$140.00" },
                { "TAX", "$4.00" },
                { "", ""},
                { "TOTAL", "$144.00" }
            };

            for (int i = 0; i < cells.Count; i++)
            {
                Assert.That(cells[i].RowIndex, Is.GreaterThanOrEqualTo(0), $"Cell with text {cells[i].Text} should have row index greater than or equal to zero.");
                Assert.Multiple(() =>
                {
                    Assert.That(cells[i].RowIndex, Is.LessThan(sampleTable.RowCount), $"Cell with text {cells[i].Text} should have row index less than {sampleTable.RowCount}.");
                    Assert.That(cells[i].ColumnIndex, Is.GreaterThanOrEqualTo(0), $"Cell with text {cells[i].Text} should have column index greater than or equal to zero.");
                });
                Assert.Multiple(() =>
                {
                    Assert.That(cells[i].ColumnIndex, Is.LessThan(sampleTable.ColumnCount), $"Cell with text {cells[i].Text} should have column index less than {sampleTable.ColumnCount}.");

                    Assert.That(cells[i].RowSpan, Is.EqualTo(1), $"Cell with text {cells[i].Text} should have a row span of 1.");
                    Assert.That(cells[i].ColumnSpan, Is.EqualTo(1), $"Cell with text {cells[i].Text} should have a column span of 1.");

                    Assert.That(cells[i].Text, Is.EqualTo(expectedText[cells[i].RowIndex, cells[i].ColumnIndex]));

                    Assert.That(cells[i].IsFooter, Is.False, $"Cell with text {cells[i].Text} should not have been classified as footer.");
                });

                if (cells[i].RowIndex == 0)
                {
                    Assert.That(cells[i].IsHeader, Is.True);
                }
                else
                {
                    Assert.That(cells[i].IsHeader, Is.False, $"Cell with text {cells[i].Text} should not have been classified as header.");
                }

                Assert.That(cells[i].Confidence, Is.GreaterThanOrEqualTo(0), $"Cell with text {cells[i].Text} should have confidence greater or equal to zero.");

                // Empty row
                if (cells[i].RowIndex != 2)
                {
                    Assert.That(cells[i].FieldElements.Count, Is.GreaterThan(0), $"Cell with text {cells[i].Text} should have at least one field element.");
                }
                else
                {
                    Assert.That(cells[i].FieldElements.Count, Is.EqualTo(0));
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

            Assert.That(formPages, Has.Count.EqualTo(2));

            for (int pageIndex = 0; pageIndex < formPages.Count; pageIndex++)
            {
                var formPage = formPages[pageIndex];

                ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = formPage.Lines[1];
                var expectedText = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.That(sampleLine.Text, Is.EqualTo(expectedText));
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

            Assert.Multiple(() =>
            {
                Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
                Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
                Assert.That(blankPage.SelectionMarks.Count, Is.EqualTo(0));
            });
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

            Assert.That(formPages, Has.Count.EqualTo(3));

            for (int pageIndex = 0; pageIndex < formPages.Count; pageIndex++)
            {
                var formPage = formPages[pageIndex];

                ValidateFormPage(formPage, includeFieldElements: true, expectedPageNumber: pageIndex + 1);

                // Basic sanity test to make sure pages are ordered correctly.

                if (pageIndex == 0 || pageIndex == 2)
                {
                    var sampleLine = formPage.Lines[3];
                    var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.That(sampleLine.Text, Is.EqualTo(expectedText));
                }
            }

            var blankPage = formPages[1];

            Assert.Multiple(() =>
            {
                Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
                Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
            });
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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidImage"));
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
            Assert.That(operation.HasValue, Is.True);

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
            Assert.That(ex.ErrorCode, Is.EqualTo("NotSupportedLanguage"));
        }
    }
}
