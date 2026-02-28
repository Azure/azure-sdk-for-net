// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.AppConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;

namespace Microsoft.Extensions.Configuration.AppConfiguration.Tests
{
    public class AppConfigurationTests
    {
        private static readonly TimeSpan NoReloadDelay = TimeSpan.FromMilliseconds(1);

        private void SetPages(Mock<ConfigurationClient> mock, params ConfigurationSetting[][] pages)
        {
            SetPages(mock, null, pages);
        }

        private void SetPages(Mock<ConfigurationClient> mock, Func<Task> getSettingsCallback, params ConfigurationSetting[][] pages)
        {
            getSettingsCallback ??= (() => Task.CompletedTask);

            mock.Setup(m => m.GetConfigurationSettings(It.IsAny<SettingSelector>(), default)).Returns(
                (SettingSelector selector, CancellationToken ct) =>
                {
                    getSettingsCallback().GetAwaiter().GetResult();
                    return new MockPageable(pages);
                });

            mock.Setup(m => m.GetConfigurationSettingsAsync(It.IsAny<SettingSelector>(), default)).Returns(
                (SettingSelector selector, CancellationToken ct) =>
                {
                    getSettingsCallback().GetAwaiter().GetResult();
                    return new MockAsyncPageable(pages);
                });
        }

        private class MockPageable : Pageable<ConfigurationSetting>
        {
            private readonly ConfigurationSetting[][] _pages;

            public MockPageable(ConfigurationSetting[][] pages)
            {
                _pages = pages;
            }

            public override IEnumerable<Page<ConfigurationSetting>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (var page in _pages)
                {
                    yield return Page<ConfigurationSetting>.FromValues(page, null, Mock.Of<Response>());
                }
            }
        }

        private class MockAsyncPageable : AsyncPageable<ConfigurationSetting>
        {
            private readonly ConfigurationSetting[][] _pages;

            public MockAsyncPageable(ConfigurationSetting[][] pages)
            {
                _pages = pages;
            }

            public override async IAsyncEnumerable<Page<ConfigurationSetting>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (var page in _pages)
                {
                    yield return Page<ConfigurationSetting>.FromValues(page, null, Mock.Of<Response>());
                }

