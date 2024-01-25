// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// A static class that lumps together the filenames of all documents to be used for tests.
    /// A single constant string must be added to this class for each new document added to the
    /// test assets folder.
    /// </summary>
    public static class TestFile
    {
        /// <summary>A single-page blank document.</summary>
        public const string Blank = "blank.pdf";

        /// <summary>A driver's license.</summary>
        public const string DriverLicenseJpg = "license.jpg";

        /// <summary>One of the purchase orders used for model training.</summary>
        public const string Form1 = "Form_1.jpg";

        /// <summary>Form containing selection marks.</summary>
        public const string FormSelectionMarks = "selectionMarkForm.pdf";

        /// <summary>An itemized en-US receipt.</summary>
        public const string ReceiptJpg = "contoso-receipt.jpg";

        /// <summary>An itemized en-US receipt.</summary>
        public const string ReceiptPng = "contoso-allinone.png";

        /// <summary>A file with multiple receipts, one per page.</summary>
        public const string ReceiptMultipage = "multipleReceipt.pdf";

        /// <summary>A three-page receipt file in which the second page is blank.</summary>
        public const string ReceipMultipageWithBlankPage = "multipageReceiptBlankPage.pdf";

        /// <summary>A business card file.</summary>
        public const string BusinessCardJpg = "businessCard.jpg";

        /// <summary>A business card file.</summary>
        public const string BusinessCardtPng = "businessCard.png";

        /// <summary>A business card file.</summary>
        public const string BusinessCardtBmp = "businessCard.bmp";

        /// <summary>A file with two business cards, one per page.</summary>
        public const string BusinessMultipage = "multipleBusinessCards.pdf";

        /// <summary>A complete invoice file.</summary>
        public const string InvoiceJpg = "recommended_invoice.jpg";

        /// <summary>A basic invoice file.</summary>
        public const string InvoicePdf = "Invoice_1.pdf";

        /// <summary>A basic invoice file.</summary>
        public const string InvoiceLeTiff = "Invoice_1.tiff";

        /// <summary>A two-page invoice file.</summary>
        public const string InvoiceMultipage = "multi1.pdf";

        /// <summary>A three-page invoice file in which the second page is blank.</summary>
        public const string InvoiceMultipageBlank = "multipage_invoice1.pdf";

        /// <summary>A form with a table that has dynamic rows and empty cells.</summary>
        public const string FormTableDynamicRows = "label_table_dynamic_rows1.pdf";

        /// <summary>A form with a table that has fixed rows and empty cells.</summary>
        public const string FormTableFixedRows = "label_table_fixed_rows1.pdf";

        /// <summary>A set of IRS-1040 forms to test document classifiers.</summary>
        public const string Irs1040 = "IRS-1040_2.pdf";
    }
}
