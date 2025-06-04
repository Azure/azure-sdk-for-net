// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using OpenAI.RealtimeConversation;

namespace Azure.AI.OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
internal partial class AzureRealtimeConversationClient : RealtimeConversationClient
{
    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Creates a new realtime conversation operation instance, establishing a connection with the /realtime endpoint.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<RealtimeConversationSession> StartConversationSessionAsync(RequestOptions options)
    {
        RealtimeConversationSession provisionalOperation = _tokenCredential is not null
            ? new AzureRealtimeConversationSession(this, _endpoint, _tokenCredential, _tokenAuthorizationScopes, _userAgent)
            : new AzureRealtimeConversationSession(this, _endpoint, _credential, _userAgent);
        try
        {
            await provisionalOperation.ConnectAsync(options).ConfigureAwait(false);
            RealtimeConversationSession result = provisionalOperation;
            provisionalOperation = null;
            return result;
        }
        finally
        {
            provisionalOperation?.Dispose();
        }
    }
}

#endif