                await Task.CompletedTask;
            }
        }

        [Test]
        public void LoadsAllSettingsFromStore()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1")
                },
                new[]
                {
                    CreateSetting("Setting2", "Value2")
                }
                );

            // Act
            using (var provider = new AppConfigurationProvider(client.Object, new AppConfigurationOptions() { Manager = new AppConfigurationSettingManager() }))
            {
                provider.Load();

                var childKeys = provider.GetChildKeys(Enumerable.Empty<string>(), null).ToArray();
                Assert.AreEqual(new[] { "Setting1", "Setting2" }, childKeys);
                Assert.AreEqual("Value1", provider.Get("Setting1"));
                Assert.AreEqual("Value2", provider.Get("Setting2"));
            }
        }

        private ConfigurationSetting CreateSetting(string key, string value, string label = null)
        {
            return ConfigurationModelFactory.ConfigurationSetting(key, value, label);
        }

        [Test]
        public void DoesNotLoadFilteredItems()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1"),
                    CreateSetting("Setting2", "Value2"),
                });

            // Act
            using (var provider = new AppConfigurationProvider(client.Object, new AppConfigurationOptions()
            {
                Manager = new EndsWithOneSettingManager()
            }))
            {
                provider.Load();

                // Assert
                var childKeys = provider.GetChildKeys(Enumerable.Empty<string>(), null).ToArray();
                Assert.AreEqual(new[] { "Setting1" }, childKeys);
                Assert.AreEqual("Value1", provider.Get("Setting1"));
            }
        }

        [Test]
        public void SupportsReload()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1"),
                });

            // Act & Assert
            using (var provider = new ReloadControlAppConfigurationProvider(client.Object, new AppConfigurationSettingManager(), NoReloadDelay))
            {
                provider.Load();
                Assert.AreEqual("Value1", provider.Get("Setting1"));

                SetPages(client,
                    new[]
                    {
                        CreateSetting("Setting1", "Value2"),
                    });

                provider.Release();
                provider.Wait().GetAwaiter().GetResult();

                Assert.AreEqual("Value2", provider.Get("Setting1"));
            }
        }

        [Test]
        public void SupportsReloadOnAdd()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1"),
                });

            // Act & Assert
            using (var provider = new ReloadControlAppConfigurationProvider(client.Object, new AppConfigurationSettingManager(), NoReloadDelay))
            {
                provider.Load();
                Assert.AreEqual("Value1", provider.Get("Setting1"));

                SetPages(client,
                    new[]
                    {
                        CreateSetting("Setting1", "Value1"),
                        CreateSetting("Setting2", "Value2"),
                    });

                provider.Release();
                provider.Wait().GetAwaiter().GetResult();

                Assert.AreEqual("Value1", provider.Get("Setting1"));
                Assert.AreEqual("Value2", provider.Get("Setting2"));
            }
        }

        [Test]
        public void SupportsReloadOnRemoval()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1"),
                    CreateSetting("Setting2", "Value2"),
                });

            // Act & Assert
            using (var provider = new ReloadControlAppConfigurationProvider(client.Object, new AppConfigurationSettingManager(), NoReloadDelay))
            {
                provider.Load();
                Assert.AreEqual("Value1", provider.Get("Setting1"));
                Assert.AreEqual("Value2", provider.Get("Setting2"));

                SetPages(client,
                    new[]
                    {
                        CreateSetting("Setting1", "Value1"),
                    });

                provider.Release();
                provider.Wait().GetAwaiter().GetResult();

                Assert.AreEqual("Value1", provider.Get("Setting1"));
                Assert.IsFalse(provider.TryGet("Setting2", out _));
            }
        }

        [Test]
        public void ReloadIgnoresExceptions()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1"),
                });

            // Act & Assert
            using (var provider = new ReloadControlAppConfigurationProvider(client.Object, new AppConfigurationSettingManager(), NoReloadDelay))
            {
                provider.Load();
                Assert.AreEqual("Value1", provider.Get("Setting1"));

                client.Setup(m => m.GetConfigurationSettingsAsync(It.IsAny<SettingSelector>(), default))
                    .Throws(new RequestFailedException("Service unavailable"));

                provider.Release();
                provider.Wait().GetAwaiter().GetResult();

                // Still has old values
                Assert.AreEqual("Value1", provider.Get("Setting1"));
            }
        }

        [Test]
        public void SupportsColonInKeyName()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Section:Setting1", "Value1"),
                });

            // Act
            using (var provider = new AppConfigurationProvider(client.Object, new AppConfigurationOptions() { Manager = new AppConfigurationSettingManager() }))
            {
                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Section:Setting1"));
            }
        }

        [Test]
        public void SupportsCustomKeyMapping()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Section/Setting1", "Value1"),
                    CreateSetting("Section/Sub/Setting2", "Value2"),
                });

            // Act
            using (var provider = new AppConfigurationProvider(client.Object, new AppConfigurationOptions()
            {
                Manager = new SlashToColonSettingManager()
            }))
            {
                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Section:Setting1"));
                Assert.AreEqual("Value2", provider.Get("Section:Sub:Setting2"));
            }
        }

        [Test]
        public void SupportsCustomGetData()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "{\"Key1\":\"Value1\",\"Key2\":\"Value2\"}"),
                });

            // Act
            using (var provider = new AppConfigurationProvider(client.Object, new AppConfigurationOptions()
            {
                Manager = new JsonSettingManager()
            }))
            {
                provider.Load();

                Assert.AreEqual("Value1", provider.Get("Key1"));
                Assert.AreEqual("Value2", provider.Get("Key2"));
            }
        }

        [Test]
        public void NotifiesChangeOnReload()
        {
            var client = new Mock<ConfigurationClient>();
            SetPages(client,
                new[]
                {
                    CreateSetting("Setting1", "Value1"),
                });

            // Act & Assert
            using (var provider = new ReloadControlAppConfigurationProvider(client.Object, new AppConfigurationSettingManager(), NoReloadDelay))
            {
                provider.Load();

                bool called = false;
                ChangeToken.OnChange(() => provider.GetReloadToken(), () => called = true);

                SetPages(client,
                    new[]
                    {
                        CreateSetting("Setting1", "Value2"),
                    });

                provider.Release();
                provider.Wait().GetAwaiter().GetResult();

                Assert.IsTrue(called);
            }
        }

        [Test]
        public void ConstructorThrowsForNullManager()
        {
            Assert.Throws<ArgumentNullException>(() => new AppConfigurationProvider(Mock.Of<ConfigurationClient>(), new AppConfigurationOptions() { Manager = null }));
        }

        [Test]
        public void ConstructorThrowsForZeroRefreshPeriodValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new AppConfigurationProvider(Mock.Of<ConfigurationClient>(), new AppConfigurationOptions() { ReloadInterval = TimeSpan.Zero }));
        }

        [Test]
        public void ConstructorThrowsForNegativeRefreshPeriodValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new AppConfigurationProvider(Mock.Of<ConfigurationClient>(), new AppConfigurationOptions() { ReloadInterval = TimeSpan.FromMilliseconds(-1) }));
        }

        [Test]
        public void DisposeCanBeCalledMultipleTimes()
        {
            // Arrange
            var client = new Mock<ConfigurationClient>();

            using (var provider = new AppConfigurationProvider(client.Object, new AppConfigurationOptions() { Manager = new AppConfigurationSettingManager() }))
            {
                provider.Dispose();

                // Act & Assert
                Assert.DoesNotThrow(() => provider.Dispose());
            }
        }

        [Test]
        public void AddAppConfigurationsThrowsOnNullBuilder()
        {
            Assert.Throws<ArgumentNullException>(() =>
                AppConfigurationExtensions.AddAppConfigurations(null, "section"));
        }

        [Test]
        public void AddAppConfigurationsThrowsOnNullSectionName()
        {
            var builder = new ConfigurationBuilder();
            Assert.Throws<ArgumentException>(() =>
                builder.AddAppConfigurations(null));
        }

        [Test]
        public void AddAppConfigurationsThrowsOnEmptySectionName()
        {
            var builder = new ConfigurationBuilder();
            Assert.Throws<ArgumentException>(() =>
                builder.AddAppConfigurations(string.Empty));
        }

        private class EndsWithOneSettingManager : AppConfigurationSettingManager
        {
            public override bool Load(ConfigurationSetting setting)
            {
                return setting.Key.EndsWith("1");
            }
        }

        private class ReloadControlAppConfigurationProvider : AppConfigurationProvider
        {
            private TaskCompletionSource<object> _releaseTaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            private TaskCompletionSource<object> _signalTaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            public ReloadControlAppConfigurationProvider(ConfigurationClient client, AppConfigurationSettingManager manager, TimeSpan? reloadPollDelay = null)
                : base(client, new AppConfigurationOptions() { Manager = manager, ReloadInterval = reloadPollDelay })
            {
            }

            internal override async Task WaitForReload()
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

        private class SlashToColonSettingManager : AppConfigurationSettingManager
        {
            public override string GetKey(ConfigurationSetting setting)
            {
                return setting.Key.Replace("/", ConfigurationPath.KeyDelimiter);
            }
        }

        private class JsonSettingManager : AppConfigurationSettingManager
        {
            public override Dictionary<string, string> GetData(IEnumerable<ConfigurationSetting> settings)
            {
                var data = new Dictionary<string, string>();
                foreach (var setting in settings)
                {
                    using var doc = JsonDocument.Parse(setting.Value);

                    foreach (var property in doc.RootElement.EnumerateObject())
                    {
                        data[property.Name] = property.Value.GetString();
                    }
                }

                return data;
            }
        }
    }
}
