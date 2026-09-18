// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using OpenAI.Realtime;

namespace Azure.AI.Projects;
#pragma warning disable OPENAI002

/// <summary>
/// The extended real time client.
/// </summary>
internal class ProjectsRealtimeClient : RealtimeClient
{
    private static string s_defaultAuthorizationScope = "https://ai.azure.com/.default";
    private AuthenticationTokenProvider _tokenProvider;
    /// <summary>
    /// Internal empty constructor for mocking.
    /// </summary>
    protected ProjectsRealtimeClient() { }

    /// <summary>
    /// Create a new instance of ProjectsRealtimeClient
    /// </summary>
    internal ProjectsRealtimeClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, string experimentalHeaders = default, RealtimeClientOptions options = null)
        : base(RealtimeClientHelper.CreatePipeline(endpoint, tokenProvider, RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders), s_defaultAuthorizationScope, options), options)
    {
        _tokenProvider = tokenProvider;
        ExperimentalHeaders = RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders);
    }

    // Read by ProjectsRealtimeSessionClient (via its internal ParentClient reference) so the same
    // Foundry-Features header value isn't computed/stored a second time for the session's own
    // independent WebSocket handshake.
    internal string ExperimentalHeaders { get; }
}
