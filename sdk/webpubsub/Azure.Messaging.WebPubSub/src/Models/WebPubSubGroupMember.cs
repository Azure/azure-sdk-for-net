// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Messaging.WebPubSub;

#nullable enable

/// <summary>
/// Represents a connection in a group.
/// </summary>
/// <remarks>
/// Creates a new instance of <see cref="WebPubSubGroupMember"/> with the specified connection id.
/// </remarks>
/// <param name="connectionId"></param>
public class WebPubSubGroupMember(string connectionId)
{
    /// <summary>
    /// The connection id.
    /// </summary>
    public string ConnectionId { get; } = connectionId;
    /// <summary>
    /// The user id.
    /// </summary>
    public string? UserId { get; set; }

    internal static WebPubSubGroupMember ParseFromJson(JsonElement root)
    {
        var connectionId = root.GetProperty("connectionId").GetString() ??
            throw new JsonException("Required property 'connectionId' was null or not present");
        var userId = root.TryGetProperty("userId", out JsonElement userIdElement) ? userIdElement.GetString() : null;
        return new WebPubSubGroupMember(connectionId)
        {
            UserId = userId
        };
    }
}
