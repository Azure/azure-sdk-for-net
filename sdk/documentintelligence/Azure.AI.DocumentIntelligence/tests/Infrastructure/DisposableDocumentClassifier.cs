// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DisposableDocumentClassifier : IAsyncDisposable
    {
        private readonly DocumentIntelligenceAdministrationClient _client;

        private DisposableDocumentClassifier(DocumentIntelligenceAdministrationClient client, Operation<DocumentClassifierDetails> operation)
        {
            _client = client;
            Operation = operation;
        }

        public Operation<DocumentClassifierDetails> Operation { get; }

        public DocumentClassifierDetails Value => Operation.Value;

        public string ClassifierId => Value.ClassifierId;

        public static async Task<DisposableDocumentClassifier> BuildAsync(DocumentIntelligenceAdministrationClient client, BuildDocumentClassifierContent buildContent)
        {
            Operation<DocumentClassifierDetails> operation = await client.BuildClassifierAsync(WaitUntil.Completed, buildContent);

            return new DisposableDocumentClassifier(client, operation);
        }

        public async ValueTask DisposeAsync()
        {
            await _client.DeleteClassifierAsync(Value.ClassifierId);
        }
    }
}
