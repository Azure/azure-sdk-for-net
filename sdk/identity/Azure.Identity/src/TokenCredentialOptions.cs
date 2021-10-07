// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to the OAUTH identity service.
    /// </summary>
    public class TokenCredentialOptions : ClientOptions
    {
        private Uri _authorityHost;
        private readonly TokenCredentialDiagnosticsOptions _diagnostics;

        /// <summary>
        /// Constructs a new <see cref="TokenCredentialOptions"/> instance.
        /// </summary>
        public TokenCredentialOptions()
        {
            _diagnostics = new TokenCredentialDiagnosticsOptions(base.DiagnosticsCore());
        }

        /// <summary>
        /// The host of the Azure Active Directory authority. The default is https://login.microsoftonline.com/. For well known authority hosts for Azure cloud instances see <see cref="AzureAuthorityHosts"/>.
        /// </summary>
        public Uri AuthorityHost
        {
            get { return _authorityHost ?? AzureAuthorityHosts.GetDefault(); }
            set { _authorityHost = Validations.ValidateAuthorityHost(value); }
        }

        /// <summary>
        /// Gets the credential diagnostic options.
        /// </summary>
        public new TokenCredentialDiagnosticsOptions Diagnostics => _diagnostics;

        /// <inheritdoc/>
        protected override DiagnosticsOptions DiagnosticsCore() => Diagnostics;
    }
}
