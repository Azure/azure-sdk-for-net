// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    public class CustomModel
    {
        internal CustomModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            LearnedForms = ConvertLearnedForms(model.Keys);
            ModelInfo = new CustomModelInfo(model.ModelInfo);
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
        public CustomModelInfo ModelInfo { get; internal set; }

        /// <summary>
        /// </summary>
        public TrainingInfo TrainingInfo { get; internal set; }


        private static IReadOnlyList<CustomModelLearnedForm> ConvertLearnedForms(KeysResult_internal keys)
        {
            List<CustomModelLearnedForm> forms = new List<CustomModelLearnedForm>();

            foreach (var key in keys.Clusters)
            {
                CustomModelLearnedForm form = new CustomModelLearnedForm()
                {
                    FormTypeId = key.Key,
                    // TODO: Q3
                    // https://github.com/Azure/azure-sdk-for-net/issues/10360
                    LearnedFields = new List<string>(key.Value)
                };
                forms.Add(form);
            }

            return forms;
        }
    }
}
