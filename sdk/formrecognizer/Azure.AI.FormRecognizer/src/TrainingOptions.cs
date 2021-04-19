// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// The set of options that can be specified when calling the training method
    /// to configure the behavior of the request. For example, set a filter to apply
    /// to the documents in the source path for training.
    /// </summary>
    public class TrainingOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingOptions"/> class which
        /// allows to set options that can be specified when calling the training method
        /// to configure the behavior of the request. For example, set a filter to apply
        /// to the documents for training.
        /// </summary>
        public TrainingOptions()
        {
        }

        /// <summary>
        /// Filter to apply to the documents in the source path for training.
        /// </summary>
        public TrainingFileFilter TrainingFileFilter { get; set; }
    }
}
