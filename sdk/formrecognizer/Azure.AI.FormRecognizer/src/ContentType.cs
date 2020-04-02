// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Form content type for local files.
    /// </summary>
    [CodeGenModel("ContentType")]
    public enum ContentType
    {
        /// <summary>application/pdf</summary>
        [CodeGenMember("ApplicationPdf")]
        Pdf,

        /// <summary>image/png</summary>
        [CodeGenMember("ImagePng")]
        Png,

        /// <summary>image/jpeg</summary>
        [CodeGenMember("ImageJpeg")]
        Jpeg,

        /// <summary>image/tiff</summary>
        [CodeGenMember("ImageTiff")]
        Tiff,
    }
}
