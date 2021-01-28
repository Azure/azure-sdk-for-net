// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a Recognize Receipts method
    /// to configure the behavior of the request. For example, specify the content type of the
    /// form, the locale of the form, or whether or not to include form elements.
    /// </summary>
    public class RecognizeReceiptsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOptions"/> class which
        /// allows to set options that can be specified when calling a Recognize Receipts method
        /// to configure the behavior of the request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.
        /// </summary>
        public RecognizeReceiptsOptions()
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
        /// Locale value. Supported locales include: en-AU, en-CA, en-GB, en-IN, en-US.
        /// </summary>
        public string Locale { get; set; }
    }
}
