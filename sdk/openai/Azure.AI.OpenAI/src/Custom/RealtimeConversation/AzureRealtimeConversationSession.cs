// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Azure.Core;
using OpenAI.RealtimeConversation;

namespace Azure.AI.OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
internal partial class AzureRealtimeConversationSession : RealtimeConversationSession
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _keyCredential;
    private readonly TokenCredential _tokenCredential;
    private readonly IEnumerable<string> _tokenAuthorizationScopes;
    private readonly TokenRequestContext _tokenRequestContext;
    private readonly string _clientRequestId;

    protected internal AzureRealtimeConversationSession(
        AzureRealtimeConversationClient parentClient,
        Uri endpoint,
        ApiKeyCredential credential,
        string userAgent)
        : this(parentClient, endpoint, userAgent)
    {
        _keyCredential = credential;
    }

    protected internal AzureRealtimeConversationSession(
        AzureRealtimeConversationClient parentClient,
        Uri endpoint,
        TokenCredential credential,
        IEnumerable<string> tokenAuthorizationScopes,
        string userAgent)
        : this(parentClient, endpoint, userAgent)
    {
        _tokenCredential = credential;
        _tokenAuthorizationScopes = tokenAuthorizationScopes;
        _tokenRequestContext = new(_tokenAuthorizationScopes.ToArray(), parentRequestId: _clientRequestId);
    }

    private AzureRealtimeConversationSession(AzureRealtimeConversationClient parentClient, Uri endpoint, string userAgent)
        : base(parentClient, endpoint, credential: new("placeholder"))
    {
        _clientRequestId = Guid.NewGuid().ToString();

        _endpoint = endpoint;
        _clientWebSocket.Options.AddSubProtocol("realtime");
        _clientWebSocket.Options.SetRequestHeader("User-Agent", userAgent);
        _clientWebSocket.Options.SetRequestHeader("x-ms-client-request-id", _clientRequestId);
    }

    internal override async Task SendCommandAsync(InternalRealtimeRequestCommand command, CancellationToken cancellationToken = default)
    {
        BinaryData requestData = ModelReaderWriter.Write(command);

        // Temporary backcompat quirk
        if (command is InternalRealtimeRequestSessionUpdateCommand sessionUpdateCommand
            && sessionUpdateCommand.Session?.TurnDetectionOptions is InternalRealtimeNoTurnDetection)
        {
            requestData = BinaryData.FromString(requestData.ToString()
                .Replace(@"""turn_detection"":null", @"""turn_detection"":{""type"":""none""}"));
        }

        RequestOptions cancellationOptions = cancellationToken.ToRequestOptions();
        await SendCommandAsync(requestData, cancellationOptions).ConfigureAwait(false);
    }
}
