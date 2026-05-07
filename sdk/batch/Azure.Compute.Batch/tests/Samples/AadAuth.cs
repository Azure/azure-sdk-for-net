// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-aad-auth.md (.NET / csharp blocks).
// Includes both integrated-auth and service-principal flows.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Compute.Batch;
using Azure.Core;
using Azure.Identity;
using Microsoft.Identity.Client;

namespace BatchDocSamples;

internal static class AadAuth
{
    // Constants from the doc
    private const string AuthorityUri = "https://login.microsoftonline.com/<tenant-id>";
    private const string BatchResourceUri = "https://batch.core.windows.net/";
    private const string BatchAccountUrl = "https://myaccount.mylocation.batch.azure.com";
    private const string ClientId = "<application-id>";
    private const string RedirectUri = "https://<redirect-uri>";
    private const string ClientKey = "<secret-key>";

    // Block: GetTokenUsingAuthorizationCode (integrated auth).
    public static async Task<string> GetTokenUsingAuthorizationCode(
        string authorizationCode, string redirectUri, string[] scopes)
    {
        #region Snippet:aad_auth_get_token_authcode
        var app = ConfidentialClientApplicationBuilder.Create(ClientId)
                    .WithAuthority(AuthorityUri)
                    .WithRedirectUri(redirectUri)
                    .WithClientSecret(ClientKey)
                    .Build();

        var authResult = await app.AcquireTokenByAuthorizationCode(scopes, authorizationCode).ExecuteAsync();
        return authResult.AccessToken;
        #endregion
    }

    // Block: PerformBatchOperationsAsync (integrated auth, with TokenCredential delegate wrapper).
    public static async Task PerformBatchOperationsIntegratedAsync()
    {
        #region Snippet:aad_auth_integrated_batch_ops
        // Wrap the MSAL-acquired token in a TokenCredential so the BatchClient can
        // request a fresh token whenever the cached one nears expiration.
        TokenCredential credential = new DelegateTokenCredential(
            async (ctx, ct) =>
            {
                string token = await GetTokenUsingAuthorizationCode(
                    "<authorization-code>",
                    RedirectUri,
                    new[] { $"{BatchResourceUri}/.default" });
                return new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(55));
            });

        BatchClient client = new BatchClient(new Uri(BatchAccountUrl), credential);

        await foreach (BatchJob job in client.GetJobsAsync())
        {
            Console.WriteLine(job.Id);
        }
        #endregion
    }

    // Block: GetServicePrincipalCredential
    public static TokenCredential GetServicePrincipalCredential()
    {
        #region Snippet:aad_auth_sp_credential
        return new ClientSecretCredential(
            tenantId: "<tenant-id>",
            clientId: ClientId,
            clientSecret: ClientKey);
        #endregion
    }

    // Block: PerformBatchOperationsAsync (service principal)
    public static async Task PerformBatchOperationsSpAsync()
    {
        #region Snippet:aad_auth_sp_batch_ops
        TokenCredential credential = GetServicePrincipalCredential();

        BatchClient client = new BatchClient(new Uri(BatchAccountUrl), credential);

        await foreach (BatchJob job in client.GetJobsAsync())
        {
            Console.WriteLine(job.Id);
        }
        #endregion
    }
}

// Lightweight TokenCredential that delegates token acquisition to a callback.
// Azure.Identity does not ship one of these by default; the doc references
// it as the bridge between an MSAL-acquired token and the BatchClient ctor.
internal sealed class DelegateTokenCredential : TokenCredential
{
    private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getToken;

    public DelegateTokenCredential(
        Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> getToken)
    {
        _getToken = getToken;
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        => _getToken(requestContext, cancellationToken).AsTask().GetAwaiter().GetResult();

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        => _getToken(requestContext, cancellationToken);
}
