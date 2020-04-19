// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    [CodeGenModel("TrainSourceFilter")]
    public partial class TrainingFileFilter
    {
        internal TrainingFileFilter()
        {
        }

        /// <inheritdoc />
        public string Prefix { get; set; } = string.Empty;

        /// <inheritdoc />
        public bool IncludeSubFolders { get; set; } = false;

    }
}
