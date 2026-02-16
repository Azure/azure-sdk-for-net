// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests.Services;

public class GitServiceTests
{
    [Test]
    public void GetLatestCommitAsync_WithNonGitDirectory_ThrowsInvalidOperationException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<GitService>>();
        var gitService = new GitService(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempPath);

        try
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
                gitService.GetLatestCommitAsync(tempPath));

            Assert.That(ex!.Message, Does.Contain("Not within a git repository"));
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }

    [Test]
    public async Task GetLatestCommitAsync_WithValidGitRepo_ReturnsCommitSha()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<GitService>>();
        var gitService = new GitService(loggerMock.Object);
        var currentDir = Directory.GetCurrentDirectory();
        var repoRoot = FindGitRoot(currentDir);

        if (repoRoot == null)
        {
            Assert.Ignore("Test must be run from within a git repository");
            return;
        }

        if (!await IsGitAvailableAsync())
        {
            Assert.Ignore("Git is not available on the system");
            return;
        }

        // Act
        var commitSha = await gitService.GetLatestCommitAsync(repoRoot);

        // Assert
        Assert.That(commitSha, Is.Not.Null);
        Assert.That(commitSha, Has.Length.EqualTo(40)); // Git SHA is 40 characters
        Assert.That(commitSha, Does.Match("^[0-9a-f]{40}$")); // Hexadecimal
    }

    private static string? FindGitRoot(string path)
    {
        var dir = new DirectoryInfo(path);
        while (dir != null)
        {
            if (Directory.Exists(Path.Combine(dir.FullName, ".git")))
            {
                return dir.FullName;
            }
            dir = dir.Parent;
        }
        return null;
    }

    private static async Task<bool> IsGitAvailableAsync()
    {
        try
        {
            using var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            await process.WaitForExitAsync();
            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }
}
