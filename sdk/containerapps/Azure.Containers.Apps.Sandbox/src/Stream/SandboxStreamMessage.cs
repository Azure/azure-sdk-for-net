// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.Apps.Sandbox.Models
{
    /// <summary> The kind of WebSocket message in a sandbox stream. </summary>
    public enum SandboxStreamMessageType
    {
        /// <summary> A text message. </summary>
        Text,
        /// <summary> A binary message. </summary>
        Binary,
        /// <summary> The peer closed the stream. </summary>
        Close
    }

    /// <summary> A complete message received from a sandbox stream. </summary>
    public class SandboxStreamMessage
    {
        internal SandboxStreamMessage(SandboxStreamMessageType type, BinaryData data, int? closeStatus = null, string closeDescription = null)
        {
            Type = type;
            Data = data;
            CloseStatus = closeStatus;
            CloseDescription = closeDescription;
        }

        /// <summary> The message type. </summary>
        public SandboxStreamMessageType Type { get; }
        /// <summary> The complete text or binary payload, or null for a close message. </summary>
        public BinaryData Data { get; }
        /// <summary> The peer's WebSocket close status, when available. </summary>
        public int? CloseStatus { get; }
        /// <summary> The peer's close description, when available. </summary>
        public string CloseDescription { get; }
    }
}
