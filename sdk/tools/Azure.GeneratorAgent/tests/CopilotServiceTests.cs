// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

public class CopilotServiceTests
{
    private static readonly string s_repoRoot = Path.GetFullPath(
        Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "..", "..", "..", "..")) + Path.DirectorySeparatorChar;

    private static readonly string s_projectPath = Path.Combine(s_repoRoot, "sdk", "vision", "Azure.AI.Vision.ImageAnalysis");

    private static readonly string s_normalizedProjectPath =
        s_projectPath.EndsWith(Path.DirectorySeparatorChar) ? s_projectPath : s_projectPath + Path.DirectorySeparatorChar;

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

    [Test]
    public void ResolveToolPath_Edit_ExtractsAbsolutePath()
    {
        var filePath = Path.Combine(s_projectPath, "src", "Generated", "Models", "Foo.cs");
        var args = JsonSerializer.Serialize(new { path = filePath });

        var result = CopilotService.ResolveToolPath("edit", args, s_projectPath);

        Assert.That(result, Is.EqualTo(Path.GetFullPath(filePath)));
    }

    [Test]
    public void ResolveToolPath_Edit_ResolvesRelativePath()
    {
        var args = JsonSerializer.Serialize(new { path = "src/Foo.cs" });

        var result = CopilotService.ResolveToolPath("edit", args, s_projectPath);

        Assert.That(result, Is.EqualTo(Path.GetFullPath(Path.Combine(s_projectPath, "src", "Foo.cs"))));
    }

    [Test]
    public void ResolveToolPath_Edit_NullArgs_ReturnsNull()
    {
        var result = CopilotService.ResolveToolPath("edit", null, s_projectPath);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ResolveToolPath_Edit_MissingPathProperty_ReturnsNull()
    {
        var args = JsonSerializer.Serialize(new { notPath = "foo" });
        var result = CopilotService.ResolveToolPath("edit", args, s_projectPath);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ResolveToolPath_Powershell_ExtractsFirstAbsolutePath()
    {
        var command = $"cd {s_repoRoot.TrimEnd(Path.DirectorySeparatorChar)}; .\\eng\\scripts\\Export-API.ps1 -ServiceDirectory vision";
        var args = JsonSerializer.Serialize(new { command });

        var result = CopilotService.ResolveToolPath("powershell", args, s_projectPath);

        Assert.That(result, Is.Not.Null);
        Assert.That(Path.IsPathFullyQualified(result!), Is.True);
    }

    [Test]
    public void ResolveToolPath_Powershell_NoAbsolutePath_ReturnsNull()
    {
        var args = JsonSerializer.Serialize(new { command = "dotnet build" });

        var result = CopilotService.ResolveToolPath("powershell", args, s_projectPath);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ResolveToolPath_ReadPowershell_ReturnsNull()
    {
        var args = JsonSerializer.Serialize(new { shellId = "abc", delay = 100 });

        var result = CopilotService.ResolveToolPath("read_powershell", args, s_projectPath);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ValidateToolAccess_Edit_InsideProject_ReturnsNull()
    {
        var filePath = Path.Combine(s_projectPath, "src", "Foo.cs");
        var args = JsonSerializer.Serialize(new { path = filePath });

        var result = CopilotService.ValidateToolAccess("edit", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "edit inside project directory should be allowed");
    }

    [Test]
    public void ValidateToolAccess_Edit_OutsideProject_ReturnsDenial()
    {
        var outsidePath = Path.Combine(s_repoRoot, "sdk", "storage", "SomeFile.cs");
        var args = JsonSerializer.Serialize(new { path = outsidePath });

        var result = CopilotService.ValidateToolAccess("edit", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("outside the project directory"));
    }

    [Test]
    public void ValidateToolAccess_Create_NoPath_ReturnsDenial()
    {
        var args = JsonSerializer.Serialize(new { notPath = "foo" });

        var result = CopilotService.ValidateToolAccess("create", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("No file path found"));
    }

    [Test]
    public void ValidateToolAccess_View_InsideRepo_ReturnsNull()
    {
        var filePath = Path.Combine(s_repoRoot, "eng", "Packages.Data.props");
        var args = JsonSerializer.Serialize(new { path = filePath });

        var result = CopilotService.ValidateToolAccess("view", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "view inside repo root should be allowed");
    }

    [Test]
    public void ValidateToolAccess_View_OutsideRepo_ReturnsDenial()
    {
        var outsidePath = Path.GetFullPath(Path.Combine(s_repoRoot, "..", "some-other-repo", "file.txt"));
        var args = JsonSerializer.Serialize(new { path = outsidePath });

        var result = CopilotService.ValidateToolAccess("view", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("outside the repository directory"));
    }

    [Test]
    public void ValidateToolAccess_View_TempDirectory_ReturnsNull()
    {
        var tempFile = Path.Combine(Path.GetTempPath(), "copilot-tool-output-12345.txt");
        var args = JsonSerializer.Serialize(new { path = tempFile });

        var result = CopilotService.ValidateToolAccess("view", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "view inside temp directory should be allowed");
    }

    [Test]
    public void ValidateToolAccess_Powershell_CdToRepoRoot_ReturnsNull()
    {
        var command = $"cd {s_repoRoot.TrimEnd(Path.DirectorySeparatorChar)}; .\\eng\\scripts\\Export-API.ps1";
        var args = JsonSerializer.Serialize(new { command });

        var result = CopilotService.ValidateToolAccess("powershell", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "powershell cd to repo root should be allowed");
    }

    [Test]
    public void ValidateToolAccess_Powershell_CdOutsideRepo_ReturnsDenial()
    {
        var outsideDir = Path.GetFullPath(Path.Combine(s_repoRoot, "..", "some-other-repo"));
        var command = $"cd {outsideDir}; ls";
        var args = JsonSerializer.Serialize(new { command });

        var result = CopilotService.ValidateToolAccess("powershell", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("outside the repository directory"));
    }

    [Test]
    public void ValidateToolAccess_Powershell_NoAbsolutePath_ReturnsNull()
    {
        var args = JsonSerializer.Serialize(new { command = "dotnet build" });

        var result = CopilotService.ValidateToolAccess("powershell", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "powershell with no absolute paths should be allowed");
    }

    [Test]
    public void ValidateToolAccess_ReadPowershell_AlwaysReturnsNull()
    {
        var args = JsonSerializer.Serialize(new { shellId = "abc", delay = 100 });

        var result = CopilotService.ValidateToolAccess("read_powershell", args, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "read_powershell should always be allowed");
    }

    [Test]
    public void ValidateToolAccess_UnknownTool_ReturnsNull()
    {
        var result = CopilotService.ValidateToolAccess("some_future_tool", null, s_projectPath, s_normalizedProjectPath, s_repoRoot);

        Assert.That(result, Is.Null, "unknown tools should pass through (no path to validate)");
    }

    [Test]
    public void AccessDenied_CancelsLinkedToken_And_ThrowsUnauthorizedAccessException()
    {
        var accessDeniedCts = new CancellationTokenSource();
        var userCts = new CancellationTokenSource();
        var timeoutCts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
        using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(
            userCts.Token, timeoutCts.Token, accessDeniedCts.Token);

        var completionTcs = new TaskCompletionSource();

        // Simulate the hook denying access
        accessDeniedCts.Cancel();

        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
        {
            try
            {
                await completionTcs.Task.WaitAsync(combinedCts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (accessDeniedCts.IsCancellationRequested)
            {
                throw new UnauthorizedAccessException(
                    "Permission denied: a tool attempted to access a path outside the allowed directories. Aborting execution.");
            }
        });

        Assert.That(ex!.Message, Does.Contain("Permission denied"));
        Assert.That(accessDeniedCts.IsCancellationRequested, Is.True);
        Assert.That(userCts.IsCancellationRequested, Is.False, "User CTS should not be cancelled");
    }

    [Test]
    public void AccessDenied_DoesNotConfuseWithUserCancellation()
    {
        var accessDeniedCts = new CancellationTokenSource();
        var userCts = new CancellationTokenSource();
        var timeoutCts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
        using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(
            userCts.Token, timeoutCts.Token, accessDeniedCts.Token);

        var completionTcs = new TaskCompletionSource();

        // Simulate user cancellation (not access denied)
        userCts.Cancel();

        string? result = null;
        Assert.DoesNotThrowAsync(async () =>
        {
            try
            {
                await completionTcs.Task.WaitAsync(combinedCts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (accessDeniedCts.IsCancellationRequested)
            {
                throw new UnauthorizedAccessException("Should not reach here");
            }
            catch (OperationCanceledException) when (userCts.IsCancellationRequested)
            {
                result = "user_cancelled";
            }
        });

        Assert.That(result, Is.EqualTo("user_cancelled"));
        Assert.That(accessDeniedCts.IsCancellationRequested, Is.False);
    }

    [Test]
    public void AccessDenied_DoesNotConfuseWithTimeout()
    {
        var accessDeniedCts = new CancellationTokenSource();
        var userCts = new CancellationTokenSource();
        var timeoutCts = new CancellationTokenSource();
        timeoutCts.Cancel();
        using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(
            userCts.Token, timeoutCts.Token, accessDeniedCts.Token);

        var completionTcs = new TaskCompletionSource();

        string? result = null;
        Assert.DoesNotThrowAsync(async () =>
        {
            try
            {
                await completionTcs.Task.WaitAsync(combinedCts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (accessDeniedCts.IsCancellationRequested)
            {
                throw new UnauthorizedAccessException("Should not reach here");
            }
            catch (OperationCanceledException) when (userCts.IsCancellationRequested)
            {
                result = "user_cancelled";
            }
            catch (OperationCanceledException)
            {
                result = "timeout";
            }
        });

        Assert.That(result, Is.EqualTo("timeout"));
        Assert.That(accessDeniedCts.IsCancellationRequested, Is.False);
    }
}
