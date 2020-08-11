// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a recognition content method
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
    }
}
