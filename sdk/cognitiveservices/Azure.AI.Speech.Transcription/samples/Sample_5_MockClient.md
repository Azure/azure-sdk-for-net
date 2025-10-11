# Mock Client for Testing

This sample demonstrates how to mock the `TranscriptionClient` for unit testing without making actual API calls to Azure.

## Why Mock the Client?

Mocking the `TranscriptionClient` is useful for:
- Unit testing application logic without network calls
- Testing error handling scenarios
- Running tests in CI/CD pipelines without Azure credentials
- Faster test execution

## Create a Mock Client

The `TranscriptionClient` provides a protected constructor for creating mock instances.

```C# Snippet:CreateMockTranscriptionClient
// TranscriptionClient provides a protected constructor for mocking
// You can create a derived class for testing purposes

// Example: Create a test-specific derived class
var mockClient = new MockTranscriptionClient();

// Use the mock client in your tests
// It won't make actual API calls
```

## Mock Transcription Behavior

Configure the mock client to return predefined results for testing.

```C# Snippet:MockTranscriptionBehavior
// Create a mock client that returns predefined results
var mockClient = new MockTranscriptionClient();

// Configure the mock to return a specific result
var expectedText = "This is a mock transcription result";
mockClient.SetMockResult(expectedText);

// Create a test request
using var audioStream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02 });
TranscribeRequestContent request = new TranscribeRequestContent
{
    Audio = audioStream
};

// Call the mock client
Response<TranscriptionResult> response = await mockClient.TranscribeAsync(request);

// Verify the result
Assert.IsNotNull(response);
Assert.IsNotNull(response.Value);

// The mock client returns the configured result
var phrases = response.Value.PhrasesByChannel.FirstOrDefault();
if (phrases != null)
{
    Console.WriteLine($"Mock transcription: {phrases.Text}");
}
```

## Use InMemoryTransport for Testing

Use Azure SDK's `MockTransport` to test without network calls.

```C# Snippet:UseInMemoryTransport
// Create a mock response that the client will return
var mockResponseContent = @"{
    ""durationMilliseconds"": 5000,
    ""combinedPhrases"": [
        {
            ""channel"": 0,
            ""text"": ""This is a test transcription""
        }
    ],
    ""phrases"": [
        {
            ""channel"": 0,
            ""offsetMilliseconds"": 0,
            ""durationMilliseconds"": 5000,
            ""text"": ""This is a test transcription"",
            ""words"": [],
            ""locale"": ""en-US"",
            ""confidence"": 0.95
        }
    ]
}";

// Create options with a mock transport
var mockTransport = new MockTransport(new MockResponse(200)
{
    ContentStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(mockResponseContent))
});

TranscriptionClientOptions options = new TranscriptionClientOptions();
options.Transport = mockTransport;

// Create client with mock transport
Uri endpoint = new Uri("https://mock.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new AzureKeyCredential("mock-key");
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

// Make a request - it will use the mock response
using var audioStream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02 });
TranscribeRequestContent request = new TranscribeRequestContent
{
    Audio = audioStream
};

Response<TranscriptionResult> response = await client.TranscribeAsync(request);

// Verify the mock response was returned
Console.WriteLine($"Duration: {response.Value.Duration}");
var phrases = response.Value.PhrasesByChannel.First();
Console.WriteLine($"Transcription: {phrases.Text}");
```

## Mock Error Scenarios

Test error handling by mocking error responses.

```C# Snippet:MockErrorScenarios
// Create a mock transport that returns an error
var mockTransport = new MockTransport(new MockResponse(401)
{
    ContentStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(
        @"{""error"": {""code"": ""Unauthorized"", ""message"": ""Invalid API key""}}"
    ))
});

TranscriptionClientOptions options = new TranscriptionClientOptions();
options.Transport = mockTransport;

Uri endpoint = new Uri("https://mock.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new AzureKeyCredential("invalid-key");
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

// Test error handling
try
{
    using var audioStream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02 });
    TranscribeRequestContent request = new TranscribeRequestContent
    {
        Audio = audioStream
    };

    await client.TranscribeAsync(request);
    Assert.Fail("Expected RequestFailedException was not thrown");
}
catch (RequestFailedException ex)
{
    // Verify error handling works correctly
    Assert.AreEqual(401, ex.Status);
    Console.WriteLine($"Successfully caught error: {ex.Message}");
}
```

## Example: Testing Application Logic

Here's a complete example of testing application code that uses `TranscriptionClient`:

```csharp
// Your application code
public class TranscriptionService
{
    private readonly TranscriptionClient _client;

    public TranscriptionService(TranscriptionClient client)
    {
        _client = client;
    }

    public async Task<string> GetTranscriptionAsync(Stream audioStream)
    {
        var request = new TranscribeRequestContent { Audio = audioStream };
        var response = await _client.TranscribeAsync(request);
        return response.Value.PhrasesByChannel.First().Text;
    }
}

// Your test code
[Test]
public async Task TestTranscriptionService()
{
    // Arrange: Create mock client
    var mockClient = new MockTranscriptionClient();
    mockClient.SetMockResult("Test transcription");

    var service = new TranscriptionService(mockClient);

    // Act: Call your service
    using var audioStream = new MemoryStream(new byte[] { 0x00 });
    string result = await service.GetTranscriptionAsync(audioStream);

    // Assert: Verify the result
    Assert.AreEqual("Test transcription", result);
}
```

## Best Practices

- Use mocks for unit tests; use real client for integration tests
- Test both success and error scenarios
- Verify your application handles all possible response states
- Use dependency injection to make your code testable
- Keep mock data realistic to catch serialization issues
