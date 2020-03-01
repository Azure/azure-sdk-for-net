// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    public class CustomLabeledModel
    {
        internal CustomLabeledModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            AverageLabelAccuracy = model.TrainResult.AverageModelAccuracy.Value;
            LabelAccuracies = SetLabelAccuracies(model.TrainResult.Fields);
            TrainingStatus = new ModelTrainingStatus(model.ModelInfo);
            TrainingInfo = new TrainingInfo(model.TrainResult);
        }

        public string ModelId { get; internal set; }
        public float AverageLabelAccuracy { get; internal set; }
        public IReadOnlyList<LabeledFieldAccuracy> LabelAccuracies { get; internal set; }
        public TrainingInfo TrainingInfo { get; internal set; }
        public ModelTrainingStatus TrainingStatus { get; internal set; }

        private static IReadOnlyList<LabeledFieldAccuracy> SetLabelAccuracies(ICollection<FormFieldsReport> fields)
        {
            List<LabeledFieldAccuracy> accuracies = new List<LabeledFieldAccuracy>();
            foreach (FormFieldsReport field in fields)
            {
                LabeledFieldAccuracy accuracy = new LabeledFieldAccuracy(field);
                accuracies.Add(accuracy);
            }

            return accuracies.AsReadOnly();
        }
    }
}
