// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Represents a model that has been built for test purposes. In order to create a new instance
    /// of this class, the <see cref="BuildAsync"/> static method must be invoked. The built
    /// model will be deleted upon disposal.
    /// </summary>
    public class DisposableDocumentModel : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the model upon disposal.</summary>
        private readonly DocumentModelAdministrationClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDocumentModel"/> class.
        /// </summary>
        /// <param name="client">The client to use for deleting the model upon disposal.</param>
        /// <param name="value">The model to associate with this instance. It will be deleted upon disposal.</param>
        private DisposableDocumentModel(DocumentModelAdministrationClient client, DocumentModelDetails value)
        {
            _client = client;
            Value = value;
        }

        /// <summary>
        /// The model this instance is associated with. It will be deleted upon disposal.
        /// </summary>
        public DocumentModelDetails Value { get; }

        /// <summary>
        /// The identifier of the model this instance is associated with.
        /// </summary>
        public string ModelId => Value.ModelId;

        /// <summary>
        /// Builds a model using the specified <see cref="DocumentModelAdministrationClient"/> and the specified set of training files. A
        /// <see cref="DisposableDocumentModel"/> instance is returned. Upon disposal, the associated model will be deleted.
        /// </summary>
        /// <param name="client">The client to use for building and for deleting the model upon disposal.</param>
        /// <param name="trainingFilesUri">An externally accessible Azure Blob Storage container URI.</param>
        /// <param name="buildMode">The technique to use to build the model.</param>
        /// <param name="modelId">The identifier of the model.</param>
        /// <param name="options">A set of options to apply when configuring the request.</param>
        /// <returns>A <see cref="DisposableDocumentModel"/> instance from which the built model ID can be obtained.</returns>
        public static async Task<DisposableDocumentModel> BuildAsync(DocumentModelAdministrationClient client, Uri trainingFilesUri, DocumentBuildMode buildMode, string modelId, BuildDocumentModelOptions options = null)
        {
            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, buildMode, modelId, options: options);

            return new DisposableDocumentModel(client, operation.Value);
        }

        /// <summary>
        /// Deletes the model this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _client.DeleteDocumentModelAsync(ModelId);
    }
}
