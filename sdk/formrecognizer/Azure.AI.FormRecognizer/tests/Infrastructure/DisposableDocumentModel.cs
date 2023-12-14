// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Represents a model that has been built for test purposes. In order to create a new instance
    /// of this class, the <see cref="BuildAsync"/> static method must be invoked. By default, the
    /// built model will be deleted on disposal.
    /// </summary>
    public class DisposableDocumentModel : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the model.</summary>
        private readonly DocumentModelAdministrationClient _client;

        /// <summary>Whether the model should be deleted on disposal.</summary>
        private readonly bool _deleteOnDisposal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDocumentModel"/> class.
        /// </summary>
        /// <param name="client">The client to use for deleting the model.</param>
        /// <param name="operation">The operation that built the model this instance is associated with.</param>
        /// <param name="deleteOnDisposal">Whether the model should be deleted on disposal.</param>
        private DisposableDocumentModel(DocumentModelAdministrationClient client, BuildDocumentModelOperation operation, bool deleteOnDisposal)
        {
            _client = client;
            _deleteOnDisposal = deleteOnDisposal;
            Operation = operation;
        }

        /// <summary>
        /// The operation that built the model this instance is associated with.
        /// </summary>
        public BuildDocumentModelOperation Operation { get; }

        /// <summary>
        /// The model this instance is associated with.
        /// </summary>
        public DocumentModelDetails Value => Operation.Value;

        /// <summary>
        /// The identifier of the model this instance is associated with.
        /// </summary>
        public string ModelId => Value.ModelId;

        /// <summary>
        /// Builds a model using the specified <see cref="DocumentModelAdministrationClient"/> and the specified set of training files. A
        /// <see cref="DisposableDocumentModel"/> instance is returned. By default, the associated model will be deleted on disposal.
        /// </summary>
        /// <param name="client">The client to use for building and for deleting the model.</param>
        /// <param name="trainingFilesUri">An externally accessible Azure Blob Storage container URI.</param>
        /// <param name="buildMode">The technique to use to build the model.</param>
        /// <param name="modelId">The identifier of the model.</param>
        /// <param name="options">A set of options to apply when configuring the request.</param>
        /// <param name="deleteOnDisposal">Whether the model should be deleted on disposal.</param>
        /// <returns>A <see cref="DisposableDocumentModel"/> instance from which the built model can be obtained.</returns>
        public static async Task<DisposableDocumentModel> BuildAsync(DocumentModelAdministrationClient client, Uri trainingFilesUri, DocumentBuildMode buildMode, string modelId, BuildDocumentModelOptions options = null, bool deleteOnDisposal = true)
        {
            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, buildMode, modelId, options: options);

            return new DisposableDocumentModel(client, operation, deleteOnDisposal);
        }

        /// <summary>
        /// Deletes the model this instance is associated with.
        /// </summary>
        public async Task DeleteAsync()
        {
            await _client.DeleteDocumentModelAsync(ModelId);
        }

        /// <summary>
        /// If deletion on disposal is enabled, deletes the model this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (_deleteOnDisposal)
            {
                await DeleteAsync();
            }
        }
    }
}
