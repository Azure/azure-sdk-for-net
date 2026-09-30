// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox.Models
{
    /// <summary> Configuration sent in the first message of an interactive sandbox exec session. </summary>
#pragma warning disable AZC0030 // This is a WebSocket start request, not an HTTP request content model.
    public class SandboxExecStartRequest
    {
        /// <summary> Initializes a request for the specified executable. </summary>
        /// <param name="command"> The executable to run. </param>
        public SandboxExecStartRequest(string command)
        {
            Argument.AssertNotNullOrEmpty(command, nameof(command));
            Command = command;
        }

        /// <summary> The executable to run. </summary>
        public string Command { get; }

        /// <summary> Arguments passed to the executable. </summary>
        public IList<string> Arguments { get; } = new List<string>();

        /// <summary> Environment variables to merge with the sandbox environment. </summary>
        public IDictionary<string, string> Environment { get; } = new Dictionary<string, string>();

        /// <summary> The working directory for the command. </summary>
        public string WorkingDirectory { get; set; }

        /// <summary> The user that runs the command. </summary>
        public string User { get; set; }

        /// <summary> Whether to allocate a terminal. Defaults to true. </summary>
        public bool Tty { get; set; } = true;

        /// <summary> Whether to enable standard input. Defaults to true. </summary>
        public bool Stdin { get; set; } = true;

        /// <summary> The initial terminal height in rows. Defaults to 24. </summary>
        public uint Height { get; set; } = 24;

        /// <summary> The initial terminal width in columns. Defaults to 80. </summary>
        public uint Width { get; set; } = 80;

        /// <summary> Whether the command is detached from the session. Defaults to false. </summary>
        public bool Detach { get; set; }
    }
#pragma warning restore AZC0030
}
