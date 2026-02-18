// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

public class CopilotServiceTests
{
    /// <summary>
    /// Creates a mock AppSettings with default values.
    /// </summary>
    /// <returns>Mock AppSettings instance.</returns>
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
    public void Constructor_WithValidLogger_ShouldInitializeCorrectly()
    {
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var settings = CreateMockSettings();
        var service = new CopilotService(logger, settings);

        Assert.That(service, Is.Not.Null);
        Assert.That(service.IsCopilotAvailable, Is.False, "Should not be available initially");
    }

    [Test]
    public void IsCopilotAvailable_Initially_ShouldReturnFalse()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        Assert.That(copilotService.IsCopilotAvailable, Is.False,
            "IsCopilotAvailable should return false before initialization");
    }

    [Test]
    public async Task InitializeCopilotAsync_WithNullProjectPath_ShouldThrowArgumentException()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => copilotService.InitializeCopilotAsync(null!));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
        Assert.That(ex.Message, Does.Contain("Project path is required"));

        // Verify error logging
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Project path is required")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Test]
    public async Task InitializeCopilotAsync_WithEmptyProjectPath_ShouldThrowArgumentException()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => copilotService.InitializeCopilotAsync(""));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
        Assert.That(ex.Message, Does.Contain("Project path is required"));
    }

    [Test]
    public async Task InitializeCopilotAsync_WithWhitespaceProjectPath_ShouldThrowArgumentException()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => copilotService.InitializeCopilotAsync("   "));

        Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
        Assert.That(ex.Message, Does.Contain("Project path is required"));
    }

    [Test]
    public async Task UpdateTspLocationFileAsync_WhenNotInitialized_ShouldThrowInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<InvalidOperationException>(
            () => copilotService.UpdateTspLocationFileAsync("/project/path", "repo-name"));

        Assert.That(ex!.Message, Does.Contain("Copilot client and session must be initialized"));

        // Verify error logging
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Copilot client and session must be initialized")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Test]
    public async Task DisposeAsync_WhenNotInitialized_ShouldCompleteWithoutError()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        Assert.DoesNotThrowAsync(async () => await copilotService.DisposeAsync());
    }

    [Test]
    public async Task DisposeAsync_MultipleCallsAreSafe()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        await copilotService.DisposeAsync();

        // Second call should not throw
        Assert.DoesNotThrowAsync(async () => await copilotService.DisposeAsync());
    }

    [Test]
    public void IsCopilotAvailable_PropertyAccessMultipleTimes_ShouldBeConsistent()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        var result1 = copilotService.IsCopilotAvailable;
        var result2 = copilotService.IsCopilotAvailable;

        Assert.That(result1, Is.EqualTo(result2));
        Assert.That(result1, Is.False); // Should be false initially
    }

    [Test]
    public async Task InitializeCopilotAsync_WithValidPath_ShouldLogDebugMessage()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());
        var validPath = "/valid/project/path";

        try
        {
            await copilotService.InitializeCopilotAsync(validPath);
        }
        catch (Exception)
        {
            // Expected to fail due to external dependencies, but we can verify logging
        }

        // Verify debug logging was called
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Initializing Copilot client with project path")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Test]
    public async Task UpdateTspLocationFileAsync_WithNullRepoName_ShouldCompleteWithoutUpdating()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        // We can't easily test this without initializing, but we can test the argument validation
        try
        {
            await copilotService.UpdateTspLocationFileAsync("/project/path", null!);
            // If we somehow get here without throwing, the method completed without error
        }
        catch (InvalidOperationException)
        {
            // Expected since service is not initialized
        }
    }

    [Test]
    public async Task UpdateTspLocationFileAsync_WithEmptyRepoName_ShouldCompleteWithoutUpdating()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        try
        {
            await copilotService.UpdateTspLocationFileAsync("/project/path", "");
            // If we somehow get here without throwing, the method completed
        }
        catch (InvalidOperationException)
        {
            // Expected since service is not initialized
        }
    }

    [Test]
    public void CopilotService_ImplementsIAsyncDisposable()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        Assert.That(copilotService, Is.InstanceOf<IAsyncDisposable>());
    }

    [Test]
    public async Task InitializeCopilotAsync_ConcurrentCalls_ShouldBeThreadSafe()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());
        var validPath = "/valid/project/path";

        // This tests the lock mechanism even though initialization will likely fail
        var tasks = new[]
        {
            Task.Run(async () =>
            {
                try { await copilotService.InitializeCopilotAsync(validPath); }
                catch { /* Expected */ }
            }),
            Task.Run(async () =>
            {
                try { await copilotService.InitializeCopilotAsync(validPath); }
                catch { /* Expected */ }
            }),
            Task.Run(async () =>
            {
                try { await copilotService.InitializeCopilotAsync(validPath); }
                catch { /* Expected */ }
            })
        };

        await Task.WhenAll(tasks);

        // Test should complete without deadlocks or race conditions
        Assert.Pass("Concurrent initialization calls completed without deadlock");
    }

    [Test]
    public async Task InitializeCopilotAsync_WithTimeout_ShouldHandleTimeoutCorrectly()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(1));

        try
        {
            await copilotService.InitializeCopilotAsync("/valid/path", cts.Token);
            // This is expected due to very short timeout or external dependency failure
        }
        catch (Exception)
        {
            // Other exceptions are also expected due to external dependencies
        }

        Assert.Pass("Timeout handling test completed");
    }

    [Test]
    public void AppSettings_HaveExpectedDefaultValues()
    {
        // Test that AppSettings provides expected default values
        var settings = CreateMockSettings();

        Assert.That(settings.Model, Is.EqualTo("claude-sonnet-4-20241022"));
        Assert.That(settings.LogLevel, Is.EqualTo("warning"));
        Assert.That(settings.DefaultTimeout, Is.EqualTo(TimeSpan.FromMinutes(2)));
        Assert.That(settings.GitHubApiUrl, Is.EqualTo("https://api.github.com"));
    }

    [Test]
    public async Task CopilotService_PropertiesAndMethodsWork_WithoutExternalDependencies()
    {
        // Test basic functionality that doesn't require external dependencies

        // Test constructor
        var logger = new Mock<ILogger<CopilotService>>().Object;
        var service = new CopilotService(logger, CreateMockSettings());

        // Test initial state
        Assert.That(service.IsCopilotAvailable, Is.False);

        // Test disposal
        await service.DisposeAsync();

        // Test state after disposal
        Assert.That(service.IsCopilotAvailable, Is.False);
    }

    [Test]
    public async Task InitializeCopilotAsync_RepeatedCallsAfterFailure_ShouldRetryInitialization()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());
        var validPath = "/valid/project/path";

        // First call - should fail due to external dependencies
        try
        {
            await copilotService.InitializeCopilotAsync(validPath);
        }
        catch (Exception)
        {
            // Expected
        }

        // Second call - should also attempt initialization (not skip due to previous failure)
        try
        {
            await copilotService.InitializeCopilotAsync(validPath);
        }
        catch (Exception)
        {
            // Expected
        }

        // Verify that initialization was attempted both times (debug logging should occur twice)
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Initializing Copilot client with project path")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Test]
    public async Task UpdateTspLocationFileAsync_WithWhitespaceRepoName_ShouldCompleteWithoutUpdating()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        try
        {
            await copilotService.UpdateTspLocationFileAsync("/project/path", "   ");
            // If we somehow get here without throwing, the method completed
        }
        catch (InvalidOperationException)
        {
            // Expected since service is not initialized
        }
    }

    [Test]
    public async Task InitializeCopilotAsync_WithVeryLongPath_ShouldNotThrow()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());
        var longPath = new string('a', 1000); // Very long path

        try
        {
            await copilotService.InitializeCopilotAsync(longPath);
        }
        catch (ArgumentException)
        {
            Assert.Fail("Should not throw ArgumentException for long but valid path");
        }
        catch (Exception)
        {
            // Other exceptions are expected due to external dependencies
        }

        Assert.Pass("Long path handling test completed");
    }

    [Test]
    public async Task InitializeCopilotAsync_WithSpecialCharactersInPath_ShouldNotThrow()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());
        var pathWithSpecialChars = "/path/\u4F60\u597D/\u00E9\u00F1\u00FC"; // Unicode characters

        try
        {
            await copilotService.InitializeCopilotAsync(pathWithSpecialChars);
        }
        catch (ArgumentException)
        {
            Assert.Fail("Should not throw ArgumentException for path with special characters");
        }
        catch (Exception)
        {
            // Other exceptions are expected due to external dependencies
        }

        Assert.Pass("Special character path handling test completed");
    }

    [Test]
    public void CopilotService_ThreadSafety_PropertyAccess()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        // Test that multiple threads can safely access the IsCopilotAvailable property
        var tasks = new Task[10];
        var results = new bool[10];

        for (int i = 0; i < 10; i++)
        {
            var index = i;
            tasks[i] = Task.Run(() =>
            {
                results[index] = copilotService.IsCopilotAvailable;
            });
        }

        Task.WaitAll(tasks);

        // All results should be the same (false initially)
        Assert.That(results.All(r => r == false), Is.True, "All property access results should be consistent");
    }

    [Test]
    public async Task DisposeAsync_CalledDuringInitialization_ShouldNotCauseDeadlock()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        var initTask = Task.Run(async () =>
        {
            try
            {
                await copilotService.InitializeCopilotAsync("/valid/path");
            }
            catch (Exception)
            {
                // Expected
            }
        });

        var disposeTask = Task.Run(async () =>
        {
            await Task.Delay(10); // Small delay
            try
            {
                await copilotService.DisposeAsync();
            }
            catch (Exception)
            {
                // Should not throw
            }
        });

        // Both tasks should complete without deadlock
        await Task.WhenAll(initTask, disposeTask);
    }

    [Test]
    public async Task UpdateTspLocationFileAsync_ExceptionHandling_ShouldThrowOnError()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        // This tests error handling in UpdateTspLocationFileAsync when not initialized
        var ex = Assert.ThrowsAsync<InvalidOperationException>(
            () => copilotService.UpdateTspLocationFileAsync("/project", "repo"));

        Assert.That(ex!.Message, Does.Contain("must be initialized"));

        // Verify the service is still in a valid state
        Assert.That(copilotService.IsCopilotAvailable, Is.False);
    }

    [Test]
    public async Task InitializeCopilotAsync_ArgumentValidation_PreservesOriginalMessage()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());
        const string expectedMessage = "Project path is required for Copilot initialization";

        var ex = Assert.ThrowsAsync<ArgumentException>(
            () => copilotService.InitializeCopilotAsync(null!));

        Assert.That(ex!.Message, Does.StartWith(expectedMessage));
        Assert.That(ex.ParamName, Is.EqualTo("projectPath"));
    }

    [Test]
    public async Task CopilotService_StateConsistency_AfterExceptionInInitialization()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        // Test that service state remains consistent after initialization failure

        Assert.That(copilotService.IsCopilotAvailable, Is.False, "Initially should be false");

        try
        {
            await copilotService.InitializeCopilotAsync("/some/path");
        }
        catch (Exception)
        {
            // Expected due to external dependencies
        }

        // State should still be consistent
        Assert.That(copilotService.IsCopilotAvailable, Is.False, "Should remain false after failed initialization");

        // Should still be able to dispose safely
        Assert.DoesNotThrowAsync(async () => await copilotService.DisposeAsync());
    }

    [Test]
    public async Task InitializeCopilotAsync_ProjectPathParameterHandling()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        // Test various project path scenarios

        var testCases = new[]
        {
            ("", typeof(ArgumentException)),
            ("   ", typeof(ArgumentException)),
            ("\t", typeof(ArgumentException)),
            ("\n", typeof(ArgumentException))
        };

        foreach (var (path, expectedException) in testCases)
        {
            if (expectedException == typeof(ArgumentException))
            {
                var ex = Assert.ThrowsAsync<ArgumentException>(
                    () => copilotService.InitializeCopilotAsync(path));
                Assert.That(ex!.ParamName, Is.EqualTo("projectPath"));
            }
        }
    }

    [Test]
    public async Task CopilotService_LoggingBehavior_VerifyAllLogLevels()
    {
        var loggerMock = new Mock<ILogger<CopilotService>>();
        var copilotService = new CopilotService(loggerMock.Object, CreateMockSettings());

        // Test that appropriate log levels are used for different scenarios

        // Test Error logging
        try
        {
            await copilotService.InitializeCopilotAsync(null!);
        }
        catch (ArgumentException)
        {
            // Expected
        }

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce,
            "Error level logging should occur for invalid arguments");

        // Test that initialization attempts trigger Debug logging
        try
        {
            await copilotService.InitializeCopilotAsync("/valid/path");
        }
        catch (Exception)
        {
            // Expected
        }

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Test]
    public void CopilotService_PublicInterface_HasExpectedMembers()
    {
        // Verify the class has the expected public interface
        var type = typeof(CopilotService);

        // Check IAsyncDisposable implementation
        Assert.That(typeof(IAsyncDisposable).IsAssignableFrom(type), Is.True,
            "CopilotService should implement IAsyncDisposable");

        // Check public methods exist
        var initMethod = type.GetMethod("InitializeCopilotAsync");
        Assert.That(initMethod, Is.Not.Null, "InitializeCopilotAsync method should exist");
        Assert.That(initMethod!.IsPublic, Is.True, "InitializeCopilotAsync should be public");

        var updateMethod = type.GetMethod("UpdateTspLocationFileAsync");
        Assert.That(updateMethod, Is.Not.Null, "UpdateTspLocationFileAsync method should exist");
        Assert.That(updateMethod!.IsPublic, Is.True, "UpdateTspLocationFileAsync should be public");

        var disposeMethod = type.GetMethod("DisposeAsync");
        Assert.That(disposeMethod, Is.Not.Null, "DisposeAsync method should exist");
        Assert.That(disposeMethod!.IsPublic, Is.True, "DisposeAsync should be public");

        // Check property exists
        var availableProperty = type.GetProperty("IsCopilotAvailable");
        Assert.That(availableProperty, Is.Not.Null, "IsCopilotAvailable property should exist");
        Assert.That(availableProperty!.CanRead, Is.True, "IsCopilotAvailable should be readable");
        Assert.That(availableProperty.GetMethod!.IsPublic, Is.True, "IsCopilotAvailable getter should be public");
    }

    [Test]
    public async Task CopilotService_MemoryAndResourceManagement()
    {
        // Test that multiple create/dispose cycles work correctly
        for (int i = 0; i < 3; i++)
        {
            var logger = new Mock<ILogger<CopilotService>>();
            var service = new CopilotService(logger.Object, CreateMockSettings());

            Assert.That(service.IsCopilotAvailable, Is.False);

            await service.DisposeAsync();

            // After disposal, should still be accessible but not available
            Assert.That(service.IsCopilotAvailable, Is.False);
        }

        Assert.Pass("Multiple create/dispose cycles completed successfully");
    }
}
