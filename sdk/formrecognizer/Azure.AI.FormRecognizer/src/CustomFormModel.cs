// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a custom model returned from training.
    /// </summary>
    public class CustomFormModel
    {
        internal CustomFormModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            Status = model.ModelInfo.Status;
            CreatedOn = model.ModelInfo.CreatedDateTime;
            LastModified = model.ModelInfo.LastUpdatedDateTime;
            Models = ConvertToSubmodel(model);
            TrainingDocuments = model.TrainResult.TrainingDocuments;
        }

        /// <summary>
        /// Model identifier.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// The status of the model.
        /// </summary>
        public CustomFormModelStatus Status { get; }

        /// <summary>
        /// Date and time (UTC) when the model was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Date and time (UTC) when the status was last updated.
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// A list of submodels which contains the fields trained on.
        /// </summary>
        public IReadOnlyList<CustomFormSubModel> Models { get; }

        /// <summary>
        ///  Training document information about the custom model.
        /// </summary>
        // TODO: for composed models, union what comes back on submodels into this single list.
        public IReadOnlyList<TrainingDocumentInfo> TrainingDocuments { get; }

        private static IReadOnlyList<CustomFormSubModel> ConvertToSubmodel(Model_internal model)
        {
            if (model.Keys != null)
                return ConvertFromUnlabeled(model.Keys);

            if (model.TrainResult != null)
                return ConvertFromLabeled(model);

            return null;
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

        private static IReadOnlyList<CustomFormSubModel> ConvertFromLabeled(Model_internal model)
        {
            var fieldMap = new Dictionary<string, CustomFormModelField>();
            foreach (var formFieldsReport in model.TrainResult.Fields)
            {
                fieldMap.Add(formFieldsReport.Name, new CustomFormModelField(formFieldsReport.Name, null, formFieldsReport.Accuracy));
            }

            return new List<CustomFormSubModel> {
                new CustomFormSubModel(
                    $"form-{model.ModelInfo.ModelId}",
                    model.TrainResult.AverageModelAccuracy,
                    fieldMap)};
        }
    }
}
