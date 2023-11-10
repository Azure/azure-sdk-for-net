// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DisposableDocumentModel : IAsyncDisposable
    {
        private readonly DocumentModelAdministrationClient _client;

        private DisposableDocumentModel(DocumentModelAdministrationClient client, Operation<DocumentModelDetails> operation)
        {
            _client = client;
            Operation = operation;
        }

        public Operation<DocumentModelDetails> Operation { get; }

        public DocumentModelDetails Value => Operation.Value;

        public string ModelId => Value.ModelId;

        public static async Task<DisposableDocumentModel> BuildAsync(DocumentModelAdministrationClient client, BuildDocumentModelRequest buildRequest)
        {
            Operation<DocumentModelDetails> operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, buildRequest);

            return new DisposableDocumentModel(client, operation);
        }

        public async ValueTask DisposeAsync()
        {
            await _client.DeleteModelAsync(Value.ModelId);
        }
    }
}
