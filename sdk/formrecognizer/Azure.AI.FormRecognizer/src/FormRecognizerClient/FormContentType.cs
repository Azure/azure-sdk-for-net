// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The content type for local form files.
    /// </summary>
    public enum FormContentType
    {
        /// <summary>
        /// Used for JSON files.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Json,

        /// <summary>
        /// Used for PDF files.
        /// </summary>
        Pdf,

        /// <summary>
        /// Used for PNG files.
        /// </summary>
        Png,

        /// <summary>
        /// Used for JPEG files.
        /// </summary>
        Jpeg,

        /// <summary>
        /// Used for TIFF files.
        /// </summary>
        Tiff,

        /// <summary>
        /// Used for BMP files.
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        Bmp
    }
}
