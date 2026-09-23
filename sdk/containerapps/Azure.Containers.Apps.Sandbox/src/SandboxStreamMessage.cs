// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> A message received from a sandbox stream. </summary>
    public class SandboxStreamMessage
    {
        internal SandboxStreamMessage(
            SandboxStreamMessageType messageType,
            BinaryData data,
            int? closeStatus,
            string closeStatusDescription)
        {
            MessageType = messageType;
            Data = data;
            CloseStatus = closeStatus;
            CloseStatusDescription = closeStatusDescription;
        }

        /// <summary> Gets the message payload type. </summary>
        public SandboxStreamMessageType MessageType { get; }

        /// <summary> Gets the message payload. </summary>
        public BinaryData Data { get; }

        /// <summary> Gets the WebSocket close status code when <see cref="MessageType"/> is <see cref="SandboxStreamMessageType.Close"/>. </summary>
        public int? CloseStatus { get; }

        /// <summary> Gets the close status description when <see cref="MessageType"/> is <see cref="SandboxStreamMessageType.Close"/>. </summary>
        public string CloseStatusDescription { get; }
    }
}
