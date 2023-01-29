# Analyze a conversation with Conversation Summarization

This sample demonstrates how to do topic segmentation task only with Conversation Summarization API. To get started, you'll need to create a Cognitive Language service endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

## Import Nuget Packages
```
  <ItemGroup>
    <PackageReference Include="Azure.AI.Language.Conversations" Version="1.1.0-beta.2" />
    <PackageReference Include="Azure.Identity" Version="1.8.1" />
  </ItemGroup>
```

## Sample Code

Notes
1. The code above uses `DefaultAzureCredential` which is recommended. If you prefer APIKEY, use `AzureKeyCredential` instead. See example:
```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```
2. Use `labFeatures` to disable chapter title generation, which can speed up the API call significantly. The summary text is populated as a GUID as placeholder instead.
3. The `utteranceLevelAudioTiming` is helpful to make the topic segmentaion more accurate.