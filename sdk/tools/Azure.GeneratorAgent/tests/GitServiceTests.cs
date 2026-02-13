// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Net;
using System.Text;

namespace Azure.GeneratorAgent.Tests;

public class GitServiceTests
{
    [Test]
    public async Task GetLatestCommitAsync_WithValidRepository_ReturnsCommitSha()
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

        var gitService = new GitService(loggerMock.Object, httpClientMock);

        var commitSha = await gitService.GetLatestCommitAsync("owner", "repo");

        Assert.That(commitSha, Is.EqualTo("abc123def456789012345678901234567890abcd"));
    }

    [Test]
    public async Task GetLatestCommitAsync_WithPath_ReturnsCommitSha()
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

        var gitService = new GitService(loggerMock.Object, httpClientMock);

        var commitSha = await gitService.GetLatestCommitAsync("owner", "repo", "sdk/some-service");

        Assert.That(commitSha, Is.EqualTo("def456abc789012345678901234567890abcdef1"));
    }

    [Test]
    public async Task GetLatestCommitAsync_WithFailedRequest_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var httpClientMock = CreateMockHttpClient("", HttpStatusCode.NotFound);

        var gitService = new GitService(loggerMock.Object, httpClientMock);

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            gitService.GetLatestCommitAsync("owner", "repo"));

        Assert.That(ex!.Message, Does.Contain("Failed to fetch commits from GitHub API"));
    }

    [Test]
    public async Task GetLatestCommitAsync_WithEmptyResponse_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var httpClientMock = CreateMockHttpClient("[]");

        var gitService = new GitService(loggerMock.Object, httpClientMock);

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            gitService.GetLatestCommitAsync("owner", "repo"));

        Assert.That(ex!.Message, Does.Contain("No commits found"));
    }

    [Test]
    public void GetLatestCommitAsync_WithOversizedResponse_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<GitService>>();
        var largeResponse = new string('x', 1_000_001); // Exceeds 1MB limit
        var httpClientMock = CreateMockHttpClient(largeResponse);

        var gitService = new GitService(loggerMock.Object, httpClientMock);

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            gitService.GetLatestCommitAsync("owner", "repo"));

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
