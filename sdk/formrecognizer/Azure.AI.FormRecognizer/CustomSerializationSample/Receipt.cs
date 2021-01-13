using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace CustomSerializationSample
{
    public class Receipt
    {
        public FormField<string> MerchantName { get; }

        public FormField<DateTime> TransactionDate { get; }

        public IReadOnlyCollection<ReceiptItem> Items { get; }

        public FormField<float> TotalPrice { get; }
    }
}
