// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Represents a model that has been built for test purposes. In order to create a new instance
    /// of this class, the <see cref="DisposableBuildModel.BuildModelAsync"/> static method must be
    /// invoked. The trained model will be deleted upon disposal.
    /// </summary>
    /// <remarks>
    /// Please note that models can also be built using a graphical user interface
    /// such as the Form Recognizer Labeling Tool found here:
    /// <see href="https://aka.ms/azsdk/formrecognizer/labelingtool"/>.
    /// </remarks>
    public class DisposableBuildModel : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the model upon disposal.</summary>
        private readonly DocumentModelAdministrationClient _adminClient;

        /// <summary>
        /// The identifier of the model this instance is associated with. It will be deleted upon
        /// disposal.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableBuildModel"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the model upon disposal.</param>
        /// <param name="modelId">The identifier of the model to delete upon disposal.</param>
        private DisposableBuildModel(DocumentModelAdministrationClient adminClient, string modelId)
        {
            _adminClient = adminClient;
            ModelId = modelId;
        }

        /// <summary>
        /// Builds a model using the specified <see cref="DocumentModelAdministrationClient"/> and the specified set of training files. A
        /// <see cref="DisposableBuildModel"/> instance is returned. Upon disposal,
        /// the associated model will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for building and for deleting the model upon disposal.</param>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="buildMode">The technique to use to build the model.</param>
        /// <param name="modelId">Model Id.</param>
        /// <returns>A <see cref="DisposableBuildModel"/> instance from which the trained model ID can be obtained.</returns>
        public static async Task<DisposableBuildModel> BuildModelAsync(DocumentModelAdministrationClient adminClient, Uri trainingFilesUri, DocumentBuildMode buildMode, string modelId)
        {
            BuildDocumentModelOperation operation = await adminClient.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, buildMode, modelId);

            Assert.IsTrue(operation.HasValue);

            return new DisposableBuildModel(adminClient, operation.Value.ModelId);
        }

        /// <summary>
        /// Deletes the model this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDocumentModelAsync(ModelId);
    }
}
