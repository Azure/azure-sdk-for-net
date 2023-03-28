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
        /// When set, specifies the order in which the recognized text lines are returned. As the sorting
        /// order depends on the detected text, it may change across images and OCR version updates. Thus,
        /// business logic should be built upon the actual line location instead of order.
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        public FormReadingOrder? ReadingOrder { get; set; }

        /// <summary>
        /// The BCP-47 language code of the text in the document.
        /// Recognize Content supports auto language identification and multi language documents, so only
        /// provide a language code if you would like to force the documented to be processed as
        /// that specific language.
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        public FormRecognizerLanguage? Language { get; set; }

        /// <summary>
        /// <para>
        /// Custom page numbers for multi-page documents(PDF/TIFF). Input the page numbers
        /// and/or ranges of pages you want to get in the result. For a range of pages, use a hyphen, like
        /// `Pages = { "1-3", "5-6" }`. Separate each page number or range with a comma.
        /// </para>
        /// <para>
        /// Although this collection cannot be set, it can be modified.
        /// See <see href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-collection-read-only-property-initialization">Object initializers with collection read-only property initialization</see>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        public IList<string> Pages { get; } = new List<string>();
    }
}
