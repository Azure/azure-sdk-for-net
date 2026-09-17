// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Realtime;

namespace Azure.AI.Projects;

/// <summary>
/// The extended real time client.
/// </summary>
[Experimental("AAIP002")]
public class ProjectsRealtimeClient : RealtimeClient
{
    private static string s_defaultAuthorizationScope = "https://ai.azure.com/.default";
    private readonly string _experimentalHeaders;
    private AuthenticationTokenProvider _tokenProvider;
    private readonly Uri _uri;
    /// <summary>
    /// Internal empty constructor for mocking.
    /// </summary>
    protected ProjectsRealtimeClient() { }

    /// <summary>
    /// Create a new instance of ProjectsRealtimeClient
    /// </summary>
    public ProjectsRealtimeClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, string experimentalHeaders=default, RealtimeClientOptions options = null)
        :base(RealtimeClientHelper.CreatePipeline(endpoint, tokenProvider, RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders), s_defaultAuthorizationScope, options), options)
    {
        _tokenProvider = tokenProvider;
        _uri = RealtimeClientHelper.GetWebSocketEndpoint(endpoint, options);
        _experimentalHeaders = RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders);
    }
}
