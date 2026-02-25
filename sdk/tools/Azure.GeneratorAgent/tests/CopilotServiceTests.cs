// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

public class CopilotServiceTests
{
    private static AppSettings CreateMockSettings()
    {
        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(x => x["Copilot:Model"]).Returns("claude-sonnet-4-20241022");
        mockConfig.Setup(x => x["Copilot:LogLevel"]).Returns("warning");
        mockConfig.Setup(x => x["Copilot:DefaultTimeoutMinutes"]).Returns("2");
        mockConfig.Setup(x => x["GitHub:ApiUrl"]).Returns("https://api.github.com");

        return new AppSettings(mockConfig.Object);
    }

    [Test]
    public void CreateAsync_WithNullLogger_ShouldThrowArgumentNullException()
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            () => CopilotService.CreateAsync("/valid/path", null!, CreateMockSettings()));

        Assert.That(ex!.ParamName, Is.EqualTo("logger"));
    }

    [Test]
    public void CreateAsync_WithNullSettings_ShouldThrowArgumentNullException()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            () => CopilotService.CreateAsync("/valid/path", logger, null!));

        Assert.That(ex!.ParamName, Is.EqualTo("settings"));
    }

    [Test]
    public void CreateAsync_WithNullProjectPath_ShouldThrowArgumentException()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => CopilotService.CreateAsync(null!, logger, settings));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
        Assert.That(ex.Message, Does.Contain("Project path is required"));
    }

    [Test]
    public void CreateAsync_WithEmptyProjectPath_ShouldThrowArgumentException()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => CopilotService.CreateAsync("", logger, settings));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
    }

    [Test]
    public void CreateAsync_WithWhitespaceProjectPath_ShouldThrowArgumentException()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => CopilotService.CreateAsync("   ", logger, settings));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
    }

    [Test]
    public void CreateAsync_WithValidArgs_WhenSdkFails_ShouldThrowInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<InvalidOperationException>(
            () => CopilotService.CreateAsync("/valid/path", loggerMock.Object, settings));

        Assert.That(ex!.Message, Does.Contain("Failed to initialize Copilot service"));
    }

    [Test]
    public void CreateAsync_WithValidPath_ShouldLogInitializationAttempt()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var settings = CreateMockSettings();

        try
        {
            CopilotService.CreateAsync("/valid/path", loggerMock.Object, settings).GetAwaiter().GetResult();
        }
        catch (InvalidOperationException)
        {
        }

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Initializing Copilot client with project path")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Test]
    public void CopilotService_ImplementsIAsyncDisposable()
    {
        Assert.That(typeof(IAsyncDisposable).IsAssignableFrom(typeof(CopilotService)), Is.True);
    }

    [Test]
    public void CopilotService_IsSealed()
    {
        Assert.That(typeof(CopilotService).IsSealed, Is.True);
    }

    [Test]
    public void CopilotService_HasCreateAsyncFactoryMethod()
    {
        var method = typeof(CopilotService).GetMethod("CreateAsync");
        Assert.That(method, Is.Not.Null);
        Assert.That(method!.IsStatic, Is.True);
        Assert.That(method.IsPublic, Is.True);
        Assert.That(method.ReturnType, Is.EqualTo(typeof(Task<CopilotService>)));
    }

    [Test]
    public void CopilotService_HasUpdateTspLocationFileAsyncMethod()
    {
        var method = typeof(CopilotService).GetMethod("UpdateTspLocationFileAsync");
        Assert.That(method, Is.Not.Null);
        Assert.That(method!.IsPublic, Is.True);
    }

    [Test]
    public void CopilotService_HasNoPublicConstructor()
    {
        var constructors = typeof(CopilotService).GetConstructors();
        Assert.That(constructors, Is.Empty, "CopilotService should have no public constructors");
    }

    [Test]
    public void CreateAsync_WhenSdkFails_ShouldWrapInnerException()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<InvalidOperationException>(
            () => CopilotService.CreateAsync("/valid/path", loggerMock.Object, settings));

        Assert.That(ex!.InnerException, Is.Not.Null, "Inner exception should preserve the SDK failure");
    }

    [Test]
    public void CreateAsync_WhenSdkFails_ShouldLogError()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var settings = CreateMockSettings();

        try
        {
            CopilotService.CreateAsync("/valid/path", loggerMock.Object, settings).GetAwaiter().GetResult();
        }
        catch (InvalidOperationException)
        {
        }

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Failed to initialize Copilot service")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Test]
    public void CreateAsync_WithTabOnlyProjectPath_ShouldThrowArgumentException()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => CopilotService.CreateAsync("\t", logger, settings));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
    }

    [Test]
    public void CreateAsync_WithNewlineProjectPath_ShouldThrowArgumentException()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => CopilotService.CreateAsync("\n", logger, settings));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
    }

    [Test]
    public void CreateAsync_WithLongValidPath_ShouldAttemptInitialization()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var settings = CreateMockSettings();
        var longPath = "/" + new string('a', 500);

        var ex = Assert.ThrowsAsync<InvalidOperationException>(
            () => CopilotService.CreateAsync(longPath, loggerMock.Object, settings));

        Assert.That(ex!.Message, Does.Contain("Failed to initialize Copilot service"));
    }

    [Test]
    public void CreateAsync_WithSpecialCharactersInPath_ShouldAttemptInitialization()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var settings = CreateMockSettings();

        var ex = Assert.ThrowsAsync<InvalidOperationException>(
            () => CopilotService.CreateAsync("/path/\u4F60\u597D/\u00E9\u00F1", loggerMock.Object, settings));

        Assert.That(ex!.Message, Does.Contain("Failed to initialize Copilot service"));
    }

    [Test]
    public void CreateAsync_FactoryMethod_HasCorrectParameterNames()
    {
        var method = typeof(CopilotService).GetMethod("CreateAsync");
        var parameters = method!.GetParameters();

        Assert.That(parameters.Length, Is.EqualTo(4));
        Assert.That(parameters[0].Name, Is.EqualTo("projectPath"));
        Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(string)));
        Assert.That(parameters[1].Name, Is.EqualTo("logger"));
        Assert.That(parameters[2].Name, Is.EqualTo("settings"));
        Assert.That(parameters[3].Name, Is.EqualTo("cancellationToken"));
        Assert.That(parameters[3].HasDefaultValue, Is.True);
    }

    [Test]
    public void UpdateTspLocationFileAsync_HasCorrectParameterNames()
    {
        var method = typeof(CopilotService).GetMethod("UpdateTspLocationFileAsync");
        var parameters = method!.GetParameters();

        Assert.That(parameters.Length, Is.EqualTo(3));
        Assert.That(parameters[0].Name, Is.EqualTo("projectPath"));
        Assert.That(parameters[1].Name, Is.EqualTo("repoName"));
        Assert.That(parameters[2].Name, Is.EqualTo("cancellationToken"));
        Assert.That(parameters[2].HasDefaultValue, Is.True);
    }

    [Test]
    public void DisposeAsync_ReturnsValueTask()
    {
        var method = typeof(CopilotService).GetMethod("DisposeAsync");
        Assert.That(method!.ReturnType, Is.EqualTo(typeof(ValueTask)));
    }

    [Test]
    public void AppSettings_HaveExpectedDefaultValues()
    {
        var settings = CreateMockSettings();

        Assert.That(settings.Model, Is.EqualTo("claude-sonnet-4-20241022"));
        Assert.That(settings.LogLevel, Is.EqualTo("warning"));
        Assert.That(settings.DefaultTimeout, Is.EqualTo(TimeSpan.FromMinutes(2)));
        Assert.That(settings.GitHubApiUrl, Is.EqualTo("https://api.github.com"));
    }
}
