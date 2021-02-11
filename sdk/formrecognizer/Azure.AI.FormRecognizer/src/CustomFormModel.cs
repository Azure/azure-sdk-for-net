// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;

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
            ModelName = model.ModelInfo.ModelName;
            Status = model.ModelInfo.Status;
            TrainingStartedOn = model.ModelInfo.TrainingStartedOn;
            TrainingCompletedOn = model.ModelInfo.TrainingCompletedOn;
            Submodels = ConvertToSubmodels(model);
            TrainingDocuments = ConvertToTrainingDocuments(model);
            Errors = model.TrainResult?.Errors ?? new List<FormRecognizerError>();
            Properties = model.ModelInfo.Properties ?? new CustomFormModelProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormModel"/> class.
        /// </summary>
        /// <param name="modelId">The unique identifier of this model.</param>
        /// <param name="status">A status indicating this model's readiness for use.</param>
        /// <param name="trainingStartedOn">The date and time (UTC) when model training was started.</param>
        /// <param name="trainingCompletedOn">The date and time (UTC) when model training completed.</param>
        /// <param name="submodels">A list of submodels that are part of this model, each of which can recognize and extract fields from a different type of form.</param>
        /// <param name="trainingDocuments">A list of meta-data about each of the documents used to train the model.</param>
        /// <param name="errors">A list of errors occurred during the training operation.</param>
        /// <param name="modelName">An optional, user-defined name to associate with your model.</param>
        /// <param name="properties">Model properties, like for example, if a model is composed.</param>
        internal CustomFormModel(
            string modelId,
            CustomFormModelStatus status,
            DateTimeOffset trainingStartedOn,
            DateTimeOffset trainingCompletedOn,
            IReadOnlyList<CustomFormSubmodel> submodels,
            IReadOnlyList<TrainingDocumentInfo> trainingDocuments,
            IReadOnlyList<FormRecognizerError> errors,
            string modelName,
            CustomFormModelProperties properties)
        {
            ModelId = modelId;
            ModelName = modelName;
            Properties = properties;
            Status = status;
            TrainingStartedOn = trainingStartedOn;
            TrainingCompletedOn = trainingCompletedOn;
            Submodels = submodels;
            TrainingDocuments = trainingDocuments;
            Errors = errors;
        }

        /// <summary>
        /// The unique identifier of this model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// An optional, user-defined name to associate with your model.
        /// </summary>
        public string ModelName { get; }

        /// <summary>
        /// Properties of a model, such as whether the model is a composed model or not.
        /// </summary>
        [CodeGenMember("Attributes")]
        public CustomFormModelProperties Properties { get; }

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
        /// A list of errors occurred during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> Errors { get; }

        private static IReadOnlyList<CustomFormSubmodel> ConvertToSubmodels(Model model)
        {
            if (model.Keys != null)
                return ConvertFromUnlabeled(model);

            if (model.TrainResult != null)
                return ConvertFromLabeled(model);

            if (model.ComposedTrainResults != null)
                return ConvertFromLabeledComposedModel(model);

            return null;
        }

        private static IReadOnlyList<CustomFormSubmodel> ConvertFromUnlabeled(Model model)
        {
            var subModels = new List<CustomFormSubmodel>();

            foreach (var cluster in model.Keys.Clusters)
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
                    fieldMap,
                    model.ModelInfo.ModelId));
            }
            return subModels;
        }

        private static IReadOnlyList<CustomFormSubmodel> ConvertFromLabeled(Model model)
        {
            string formType = string.Empty;
            if (string.IsNullOrEmpty(model.ModelInfo.ModelName))
                formType = $"custom:{model.ModelInfo.ModelId}";
            else
                formType = $"custom:{model.ModelInfo.ModelName}";

            return new List<CustomFormSubmodel> {
                new CustomFormSubmodel(
                    formType,
                    model.TrainResult.AverageModelAccuracy,
                    CalculateFieldMap(model.TrainResult),
                    model.ModelInfo.ModelId) };
        }

        private static IReadOnlyList<CustomFormSubmodel> ConvertFromLabeledComposedModel(Model model)
        {
            var submodels = new List<CustomFormSubmodel>();

            foreach (var trainResult in model.ComposedTrainResults)
            {
                submodels.Add(new CustomFormSubmodel(
                    $"custom:{trainResult.ModelId}",
                    trainResult.AverageModelAccuracy,
                    CalculateFieldMap(trainResult),
                    trainResult.ModelId));
            }

            return submodels;
        }

        private static Dictionary<string, CustomFormModelField> CalculateFieldMap(TrainResult trainResult)
        {
            var fieldMap = new Dictionary<string, CustomFormModelField>();

            if (trainResult.Fields != null)
            {
                foreach (var formFieldsReport in trainResult.Fields)
                {
                    fieldMap.Add(formFieldsReport.Name, new CustomFormModelField(formFieldsReport.Name, null, formFieldsReport.Accuracy));
                }
            }

            return fieldMap;
        }

        private static IReadOnlyList<TrainingDocumentInfo> ConvertToTrainingDocuments(Model model)
        {
            var trainingDocs = new List<TrainingDocumentInfo>();

            // TrainResult can be null if model is not ready yet.
            if (!model.ModelInfo.Properties.IsComposedModel && model.TrainResult != null)
            {
                foreach (var document in model.TrainResult.TrainingDocuments)
                {
                    trainingDocs.Add(
                        new TrainingDocumentInfo(
                            document.Name,
                            document.PageCount,
                            document.Errors ?? new List<FormRecognizerError>(),
                            document.Status,
                            model.ModelInfo.ModelId));
                }
            }

            if (model.ModelInfo.Properties.IsComposedModel && model.ComposedTrainResults != null)
            {
                foreach (var trainResult in model.ComposedTrainResults)
                {
                    foreach (var document in trainResult.TrainingDocuments)
                    {
                        trainingDocs.Add(
                            new TrainingDocumentInfo(
                                document.Name,
                                document.PageCount,
                                document.Errors ?? new List<FormRecognizerError>(),
                                document.Status,
                                trainResult.ModelId));
                    }
                }
            }

            return trainingDocs;
        }
    }
}
