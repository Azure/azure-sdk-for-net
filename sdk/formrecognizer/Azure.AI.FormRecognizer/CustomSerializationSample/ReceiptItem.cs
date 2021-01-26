using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace CustomSerializationSample
{
    public class ReceiptItem
    {
        public FormField<string> Name { get; }
        public FormField<float> TotalPrice { get; }
    }
}
