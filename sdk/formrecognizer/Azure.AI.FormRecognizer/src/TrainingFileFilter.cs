// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Used by the <see cref="FormTrainingClient"/> to filter the documents by name in the
    /// source path provided for training.
    /// </summary>
    [CodeGenModel("TrainSourceFilter")]
    public partial class TrainingFileFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingFileFilter"/> class which is
        /// used by the <see cref="FormTrainingClient"/> to filter the documents by name in the
        /// source path provided for training.
        /// </summary>
        public TrainingFileFilter()
        {
        }

        /// <summary>
        /// A case-sensitive prefix string to filter documents in the source path for training. For example,
        /// you may use the prefix to restrict subfolders for training.
        /// </summary>
        public string Prefix { get; set; } = string.Empty;

        /// <summary>
        /// A flag to indicate whether subfolders within the set of prefix folders should be included
        /// when searching for content to be preprocessed.
        /// </summary>
        [CodeGenMember("IncludeSubFolders")]
        public bool IncludeSubfolders { get; set; } = false;
    }
}
