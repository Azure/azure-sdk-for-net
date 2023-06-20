# Import a project

This sample demonstrates how to import a project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

Start by importing the namespace for the `ConversationAuthoringClient` and related classes:

```C# Snippet:ConversationAuthoringClient_Namespaces
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring;
```

To import a project, you'll need to first create a `ConversationAuthoringClient` using an endpoint and an API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAuthoringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAuthoringClient client = new ConversationAuthoringClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods. Typically, the content would come from a file but a small sample is shown here for demonstration purposes.

## Synchronous

```C# Snippet:ConversationAuthoringClient_ImportProject
string projectName = "Menu";

// Define our project assets and import. In practice this would most often be read from a file.
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

Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Completed, projectName, RequestContent.Create(importData));

// Train the model.
var trainData = new
{
    modelLabel = "Sample5",
    trainingMode = "standard",
};

Console.WriteLine($"Training project {projectName}...");
Operation<BinaryData> trainOperation = client.Train(WaitUntil.Completed, projectName, RequestContent.Create(trainData));

// Deploy the model.
var deployData = new
{
    trainedModelLabel = "Sample5",
};

Console.WriteLine($"Deploying project {projectName} to production...");
Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Completed, projectName, "production", RequestContent.Create(deployData));

Console.WriteLine("Import complete");
```

## Asynchronous

Using the same `importData` definition above, you can make an asynchronous request by calling `ImportProjectAsync`:

```C# Snippet:ConversationAuthoringClient_ImportProjectAsync
Operation<BinaryData> importOperation = await client.ImportProjectAsync(WaitUntil.Completed, projectName, RequestContent.Create(importData));

// Train the model.
var trainData = new
{
    modelLabel = "Sample5",
    trainingMode = "standard",
};

Console.WriteLine($"Training project {projectName}...");
Operation<BinaryData> trainOperation = await client.TrainAsync(WaitUntil.Completed, projectName, RequestContent.Create(trainData));

// Deploy the model.
var deployData = new
{
    trainedModelLabel = "Sample5",
};

Console.WriteLine($"Deploying project {projectName} to production...");
Operation<BinaryData> deployOperation = await client.DeployProjectAsync(WaitUntil.Completed, projectName, "production", RequestContent.Create(deployData));

Console.WriteLine("Import complete");
```
