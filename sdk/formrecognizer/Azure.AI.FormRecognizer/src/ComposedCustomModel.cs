// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomComposedModel
    {
        internal CustomComposedModel()
        {
        }

        /// <summary>
        /// Information about the trained model, including model ID and training completion status.
        /// </summary>
        public CustomModelInfo ModelInfo { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<CustomLabeledModel> Models { get; }
    }
}
