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
            PredictionAccuracies = ConvertLabelAccuracies(model.TrainResult.Fields);
            TrainingStatus = new CustomModelTrainingStatus(model.ModelInfo);
            TrainingInfo = new TrainingInfo(model.TrainResult);
        }

        public string ModelId { get; }
        public float AveragePredictionAccuracy { get; }
        public IReadOnlyList<FieldPredictionAccuracy> PredictionAccuracies { get; }
        public TrainingInfo TrainingInfo { get; }
        public CustomModelTrainingStatus TrainingStatus { get; }

        private static IReadOnlyList<FieldPredictionAccuracy> ConvertLabelAccuracies(ICollection<FormFieldsReport_internal> fields)
        {
            List<FieldPredictionAccuracy> accuracies = new List<FieldPredictionAccuracy>();
            foreach (FormFieldsReport_internal field in fields)
            {
                FieldPredictionAccuracy accuracy = new FieldPredictionAccuracy(field);
                accuracies.Add(accuracy);
            }

            return accuracies;
        }
    }
}
