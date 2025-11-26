# Unit Testing with Microsoft.ClientModel.TestFramework

This sample demonstrates how to use the Test Framework's mock utilities and testing helpers to write comprehensive unit tests for your client libraries.

## Overview

Unit tests with the Test Framework allow you to:
- Test client behavior without making actual HTTP requests
- Simulate various service responses and error conditions
- Validate client-side logic and error handling
- Test authentication and pipeline behavior

## Key Mock Components

The Test Framework provides several mock implementations for unit testing:

- `MockCredential` - Mock authentication token provider
- `MockPipelineTransport` - Mock HTTP transport
- `MockPipelineResponse` - Mock HTTP responses
- `MockPipelineRequest` - Mock HTTP requests

## Basic Unit Test Setup

```C# Snippet:BasicUnitTestSetup
[TestFixture]
public class MapsClientUnitTests
{
    [Test]
    public void CanCreateClientWithMockCredential()
    {
        // Create a mock credential
        var mockCredential = new MockCredential("test-subscription-key", DateTimeOffset.UtcNow.AddHours(1));

        // Create client with mock credential
        var client = new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            mockCredential);

        Assert.That(client, Is.Not.Null);
    }

    [Test]
    public async Task MockCredentialProvidesToken()
    {
        var expectedToken = "mock-subscription-key";
        var expiresOn = DateTimeOffset.UtcNow.AddHours(1);

        var mockCredential = new MockCredential(expectedToken, expiresOn);

        // Test token retrieval
        var tokenResult = await mockCredential.GetTokenAsync(
            new GetTokenOptions(new Dictionary<string, object>
            {
                { GetTokenOptions.ScopesPropertyName, new string[] { "https://atlas.microsoft.com/.default" } }
            }),
            CancellationToken.None);

        Assert.That(expectedToken, Is.EqualTo(tokenResult.TokenValue));
        Assert.That(expiresOn, Is.EqualTo(tokenResult.ExpiresOn));
    }
}
```

## Mock Transport Testing

Use `MockPipelineTransport` to simulate HTTP responses:

```C# Snippet:MockTransportBasics
[TestFixture]
public class MockTransportTests
{
    [Test]
    public async Task MockTransportReturnsConfiguredResponse()
    {
        // Create a mock transport that returns a 200 response
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"countryRegion":{"isoCode":"US"},"ipAddress":"8.8.8.8"}""")));

        var options = new MapsClientOptions();
        options.Transport = mockTransport;

        var client = new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new MockCredential(),
            options);

        var ipAddress = System.Net.IPAddress.Parse("8.8.8.8");
        var result = await client.GetCountryCodeAsync(ipAddress);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.CountryRegion.IsoCode, Is.EqualTo("US"));
    }

    [Test]
    public void MockTransportCanSimulateErrors()
    {
        // Create a mock transport that returns an error response
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(401, "Unauthorized")
                .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Invalid subscription key"}""")));

        var options = new MapsClientOptions();
        options.Transport = mockTransport;

        var client = new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new MockCredential(),
            options);

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetCountryCodeAsync("8.8.8.8"));

        Assert.That(exception.Status, Is.EqualTo(401));
    }
}
```

## Advanced Mock Scenarios

### Multiple Response Simulation

```C# Snippet:MultipleResponseSimulation
[TestFixture]
public class MultipleResponseTests
{
    [Test]
    public async Task MockTransportHandlesMultipleRequests()
    {
        // Configure multiple responses for sequential requests
        var requestCount = 0;
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                // First request - Create operation
                return new MockPipelineResponse(201)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"new-resource","status":"created"}"""));
            }
            else
            {
                // Second request - Get operation
                return new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"new-resource","status":"active"}"""));
            }
        });

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        // First call - process data
        var inputData = new SampleData { Id = "new-data", Value = 42, Success = false };
        var processResult = await client.ProcessDataAsync(inputData);
        Assert.That(processResult.Value.Success, Is.True);

        // Second call - analyze data
        var analyzeResult = await client.AnalyzeDataAsync("new-data");
        Assert.That(analyzeResult.Value, Is.Not.Null);

        // Verify both requests were made
        Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
    }
}
```

### Retry Logic Testing

The Test Framework is excellent for testing retry scenarios and error handling:

