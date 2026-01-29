// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public VisualStudioCodeCredential() : base(CredentialOptionsMapper.GetBrokerOptions(out bool isBrokerEnabled, fileSystem: FileSystemService.Default) ?? CredentialOptionsMapper.CreateFallbackOptions())
        {
            _isBrokerOptionsEnabled = isBrokerEnabled;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options)
            : base(CredentialOptionsMapper.GetBrokerOptions(out bool isBrokerEnabled, options, FileSystemService.Default) ?? CredentialOptionsMapper.CreateFallbackOptions(options))
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
    }
}
