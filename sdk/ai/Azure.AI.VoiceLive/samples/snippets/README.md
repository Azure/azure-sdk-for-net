# Azure.AI.VoiceLive Snippets

This directory contains code snippets used in the main README.md file and documentation. These snippets demonstrate the key functionality of the Azure.AI.VoiceLive client library.

## Snippets Organization

- **AuthenticationSnippets.cs**: Demonstrates different ways to authenticate with the VoiceLive service
- **BasicUsageSnippets.cs**: Shows basic usage patterns including voice assistants, custom voices, and function calling

## Building the Snippets

The snippets project references the main Azure.AI.VoiceLive project and can be built to verify that the code examples are syntactically correct:

```bash
dotnet build Azure.AI.VoiceLive.Snippets.csproj
```

## Usage in Documentation

The snippets use the `#region Snippet:Name` and `#endregion` syntax to allow them to be extracted and included in documentation and the README.md file.

Example:
```csharp
#region Snippet:CreateVoiceLiveClientWithApiKey
Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
#endregion
```

These snippets are then referenced in the README using the syntax:
```markdown
```C# Snippet:CreateVoiceLiveClientWithApiKey
Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
```