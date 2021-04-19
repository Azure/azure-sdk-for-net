﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a Recognize Invoices method
    /// to configure the behavior of the request. For example, specify the content type of the
    /// form, the locale of the form, or whether or not to include form elements.
    /// </summary>
    public class RecognizeInvoicesOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeInvoicesOptions"/> class which
        /// allows to set options that can be specified when calling a Recognize Invoices method
        /// to configure the behavior of the request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.
        /// </summary>
        public RecognizeInvoicesOptions()
        {
        }

        /// <summary>
        /// Whether or not to include all lines per page and field elements such as lines, words,
        /// and selection marks for each form field.
        /// </summary>
        public bool IncludeFieldElements { get; set; }

        /// <summary>
        /// When set, specifies the content type for uploaded streams and skips automatic
        /// content type detection.
        /// </summary>
        public FormContentType? ContentType { get; set; }

        /// <summary>
        /// Sets the locale information for the invoice.
        /// Supported locales include: en-US.
        /// </summary>
        public FormRecognizerLocale? Locale { get; set; }

        /// <summary>
        /// <para>
        /// Custom page numbers for multi-page documents(PDF/TIFF). Input the page numbers
        /// and/or ranges of pages you want to get in the result. For a range of pages, use a hyphen, like
        /// `Pages = { "1-3", "5-6" }`. Separate each page number or range with a comma.
        /// </para>
        /// <para>
        /// Although this collection cannot be set, it can be modified.
        /// See <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers">collection initializer</a>.
        /// </para>
        /// </summary>
        public IList<string> Pages { get; } = new List<string>();
    }
}
