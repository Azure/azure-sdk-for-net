// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using data from Visual Studio Code
    /// </summary>
    public class VisualStudioCodeCredential : TokenCredential, IExtendedTokenCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string ClientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
        private readonly IVisualStudioCodeAdapter _vscAdapter;
        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;

        /// <inheritdoc />
        public VisualStudioCodeCredential() : this(default, default) {}

        /// <inheritdoc />
        public VisualStudioCodeCredential(string tenantId, TokenCredentialOptions options)
        {
            _tenantId = tenantId ?? "common";
            _pipeline = CredentialPipeline.GetInstance(options);
            _vscAdapter = GetVscAdapter();
        }

        /// <inheritdoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => (await GetTokenImplAsync(requestContext, true, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenImpl(requestContext, cancellationToken).GetTokenOrThrow();

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenImpl(requestContext, cancellationToken);

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await GetTokenImplAsync(requestContext, true, cancellationToken).ConfigureAwait(false);

        private ExtendedAccessToken GetTokenImpl(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(requestContext, false, cancellationToken).GetAwaiter().GetResult();
        }

        private async ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("VisualStudioCodeCredential.GetToken", requestContext);

            try
            {
                var userSettings = GetUserSettings();
                var tenant = userSettings.TryGetProperty("azure.tenant", out JsonElement tenantProperty)
                    ? tenantProperty.GetString()
                    :  _tenantId;

                var environmentName = userSettings.TryGetProperty("azure.cloud", out JsonElement environmentProperty)
                    ? environmentProperty.GetString()
                    : null;

                var environment = Environment.FromName(environmentName);

                var storedCredentials = _vscAdapter.GetCredentials(CredentialsSection, environment.Name);
                var builder = ConfidentialClientApplicationBuilder.Create(ClientId)
                    .WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline.HttpPipeline))
                    .WithAuthority(environment.CloudInstance, _tenantId);

                AuthenticationResult result;

                try
                {
                    JsonElement parsedCredentials = JsonDocument.Parse(storedCredentials).RootElement;
                    var redirectUri = parsedCredentials.GetProperty("redirectionUrl").GetString();
                    var authorizationCode = parsedCredentials.GetProperty("code").GetString();
                    var client =  ConfidentialClientApplicationBuilder.Create(ClientId)
                        .WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline.HttpPipeline))
                        .WithAuthority(environment.CloudInstance, _tenantId)
                        .WithRedirectUri(redirectUri).Build();

                    var parameterBuilder = client.AcquireTokenByAuthorizationCode(requestContext.Scopes, authorizationCode);

                    result = async
                        ? await parameterBuilder.ExecuteAsync(cancellationToken).ConfigureAwait(false)
                        : parameterBuilder.ExecuteAsync(cancellationToken).GetAwaiter().GetResult();
                }
                catch (JsonException)
                {
                    var client = (IByRefreshToken)PublicClientApplicationBuilder.Create(ClientId)
                        .WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline.HttpPipeline))
                        .WithAuthority(environment.CloudInstance, _tenantId)
                        .Build();

                    var parameterBuilder = client.AcquireTokenByRefreshToken(requestContext.Scopes, storedCredentials);

                    result = async
                        ? await parameterBuilder.ExecuteAsync(cancellationToken).ConfigureAwait(false)
                        : parameterBuilder.ExecuteAsync(cancellationToken).GetAwaiter().GetResult();
                }

                return new ExtendedAccessToken(scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn)));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);
                throw;
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }


        private JsonElement GetUserSettings()
        {
            var path = _vscAdapter.GetUserSettingsPath();
            try
            {
                var content = File.ReadAllText(path);
                return JsonDocument.Parse(content).RootElement;
            }
            catch (Exception)
            {
                return default;
            }
        }

        private static IVisualStudioCodeAdapter GetVscAdapter()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new WindowsVisualStudioCodeAdapter();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new MacosVisualStudioCodeAdapter();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new LinuxVisualStudioCodeAdapter();
            }

            throw new PlatformNotSupportedException();
        }

        private readonly struct Environment
        {
            public string Name { get; }
            public AzureCloudInstance CloudInstance { get; }

            public Environment(string name, AzureCloudInstance cloudInstance)
            {
                Name = name;
                CloudInstance = cloudInstance;
            }

            public static Environment FromName(string name) =>
                name switch
                {
                    "Azure" => new Environment("Azure", AzureCloudInstance.AzurePublic),
                    _ => new Environment("Azure", AzureCloudInstance.AzurePublic)
                };
        }
    }
}
