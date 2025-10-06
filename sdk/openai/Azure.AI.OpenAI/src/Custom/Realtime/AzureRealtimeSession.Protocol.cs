// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using Azure.Core;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Net.WebSockets;

namespace Azure.AI.OpenAI.Realtime;

internal partial class AzureRealtimeSession : RealtimeSession
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected internal override async Task ConnectAsync(RequestOptions options)
    {
        WebSocket?.Dispose();

        // Temporary mitigation of static RPM rate limiting behavior: pending protocol-based rate limit integration with
        // rate_limits.updated, use a static retry strategy upon receiving a 429 error.

        bool shouldRetryOnFailure = false;
        int rateLimitRetriesUsed = 0;
        const int maximumRateLimitRetries = 3;
        TimeSpan timeBetweenRateLimitRetries = TimeSpan.FromSeconds(5);

        do
        {
            try
            {
                ClientWebSocket webSocket = await CreateAzureWebSocketAsync(options).ConfigureAwait(false);
                await webSocket.ConnectAsync(_endpoint, options?.CancellationToken ?? default)
                    .ConfigureAwait(false);
                WebSocket = webSocket;
            }
            catch (WebSocketException webSocketException)
            {
                shouldRetryOnFailure
                    = webSocketException.Message?.Contains("429") == true && rateLimitRetriesUsed++ < maximumRateLimitRetries;
                if (shouldRetryOnFailure)
                {
                    await Task.Delay(timeBetweenRateLimitRetries).ConfigureAwait(false);
                }
                else
                {
                    throw;
                }
            }
        } while (shouldRetryOnFailure);
    }

    private async Task<ClientWebSocket> CreateAzureWebSocketAsync(RequestOptions options)
    {
        string clientRequestId = Guid.NewGuid().ToString();

        ClientWebSocket clientWebSocket = new();
        clientWebSocket.Options.AddSubProtocol("realtime");
        clientWebSocket.Options.SetRequestHeader("openai-beta", $"realtime=v1");
        clientWebSocket.Options.SetRequestHeader("x-ms-client-request-id", clientRequestId);

        foreach (KeyValuePair<string, string> defaultHeaderPair in _defaultHeaders)
        {
            clientWebSocket.Options.SetRequestHeader(defaultHeaderPair.Key, defaultHeaderPair.Value);
        }

        try
        {
            clientWebSocket.Options.SetRequestHeader("User-Agent", _userAgent);
        }
        catch (ArgumentException argumentException)
        {
            throw new PlatformNotSupportedException(
                $"{nameof(RealtimeClient)} is not yet supported on older .NET framework targets.",
                argumentException);
        }

        if (_tokenCredential is not null)
        {
            TokenRequestContext tokenRequestContext = new(_tokenAuthorizationScopes.ToArray(), clientRequestId);
            AccessToken token = await _tokenCredential.GetTokenAsync(tokenRequestContext, options?.CancellationToken ?? default)
                .ConfigureAwait(false);
            clientWebSocket.Options.SetRequestHeader("Authorization", $"Bearer {token.Token}");
        }
        else
        {
            _keyCredential.Deconstruct(out string dangerousCredential);
            clientWebSocket.Options.SetRequestHeader("api-key", dangerousCredential);
        }

        return clientWebSocket;
    }
}

#endif
