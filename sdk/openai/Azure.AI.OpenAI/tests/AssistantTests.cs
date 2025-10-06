// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Utils;
using OpenAI.VectorStores;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests;

public class AssistantTests(bool isAsync) : AoaiTestBase<AssistantClient>(isAsync)
{
#if !AZURE_OPENAI_GA
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<AssistantClient>());

    [Test]
    [Category("Smoke")]
    public void VerifyClientOptionMutability()
    {
        AzureOpenAIClientOptions options = null;
        Assert.DoesNotThrow(() =>
            options = new AzureOpenAIClientOptions()
            {
                UserAgentApplicationId = "init does not throw",
            });
        Assert.DoesNotThrow(() =>
            options.UserAgentApplicationId = "set before freeze OK");
        AzureOpenAIClient azureClient = new(
            new Uri("https://www.microsoft.com/placeholder"),
            new ApiKeyCredential("placeholder"),
            options);
        Assert.Throws<InvalidOperationException>(() =>
            options.UserAgentApplicationId = "set after freeze throws");
    }

    [RecordedTest]
    public async Task BasicAssistantOperationsWork()
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();
        Assistant assistant = await client.CreateAssistantAsync(modelName);
        Validate(assistant);
        Assert.That(assistant.Name, Is.Null.Or.Empty);
        assistant = await client.ModifyAssistantAsync(assistant.Id, new AssistantModificationOptions()
        {
            Name = "test assistant name",
        });
        Assert.That(assistant.Name, Is.EqualTo("test assistant name"));
        AssistantDeletionResult deletionResult = await client.DeleteAssistantAsync(assistant.Id);
        Assert.That(deletionResult.AssistantId, Is.EqualTo(assistant.Id));
        Assert.That(deletionResult.Deleted, Is.True);
        assistant = await client.CreateAssistantAsync(modelName, new AssistantCreationOptions()
        {
            Metadata =
            {
                ["testkey"] = "hello!"
            },
        });
        Validate(assistant);
        Assistant retrievedAssistant = await client.GetAssistantAsync(assistant.Id);
        Assert.That(retrievedAssistant.Id, Is.EqualTo(assistant.Id));
        Assert.That(retrievedAssistant.Metadata.TryGetValue("testkey", out string metadataValue) && metadataValue == "hello!");
        Assistant modifiedAssistant = await client.ModifyAssistantAsync(assistant.Id, new AssistantModificationOptions()
        {
            Metadata =
            {
                ["testkey"] = "goodbye!",
            },
        });
        Assert.That(modifiedAssistant.Id, Is.EqualTo(assistant.Id));
        AsyncCollectionResult<Assistant> recentAssistants = client.GetAssistantsAsync();
        Assistant firstAssistant = await recentAssistants.FirstOrDefaultAsync();
        Assert.That(firstAssistant, Is.Not.Null);
        Assert.That(firstAssistant.Metadata.TryGetValue("testkey", out string newMetadataValue) && newMetadataValue == "goodbye!");
    }

    [RecordedTest]
    public async Task BasicThreadOperationsWork()
    {
        AssistantClient client = GetTestClient();
        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);
        Assert.That(thread.CreatedAt, Is.GreaterThan(s_2024));
        ThreadDeletionResult deletionResult = await client.DeleteThreadAsync(thread.Id);
        Assert.That(deletionResult.ThreadId, Is.EqualTo(thread.Id));
        Assert.That(deletionResult.Deleted, Is.True);

        ThreadCreationOptions options = new()
        {
            Metadata =
            {
                ["threadMetadata"] = "threadMetadataValue",
            }
        };
        thread = await client.CreateThreadAsync(options);
        Validate(thread);
        Assert.That(thread.Metadata.TryGetValue("threadMetadata", out string threadMetadataValue) && threadMetadataValue == "threadMetadataValue");
        AssistantThread retrievedThread = await client.GetThreadAsync(thread.Id);
        Assert.That(retrievedThread.Id, Is.EqualTo(thread.Id));
        thread = await client.ModifyThreadAsync(thread.Id, new ThreadModificationOptions()
        {
            Metadata =
            {
                ["threadMetadata"] = "newThreadMetadataValue",
            },
        });
        Assert.That(thread.Metadata.TryGetValue("threadMetadata", out threadMetadataValue) && threadMetadataValue == "newThreadMetadataValue");
    }

    public enum TestResponseFormatKind
    {
        Default,
        Text,
        JsonObject,
        JsonSchema,
    }

    [RecordedTest]
    [TestCase(TestResponseFormatKind.Default)]
    [TestCase(TestResponseFormatKind.Text)]
    [TestCase(TestResponseFormatKind.JsonObject)]
    //[TestCase(TestResponseFormatKind.JsonSchema)]
    public async Task SettingResponseFormatWorks(TestResponseFormatKind responseFormatKind)
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();

        AssistantResponseFormat selectedResponseFormat = responseFormatKind switch
        {
            TestResponseFormatKind.Text => AssistantResponseFormat.Text,
            TestResponseFormatKind.JsonObject => AssistantResponseFormat.JsonObject,
            TestResponseFormatKind.JsonSchema => AssistantResponseFormat.CreateJsonSchemaFormat(
                name: "food_item_with_ingredients",
                jsonSchema: s_foodSchemaBytes,
                description: "the name of a food item with a list of its ingredients",
                strictSchemaEnabled: true),
            _ => null,
        };

        AssistantCreationOptions assistantOptions = new()
        {
            ResponseFormat = selectedResponseFormat,
        };

        Assistant assistant = await client.CreateAssistantAsync(modelName, assistantOptions);
        Validate(assistant);
        Assert.That(assistant.ResponseFormat, Is.EqualTo(selectedResponseFormat ?? AssistantResponseFormat.Auto));

        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);

        ThreadMessage message = await client.CreateMessageAsync(thread.Id, MessageRole.User, ["Write some JSON for me!"]);
        Validate(message);

        ThreadRun run = await client.CreateRunAsync(thread.Id, assistant.Id);
        Validate(run);

        Assert.That(run.ResponseFormat, Is.EqualTo(selectedResponseFormat ?? AssistantResponseFormat.Auto));
    }

    [RecordedTest]
    public async Task StreamingToolCall()
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();
        FunctionToolDefinition getWeatherTool = new("get_current_weather") { Description = "Gets the user's current weather" };
        Assistant assistant = await client.CreateAssistantAsync(modelName, new()
        {
            Tools = { getWeatherTool }
        });
        Validate(assistant);

        ThreadCreationOptions thirdOpt = new()
        {
            InitialMessages = { new(MessageRole.User, ["What should I wear outside right now?"]), },
        };
        AsyncCollectionResult<StreamingUpdate> asyncResults = client.CreateThreadAndRunStreamingAsync(assistant.Id, thirdOpt);

        ThreadRun run = null;

        do
        {
            run = null;
            List<ToolOutput> toolOutputs = new();
            await foreach (StreamingUpdate update in asyncResults)
            {
                if (update is RunUpdate runUpdate)
                {
                    run = runUpdate.Value;
                }
                if (update is RequiredActionUpdate requiredActionUpdate)
                {
                    Assert.That(requiredActionUpdate.FunctionName, Is.EqualTo(getWeatherTool.FunctionName));
                    Assert.That(requiredActionUpdate.GetThreadRun().Status, Is.EqualTo(RunStatus.RequiresAction));
                    toolOutputs.Add(new(requiredActionUpdate.ToolCallId, "warm and sunny"));
                }
                if (update is MessageContentUpdate contentUpdate)
                {
                }
            }
            if (toolOutputs.Count > 0)
            {
                asyncResults = client.SubmitToolOutputsToRunStreamingAsync(run.ThreadId, run.Id, toolOutputs);
            }
        } while (run?.Status.IsTerminal == false);
    }

    [RecordedTest]
    public async Task BasicMessageOperationsWork()
    {
        // TODO FIXME Can't currently delete messages on AOAI
        bool aoaiDeleteBugFixed = false;

        AssistantClient client = GetTestClient();
        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);
        ThreadMessage message = await client.CreateMessageAsync(thread.Id, MessageRole.User, ["Hello, world!"]);
        Validate(message);
        Assert.That(message.CreatedAt, Is.GreaterThan(s_2024));
        Assert.That(message.Content?.Count, Is.EqualTo(1));
        Assert.That(message.Content[0], Is.Not.Null);
        Assert.That(message.Content[0].Text, Is.EqualTo("Hello, world!"));

        if (aoaiDeleteBugFixed)
        {
            MessageDeletionResult deletionResult = await client.DeleteMessageAsync(message.ThreadId, message.Id);
            Assert.That(deletionResult.MessageId, Is.EqualTo(message.Id));
            Assert.That(deletionResult.Deleted, Is.True);
        }

        message = await client.CreateMessageAsync(thread.Id, MessageRole.User, ["Goodbye, world!"], new MessageCreationOptions()
        {
            Metadata =
            {
                ["messageMetadata"] = "messageMetadataValue",
            },
        });
        Validate(message);
        Assert.That(message.Metadata.TryGetValue("messageMetadata", out string metadataValue) && metadataValue == "messageMetadataValue");

        ThreadMessage retrievedMessage = await client.GetMessageAsync(thread.Id, message.Id);
        Assert.That(retrievedMessage.Id, Is.EqualTo(message.Id));

        message = await client.ModifyMessageAsync(message.ThreadId, message.Id, new MessageModificationOptions()
        {
            Metadata =
            {
                ["messageMetadata"] = "newValue",
            }
        });
        Assert.That(message.Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");

        var messagePage = await client.GetMessagesAsync(thread.Id).ToListAsync();
        if (aoaiDeleteBugFixed)
        {
            Assert.That(messagePage.Count, Is.EqualTo(1));
        }
        else
        {
            Assert.That(messagePage.Count, Is.EqualTo(2));
        }

        Assert.That(messagePage.ElementAt(0).Id, Is.EqualTo(message.Id));
        Assert.That(messagePage.ElementAt(0).Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");
    }

    [RecordedTest]
    public async Task ThreadWithInitialMessagesWorks()
    {
        const string userGreeting = "Hello, world!";
        const string userQuestion = "Can you describe why stop signs are the shape and color that they are?";

        AssistantClient client = GetTestClient();
        ThreadCreationOptions options = new()
        {
            InitialMessages =
            {
                new ThreadInitializationMessage(MessageRole.User, [userGreeting]),
                new ThreadInitializationMessage(MessageRole.User, [ userQuestion ])
                {
                    Metadata =
                    {
                        ["messageMetadata"] = "messageMetadataValue",
                    },
                },
            },
        };
        AssistantThread thread = await client.CreateThreadAsync(options);
        Validate(thread);
        List<ThreadMessage> messageList = await client.GetMessagesAsync(thread.Id, new() { Order = MessageCollectionOrder.Ascending }).ToListAsync();
        Assert.That(messageList.Count, Is.EqualTo(2));
        Assert.That(messageList[0].Role, Is.EqualTo(MessageRole.User));
        Assert.That(messageList[0].Content?.Count, Is.EqualTo(1));
        Assert.That(messageList[0].Content[0].Text, Is.EqualTo(userGreeting));
        Assert.That(messageList[1].Content[0], Is.Not.Null);
        Assert.That(messageList[1].Content[0].Text, Is.EqualTo(userQuestion));
    }

    [RecordedTest]
    public async Task BasicRunOperationsWork()
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();
        Assistant assistant = await client.CreateAssistantAsync(modelName);
        Validate(assistant);
        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);
        List<ThreadRun> runPage = await client.GetRunsAsync(thread.Id).ToListAsync();
        Assert.That(runPage.Count, Is.EqualTo(0));
        ThreadMessage message = await client.CreateMessageAsync(thread.Id, MessageRole.User, ["Hello, assistant!"]);
        Validate(message);
        ThreadRun run = await client.CreateRunAsync(thread.Id, assistant.Id);
        Validate(run);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Queued));
        Assert.That(run.CreatedAt, Is.GreaterThan(s_2024));
        ThreadRun retrievedRun = await client.GetRunAsync(thread.Id, run.Id);
        Assert.That(retrievedRun.Id, Is.EqualTo(run.Id));
        runPage = await client.GetRunsAsync(thread.Id).ToListAsync();
        Assert.That(runPage.Count, Is.EqualTo(1));
        Assert.That(runPage.ElementAt(0).Id, Is.EqualTo(run.Id));

        List<ThreadMessage> messages = await client.GetMessagesAsync(thread.Id).ToListAsync();
        Assert.That(messages.Count, Is.GreaterThanOrEqualTo(1));

        run = await WaitUntilReturnLast(
            run,
            () => client.GetRunAsync(run.ThreadId, run.Id),
            r => r.Status.IsTerminal);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        Assert.Multiple(() =>
        {
            Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
            Assert.That(run.CompletedAt, Is.GreaterThan(s_2024));
            Assert.That(run.RequiredActions, Is.Empty);
            Assert.That(run.AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(run.FailedAt, Is.Null);
            Assert.That(run.IncompleteDetails, Is.Null);
        });
        messages = await client.GetMessagesAsync(thread.Id).ToListAsync();
        Assert.That(messages.Count, Is.EqualTo(2));

        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(1).Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages.ElementAt(1).Id, Is.EqualTo(message.Id));
    }

    [RecordedTest]
    public async Task BasicRunStepFunctionalityWorks()
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();
        Assistant assistant = await client.CreateAssistantAsync(modelName, new AssistantCreationOptions()
        {
            Tools = { new CodeInterpreterToolDefinition() },
            Instructions = "Call the code interpreter tool when asked to visualize mathematical concepts.",
        });
        Validate(assistant);

        AssistantThread thread = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            InitialMessages = { new(MessageRole.User, ["Please graph the equation y = 3x + 4"]), },
        }); 
        Validate(thread);

        ThreadRun run = await client.CreateRunAsync(thread.Id, assistant.Id);
        Validate(run);

        run = await WaitUntilReturnLast(
            run,
            () => client.GetRunAsync(run.ThreadId, run.Id),
            r => r.Status.IsTerminal);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
        Assert.That(run.Usage?.TotalTokenCount, Is.GreaterThan(0));

        List<RunStep> runSteps = await client.GetRunStepsAsync(run.ThreadId, run.Id).ToListAsync();
        Assert.That(runSteps.Count(), Is.GreaterThan(1));
        Assert.Multiple(() =>
        {
            Assert.That(runSteps.ElementAt(0).AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(runSteps.ElementAt(0).ThreadId, Is.EqualTo(thread.Id));
            Assert.That(runSteps.ElementAt(0).RunId, Is.EqualTo(run.Id));
            Assert.That(runSteps.ElementAt(0).CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(runSteps.ElementAt(0).CompletedAt, Is.GreaterThan(s_2024));
        });
        RunStepDetails details = runSteps.ElementAt(0).Details;
        Assert.That(details?.CreatedMessageId, Is.Not.Null.Or.Empty);

        details = runSteps.ElementAt(1).Details;
        Assert.Multiple(() =>
        {
            Assert.That(details?.ToolCalls.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].Kind, Is.EqualTo(RunStepToolCallKind.CodeInterpreter));
            Assert.That(details.ToolCalls[0].Id, Is.Not.Null.Or.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterInput, Is.Not.Null.Or.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs?.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs[0].ImageFileId, Is.Not.Null.Or.Empty);
        });
    }

    public enum TestStrictSchemaMode
    {
        Default,
        UseStrictToolParameterSchema,
        DoNotUseStrictToolParameterSchema
    }

    [RecordedTest]
    [TestCase(TestStrictSchemaMode.Default)]
    //[TestCase(TestStrictSchemaMode.UseStrictToolParameterSchema)]
    //[TestCase(TestStrictSchemaMode.DoNotUseStrictToolParameterSchema)]
    public async Task FunctionToolsWork(TestStrictSchemaMode schemaMode)
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();

        s_getFoodForDayOfWeekTool.StrictParameterSchemaEnabled = schemaMode switch
        {
            TestStrictSchemaMode.UseStrictToolParameterSchema => true,
            TestStrictSchemaMode.DoNotUseStrictToolParameterSchema => false,
            _ => null,
        };
        AssistantCreationOptions options = new()
        {
            Tools = { s_getFoodForDayOfWeekTool }
        };

        Assistant assistant = await client.CreateAssistantAsync(modelName, options);
        Validate(assistant);
        Assert.That(assistant.Tools?.Count, Is.EqualTo(1));

        FunctionToolDefinition responseToolDefinition = assistant.Tools[0] as FunctionToolDefinition;
        Assert.That(responseToolDefinition?.FunctionName, Is.EqualTo(s_getFoodForDayOfWeekTool.FunctionName));
        Assert.That(responseToolDefinition?.Parameters, Is.Not.Null);

        ThreadRun run = await client.CreateThreadAndRunAsync(
            assistant.Id,
            new ThreadCreationOptions()
            {
                InitialMessages = { new(MessageRole.User, ["What should I eat on Thursday?"]) },
            },
            new RunCreationOptions()
            {
                AdditionalInstructions = "Call provided tools when appropriate.",
            });
        Validate(run);

        // TODO FIXME: The underlying OpenAI code doesn't consider the "requires_action" status to be terminal even though it is.
        //             Work around this here
        run = await WaitUntilReturnLast(
            run,
            () => client.GetRunAsync(run.ThreadId, run.Id),
            r => r.Status.IsTerminal || r.Status.Equals(RunStatus.RequiresAction));

        Assert.That(run.Status, Is.EqualTo(RunStatus.RequiresAction));
        Assert.That(run.RequiredActions?.Count, Is.EqualTo(1));
        Assert.That(run.RequiredActions[0].ToolCallId, Is.Not.Null.Or.Empty);
        Assert.That(run.RequiredActions[0].FunctionName, Is.EqualTo("get_favorite_food_for_day_of_week"));
        Assert.That(run.RequiredActions[0].FunctionArguments, Is.Not.Null.Or.Empty);

        run = await client.SubmitToolOutputsToRunAsync(run.ThreadId, run.Id, [new(run.RequiredActions[0].ToolCallId, "tacos")]);
        Assert.That(run.Status.IsTerminal, Is.False);

        run = await WaitUntilReturnLast(
            run,
            () => client.GetRunAsync(run.ThreadId, run.Id),
            r => r.Status.IsTerminal);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        List<ThreadMessage> messages = await client.GetMessagesAsync(run.ThreadId, new() { Order = MessageCollectionOrder.Descending })
            .ToListAsync();
        Assert.That(messages.Count, Is.GreaterThan(1));
        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(0).Content?[0], Is.Not.Null);
        Assert.That(messages.ElementAt(0).Content?[0].Text, Does.Contain("tacos"));
    }

    [RecordedTest]
    public async Task BasicFileSearchWorks()
    {
        // First, we need to upload a simple test file.
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(client);

        OpenAIFile testFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("""
                This file describes the favorite foods of several people.

                Summanus Ferdinand: tacos
                Tekakwitha Effie: pizza
                Filip Carola: cake
                """),
            "favorite_foods.txt",
            FileUploadPurpose.Assistants);
        Validate(testFile);

        // Create an assistant, using the creation helper to make a new vector store
        Assistant assistant = await client.CreateAssistantAsync(modelName, new()
        {
            Tools = { new FileSearchToolDefinition() },
            ToolResources = new()
            {
                FileSearch = new()
                {
                    NewVectorStores =
                    {
                        new VectorStoreCreationHelper([testFile]),
                    }
                }
            }
        });
        Validate(assistant);
        Assert.That(assistant.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        string createdVectorStoreId = assistant.ToolResources.FileSearch.VectorStoreIds[0];
        ValidateById<VectorStore>(createdVectorStoreId);

        // Modify an assistant to use the existing vector store
        assistant = await client.ModifyAssistantAsync(assistant.Id, new AssistantModificationOptions()
        {
            ToolResources = new()
            {
                FileSearch = new()
                {
                    VectorStoreIds = { assistant.ToolResources.FileSearch.VectorStoreIds[0] },
                },
            },
        });
        Assert.That(assistant.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        Assert.That(assistant.ToolResources.FileSearch.VectorStoreIds[0], Is.EqualTo(createdVectorStoreId));

        // Create a thread with an override vector store
        AssistantThread thread = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            InitialMessages = { new(MessageRole.User, ["Using the files you have available, what's Filip's favorite food?"]) },
            ToolResources = new()
            {
                FileSearch = new()
                {
                    NewVectorStores =
                    {
                        new VectorStoreCreationHelper([testFile.Id])
                    }
                }
            }
        });
        Validate(thread);
        Assert.That(thread.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        createdVectorStoreId = thread.ToolResources.FileSearch.VectorStoreIds[0];
        ValidateById<VectorStore>(createdVectorStoreId);

        // Ensure that modifying the thread with an existing vector store works
        thread = await client.ModifyThreadAsync(thread.Id, new ThreadModificationOptions()
        {
            ToolResources = new()
            {
                FileSearch = new()
                {
                    VectorStoreIds = { createdVectorStoreId },
                }
            }
        });
        Assert.That(thread.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        Assert.That(thread.ToolResources.FileSearch.VectorStoreIds[0], Is.EqualTo(createdVectorStoreId));

        ThreadRun run = await client.CreateRunAsync(thread.Id, assistant.Id);
        Validate(run);
        run = await WaitUntilReturnLast(
            run,
            () => client.GetRunAsync(run.ThreadId, run.Id),
            r => r.Status.IsTerminal);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        AsyncCollectionResult<ThreadMessage> messages = client.GetMessagesAsync(thread.Id, new() { Order = MessageCollectionOrder.Descending });
        int numThreads = 0;
        bool hasCake = false;
        await foreach (ThreadMessage message in messages)
        {
            numThreads++;
            foreach (MessageContent content in message.Content)
            {
                hasCake |= content.Text?.ToLowerInvariant().Contains("cake") == true;
                foreach (TextAnnotation annotation in content.TextAnnotations)
                {
                    Assert.That(annotation.InputFileId, Is.Not.Null.And.Not.Empty);
                    Assert.That(annotation.TextToReplace, Is.Not.Null.And.Not.Empty);
                }
            }
        }

        Assert.That(numThreads, Is.GreaterThan(0));
        Assert.That(hasCake, Is.True);
    }

    [RecordedTest]
    public async Task StreamingRunWorks()
    {
        AssistantClient client = GetTestClient();
        string modelName = client.DeploymentOrThrow();
        Assistant assistant = await client.CreateAssistantAsync(modelName);
        Validate(assistant);

        AssistantThread thread = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            InitialMessages = { new(MessageRole.User, ["Hello there, assistant! How are you today?"]), },
        });
        Validate(thread);

        AsyncCollectionResult<StreamingUpdate> streamingResult = client.CreateRunStreamingAsync(thread.Id, assistant.Id);

        StringBuilder content = new();
        DateTimeOffset? lastUpdate = null;
        StreamingUpdateReason? lastUpdateReason = null;

        await foreach (StreamingUpdate update in streamingResult)
        {
            if (update is RunUpdate runUpdate)
            {
                lastUpdateReason = runUpdate.UpdateKind;
                lastUpdate = update.UpdateKind switch
                {
                    StreamingUpdateReason.RunCreated => runUpdate.Value.CreatedAt,
                    StreamingUpdateReason.RunQueued => runUpdate.Value.StartedAt,
                    StreamingUpdateReason.RunInProgress => runUpdate.Value.StartedAt,
                    StreamingUpdateReason.RunCompleted => runUpdate.Value.CompletedAt,
                    _ => null,
                };
            }
            if (update is MessageContentUpdate contentUpdate)
            {
                // TODO FIXME: The OpenAI library code is currently incorrectly returning a MessageRole.User value here.
                //             It should instead be null or at least Assistant
                //Assert.That(contentUpdate.Role, Is.Null.Or.EqualTo(MessageRole.Assistant));
                Assert.That(contentUpdate.Text, Is.Not.Null); // can be empty string
                content.Append(contentUpdate.Text);
            }
        }

        Assert.That(lastUpdateReason, Is.EqualTo(StreamingUpdateReason.RunCompleted));
        Assert.That(lastUpdate, Is.Not.Null.And.GreaterThan(s_2024));
        Assert.That(content, Has.Length.GreaterThan(0));
    }

    private static readonly DateTimeOffset s_2024 = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
    private static FunctionToolDefinition s_getFoodForDayOfWeekTool = new("get_favorite_food_for_day_of_week")
    {
        Description = "gets the user's favorite food for a given day of the week, like Tuesday",
        Parameters = BinaryData.FromObjectAsJson(new
        {
            type = "object",
            properties = new
            {
                day_of_week = new
                {
                    type = "string",
                    description = "a day of the week, like Tuesday or Saturday",
                }
            }
        }),
    };
    private static readonly BinaryData s_foodSchemaBytes = BinaryData.FromString("""
        {
          "type": "object",
          "properties": {
            "name": {
              "type": "string",
              "description": "a descriptive name for the food"
            },
            "ingredients": {
              "type": "array",
              "items": {
                "type": "string"
              },
              "description": "recipe ingredients for the food"
            }
          },
          "additionalProperties": false
        }
        """);

#else
    [Test]
    [SyncOnly]
    public void VersionUnsupportedAssistantClientThrows()
    {
        Assert.Throws<InvalidOperationException>(() => GetTestClient());
    }
#endif
}
