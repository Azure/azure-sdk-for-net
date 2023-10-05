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
    /// The suite of tests for the `StartRecognizeInvoices` methods in the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class RecognizeInvoicesLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeInvoicesLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task StartRecognizeInvoicesCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream);
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

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeInvoicesPopulatesExtractedJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeInvoicesOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeInvoicesAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceJpg);
                operation = await client.StartRecognizeInvoicesFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:invoice", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("AmountDue"));
            Assert.True(form.Fields.ContainsKey("BillingAddress"));
            Assert.True(form.Fields.ContainsKey("BillingAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("CustomerAddress"));
            Assert.True(form.Fields.ContainsKey("CustomerAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("CustomerId"));
            Assert.True(form.Fields.ContainsKey("CustomerName"));
            Assert.True(form.Fields.ContainsKey("DueDate"));
            Assert.True(form.Fields.ContainsKey("InvoiceDate"));
            Assert.True(form.Fields.ContainsKey("InvoiceId"));
            Assert.True(form.Fields.ContainsKey("InvoiceTotal"));
            Assert.True(form.Fields.ContainsKey("Items"));
            Assert.True(form.Fields.ContainsKey("PreviousUnpaidBalance"));
            Assert.True(form.Fields.ContainsKey("PurchaseOrder"));
            Assert.True(form.Fields.ContainsKey("RemittanceAddress"));
            Assert.True(form.Fields.ContainsKey("RemittanceAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("ServiceAddress"));
            Assert.True(form.Fields.ContainsKey("ServiceAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("ServiceEndDate"));
            Assert.True(form.Fields.ContainsKey("ServiceStartDate"));
            Assert.True(form.Fields.ContainsKey("ShippingAddress"));
            Assert.True(form.Fields.ContainsKey("ShippingAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("SubTotal"));
            Assert.True(form.Fields.ContainsKey("TotalTax"));
            Assert.True(form.Fields.ContainsKey("VendorAddress"));
            Assert.True(form.Fields.ContainsKey("VendorAddressRecipient"));
            Assert.True(form.Fields.ContainsKey("VendorName"));

            Assert.That(form.Fields["AmountDue"].Value.AsFloat(), Is.EqualTo(610.00).Within(0.0001));
            Assert.AreEqual("123 Bill St, Redmond WA, 98052", form.Fields["BillingAddress"].Value.AsString());
            Assert.AreEqual("Microsoft Finance", form.Fields["BillingAddressRecipient"].Value.AsString());
            Assert.AreEqual("123 Other St, Redmond WA, 98052", form.Fields["CustomerAddress"].Value.AsString());
            Assert.AreEqual("Microsoft Corp", form.Fields["CustomerAddressRecipient"].Value.AsString());
            Assert.AreEqual("CID-12345", form.Fields["CustomerId"].Value.AsString());
            Assert.AreEqual("MICROSOFT CORPORATION", form.Fields["CustomerName"].Value.AsString());

            var dueDate = form.Fields["DueDate"].Value.AsDate();
            Assert.AreEqual(15, dueDate.Day);
            Assert.AreEqual(12, dueDate.Month);
            Assert.AreEqual(2019, dueDate.Year);

            var invoiceDate = form.Fields["InvoiceDate"].Value.AsDate();
            Assert.AreEqual(15, invoiceDate.Day);
            Assert.AreEqual(11, invoiceDate.Month);
            Assert.AreEqual(2019, invoiceDate.Year);

            Assert.AreEqual("INV-100", form.Fields["InvoiceId"].Value.AsString());
            Assert.That(form.Fields["InvoiceTotal"].Value.AsFloat(), Is.EqualTo(110.00).Within(0.0001));
            Assert.That(form.Fields["PreviousUnpaidBalance"].Value.AsFloat(), Is.EqualTo(500.00).Within(0.0001));
            Assert.AreEqual("PO-3333", form.Fields["PurchaseOrder"].Value.AsString());
            Assert.AreEqual("123 Remit St New York, NY, 10001", form.Fields["RemittanceAddress"].Value.AsString());
            Assert.AreEqual("Contoso Billing", form.Fields["RemittanceAddressRecipient"].Value.AsString());
            Assert.AreEqual("123 Service St, Redmond WA, 98052", form.Fields["ServiceAddress"].Value.AsString());
            Assert.AreEqual("Microsoft Services", form.Fields["ServiceAddressRecipient"].Value.AsString());

            var serviceEndDate = form.Fields["ServiceEndDate"].Value.AsDate();
            Assert.AreEqual(14, serviceEndDate.Day);
            Assert.AreEqual(11, serviceEndDate.Month);
            Assert.AreEqual(2019, serviceEndDate.Year);

            var serviceStartDate = form.Fields["ServiceStartDate"].Value.AsDate();
            Assert.AreEqual(14, serviceStartDate.Day);
            Assert.AreEqual(10, serviceStartDate.Month);
            Assert.AreEqual(2019, serviceStartDate.Year);

            Assert.AreEqual("123 Ship St, Redmond WA, 98052", form.Fields["ShippingAddress"].Value.AsString());
            Assert.AreEqual("Microsoft Delivery", form.Fields["ShippingAddressRecipient"].Value.AsString());
            Assert.That(form.Fields["SubTotal"].Value.AsFloat(), Is.EqualTo(100.00).Within(0.0001));
            Assert.That(form.Fields["TotalTax"].Value.AsFloat(), Is.EqualTo(10.00).Within(0.0001));
            Assert.AreEqual("123 456th St New York, NY, 10001", form.Fields["VendorAddress"].Value.AsString());
            Assert.AreEqual("Contoso Headquarters", form.Fields["VendorAddressRecipient"].Value.AsString());
            Assert.AreEqual("CONTOSO LTD.", form.Fields["VendorName"].Value.AsString());

            // TODO: add validation for Tax which currently don't have `valuenumber` properties.
            // Issue: https://github.com/Azure/azure-sdk-for-net/issues/20014

            var expectedItems = new List<(float? Amount, DateTime Date, string Description, string ProductCode, float? Quantity, string Unit, float? UnitPrice)>()
            {
                (60f, DateTime.Parse("2021-03-04 00:00:00"), "Consulting Services", "A123", 2f, "hours", 30f),
                (30f, DateTime.Parse("2021-03-05 00:00:00"), "Document Fee", "B456", 3f, null, 10f),
                (10f, DateTime.Parse("2021-03-06 00:00:00"), "Printing Fee", "C789", 10f, "pages", 1f)
            };

            // Include a bit of tolerance when comparing float types.

            var items = form.Fields["Items"].Value.AsList();

            Assert.AreEqual(expectedItems.Count, items.Count);

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var receiptItemInfo = items[itemIndex].Value.AsDictionary();

                receiptItemInfo.TryGetValue("Amount", out var amountField);
                receiptItemInfo.TryGetValue("Date", out var dateField);
                receiptItemInfo.TryGetValue("Description", out var descriptionField);
                receiptItemInfo.TryGetValue("ProductCode", out var productCodeField);
                receiptItemInfo.TryGetValue("Quantity", out var quantityField);
                receiptItemInfo.TryGetValue("UnitPrice", out var unitPricefield);
                receiptItemInfo.TryGetValue("Unit", out var unitfield);

                float? amount = amountField.Value.AsFloat();
                string description = descriptionField.Value.AsString();
                string productCode = productCodeField.Value.AsString();
                float? quantity = quantityField?.Value.AsFloat();
                float? unitPrice = unitPricefield.Value.AsFloat();
                string unit = unitfield?.Value.AsString();

                Assert.IsNotNull(dateField);
                DateTime date = dateField.Value.AsDate();

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
        public async Task StartRecognizeInvoicesIncludeFieldElements()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeInvoicesOptions() { IncludeFieldElements = true };
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var invoicesform = recognizedForms.Single();

            ValidatePrebuiltForm(
                invoicesform,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [RecordedTest]
        public async Task StartRecognizeInvoicesCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            RecognizeInvoicesOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeInvoicesAsync(stream);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

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

        [RecordedTest]
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

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

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

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        public void StartRecognizeInvoicesFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeInvoicesFromUriAsync(invalidUri));
            Assert.AreEqual("InvalidImage", ex.ErrorCode);
        }

        [RecordedTest]
        public void StartRecognizeInvoicesWithWrongLocale()
        {
            var client = CreateFormRecognizerClient();

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceJpg);
            RequestFailedException ex;

            using (Recording.DisableRequestBodyRecording())
            {
                ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeInvoicesAsync(stream, new RecognizeInvoicesOptions() { Locale = "not-locale" }));
            }
            Assert.AreEqual("UnsupportedLocale", ex.ErrorCode);
        }
    }
}
