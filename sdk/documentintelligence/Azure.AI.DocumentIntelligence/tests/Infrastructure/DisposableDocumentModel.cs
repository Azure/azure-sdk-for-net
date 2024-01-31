// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DisposableDocumentModel : IAsyncDisposable
    {
        private readonly DocumentIntelligenceAdministrationClient _client;

        private DisposableDocumentModel(DocumentIntelligenceAdministrationClient client, Operation<DocumentModelDetails> operation)
        {
            _client = client;
            Operation = operation;
        }

        public Operation<DocumentModelDetails> Operation { get; }

        public DocumentModelDetails Value => Operation.Value;

        public string ModelId => Value.ModelId;

        public static async Task<DisposableDocumentModel> BuildAsync(DocumentIntelligenceAdministrationClient client, BuildDocumentModelContent buildContent)
        {
            Operation<DocumentModelDetails> operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, buildContent);

            return new DisposableDocumentModel(client, operation);
        }

        public async ValueTask DisposeAsync()
        {
            await _client.DeleteModelAsync(Value.ModelId);
        }
    }
}
