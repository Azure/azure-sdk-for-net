// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.Agents;
public partial class SessionLogEvent
{
    /// <param name="result"> The <see cref="ClientResult"/> to deserialize the <see cref="SessionLogEvent"/> from. </param>
    public static explicit operator SessionLogEvent(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();
        // Fix if the result is not a json document.
        try
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeSessionLogEvent(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
        catch (JsonException)
        {
            return new SessionLogEvent(SessionLogEventType.Log, response.Content.ToString());
        }
    }
}
