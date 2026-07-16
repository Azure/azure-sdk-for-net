// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity.CredentialResolvers
{
    public class AzureCredentialResolverTests
    {
        private static IConfigurationSection BuildSection(IDictionary<string, string> values)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();
            return config.GetSection("MyClient:Credential");
        }

        [Test]
        public void TryResolve_NullSection_ReturnsFalse()
        {
            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(null, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_NonExistentSection_ReturnsFalse()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(config.GetSection("Missing"), out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_NoCredentialSource_ReturnsFalse()
        {
            // Section exists but lacks a CredentialSource value — defer to next resolver.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:TenantId"] = "some-tenant",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_UnknownCredentialSource_ReturnsFalse()
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "NotAKnownCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ApiKeyCredential_ReturnsFalse()
        {
            // ApiKey is intentionally not claimed by AzureCredentialResolver. Consuming
            // libraries dispatch on Credential.CredentialSource themselves and read
            // Credential.Key directly.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["MyClient:Credential:Key"] = "secret-api-key-value",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ApiKeyCredential_MissingKey_ReturnsFalse()
        {
            // ApiKey path always returns false, regardless of whether Key is present.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ApiKeyShortName_NormalizedAndStillReturnsFalse()
        {
            // CredentialSettings normalizes "apikey" -> "apikeycredential"; the resolver
            // still defers regardless of which alias was supplied.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "apikey",
                ["MyClient:Credential:Key"] = "k",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_ProducesChainedCredential()
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                ["MyClient:Credential:Sources:0:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Sources:1:CredentialSource"] = "EnvironmentCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));
            Assert.IsInstanceOf<ChainedTokenCredential>(provider);
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_EntriesAreChained()
        {
            // Each entry in a resolver-built chain must be constructed with
            // IsChainedCredential=true so a transient failure surfaces as
            // CredentialUnavailableException and ChainedTokenCredential falls
            // through to the next entry instead of aborting on the first one.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                ["MyClient:Credential:Sources:0:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Sources:1:CredentialSource"] = "AzurePowerShellCredential",
                ["MyClient:Credential:Sources:2:CredentialSource"] = "AzureDeveloperCliCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));

            TokenCredential[] sources = GetChainSources((ChainedTokenCredential)provider);
            Assert.AreEqual(3, sources.Length);
            foreach (TokenCredential source in sources)
            {
                Assert.IsTrue(GetIsChained(source), $"{source.GetType().Name} should be constructed as a chained credential");
            }
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_CustomSourceResolvedByThirdPartyResolver()
        {
            // A source AzureCredentialResolver doesn't recognize is handed to the
            // active resolver chain so a third-party resolver can contribute the
            // chain entry — and it receives the chained signal.
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                    ["MyClient:Credential:Sources:0:CredentialSource"] = "AzureCliCredential",
                    ["MyClient:Credential:Sources:1:CredentialSource"] = "MyCustomCredential",
                })
                .Build();

            CredentialSettings settings = config.GetAzureCredentialSettings("MyClient:Credential", new FakeCustomResolver());

            Assert.IsNotNull(settings);
            Assert.IsInstanceOf<ChainedTokenCredential>(settings.TokenProvider);

            TokenCredential[] sources = GetChainSources((ChainedTokenCredential)settings.TokenProvider);
            Assert.AreEqual(2, sources.Length);
            Assert.IsInstanceOf<AzureCliCredential>(sources[0]);

            FakeCustomCredential custom = sources[1] as FakeCustomCredential;
            Assert.IsNotNull(custom, "Third-party resolver should have contributed the second chain entry");
            Assert.IsTrue(custom.IsChained, "Custom chain entry should have been marked chained");
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_EnvironmentEntry_SurfacesUnavailableForFallthrough()
        {
            // EnvironmentCredential (like WorkloadIdentityCredential) does not consume
            // IsChainedCredential — it surfaces an unconfigured environment as
            // CredentialUnavailableException, which is what lets ChainedTokenCredential
            // fall through. DefaultAzureCredentialFactory likewise does not set the flag
            // for these credentials, so the behavior matches DefaultAzureCredential.
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_CLIENT_SECRET", null },
                { "AZURE_CLIENT_CERTIFICATE_PATH", null },
                { "AZURE_USERNAME", null },
                { "AZURE_PASSWORD", null },
                { "AZURE_FEDERATED_TOKEN_FILE", null },
            }))
            {
                var section = BuildSection(new Dictionary<string, string>
                {
                    ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                    ["MyClient:Credential:Sources:0:CredentialSource"] = "EnvironmentCredential",
                });

                var resolver = new AzureCredentialResolver();
                Assert.IsTrue(resolver.TryResolve(section, out var provider));

                TokenCredential[] sources = GetChainSources((ChainedTokenCredential)provider);
                Assert.IsInstanceOf<EnvironmentCredential>(sources[0]);

                var context = new TokenRequestContext(new[] { "https://management.azure.com/.default" });
                Assert.Throws<CredentialUnavailableException>(() => sources[0].GetToken(context, default));
            }
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_NestedChain_IsRejected()
        {
            // A ChainedTokenCredential entry nested inside another chain is rejected
            // (consistent with ChainedTokenCredentialFactory) rather than recursively
            // building a nested chain.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                ["MyClient:Credential:Sources:0:CredentialSource"] = "ChainedTokenCredential",
                ["MyClient:Credential:Sources:0:Sources:0:CredentialSource"] = "AzureCliCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.Throws<InvalidOperationException>(() => resolver.TryResolve(section, out _));
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_UnclaimedCustomSource_ReturnsFalse()
        {
            // No resolver claims the custom source and no chain callback is
            // available (single-arg overload), so the whole chain defers.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                ["MyClient:Credential:Sources:0:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Sources:1:CredentialSource"] = "MyCustomCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_CustomSource_DoesNotCollideWithStandalone()
        {
            // The same custom source resolved standalone (not chained) and inside
            // a chain (chained) must not collide in the resolver engine's cache —
            // the chained overlay must be part of the section's cache key.
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Standalone:CredentialSource"] = "MyCustomCredential",
                    ["Chain:CredentialSource"] = "ChainedTokenCredential",
                    ["Chain:Sources:0:CredentialSource"] = "MyCustomCredential",
                })
                .Build();

            var custom = new FakeCustomResolver();

            var standalone = config.GetAzureCredentialSettings("Standalone", custom).TokenProvider as FakeCustomCredential;
            Assert.IsNotNull(standalone);
            Assert.IsFalse(standalone.IsChained, "Standalone custom credential should not be chained");

            CredentialSettings chain = config.GetAzureCredentialSettings("Chain", custom);
            TokenCredential[] sources = GetChainSources((ChainedTokenCredential)chain.TokenProvider);
            var chained = sources[0] as FakeCustomCredential;
            Assert.IsNotNull(chained);
            Assert.IsTrue(chained.IsChained, "Chained custom credential should be chained despite identical CredentialSource");
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_AzureEntryFlowsThroughResolverChain()
        {
            // An Azure source inside a chain is resolved through the active resolver
            // chain, so a caller-supplied resolver ordered ahead of the built-in one
            // can claim it. The unclaimed entry falls through to the built-in resolver.
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                    ["MyClient:Credential:Sources:0:CredentialSource"] = "AzureCliCredential",
                    ["MyClient:Credential:Sources:1:CredentialSource"] = "EnvironmentCredential",
                })
                .Build();

            CredentialSettings settings = config.GetAzureCredentialSettings("MyClient:Credential", new AzureCliOverrideResolver());

            TokenCredential[] sources = GetChainSources((ChainedTokenCredential)settings.TokenProvider);
            Assert.AreEqual(2, sources.Length);

            var overridden = sources[0] as FakeCustomCredential;
            Assert.IsNotNull(overridden, "Caller-supplied resolver should have claimed the AzureCli entry");
            Assert.IsTrue(overridden.IsChained, "Claimed chain entry should be chained");
            Assert.IsInstanceOf<EnvironmentCredential>(sources[1], "Unclaimed entry should be built by the built-in resolver");
        }

        private static TokenCredential[] GetChainSources(ChainedTokenCredential chain)
        {
            FieldInfo sourcesField = typeof(ChainedTokenCredential).GetField("_sources", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(sourcesField, "ChainedTokenCredential._sources field not found via reflection");
            return (TokenCredential[])sourcesField.GetValue(chain);
        }

        private static bool GetIsChained(TokenCredential credential)
        {
            FieldInfo field = credential.GetType().GetField("_isChainedCredential", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field, $"{credential.GetType().Name}._isChainedCredential field not found via reflection");
            return (bool)field.GetValue(credential);
        }

        private sealed class FakeCustomResolver : CredentialResolver
        {
            public override bool TryResolve(IConfigurationSection credentialSection, out AuthenticationTokenProvider provider)
            {
                var settings = new CredentialSettings(credentialSection);
                if (string.Equals(settings.CredentialSource, "MyCustomCredential", StringComparison.OrdinalIgnoreCase))
                {
                    bool chained = bool.TryParse(credentialSection["IsChainedCredential"], out bool c) && c;
                    provider = new FakeCustomCredential(chained);
                    return true;
                }

                provider = null;
                return false;
            }
        }

        private sealed class AzureCliOverrideResolver : CredentialResolver
        {
            public override bool TryResolve(IConfigurationSection credentialSection, out AuthenticationTokenProvider provider)
            {
                var settings = new CredentialSettings(credentialSection);
                if (string.Equals(settings.CredentialSource, "AzureCliCredential", StringComparison.OrdinalIgnoreCase))
                {
                    bool chained = bool.TryParse(credentialSection["IsChainedCredential"], out bool c) && c;
                    provider = new FakeCustomCredential(chained);
                    return true;
                }

                provider = null;
                return false;
            }
        }

        private sealed class FakeCustomCredential : TokenCredential
        {
            public FakeCustomCredential(bool isChained) => IsChained = isChained;

            public bool IsChained { get; }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => default;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => default;
        }

        [TestCase("AzureCliCredential", typeof(AzureCliCredential))]
        [TestCase("AzurePowerShellCredential", typeof(AzurePowerShellCredential))]
        [TestCase("AzureDeveloperCliCredential", typeof(AzureDeveloperCliCredential))]
        [TestCase("VisualStudioCredential", typeof(VisualStudioCredential))]
        [TestCase("VisualStudioCodeCredential", typeof(VisualStudioCodeCredential))]
        [TestCase("visualstudiocode", typeof(VisualStudioCodeCredential))]
        [TestCase("EnvironmentCredential", typeof(EnvironmentCredential))]
        [TestCase("WorkloadIdentityCredential", typeof(WorkloadIdentityCredential))]
        [TestCase("ManagedIdentityCredential", typeof(ManagedIdentityCredential))]
        [TestCase("InteractiveBrowserCredential", typeof(InteractiveBrowserCredential))]
        public void TryResolve_KnownSingleSource_ProducesConcreteCredential(string source, Type expectedType)
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = source,
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider), $"Resolver should claim {source}");
            Assert.IsInstanceOf(expectedType, provider);
            Assert.IsNotInstanceOf<DefaultAzureCredential>(provider);
        }

        [Test]
        public void TryResolve_KnownSingleSource_IsNotChained()
        {
            // A top-level single source is not part of a chain, so it must surface
            // failures as AuthenticationFailedException (IsChainedCredential=false).
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));
            Assert.IsFalse(GetIsChained((TokenCredential)provider), "Top-level single source should not be chained");
        }

        [TestCase("BrokerCredential")]
        [TestCase("broker")]
        public void TryResolve_BrokerSource_DefersToBrokerResolver(string source)
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = source,
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider), $"Resolver should defer {source}");
            Assert.IsNull(provider);
        }

        [Test]
        public void Default_ReturnsSameSingleton()
        {
            Assert.AreSame(AzureCredentialResolver.Default, AzureCredentialResolver.Default);
        }
    }
}
