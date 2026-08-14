# Migrate from Azure.AI.OpenAI to the OpenAI SDK (dotnet)

Moving from `Azure.AI.OpenAI` to `OpenAI` gives you one SDK surface for OpenAI-compatible scenarios, faster access to new features, and simpler long-term maintenance.

This guide is focused on .NET only and uses constructor-and-variable style examples (no dependency injection setup).

## Why migrate now

- One primary SDK (`OpenAI`) for new development.
- Cleaner endpoint model with OpenAI v1 routes.
- Fewer SDK-specific migration hops over time.
- Easier portability between hosted environments.

## 1. Update package references

Remove the `Azure.AI.OpenAI` package reference from your project file and add `OpenAI` directly.

```xml
<ItemGroup>
  <PackageReference Include="OpenAI" Version="<OpenAI SDK version>" />
</ItemGroup>
```

If you use Microsoft Entra ID authentication, also add:

```xml
<ItemGroup>
  <PackageReference Include="Azure.Identity" Version="<Azure.Identity version>" />
</ItemGroup>
```

Or with the CLI:

```bash
dotnet remove package Azure.AI.OpenAI
dotnet add package OpenAI --version <OpenAI SDK version>
dotnet add package Azure.Identity --version <Azure.Identity version>
```

## 2. Understand the key differences

| Area | Azure.AI.OpenAI | OpenAI SDK |
| ---- | ---- | ---- |
| Primary entry point | `AzureOpenAIClient` then scenario client | Scenario clients directly (for example `ChatClient`) |
| Endpoint format | Resource endpoint and Azure-specific routing `https://<resource>.cognitiveservices.azure.com/?api-version=version` | `https://<resource>.openai.azure.com/openai/v1/` |
| Model/deployment | Often passed when creating sub-client | Required as `model` (your deployment name) |
| Authentication | `ApiKeyCredential` or Entra via Azure client | `ApiKeyCredential` or auth policy with Entra |

## 3. Migrate client creation

### Before (Azure.AI.OpenAI)

```csharp
using Azure;
using Azure.AI.OpenAI;

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_ENDPOINT");
string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_API_KEY");
string deployment = Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_DEPLOYMENT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_CHAT_DEPLOYMENT");

AzureOpenAIClient azureClient = new(new Uri(endpoint), new ApiKeyCredential(apiKey));
ChatClient chatClient = azureClient.GetChatClient(deployment);
```

### After (OpenAI SDK, API key)

```csharp
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_ENDPOINT");
string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_API_KEY");
string deployment = Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_DEPLOYMENT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_CHAT_DEPLOYMENT");

OpenAIClientOptions options = new()
{
 Endpoint = new Uri(endpoint)
};

ChatClient chatClient = new(
 model: deployment,
 credential: new ApiKeyCredential(apiKey),
 options: options);
```

### After (OpenAI SDK, Entra ID)

```csharp
using Azure.Identity;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel.Primitives;

#pragma warning disable OPENAI001
BearerTokenPolicy tokenPolicy = new(
 new DefaultAzureCredential(),
 "https://ai.azure.com/.default");
#pragma warning restore OPENAI001

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_ENDPOINT");
string deployment = Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_DEPLOYMENT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_CHAT_DEPLOYMENT");

OpenAIClientOptions options = new()
{
 Endpoint = new Uri(endpoint)
};

ChatClient chatClient = new(
 model: deployment,
 authenticationPolicy: tokenPolicy,
 options: options);
```

## 4. Update common calls

### Chat completions

```csharp
using OpenAI.Chat;

ChatCompletion completion = chatClient.CompleteChat(
 new SystemChatMessage("You are a concise assistant."),
 new UserChatMessage("Summarize this migration in one sentence."));

Console.WriteLine(completion.Content[0].Text);
```

### Streaming

```csharp
using System.ClientModel;
using OpenAI.Chat;

CollectionResult<StreamingChatCompletionUpdate> updates = chatClient.CompleteChatStreaming(
 new UserChatMessage("Write a short onboarding message for our migration."));

foreach (StreamingChatCompletionUpdate update in updates)
{
 foreach (ChatMessageContentPart part in update.ContentUpdate)
 {
  Console.Write(part.Text);
 }
}
```

## 5. Migration checklist

- Remove `Azure.AI.OpenAI` package references.
- Add `OpenAI` package reference.
- Add `Azure.Identity` if using Entra ID.
- Change endpoint handling to use `/openai/v1/`.
- Ensure each scenario client is created with a deployment name as `model`.
- Re-test chat, streaming, embeddings, and audio scenarios.
- Update docs and internal runbooks to refer to the OpenAI SDK.

## Known issues

### Audio transcription routing on v1 endpoints

In some setups, audio transcription calls may not route correctly when using the standard v1 endpoint path.

One practical workaround is:

1. Create dedicated `OpenAIClientOptions` for audio calls.
2. Point audio calls to the cognitiveservices-style deployment route.
3. Inject an API version query string with a custom `ApiVersionPipelinePolicy`.

```csharp
using OpenAI;
using OpenAI.Audio;
using System;
using System.ClientModel.Primitives;

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_ENDPOINT");
string audioDeployment = Environment.GetEnvironmentVariable("AZURE_OPENAI_AUDIO_DEPLOYMENT")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_AUDIO_DEPLOYMENT");
string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")
 ?? throw new InvalidOperationException("Missing AZURE_OPENAI_API_KEY");

Uri baseEndpointUri = new(endpoint);
UriBuilder audioEndpointBuilder = new(baseEndpointUri)
{
 Host = baseEndpointUri.Host.Replace(
  ".openai.azure.com",
  ".cognitiveservices.azure.com",
  StringComparison.OrdinalIgnoreCase),
 Path = $"openai/deployments/{audioDeployment}/",
 Query = string.Empty
};
Uri audioEndpoint = audioEndpointBuilder.Uri;

OpenAIClientOptions audioOptions = new()
{
 Endpoint = audioEndpoint
};

audioOptions.AddPolicy(new ApiVersionPipelinePolicy("2025-03-01-preview"), PipelinePosition.BeforeTransport);

AudioClient audioClient = new(
 model: audioDeployment,
 credential: new ApiKeyCredential(apiKey),
 options: audioOptions);
```

Example policy implementation:

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ClientModel.Primitives;

internal sealed class ApiVersionPipelinePolicy : PipelinePolicy
{
 private readonly string _version;

 public ApiVersionPipelinePolicy(string version = "2025-03-01-preview")
 {
  ArgumentException.ThrowIfNullOrEmpty(version);
  _version = version;
 }

 public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
 {
  message.Request.Uri = new(message.Request.Uri, $"?api-version={_version}");
  ProcessNext(message, pipeline, currentIndex);
 }

 public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
 {
  message.Request.Uri = new(message.Request.Uri, $"?api-version={_version}");
  await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
 }
}
```

If your audio scenarios are already stable on standard v1 routing, prefer the simpler default configuration and avoid custom policy injection.

## Final note

Do not leave both SDKs referenced unless you are intentionally running a short, staged migration. For most apps, the cleanest path is a direct move to `OpenAI` and removal of `Azure.AI.OpenAI`.
