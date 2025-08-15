# Azure VoiceLive Test Data Generator

This standalone console application generates test audio files and other collateral needed for VoiceLive SDK integration tests.

## Features

- **Speech Generation**: Uses Azure Cognitive Services Speech SDK to generate speech samples
- **Tone Generation**: Creates pure tones, silence, and noise samples without external dependencies
- **Format Conversion**: Converts audio to different sample rates and formats (PCM16, G.711)
- **Multi-language Support**: Generates speech in multiple languages
- **Configurable**: JSON-based configuration for phrases and settings

## Prerequisites

1. Azure Cognitive Services Speech resource
2. .NET 8.0 or later

## Configuration

### Option 1: appsettings.json
Edit `appsettings.json` with your Azure Speech credentials:

```json
{
  "AzureSpeech": {
    "SubscriptionKey": "your-subscription-key",
    "Region": "eastus"
  }
}
```

### Option 2: Environment Variables
Set environment variables (prefixed with `VOICELIVE_TEST_`):

```bash
export VOICELIVE_TEST_AzureSpeech__SubscriptionKey="your-key"
export VOICELIVE_TEST_AzureSpeech__Region="eastus"
```

### Option 3: User Secrets (Development)
```bash
dotnet user-secrets set "AzureSpeech:SubscriptionKey" "your-key"
dotnet user-secrets set "AzureSpeech:Region" "eastus"
```

## Usage

### Generate All Test Data
```bash
dotnet run -- --output ./TestAudio
```

### Generate Specific Categories
```bash
# Speech only
dotnet run -- --category Speech --output ./TestAudio

# Tones and noise only  
dotnet run -- --category "Tones,Noise" --output ./TestAudio
```

### Dry Run (Preview)
```bash
dotnet run -- --dry-run --verbose
```

### Command Line Options

- `--output, -o`: Output directory (default: ./TestAudio)
- `--category, -cat`: Categories to generate (Speech, Tones, Noise, Formats, Mixed, All)
- `--config, -c`: Configuration file path (default: appsettings.json)
- `--verbose, -v`: Enable verbose logging
- `--dry-run, -d`: Preview what would be generated

## Generated File Structure

```
TestAudio/
├── Basic/                          # Basic speech samples
│   ├── hello.wav
│   ├── hello_how_are_you.wav
│   └── ...
├── Questions/                      # Question utterances
│   ├── whats_weather_seattle.wav
│   └── ...
├── Commands/                       # Command phrases
│   ├── set_timer.wav
│   └── ...
├── Languages/                      # Multi-language samples
│   ├── hello_multilang_en_US.wav
│   ├── hello_multilang_es_ES.wav
│   └── ...
├── Tones/                         # Generated tones and silence
│   ├── tone_A4_1s.wav
│   ├── silence_2s.wav
│   └── ...
├── Noise/                         # Noise samples
│   ├── white_noise_0.1_3s.wav
│   ├── pink_noise_3s.wav
│   └── ...
├── Formats/                       # Different audio formats
│   ├── hello_pcm16_8000hz.wav
│   ├── hello_g711_ulaw.wav
│   └── ...
└── metadata.json                  # Generation metadata
```

## Customizing Test Phrases

Edit `test-phrases.json` to add or modify test phrases:

```json
{
  "categories": {
    "Basic": [
      {
        "id": "custom_phrase",
        "text": "Your custom phrase here",
        "description": "Description of the phrase",
        "expectedDuration": "1.5s"
      }
    ]
  }
}
```

## Integration with Tests

The generated audio files are designed to be used by the VoiceLive SDK integration tests:

```csharp
// In your test class
protected byte[] LoadTestAudio(string filename)
{
    var path = Path.Combine(TestEnvironment.TestAudioPath, filename);
    return File.ReadAllBytes(path);
}

// Usage
var audio = LoadTestAudio("Basic/hello.wav");
await session.SendInputAudioAsync(audio);
```

## Troubleshooting

### Speech Generation Fails
- Verify Azure Speech credentials are correct
- Check network connectivity
- Ensure Speech resource has sufficient quota

### Missing Files
- Run with `--verbose` to see detailed generation logs
- Check file permissions in output directory
- Verify configuration file exists and is valid

### Audio Quality Issues
- Generated speech uses 24kHz 16-bit PCM by default
- Tone generation uses mathematical sine waves
- Noise samples use pseudo-random generation

## Development

To extend the generator:

1. Implement `ITestDataGenerator` interface
2. Add new generator to the `generators` array in `Program.cs`
3. Update `TestDataCategory` enum if needed
4. Add configuration options to `appsettings.json`

Example:
```csharp
public class CustomGenerator : ITestDataGenerator
{
    public TestDataCategory Category => TestDataCategory.Custom;
    
    public async Task GenerateAsync(string outputPath, TestPhrases phrases)
    {
        // Your generation logic here
    }
}
```