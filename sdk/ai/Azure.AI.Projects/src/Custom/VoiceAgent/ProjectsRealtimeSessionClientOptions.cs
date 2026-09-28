// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Azure.AI.Projects.Agents;
using OpenAI.Realtime;

namespace Azure.AI.Projects;

/// <summary>
/// Extends <see cref="RealtimeSessionClientOptions"/> with Foundry-only voice-agent connection
/// options that have a strongly-typed generated equivalent -- currently just
/// <see cref="Transport"/> -- so
/// <see cref="ProjectsRealtimeClient.StartSessionAsync(string, string, RealtimeSessionClientOptions, CancellationToken)"/>
/// keeps a single signature (matching the base OpenAI <see cref="RealtimeClient.StartSessionAsync(string, string, RealtimeSessionClientOptions, CancellationToken)"/>
/// it overrides) instead of gaining a new overload for every option. Foundry-only options with no
/// generated type of their own -- like "store" -- still only have a raw
/// <see cref="RealtimeSessionClientOptions.QueryString"/> value; pass a
/// <see cref="ProjectsRealtimeSessionClientOptions"/> instead of a plain
/// <see cref="RealtimeSessionClientOptions"/> wherever both are needed together.
/// </summary>
[Experimental("AAIP002")]
public class ProjectsRealtimeSessionClientOptions : RealtimeSessionClientOptions
{
    /// <summary>
    /// The transport to negotiate for the session's media path: <see cref="VoiceAgentTransport.Webrtc"/>
    /// to negotiate a WebRTC peer connection instead of the default WebSocket-only media path (only
    /// SDP signaling travels over the WebSocket connection; completing the SDP offer/answer exchange
    /// using the <c>rtc.call.sdp.create</c> and <c>rtc.call.sdp.created</c> events remains the
    /// caller's responsibility), or <see cref="VoiceAgentTransport.Websocket"/> to force the default
    /// WebSocket-only media path. Leave unset (<see langword="null"/>, the default) to omit the
    /// "transport" query parameter entirely and let the service pick its own default.
    /// </summary>
    public VoiceAgentTransport? Transport { get; set; }
}
