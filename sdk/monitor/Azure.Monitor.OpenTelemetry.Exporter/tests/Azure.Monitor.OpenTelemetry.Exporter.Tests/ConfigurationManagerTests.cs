// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
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

        [Fact]
        public async Task ConcurrentRegistrationsAndDisposalsDoNotLoseUpdates()
        {
            const int RegistrationCount = 32;
            int callbackInvocations = 0;
            var registrationTasks = new Task<IDisposable>[RegistrationCount];

            for (int i = 0; i < registrationTasks.Length; i++)
            {
                registrationTasks[i] = Task.Run(() =>
                    ConfigurationManager.Instance.RegisterCallback(
                        _ =>
                        {
                            Interlocked.Increment(ref callbackInvocations);
                            return Task.CompletedTask;
                        }));
            }

            IDisposable[] registrations = await Task.WhenAll(registrationTasks);
            await ConfigurationManager.Instance.NotifyCallbacksAsync(new Dictionary<string, string>());

            Assert.Equal(RegistrationCount, callbackInvocations);

            var disposalTasks = new Task[RegistrationCount];
            for (int i = 0; i < disposalTasks.Length; i++)
            {
                IDisposable registration = registrations[i];
                disposalTasks[i] = Task.Run(registration.Dispose);
            }

            await Task.WhenAll(disposalTasks);
            await ConfigurationManager.Instance.NotifyCallbacksAsync(new Dictionary<string, string>());

            Assert.Equal(RegistrationCount, callbackInvocations);
        }
    }
}
