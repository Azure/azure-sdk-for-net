// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.AI.OpenAI.Realtime;

[Experimental("OPENAI002")]
internal partial class AzureRealtimeSession : RealtimeSession
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _keyCredential;
    private readonly TokenCredential _tokenCredential;
    private readonly IEnumerable<string> _tokenAuthorizationScopes;
    private readonly string _userAgent;

    protected internal AzureRealtimeSession(
        AzureRealtimeClient parentClient,
        Uri endpoint,
        ApiKeyCredential credential,
        string userAgent,
        string deploymentName,
        string intent)
            : this(parentClient, endpoint, userAgent, deploymentName, intent)
    {
        _keyCredential = credential;
    }

    protected internal AzureRealtimeSession(
        AzureRealtimeClient parentClient,
        Uri endpoint,
        TokenCredential credential,
        IEnumerable<string> tokenAuthorizationScopes,
        string userAgent,
        string deploymentName,
        string intent)
            : this(parentClient, endpoint, userAgent, deploymentName, intent)
    {
        _tokenCredential = credential;
        _tokenAuthorizationScopes = tokenAuthorizationScopes;
    }

    private AzureRealtimeSession(AzureRealtimeClient parentClient, Uri endpoint, string userAgent, string deploymentName, string intent)
        : base(credential: new("placeholder"), parentClient, endpoint, deploymentName, intent)
    {
        _endpoint = endpoint;
        _userAgent = userAgent;
    }
}

#endif
