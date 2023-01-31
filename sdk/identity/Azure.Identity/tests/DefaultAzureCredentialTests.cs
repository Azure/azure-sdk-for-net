// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Moq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class DefaultAzureCredentialTests : ClientTestBase
    {
        public DefaultAzureCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ValidateCtorNoOptions()
        {
            var cred = new DefaultAzureCredential();

            TokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 9);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(AzureDeveloperCliCredential), sources[2]);
            Assert.IsInstanceOf(typeof(VisualStudioCredential), sources[3]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[4]);
            Assert.IsInstanceOf(typeof(AzurePowerShellCredential), sources[5]);
            Assert.IsNull(sources[8]);
        }

        [Test]
        public void ValidateCtorIncludedInteractiveParam([Values(true, false)] bool includeInteractive)
        {
            var cred = new DefaultAzureCredential(includeInteractive);

            TokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 9);

            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(AzureDeveloperCliCredential), sources[2]);
            Assert.IsInstanceOf(typeof(VisualStudioCredential), sources[3]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[4]);
            Assert.IsInstanceOf(typeof(AzurePowerShellCredential), sources[5]);

            if (includeInteractive)
            {
                Assert.IsInstanceOf(typeof(InteractiveBrowserCredential), sources[6]);
            }
            else
            {
                Assert.IsNull(sources[6]);
            }
        }

        [Test]
        public void ValidateAllUnavailable([Values(true, false)] bool excludeEnvironmentCredential,
                                           [Values(true, false)] bool excludeManagedIdentityCredential,
                                           [Values(true, false)] bool excludeDeveloperCliCredential,
                                           [Values(true, false)] bool excludeSharedTokenCacheCredential,
                                           [Values(true, false)] bool excludeVisualStudioCredential,
                                           [Values(true, false)] bool excludeVisualStudioCodeCredential,
                                           [Values(true, false)] bool excludeCliCredential,
                                           [Values(true, false)] bool excludePowerShellCredential,
                                           [Values(true, false)] bool excludeInteractiveBrowserCredential)
        {
            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeDeveloperCliCredential && excludeSharedTokenCacheCredential && excludeVisualStudioCredential && excludeVisualStudioCodeCredential && excludeCliCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Pass();
            }

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeAzureDeveloperCliCredential = excludeDeveloperCliCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                ExcludeAzureCliCredential = excludeCliCredential,
                ExcludeAzurePowerShellCredential = excludePowerShellCredential,
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential
            };

            var credFactory = new MockDefaultAzureCredentialFactory(options);

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential =>
                mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new CredentialUnavailableException($"{typeof(T).Name} Unavailable"));

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateInteractiveBrowserCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureDeveloperCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = c =>
                SetupMockForException(c);

            var cred = new DefaultAzureCredential(credFactory);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            if (!excludeEnvironmentCredential)
            {
                Assert.True(ex.Message.Contains("EnvironmentCredential Unavailable"));
            }
            if (!excludeManagedIdentityCredential)
            {
                Assert.True(ex.Message.Contains("ManagedIdentityCredential Unavailable"));
            }
            if (!excludeDeveloperCliCredential)
            {
                Assert.True(ex.Message.Contains("DeveloperCliCredential Unavailable"));
            }
            if (!excludeSharedTokenCacheCredential)
            {
                Assert.True(ex.Message.Contains("SharedTokenCacheCredential Unavailable"));
            }
            if (!excludeCliCredential)
            {
                Assert.True(ex.Message.Contains("CliCredential Unavailable"));
            }
            if (!excludePowerShellCredential)
            {
                Assert.True(ex.Message.Contains("PowerShellCredential Unavailable"));
            }
            if (!excludeInteractiveBrowserCredential)
            {
                Assert.True(ex.Message.Contains("InteractiveBrowserCredential Unavailable"));
            }
            if (!excludeVisualStudioCredential)
            {
                Assert.True(ex.Message.Contains("VisualStudioCredential Unavailable"));
            }
            if (!excludeVisualStudioCodeCredential)
            {
                Assert.True(ex.Message.Contains("VisualStudioCodeCredential Unavailable"));
            }
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public void ValidateUnhandledException(Type credentialType)
        {
            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeAzureDeveloperCliCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeVisualStudioCredential = false,
                ExcludeVisualStudioCodeCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var credFactory = new MockDefaultAzureCredentialFactory(options);

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential
            {
                Exception e;
                if (typeof(T) != credentialType)
                {
                    e = new CredentialUnavailableException($"{typeof(T).Name} Unavailable");
                }
                else
                {
                    e = new MockClientException($"{typeof(T).Name} unhandled exception");
                }
                mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(e);
            }

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureDeveloperCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = c =>
                SetupMockForException(c);

            credFactory.OnCreateInteractiveBrowserCredential = c =>
            {
                c.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new MockClientException("InteractiveBrowserCredential unhandled exception"));
            };

            var cred = new DefaultAzureCredential(credFactory);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            var unhandledException = ex.InnerException is AggregateException ae ? ae.InnerExceptions.Last() : ex.InnerException;

            Assert.AreEqual($"{credentialType.Name} unhandled exception", unhandledException.Message);
        }

        public static IEnumerable<object[]> AllCredentialTypes()
        {
            yield return new object[] { typeof(EnvironmentCredential) };
            yield return new object[] { typeof(SharedTokenCacheCredential) };
            yield return new object[] { typeof(VisualStudioCredential) };
            yield return new object[] { typeof(VisualStudioCodeCredential) };
            yield return new object[] { typeof(AzureCliCredential) };
            yield return new object[] { typeof(InteractiveBrowserCredential) };
            yield return new object[] { typeof(ManagedIdentityCredential) };
            yield return new object[] { typeof(AzureDeveloperCliCredential) };
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public async Task ValidateSelectedCredentialCaching(Type availableCredential)
        {
            var expToken = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue);
            List<Type> calledCredentials = new();

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeAzureDeveloperCliCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeVisualStudioCredential = false,
                ExcludeVisualStudioCodeCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var credFactory = GetMockDefaultAzureCredentialFactory(options, availableCredential, expToken, calledCredentials);

            var cred = InstrumentClient(new DefaultAzureCredential(credFactory));

            AccessToken actToken = await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken.Token, actToken.Token);

            // assert that the available credential was the last credential called
            Assert.AreEqual(calledCredentials[calledCredentials.Count - 1], availableCredential);

            calledCredentials.Clear();

            actToken = await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken.Token, actToken.Token);

            // assert that the available credential was the only credential called
            Assert.AreEqual(calledCredentials.Count, 1);

            Assert.AreEqual(calledCredentials[0], availableCredential);
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public async Task CredentialTypeLogged(Type availableCredential)
        {
            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Informational);

            var expToken = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue);
            List<Type> calledCredentials = new();

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeAzureDeveloperCliCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeVisualStudioCredential = false,
                ExcludeVisualStudioCodeCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var credFactory = GetMockDefaultAzureCredentialFactory(options, availableCredential, expToken, calledCredentials);

            var cred = InstrumentClient(new DefaultAzureCredential(credFactory));

            await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.That(messages, Has.Some.Match(availableCredential.Name).And.Some.Match("DefaultAzureCredential credential selected"));
        }

        internal MockDefaultAzureCredentialFactory GetMockDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, Type availableCredential, AccessToken expToken, List<Type> calledCredentials)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(options);

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential
            {
                if (IsAsync)
                    mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                        .Callback(() => calledCredentials.Add(typeof(T)))
                        .ReturnsAsync(() =>
                        {
                            return availableCredential == typeof(T) ? expToken : throw new CredentialUnavailableException("Unavailable");
                        });
                else
                    mock.Setup(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                        .Callback(() => calledCredentials.Add(typeof(T)))
                        .Returns(() =>
                        {
                            return availableCredential == typeof(T) ? expToken : throw new CredentialUnavailableException("Unavailable");
                        });
            }

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureDeveloperCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateInteractiveBrowserCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = c =>
                SetupMockForException(c);

            return credFactory;
        }
    }
}
