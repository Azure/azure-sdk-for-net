// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects;

/// <summary> Connects to native Live sessions for Foundry Voice Agents. </summary>
[Experimental("AAIP001")]
public class ProjectsLiveClient
{
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly IReadOnlyDictionary<string, object> _tokenProperties;
    private readonly string _apiVersion;
    private readonly string _experimentalHeaders;
    private readonly ClientDiagnostics _diagnostics;
    private readonly TimeSpan _connectionTimeout;

    /// <summary> Initializes a new instance for mocking. </summary>
    protected ProjectsLiveClient()
    {
    }

    internal ProjectsLiveClient(Uri endpoint, AuthenticationTokenProvider tokenProvider,
        IReadOnlyDictionary<string, object> tokenProperties, string apiVersion, string experimentalHeaders,
        ClientPipeline pipeline, ClientDiagnostics diagnostics, TimeSpan? networkTimeout)
    {
        Endpoint = endpoint;
        _tokenProvider = tokenProvider;
        _tokenProperties = tokenProperties;
        _apiVersion = apiVersion;
        _experimentalHeaders = RealtimeClientHelper.ExperimentalHeaders(experimentalHeaders);
        Pipeline = pipeline;
        _diagnostics = diagnostics;
        _connectionTimeout = networkTimeout ?? TimeSpan.FromMinutes(1);
    }

    /// <summary> The Foundry project endpoint. </summary>
    public Uri Endpoint { get; }

    /// <summary> The parent project's HTTP pipeline. Native Live messages use a dedicated WebSocket. </summary>
    public ClientPipeline Pipeline { get; }

