// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Represents a classifier that has been built for test purposes. In order to create a new instance
    /// of this class, the <see cref="BuildAsync"/> static method must be invoked. The built classifier
    /// will be deleted upon disposal.
    /// </summary>
    public class DisposableDocumentClassifier : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the classifier upon disposal.</summary>
        private readonly DocumentModelAdministrationClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDocumentClassifier"/> class.
        /// </summary>
        /// <param name="client">The client to use for deleting the classifier upon disposal.</param>
        /// <param name="operation">The operation that built the classifier this instance is associated with.</param>
        private DisposableDocumentClassifier(DocumentModelAdministrationClient client, BuildDocumentClassifierOperation operation)
        {
            _client = client;
            Operation = operation;
        }

        /// <summary>
        /// The operation that built the classifier this instance is associated with.
        /// </summary>
        public BuildDocumentClassifierOperation Operation { get; }

        /// <summary>
        /// The classifier this instance is associated with. It will be deleted upon disposal.
        /// </summary>
        public DocumentClassifierDetails Value => Operation.Value;

        /// <summary>
        /// The identifier of the classifier this instance is associated with.
        /// </summary>
        public string ClassifierId => Value.ClassifierId;

        /// <summary>
        /// Builds a classifier using the specified <see cref="DocumentModelAdministrationClient"/> and the specified set of training files. A
        /// <see cref="DisposableDocumentClassifier"/> instance is returned. Upon disposal, the associated classifier will be deleted.
        /// </summary>
        /// <param name="client">The client to use for building and for deleting the classifier upon disposal.</param>
        /// <param name="documentTypes">A mapping to the training data of each document type supported by the classifier.</param>
        /// <param name="classifierId">The identifier of the classifier.</param>
        /// <param name="description">An optional classifier description.</param>
        /// <returns>A <see cref="DisposableDocumentClassifier"/> instance from which the built classifier can be obtained.</returns>
        public static async Task<DisposableDocumentClassifier> BuildAsync(DocumentModelAdministrationClient client, IDictionary<string, ClassifierDocumentTypeDetails> documentTypes, string classifierId, string description = null)
        {
            BuildDocumentClassifierOperation operation = await client.BuildDocumentClassifierAsync(WaitUntil.Completed, documentTypes, classifierId, description);

            return new DisposableDocumentClassifier(client, operation);
        }

        /// <summary>
        /// Deletes the classifier this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _client.DeleteDocumentClassifierAsync(ClassifierId);
    }
}
