// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="CredentialResolver"/> that produces Azure credentials
    /// (<see cref="TokenCredential"/> instances) from an
    /// <see cref="IConfigurationSection"/>. It dispatches on the
    /// <c>CredentialSource</c> value of the supplied section and recognizes the
    /// full set of Azure token-based credential sources (e.g.
    /// <c>AzureCliCredential</c>, <c>ManagedIdentityCredential</c>,
    /// <c>EnvironmentCredential</c>, <c>WorkloadIdentityCredential</c>,
    /// <c>ChainedTokenCredential</c>, etc.). API-key sections
    /// (<c>CredentialSource: ApiKeyCredential</c>) are intentionally NOT
    /// claimed by this resolver — consuming clients that accept an API key are
    /// expected to dispatch on <c>Credential.CredentialSource</c> themselves
    /// at construction time and read <c>Credential.Key</c> directly.
    /// </summary>
    /// <remarks>
    /// Register this resolver explicitly via <see cref="ConfigurationExtensions.AddAzureCredentialResolver(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// (or its host-builder overload), or rely on
    /// <see cref="ConfigurationExtensions.GetAzureCredential(IConfiguration, string)"/>
    /// and friends, which transparently append a built-in instance to the
    /// resolver chain. The class has a public parameterless constructor so it
    /// can be used with <c>AddCredentialResolver&lt;AzureCredentialResolver&gt;()</c>.
    /// </remarks>
    [Experimental("SCME0002")]
    [UnsupportedOSPlatform("browser")]
    public sealed class AzureCredentialResolver : CredentialResolver
    {
        /// <summary>
        /// A shared singleton used by built-in helpers (e.g.
        /// <see cref="ConfigurationExtensions.GetAzureCredential(IConfiguration, string)"/>).
        /// </summary>
        internal static AzureCredentialResolver Instance { get; } = new AzureCredentialResolver();

        /// <summary>
        /// Initializes a new instance of <see cref="AzureCredentialResolver"/>.
        /// </summary>
        public AzureCredentialResolver()
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

            if (!DefaultAzureCredentialOptions.TryConvertCredentialSource(settings.CredentialSource, out string source))
            {
                provider = null;
                return false;
            }

            // ApiKey is intentionally not claimed by this resolver — consuming
            // libraries dispatch on Credential.CredentialSource themselves and
            // read Credential.Key directly. Returning false here lets callers
            // distinguish "no token credential available" from "credential not
            // configured at all".
            if (source == Constants.ApiKeyCredential)
            {
                provider = null;
                return false;
            }

            DefaultAzureCredentialOptions options = new(settings, credentialSection);

            if (source == Constants.ChainedTokenCredential)
            {
                provider = new ChainedTokenCredential(ChainedTokenCredentialFactory.CreateCredentialChain(options));
                return true;
            }

            // Single-source dispatch goes through DefaultAzureCredential, which
            // preserves env-var defaults, the Azure.Identity.Broker reflection
            // hop for BrokerCredential, and all other existing single-source
            // construction behavior. After AzureBrokerCredentialResolver ships
            // (phase 3) and the chain factory is rewired (phase 3.5), this
            // path will dispatch to per-source helpers directly.
            provider = new DefaultAzureCredential(options);
            return true;
        }
    }
}
