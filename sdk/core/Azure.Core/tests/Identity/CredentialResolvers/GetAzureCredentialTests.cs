// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity.CredentialResolvers
{
    public class GetAzureCredentialTests
    {
        private static IConfiguration BuildConfig(IDictionary<string, string> values)
            => new ConfigurationBuilder().AddInMemoryCollection(values).Build();

        [Test]
        public void GetAzureCredential_NoResolvers_UsesBuiltInResolver()
        {
            // Even with no caller-supplied resolvers, the built-in AzureCredentialResolver
            // is appended to the chain so a known token-source section resolves successfully.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            TokenCredential cred = config.GetAzureCredential("MyClient:Credential");
            Assert.IsNotNull(cred);
            Assert.IsInstanceOf<DefaultAzureCredential>(cred);
        }

        [Test]
        public void GetAzureCredential_ApiKeySection_ReturnsNull()
        {
            // ApiKey sections are intentionally not claimed by AzureCredentialResolver — consuming
            // libraries dispatch on Credential.CredentialSource themselves at construction time.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["MyClient:Credential:Key"] = "abc",
            });

            Assert.IsNull(config.GetAzureCredential("MyClient:Credential"));
        }

        [Test]
        public void GetAzureCredential_MissingSection_ReturnsNullWithoutThrowing()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>());

            Assert.IsNull(config.GetAzureCredential("Nope"));
            Assert.IsNull(config.GetAzureCredential("Nope", Array.Empty<CredentialResolver>()));
            Assert.IsNull(config.GetAzureCredential("Nope", Array.Empty<CredentialResolver>(), _ => { }));
        }

        [Test]
        public void GetAzureCredential_CustomResolverWins_OverBuiltIn()
        {
            // Custom resolver appears before AzureCredentialResolver in the chain, so when
            // both could claim the section the custom one wins. The section uses a token-based
            // source that the built-in WOULD claim, but the custom resolver claims first.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            FakeTokenCredential fake = new FakeTokenCredential("from-fake-resolver");
            FakeResolver custom = new FakeResolver(fake);

            TokenCredential cred = config.GetAzureCredential("MyClient:Credential", custom);
            Assert.AreSame(fake, cred);
        }

        [Test]
        public void GetAzureCredential_BuiltInWins_WhenCustomResolverDefers()
        {
            // Custom resolver returns false, so the built-in handles the section.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            DeferringResolver custom = new DeferringResolver();

            TokenCredential cred = config.GetAzureCredential("MyClient:Credential", custom);
            Assert.IsNotNull(cred);
            Assert.IsInstanceOf<DefaultAzureCredential>(cred);
        }

        [Test]
        public void GetAzureCredential_WithOverrides_AppliesBeforeResolution()
        {
            // The override callback runs against the writable overlay of the credential section
            // before any resolver sees it. Use a custom resolver that surfaces what it observed
            // so we can assert the override propagated.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "Marker",
                ["MyClient:Credential:Marker"] = "original",
            });

            MarkerEchoingResolver echo = new MarkerEchoingResolver();

            TokenCredential cred = config.GetAzureCredential(
                "MyClient:Credential",
                new CredentialResolver[] { echo },
                section => section["Marker"] = "overridden");

            Assert.IsNotNull(cred);
            Assert.AreEqual("overridden", cred.GetToken(new TokenRequestContext(new[] { "x" }), default).Token);
        }

        private sealed class FakeResolver : CredentialResolver
        {
            private readonly TokenCredential _provider;
            public FakeResolver(TokenCredential provider) => _provider = provider;

            public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider provider)
            {
                provider = _provider;
                return true;
            }
        }

        private sealed class DeferringResolver : CredentialResolver
        {
            public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider provider)
            {
                provider = null;
                return false;
            }
        }

        private sealed class MarkerEchoingResolver : CredentialResolver
        {
            // Echoes section["Marker"] back as the access-token value of a FakeTokenCredential.
            // Used to verify configureOverrides ran before resolution.
            public override bool TryResolve(IConfigurationSection credentialSection, [NotNullWhen(true)] out AuthenticationTokenProvider provider)
            {
                if (credentialSection is null || !credentialSection.Exists())
                {
                    provider = null;
                    return false;
                }

                string marker = credentialSection["Marker"];
                if (marker is null)
                {
                    provider = null;
                    return false;
                }

                provider = new FakeTokenCredential(marker);
                return true;
            }
        }

        private sealed class FakeTokenCredential : TokenCredential
        {
            private readonly AccessToken _token;
            public FakeTokenCredential(string token) => _token = new AccessToken(token, DateTimeOffset.MaxValue);

            public override AccessToken GetToken(TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) => _token;
            public override System.Threading.Tasks.ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) => new(_token);
        }
    }
}
