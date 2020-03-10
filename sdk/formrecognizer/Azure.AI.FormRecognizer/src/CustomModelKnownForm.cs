// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Custom
{
    public class CustomModelLearnedForm
    {
        /// <summary>
        /// </summary>
        public string FormTypeId { get; internal set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> LearnedFields { get; internal set; }
    }
}
