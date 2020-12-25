// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The content type for local form files.
    /// </summary>
    [CodeGenModel("ContentType")]
    public enum FormContentType
    {
        /// <summary>
        /// Used for JSON files.
        /// </summary>
        [CodeGenMember("ApplicationJson")]
        Json,

        /// <summary>
        /// Used for PDF files.
        /// </summary>
        [CodeGenMember("ApplicationPdf")]
        Pdf,

        /// <summary>
        /// Used for PNG files.
        /// </summary>
        [CodeGenMember("ImagePng")]
        Png,

        /// <summary>
        /// Used for JPEG files.
        /// </summary>
        [CodeGenMember("ImageJpeg")]
        Jpeg,

        /// <summary>
        /// Used for TIFF files.
        /// </summary>
        [CodeGenMember("ImageTiff")]
        Tiff,
    }
}
