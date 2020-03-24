// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ReceiptClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [TestFixture]
    public class ReceiptClientLiveTests
    {
        /// <summary>
        /// Verifies that the <see cref="ReceiptClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ExtractReceiptPopulatesExtractedReceipt(bool async)
        {
            var endpoint = new Uri("");
            var key = "";
            var client = new ReceiptClient(endpoint, new FormRecognizerApiKeyCredential(key));

            using var stream = new FileStream(@"", FileMode.Open);
            Response<ExtractedReceipt> response;

            if (async)
            {
                response = await client.ExtractReceiptAsync(stream, FormContentType.Jpeg);
            }
            else
            {
                response = client.ExtractReceipt(stream, FormContentType.Jpeg);
            }

            Assert.IsNotNull(response);

            var receipt = response.Value;

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
    }
}
