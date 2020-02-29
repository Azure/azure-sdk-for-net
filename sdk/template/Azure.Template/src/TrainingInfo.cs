// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class TrainingInfo
    {
        private TrainResult_internal trainResult;

        internal TrainingInfo(TrainResult_internal trainResult)
        {
            this.trainResult = trainResult;

            // TODO: Q3 Can we get a List instead of a Collection?
            this.PerDocumentInfo = new List<TrainingDocumentInfo>(trainResult.TrainingDocuments).AsReadOnly();
            this.TrainingErrors = new List<FormRecognizerError>(trainResult.Errors).AsReadOnly();
        }

        /// <summary>
        /// List of the documents used to train the model and any errors reported in each document.
        /// </summary>
        public IReadOnlyList<TrainingDocumentInfo> PerDocumentInfo { get; internal set; }

        /// <summary>
        /// Errors returned during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> TrainingErrors { get; internal set; }
    }
}
