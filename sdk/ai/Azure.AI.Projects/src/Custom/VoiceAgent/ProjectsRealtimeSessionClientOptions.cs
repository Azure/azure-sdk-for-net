// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.Projects.Agents;
using OpenAI.Realtime;

namespace Azure.AI.Projects;

/// <summary> Options for connecting to a Foundry Voice Agent realtime session. </summary>
[Experimental("AAIP002")]
public class ProjectsRealtimeSessionClientOptions : RealtimeSessionClientOptions
{
    /// <summary>
    /// The transport to use for this session. If omitted, the service uses its default WebSocket transport.
    /// WebRTC selects signaling over the WebSocket; the application must manage the peer connection and media.
    /// </summary>
    public VoiceAgentTransport? Transport { get; set; }
}
