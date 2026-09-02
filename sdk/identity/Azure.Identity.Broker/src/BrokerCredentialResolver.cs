// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// A <see cref="CredentialResolver"/> that produces broker-backed
    /// <see cref="TokenCredential"/> instances from an
    /// <see cref="IConfigurationSection"/>. It claims sections whose
    /// <c>CredentialSource</c> resolves to <c>BrokerCredential</c> or
    /// <c>VisualStudioCodeCredential</c> — the two credential sources that
    /// require the <c>Azure.Identity.Broker</c> package to function. All
    /// other sources are deferred (return <see langword="false"/>) so the
    /// next resolver in the chain (typically <see cref="AzureCredentialResolver"/>)
    /// can claim them.
    /// </summary>
    /// <remarks>
    /// Register this resolver explicitly via
    /// <see cref="ConfigurationExtensions.AddBrokerCredentialResolver(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// (or its host-builder overload) for the DI flow, or pass an instance to
    /// <see cref="Azure.Identity.ConfigurationExtensions.GetAzureClientSettings{TSettings}(IConfiguration, string, CredentialResolver[])"/>
    /// (and friends) for the standalone configuration flow. The class has a
    /// public parameterless constructor so it can be used with
    /// <c>AddCredentialResolver&lt;BrokerCredentialResolver&gt;()</c>.
    /// </remarks>
    [Experimental("SCME0002")]
    [UnsupportedOSPlatform("browser")]
    public sealed class BrokerCredentialResolver : CredentialResolver
    {
        /// <summary>
        /// A shared singleton instance suitable for both standalone and DI usage.
        /// SCM's credential cache keys cached providers by resolver reference, so
        /// passing this instance into a standalone <c>GetCredential</c> call (or any
        /// resolver chain you build by hand) lets that path share cached credentials
        /// with code paths that resolved through DI via
        /// <see cref="ConfigurationExtensions.AddBrokerCredentialResolver(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>.
        /// Stateless; safe to share across threads.
        /// </summary>
        public static BrokerCredentialResolver Default { get; } = new BrokerCredentialResolver();

        /// <summary>
        /// Initializes a new instance of <see cref="BrokerCredentialResolver"/>.
        /// </summary>
        public BrokerCredentialResolver()
        {
        }

        /// <inheritdoc />
        public override bool TryResolve(
            IConfigurationSection credentialSection,
            [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            if (credentialSection is null || !credentialSection.Exists())
            {
                provider = null;
                return false;
            }

            CredentialSettings settings = new(credentialSection);

            // CredentialSettings lowercases CredentialSource on assignment, and
            // the schema this package ships advertises only the full names
            // "BrokerCredential" / "VisualStudioCodeCredential" (matching the
            // Constants values). Short-form aliases like "broker" /
            // "visualstudiocode" are deferred to AzureCredentialResolver, which
            // still expands them via DefaultAzureCredentialOptions.TryConvertCredentialSource.
            string? source = settings.CredentialSource;
            if (source != Constants.BrokerCredential && source != Constants.VisualStudioCodeCredential)
            {
                provider = null;
                return false;
            }

            // Delegate to the existing DefaultAzureCredentialFactory construction
            // paths so this resolver flows the full set of broker / VS Code
            // options (UseDefaultBrokerAccount, IsLegacyMsaPassthroughEnabled,
            // LoginHint, AuthenticationRecord, RedirectUri, AuthorityHost,
            // TokenCachePersistenceOptions, AdditionallyAllowedTenants, etc.)
            // identically to existing single-source resolution. IsChainedCredential
            // is set to false by the factory because explicit single-source
            // selection is not part of a DefaultAzureCredential chain.
            // The AZC0112 suppression here goes away in a future phase, when
            // this resolver bypasses DefaultAzureCredentialOptions /
            // DefaultAzureCredentialFactory entirely by constructing
            // BrokerCredential / VisualStudioCodeCredential directly from
            // the IConfigurationSection.
#pragma warning disable AZC0112 // Accessing internal members via InternalsVisibleTo
            DefaultAzureCredentialOptions options = new(settings, credentialSection);
            DefaultAzureCredentialFactory factory = new(options);
            provider = source == Constants.BrokerCredential
                ? factory.CreateBrokerCredential()
                : factory.CreateVisualStudioCodeCredential();
#pragma warning restore AZC0112
            return true;
        }
    }
}
