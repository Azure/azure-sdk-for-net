// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> Format of the HTTP sandbox log stream. </summary>
    public enum SandboxLogFormat
    {
        /// <summary> Plain text lines. </summary>
        Text,
        /// <summary> Newline-delimited JSON objects with timestamp, stream, and message fields. </summary>
        Json
    }
}
