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
            AverageLabelAccuracy = model.TrainResult.AverageModelAccuracy.Value;
            LabelAccuracies = ConvertLabelAccuracies(model.TrainResult.Fields);
            TrainingStatus = new CustomModelTrainingStatus(model.ModelInfo);
            TrainingInfo = new TrainingInfo(model.TrainResult);
        }

        public string ModelId { get; }
        public float AverageLabelAccuracy { get; }
        public IReadOnlyList<LabeledFieldAccuracy> LabelAccuracies { get; }
        public TrainingInfo TrainingInfo { get; }
        public CustomModelTrainingStatus TrainingStatus { get; }

        private static IReadOnlyList<LabeledFieldAccuracy> ConvertLabelAccuracies(ICollection<FormFieldsReport_internal> fields)
        {
            List<LabeledFieldAccuracy> accuracies = new List<LabeledFieldAccuracy>();
            foreach (FormFieldsReport_internal field in fields)
            {
                LabeledFieldAccuracy accuracy = new LabeledFieldAccuracy(field);
                accuracies.Add(accuracy);
            }

            return accuracies;
        }
    }
}
