// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task AnalyzeInvoiceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeInvoice
            // You can replace this URL with your own invoice file URL
            Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = invoiceUrl } });

            AnalyzeResult result = operation.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeInvoice
            Assert.IsNotNull(invoiceUrl, "Invoice URL should not be null");
            Assert.IsTrue(invoiceUrl.IsAbsoluteUri, "Invoice URL should be absolute");
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "Invoice should have exactly one content element");
            #endregion

            #region Snippet:ContentUnderstandingExtractInvoiceFields
            // Get the document content (invoices are documents)
            DocumentContent documentContent = (DocumentContent)result.Contents!.First();

            // Print document unit information
            // The unit indicates the measurement system used for coordinates in the source field
            Console.WriteLine($"Document unit: {documentContent.Unit ?? "unknown"}");
            Console.WriteLine($"Pages: {documentContent.StartPageNumber} to {documentContent.EndPageNumber}");
            if (documentContent.Pages != null && documentContent.Pages.Count > 0)
            {
                var page = documentContent.Pages[0];
                var unit = documentContent.Unit?.ToString() ?? "units";
                Console.WriteLine($"Page dimensions: {page.Width} x {page.Height} {unit}");
            }
            Console.WriteLine();

            // Extract simple string fields
            var customerNameField = documentContent.Fields["CustomerName"];
            Console.WriteLine($"Customer Name: {customerNameField.Value ?? "(None)"}");
            Console.WriteLine($"  Confidence: {customerNameField.Confidence?.ToString("F2") ?? "N/A"}");
            Console.WriteLine($"  Source: {customerNameField.Source ?? "N/A"}");
            if (customerNameField.Spans?.Count > 0)
            {
                var span = customerNameField.Spans[0];
                Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
            }

            // Extract simple date field
            var invoiceDateField = documentContent.Fields.GetFieldOrDefault("InvoiceDate");
            Console.WriteLine($"Invoice Date: {invoiceDateField?.Value ?? "(None)"}");
            Console.WriteLine($"  Confidence: {invoiceDateField?.Confidence?.ToString("F2") ?? "N/A"}");
            Console.WriteLine($"  Source: {invoiceDateField?.Source ?? "N/A"}");
            if (invoiceDateField?.Spans?.Count > 0)
            {
                var span = invoiceDateField.Spans[0];
                Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
            }

            // Extract object fields (nested structures)
            if (documentContent.Fields.GetFieldOrDefault("TotalAmount") is ObjectField totalAmountObj)
            {
                var amount = totalAmountObj.ValueObject?.GetFieldOrDefault("Amount")?.Value as double?;
                var currency = totalAmountObj.ValueObject?.GetFieldOrDefault("CurrencyCode")?.Value;
                Console.WriteLine($"Total: {currency ?? "$"}{amount?.ToString("F2") ?? "(None)"}");
                Console.WriteLine($"  Confidence: {totalAmountObj.Confidence?.ToString("F2") ?? "N/A"}");
                Console.WriteLine($"  Source: {totalAmountObj.Source ?? "N/A"}");
            }

            // Extract array fields (collections like line items)
            if (documentContent.Fields.GetFieldOrDefault("LineItems") is ArrayField lineItems)
            {
                Console.WriteLine($"Line Items ({lineItems.Count}):");
                for (int i = 0; i < lineItems.Count; i++)
                {
                    if (lineItems[i] is ObjectField item)
                    {
                        var description = item.ValueObject?.GetFieldOrDefault("Description")?.Value;
                        var quantity = item.ValueObject?.GetFieldOrDefault("Quantity")?.Value as double?;
                        Console.WriteLine($"  Item {i + 1}: {description ?? "N/A"} (Qty: {quantity?.ToString() ?? "N/A"})");
                        Console.WriteLine($"    Confidence: {item.Confidence?.ToString("F2") ?? "N/A"}");
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractInvoiceFields
            var content = result.Contents?.FirstOrDefault();
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<DocumentContent>(content, "Content should be of type DocumentContent");

            var docContent = (DocumentContent)content!;
            Assert.IsNotNull(docContent.Fields, "DocumentContent.Fields should not be null");

            // Verify basic document properties
            Assert.IsTrue(docContent.StartPageNumber >= 1, "Start page should be >= 1");
            Assert.IsTrue(docContent.EndPageNumber >= docContent.StartPageNumber,
                "End page should be >= start page");
            int totalPages = docContent.EndPageNumber - docContent.StartPageNumber + 1;
            Assert.IsTrue(totalPages > 0, "Total pages should be positive");

            // Verify CustomerName field - expected to exist
            var customerNameFieldAssert = docContent.Fields["CustomerName"];
            Assert.IsNotNull(customerNameFieldAssert, "CustomerName field should exist");

            if (customerNameFieldAssert.Value != null)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(customerNameFieldAssert.Value.ToString()),
                    "CustomerName value should not be empty when present");
            }

            if (customerNameFieldAssert.Confidence.HasValue)
            {
                Assert.IsTrue(customerNameFieldAssert.Confidence.Value >= 0 && customerNameFieldAssert.Confidence.Value <= 1,
                    $"CustomerName confidence should be between 0 and 1, but was {customerNameFieldAssert.Confidence.Value}");
            }

            if (!string.IsNullOrWhiteSpace(customerNameFieldAssert.Source))
            {
                Assert.IsTrue(customerNameFieldAssert.Source.StartsWith("D("),
                    "Source should start with 'D(' for document fields");
            }

            // Spans are expected to exist and have at least one span
            Assert.IsNotNull(customerNameFieldAssert.Spans, "CustomerName Spans should not be null");
            Assert.IsTrue(customerNameFieldAssert.Spans.Count > 0, "CustomerName should have at least one span");
            foreach (var span in customerNameFieldAssert.Spans)
            {
                Assert.IsTrue(span.Offset >= 0, $"Span offset should be >= 0, but was {span.Offset}");
                Assert.IsTrue(span.Length > 0, $"Span length should be > 0, but was {span.Length}");
            }

            // Verify InvoiceDate field - expected to exist
            var invoiceDateFieldAssert = docContent.Fields["InvoiceDate"];
            Assert.IsNotNull(invoiceDateFieldAssert, "InvoiceDate field should exist");

            if (invoiceDateFieldAssert.Value != null)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(invoiceDateFieldAssert.Value.ToString()),
                    "InvoiceDate value should not be empty when present");
            }

            if (invoiceDateFieldAssert.Confidence.HasValue)
            {
                Assert.IsTrue(invoiceDateFieldAssert.Confidence.Value >= 0 && invoiceDateFieldAssert.Confidence.Value <= 1,
                    $"InvoiceDate confidence should be between 0 and 1, but was {invoiceDateFieldAssert.Confidence.Value}");
            }

            if (!string.IsNullOrWhiteSpace(invoiceDateFieldAssert.Source))
            {
                Assert.IsTrue(invoiceDateFieldAssert.Source.StartsWith("D("),
                    "Source should start with 'D(' for document fields");
            }

            // Spans are expected to exist and have at least one span
            Assert.IsNotNull(invoiceDateFieldAssert.Spans, "InvoiceDate Spans should not be null");
            Assert.IsTrue(invoiceDateFieldAssert.Spans.Count > 0, "InvoiceDate should have at least one span");
            foreach (var span in invoiceDateFieldAssert.Spans)
            {
                Assert.IsTrue(span.Offset >= 0, $"Span offset should be >= 0, but was {span.Offset}");
                Assert.IsTrue(span.Length > 0, $"Span length should be > 0, but was {span.Length}");
            }

            // Verify TotalAmount object field - expected to exist
            var totalAmountFieldAssert = docContent.Fields["TotalAmount"];
            Assert.IsInstanceOf<ObjectField>(totalAmountFieldAssert, "TotalAmount should be an ObjectField");
            var totalAmountObjAssert = (ObjectField)totalAmountFieldAssert;

            if (totalAmountObjAssert.Confidence.HasValue)
            {
                Assert.IsTrue(totalAmountObjAssert.Confidence.Value >= 0 && totalAmountObjAssert.Confidence.Value <= 1,
                    $"TotalAmount confidence should be between 0 and 1, but was {totalAmountObjAssert.Confidence.Value}");
            }

            // Verify Amount sub-field - expected to exist
            Assert.IsNotNull(totalAmountObjAssert.ValueObject, "TotalAmount.ValueObject should not be null");
            var amountFieldAssert = totalAmountObjAssert.ValueObject["Amount"];
            Assert.IsNotNull(amountFieldAssert, "Amount field should exist");
            Assert.IsInstanceOf<NumberField>(amountFieldAssert, "Amount should be a NumberField");
            if (amountFieldAssert.Value is double amountValue)
            {
                Assert.IsTrue(amountValue >= 0, $"Amount should be >= 0, but was {amountValue}");
            }

            // Verify CurrencyCode sub-field - expected to exist
            var currencyFieldAssert = totalAmountObjAssert.ValueObject["CurrencyCode"];
            Assert.IsNotNull(currencyFieldAssert, "CurrencyCode field should exist");
            if (currencyFieldAssert.Value != null)
            {
                var currencyValue = currencyFieldAssert.Value.ToString();
                if (!string.IsNullOrWhiteSpace(currencyValue))
                {
                    Assert.AreEqual(3, currencyValue.Length,
                        $"CurrencyCode should be 3 characters, but was '{currencyValue}'");
                }
            }

            // Verify LineItems array field - expected to exist
            var lineItemsFieldAssert = docContent.Fields["LineItems"];
            Assert.IsInstanceOf<ArrayField>(lineItemsFieldAssert, "LineItems should be an ArrayField");
            var lineItemsAssert = (ArrayField)lineItemsFieldAssert;
            Assert.IsTrue(lineItemsAssert.Count >= 0, "LineItems count should be >= 0");

            for (int i = 0; i < lineItemsAssert.Count; i++)
            {
                Assert.IsInstanceOf<ObjectField>(lineItemsAssert[i], $"Line item {i + 1} should be an ObjectField");
                var item = (ObjectField)lineItemsAssert[i];

                if (item.Confidence.HasValue)
                {
                    Assert.IsTrue(item.Confidence.Value >= 0 && item.Confidence.Value <= 1,
                        $"Line item {i + 1} confidence should be between 0 and 1, but was {item.Confidence.Value}");
                }

                // Verify Description field - expected to exist
                Assert.IsNotNull(item.ValueObject, $"Line item {i + 1} ValueObject should not be null");
                var descriptionField = item.ValueObject["Description"];
                Assert.IsNotNull(descriptionField, $"Line item {i + 1} Description field should exist");
                if (descriptionField.Value != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(descriptionField.Value.ToString()),
                        $"Line item {i + 1} description should not be empty when present");
                }

                // Verify Quantity field - expected to exist
                var quantityField = item.ValueObject["Quantity"];
                Assert.IsNotNull(quantityField, $"Line item {i + 1} Quantity field should exist");
                Assert.IsInstanceOf<NumberField>(quantityField, $"Line item {i + 1} Quantity should be a NumberField");
                if (quantityField.Value is double quantity)
                {
                    Assert.IsTrue(quantity >= 0, $"Line item {i + 1} quantity should be >= 0, but was {quantity}");
                }

                // Verify UnitPrice field if exists (optional)
                var unitPriceField = item.ValueObject?.GetFieldOrDefault("UnitPrice");
                if (unitPriceField?.Value is double unitPrice)
                {
                    Assert.IsTrue(unitPrice >= 0, $"Line item {i + 1} unit price should be >= 0, but was {unitPrice}");
                }

                // Verify Amount field if exists (optional)
                var itemAmountField = item.ValueObject?.GetFieldOrDefault("Amount");
                if (itemAmountField?.Value is double itemAmount)
                {
                    Assert.IsTrue(itemAmount >= 0, $"Line item {i + 1} amount should be >= 0, but was {itemAmount}");
                }
            }
            #endregion
        }
    }
}
