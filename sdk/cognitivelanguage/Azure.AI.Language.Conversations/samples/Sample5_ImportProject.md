# Import a project

This sample demonstrates how to import a project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To import a project, you'll need to first create a `ConversationAnalysisProjectsClient` using an endpoint and an API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisProjectsClient_Create
Uri endpoint = new Uri("https://myaccount.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisProjectsClient client = new ConversationAnalysisProjectsClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods. Typically, the content would come from a file but a small sample is shown here for demonstration purposes.

## Synchronous

```C# Snippet:ConversationAnalysisProjectsClient_ImportProject
string projectName = "Menu";

// Define our project assets and import.
var importData = new
{
    projectFileVersion = "2022-05-01",
    metadata = new {
        projectName,
        projectKind = "Conversation",
        multilingual = true,
        language = "en",
    },

    assets = new
    {
        projectKind = "Conversation",
        entities = new[] // ConversationalAnalysisAuthoringConversationExportedEntity
        {
            new
            {
                category = "Contact",
                compositionSetting = "combineComponents",
                prebuilts = new[]
                {
                    new
                    {
                        category = "Person.Name",
                    },
                },

                // ... more entities.
            }
        },

        intents = new[] // ConversationalAnalysisAuthoringConversationExportedIntent
        {
            new
            {
                category = "Send",
            },

            // ... more intents.
        },

        utterances = new[] // ConversationalAnalysisAuthoringConversationExportedUtterance
        {
            new
            {
                text = "Send an email to Johnson",
                language = "en",
                intent = "Send",
                entities = new[]
                {
                    new
                    {
                        category = "Contact",
                        offset = 17,
                        length = 7,
                    },
                },
            },
            new
            {
                text = "Send Kathy a calendar invite",
                language = "en",
                intent = "Send",
                entities = new[]
                {
                    new
                    {
                        category = "Contact",
                        offset = 5,
                        length = 5,
                    },
                },
            },

            // ... more utterances.
        },
    },

    // Use Utf16CodeUnit for strings in .NET.
    stringIndexType = "Utf16CodeUnit",
};

Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Started, projectName, RequestContent.Create(importData));
importOperation.WaitForCompletion();

// Train the model.
var trainData = new
{
    modelLabel = "Sample5",
    trainingMode = "standard",
};

Operation<BinaryData> trainOperation = client.Train(WaitUntil.Started, projectName, RequestContent.Create(trainData));
trainOperation.WaitForCompletion();

// Deploy the model.
var deployData = new
{
    trainedModelLabel = "Sample5",
};

Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Started, projectName, "production", RequestContent.Create(deployData));
deployOperation.WaitForCompletion();
```

# Asynchronous

```C# Snippet:ConversationAnalysisProjectsClient_ImportProjectAsync
string projectName = "Menu";

// Define our project assets and import.
var importData = new
{
    projectFileVersion = "2022-05-01",
    metadata = new
    {
        projectName,
        projectKind = "Conversation",
        multilingual = true,
        language = "en",
    },

    assets = new
    {
        projectKind = "Conversation",
        entities = new[] // ConversationalAnalysisAuthoringConversationExportedEntity
        {
            new
            {
                category = "Contact",
                compositionSetting = "combineComponents",
                prebuilts = new[]
                {
                    new
                    {
                        category = "Person.Name",
                    },
                },

                // ... more entities.
            }
        },

        intents = new[] // ConversationalAnalysisAuthoringConversationExportedIntent
        {
            new
            {
                category = "Send",
            },

            // ... more intents.
        },

        utterances = new[] // ConversationalAnalysisAuthoringConversationExportedUtterance
        {
            new
            {
                text = "Send an email to Johnson",
                language = "en",
                intent = "Send",
                entities = new[]
                {
                    new
                    {
                        category = "Contact",
                        offset = 17,
                        length = 7,
                    },
                },
            },
            new
            {
                text = "Send Kathy a calendar invite",
                language = "en",
                intent = "Send",
                entities = new[]
                {
                    new
                    {
                        category = "Contact",
                        offset = 5,
                        length = 5,
                    },
                },
            },

            // ... more utterances.
        },
    },

    // Use Utf16CodeUnit for strings in .NET.
    stringIndexType = "Utf16CodeUnit",
};

Operation<BinaryData> importOperation = await client.ImportProjectAsync(WaitUntil.Started, projectName, RequestContent.Create(importData));
await importOperation.WaitForCompletionAsync();

// Train the model.
var trainData = new
{
    modelLabel = "Sample5",
    trainingMode = "standard",
};

Operation<BinaryData> trainOperation = await client.TrainAsync(WaitUntil.Started, projectName, RequestContent.Create(trainData));
await trainOperation.WaitForCompletionAsync();

// Deploy the model.
var deployData = new
{
    trainedModelLabel = "Sample5",
};

Operation<BinaryData> deployOperation = await client.DeployProjectAsync(WaitUntil.Started, projectName, "production", RequestContent.Create(deployData));
await deployOperation.WaitForCompletionAsync();
```
