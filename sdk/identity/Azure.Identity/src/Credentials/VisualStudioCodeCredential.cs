// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID as the user signed in to Visual Studio Code via
    /// the broker.
    /// </summary>
    /// <remarks>
    /// This credential requires installation of the following components:
    /// <list type="bullet">
    /// <item><description><see href="https://www.nuget.org/packages/Azure.Identity.Broker">Azure.Identity.Broker package</see></description></item>
    /// <item><description><see href="https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureresourcegroups">Azure Resources extension</see></description></item>
    /// </list>
    /// </remarks>
    public class VisualStudioCodeCredential : InteractiveBrowserCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/vscodecredential/troubleshoot";

        private readonly bool _isBrokerOptionsEnabled;

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential() : base(TryGetBrokerOptions(FileSystemService.Default, out bool isBrokerEnabled) ?? CreateFallbackOptions())
        {
            _isBrokerOptionsEnabled = isBrokerEnabled;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options)
            : base(TryGetBrokerOptionsWithCredentialOptions(FileSystemService.Default, options, out bool isBrokerEnabled) ?? CreateFallbackOptionsFromCredentialOptions(options))
        {
            _isBrokerOptionsEnabled = isBrokerEnabled;
        }

        /// <InheritDoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default) =>
            GetTokenImpl(false, requestContext, cancellationToken).EnsureCompleted();

        /// <InheritDoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default) =>
            await GetTokenImpl(true, requestContext, cancellationToken).ConfigureAwait(false);

        private async Task<AccessToken> GetTokenImpl(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (!_isBrokerOptionsEnabled)
            {
                throw new CredentialUnavailableException($"{nameof(VisualStudioCodeCredential)} requires the Azure.Identity.Broker package to be referenced from the project. {CredentialsSection} {Troubleshooting}");
            }

            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(VisualStudioCodeCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                var token = async
                    ? await base.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                    : base.GetToken(requestContext, cancellationToken);
                scope.Succeeded(token);

                return token;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, "VisualStudioCodeCredential failed to silently authenticate via the broker", isCredentialUnavailable: true);
            }
        }

        /// <summary>
        /// Attempts to get broker options and returns them if available, along with a flag indicating success.
        /// </summary>
        /// <param name="fileSystem">The file system service to use for reading authentication records.</param>
        /// <param name="isBrokerEnabled">Output parameter indicating whether broker options are available.</param>
        /// <returns>The broker options if available, null otherwise.</returns>
        private static InteractiveBrowserCredentialOptions TryGetBrokerOptions(IFileSystemService fileSystem, out bool isBrokerEnabled)
        {
            isBrokerEnabled = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out InteractiveBrowserCredentialOptions options);

            if (isBrokerEnabled && options != null)
            {
                options.AuthenticationRecord = GetAuthenticationRecord(fileSystem);
                return options;
            }

            return null;
        }

        /// <summary>
        /// Creates fallback options when broker options are not available.
        /// This prevents the constructor from failing and defers the error to GetToken.
        /// </summary>
        /// <returns>A minimal InteractiveBrowserCredentialOptions instance.</returns>
        private static InteractiveBrowserCredentialOptions CreateFallbackOptions()
        {
            return new InteractiveBrowserCredentialOptions();
        }

        /// <summary>
        /// Attempts to get broker options with legacy credential options and returns them if available, along with a flag indicating success.
        /// </summary>
        /// <param name="fileSystem">The file system service to use for reading authentication records.</param>
        /// <param name="credentialOptions">The legacy credential options.</param>
        /// <param name="isBrokerEnabled">Output parameter indicating whether broker options are available.</param>
        /// <returns>The broker options if available, null otherwise.</returns>
        private static InteractiveBrowserCredentialOptions TryGetBrokerOptionsWithCredentialOptions(IFileSystemService fileSystem, VisualStudioCodeCredentialOptions credentialOptions, out bool isBrokerEnabled)
        {
            isBrokerEnabled = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out InteractiveBrowserCredentialOptions options);

            if (isBrokerEnabled && options != null)
            {
                if (credentialOptions != null)
                {
                    options.TenantId = credentialOptions.TenantId;
                    options.AdditionallyAllowedTenants = credentialOptions.AdditionallyAllowedTenants;
                    options.AuthorityHost = credentialOptions.AuthorityHost;
                    options.IsUnsafeSupportLoggingEnabled = credentialOptions.IsUnsafeSupportLoggingEnabled;
                    options.IsChainedCredential = credentialOptions.IsChainedCredential;
                }

                options.AuthenticationRecord = GetAuthenticationRecord(fileSystem);
                return options;
            }

            return null;
        }

        /// <summary>
        /// Creates fallback options when broker options are not available, based on legacy credential options.
        /// This prevents the constructor from failing and defers the error to GetToken.
        /// </summary>
        /// <param name="credentialOptions">The legacy credential options to base fallback options on.</param>
        /// <returns>A minimal InteractiveBrowserCredentialOptions instance.</returns>
        private static InteractiveBrowserCredentialOptions CreateFallbackOptionsFromCredentialOptions(VisualStudioCodeCredentialOptions credentialOptions)
        {
            var fallbackOptions = new InteractiveBrowserCredentialOptions();

            if (credentialOptions != null)
            {
                fallbackOptions.TenantId = credentialOptions.TenantId;
                fallbackOptions.AdditionallyAllowedTenants = credentialOptions.AdditionallyAllowedTenants;
                fallbackOptions.AuthorityHost = credentialOptions.AuthorityHost;
                fallbackOptions.IsUnsafeSupportLoggingEnabled = credentialOptions.IsUnsafeSupportLoggingEnabled;
                fallbackOptions.IsChainedCredential = credentialOptions.IsChainedCredential;
            }

            return fallbackOptions;
        }

        internal static AuthenticationRecord GetAuthenticationRecord(IFileSystemService _fileSystem)
        {
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            var authRecordPathLowerCase = Path.Combine(homeDir, ".azure", "ms-azuretools.vscode-azureresourcegroups", "authRecord.json");
            var authRecordPathUpperCase = Path.Combine(homeDir, ".Azure", "ms-azuretools.vscode-azureresourcegroups", "authRecord.json");

            var authRecordPath = _fileSystem.FileExists(authRecordPathLowerCase) ? authRecordPathLowerCase :
                                 _fileSystem.FileExists(authRecordPathUpperCase) ? authRecordPathUpperCase : null;

            if (authRecordPath == null)
            {
                return null;
            }

            try
            {
                using var authRecordStream = _fileSystem.GetFileStream(authRecordPath);
                var authRecord = AuthenticationRecord.Deserialize(authRecordStream);
                if (authRecord != null && !string.IsNullOrEmpty(authRecord.TenantId) && !string.IsNullOrEmpty(authRecord.HomeAccountId))
                {
                    return authRecord;
                }
            }
            catch (Exception) { }
            return null;
        }
    }
}
