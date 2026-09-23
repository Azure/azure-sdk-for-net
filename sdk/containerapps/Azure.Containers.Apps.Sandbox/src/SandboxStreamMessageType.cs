// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> The type of a sandbox stream message. </summary>
    public enum SandboxStreamMessageType
    {
        /// <summary> A UTF-8 text message. </summary>
        Text,

        /// <summary> A binary message. </summary>
        Binary,

        /// <summary> A message indicating that the stream was closed. </summary>
        Close
    }
}
