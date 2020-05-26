// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Tests
{
    public static class FormName
    {
        /// <summary>The name of the JPG file which contains the receipt to be used for tests.</summary>
        public const string JpgReceiptFilename = "contoso-receipt.jpg";

        /// <summary>The name of the PNG file which contains the receipt to be used for tests.</summary>
        public const string PngReceiptFilename = "contoso-allinone.png";

        /// <summary>The format to generate the filenames of the forms to be used for tests.</summary>
        public const string InvoiceFilenameFormat = "Invoice_1.pdf";

        public const string InvoiceTiff = "Invoice_1.tiff";

        /// <summary>The name of the JPG file which contains the form to be used for tests.</summary>
        public const string FormFilename = "Form_1.jpg";

        /// <summary>The name of the PDF file which contains the multipage form to be used for tests.</summary>
        public const string MultipageFormFilename = "multipage_invoice_noblank.pdf";
    }
}
