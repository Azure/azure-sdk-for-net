// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when calling a Recognize Custom Forms method
    /// to configure the behavior of the request. For example, specify the content type of the
    /// form, or whether or not to include form elements.
    /// </summary>
    public class RecognizeCustomFormsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeCustomFormsOptions"/> class which
        /// allows to set options that can be specified when calling a Recognize Custom Forms method
        /// to configure the behavior of the request. For example, specify the content type of the
        /// form, or whether or not to include form elements.
        /// </summary>
        public RecognizeCustomFormsOptions()
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
    }
}