```C# Snippet:RetryLogicTesting
[TestFixture]
public class RetryLogicTests
{
    [Test]
    public async Task ClientRetriesOnTransientFailure()
    {
        var requestCount = 0;
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                // First request fails with transient error
                return new MockPipelineResponse(503, "Service Unavailable");
            }
            else
            {
                // Second request succeeds
                return new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"success","retry":true}"""));
            }
        });

        var options = new SampleClientOptions();
        options.Transport = mockTransport;
        // System.ClientModel.ClientPipelineOptions doesn't have Retry configuration

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        var result = await client.GetDataAsync("test");

        // Verify the request succeeded after retry
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.Id, Is.EqualTo("success"));
        // Verify two requests were made (original + 1 retry)
        Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
    }

    [Test]
    public void ClientRespectsMaxRetries()
    {
        // Create transport that always fails
        var mockTransport = new MockPipelineTransport(message =>
            new MockPipelineResponse(503, "Service Unavailable"));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;
        // System.ClientModel.ClientPipelineOptions doesn't have Retry configuration

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetDataAsync("test"));

        Assert.That(exception.Status, Is.EqualTo(503));

        // Verify correct number of attempts (1 original + 2 retries = 3 total)
        Assert.That(mockTransport.Requests.Count, Is.EqualTo(3));
    }
}
```

### Custom Response Factory

```C# Snippet:CustomResponseFactory
[TestFixture]
public class CustomResponseFactoryTests
{
    [Test]
    public async Task CustomResponseBasedOnRequest()
    {
        // Create mock transport with custom response logic
        var mockTransport = new MockPipelineTransport((message) =>
        {
            var request = message.Request;

            // Return different responses based on request URI
            if (request.Uri?.ToString()?.Contains("users") == true)
            {
                return new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"users":[{"id":"1","name":"Test User"}]}"""));
            }
            else if (request.Uri?.ToString()?.Contains("settings") == true)
            {
                return new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"theme":"dark","language":"en"}"""));
            }

            return new MockPipelineResponse(404);
        });

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        var usersResult = await client.GetUsersAsync();
        Assert.That(usersResult.Value.Users, Is.Not.Null);
        Assert.That(usersResult.Value.Users.Count, Is.EqualTo(1));

        var settingsResult = await client.GetSettingsAsync();
        Assert.That(settingsResult.Value.Theme, Is.EqualTo("dark"));
    }
}
```

## Request Validation

Validate that your client sends correct requests:

```C# Snippet:RequestValidation
[TestFixture]
public class RequestValidationTests
{
    [Test]
    public async Task ValidateRequestHeaders()
    {
        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential("test-token", DateTimeOffset.UtcNow.AddHours(1)),
            options);

        await client.GetDataAsync("test-id");

        // Validate request was made correctly
        Assert.That(1, Is.EqualTo(mockTransport.Requests.Count));

        var request = mockTransport.Requests[0];
        Assert.That("GET", Is.EqualTo(request.Method));
        Assert.That(request.Uri?.ToString().Contains("test-id"), Is.True);

        // Validate authentication header was added
                    Assert.That(request.Headers.Any(h => h.Key == "Authorization"), Is.True);
    }

    [Test]
    public async Task ValidateRequestBody()
    {
        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(201));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        var inputData = new SampleData { Id = "test-data", Value = 42, Success = false };
        await client.ProcessDataAsync(inputData);

        var request = mockTransport.Requests[0];
        Assert.That("POST", Is.EqualTo(request.Method));

        // Validate request body
        var bodyContent = request.Content?.ToString();
        Assert.That(bodyContent, Is.Not.Null);
        Assert.That(bodyContent.Contains("test-data"), Is.True);
        Assert.That(bodyContent.Contains("42"), Is.True);
        Assert.That(bodyContent.Contains("false"), Is.True);
    }
}
```

## Error Scenario Testing

Test various error conditions and client responses:

```C# Snippet:ErrorScenarioTesting
[TestFixture]
public class ErrorScenarioTests
{
    [Test]
    public void ClientHandles401Unauthorized()
    {
        var mockTransport = new MockPipelineTransport(message =>
            new MockPipelineResponse(401, "Unauthorized")
                .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Invalid credentials"}""")));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential("invalid-token", DateTimeOffset.UtcNow.AddHours(1)),
            options);

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetSecureDataAsync());

        Assert.That(exception.Status, Is.EqualTo(401));
        Assert.That(exception.Message.Contains("Invalid credentials"), Is.True);
    }

    [Test]
    public void ClientHandlesNetworkTimeout()
    {
        var mockTransport = new MockPipelineTransport(message =>
        {
            throw new TaskCanceledException("Request timed out");
        });

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        TaskCanceledException exception = Assert.ThrowsAsync<TaskCanceledException>(
            async () => await client.GetDataAsync("test"));

        Assert.That(exception.Message.Contains("timed out"), Is.True);
    }

    [Test]
    public void ClientHandlesServerError()
    {
        var mockTransport = new MockPipelineTransport(message =>
            new MockPipelineResponse(500, "Internal Server Error")
                .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Server error occurred"}""")));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetDataAsync("test"));

        Assert.That(500, Is.EqualTo(exception.Status));
    }
}
```

