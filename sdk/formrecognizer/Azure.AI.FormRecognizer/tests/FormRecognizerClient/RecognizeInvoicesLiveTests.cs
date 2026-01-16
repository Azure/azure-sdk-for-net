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
            Assert.That(form, Is.Not.Null);

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

            Assert.That(operation.HasValue, Is.True);

            var form = operation.Value.Single();

            Assert.That(form, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.That(form.FormType, Is.EqualTo("prebuilt:invoice"));
            Assert.That(form.PageRange.FirstPageNumber, Is.EqualTo(1));
            Assert.That(form.PageRange.LastPageNumber, Is.EqualTo(1));

            Assert.That(form.Fields, Is.Not.Null);

            Assert.That(form.Fields.ContainsKey("AmountDue"), Is.True);
            Assert.That(form.Fields.ContainsKey("BillingAddress"), Is.True);
            Assert.That(form.Fields.ContainsKey("BillingAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("CustomerAddress"), Is.True);
            Assert.That(form.Fields.ContainsKey("CustomerAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("CustomerId"), Is.True);
            Assert.That(form.Fields.ContainsKey("CustomerName"), Is.True);
            Assert.That(form.Fields.ContainsKey("DueDate"), Is.True);
            Assert.That(form.Fields.ContainsKey("InvoiceDate"), Is.True);
            Assert.That(form.Fields.ContainsKey("InvoiceId"), Is.True);
            Assert.That(form.Fields.ContainsKey("InvoiceTotal"), Is.True);
            Assert.That(form.Fields.ContainsKey("Items"), Is.True);
            Assert.That(form.Fields.ContainsKey("PreviousUnpaidBalance"), Is.True);
            Assert.That(form.Fields.ContainsKey("PurchaseOrder"), Is.True);
            Assert.That(form.Fields.ContainsKey("RemittanceAddress"), Is.True);
            Assert.That(form.Fields.ContainsKey("RemittanceAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("ServiceAddress"), Is.True);
            Assert.That(form.Fields.ContainsKey("ServiceAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("ServiceEndDate"), Is.True);
            Assert.That(form.Fields.ContainsKey("ServiceStartDate"), Is.True);
            Assert.That(form.Fields.ContainsKey("ShippingAddress"), Is.True);
            Assert.That(form.Fields.ContainsKey("ShippingAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("SubTotal"), Is.True);
            Assert.That(form.Fields.ContainsKey("TotalTax"), Is.True);
            Assert.That(form.Fields.ContainsKey("VendorAddress"), Is.True);
            Assert.That(form.Fields.ContainsKey("VendorAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("VendorName"), Is.True);

            Assert.That(form.Fields["AmountDue"].Value.AsFloat(), Is.EqualTo(610.00).Within(0.0001));
            Assert.That(form.Fields["BillingAddress"].Value.AsString(), Is.EqualTo("123 Bill St, Redmond WA, 98052"));
            Assert.That(form.Fields["BillingAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Finance"));
            Assert.That(form.Fields["CustomerAddress"].Value.AsString(), Is.EqualTo("123 Other St, Redmond WA, 98052"));
            Assert.That(form.Fields["CustomerAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Corp"));
            Assert.That(form.Fields["CustomerId"].Value.AsString(), Is.EqualTo("CID-12345"));
            Assert.That(form.Fields["CustomerName"].Value.AsString(), Is.EqualTo("MICROSOFT CORPORATION"));

            var dueDate = form.Fields["DueDate"].Value.AsDate();
            Assert.That(dueDate.Day, Is.EqualTo(15));
            Assert.That(dueDate.Month, Is.EqualTo(12));
            Assert.That(dueDate.Year, Is.EqualTo(2019));

            var invoiceDate = form.Fields["InvoiceDate"].Value.AsDate();
            Assert.That(invoiceDate.Day, Is.EqualTo(15));
            Assert.That(invoiceDate.Month, Is.EqualTo(11));
            Assert.That(invoiceDate.Year, Is.EqualTo(2019));

            Assert.That(form.Fields["InvoiceId"].Value.AsString(), Is.EqualTo("INV-100"));
            Assert.That(form.Fields["InvoiceTotal"].Value.AsFloat(), Is.EqualTo(110.00).Within(0.0001));
            Assert.That(form.Fields["PreviousUnpaidBalance"].Value.AsFloat(), Is.EqualTo(500.00).Within(0.0001));
            Assert.That(form.Fields["PurchaseOrder"].Value.AsString(), Is.EqualTo("PO-3333"));
            Assert.That(form.Fields["RemittanceAddress"].Value.AsString(), Is.EqualTo("123 Remit St New York, NY, 10001"));
            Assert.That(form.Fields["RemittanceAddressRecipient"].Value.AsString(), Is.EqualTo("Contoso Billing"));
            Assert.That(form.Fields["ServiceAddress"].Value.AsString(), Is.EqualTo("123 Service St, Redmond WA, 98052"));
            Assert.That(form.Fields["ServiceAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Services"));

            var serviceEndDate = form.Fields["ServiceEndDate"].Value.AsDate();
            Assert.That(serviceEndDate.Day, Is.EqualTo(14));
            Assert.That(serviceEndDate.Month, Is.EqualTo(11));
            Assert.That(serviceEndDate.Year, Is.EqualTo(2019));

            var serviceStartDate = form.Fields["ServiceStartDate"].Value.AsDate();
            Assert.That(serviceStartDate.Day, Is.EqualTo(14));
            Assert.That(serviceStartDate.Month, Is.EqualTo(10));
            Assert.That(serviceStartDate.Year, Is.EqualTo(2019));

            Assert.That(form.Fields["ShippingAddress"].Value.AsString(), Is.EqualTo("123 Ship St, Redmond WA, 98052"));
            Assert.That(form.Fields["ShippingAddressRecipient"].Value.AsString(), Is.EqualTo("Microsoft Delivery"));
            Assert.That(form.Fields["SubTotal"].Value.AsFloat(), Is.EqualTo(100.00).Within(0.0001));
            Assert.That(form.Fields["TotalTax"].Value.AsFloat(), Is.EqualTo(10.00).Within(0.0001));
            Assert.That(form.Fields["VendorAddress"].Value.AsString(), Is.EqualTo("123 456th St New York, NY, 10001"));
            Assert.That(form.Fields["VendorAddressRecipient"].Value.AsString(), Is.EqualTo("Contoso Headquarters"));
            Assert.That(form.Fields["VendorName"].Value.AsString(), Is.EqualTo("CONTOSO LTD."));

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

            Assert.That(items.Count, Is.EqualTo(expectedItems.Count));

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

                Assert.That(dateField, Is.Not.Null);
                DateTime date = dateField.Value.AsDate();

                var expectedItem = expectedItems[itemIndex];

                Assert.That(amount, Is.EqualTo(expectedItem.Amount).Within(0.0001), $"Amount mismatch in item with index {itemIndex}.");
                Assert.That(date, Is.EqualTo(expectedItem.Date), $"Date mismatch in item with index {itemIndex}.");
                Assert.That(description, Is.EqualTo(expectedItem.Description), $"Description mismatch in item with index {itemIndex}.");
                Assert.That(productCode, Is.EqualTo(expectedItem.ProductCode), $"ProductCode mismatch in item with index {itemIndex}.");
                Assert.That(unit, Is.EqualTo(expectedItem.Unit), $"Unit mismatch in item with index {itemIndex}.");
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

            Assert.That(blankForm.Fields.Count, Is.EqualTo(0));

            var blankPage = blankForm.Pages.Single();

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
            Assert.That(blankPage.SelectionMarks.Count, Is.EqualTo(0));
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

            Assert.That(form, Is.Not.Null);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the invoice. We are not testing the service here, but the SDK.

            Assert.That(form.FormType, Is.EqualTo("prebuilt:invoice"));
            Assert.That(form.PageRange.FirstPageNumber, Is.EqualTo(1));
            Assert.That(form.PageRange.LastPageNumber, Is.EqualTo(2));

            Assert.That(form.Fields, Is.Not.Null);

            Assert.That(form.Fields.ContainsKey("VendorName"), Is.True);
            Assert.That(form.Fields.ContainsKey("RemittanceAddressRecipient"), Is.True);
            Assert.That(form.Fields.ContainsKey("RemittanceAddress"), Is.True);

            FormField vendorName = form.Fields["VendorName"];
            Assert.That(vendorName.ValueData.PageNumber, Is.EqualTo(2));
            Assert.That(vendorName.Value.AsString(), Is.EqualTo("Southridge Video"));

            FormField addressRecepient = form.Fields["RemittanceAddressRecipient"];
            Assert.That(addressRecepient.ValueData.PageNumber, Is.EqualTo(1));
            Assert.That(addressRecepient.Value.AsString(), Is.EqualTo("Contoso Ltd."));

            FormField address = form.Fields["RemittanceAddress"];
            Assert.That(address.ValueData.PageNumber, Is.EqualTo(1));
            Assert.That(address.Value.AsString(), Is.EqualTo("2345 Dogwood Lane Birch, Kansas 98123"));

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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidImage"));
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
            Assert.That(ex.ErrorCode, Is.EqualTo("UnsupportedLocale"));
        }
    }
}
