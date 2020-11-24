// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a recognize business cards method
    /// to configure the behavior of the request.
    /// </summary>
    public class RecognizeBusinessCardsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeBusinessCardsOptions"/> class.
        /// </summary>
        public RecognizeBusinessCardsOptions()
        {
        }

        /// <summary>
        /// Whether or not to include form elements such as lines and words in addition to form fields.
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
