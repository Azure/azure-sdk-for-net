// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Template.Models
{
    /// <summary> Request parameter to train a new custom model. </summary>
    public partial class TrainRequest
    {
        /// <summary> Source path containing the training documents. </summary>
        public string Source { get; set; }
        /// <summary> Filter to apply to the documents in the source path for training. </summary>
        public TrainSourceFilter SourceFilter { get; set; }
        /// <summary> Use label file for training a model. </summary>
        public bool? UseLabelFile { get; set; }
    }
}
