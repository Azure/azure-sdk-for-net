// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity.Credentials;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID as the user signed in to Visual Studio Code via
    /// the broker. Note that this credential relies on a reference to the Azure.Identity.Broker package.
    /// </summary>
    public class VisualStudioCodeCredential : InteractiveBrowserCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/vscodecredential/troubleshoot";

        private readonly bool _isBrokerOptionsEnabled;

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential() : base(CredentialOptionsMapper.TryGetBrokerOptions(out bool isBrokerEnabled, FileSystemService.Default) ?? CredentialOptionsMapper.CreateFallbackOptions())
        {
            _isBrokerOptionsEnabled = isBrokerEnabled;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options)
            : base(CredentialOptionsMapper.GetBrokerOptionsWithCredentialOptions(options, out bool isBrokerEnabled, FileSystemService.Default) ?? CredentialOptionsMapper.CreateFallbackOptionsFromCredentialOptions(options))
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
                throw new CredentialUnavailableException($"The {nameof(VisualStudioCodeCredential)} requires the Azure.Identity.Broker package to be referenced. {CredentialsSection} {Troubleshooting}");
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
