// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Azure.Developer.Playwright.Utility;
using Azure.Developer.Playwright.Interface;
using Microsoft.IdentityModel.JsonWebTokens;
using Moq;

namespace Azure.Developer.Playwright.Tests.Utility
{
    [TestFixture]
    internal class ClientUtilitiesTests
    {
        [Test]
        public void GetServiceCompatibleOs_WithLinux_ReturnsLinuxString()
        {
            var result = ClientUtilities.GetServiceCompatibleOs(OSPlatform.Linux);
            Assert.That(result, Is.EqualTo(OSConstants.s_lINUX));
        }

        [Test]
        public void GetServiceCompatibleOs_WithWindows_ReturnsWindowsString()
        {
            var result = ClientUtilities.GetServiceCompatibleOs(OSPlatform.Windows);
            Assert.That(result, Is.EqualTo(OSConstants.s_wINDOWS));
        }

        [Test]
        public void GetServiceCompatibleOs_WithNull_ReturnsNull()
        {
            var result = ClientUtilities.GetServiceCompatibleOs(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetServiceCompatibleOs_WithUnsupportedOs_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ClientUtilities.GetServiceCompatibleOs(OSPlatform.OSX));
        }

        [Test]
        public void GetOSPlatform_WithLinuxString_ReturnsLinux()
        {
            OSPlatform? result = ClientUtilities.GetOSPlatform(OSConstants.s_lINUX);
            Assert.That(result, Is.EqualTo(OSPlatform.Linux));
        }

        [Test]
        public void GetOSPlatform_WithWindowsString_ReturnsWindows()
        {
            OSPlatform? result = ClientUtilities.GetOSPlatform(OSConstants.s_wINDOWS);
            Assert.That(result, Is.EqualTo(OSPlatform.Windows));
        }

        [Test]
        public void GetOSPlatform_WithNullOrEmpty_ReturnsNull()
        {
            Assert.That(ClientUtilities.GetOSPlatform(null), Is.Null);
            Assert.That(ClientUtilities.GetOSPlatform(""), Is.Null);
        }

        [Test]
        public void GetOSPlatform_WithInvalidString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ClientUtilities.GetOSPlatform("invalid_os"));
        }

        [Test]
        public void GetDefaultRunId_WhenEnvVarIsSet_ReturnsEnvVar()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, "runid123");
            var util = new ClientUtilities(environment);
            var result = util.GetDefaultRunId();
            Assert.That(result, Is.EqualTo("runid123"));
        }

        [Test]
        public void GetDefaultRunId_WhenEnvVarIsNotSet_CallsCIProviderAndSetsEnvVar()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, null);
            var util = new ClientUtilities(environment);
            var result = util.GetDefaultRunId();
            Assert.That(Guid.TryParse(result, out _), Is.True);
        }

        [Test]
        public void ValidateMptPAT_WithNullToken_Throws()
        {
            var environment = new TestEnvironment();
            var util = new ClientUtilities(environment);
            Assert.Throws<Exception>(() => util.ValidateMptPAT(null, "wss://region.api.playwright.io/playwrightworkspaces/workspace123/"));
        }

        [Test]
        public void ValidateMptPAT_WithInvalidJwt_Throws()
        {
            var environment = new TestEnvironment();

            var jwtHandlerMock = new Mock<JsonWebTokenHandler>();
            jwtHandlerMock.Setup(j => j.ReadJsonWebToken("badtoken")).Throws(new Exception());
            var util = new ClientUtilities(jsonWebTokenHandler: jwtHandlerMock.Object, environment: environment);
            Assert.Throws<Exception>(() => util.ValidateMptPAT("badtoken", "wss://region.api.playwright.io/playwrightworkspaces/workspace123/"));
        }

        [Test]
        public void ValidateMptPAT_WithWorkspaceMismatch_Throws()
        {
            var environment = new TestEnvironment();
            var token = TestUtilities.GetToken(new Dictionary<string, object>
            {
                {"pwid", "workspace321"},
            });
            var jwt = new JsonWebToken(token);
            var jwtHandlerMock = new Mock<JsonWebTokenHandler>();
            jwtHandlerMock.Setup(j => j.ReadJsonWebToken(It.IsAny<string>())).Returns(jwt);

            var util = new ClientUtilities(jsonWebTokenHandler: jwtHandlerMock.Object, environment: environment);
            Assert.Throws<Exception>(() => util.ValidateMptPAT("token", "wss://region.api.playwright.io/playwrightworkspaces/workspace123/"));
        }

        [Test]
        public void ValidateMptPAT_WithExpiredToken_Throws()
        {
            var environment = new TestEnvironment();
            var token = TestUtilities.GetToken(new Dictionary<string, object>
            {
                {"pwid", "workspace123"},
            }, DateTime.UtcNow.Add(TimeSpan.FromMinutes(-10)));
            var jwt = new JsonWebToken(token);
            var jwtHandlerMock = new Mock<JsonWebTokenHandler>();
            jwtHandlerMock.Setup(j => j.ReadJsonWebToken(It.IsAny<string>())).Returns(jwt);

            var util = new ClientUtilities(jsonWebTokenHandler: jwtHandlerMock.Object, environment: environment);
            Assert.Throws<Exception>(() => util.ValidateMptPAT("token", "wss://region.api.playwright.io/playwrightworkspaces/workspace123/"));
        }

        [Test]
        public void ValidateMptPAT_WithValidToken_DoesNotThrow()
        {
            var environment = new TestEnvironment();
            var token = TestUtilities.GetToken(new Dictionary<string, object>
            {
                {"pwid", "workspace123"},
            });
            var jwt = new JsonWebToken(token);
            var jwtHandlerMock = new Mock<JsonWebTokenHandler>();
            jwtHandlerMock.Setup(j => j.ReadJsonWebToken(It.IsAny<string>())).Returns(jwt);

            var util = new ClientUtilities(jsonWebTokenHandler: jwtHandlerMock.Object, environment: environment);
            Assert.DoesNotThrow(() => util.ValidateMptPAT("token", "wss://region.api.playwright.io/playwrightworkspaces/workspace123/"));
        }
    }
}
