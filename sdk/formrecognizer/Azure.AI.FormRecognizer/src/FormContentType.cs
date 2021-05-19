// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
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

        /// <summary>
        /// Used for BMP files.
        /// </summary>
        [CodeGenMember("ImageBmp")]
        Bmp,
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Small extensions, good to keep here.")]
    internal static class FormContentTypeExtension
    {
        /// <summary>
        /// Converts this instance into an equivalent <see cref="ContentType1"/>.
        /// </summary>
        /// <returns>The equivalent <see cref="ContentType1"/>.</returns>

        internal static ContentType1 ConvertToContentType1(this FormContentType type)
        {
            return type switch
            {
                FormContentType.Pdf => ContentType1.ApplicationPdf,
                FormContentType.Jpeg => ContentType1.ImageJpeg,
                FormContentType.Png => ContentType1.ImagePng,
                FormContentType.Tiff => ContentType1.ImageTiff,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown FormContentType value."),
            };
        }
    }
}
