// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a recognize content method
    /// to configure the behavior of the request.
    /// </summary>
    public class RecognizeContentOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeContentOptions"/> class.
        /// </summary>
        public RecognizeContentOptions()
        {
        }

        /// <summary>
        /// When set, specifies the content type for uploaded streams and skips automatic
        /// content type detection.
        /// </summary>
        public FormContentType? ContentType { get; set; } = null;

        /// <summary>
        /// Custom page numbers for multi-page documents(PDF/TIFF). Input the number of the
        /// pages you want to get OCR result. For a range of pages, use a hyphen.
        /// Separate each page or range with a comma.
        /// </summary>
        public IEnumerable<string> Pages { get; set; }
    }
}
