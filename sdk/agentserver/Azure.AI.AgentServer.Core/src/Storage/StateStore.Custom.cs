// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Core.Storage
{
    public partial class StateStore
    {
        /// <summary>Gets the optional free-form description.</summary>
        [CodeGenMember("Description")]
        public string? Description { get; }

        /// <param name="result">The <see cref="ClientResult"/> to deserialize.</param>
        public static explicit operator StateStore(ClientResult result)
        {
            PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeStateStore(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
