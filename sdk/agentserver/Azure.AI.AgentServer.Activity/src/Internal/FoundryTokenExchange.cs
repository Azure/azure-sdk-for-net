// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Handles the 3-step agentic token exchange for Foundry containers.
///
/// This is the .NET equivalent of the Python SDK's <c>_apply_msal_patches()</c>
/// which patches <c>MsalAuth.get_agentic_application_token</c> to use
/// <c>DefaultAzureCredential</c> with <c>fmi_path</c> support.
///
/// In .NET, instead of monkey-patching, we provide a standalone token
/// helper that agents can use to acquire tokens for outbound Bot Connector
/// calls, implementing the same 3-step flow:
///   1. Blueprint Managed Identity → api://AzureADTokenExchange/.default
///   2. Client assertion exchange → instance token
///   3. user_fic grant → agentic user token
/// </summary>
internal sealed class FoundryTokenExchange
{
    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;

    public FoundryTokenExchange(ILogger logger, HttpClient? httpClient = null)
    {
        _logger = logger;
        _httpClient = httpClient ?? new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
    }

    /// <summary>
    /// Acquires a Blueprint Managed Identity token using DefaultAzureCredential
    /// with fmi_path support (the key MSAL auth patch).
    /// </summary>
    /// <param name="clientId">The blueprint client ID.</param>
    /// <param name="agentAppInstanceId">The agent app instance ID (used as fmi_path).</param>
    /// <param name="scope">The token scope (default: api://AzureADTokenExchange/.default).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The access token, or null on failure.</returns>
    public async Task<string?> AcquireAgenticApplicationTokenAsync(
        string clientId,
        string? agentAppInstanceId,
        string scope = "api://AzureADTokenExchange/.default",
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "[activity-bridge] Acquiring agentic application token via " +
            "DefaultAzureCredential for agent_app_instance_id={AgentAppInstanceId}",
            agentAppInstanceId);

        try
        {
            // Use DefaultAzureCredential configured for managed identity with blueprint client ID
            var credential = new DefaultAzureCredential(
                new DefaultAzureCredentialOptions { ManagedIdentityClientId = clientId });
            var tokenResult = await credential.GetTokenAsync(
                new Azure.Core.TokenRequestContext(new[] { scope }),
                cancellationToken).ConfigureAwait(false);
            return tokenResult.Token;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Failed to acquire agentic application token for agent_app_instance_id={AgentAppInstanceId}",
                agentAppInstanceId);
            return null;
        }
    }

    /// <summary>
    /// Step 2: Exchange blueprint token for an instance token via client_assertion.
    /// </summary>
    public async Task<string?> ExchangeForInstanceTokenAsync(
        string tenantId,
        string clientId,
        string assertion,
        string scope = "api://AzureADTokenExchange/.default",
        CancellationToken cancellationToken = default)
    {
        var form = new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = clientId,
            ["client_assertion_type"] = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer",
            ["client_assertion"] = assertion,
            ["scope"] = scope,
        };

        return await PostTokenRequestAsync(tenantId, form, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Step 3: Exchange instance token for an agentic user token via user_fic grant.
    /// </summary>
    public async Task<string?> ExchangeForAgenticUserTokenAsync(
        string tenantId,
        string clientId,
        string assertion,
        string instanceToken,
        string userId,
        string scope = "5a807f24-c9de-44ee-a3a7-329e88a00ffc/.default",
        CancellationToken cancellationToken = default)
    {
        var form = new Dictionary<string, string>
        {
            ["grant_type"] = "user_fic",
            ["client_id"] = clientId,
            ["client_assertion_type"] = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer",
            ["client_assertion"] = assertion,
            ["scope"] = scope,
            ["user_id"] = userId,
            ["user_federated_identity_credential"] = instanceToken,
        };

        return await PostTokenRequestAsync(tenantId, form, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Performs the full 3-step token exchange and sends a reply activity.
    /// Returns true if the reply was sent successfully.
    /// </summary>
    public async Task<bool> SendReplyWithTokenExchangeAsync(
        string serviceUrl,
        string conversationId,
        string replyJson,
        string blueprintClientId,
        string tenantId,
        string agenticAppId,
        string agenticUserId,
        CancellationToken cancellationToken = default)
    {
        // Step 1: Blueprint MI → api://AzureADTokenExchange/.default
        var agentAppToken = await AcquireAgenticApplicationTokenAsync(
            blueprintClientId, agenticAppId, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (agentAppToken == null)
        {
            return false;
        }

        // Step 2: client_assertion exchange → instance token
        var instanceToken = await ExchangeForInstanceTokenAsync(
            tenantId, agenticAppId, agentAppToken, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (instanceToken == null)
        {
            return false;
        }

        // Step 3: user_fic grant → agentic user token
        var userToken = await ExchangeForAgenticUserTokenAsync(
            tenantId, agenticAppId, agentAppToken, instanceToken, agenticUserId,
            cancellationToken: cancellationToken).ConfigureAwait(false);
        if (userToken == null)
        {
            return false;
        }

        // Send the reply to Bot Connector
        var sendUrl = $"{serviceUrl.TrimEnd('/')}/v3/conversations/{conversationId}/activities";
        using var request = new HttpRequestMessage(HttpMethod.Post, sendUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
        request.Content = new StringContent(replyJson, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning(
                "Failed to send reply to Bot Connector: {StatusCode} {ReasonPhrase}",
                response.StatusCode, response.ReasonPhrase);
        }

        return response.IsSuccessStatusCode;
    }

    private async Task<string?> PostTokenRequestAsync(
        string tenantId,
        Dictionary<string, string> form,
        CancellationToken cancellationToken)
    {
        var url = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";
        using var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new FormUrlEncodedContent(form),
        };

        try
        {
            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning(
                    "Token exchange failed: {StatusCode} {Reason}",
                    response.StatusCode, response.ReasonPhrase);
                return null;
            }

            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            using var doc = JsonDocument.Parse(body);
            return doc.RootElement.GetProperty("access_token").GetString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token exchange request failed");
            return null;
        }
    }
}
