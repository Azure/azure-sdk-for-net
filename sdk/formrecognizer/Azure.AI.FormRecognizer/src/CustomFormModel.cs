// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomFormModel
    {
        internal CustomFormModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            Status = model.ModelInfo.Status;
            CreatedOn = model.ModelInfo.CreatedDateTime;
            LastModified = model.ModelInfo.LastUpdatedDateTime;
            Models = ConvertToModels(model.Keys);
            TrainingDocuments = model.TrainResult.TrainingDocuments;
        }

        /// <summary>
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// </summary>
        public CustomFormModelStatus Status { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<CustomFormSubModel> Models { get; }

        /// <summary>
        /// </summary>
        // TODO: for composed models, union what comes back on submodels into this single list.
        public IReadOnlyList<TrainingDocumentInfo> TrainingDocuments { get; }

        private static IReadOnlyList<CustomFormSubModel> ConvertToModels(KeysResult_internal keys)
        {
            return keys != null ? ConvertFromUnlabeled(keys) : ConvertFromLabeled(keys);
        }

        private static IReadOnlyList<CustomFormSubModel> ConvertFromUnlabeled(KeysResult_internal keys)
        {
            var subModels = new List<CustomFormSubModel>();

            var fieldMap = new Dictionary<string, CustomFormModelField>();
            foreach (var cluster in keys.Clusters)
            {
                for (int i = 0; i < cluster.Value.Count; i++)
                {
                    string fieldName = "field-" + i;
                    string fieldLabel = cluster.Value[i];
                    fieldMap.Add(fieldName, new CustomFormModelField(fieldName, fieldLabel, default));
                }
                subModels.Add(new CustomFormSubModel(
                    $"form-{cluster.Key}",
                    default,
                    fieldMap));
            }
            return subModels;
        }

        private static IReadOnlyList<CustomFormSubModel> ConvertFromLabeled(KeysResult_internal keys)
        {
            return null;
        }
    }
}