    /// <summary> Connects a native Live WebSocket session and waits for the service's startup acknowledgment. </summary>
    /// <param name="agentName"> The name of the Live voice agent. </param>
    /// <param name="options"> Optional connection settings. Foundry starts the native session from the agent definition. </param>
    /// <param name="cancellationToken"> Cancels authentication, connection, and session startup. </param>
    /// <returns> An initialized session, owned by the caller. </returns>
#pragma warning disable AZC0004 // WebSocket connection and native session startup are asynchronous.
#pragma warning disable AZC0015 // The result is an owned, connected session, not an HTTP response.
    public virtual async Task<ProjectsLiveSessionClient> StartSessionAsync(string agentName,
        ProjectsLiveSessionClientOptions options = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015
#pragma warning restore AZC0004
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        cancellationToken.ThrowIfCancellationRequested();
        Uri uri = BuildEndpoint(Endpoint, agentName, _apiVersion, options);
        using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(_connectionTimeout);
        using DiagnosticScope scope = _diagnostics.CreateScope("ProjectsLiveClient.StartSession");
        scope.Start();
        ClientWebSocket socket = new();
        ProjectsLiveSessionClient session = null;
        try
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, string> header in options.Headers)
                {
                    if (header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase) ||
                        header.Key.Equals("Foundry-Features", StringComparison.OrdinalIgnoreCase) ||
                        header.Key.Equals("Sec-WebSocket-Protocol", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException("Authentication, preview, and WebSocket protocol headers are managed by the client.", nameof(options));
                    }
                    socket.Options.SetRequestHeader(header.Key, header.Value);
                }
            }
            AuthenticationToken token = await _tokenProvider.GetTokenAsync(new GetTokenOptions(_tokenProperties), timeout.Token).ConfigureAwait(false);
            socket.Options.SetRequestHeader("Authorization", $"{token.TokenType} {token.TokenValue}");
            socket.Options.SetRequestHeader("Foundry-Features", _experimentalHeaders);
            socket.Options.SetRequestHeader("x-ms-client-request-id", Guid.NewGuid().ToString());
            await socket.ConnectAsync(uri, timeout.Token).ConfigureAwait(false);
            session = new ProjectsLiveSessionClient(socket);
            await session.InitializeAsync(timeout.Token).ConfigureAwait(false);
            ProjectsLiveSessionClient result = session;
            session = null;
            socket = null;
            return result;
        }
        catch (WebSocketException exception) when (timeout.IsCancellationRequested)
        {
            // .NET Framework wraps a canceled HTTP upgrade in WebSocketException.
            OperationCanceledException cancelled = new("The Live connection was canceled.", exception,
                cancellationToken.IsCancellationRequested ? cancellationToken : timeout.Token);
            scope.Failed(cancelled);
            throw cancelled;
        }
        catch (Exception exception)
        {
            scope.Failed(exception);
            throw;
        }
        finally
        {
            session?.Dispose();
            socket?.Dispose();
        }
    }

    internal static Uri BuildEndpoint(Uri endpoint, string agentName, string apiVersion, ProjectsLiveSessionClientOptions options)
    {
        UriBuilder builder = new(RealtimeClientHelper.GetAgentWebSocketEndpoint(endpoint, agentName));
        builder.Path += "/live/sessions";
        StringBuilder query = new();
        RealtimeClientHelper.AppendQueryParameter(query, "api-version", apiVersion);
        if (options?.Store != null)
        {
            RealtimeClientHelper.AppendQueryParameter(query, "store", options.Store.Value ? "true" : "false");
        }
        if (options?.AgentVersion != null)
        {
            Argument.AssertNotNullOrEmpty(options.AgentVersion, nameof(options.AgentVersion));
            RealtimeClientHelper.AppendQueryParameter(query, "x-agent-version-override", options.AgentVersion);
        }
        if (options?.StructuredInputs.Count > 0)
        {
            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream))
            {
                writer.WriteStartObject();
                foreach (KeyValuePair<string, BinaryData> input in options.StructuredInputs)
                {
                    writer.WritePropertyName(input.Key);
                    if (input.Value == null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        using JsonDocument value = JsonDocument.Parse(input.Value);
                        value.RootElement.WriteTo(writer);
                    }
                }
                writer.WriteEndObject();
            }
            RealtimeClientHelper.AppendQueryParameter(query, "structured_inputs", Encoding.UTF8.GetString(stream.ToArray()));
        }
        if (!string.IsNullOrEmpty(options?.QueryString))
        {
            foreach (string parameter in options.QueryString.TrimStart('?').Split('&'))
            {
                if (parameter.Length == 0)
                {
                    continue;
                }
                int separator = parameter.IndexOf('=');
                string name = Uri.UnescapeDataString(separator < 0 ? parameter : parameter.Substring(0, separator));
                if (name.Equals("api-version", StringComparison.OrdinalIgnoreCase) ||
                    (options.Store.HasValue && name.Equals("store", StringComparison.OrdinalIgnoreCase)) ||
                    (options.AgentVersion != null && name.Equals("x-agent-version-override", StringComparison.OrdinalIgnoreCase)) ||
                    (options.StructuredInputs.Count > 0 && (name == "structured_inputs" || name == "structured_input")))
                {
                    throw new ArgumentException("A query parameter conflicts with a managed project or session option.", nameof(options));
                }
                if (query.Length > 0)
                {
                    query.Append('&');
                }
                query.Append(parameter);
            }
        }
        builder.Query = query.ToString();
        return builder.Uri;
    }
}

public partial class AIProjectClient
{
    [Experimental("AAIP001")]
    private ProjectsLiveClient _cachedProjectsLiveClient;

    /// <summary> Gets the client for native Live Voice Agent sessions. Realtime agents use <see cref="ProjectsRealtimeClient"/> instead. </summary>
    [Experimental("AAIP001")]
    public virtual ProjectsLiveClient ProjectsLiveClient
    {
        get
        {
            if (_tokenProvider == null)
            {
                throw new InvalidOperationException("Native Live sessions require a project client constructed with an AuthenticationTokenProvider.");
            }
            return Volatile.Read(ref _cachedProjectsLiveClient) ??
                Interlocked.CompareExchange(ref _cachedProjectsLiveClient,
                    new ProjectsLiveClient(_endpoint, _tokenProvider, _flows[0], _apiVersion, s_experimentalHeaders,
                        Pipeline, ClientDiagnostics, _clientOptions?.NetworkTimeout), null) ??
                _cachedProjectsLiveClient;
        }
    }
}
