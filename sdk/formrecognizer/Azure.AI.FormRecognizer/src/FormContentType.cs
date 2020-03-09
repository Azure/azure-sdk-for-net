// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Form content type for local files.
    /// </summary>
    public enum FormContentType
    {
        /// <summary>application/pdf</summary>
        Pdf = 1,

        /// <summary>image/png</summary>
        Png = 2,

        /// <summary>image/jpeg</summary>
        Jpeg = 3,

        /// <summary>image/tiff</summary>
        Tiff = 4,
    }
}
