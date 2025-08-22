// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Realtime;

namespace Azure.AI.OpenAI.Realtime;

[Experimental("OPENAI002")]
internal partial class AzureRealtimeClient : RealtimeClient
{
    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Creates a new realtime conversation operation instance, establishing a connection with the /realtime endpoint.
    /// </summary>
    /// <param name="deploymentName"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Task<RealtimeSession> StartConversationSessionAsync(string deploymentName, RequestOptions options)
        => StartSessionAsync(deploymentName, intent: null, options: options);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Task<RealtimeSession> StartTranscriptionSessionAsync(RequestOptions options)
        => StartSessionAsync(deploymentName: null, intent: "transcription", options: options);

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Creates a new realtime operation instance, establishing a connection with the /realtime endpoint.
    /// </summary>
    /// <param name="deploymentName"></param>
    /// <param name="intent"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<RealtimeSession> StartSessionAsync(string deploymentName, string intent, RequestOptions options)
    {
        RealtimeSession provisionalOperation = _tokenCredential is not null
            ? new AzureRealtimeSession(this, BuildSessionEndpoint(deploymentName, intent), _tokenCredential, _tokenAuthorizationScopes, _userAgent, _defaultHeaders)
            : new AzureRealtimeSession(this, BuildSessionEndpoint(deploymentName, intent), _credential, _userAgent, _defaultHeaders);
        try
        {
            await provisionalOperation.ConnectAsync(options).ConfigureAwait(false);
            RealtimeSession result = provisionalOperation;
            provisionalOperation = null;
            return result;
        }
        finally
        {
            provisionalOperation?.Dispose();
        }
    }

    private Uri BuildSessionEndpoint(string deploymentName, string intent)
    {
        ClientUriBuilder builder = new();
        builder.Reset(_baseEndpoint);
        if (!string.IsNullOrEmpty(deploymentName))
        {
            builder.AppendQuery("deployment", deploymentName, escape: true);
        }
        if (!string.IsNullOrEmpty(intent))
        {
            builder.AppendQuery("intent", intent, escape: true);
        }
        if (!string.IsNullOrEmpty(_apiVersion))
        {
            builder.AppendQuery("api-version", _apiVersion, escape: true);
        }
        foreach (KeyValuePair<string, string> defaultQueryParameter in _defaultQueryParameters)
        {
            builder.AppendQuery(defaultQueryParameter.Key, defaultQueryParameter.Value, escape: true);
        }
        return builder.ToUri();
    }
}

#endif