// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Contains general information about a Cognitive Services Account, such as the number
    /// of models and account limits.
    /// </summary>
    public class AccountProperties
    {
        internal AccountProperties(ModelsSummary_internal summary)
        {
            CustomModelCount = summary.Count;
            CustomModelLimit = summary.Limit;
        }

        /// <summary>
        /// The current count of trained custom models.
        /// </summary>
        public int CustomModelCount { get; internal set; }

        /// <summary>
        /// The maximum number of models that can be trained for this subscription.
        /// </summary>
        public int CustomModelLimit { get; internal set; }
    }
}
