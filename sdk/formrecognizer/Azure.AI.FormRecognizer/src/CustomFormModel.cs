// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a model trained from custom forms.
    /// </summary>
    public class CustomFormModel
    {
        internal CustomFormModel(Model model)
        {
            ModelId = model.ModelInfo.ModelId;
            Status = model.ModelInfo.Status;
            TrainingStartedOn = model.ModelInfo.TrainingStartedOn;
            TrainingCompletedOn = model.ModelInfo.TrainingCompletedOn;
            Submodels = ConvertToSubmodels(model);

            // TrainResult can be null if model is not ready yet.

            TrainingDocuments = model.TrainResult != null
                ? ConvertToTrainingDocuments(model.TrainResult)
                : new List<TrainingDocumentInfo>();

            Errors = model.TrainResult?.Errors ?? new List<FormRecognizerError>();
        }

        /// <summary>
        /// The unique identifier of this model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// A status indicating this model's readiness for use.
        /// </summary>
        public CustomFormModelStatus Status { get; }

        /// <summary>
        /// The date and time (UTC) when model training was started.
        /// </summary>
        public DateTimeOffset TrainingStartedOn { get; }

        /// <summary>
        /// The date and time (UTC) when model training completed.
        /// </summary>
        public DateTimeOffset TrainingCompletedOn { get; }

        /// <summary>
        /// A list of submodels that are part of this model, each of which can recognize and extract fields from a different type of form.
        /// </summary>
        public IReadOnlyList<CustomFormSubmodel> Submodels { get; }

        /// <summary>
        /// A list of meta-data about each of the documents used to train the model.
        /// </summary>
        public IReadOnlyList<TrainingDocumentInfo> TrainingDocuments { get; }

        /// <summary>
        /// A list of errors ocurred during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> Errors { get; }

        private static IReadOnlyList<CustomFormSubmodel> ConvertToSubmodels(Model model)
        {
            if (model.Keys != null)
                return ConvertFromUnlabeled(model.Keys);

            if (model.TrainResult != null)
                return ConvertFromLabeled(model);

            return null;
        }

        private static IReadOnlyList<CustomFormSubmodel> ConvertFromUnlabeled(KeysResult keys)
        {
            var subModels = new List<CustomFormSubmodel>();

            foreach (var cluster in keys.Clusters)
            {
                var fieldMap = new Dictionary<string, CustomFormModelField>();
                for (int i = 0; i < cluster.Value.Count; i++)
                {
                    string fieldName = "field-" + i;
                    string fieldLabel = cluster.Value[i];
                    fieldMap.Add(fieldName, new CustomFormModelField(fieldName, fieldLabel, default));
                }
                subModels.Add(new CustomFormSubmodel(
                    $"form-{cluster.Key}",
                    default,
                    fieldMap));
            }
            return subModels;
        }

        private static IReadOnlyList<CustomFormSubmodel> ConvertFromLabeled(Model model)
        {
            var fieldMap = new Dictionary<string, CustomFormModelField>();

            if (model.TrainResult.Fields != null)
            {
                foreach (var formFieldsReport in model.TrainResult.Fields)
                {
                    fieldMap.Add(formFieldsReport.Name, new CustomFormModelField(formFieldsReport.Name, null, formFieldsReport.Accuracy));
                }
            }

            return new List<CustomFormSubmodel> {
                new CustomFormSubmodel(
                    $"form-{model.ModelInfo.ModelId}",
                    model.TrainResult.AverageModelAccuracy,
                    fieldMap)};
        }

        private static IReadOnlyList<TrainingDocumentInfo> ConvertToTrainingDocuments(TrainResult trainResult)
        {
            var trainingDocs = new List<TrainingDocumentInfo>();
            foreach (var docs in trainResult.TrainingDocuments)
            {
                trainingDocs.Add(
                    new TrainingDocumentInfo(
                        docs.Name,
                        docs.PageCount,
                        docs.Errors ?? new List<FormRecognizerError>(),
                        docs.Status));
            }
            return trainingDocs;
        }
    }
}
