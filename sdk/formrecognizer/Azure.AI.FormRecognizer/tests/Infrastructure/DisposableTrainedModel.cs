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
    /// of this class, the <see cref="DisposableTrainedModel.TrainModelAsync"/> static method must be
    /// invoked. The trained model will be deleted upon disposal.
    /// </summary>
    /// <remarks>
    /// Please note that models can also be trained using a graphical user interface
    /// such as the Form Recognizer Labeling Tool found here:
    /// <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/label-tool"/>.
    /// </remarks>
    public class DisposableTrainedModel : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the model upon disposal.</summary>
        private readonly FormTrainingClient _trainingClient;

        /// <summary>
        /// The identifier of the model this instance is associated with. It will be deleted upon
        /// disposal.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableTrainedModel"/> class.
        /// </summary>
        /// <param name="trainingClient">The client to use for deleting the model upon disposal.</param>
        /// <param name="modelId">The identifier of the model to delete upon disposal.</param>
        private DisposableTrainedModel(FormTrainingClient trainingClient, string modelId)
        {
            _trainingClient = trainingClient;
            ModelId = modelId;
        }

        /// <summary>
        /// Trains a model using the specified <see cref="FormTrainingClient"/> and the specified set of training files. A
        /// <see cref="DisposableTrainedModel"/> instance is returned, from which the model ID can be obtained. Upon disposal,
        /// the associated model will be deleted.
        /// </summary>
        /// <param name="trainingClient">The client to use for training and for deleting the model upon disposal.</param>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="pollingInterval">Polling interval value to use.</param>
        /// <param name="modelName">Optional model name.</param>
        /// <returns>A <see cref="DisposableTrainedModel"/> instance from which the trained model ID can be obtained.</returns>
        public static async Task<DisposableTrainedModel> TrainModelAsync(FormTrainingClient trainingClient, Uri trainingFilesUri, bool useTrainingLabels, TimeSpan pollingInterval, string modelName = default)
        {
            TrainingOperation operation = await trainingClient.StartTrainingAsync(trainingFilesUri, useTrainingLabels, modelName);
            await operation.WaitForCompletionAsync(pollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, operation.Value.Status);

            return new DisposableTrainedModel(trainingClient, operation.Value.ModelId);
        }

        /// <summary>
        /// Deletes the model this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _trainingClient.DeleteModelAsync(ModelId);
    }
}
