// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a recognize custom form method
    /// to configure the behavior of the request.
    /// </summary>
    public class RecognizeCustomFormsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeCustomFormsOptions"/> class.
        /// </summary>
        public RecognizeCustomFormsOptions()
        {
        }

        /// <summary>
        /// Whether or not to include form elements such as lines and words in addition to form fields.
        /// </summary>
        public bool IncludeFieldElements { get; set; } = false;

        /// <summary>
        /// When set, specifies the content type for uploaded streams and skips automatic
        /// content type detection.
        /// </summary>
        public FormContentType? ContentType { get; set; } = null;
    }
}
