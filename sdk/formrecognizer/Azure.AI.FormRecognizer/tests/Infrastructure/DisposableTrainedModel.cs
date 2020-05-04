// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class DisposableTrainedModel : IAsyncDisposable
    {
        private readonly FormTrainingClient _trainingClient;

        public string ModelId { get; }

        private DisposableTrainedModel(FormTrainingClient trainingClient, string modelId)
        {
            _trainingClient = trainingClient;
            ModelId = modelId;
        }

        public static async Task<DisposableTrainedModel> TrainModel(FormTrainingClient trainingClient, Uri trainingFiles, bool useLabels)
        {
            TrainingOperation operation = await trainingClient.StartTrainingAsync(trainingFiles, useLabels);
            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, operation.Value.Status);

            return new DisposableTrainedModel(trainingClient, operation.Value.ModelId);
        }

        public async ValueTask DisposeAsync() => await _trainingClient.DeleteModelAsync(ModelId);
    }
}
