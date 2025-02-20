// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The set of options that can be specified when calling an Analyze Document method
    /// to configure the behavior of the request. For example, specify the locale of the
    /// document, or which pages to analyze.
    /// </summary>
    public class AnalyzeDocumentOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeDocumentOptions"/> class which
        /// allows to set options that can be specified when calling a Analyze Document method
        /// to configure the behavior of the request. For example, specify the locale of the
        /// document, or which pages to analyze.
        /// </summary>
        public AnalyzeDocumentOptions()
        {
        }

        /// <summary>
        /// Sets the locale information for the document.
        /// See the <see href="https://aka.ms/azsdk/formrecognizer/supportedlocales">service documentation</see> for a complete list of supported locales.
        /// </summary>
        public string Locale { get; set; }

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
        public IList<string> Pages { get; } = new List<string>();

        /// <summary>
        /// The add-on capabilities to enable during document analysis.
        /// For more information, see <see href="https://aka.ms/azsdk/formrecognizer/features">Azure Form Recognizer add-on capabilities</see>.
        /// </summary>
        public IList<DocumentAnalysisFeature> Features { get; } = new List<DocumentAnalysisFeature>();
    }
}
