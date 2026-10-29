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
    /// The connection transport. WebRTC provides signaling only; your application must handle the peer connection and audio.
    /// </summary>
    public VoiceAgentTransport? Transport { get; set; }
}
