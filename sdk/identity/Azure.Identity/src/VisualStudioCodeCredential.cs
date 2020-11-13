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
    /// Enables authentication to Azure Active Directory using data from Visual Studio Code.
    /// </summary>
    public class VisualStudioCodeCredential : TokenCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string ClientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
        private readonly IVisualStudioCodeAdapter _vscAdapter;
        private readonly IFileSystemService _fileSystem;
        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;
        private readonly MsalPublicClient _client;

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential() : this(default, default, default, default, default) { }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/> with the specified options.
        /// </summary>
        /// <param name="options">Options for configuring the credential.</param>
        public VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options) : this(options, default, default, default, default) { }

        internal VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client, IFileSystemService fileSystem, IVisualStudioCodeAdapter vscAdapter)
        {
            _tenantId = options?.TenantId ?? "common";
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            _client = client ?? new MsalPublicClient(_pipeline, options?.TenantId, ClientId, null, null);
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

                if (string.Equals(tenant, Constants.AdfsTenantId, StringComparison.Ordinal))
                {
                    throw new CredentialUnavailableException("VisualStudioCodeCredential authentication unavailable. ADFS tenant / authorities are not supported.");
                }

                var cloudInstance = GetAzureCloudInstance(environmentName);
                string storedCredentials = GetStoredCredentials(environmentName);

                var result = await _client.AcquireTokenByRefreshToken(requestContext.Scopes, storedCredentials, cloudInstance, tenant, async, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (MsalUiRequiredException e)
            {
                throw scope.FailWrapAndThrow(new CredentialUnavailableException($"{nameof(VisualStudioCodeCredential)} authentication unavailable. Token acquisition failed. Ensure that you have authenticated in VSCode Azure Account.", e));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private string GetStoredCredentials(string environmentName)
        {
            try
            {
                var storedCredentials = _vscAdapter.GetCredentials(CredentialsSection, environmentName);
                if (!IsRefreshTokenString(storedCredentials))
                {
                    throw new CredentialUnavailableException("Need to re-authenticate user in VSCode Azure Account.");
                }

                return storedCredentials;
            }
            catch (Exception ex) when (!(ex is OperationCanceledException || ex is CredentialUnavailableException))
            {
                throw new CredentialUnavailableException("Stored credentials not found. Need to authenticate user in VSCode Azure Account.", ex);
            }
        }

        private static bool IsRefreshTokenString(string str)
        {
            for (var index = 0; index < str.Length; index++)
            {
                var ch = (uint)str[index];
                if ((ch < '0' || ch > '9') && (ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z') && ch != '_' && ch != '-' && ch != '.')
                {
                    return false;
                }
            }

            return true;
        }

        private void GetUserSettings(out string tenant, out string environmentName)
        {
            var path = _vscAdapter.GetUserSettingsPath();
            tenant = _tenantId;
            environmentName = "AzureCloud";

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
                "AzureCloud" => AzureCloudInstance.AzurePublic,
                "AzureChina" => AzureCloudInstance.AzureChina,
                "AzureGermanCloud" => AzureCloudInstance.AzureGermany,
                "AzureUSGovernment" => AzureCloudInstance.AzureUsGovernment,
                _ => AzureCloudInstance.AzurePublic
            };
    }
}
