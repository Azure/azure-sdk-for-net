# Voice Live SDK Test Infrastructure

## Overview

This test infrastructure provides comprehensive support for testing the Azure AI Voice Live SDK. It includes both unit testing capabilities (using mocked WebSockets) and integration testing capabilities (using real service connections).

## Test Categories

- **Unit Tests**: Test logic without real connections (using FakeWebSocket)
- **Integration Tests**: Test with real Voice Live Service (marked with `[Category("Live")]`)
- **Performance Tests**: Measure latency and throughput
- **Stress Tests**: Test under load conditions
- **Long Running Tests**: Test extended conversations

## Setup

### 1. Environment Configuration

Copy `.env.example` to `.env` and configure your settings:

```bash
cp .env.example .env
# Edit .env with your service credentials
```

**Important**: Never commit `.env` to source control. It's already in `.gitignore`.

### 2. Required Environment Variables

For integration tests, you need at minimum:

- `VOICELIVE_ENDPOINT`: Your Voice Live Service endpoint
- `VOICELIVE_API_KEY`: API key (or use Azure AD authentication)

### 3. Test Audio Files

Place test audio files in the `Audio/` directory. The infrastructure expects:

- PCM16 format at 16kHz by default
- Various test scenarios in subdirectories (Basic, Commands, Noise, etc.)

## Writing Tests

### Unit Tests

For unit tests that don't require real connections:

```csharp
[TestFixture]
public class MyUnitTests
{
    [Test]
    public void TestSomething()
    {
        // Use FakeWebSocket and TestableVoiceLiveSession
        var fakeSocket = new FakeWebSocket();
        // ... test logic
    }
}
```

### Integration Tests

For tests that connect to the real service:

```csharp
[TestFixture]
public class MyIntegrationTests : VoiceLiveTestBase
{
    public MyIntegrationTests() : base(isAsync: true) { }

    [Test]
    [Category("Live")]
    public async Task TestRealConnection()
    {
        // CreateSessionAsync handles setup and cleanup
        var session = await CreateSessionAsync();
        
        // Use helper methods
        var response = await SendTextAndWaitForResponseAsync(
            session, "Hello!");
        
        Assert.NotNull(response);
    }
}
```

## Base Classes and Helpers

### VoiceLiveTestBase

Base class for integration tests providing:

- Automatic session cleanup
- Event waiting helpers
- Audio loading utilities
- Voice provider creation
- Feature requirement checking

### VoiceLiveTestEnvironment

Manages all environment variables and configuration:

- Service endpoints and credentials
- Model selection
- Voice configuration
- Feature flags
- Timeouts

### TestAudioHelper

Utilities for working with pre-recorded test audio files:

- Load audio files from test directories
- Get available files by category
- Split audio into chunks for streaming
- Combine audio chunks
- Extract portions of audio data

### VoiceLiveTestHelpers

Common test operations:

- Create session configurations
- Simulate conversation turns
- Validate responses
- Perform function calls
- Log statistics

## Running Tests

### Run All Tests

```bash
dotnet test
```

### Run Only Unit Tests

```bash
dotnet test --filter "Category!=Live"
```

### Run Only Integration Tests

```bash
dotnet test --filter "Category=Live"
```

### Run Specific Test Categories

```bash
# Run audio-specific tests
dotnet test --filter "Category=Audio"

# Run performance tests
dotnet test --filter "Category=Performance"

# Run long-running tests
dotnet test --filter "Category=LongRunning"
```

### Run with Verbose Logging

Set environment variable before running:

```bash
export VOICELIVE_VERBOSE_LOGGING=true
dotnet test
```

## Test Data Organization

The test suite uses pre-recorded WAV audio files organized by category:

```
tests/
├── Audio/
│   ├── Basic/           # Simple test phrases (hello, goodbye, thanks)
│   ├── Commands/        # Command-like inputs (turn on lights, set timer)
│   ├── Formats/         # Different audio formats (PCM16 at various sample rates)
│   ├── Languages/       # Multi-language samples
│   ├── LongForm/        # Extended speech samples
│   ├── Mixed/           # Mixed content samples
│   ├── Noise/           # Noisy environment samples
│   ├── Questions/       # Question inputs (weather, time, calculations)
│   ├── Tones/          # Test tones
│   └── WithIssues/     # Problematic audio (silence, clipped, very quiet/loud)
├── Infrastructure/      # Test infrastructure code
├── .env.example        # Environment template
└── README.md           # This file
```

