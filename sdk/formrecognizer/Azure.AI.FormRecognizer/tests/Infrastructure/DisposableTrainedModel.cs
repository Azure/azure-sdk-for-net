// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// Represents a model that has been trained for test purposes. In order to create a new instance
    /// of this class, the <see cref="TrainModelAsync"/> static method must be invoked. By default, the
    /// trained model will be deleted on disposal.
    /// </summary>
    public class DisposableTrainedModel : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the model.</summary>
        private readonly FormTrainingClient _trainingClient;

        /// <summary>Whether the model should be deleted on disposal.</summary>
        private readonly bool _deleteOnDisposal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableTrainedModel"/> class.
        /// </summary>
        /// <param name="trainingClient">The client to use for deleting the model.</param>
        /// <param name="modelId">The identifier of the model to associate with this instance.</param>
        /// <param name="deleteOnDisposal">Whether the model should be deleted on disposal.</param>
        private DisposableTrainedModel(FormTrainingClient trainingClient, string modelId, bool deleteOnDisposal)
        {
            _trainingClient = trainingClient;
            _deleteOnDisposal = deleteOnDisposal;
            ModelId = modelId;
        }

        /// <summary>
        /// The identifier of the model this instance is associated with.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// Trains a model using the specified <see cref="FormTrainingClient"/> and the specified set of training files. A
        /// <see cref="DisposableTrainedModel"/> instance is returned, from which the model ID can be obtained. By default,
        /// the associated model will be deleted on disposal.
        /// </summary>
        /// <param name="trainingClient">The client to use for training and for deleting the model.</param>
        /// <param name="trainingFilesUri">An externally accessible Azure Blob Storage container URI.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="modelName">Optional model name.</param>
        /// <param name="deleteOnDisposal">Whether the model should be deleted on disposal.</param>
        /// <returns>A <see cref="DisposableTrainedModel"/> instance from which the trained model ID can be obtained.</returns>
        public static async Task<DisposableTrainedModel> TrainModelAsync(FormTrainingClient trainingClient, Uri trainingFilesUri, bool useTrainingLabels, string modelName = default, bool deleteOnDisposal = true)
        {
            TrainingOperation operation = await trainingClient.StartTrainingAsync(trainingFilesUri, useTrainingLabels, modelName);
            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, operation.Value.Status);

            return new DisposableTrainedModel(trainingClient, operation.Value.ModelId, deleteOnDisposal);
        }

        /// <summary>
        /// Deletes the model this instance is associated with.
        /// </summary>
        public async Task DeleteModelAsync()
        {
            await _trainingClient.DeleteModelAsync(ModelId);
        }

        /// <summary>
        /// If deletion on disposal is enabled, deletes the model this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (_deleteOnDisposal)
            {
                await DeleteModelAsync();
            }
        }
    }
}
