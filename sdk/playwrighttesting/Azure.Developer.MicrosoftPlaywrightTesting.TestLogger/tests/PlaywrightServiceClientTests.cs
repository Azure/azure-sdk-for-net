// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

public class PlaywrightServiceClientTests : RecordedTestBase<PlaywrightServiceTestEnvironment>
{
    private PlaywrightService? _playwrightService;
    private static string Access_Token => Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken)!;

    public PlaywrightServiceClientTests(bool isAsync) : base(isAsync, RecordedTestMode.Live) { }

    [SetUp]
    public async Task Setup()
    {
        var workspaceId = TestUtils.GetWorkspaceIdFromDashboardEndpoint(TestEnvironment.DashboardEndpoint);
        var region = TestEnvironment.Region;
        var serviceApiEndpoint = TestUtils.GetPlaywrightServiceAPIEndpoint(workspaceId, region);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, serviceApiEndpoint);
        _playwrightService = new PlaywrightService(new PlaywrightServiceOptions(), credential: TestEnvironment.Credential);
        await _playwrightService.InitializeAsync();
    }

    [TearDown]
    public void Teardown()
    {
        _playwrightService?.Cleanup();
    }

    [Test]
    [Category("Live")]
    public async Task TestPlaywrightServiceConnection()
    {
        var workspaceId = TestUtils.GetWorkspaceIdFromDashboardEndpoint(TestEnvironment.DashboardEndpoint);
        var region = TestEnvironment.Region;
        var serviceApiEndpoint = TestUtils.GetPlaywrightServiceAPIEndpoint(workspaceId, region);
        var client = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = false
        });
        var request = new HttpRequestMessage(HttpMethod.Get, serviceApiEndpoint);
        request.Headers.Add("Authorization", $"Bearer {Access_Token}");
        request.RequestUri = new Uri($"{request.RequestUri}?cap={{}}");
        HttpResponseMessage response = await client.SendAsync(request);
        response.Headers.TryGetValues("Location", out System.Collections.Generic.IEnumerable<string>? location);
        Assert.AreEqual(302, (int)response.StatusCode);
        Assert.IsTrue(location!.Any(url => url.Contains("browser.playwright.microsoft.com")));
    }
}
