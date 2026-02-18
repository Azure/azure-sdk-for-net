// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using Azure.GeneratorAgent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

public class GitServiceTests
{
    /// <summary>
    /// Creates a mock AppSettings with default values for use in GitService tests.
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
    public async Task GetLatestCommitWithPathAsync_WithValidRepository_ReturnsCommitInfo()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var copilotServiceMock = new Mock<CopilotService>(new Mock<ILogger<CopilotService>>().Object, CreateMockSettings());
        var httpClientMock = CreateMockHttpClient("""
            [
                {
                    "sha": "abc123def456789012345678901234567890abcd",
                    "commit": {
                        "message": "Test commit"
                    }
                }
            ]
            """);

        var gitService = new GitService(loggerMock.Object, httpClientMock, copilotServiceMock.Object, CreateMockSettings());

        var result = await gitService.GetLatestCommitWithPathAsync("owner", "repo", "/test/project/path", "some/path");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.CommitSha, Is.EqualTo("abc123def456789012345678901234567890abcd"));
        Assert.That(result.Value.ResolvedPath, Is.EqualTo("some/path"));
    }

    [Test]
    public async Task GetLatestCommitWithPathAsync_WithPath_ReturnsCommitInfo()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var copilotServiceMock = new Mock<CopilotService>(new Mock<ILogger<CopilotService>>().Object, CreateMockSettings());
        var httpClientMock = CreateMockHttpClient("""
            [
                {
                    "sha": "def456abc789012345678901234567890abcdef1",
                    "commit": {
                        "message": "Update specific path"
                    }
                }
            ]
            """);

        var gitService = new GitService(loggerMock.Object, httpClientMock, copilotServiceMock.Object, CreateMockSettings());

        var result = await gitService.GetLatestCommitWithPathAsync("owner", "repo", "/test/project/path", "sdk/some-service");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.CommitSha, Is.EqualTo("def456abc789012345678901234567890abcdef1"));
        Assert.That(result.Value.ResolvedPath, Is.EqualTo("sdk/some-service"));
    }

    [Test]
    public async Task GetLatestCommitWithPathAsync_WithFailedRequest_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var copilotServiceMock = new Mock<CopilotService>(new Mock<ILogger<CopilotService>>().Object, CreateMockSettings());
        var httpClientMock = CreateMockHttpClient("", HttpStatusCode.NotFound);

        var gitService = new GitService(loggerMock.Object, httpClientMock, copilotServiceMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            gitService.GetLatestCommitWithPathAsync("owner", "repo", "/test/project/path"));

        Assert.That(ex!.Message, Does.Contain("No commits found in repository"));
    }

    [Test]
    public async Task GetLatestCommitWithPathAsync_WithEmptyResponse_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var copilotServiceMock = new Mock<CopilotService>(new Mock<ILogger<CopilotService>>().Object, CreateMockSettings());
        var httpClientMock = CreateMockHttpClient("[]");

        var gitService = new GitService(loggerMock.Object, httpClientMock, copilotServiceMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            gitService.GetLatestCommitWithPathAsync("owner", "repo", "/test/project/path", "path"));

        Assert.That(ex!.Message, Does.Contain("No commits found"));
    }

    [Test]
    public void GetLatestCommitWithPathAsync_WithOversizedResponse_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var copilotServiceMock = new Mock<CopilotService>(new Mock<ILogger<CopilotService>>().Object, CreateMockSettings());

        // Create a large valid JSON response that exceeds 1MB limit
        var largeResponse = '[' + new string(' ', 1_000_000) + ']'; // Creates a 1,000,002 character response

        var httpClientMock = CreateMockHttpClient(largeResponse);

        var gitService = new GitService(loggerMock.Object, httpClientMock, copilotServiceMock.Object, CreateMockSettings());

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            gitService.GetLatestCommitWithPathAsync("owner", "repo", "/test/project/path", "some/path"));

        Assert.That(ex!.Message, Does.Contain("API response exceeded maximum allowed size"));
    }

    private static HttpClient CreateMockHttpClient(string responseContent, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
            });

        return new HttpClient(mockHandler.Object);
    }
}
