// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomModelLearnedForm
    {
        internal CustomModelLearnedForm()
        {
        }

        /// <summary>
        /// </summary>
        public string FormType { get; internal set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> LearnedFields { get; internal set; }
    }
}
