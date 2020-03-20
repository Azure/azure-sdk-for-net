// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    public class CustomModelLearnedPage
    {
        internal CustomModelLearnedPage()
        {
        }

        /// <summary>
        /// </summary>
        public string FormTypeId { get; internal set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> LearnedFields { get; internal set; }
    }
}
