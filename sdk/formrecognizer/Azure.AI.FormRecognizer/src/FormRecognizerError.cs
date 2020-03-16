// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    [CodeGenSchema("ErrorInformation")]
    public partial class FormRecognizerError
    {
        /// <summary>
        /// </summary>
        [CodeGenSchemaMember("Code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [CodeGenSchemaMember("Message")]
        public string Message { get; set; }
    }
}
