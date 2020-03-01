// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public class CustomModel
    {
        internal CustomModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            LearnedForms = SetLearnedForms(model.Keys);
            TrainingStatus = new CustomModelTrainingStatus(model.ModelInfo);
            TrainingInfo = new TrainingInfo(model.TrainResult);
        }

        /// <summary>
        /// </summary>
        public string ModelId { get; internal set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<CustomModelLearnedForm> LearnedForms { get; internal set; }

        /// <summary>
        /// </summary>
        public CustomModelTrainingStatus TrainingStatus { get; internal set; }

        /// <summary>
        /// </summary>
        public TrainingInfo TrainingInfo { get; internal set; }


        private IReadOnlyList<CustomModelLearnedForm> SetLearnedForms(KeysResult_internal keys)
        {
            List<CustomModelLearnedForm> forms = new List<CustomModelLearnedForm>();

            foreach (var key in keys.Clusters)
            {
                CustomModelLearnedForm form = new CustomModelLearnedForm()
                {
                    FormTypeId = key.Key,
                    // TODO: Q3
                    LearnedFields = new List<string>(key.Value).AsReadOnly()
                };
                forms.Add(form);
            }

            return forms.AsReadOnly();
        }
    }
}
