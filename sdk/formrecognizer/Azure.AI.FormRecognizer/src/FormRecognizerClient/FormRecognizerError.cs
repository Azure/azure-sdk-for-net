// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents an error that occurred during an operation in the Form Recognizer Azure
    /// Cognitive Service.
    /// </summary>
    [CodeGenModel("ErrorInformation")]
    public partial class FormRecognizerError
    {
        /// <summary>
        /// The error code.
        /// </summary>
        [CodeGenMember("Code")]
        public string ErrorCode { get; }

        /// <summary>
        /// The error message.
        /// </summary>
        [CodeGenMember("Message")]
        public string Message { get; }
    }
}
