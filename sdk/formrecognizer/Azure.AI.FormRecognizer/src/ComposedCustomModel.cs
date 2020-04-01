// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomFormModel
    {
        internal CustomFormModel()
        {
        }

        /// <summary>
        /// Information about the trained model, including model ID and training completion status.
        /// </summary>
        public CustomFormModelInfo ModelInfo { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<CustomFormSubModel> Models { get; }

        /// <summary>
        /// Errors returned during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> Errors { get; internal set; }
    }
}
