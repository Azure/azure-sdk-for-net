// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Configuration;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void InstanceIsProcessWide()
        {
            Assert.Same(ConfigurationManager.Instance, ConfigurationManager.Instance);
        }

        [Fact]
        public void InitializeIsIdempotent()
        {
            ConfigurationManager.Instance.Initialize();
            ConfigurationManager.Instance.Initialize();

            Assert.True(ConfigurationManager.Instance.IsInitialized);
        }

        [Fact]
        public async Task PollingStubReturnsDefaultRefreshInterval()
        {
            TimeSpan result = await ConfigurationManager.Instance.GetConfigurationAndRefreshIntervalAsync();

            Assert.Equal(OneSettingsConstants.DefaultRefreshInterval, result);
        }

        [Fact]
        public async Task CallbackFailuresAreIsolated()
        {
            var settings = new Dictionary<string, string>();
            var successfulCallbackInvoked = false;
            using IDisposable failedRegistration = ConfigurationManager.Instance.RegisterCallback(
                _ => Task.FromException(new InvalidOperationException("Test exception")));
            using IDisposable successfulRegistration = ConfigurationManager.Instance.RegisterCallback(
                _ =>
                {
                    successfulCallbackInvoked = true;
                    return Task.CompletedTask;
                });

            await ConfigurationManager.Instance.NotifyCallbacksAsync(settings);

            Assert.True(successfulCallbackInvoked);
        }

        [Fact]
        public async Task DisposedRegistrationIsNotInvoked()
        {
            var settings = new Dictionary<string, string>();
            var callbackInvoked = false;
            IDisposable registration = ConfigurationManager.Instance.RegisterCallback(
                _ =>
                {
                    callbackInvoked = true;
                    return Task.CompletedTask;
                });

            registration.Dispose();
            await ConfigurationManager.Instance.NotifyCallbacksAsync(settings);

            Assert.False(callbackInvoked);
        }
    }
}
