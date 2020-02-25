// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Summary of all trained custom models. </summary>
    public partial class ModelsSummary
    {
        /// <summary> Current count of trained custom models. </summary>
        public int Count { get; set; }
        /// <summary> Max number of models that can be trained for this subscription. </summary>
        public int Limit { get; set; }
        /// <summary> Date and time (UTC) when the summary was last updated. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; set; }
    }
}
