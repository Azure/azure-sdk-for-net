// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Realtime;

namespace Azure.AI.Projects;
#pragma warning disable OPENAI002
#pragma warning disable AAIP002

/// <summary>
/// The extended real time client.
/// </summary>
[Experimental("AAIP002")]
public class ProjectsRealtimeClient : RealtimeClient
{
    private static string s_defaultAuthorizationScope = "https://ai.azure.com/.default";
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly IReadOnlyDictionary<string, object> _tokenProperties;
    private readonly string _apiVersion;

    /// <summary>
    /// Internal empty constructor for mocking.
    /// </summary>
    protected ProjectsRealtimeClient() { }

    /// <summary>
    /// Create a new instance of ProjectsRealtimeClient. Only AIProjectClient.ProjectsRealtimeClient
    /// constructs this type, so tokenProperties/apiVersion -- needed by every
    /// ProjectsRealtimeSessionClient this creates (see StartSessionAsync below) -- are taken
    /// directly as constructor parameters rather than set later through settable properties.
    /// </summary>
    // "out preparedOptions" resolves and returns the same options instance (defaulted, with its
    // Endpoint set) used to build the pipeline below, so it can also be passed to the base
    // constructor's own options parameter. That ordering matters: RealtimeClient's base constructor
    // reads options.Endpoint to compute its private _endpoint/_webSocketEndpoint fields (which the
    // inherited Endpoint property returns), so Endpoint needs to already be set on that same
    // instance by the time base(...) runs -- setting it from this constructor's body would be too
    // late, since the base constructor would already have read the unset value.
    internal ProjectsRealtimeClient(
        Uri endpoint,
        AuthenticationTokenProvider tokenProvider,
        IReadOnlyDictionary<string, object> tokenProperties,
        string apiVersion,
        string experimentalHeaders = default,
        RealtimeClientOptions options = null)
        : base(CreatePipeline(endpoint, tokenProvider, experimentalHeaders, options, out RealtimeClientOptions preparedOptions), preparedOptions)
    {
        _tokenProvider = tokenProvider;
        _tokenProperties = tokenProperties;
        _apiVersion = apiVersion;
        ExperimentalHeaders = RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders);
    }

    private static ClientPipeline CreatePipeline(Uri endpoint, AuthenticationTokenProvider tokenProvider, string experimentalHeaders, RealtimeClientOptions options, out RealtimeClientOptions preparedOptions)
    {
        preparedOptions = options ?? new RealtimeClientOptions();
        preparedOptions.Endpoint = endpoint;
        return RealtimeClientHelper.CreatePipeline(endpoint, tokenProvider, RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders), s_defaultAuthorizationScope, preparedOptions);
    }

    // Read by ProjectsRealtimeSessionClient (via its internal ParentClient reference) so the same
    // Foundry-Features header value isn't computed/stored a second time for the session's own
    // independent WebSocket handshake.
    internal string ExperimentalHeaders { get; }

    /// <summary>
    /// Starts and connects a realtime session for the named voice agent. Overrides
    /// <see cref="RealtimeClient.StartSessionAsync(string, string, RealtimeSessionClientOptions, CancellationToken)"/>
    /// rather than introducing a differently-named method: this is the public, documented way to
    /// start a voice-agent session -- get a <see cref="ProjectsRealtimeClient"/> from
    /// <see cref="AIProjectClient.ProjectsRealtimeClient"/>, then call this (inherited/overridden)
    /// method on it, the same way an OpenAI <see cref="RealtimeClient"/> consumer would.
    /// </summary>
    /// <param name="model">The name of the voice agent to connect to (used as the <c>{agentName}</c> path segment).</param>
    /// <param name="intent">The client intent.</param>
    /// <param name="options">
    /// Additional connection options. <see cref="RealtimeSessionClientOptions.QueryString"/> is
    /// used to pass Foundry's "store" option (a Foundry-only concept with no equivalent on this
    /// method's own signature) as <c>"store=true"</c> or <c>"store=false"</c>; see
    /// <see cref="ProjectsRealtimeSessionClient.ConnectAsync"/>, which merges it with api-version.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// An already-connected <see cref="ProjectsRealtimeSessionClient"/> (returned as the base
    /// <see cref="RealtimeSessionClient"/> type: <c>Task&lt;T&gt;</c> isn't covariant in <c>T</c>
    /// even under C# 9+ override covariance, unlike a method's own direct return type).
    /// </returns>
#pragma warning disable AZC0015 // Returns a connected WebSocket session client, not a REST response; there is no response body to wrap.
#pragma warning disable AZC0004 // Establishing a WebSocket connection is asynchronous-only; matches the base method's own shape.
    public override async Task<RealtimeSessionClient> StartSessionAsync(string model, string intent, RealtimeSessionClientOptions options = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0004
#pragma warning restore AZC0015
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));

        ProjectsRealtimeSessionClient sessionClient = new(Endpoint, _tokenProvider, model, intent, _tokenProperties, _apiVersion, parentClient: this);
        try
        {
            await sessionClient.ConnectInternalAsync(options?.QueryString, options?.Headers, cancellationToken).ConfigureAwait(false);
            RealtimeSessionClient result = sessionClient;
            sessionClient = null;
            return result;
        }
        finally
        {
            sessionClient?.Dispose();
        }
    }
}
