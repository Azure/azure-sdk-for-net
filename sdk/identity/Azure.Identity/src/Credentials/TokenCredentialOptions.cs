// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to the OAUTH identity service.
    /// </summary>
    public class TokenCredentialOptions : ClientOptions
    {
        private Uri _authorityHost;

        /// <summary>
        /// Constructs a new <see cref="TokenCredentialOptions"/> instance.
        /// </summary>
        public TokenCredentialOptions()
            : base(diagnostics: new TokenCredentialDiagnosticsOptions())
        {
        }

        /// <summary>
        /// The host of the Microsoft Entra authority. The default is https://login.microsoftonline.com/. For well known authority hosts for Azure cloud instances see <see cref="AzureAuthorityHosts"/>.
        /// </summary>
        public Uri AuthorityHost
        {
            get { return _authorityHost ?? AzureAuthorityHosts.GetDefault(); }
            set { _authorityHost = Validations.ValidateAuthorityHost(value); }
        }

        /// <summary>
        /// Gets or sets value indicating if ETW logging that contains potentially sensitive content should be logged.
        /// Setting this property to true will not disable redaction of <see cref="Request"/> Content. To enable logging of sensitive <see cref="Request.Content"/>
        /// the <see cref="DiagnosticsOptions.IsLoggingContentEnabled"/> property must be set to <c>true</c>.
        /// Setting this property to `true` equates to passing 'true' for the enablePiiLogging parameter to the 'WithLogging' method on the MSAL client builder.
        /// </summary>
        public bool IsUnsafeSupportLoggingEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether this credential is part of a chained credential.
        /// </summary>
        internal bool IsChainedCredential { get; set; }

        internal TenantIdResolverBase TenantIdResolver { get; set; } = TenantIdResolverBase.Default;

        internal virtual T Clone<T>()
            where T : TokenCredentialOptions, new()
        {
            T clone = new T();

            // copy TokenCredentialOptions Properties
            clone.AuthorityHost = AuthorityHost;

            clone.IsUnsafeSupportLoggingEnabled = IsUnsafeSupportLoggingEnabled;

            // copy TokenCredentialDiagnosticsOptions specific options
            clone.Diagnostics.IsAccountIdentifierLoggingEnabled = Diagnostics.IsAccountIdentifierLoggingEnabled;

            // copy ISupportsDisableInstanceDiscovery
            CloneIfImplemented<ISupportsDisableInstanceDiscovery>(this, clone, (o, c) => c.DisableInstanceDiscovery = o.DisableInstanceDiscovery);

            // copy ISupportsTokenCachePersistenceOptions
            CloneIfImplemented<ISupportsTokenCachePersistenceOptions>(this, clone, (o, c) => c.TokenCachePersistenceOptions = o.TokenCachePersistenceOptions);

            // copy ISupportsAdditionallyAllowedTenants
            CloneIfImplemented<ISupportsAdditionallyAllowedTenants>(this, clone, (o, c) => CloneListItems(o.AdditionallyAllowedTenants, c.AdditionallyAllowedTenants));

            // copy base ClientOptions properties, this would be replaced by a similar method on the base class

            // only copy transport if the original has changed from the default so as not to set IsCustomTransportSet unintentionally
            if (Transport != Default.Transport)
            {
                clone.Transport = Transport;
            }

            // clone base Diagnostic options
            clone.Diagnostics.ApplicationId = Diagnostics.ApplicationId;
            clone.Diagnostics.IsLoggingEnabled = Diagnostics.IsLoggingEnabled;
            clone.Diagnostics.IsTelemetryEnabled = Diagnostics.IsTelemetryEnabled;
            clone.Diagnostics.LoggedContentSizeLimit = Diagnostics.LoggedContentSizeLimit;
            clone.Diagnostics.IsDistributedTracingEnabled = Diagnostics.IsDistributedTracingEnabled;
            clone.Diagnostics.IsLoggingContentEnabled = Diagnostics.IsLoggingContentEnabled;

            CloneListItems(Diagnostics.LoggedHeaderNames, clone.Diagnostics.LoggedHeaderNames);
            CloneListItems(Diagnostics.LoggedQueryParameters, clone.Diagnostics.LoggedQueryParameters);

            // clone base RetryOptions
            clone.RetryPolicy = RetryPolicy;

            clone.Retry.MaxRetries = Retry.MaxRetries;
            clone.Retry.Delay = Retry.Delay;
            clone.Retry.MaxDelay = Retry.MaxDelay;
            clone.Retry.Mode = Retry.Mode;
            clone.Retry.NetworkTimeout = Retry.NetworkTimeout;

            // TODO: clone additional policies
            // at the moment there is no way to access policies added to the ClientOptions

            return clone;
        }

        private static void CloneListItems<T>(IList<T> original, IList<T> clone)
        {
            clone.Clear();

            foreach (var item in original)
            {
                clone.Add(item);
            }
        }

        private static void CloneIfImplemented<T>(TokenCredentialOptions original, TokenCredentialOptions clone, Action<T, T> cloneOperation)
            where T : class
        {
            if (original is T originalAsT && clone is T cloneAsT)
            {
                cloneOperation(originalAsT, cloneAsT);
            }
        }

        /// <summary>
        /// Gets the credential diagnostic options.
        /// </summary>
        public new TokenCredentialDiagnosticsOptions Diagnostics => base.Diagnostics as TokenCredentialDiagnosticsOptions;
    }
}
