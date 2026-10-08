// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Core.Storage
{
    internal partial class ListResponseStateStoreItemKey
    {
        internal static ListResponseStateStoreItemKey FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeListResponseStateStoreItemKey(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
