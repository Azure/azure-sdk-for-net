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
        internal CustomFormModel(Model_internal model)
        {
            ModelId = model.ModelInfo.ModelId.ToString();
            Status = model.ModelInfo.Status;
            CreatedOn = model.ModelInfo.CreatedDateTime;
            LastModified = model.ModelInfo.LastUpdatedDateTime;
            Models = ConvertToSubmodels(model);
            TrainingDocuments = ConvertToTrainingDocuments(model.TrainResult);
            Errors = ConvertToFormRecognizerError(model.TrainResult);
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
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// The date and time (UTC) when model training completed.
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// A list of submodels that are part of this model, each of which can recognize and extract fields from a different type of form.
        /// </summary>
        public IReadOnlyList<CustomFormSubModel> Models { get; }

        /// <summary>
        /// A list of meta-data about each of the documents used to train the model.
        /// </summary>
        public IReadOnlyList<TrainingDocumentInfo> TrainingDocuments { get; }

        /// <summary>
        /// A list of errors ocurred during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> Errors { get; }

        private static IReadOnlyList<CustomFormSubModel> ConvertToSubmodels(Model_internal model)
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

            foreach (var cluster in keys.Clusters)
            {
                var fieldMap = new Dictionary<string, CustomFormModelField>();
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

            if (model.TrainResult.Fields != null)
            {
                foreach (var formFieldsReport in model.TrainResult.Fields)
                {
                    fieldMap.Add(formFieldsReport.Name, new CustomFormModelField(formFieldsReport.Name, null, formFieldsReport.Accuracy));
                }
            }

            return new List<CustomFormSubModel> {
                new CustomFormSubModel(
                    $"form-{model.ModelInfo.ModelId}",
                    model.TrainResult.AverageModelAccuracy,
                    fieldMap)};
        }

        private static IReadOnlyList<TrainingDocumentInfo> ConvertToTrainingDocuments(TrainResult_internal trainResult)
        {
            var trainingDocs = new List<TrainingDocumentInfo>();
            if (trainResult?.TrainingDocuments != null)
            {
                foreach (var docs in trainResult?.TrainingDocuments)
                {
                    trainingDocs.Add(
                        new TrainingDocumentInfo(
                            docs.DocumentName,
                            docs.PageCount,
                            docs.Errors ?? new List<FormRecognizerError>(),
                            docs.Status));
                }
            }
            return trainingDocs;
        }

        private static IReadOnlyList<FormRecognizerError> ConvertToFormRecognizerError(TrainResult_internal trainResult)
        {
            var errors = new List<FormRecognizerError>();
            foreach (var error in trainResult?.Errors)
            {
                errors.Add(new FormRecognizerError(error.Code, error.Message));
            }
            return errors;
        }
    }
}
