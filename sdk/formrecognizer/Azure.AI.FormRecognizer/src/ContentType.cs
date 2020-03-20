// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Form content type for local files.
    /// </summary>
    [CodeGenSchema("ContentType")]
    public enum ContentType
    {
        /// <summary>application/pdf</summary>
        [CodeGenSchemaMember("ApplicationPdf")]
        Pdf,

        /// <summary>image/png</summary>
        [CodeGenSchemaMember("ImagePng")]
        Png,

        /// <summary>image/jpeg</summary>
        [CodeGenSchemaMember("ImageJpeg")]
        Jpeg,

        /// <summary>image/tiff</summary>
        [CodeGenSchemaMember("ImageTiff")]
        Tiff,
    }
}