## Retry Logic Testing

Test client retry behavior with mock transport:

```C# Snippet:RetryLogicTesting
[TestFixture]
public class RetryLogicTests
{
    [Test]
    public async Task ClientRetriesOnTransientFailure()
    {
        var requestCount = 0;
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                // First request fails with transient error
                return new MockPipelineResponse(503, "Service Unavailable");
            }
            else
            {
                // Second request succeeds
                return new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"success","retry":true}"""));
            }
        });

        var options = new SampleClientOptions();
        options.Transport = mockTransport;
        // System.ClientModel.ClientPipelineOptions doesn't have Retry configuration

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        var result = await client.GetDataAsync("test");

        // Verify the request succeeded after retry
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.Id, Is.EqualTo("success"));
        // Verify two requests were made (original + 1 retry)
        Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
    }

    [Test]
    public void ClientRespectsMaxRetries()
    {
        // Create transport that always fails
        var mockTransport = new MockPipelineTransport(message =>
            new MockPipelineResponse(503, "Service Unavailable"));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;
        // System.ClientModel.ClientPipelineOptions doesn't have Retry configuration

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetDataAsync("test"));

        Assert.That(exception.Status, Is.EqualTo(503));

        // Verify correct number of attempts (1 original + 2 retries = 3 total)
        Assert.That(mockTransport.Requests.Count, Is.EqualTo(3));
    }
}
```

## Authentication Testing

Test authentication scenarios with mock credentials:

```C# Snippet:AuthenticationTesting
[TestFixture]
public class AuthenticationTests
{
    [Test]
    public async Task MockCredentialUsedForAuthentication()
    {
        var mockCredential = new MockCredential("my-test-token", DateTimeOffset.UtcNow.AddHours(1));
        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            mockCredential,
            options);

        await client.GetDataAsync("test");

        // Verify authentication header was added with mock token
        var request = mockTransport.Requests[0];
        var authHeader = request.Headers.FirstOrDefault(h => h.Key == "Authorization");

        Assert.That(authHeader, Is.Not.Null);
        Assert.That(authHeader.Value?.Contains("Bearer my-test-token") == true);
    }

    [Test]
    public async Task CustomCredentialBehavior()
    {
        var customToken = "custom-bearer-token";
        var mockCredential = new MockCredential(customToken, DateTimeOffset.UtcNow.AddMinutes(30));

        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            mockCredential,
            options);

        await client.GetDataAsync("test");

        var request = mockTransport.Requests[0];
        var authHeader = request.Headers.FirstOrDefault(h => h.Key == "Authorization");

        Assert.That($"Bearer {customToken}", Is.EqualTo(authHeader.Value));
    }
}
```

## Pipeline Policy Testing

Test custom pipeline policies with mock transport:

```C# Snippet:PipelinePolicyTesting
[TestFixture]
public class PipelinePolicyTests
{
    [Test]
    public async Task CustomPolicyAddsHeaders()
    {
        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        // Add custom policy that adds a header
        options.AddPolicy(new CustomHeaderPolicy("x-custom-header", "test-value"), PipelinePosition.PerCall);

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        await client.GetDataAsync("test");

        var request = mockTransport.Requests[0];
        var customHeader = request.Headers.FirstOrDefault(h => h.Key == "x-custom-header");

        Assert.That(customHeader, Is.Not.Null);
        Assert.That(customHeader.Value, Is.EqualTo("test-value"));
    }

    // Custom policy for testing
    private class CustomHeaderPolicy : PipelinePolicy
    {
        private readonly string _headerName;
        private readonly string _headerValue;

        public CustomHeaderPolicy(string headerName, string headerValue)
        {
            _headerName = headerName;
            _headerValue = headerValue;
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(_headerName, _headerValue);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(_headerName, _headerValue);
            await ProcessNextAsync(message, pipeline, currentIndex);
        }
    }
}
```

