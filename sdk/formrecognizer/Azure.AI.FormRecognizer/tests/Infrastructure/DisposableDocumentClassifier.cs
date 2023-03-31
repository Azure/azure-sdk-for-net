// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Represents a classifier that has been built for test purposes. In order to create a new instance
    /// of this class, the <see cref="DisposableDocumentClassifier.BuildAsync"/> static method must be
    /// invoked. The trained classifier will be deleted upon disposal.
    /// </summary>
    internal class DisposableDocumentClassifier : IAsyncDisposable
    {
        /// <summary>The client to use for deleting the classifier upon disposal.</summary>
        private readonly DocumentModelAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDocumentClassifier"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the classifier upon disposal.</param>
        /// <param name="classifierId">The identifier of the classifier to delete upon disposal.</param>
        private DisposableDocumentClassifier(DocumentModelAdministrationClient adminClient, string classifierId)
        {
            _adminClient = adminClient;
            ClassifierId = classifierId;
        }

        /// <summary>
        /// The identifier of the classifier this instance is associated with. It will be deleted upon
        /// disposal.
        /// </summary>
        public string ClassifierId { get; }

        /// <summary>
        /// Builds a classifier using the specified <see cref="DocumentModelAdministrationClient"/> and the specified set of training files. A
        /// <see cref="DisposableDocumentClassifier"/> instance is returned. Upon disposal, the associated classifier will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for building and for deleting the classifier upon disposal.</param>
        /// <param name="documentTypes">A mapping to the training data of each document type supported by the classifier.</param>
        /// <param name="classifierId">The identifier of the classifier.</param>
        /// <returns>A <see cref="DisposableDocumentClassifier"/> instance from which the built classifier ID can be obtained.</returns>
        public static async Task<DisposableDocumentClassifier> BuildAsync(DocumentModelAdministrationClient adminClient, IDictionary<string, ClassifierDocumentTypeDetails> documentTypes, string classifierId)
        {
            BuildDocumentClassifierOperation operation = await adminClient.BuildDocumentClassifierAsync(WaitUntil.Completed, documentTypes, classifierId);

            return new DisposableDocumentClassifier(adminClient, operation.Value.ClassifierId);
        }

        /// <summary>
        /// Deletes the classifier this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDocumentClassifierAsync(ClassifierId);
    }
}
