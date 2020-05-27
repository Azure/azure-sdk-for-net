// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// A static class that lumps together the filenames of all forms to be used for tests.
    /// A single constant string must be added to this class for each new form added to the
    /// test assets folder.
    /// </summary>
    public static class TestFile
    {
        /// <summary>One of the purchase orders used for model training.</summary>
        public const string Form1 = "Form_1.jpg";

        /// <summary>An itemized en-US receipt.</summary>
        public const string ReceiptJpg = "contoso-receipt.jpg";

        /// <summary>An itemized en-US receipt.</summary>
        public const string ReceiptPng = "contoso-allinone.png";

        /// <summary>A basic invoice file.</summary>
        public const string InvoicePdf = "Invoice_1.pdf";

        /// <summary>A basic invoice file.</summary>
        public const string InvoiceLeTiff = "Invoice_1.tiff";

        /// <summary>A two-page invoice file.</summary>
        public const string InvoiceMultipage = "multipage_invoice_noblank.pdf";
    }
}
