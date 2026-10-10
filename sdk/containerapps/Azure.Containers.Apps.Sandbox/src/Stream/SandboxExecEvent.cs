// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.Apps.Sandbox.Models
{
    /// <summary> A service event received from an interactive sandbox exec session. </summary>
    public enum SandboxExecEventType
    {
        /// <summary> The service assigned a session ID. </summary>
        SessionId,
        /// <summary> Standard output bytes are available. </summary>
        StandardOutput,
        /// <summary> Standard error bytes are available. </summary>
        StandardError,
        /// <summary> The process exited. </summary>
        ExitCode,
        /// <summary> The service reported an error. </summary>
        Error,
        /// <summary> The WebSocket closed. </summary>
        Closed
    }

    /// <summary> A decoded exec event. Output data is raw bytes, not base64 text. </summary>
    public class SandboxExecEvent
    {
        internal SandboxExecEvent(SandboxExecEventType type, BinaryData data = null, string text = null, int? exitCode = null)
        {
            Type = type;
            Data = data;
            Text = text;
            ExitCode = exitCode;
        }

        /// <summary> The event type. </summary>
        public SandboxExecEventType Type { get; }
        /// <summary> The raw standard output or standard error bytes, if present. </summary>
        public BinaryData Data { get; }
        /// <summary> The session ID, error message, or WebSocket close description, if present. </summary>
        public string Text { get; }
        /// <summary> The exit code, if present. </summary>
        public int? ExitCode { get; }
    }
}
