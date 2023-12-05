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
    /// Enables authentication to Microsoft Entra ID as the user signed in to Visual Studio Code via
    /// the 'Azure Account' extension.
    ///
    /// It's a <see href="https://github.com/Azure/azure-sdk-for-net/issues/27263">known issue</see> that `VisualStudioCodeCredential`
    /// doesn't work with <see href="https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account">Azure Account extension</see>
    /// versions newer than <b>0.9.11</b>. A long-term fix to this problem is in progress. In the meantime, consider authenticating
    /// with <see cref="AzureCliCredential"/>.
    /// </summary>
    public class VisualStudioCodeCredential : TokenCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string ClientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
        private readonly IVisualStudioCodeAdapter _vscAdapter;
        private readonly IFileSystemService _fileSystem;
        private readonly CredentialPipeline _pipeline;
        internal string TenantId { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        private const string _commonTenant = "common";
        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/vscodecredential/troubleshoot";
        internal MsalPublicClient Client { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential() : this(default, default, default, default, default) { }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/> with the specified options.
        /// </summary>
        /// <param name="options">Options for configuring the credential.</param>
        public VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options) : this(options, default, default, default, default) { }

        internal VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client, IFileSystemService fileSystem,
            IVisualStudioCodeAdapter vscAdapter)
        {
            TenantId = options?.TenantId;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            Client = client ?? new MsalPublicClient(_pipeline, TenantId, ClientId, null, options);
            _fileSystem = fileSystem ?? FileSystemService.Default;
            _vscAdapter = vscAdapter ?? GetVscAdapter();
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
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

                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds) ?? tenant;

                if (string.Equals(tenantId, Constants.AdfsTenantId, StringComparison.Ordinal))
                {
                    throw new CredentialUnavailableException("VisualStudioCodeCredential authentication unavailable. ADFS tenant / authorities are not supported.");
                }

                var cloudInstance = GetAzureCloudInstance(environmentName);
                string storedCredentials = GetStoredCredentials(environmentName);

                var result = await Client
                    .AcquireTokenByRefreshTokenAsync(requestContext.Scopes, requestContext.Claims, storedCredentials, cloudInstance, tenantId, requestContext.IsCaeEnabled, async, cancellationToken)
                    .ConfigureAwait(false);
                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (MsalUiRequiredException e)
            {
                throw scope.FailWrapAndThrow(
                    new CredentialUnavailableException(
                        $"{nameof(VisualStudioCodeCredential)} authentication unavailable. Token acquisition failed. Ensure that you have authenticated in VSCode Azure Account. " + Troubleshooting,
                        e));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
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
                throw new CredentialUnavailableException("Stored credentials not found. Need to authenticate user in VSCode Azure Account. " + Troubleshooting, ex);
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
            tenant = TenantId ?? _commonTenant;
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