### Using Test Audio Files

The `TestAudioHelper` class provides utilities for working with the pre-recorded audio files:

```csharp
// Load a specific audio file
var audio = TestAudioHelper.LoadAudioFile("Basic/hello.wav");

// Use predefined paths
var weatherAudio = TestAudioHelper.LoadAudioFile(
    TestAudioHelper.TestFiles.Questions.Weather);

// List all files in a category
var basicFiles = TestAudioHelper.GetAudioFilesInCategory("Basic");

// Split audio into chunks for streaming
var chunks = TestAudioHelper.SplitIntoChunks(audio, 4096);
```

## Common Test Patterns

### Testing Audio Input/Output

```csharp
[Test]
public async Task TestAudioProcessing()
{
    var session = await CreateSessionAsync();
    
    // Load pre-recorded audio file
    var audio = TestAudioHelper.LoadAudioFile("Basic/hello.wav");
    
    // Or use predefined path constants
    var audio2 = TestAudioHelper.LoadAudioFile(
        TestAudioHelper.TestFiles.Questions.Weather);
    
    var response = await SendAudioAndWaitForResponseAsync(
        session, audio);
    
    Assert.NotNull(response);
    Assert.Greater(response.Delta.Length, 0);
}
```

### Testing Function Calls

```csharp
[Test]
public async Task TestFunctionCalling()
{
    var options = VoiceLiveTestHelpers.CreateSessionOptionsWithTools();
    var session = await CreateSessionAsync(options: options);
    
    var result = await VoiceLiveTestHelpers.PerformFunctionCallAsync(
        session, 
        "What's the weather in Seattle?",
        DefaultTimeout);
    
    Assert.IsTrue(result.Success);
    Assert.AreEqual("get_weather", result.FunctionName);
}
```

### Testing Animation Output

```csharp
[Test]
public async Task TestAnimationBlendshapes()
{
    RequireFeature(TestEnvironment.HasAnimationSupport, 
        "Animation not enabled");
    
    var options = VoiceLiveTestHelpers.CreateAnimationSessionOptions();
    var session = await CreateSessionAsync(options: options);
    
    await session.SendTextInputAsync("Smile and wave!");
    
    var blendshapes = await CollectAnimationBlendshapesAsync(
        session, TimeSpan.FromSeconds(5));
    
    Assert.Greater(blendshapes.Count, 0);
}
```

### Testing with Different Voices

```csharp
[Test]
public async Task TestCustomVoice()
{
    RequireFeature(TestEnvironment.HasCustomVoice, 
        "Custom voice not configured");
    
    var voice = CreateVoiceProvider("azure-custom");
    var options = CreateBasicSessionOptions(voice: voice);
    var session = await CreateSessionAsync(options: options);
    
    // Test custom voice...
}
```

## Troubleshooting

### Connection Issues

1. Verify endpoint URL is correct
2. Check API key or Azure AD credentials
3. Ensure network connectivity
4. Check service region

### Test Failures

1. Enable verbose logging: `VOICELIVE_VERBOSE_LOGGING=true`
2. Check test output for detailed error messages
3. Verify audio files exist in expected locations
4. Ensure required features are enabled

### Performance Issues

1. Adjust timeouts if needed
2. Check network latency
3. Use appropriate model for testing
4. Consider test parallelization settings

## Best Practices

1. **Always use base classes**: Inherit from `VoiceLiveTestBase` for proper cleanup
2. **Check features**: Use `RequireFeature()` to skip tests when features aren't available
3. **Handle timeouts**: Use appropriate timeouts for different operations
4. **Clean up resources**: Sessions are automatically cleaned up in TearDown
5. **Use categories**: Mark tests with appropriate categories for filtering
6. **Don't record secrets**: Use `IsSecret()` for sensitive configuration
7. **Test isolation**: Each test should be independent and not rely on others

## Contributing

When adding new test infrastructure:

1. Follow existing patterns and naming conventions
2. Add XML documentation comments
3. Include examples in this README
4. Consider both unit and integration test scenarios
5. Ensure proper error handling and cleanup

## Support

For issues or questions about the test infrastructure:

1. Check this README first
2. Review existing test examples
3. Check environment configuration
4. Enable verbose logging for debugging