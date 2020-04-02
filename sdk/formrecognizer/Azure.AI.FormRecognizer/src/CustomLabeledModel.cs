// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;
using System.Linq;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// Description of a custom model that was trained with labels.
    /// </summary>
    public class CustomLabeledModel
    {
        internal CustomLabeledModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            AveragePredictionAccuracy = model.TrainResult.AverageModelAccuracy.Value;
            PredictionAccuracies = (IReadOnlyList<FieldPredictionAccuracy>)model.TrainResult.Fields;
            ModelInfo = new CustomModelInfo(model.ModelInfo);
            TrainingInfo = new TrainingInfo(model.TrainResult);
        }

        /// <summary>
        /// The unique identifier of the model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// The mean of the prediction accuracies for each field.
        /// </summary>
        public float AveragePredictionAccuracy { get; }

        /// <summary>
        /// A collection of prediction accuracies per field.  These indicate the ability of the model
        /// to correctly predict the value of a field for a given label.
        /// </summary>
        public IReadOnlyList<FieldPredictionAccuracy> PredictionAccuracies { get; }

        /// <summary>
        /// Information about documents used to train the model and errors encountered during training.
        /// </summary>
        public TrainingInfo TrainingInfo { get; }

        /// <summary>
        /// Information about the trained model, including model ID and training completion status.
        /// </summary>
        public CustomModelInfo ModelInfo { get; }
    }
}
