// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Implementation
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class CloudRunErrorParserTests
    {
        private Mock<ILogger>? _loggerMock;
        private Mock<IConsoleWriter>? _consoleWriterMock;
        private CloudRunErrorParser? _errorParser;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _consoleWriterMock = new Mock<IConsoleWriter>();
            _errorParser = new CloudRunErrorParser(_loggerMock.Object, _consoleWriterMock.Object);
        }

        [Test]
        public void TryPushMessageAndKey_WithValidMessageAndKey_ReturnsTrue()
        {
            string message = "Test message";
            string key = "Test key";

            bool result = _errorParser!.TryPushMessageAndKey(message, key);

            Assert.IsTrue(result);
        }

        [Test]
        public void TryPushMessageAndKey_WithNullOrEmptyMessage_ReturnsFalse()
        {
            string? message = null;
            string key = "Test key";

            bool result = _errorParser!.TryPushMessageAndKey(message, key);

            Assert.IsFalse(result);
        }

        [Test]
        public void TryPushMessageAndKey_WithNullOrEmptyKey_ReturnsFalse()
        {
            string message = "Test message";
            string? key = null;

            bool result = _errorParser!.TryPushMessageAndKey(message, key);

            Assert.IsFalse(result);
        }

        [Test]
        public void TryPushMessageAndKey_WithExistingKey_ReturnsFalse()
        {
            string message = "Test message";
            string key = "Existing key";
            _errorParser!.TryPushMessageAndKey(message, key);

            bool result = _errorParser.TryPushMessageAndKey(message, key);

            Assert.IsFalse(result);
        }

        [Test]
        public void PushMessage_AddsMessageToList()
        {
            string message = "Test message";

            _errorParser!.PushMessage(message);

            CollectionAssert.Contains(_errorParser!.InformationalMessages, message);
        }

        [Test]
        public void DisplayMessages_WithMessages_WritesMessagesToConsole()
        {
            _errorParser!.PushMessage("Message 1");
            _errorParser.PushMessage("Message 2");

            _errorParser.DisplayMessages();

            _consoleWriterMock!.Verify(cw => cw.WriteLine(null), Times.Once);
            _consoleWriterMock.Verify(cw => cw.WriteLine("1) Message 1"), Times.Once);
            _consoleWriterMock.Verify(cw => cw.WriteLine("2) Message 2"), Times.Once);
        }

        [Test]
        public void DisplayMessages_WithoutMessages_DoesNotWriteToConsole()
        {
            _errorParser!.DisplayMessages();

            _consoleWriterMock!.Verify(cw => cw.WriteLine(null), Times.Never);
            _consoleWriterMock.Verify(cw => cw.WriteLine(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void PrintErrorToConsole_WritesErrorMessageToConsole()
        {
            string errorMessage = "Test error message";

            _errorParser!.PrintErrorToConsole(errorMessage);

            _consoleWriterMock!.Verify(cw => cw.WriteError(errorMessage), Times.Once);
        }

        [Test]
        public void HandleScalableRunErrorMessage_WithNullMessage_DoesNotPushMessage()
        {
            _errorParser!.HandleScalableRunErrorMessage(null);

            Assert.IsEmpty(_errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessage_WithoutMatchingPattern_DoesNotPushMessage()
        {
            string message = "Unknown error";

            _errorParser!.HandleScalableRunErrorMessage(message);

            Assert.IsEmpty(_errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessage401_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_123/browsers 401 Unauthorized";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The authentication token provided is invalid. Please check the token and try again.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageNoPermissionOnWorkspaceScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_123/browsers 403 Forbidden\r\nCheckAccess API call with non successful response.";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = @"You do not have the required permissions to run tests. This could be because:

    a. You do not have the required roles on the workspace. Only Owner and Contributor roles can run tests. Contact the service administrator.
    b. The workspace you are trying to run the tests on is in a different Azure tenant than what you are signed into. Check the tenant id from Azure portal and login using the command 'az login --tenant <TENANT_ID>'.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageInvalidWorkspaceScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_123/browsers 403 Forbidden\r\nInvalidAccountOrSubscriptionState";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The specified workspace does not exist. Please verify your workspace settings.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageInvalidAccessToken_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_123/browsers 403 Forbidden\r\nInvalidAccessToken";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The provided access token does not match the specified workspace URL. Please verify that both values are correct.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageAccessTokenOrUserOrWorkspaceNotFoundScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_123/browsers 404 Not Found\r\nNotFound";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The data for the user, workspace or access token was not found. Please check the request or create new token and try again.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageAccessKeyBasedAuthNotSupportedScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_123/browsers 403 Forbidden\r\nAccessKeyBasedAuthNotSupported";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "Authentication through service access token is disabled for this workspace. Please use Entra ID to authenticate.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageServiceUnavailableScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_1120dd21-4e05-4b3d-8b54-e329307ff214/browsers 503 Service Unavailable";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The service is currently unavailable. Please check the service status and try again.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageGatewayTimeoutScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = " Microsoft.Playwright.PlaywrightException : WebSocket error: wss://eastus.api.playwright.microsoft.com/accounts/eastus_1120dd21-4e05-4b3d-8b54-e329307ff214/browsers 504 Gateway Timeout";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The request to the service timed out. Please try again later.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageQuotaLimitErrorScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = "Timeout 60000s exceeded,\r\nws connecting wss://eastus.api.playwright.microsoft.com/accounts/eastus_1120dd21-4e05-4b3d-8b54-e329307ff214/browsers";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "It is possible that the maximum number of concurrent sessions allowed for your workspace has been exceeded.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }

        [Test]
        public void HandleScalableRunErrorMessageBrowserConnectionErrorScalable_WithMatchingPattern_PushesMessage()
        {
            string errorMessage = "Target page, context or browser has been closed";

            _errorParser!.HandleScalableRunErrorMessage(errorMessage);
            var message = "The service is currently unavailable. Please try again after some time.";
            Assert.Contains(message, _errorParser.InformationalMessages);
        }
    }
}
