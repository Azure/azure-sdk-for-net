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
    public async Task TryGetCommitForPath_WithValidRepository_ReturnsCommitSha()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
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

        var gitService = new GitService(loggerMock.Object, httpClientMock, CreateMockSettings());

        var result = await gitService.TryGetCommitForPath("owner", "repo", "some/path", CancellationToken.None);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo("abc123def456789012345678901234567890abcd"));
    }

    [Test]
    public async Task TryGetCommitForPath_WithSpecificPath_ReturnsCommitSha()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
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

        var gitService = new GitService(loggerMock.Object, httpClientMock, CreateMockSettings());

        var result = await gitService.TryGetCommitForPath("owner", "repo", "sdk/some-service", CancellationToken.None);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo("def456abc789012345678901234567890abcdef1"));
    }

    [Test]
    public async Task TryGetCommitForPath_WithFailedRequest_ReturnsNull()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var httpClientMock = CreateMockHttpClient("", HttpStatusCode.NotFound);

        var gitService = new GitService(loggerMock.Object, httpClientMock, CreateMockSettings());

        var result = await gitService.TryGetCommitForPath("owner", "repo", "/test/project/path", CancellationToken.None);

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task TryGetCommitForPath_WithEmptyResponse_ReturnsNull()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var httpClientMock = CreateMockHttpClient("[]");

        var gitService = new GitService(loggerMock.Object, httpClientMock, CreateMockSettings());

        var result = await gitService.TryGetCommitForPath("owner", "repo", "/test/project/path", CancellationToken.None);

        Assert.That(result, Is.Null);
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
