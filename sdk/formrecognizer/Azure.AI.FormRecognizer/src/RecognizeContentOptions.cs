// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a Recognize Content method
    /// to configure the behavior of the request. For example, specify the content type of the
    /// form, the language of the form, and which pages in a multi-page document to analyze.
    /// </summary>
    public class RecognizeContentOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeContentOptions"/> class which
        /// allows to set options that can be specified when calling a Recognize Content method
        /// to configure the behavior of the request. For example, specify the content type of the
        /// form, the language of the form, and which pages in a multi-page document to analyze.
        /// </summary>
        public RecognizeContentOptions()
        {
        }

        /// <summary>
        /// When set, specifies the content type for uploaded streams and skips automatic
        /// content type detection.
        /// </summary>
        public FormContentType? ContentType { get; set; }

        /// <summary>
        /// The BCP-47 language code of the text in the document.
        /// Recognize Content supports auto language identification and multi language documents, so only
        /// provide a language code if you would like to force the documented to be processed as
        /// that specific language.
        /// <para>See supported language codes <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/language-support">here</a>.</para>
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Custom page numbers for multi-page documents(PDF/TIFF). Input the number of the
        /// pages you want to get OCR result. For a range of pages, use a hyphen.
        /// Separate each page or range with a comma.
        /// </summary>
        public IEnumerable<string> Pages { get; set; }
    }
}
