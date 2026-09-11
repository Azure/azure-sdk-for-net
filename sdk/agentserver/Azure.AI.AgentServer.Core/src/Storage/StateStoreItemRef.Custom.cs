// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.AgentServer.Core.Storage
{
    public partial class StateStoreItemRef
    {
        /// <param name="result">The <see cref="ClientResult"/> to deserialize.</param>
        public static explicit operator StateStoreItemRef(ClientResult result)
        {
            PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeStateStoreItemRef(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
