// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the `StartRecognizeReceipts` methods in the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(
    FormRecognizerClientOptions.ServiceVersion.V2_0,
    FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class RecognizeReceiptsLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeReceiptsLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
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

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync();

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
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
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

            await operation.WaitForCompletionAsync();

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
            Assert.AreEqual("Contoso", form.Fields["MerchantName"].Value.AsString());
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
                (1, "Surface Pro 6", null, 999.00f),
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

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
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

            await operation.WaitForCompletionAsync();

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
            Assert.AreEqual("Contoso", form.Fields["MerchantName"].Value.AsString());
            Assert.AreEqual("123 Main Street Redmond, WA 98052", form.Fields["MerchantAddress"].Value.AsString());
            Assert.AreEqual("987-654-3210", form.Fields["MerchantPhoneNumber"].ValueData.Text);

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

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeReceiptsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeReceiptsOptions() { IncludeFieldElements = true };
            RecognizeReceiptsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeReceiptsAsync(stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.ReceiptMultipage);
                operation = await client.StartRecognizeReceiptsFromUriAsync(uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

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
                var sampleField = recognizedForm.Fields["Total"];
                Assert.IsNotNull(sampleField.ValueData);

                if (formIndex == 0)
                {
                    Assert.AreEqual("$14.50", sampleField.ValueData.Text);
                }
                else if (formIndex == 1)
                {
                    Assert.AreEqual("$ 1203.39", sampleField.ValueData.Text);
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
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

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

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

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeReceiptsCanParseMultipageFormWithBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeReceiptsOptions() { IncludeFieldElements = true };
            RecognizeReceiptsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceipMultipageWithBlankPage);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeReceiptsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

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
                    var sampleField = recognizedForm.Fields["Total"];
                    var expectedValueData = formIndex == 0 ? "$14.50" : "$ 1203.39";

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

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public void StartRecognizeReceiptsFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeReceiptsFromUriAsync(invalidUri));
            Assert.AreEqual("InvalidImage", ex.ErrorCode);
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public void StartRecognizeReceiptsWithWrongLocale()
        {
            var client = CreateFormRecognizerClient();

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            RequestFailedException ex;

            using (Recording.DisableRequestBodyRecording())
            {
                ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeReceiptsAsync(stream, new RecognizeReceiptsOptions() { Locale = "not-locale" }));
            }
            Assert.AreEqual("UnsupportedLocale", ex.ErrorCode);
        }
    }
}
