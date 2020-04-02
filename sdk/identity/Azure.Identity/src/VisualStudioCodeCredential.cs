// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
    internal class VisualStudioCodeCredential : TokenCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string ClientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
        private readonly IVisualStudioCodeAdapter _vscAdapter;
        private readonly IFileSystemService _fileSystem;
        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;

        /// <summary>
        /// Protected constructor for mocking
        /// </summary>
        protected VisualStudioCodeCredential() : this(default, default) {}

        /// <inheritdoc />
        public VisualStudioCodeCredential(string tenantId, TokenCredentialOptions options) : this(tenantId, options, default, default) {}

        internal VisualStudioCodeCredential(string tenantId, TokenCredentialOptions options, IFileSystemService fileSystem, IVisualStudioCodeAdapter vscAdapter)
        {
            _tenantId = tenantId ?? "common";
            _pipeline = CredentialPipeline.GetInstance(options);
            _fileSystem = fileSystem ?? FileSystemService.Default;
            _vscAdapter = vscAdapter ?? GetVscAdapter();
        }

        /// <inheritdoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await GetTokenImplAsync(requestContext, true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenImplAsync(requestContext, false, cancellationToken).EnsureCompleted();

        private async ValueTask<AccessToken> GetTokenImplAsync(TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("VisualStudioCodeCredential.GetToken", requestContext);

            try
            {
                GetUserSettings(out var tenant, out var environmentName);

                var cloudInstance = GetAzureCloudInstance(environmentName);
                var storedCredentials = _vscAdapter.GetCredentials(CredentialsSection, environmentName);

                if (!IsBase64String(storedCredentials))
                {
                    throw new CredentialUnavailableException("Need to re-authenticate user in VSCode Azure Account.");
                }

                var publicClient = (IByRefreshToken)PublicClientApplicationBuilder.Create(ClientId)
                    .WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline.HttpPipeline))
                    .WithAuthority(cloudInstance, tenant)
                    .Build();

                var result = await publicClient.AcquireTokenByRefreshToken(requestContext.Scopes, storedCredentials).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);
                throw;
            }
            catch (Exception e)
            {
                throw scope.FailAndWrap(e);
            }
        }

        private static bool IsBase64String(string str)
            => str.Select(t => (uint)t).All(ch => ch >= '0' && ch <= '9' || ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch == '_' || ch == '-');

        private void GetUserSettings(out string tenant, out string environmentName)
        {
            var path = _vscAdapter.GetUserSettingsPath();
            tenant = _tenantId;
            environmentName = "Azure";

            try
            {
                var content = _fileSystem.ReadAllText(path);
                var root = JsonDocument.Parse(content).RootElement;

                if (root.TryGetProperty("azure.tenant", out JsonElement tenantProperty))
                {
                    tenant = tenantProperty.GetString();
                }

                if (root.TryGetProperty("azure.cloud", out JsonElement environmentProperty))
                {
                    environmentName = environmentProperty.GetString();
                }
            }
            catch (IOException) { }
            catch (JsonException) { }
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

        private static AzureCloudInstance GetAzureCloudInstance(string name) =>
            name switch
            {
                "Azure" => AzureCloudInstance.AzurePublic,
                "AzureChina" => AzureCloudInstance.AzureChina,
                "AzureGermanCloud" => AzureCloudInstance.AzureGermany,
                "AzureUSGovernment" => AzureCloudInstance.AzureUsGovernment,
                _ => AzureCloudInstance.AzurePublic
            };
    }
}
