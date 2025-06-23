// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using Azure.Developer.Playwright.Utility;
using Moq;

namespace Azure.Developer.Playwright.Tests
{
    [TestFixture]
    public class PlaywrightServiceBrowserClientOptionsTests
    {
        [Test]
        public void Constructor_WithDefaultParameters_InitializesCorrectly()
        {
            var options = new PlaywrightServiceBrowserClientOptions();

            Assert.Multiple(() =>
            {
                Assert.That(options.OS, Is.EqualTo(OSPlatform.Linux));
                Assert.That(options.UseCloudHostedBrowsers, Is.True);
                Assert.That(options.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
                Assert.That(options.VersionString, Is.EqualTo("2025-07-01-preview"));
            });
        }

        [Test]
        public void OS_WhenEnvironmentVariableIsSet_ReturnsEnvironmentValue()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable, "windows");
            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.OS, Is.EqualTo(OSPlatform.Windows));
        }

        [Test]
        public void OS_WhenSetToInvalidValue_ThrowsArgumentException()
        {
            var options = new PlaywrightServiceBrowserClientOptions();

            var ex = Assert.Throws<ArgumentException>(() => options.OS = OSPlatform.OSX);
            Assert.That(ex!.Message, Does.Contain("Invalid value for OS"));
        }

        [Test]
        public void RunId_WhenEnvironmentVariableIsSet_ReturnsEnvironmentValue()
        {
            var environment = new TestEnvironment();
            var expectedRunId = "test-run-id";
            environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, expectedRunId);

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.RunId, Is.EqualTo(expectedRunId));
        }

        [Test]
        public void RunId_WhenSetAndEnvironmentNotSet_SetsEnvironmentVariable()
        {
            var environment = new TestEnvironment();
            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            var expectedRunId = "new-run-id";
            options.RunId = expectedRunId;

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable),
                Is.EqualTo(expectedRunId));
        }

        [Test]
        public void ServiceAuth_WhenSetToInvalidValue_ThrowsArgumentException()
        {
            var options = new PlaywrightServiceBrowserClientOptions();

            var ex = Assert.Throws<ArgumentException>(() =>
                options.ServiceAuth = new ServiceAuthType("InvalidAuth"));
            Assert.That(ex!.Message, Does.Contain("Invalid value for ServiceAuth"));
        }

        [Test]
        public void UseCloudHostedBrowsers_WhenEnvironmentVariableIsInvalid_ThrowsArgumentException()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(
                Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable,
                "not-a-boolean");

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var _ = options.UseCloudHostedBrowsers;
            });
            Assert.That(ex!.Message, Does.Contain("Invalid value for UseCloudHostedBrowsers"));
        }

        [Test]
        public void ServiceEndpoint_WhenSetAndGet_WorksCorrectly()
        {
            var environment = new TestEnvironment();
            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            var expectedEndpoint = "https://playwright.test.endpoint";
            options.ServiceEndpoint = expectedEndpoint;

            Assert.That(options.ServiceEndpoint, Is.EqualTo(expectedEndpoint));
        }

        [Test]
        public void ExposeNetwork_WhenNotSet_ReturnsDefaultValue()
        {
            var environment = new TestEnvironment();
            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
        }

        [Test]
        public void Constructor_WithInvalidServiceVersion_ThrowsArgumentOutOfRangeException()
        {
            var environment = new TestEnvironment();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new PlaywrightServiceBrowserClientOptions(
                    environment: environment,
                    serviceVersion: (PlaywrightServiceBrowserClientOptions.ServiceVersion)999));
        }

        [Test]
        public void AuthToken_ReturnsEnvironmentVariable()
        {
            var environment = new TestEnvironment();
            var expectedToken = "test-token";
            environment.SetEnvironmentVariable(
                ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(),
                expectedToken);

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.AuthToken, Is.EqualTo(expectedToken));
        }

        [Test]
        public void ExposeNetwork_WhenEnvironmentVariableIsSet_ReturnsEnvironmentValue()
        {
            var environment = new TestEnvironment();
            var expectedNetwork = "custom-network";
            environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable, expectedNetwork);

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.ExposeNetwork, Is.EqualTo(expectedNetwork));
        }

        [Test]
        public void ExposeNetwork_WhenSetAndEnvironmentIsSet_DoesNotUpdateEnvironmentVariable()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable, "initial-network");

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            var expectedNetwork = "updated-network";
            options.ExposeNetwork = expectedNetwork;

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable),
                Is.EqualTo("initial-network"));
        }

        [Test]
        public void ServiceAuth_WhenEnvironmentVariableIsSet_ReturnsEnvironmentValue()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, ServiceAuthType.AccessToken.ToString());

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.ServiceAuth, Is.EqualTo(ServiceAuthType.AccessToken));
        }

        [Test]
        public void ServiceAuth_WhenSetAndEnvironmentIsSet_DoesNotUpdateEnvironmentVariable()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, ServiceAuthType.EntraId.ToString());

            _ = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
            {
                ServiceAuth = ServiceAuthType.AccessToken
            };

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable),
                Is.EqualTo(ServiceAuthType.EntraId.ToString()));
        }

        [Test]
        public void UseCloudHostedBrowsers_WhenSetAndEnvironmentIsSet_DoesNotUpdateEnvironmentVariable()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable, "true");

            _ = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
            {
                UseCloudHostedBrowsers = false
            };

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable),
                Is.EqualTo("true"));
        }

        [Test]
        public void UseCloudHostedBrowsers_WhenEnvironmentVariableIsSet_ReturnsEnvironmentValue()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable, "false");

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.UseCloudHostedBrowsers, Is.False);
        }

        [Test]
        public void RunId_WhenNoValueSet_ReturnsDefaultRunId()
        {
            var environment = new TestEnvironment();
            var clientUtilities = new ClientUtilities(environment);

            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                clientUtility: clientUtilities,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(Guid.TryParse(options.RunId, out _), Is.True);
        }

        [Test]
        public void OS_WhenEnvironmentVariableNotSet_ReturnsLinux()
        {
            var environment = new TestEnvironment();
            var options = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview);

            Assert.That(options.OS, Is.EqualTo(OSPlatform.Linux));
        }

        [Test]
        public void RunId_WhenSetAndEnvironmentAlreadySet_DoesNotUpdateEnvironment()
        {
            var environment = new TestEnvironment();
            var existingRunId = "existing-run-id";
            environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, existingRunId);

            _ = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
            {
                RunId = "new-run-id"
            };

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable),
                Is.EqualTo(existingRunId));
        }

        [Test]
        public void ExposeNetwork_WhenSetAndEnvironmentNotSet_UpdatesEnvironment()
        {
            var environment = new TestEnvironment();

            _ = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
            {
                ExposeNetwork = "test-network"
            };

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable),
                Is.EqualTo("test-network"));
        }

        [Test]
        public void ServiceAuth_WhenSetAndEnvironmentNotSet_UpdatesEnvironment()
        {
            var environment = new TestEnvironment();

            _ = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
            {
                ServiceAuth = ServiceAuthType.AccessToken
            };

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable),
                Is.EqualTo(ServiceAuthType.AccessToken.ToString()));
        }

        [Test]
        public void UseCloudHostedBrowsers_WhenSetAndEnvironmentNotSet_UpdatesEnvironment()
        {
            var environment = new TestEnvironment();

            _ = new PlaywrightServiceBrowserClientOptions(
                environment: environment,
                serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
            {
                UseCloudHostedBrowsers = false
            };

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable),
                Is.EqualTo(false.ToString()));
        }
    }
}
