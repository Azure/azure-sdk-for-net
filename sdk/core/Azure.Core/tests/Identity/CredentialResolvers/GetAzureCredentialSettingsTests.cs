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
    public class GetAzureCredentialSettingsTests
    {
        private static IConfiguration BuildConfig(IDictionary<string, string> values)
            => new ConfigurationBuilder().AddInMemoryCollection(values).Build();

        [Test]
        public void GetAzureCredentialSettings_NoResolvers_UsesBuiltInResolver()
        {
            // Even with no caller-supplied resolvers, the built-in AzureCredentialResolver
            // is appended to the chain so a known token-source section resolves successfully.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            CredentialSettings cred = config.GetAzureCredentialSettings("MyClient:Credential");
            Assert.IsNotNull(cred);
            Assert.IsInstanceOf<DefaultAzureCredential>(cred.TokenProvider);
        }

        [Test]
        public void GetAzureCredentialSettings_ApiKeySection_ReturnsKeyWithNoProvider()
        {
            // ApiKey sections are intentionally not claimed by AzureCredentialResolver — the
            // returned settings expose the inline Key (so consuming libraries can dispatch on
            // CredentialSource and read Key directly) while TokenProvider stays null.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["MyClient:Credential:Key"] = "abc",
            });

            CredentialSettings cred = config.GetAzureCredentialSettings("MyClient:Credential");

            Assert.IsNotNull(cred);
            Assert.IsNull(cred.TokenProvider);
            Assert.AreEqual("apikeycredential", cred.CredentialSource);
            Assert.AreEqual("abc", cred.Key);
        }

        [Test]
        public void GetAzureCredentialSettings_MissingSection_ReturnsNullWithoutThrowing()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>());

            Assert.IsNull(config.GetAzureCredentialSettings("Nope"));
            Assert.IsNull(config.GetAzureCredentialSettings("Nope", Array.Empty<CredentialResolver>()));
            Assert.IsNull(config.GetAzureCredentialSettings("Nope", Array.Empty<CredentialResolver>(), _ => { }));
        }

        [Test]
        public void GetAzureCredentialSettings_CustomResolverWins_OverBuiltIn()
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

            CredentialSettings cred = config.GetAzureCredentialSettings("MyClient:Credential", custom);
            Assert.IsNotNull(cred);
            Assert.AreSame(fake, cred.TokenProvider);
        }

        [Test]
        public void GetAzureCredentialSettings_BuiltInWins_WhenCustomResolverDefers()
        {
            // Custom resolver returns false, so the built-in handles the section.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            DeferringResolver custom = new DeferringResolver();

            CredentialSettings cred = config.GetAzureCredentialSettings("MyClient:Credential", custom);
            Assert.IsNotNull(cred);
            Assert.IsInstanceOf<DefaultAzureCredential>(cred.TokenProvider);
        }

        [Test]
        public void GetAzureCredentialSettings_WithOverrides_AppliesBeforeResolution()
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

            CredentialSettings cred = config.GetAzureCredentialSettings(
                "MyClient:Credential",
                new CredentialResolver[] { echo },
                section => section["Marker"] = "overridden");

            Assert.IsNotNull(cred);
            Assert.IsInstanceOf<TokenCredential>(cred.TokenProvider);
            TokenCredential token = (TokenCredential)cred.TokenProvider;
            Assert.AreEqual("overridden", token.GetToken(new TokenRequestContext(new[] { "x" }), default).Token);
        }

        [Test]
        public void GetAzureCredentialSettings_DispatchPattern_TokenAndApiKey()
        {
            // Demonstrates the mixed-mode dispatch pattern: a single call site can hand off
            // either a TokenCredential or an inline ApiKey without binding a ClientSettings.
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["TokenClient:Credential:CredentialSource"] = "AzureCliCredential",
                ["KeyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["KeyClient:Credential:Key"] = "secret",
            });

            CredentialSettings tokenSettings = config.GetAzureCredentialSettings("TokenClient:Credential");
            Assert.IsNotNull(tokenSettings);
            Assert.IsInstanceOf<TokenCredential>(tokenSettings.TokenProvider);

            CredentialSettings keySettings = config.GetAzureCredentialSettings("KeyClient:Credential");
            Assert.IsNotNull(keySettings);
            Assert.IsNull(keySettings.TokenProvider);
            Assert.AreEqual("secret", keySettings.Key);
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
