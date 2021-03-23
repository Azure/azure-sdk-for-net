// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets.Tests
{
    public class AzureKeyVaultConfigurationTests
    {
        private static readonly TimeSpan NoReloadDelay = TimeSpan.FromMilliseconds(1);

        private void SetPages(Mock<SecretClient> mock, params KeyVaultSecret[][] pages)
        {
            SetPages(mock, null, pages);
        }

        private void SetPages(Mock<SecretClient> mock, Func<string, Task> getSecretCallback, params KeyVaultSecret[][] pages)
        {
            getSecretCallback ??= (_ => Task.CompletedTask);

            var pagesOfProperties = pages.Select(
                page => page.Select(secret => secret.Properties).ToArray()).ToArray();

            mock.Setup(m => m.GetPropertiesOfSecretsAsync(default)).Returns(new MockAsyncPageable(pagesOfProperties));

            foreach (var page in pages)
            {
                foreach (var secret in page)
                {
                    mock.Setup(client => client.GetSecretAsync(secret.Name, null, default))
                        .Returns(async (string name, string label, CancellationToken token) =>
                        {
                            await getSecretCallback(name);
                            return Response.FromValue(secret, Mock.Of<Response>());
                        }
                    );
                }
            }
        }

        private class MockAsyncPageable : AsyncPageable<SecretProperties>
        {
            private readonly SecretProperties[][] _pages;

            public MockAsyncPageable(SecretProperties[][] pages)
            {
                _pages = pages;
            }

            public override async IAsyncEnumerable<Page<SecretProperties>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (var page in _pages)
                {
                    yield return Page<SecretProperties>.FromValues(page, null, Mock.Of<Response>());
                }

                await Task.CompletedTask;
            }
        }

        [Test]
        public void LoadsAllSecretsFromVault()
        {
            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1")
                },
                new[]
                {
                    CreateSecret("Secret2", "Value2")
                }
                );

            // Act
            using (var provider = new AzureKeyVaultConfigurationProvider(client.Object,  new KeyVaultSecretManager()))
            {
                provider.Load();

                var childKeys = provider.GetChildKeys(Enumerable.Empty<string>(), null).ToArray();
                Assert.AreEqual(new[] { "Secret1", "Secret2" }, childKeys);
                Assert.AreEqual("Value1", provider.Get("Secret1"));
                Assert.AreEqual("Value2", provider.Get("Secret2"));
            }
        }

        private KeyVaultSecret CreateSecret(string name, string value, bool? enabled = true, DateTimeOffset? updated = null)
        {
            var id = new Uri("http://azure.keyvault/" + name);

            var secretProperties = SecretModelFactory.SecretProperties(id, name: name, updatedOn: updated);
            secretProperties.Enabled = enabled;

            return SecretModelFactory.KeyVaultSecret(secretProperties, value);
        }

        [Test]
        public void DoesNotLoadFilteredItems()
        {
            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1")
                },
                new[]
                {
                    CreateSecret("Secret2", "Value2")
                }
            );

            // Act
            using (var provider = new AzureKeyVaultConfigurationProvider(client.Object, new EndsWithOneKeyVaultSecretManager()))
            {
                provider.Load();

                // Assert
                var childKeys = provider.GetChildKeys(Enumerable.Empty<string>(), null).ToArray();
                Assert.AreEqual(new[] { "Secret1" }, childKeys);
                Assert.AreEqual("Value1", provider.Get("Secret1"));
            }
        }

        [Test]
        public void DoesNotLoadDisabledItems()
        {
            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1")
                },
                new[]
                {
                    CreateSecret("Secret2", "Value2", enabled: false),
                    CreateSecret("Secret3", "Value3", enabled: null),
                }
            );

            // Act
            using (var provider = new AzureKeyVaultConfigurationProvider(client.Object, new KeyVaultSecretManager()))
            {
                provider.Load();

                // Assert
                var childKeys = provider.GetChildKeys(Enumerable.Empty<string>(), null).ToArray();
                Assert.AreEqual(new[] { "Secret1" }, childKeys);
                Assert.AreEqual("Value1", provider.Get("Secret1"));
                Assert.Throws<InvalidOperationException>(() => provider.Get("Secret2"));
                Assert.Throws<InvalidOperationException>(() => provider.Get("Secret3"));
            }
        }

        [Test]
        public void SupportsReload()
        {
            var updated = DateTime.Now;

            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1", enabled: true, updated: updated)
                }
            );

            // Act & Assert
            using (var provider = new AzureKeyVaultConfigurationProvider(client.Object, new KeyVaultSecretManager()))
            {
                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Secret1"));

                SetPages(client,
                    new[]
                    {
                        CreateSecret("Secret1", "Value2", enabled: true, updated: updated.AddSeconds(1))
                    }
                );

                provider.Load();
                Assert.AreEqual("Value2", provider.Get("Secret1"));
            }
        }

        [Test]
        public async Task SupportsAutoReload()
        {
            var updated = DateTime.Now;
            int numOfTokensFired = 0;

            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1", enabled: true, updated: updated)
                }
            );

            // Act & Assert
            using (var provider = new ReloadControlKeyVaultProvider(client.Object, new KeyVaultSecretManager(), reloadPollDelay: NoReloadDelay))
            {
                ChangeToken.OnChange(
                    () => provider.GetReloadToken(),
                    () => {
                        numOfTokensFired++;
                    });

                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Secret1"));

                await provider.Wait();

                SetPages(client,
                        new[]
                    {
                        CreateSecret("Secret1", "Value2", enabled: true, updated: updated.AddSeconds(1))
                    }
                );

                provider.Release();

                await provider.Wait();

                Assert.AreEqual("Value2", provider.Get("Secret1"));
                Assert.AreEqual(1, numOfTokensFired);
            }
        }

        [Test]
        public async Task DoesntReloadUnchanged()
        {
            var updated = DateTime.Now;
            int numOfTokensFired = 0;

            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1", enabled: true, updated: updated)
                }
            );

            // Act & Assert
            using (var provider = new ReloadControlKeyVaultProvider(client.Object, new KeyVaultSecretManager(), reloadPollDelay: NoReloadDelay))
            {
                ChangeToken.OnChange(
                    () => provider.GetReloadToken(),
                    () => {
                        numOfTokensFired++;
                    });

                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Secret1"));

                await provider.Wait();

                provider.Release();

                await provider.Wait();

                Assert.AreEqual("Value1", provider.Get("Secret1"));
                Assert.AreEqual(0, numOfTokensFired);
            }
        }

        [Test]
        public async Task SupportsReloadOnRemove()
        {
            int numOfTokensFired = 0;

            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1"),
                    CreateSecret("Secret2", "Value2")
                }
            );

            // Act & Assert
            using (var provider = new ReloadControlKeyVaultProvider(client.Object, new KeyVaultSecretManager(), reloadPollDelay: NoReloadDelay))
            {
                ChangeToken.OnChange(
                    () => provider.GetReloadToken(),
                    () => {
                        numOfTokensFired++;
                    });

                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Secret1"));

                await provider.Wait();

                SetPages(client,
                    new[]
                    {
                        CreateSecret("Secret1", "Value2")
                    }
                );

                provider.Release();

                await provider.Wait();

                Assert.Throws<InvalidOperationException>(() => provider.Get("Secret2"));
                Assert.AreEqual(1, numOfTokensFired);
            }
        }

        [Test]
        public async Task SupportsReloadOnEnabledChange()
        {
            int numOfTokensFired = 0;

            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1"),
                    CreateSecret("Secret2", "Value2")
                }
            );

            // Act & Assert
            using (var provider = new ReloadControlKeyVaultProvider(client.Object, new KeyVaultSecretManager(), reloadPollDelay: NoReloadDelay))
            {
                ChangeToken.OnChange(
                    () => provider.GetReloadToken(),
                    () => {
                        numOfTokensFired++;
                    });

                provider.Load();

                Assert.AreEqual("Value2", provider.Get("Secret2"));

                await provider.Wait();

                SetPages(client,
        new[]
                    {
                        CreateSecret("Secret1", "Value2"),
                        CreateSecret("Secret2", "Value2", enabled: false)
                    }
                );

                provider.Release();

                await provider.Wait();

                Assert.Throws<InvalidOperationException>(() => provider.Get("Secret2"));
                Assert.AreEqual(1, numOfTokensFired);
            }
        }

        [Test]
        public async Task SupportsReloadOnAdd()
        {
            int numOfTokensFired = 0;

            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Secret1", "Value1")
                }
            );

            // Act & Assert
            using (var provider = new ReloadControlKeyVaultProvider(client.Object, new KeyVaultSecretManager(), reloadPollDelay: NoReloadDelay))
            {
                ChangeToken.OnChange(
                    () => provider.GetReloadToken(),
                    () => {
                        numOfTokensFired++;
                    });

                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Secret1"));

                await provider.Wait();

                SetPages(client,
                    new[]
                    {
                        CreateSecret("Secret1", "Value1"),
                    },
                    new[]
                    {
                        CreateSecret("Secret2", "Value2")
                    }
                );

                provider.Release();

                await provider.Wait();

                Assert.AreEqual("Value1", provider.Get("Secret1"));
                Assert.AreEqual("Value2", provider.Get("Secret2"));
                Assert.AreEqual(1, numOfTokensFired);
            }
        }

        [Test]
        public void ReplaceDoubleMinusInKeyName()
        {
            var client = new Mock<SecretClient>();
            SetPages(client,
                new[]
                {
                    CreateSecret("Section--Secret1", "Value1")
                }
            );

            // Act
            using (var provider = new AzureKeyVaultConfigurationProvider(client.Object, new KeyVaultSecretManager()))
            {
                provider.Load();

                // Assert
                Assert.AreEqual("Value1", provider.Get("Section:Secret1"));
            }
        }

        [Test]
        public async Task LoadsSecretsInParallel()
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            var expectedCount = 2;
            var client = new Mock<SecretClient>();

            SetPages(client,
                async (string id) =>
                {
                    if (Interlocked.Decrement(ref expectedCount) == 0)
                    {
                        tcs.SetResult(null);
                    }

                    await tcs.Task.TimeoutAfter(TimeSpan.FromSeconds(10));
                },
                new[]
                {
                    CreateSecret("Secret1", "Value1"),
                    CreateSecret("Secret2", "Value2")
                }
            );

            // Act
            var provider = new AzureKeyVaultConfigurationProvider(client.Object, new KeyVaultSecretManager());
            provider.Load();
            await tcs.Task;

            // Assert
            Assert.AreEqual("Value1", provider.Get("Secret1"));
            Assert.AreEqual("Value2", provider.Get("Secret2"));
        }

        [Test]
        public void LimitsMaxParallelism()
        {
            var expectedCount = 100;
            var currentParallel = 0;
            var maxParallel = 0;
            var client = new Mock<SecretClient>();

            // Create 10 pages of 10 secrets
            var pages = Enumerable.Range(0, 10).Select(a =>
                Enumerable.Range(0, 10).Select(b => CreateSecret("Secret" + (a * 10 + b), (a * 10 + b).ToString())).ToArray()
            ).ToArray();

            SetPages(client,
                async (string id) =>
                {
                    var i = Interlocked.Increment(ref currentParallel);

                    maxParallel = Math.Max(i, maxParallel);

                    await Task.Delay(30);
                    Interlocked.Decrement(ref currentParallel);
                },
                pages
            );

            // Act
            var provider = new AzureKeyVaultConfigurationProvider(client.Object, new KeyVaultSecretManager());
            provider.Load();

            // Assert
            for (int i = 0; i < expectedCount; i++)
            {
                Assert.AreEqual(i.ToString(), provider.Get("Secret"+i));
            }

            Assert.LessOrEqual(maxParallel, 32);
        }

        [Test]
        public void ConstructorThrowsForNullManager()
        {
            Assert.Throws<ArgumentNullException>(() => new AzureKeyVaultConfigurationProvider(Mock.Of<SecretClient>(), null));
        }

        [Test]
        public void ConstructorThrowsForZeroRefreshPeriodValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new AzureKeyVaultConfigurationProvider(Mock.Of<SecretClient>(), new KeyVaultSecretManager(), TimeSpan.Zero));
        }

        [Test]
        public void ConstructorThrowsForNegativeRefreshPeriodValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new AzureKeyVaultConfigurationProvider(Mock.Of<SecretClient>(), new KeyVaultSecretManager(), TimeSpan.FromMilliseconds(-1)));
        }

        private class EndsWithOneKeyVaultSecretManager : KeyVaultSecretManager
        {
            public override bool Load(SecretProperties secret)
            {
                return secret.Name.EndsWith("1");
            }
        }

        private class ReloadControlKeyVaultProvider : AzureKeyVaultConfigurationProvider
        {
            private TaskCompletionSource<object> _releaseTaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            private TaskCompletionSource<object> _signalTaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            public ReloadControlKeyVaultProvider(SecretClient client, KeyVaultSecretManager manager, TimeSpan? reloadPollDelay = null) : base(client, manager, reloadPollDelay)
            {
            }

            protected override async Task WaitForReload()
            {
                _signalTaskCompletionSource.SetResult(null);
                await _releaseTaskCompletionSource.Task.TimeoutAfter(TimeSpan.FromSeconds(10));
            }

            public async Task Wait()
            {
                await _signalTaskCompletionSource.Task.TimeoutAfter(TimeSpan.FromSeconds(10));
            }

            public void Release()
            {
                if (!_signalTaskCompletionSource.Task.IsCompleted)
                {
                    throw new InvalidOperationException("Provider is not waiting for reload");
                }

                var releaseTaskCompletionSource = _releaseTaskCompletionSource;
                _releaseTaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
                _signalTaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
                releaseTaskCompletionSource.SetResult(null);
            }
        }
    }
}