## Model Serialization Testing

Test model serialization and deserialization:

```C# Snippet:ModelSerializationTesting
[TestFixture]
public class ModelSerializationTests
{
    [Test]
    public async Task ModelSerializationWorks()
    {
        var originalData = new SampleData
        {
            Id = "test-id",
            Value = 42,
            Success = false
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithContent(System.Text.Encoding.UTF8.GetBytes(
                    """{"id":"test-id","value":42,"success":true}""")));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        var result = await client.ProcessDataAsync(originalData);

        // Validate request body contains serialized model
        var request = mockTransport.Requests[0];
        var requestBody = request.Content?.ToString();
        Assert.That(requestBody?.Contains("test-id"), Is.True);
        Assert.That(requestBody?.Contains("42"), Is.True);
        Assert.That(requestBody?.Contains("false"), Is.True);

        // Validate response deserialization
        Assert.That(result.Value.Id, Is.EqualTo("test-id"));
        Assert.That(result.Value.Value, Is.EqualTo(42));
        Assert.That(result.Value.Success, Is.True);
    }
}
```

## Combining with Sync/Async Testing

Unit tests can also leverage sync/async testing capabilities:

```C# Snippet:UnitTestSyncAsync
[ClientTestFixture]
public class UnitTestSyncAsync : ClientTestBase
{
    public UnitTestSyncAsync(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task MockTransportWorksBothSyncAndAsync()
    {
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"test","success":true}""")));

        var options = new SampleClientOptions();
        options.Transport = mockTransport;

        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options));

        var result = await client.GetDataAsync("test");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.Success, Is.True);

        // This test runs for both sync and async modes
        TestContext.WriteLine($"Running in {(IsAsync ? "Async" : "Sync")} mode");
    }
}
```

## Best Practices

### 1. Test Organization

```C# Snippet:UnitTestBestPractices
[TestFixture]
public class WellOrganizedUnitTests
{
    private MockCredential _mockCredential;
    private SampleClientOptions _clientOptions;

    [SetUp]
    public void Setup()
    {
        _mockCredential = new MockCredential("test-token", DateTimeOffset.UtcNow.AddHours(1));
        _clientOptions = new SampleClientOptions();
    }

    [Test]
    public async Task TestSuccessScenario()
    {
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"success":true}""")));

        _clientOptions.Transport = mockTransport;
        var client = new SampleClient(new Uri("https://example.com"), _mockCredential, _clientOptions);

        var result = await client.GetDataAsync("test");
        Assert.That(result.Value.Success);
    }

    [Test]
    public void TestErrorScenario()
    {
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(400, "Bad Request"));

        _clientOptions.Transport = mockTransport;
        var client = new SampleClient(new Uri("https://example.com"), _mockCredential, _clientOptions);

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetDataAsync("invalid"));

        Assert.That(400, Is.EqualTo(exception.Status));
    }
}
```

### 2. Comprehensive Coverage

```C# Snippet:ComprehensiveCoverage
[TestFixture]
public class ComprehensiveUnitTests
{
    [Test]
    public async Task TestAllDataOperations()
    {
        var responses = new[]
        {
            // Process data
            new MockPipelineResponse(200).WithContent("""{"id":"test-data","value":42,"success":true}"""),
            // Analyze data
            new MockPipelineResponse(200).WithContent("""{"dataId":"test-data","analysisResult":"complete","score":85.5}"""),
            // Get processed data
            new MockPipelineResponse(200).WithContent("""{"id":"test-data","value":42,"success":true}""")
        };
        var responseIndex = 0;

        var mockTransport = new MockPipelineTransport(_ => responses[responseIndex++]);

        var options = new SampleClientOptions { Transport = mockTransport };
        var client = new SampleClient(
            new Uri("https://example.com"),
            new MockCredential(),
            options);

        // Test all data operations
        var inputData = new SampleData { Id = "test-data", Value = 42, Success = false };
        var processed = await client.ProcessDataAsync(inputData);
        Assert.That(processed.Value.Success, Is.True);

        var analyzed = await client.AnalyzeDataAsync("test-data");
        Assert.That(analyzed.Value, Is.Not.Null);

        var retrieved = await client.GetDataAsync("test-data");
        Assert.That(retrieved.Value.Success, Is.True);

        // Verify all requests were made
        Assert.That(3, Is.EqualTo(mockTransport.Requests.Count));
    }
}
```