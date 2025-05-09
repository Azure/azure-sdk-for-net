// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// The update type presented when the status of a message changes.
/// </summary>
public class MessageStatusUpdate : StreamingUpdate<PersistentThreadMessage>
{
    internal MessageStatusUpdate(PersistentThreadMessage message, StreamingUpdateReason updateKind)
        : base(message, updateKind)
    { }

    internal static IEnumerable<MessageStatusUpdate> DeserializeMessageStatusUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        PersistentThreadMessage message = PersistentThreadMessage.DeserializePersistentThreadMessage(element, options);
        return updateKind switch
        {
            _ => [new MessageStatusUpdate(message, updateKind)],
        };
    }
}
