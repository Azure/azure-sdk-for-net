// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public readonly partial struct DocumentBarcodeKind
    {
        /// <summary> QR code, as defined in ISO/IEC 18004:2015. </summary>
        [CodeGenMember("QRCode")]
        public static DocumentBarcodeKind QrCode { get; } = new DocumentBarcodeKind(QrCodeValue);

        /// <summary> PDF417, as defined in ISO 15438. </summary>
        [CodeGenMember("PDF417")]
        public static DocumentBarcodeKind Pdf417 { get; } = new DocumentBarcodeKind(Pdf417Value);

        /// <summary> GS1 8-digit International Article Number (European Article Number). </summary>
        [CodeGenMember("EAN8")]
        public static DocumentBarcodeKind Ean8 { get; } = new DocumentBarcodeKind(Ean8Value);

        /// <summary> GS1 13-digit International Article Number (European Article Number). </summary>
        [CodeGenMember("EAN13")]
        public static DocumentBarcodeKind Ean13 { get; } = new DocumentBarcodeKind(Ean13Value);

        /// <summary> Interleaved 2 of 5 barcode, as defined in ANSI/AIM BC2-1995. </summary>
        [CodeGenMember("ITF")]
        public static DocumentBarcodeKind Itf { get; } = new DocumentBarcodeKind(ItfValue);

        /// <summary> Micro QR code, as defined in ISO/IEC 23941:2022. </summary>
        [CodeGenMember("MicroQRCode")]
        public static DocumentBarcodeKind MicroQrCode { get; } = new DocumentBarcodeKind(MicroQrCodeValue);
    }
}
