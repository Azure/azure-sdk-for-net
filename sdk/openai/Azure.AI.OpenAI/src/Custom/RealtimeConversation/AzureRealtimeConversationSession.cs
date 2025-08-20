// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.WebSockets;
using Azure.Core;

namespace Azure.AI.OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
internal partial class AzureRealtimeConversationSession : RealtimeConversationSession
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _keyCredential;
    private readonly TokenCredential _tokenCredential;
    private readonly IEnumerable<string> _tokenAuthorizationScopes;
    private readonly string _userAgent;

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
    }

    private AzureRealtimeConversationSession(AzureRealtimeConversationClient parentClient, Uri endpoint, string userAgent)
        : base(parentClient, endpoint, credential: new("placeholder"))
    {
        _endpoint = endpoint;
        _userAgent = userAgent;
    }
}

#endif