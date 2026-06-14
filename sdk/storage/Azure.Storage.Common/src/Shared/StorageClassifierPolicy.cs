// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// A per-call policy that wraps per-operation classifiers set by generated code
    /// with <see cref="StorageRetriableClassifier"/> to preserve storage-specific
    /// retry logic (e.g. 404 from secondary host is retriable).
    /// </summary>
    internal class StorageClassifierPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly StorageResponseClassifier _storageClassifier;

        public StorageClassifierPolicy(StorageResponseClassifier storageClassifier)
        {
            _storageClassifier = storageClassifier;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            // If the generated code replaced the pipeline's StorageResponseClassifier
            // with a per-operation classifier, wrap it to preserve storage retry logic.
            if (message.ResponseClassifier is not StorageResponseClassifier
                and not StorageRetriableClassifier)
            {
                message.ResponseClassifier = new StorageRetriableClassifier(
                    message.ResponseClassifier, _storageClassifier);
            }
        }
    }
}
