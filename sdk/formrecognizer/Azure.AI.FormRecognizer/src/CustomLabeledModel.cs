// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
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

        public string ModelId { get; }
        public float AveragePredictionAccuracy { get; }
        public IReadOnlyList<FieldPredictionAccuracy> PredictionAccuracies { get; }
        public TrainingInfo TrainingInfo { get; }
        public CustomModelInfo ModelInfo { get; }
    }
}
