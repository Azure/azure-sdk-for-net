using System;
using System.Collections.Generic;
using System.Text;

namespace CustomSerializationSample
{
    public class Receipt
    {
        public string MerchantName { get; }

        public DateTime TransactionDate { get; }

        public IReadOnlyCollection<ReceiptItem> Items { get; }

        public float TotalPrice { get; }
    }
}
