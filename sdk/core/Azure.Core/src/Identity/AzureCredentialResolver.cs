// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Versioning;
using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="CredentialResolver"/> that produces Azure
    /// <see cref="TokenCredential"/> instances from an
    /// <see cref="IConfigurationSection"/>, dispatching on the section's
    /// <c>CredentialSource</c> value (e.g. <c>AzureCliCredential</c>,
    /// <c>ManagedIdentityCredential</c>, <c>EnvironmentCredential</c>,
    /// <c>WorkloadIdentityCredential</c>, <c>ChainedTokenCredential</c>).
    /// </summary>
    /// <remarks>
    /// Register this resolver explicitly via <see cref="ConfigurationExtensions.AddAzureCredentialResolver(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// (or its host-builder overload), or rely on
    /// <see cref="ConfigurationExtensions.GetAzureCredentialSettings(IConfiguration, string)"/>
    /// and friends, which transparently append a built-in instance to the
    /// resolver chain. The class has a public parameterless constructor so it
    /// can be used with <c>AddCredentialResolver&lt;AzureCredentialResolver&gt;()</c>.
    /// </remarks>
    [Experimental("SCME0002")]
    [UnsupportedOSPlatform("browser")]
    public sealed class AzureCredentialResolver : CredentialResolver
    {
        /// <summary>
        /// A shared singleton suitable for standalone callers that want to
        /// participate in the process-wide resolved-credential cache without
        /// allocating a new resolver instance per call.
        /// </summary>
        public static AzureCredentialResolver Default { get; } = new AzureCredentialResolver();

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
            => TryResolveInternal(credentialSection, ResolveThroughSelf, out provider);

        /// <inheritdoc />
        public override bool TryResolve(
            IConfigurationSection credentialSection,
            Func<IConfigurationSection, AuthenticationTokenProvider?> resolveChild,
            [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            Argument.AssertNotNull(resolveChild, nameof(resolveChild));
            return TryResolveInternal(credentialSection, resolveChild, out provider);
        }

        // resolveChild for the single-argument overload, which has no engine behind it:
        // chain entries are resolved through this resolver alone.
        private AuthenticationTokenProvider? ResolveThroughSelf(IConfigurationSection child)
            => TryResolve(child, out AuthenticationTokenProvider? provider) ? provider : null;

        private static bool TryResolveInternal(
            IConfigurationSection credentialSection,
            Func<IConfigurationSection, AuthenticationTokenProvider?> resolveChild,
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

            // A chain entry (flagged by TryResolveChain via ChainedChildSection) is built
            // with IsChainedCredential=true so transient failures surface as
            // CredentialUnavailableException and the enclosing ChainedTokenCredential falls
            // through to the next entry. This is checked before the ChainedTokenCredential
            // branch so a nested chain entry is routed to CreateCredential, which rejects
            // nesting, rather than recursively building a nested chain.
            if (IsChainEntry(credentialSection))
            {
                provider = ChainedTokenCredentialFactory.CreateCredential(new DefaultAzureCredentialOptions(settings, credentialSection));
                return true;
            }

            if (source == Constants.ChainedTokenCredential)
            {
                return TryResolveChain(credentialSection, resolveChild, out provider);
            }

            // Top-level single source: build the concrete credential directly through
            // DefaultAzureCredentialFactory — the same helpers DefaultAzureCredential
            // uses internally — so construction is identical but without the surrounding
            // DefaultAzureCredential chain. Sources not listed here (ApiKey, Broker, and
            // anything a third party owns) are deferred.
            DefaultAzureCredentialFactory factory = new(new DefaultAzureCredentialOptions(settings, credentialSection));
            provider = source switch
            {
                Constants.AzureCliCredential => factory.CreateAzureCliCredential(),
                Constants.AzurePowerShellCredential => factory.CreateAzurePowerShellCredential(),
                Constants.AzureDeveloperCliCredential => factory.CreateAzureDeveloperCliCredential(),
                Constants.VisualStudioCredential => factory.CreateVisualStudioCredential(),
                Constants.VisualStudioCodeCredential => factory.CreateVisualStudioCodeCredential(),
                Constants.EnvironmentCredential => factory.CreateEnvironmentCredential(),
                Constants.WorkloadIdentityCredential => factory.CreateWorkloadIdentityCredential(),
                Constants.ManagedIdentityCredential => factory.CreateManagedIdentityCredential(isChained: false),
                Constants.InteractiveBrowserCredential => factory.CreateInteractiveBrowserCredential(),
                Constants.AzurePipelinesCredential => factory.CreateAzurePipelinesCredential(),
                Constants.ManagedIdentityAsFederatedIdentityCredential => factory.CreateManagedIdentityAsFederatedIdentityCredential(),
                _ => null,
            };

            return provider is not null;
        }

        private static bool IsChainEntry(IConfigurationSection section)
            => bool.TryParse(section[nameof(TokenCredentialOptions.IsChainedCredential)], out bool isChained) && isChained;

        private static bool TryResolveChain(
            IConfigurationSection credentialSection,
            Func<IConfigurationSection, AuthenticationTokenProvider?> resolveChild,
            [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
        {
            List<IConfigurationSection> children = credentialSection.GetSection("Sources").GetChildren().ToList();
            if (children.Count == 0)
            {
                provider = null;
                return false;
            }

            TokenCredential[] chain = new TokenCredential[children.Count];

            for (int i = 0; i < children.Count; i++)
            {
                // Every entry is resolved through the active resolver chain, marked as a
                // chain entry, so any registered CredentialResolver — this one, the broker
                // resolver, or a third party — can claim it. Recognized Azure sources
                // re-enter this resolver's chain-entry path above.
                if (resolveChild(new ChainedChildSection(children[i])) is not TokenCredential resolved)
                {
                    provider = null;
                    return false;
                }

                chain[i] = resolved;
            }

            provider = new ChainedTokenCredential(chain);
            return true;
        }
    }
}
