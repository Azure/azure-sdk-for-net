// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// The set of options that can be specified when calling a recognition method in
    /// a <see cref="FormRecognizerClient" /> instance to configure the behavior of the
    /// request.
    /// </summary>
    public class RecognizeOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeOptions"/> class.
        /// </summary>
        public RecognizeOptions()
        {
        }

        /// <summary>
        /// Whether or not to include form content elements such as lines and words in addition to form fields.
        /// </summary>
        public bool IncludeFieldElements { get; set; } = false;

        /// <summary>
        /// When set, specifies the content type for uploaded streams and skips automatic
        /// content type detection.
        /// </summary>
        public FormContentType? ContentType { get; set; } = null;
    }
}
