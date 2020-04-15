// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("ErrorInformation")]
    public partial class FormRecognizerError
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("Code")]
        public string Code { get; internal set; }

        /// <summary>
        /// </summary>
        [CodeGenMember("Message")]
        public string Message { get; internal set; }
    }
}
