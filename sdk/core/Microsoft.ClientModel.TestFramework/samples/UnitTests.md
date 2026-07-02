# Unit Testing with Microsoft.ClientModel.TestFramework

This sample demonstrates how to use the test framework's mock utilities and testing helpers to write comprehensive unit tests for your client libraries.

## Key Mock Components

The test framework provides several mock implementations for unit testing:

- `MockCredential` - Mock authentication token provider
- `MockPipelineTransport` - Mock HTTP transport
- `MockPipelineResponse` - Mock HTTP responses
- `MockPipelineRequest` - Mock HTTP requests

## Mock Transport Testing

Use `MockPipelineTransport` to simulate HTTP responses:

```C# Snippet:MockTransportBasics
// Create a mock transport that returns a 200 response
MockPipelineTransport mockTransport = new(_ =>
    new MockPipelineResponse(200)
        .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"countryRegion":{"isoCode":"US"},"ipAddress":"8.8.8.8"}""")));

MapsClientOptions options = new()
{
    Transport = mockTransport
};
```

```C# Snippet:ErrorScenarioTesting
// Create a mock transport that returns an error response
MockPipelineTransport mockTransport = new(_ =>
    new MockPipelineResponse(401, "Unauthorized")
        .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Invalid subscription key"}""")));

MapsClientOptions options = new()
{
    Transport = mockTransport
};

// Timeout
mockTransport = new MockPipelineTransport(message =>
{
    throw new TaskCanceledException("Request timed out");
});

// Server error
mockTransport = new MockPipelineTransport(message =>
    new MockPipelineResponse(500, "Internal Server Error")
        .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Server error occurred"}""")));
```

## Request Validation

Validate that your client sends correct requests:

```C# Snippet:RequestValidation
var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200));
mockTransport.ExpectSyncPipeline = !IsAsync;

var options = new MapsClientOptions();
options.Transport = mockTransport;

// Call client methods
MapsClient client = CreateProxyFromClient(new MapsClient(
    new Uri("https://example.com"),
    new ApiKeyCredential("fake-key"),
    options));

var result = await client.GetCountryCodeAsync("test");

var request = mockTransport.Requests[0];
```


## Combining with Sync/Async Testing

Unit tests can also leverage sync/async testing capabilities:

```C# Snippet:UnitTestSyncAsync
MockPipelineTransport mockTransport = new(_ =>
    new MockPipelineResponse(200)
        .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"test","success":true}""")));
mockTransport.ExpectSyncPipeline = !IsAsync;

MapsClientOptions options = new();
options.Transport = mockTransport;

MapsClient client = CreateProxyFromClient(new MapsClient(
    new Uri("https://example.com"),
    new ApiKeyCredential("fake-key"),
    options));

var result = await client.GetCountryCodeAsync("test");
```