// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomModel
    {
        internal CustomModel()
        {
        }

        /// <summary>
        /// </summary>
        public string FormType { get; internal set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> Fields { get; internal set; }


        /// <summary>
        /// Information about the trained model, including model ID and training completion status.
        /// </summary>
        public CustomModelInfo ModelInfo { get; }

        /// <summary>
        /// Errors returned during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> Errors { get; internal set; }
    }
}
