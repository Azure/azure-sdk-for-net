// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.VectorStores;

namespace Azure.AI.OpenAI.Tests;

public class AssistantTests(bool isAsync) : AoaiTestBase<AssistantClient>(isAsync)
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<AssistantClient>());

    [RecordedTest]
    public async Task BasicAssistantOperationsWork()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        Assistant assistant = await client.CreateAssistantAsync(modelName);
        Validate(assistant);
        Assert.That(assistant.Name, Is.Null.Or.Empty);
        assistant = await client.ModifyAssistantAsync(assistant.Id, new AssistantModificationOptions()
        {
            Name = "test assistant name",
        });
        Assert.That(assistant.Name, Is.EqualTo("test assistant name"));
        bool deleted = await client.DeleteAssistantAsync(assistant.Id);
        Assert.That(deleted, Is.True);
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
        AsyncPageableCollection<Assistant> recentAssistants = SyncOrAsync(
            client, c => c.GetAssistants(), c => c.GetAssistantsAsync());
        Assistant recentAssistant = null;
        await foreach (Assistant asyncAssistant in recentAssistants)
        {
            recentAssistant = asyncAssistant;
            break;
        }
        Assert.That(recentAssistant, Is.Not.Null);
        Assert.That(recentAssistant.Metadata.TryGetValue("testkey", out string newMetadataValue) && newMetadataValue == "goodbye!");
    }

    [RecordedTest]
    public async Task BasicThreadOperationsWork()
    {
        AssistantClient client = GetTestClient();
        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);
        Assert.That(thread.CreatedAt, Is.GreaterThan(s_2024));
        bool deleted = await client.DeleteThreadAsync(thread.Id);
        Assert.That(deleted, Is.True);

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
        thread = await client.ModifyThreadAsync(thread, new ThreadModificationOptions()
        {
            Metadata =
            {
                ["threadMetadata"] = "newThreadMetadataValue",
            },
        });
        Assert.That(thread.Metadata.TryGetValue("threadMetadata", out threadMetadataValue) && threadMetadataValue == "newThreadMetadataValue");
    }

    [RecordedTest]
    public async Task SettingResponseFormatWorks()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();

        Assistant assistant = await client.CreateAssistantAsync(modelName, new()
        {
            ResponseFormat = AssistantResponseFormat.JsonObject,
        });
        Validate(assistant);
        Assert.That(assistant.ResponseFormat, Is.EqualTo(AssistantResponseFormat.JsonObject));
        assistant = await client.ModifyAssistantAsync(assistant, new()
        {
            ResponseFormat = AssistantResponseFormat.Text,
        });
        Assert.That(assistant.ResponseFormat, Is.EqualTo(AssistantResponseFormat.Text));
        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);
        ThreadMessage message = await client.CreateMessageAsync(thread, ["Write some JSON for me!"]);
        Validate(message);
        ThreadRun run = await client.CreateRunAsync(thread, assistant, new()
        {
            ResponseFormat = AssistantResponseFormat.JsonObject,
        });
        Validate(run);
        Assert.That(run.ResponseFormat, Is.EqualTo(AssistantResponseFormat.JsonObject));
    }

    [RecordedTest]
    public async Task StreamingToolCall()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        FunctionToolDefinition getWeatherTool = new("get_current_weather", "Gets the user's current weather");
        Assistant assistant = await client.CreateAssistantAsync(modelName, new()
        {
            Tools = { getWeatherTool }
        });
        Validate(assistant);

        Stopwatch stopwatch = Stopwatch.StartNew();
        void Print(string message) => Console.WriteLine($"[{stopwatch.ElapsedMilliseconds,6}] {message}");

        Print(" >>> Beginning call ... ");

        ThreadCreationOptions thrdOpt = new()
        {
            InitialMessages = { new(["What should I wear outside right now?"]), },
        };
        AsyncResultCollection<StreamingUpdate> asyncResults = SyncOrAsync(client,
            c => c.CreateThreadAndRunStreaming(assistant, thrdOpt),
            c => c.CreateThreadAndRunStreamingAsync(assistant, thrdOpt));

        Print(" >>> Starting enumeration ...");

        ThreadRun run = null;

        do
        {
            run = null;
            List<ToolOutput> toolOutputs = new();
            await foreach (StreamingUpdate update in asyncResults)
            {
                string message = update.UpdateKind.ToString();

                if (update is RunUpdate runUpdate)
                {
                    message += $" run_id:{runUpdate.Value.Id}";
                    run = runUpdate.Value;
                }
                if (update is RequiredActionUpdate requiredActionUpdate)
                {
                    Assert.That(requiredActionUpdate.FunctionName, Is.EqualTo(getWeatherTool.FunctionName));
                    Assert.That(requiredActionUpdate.GetThreadRun().Status, Is.EqualTo(RunStatus.RequiresAction));
                    message += $" {requiredActionUpdate.FunctionName}";
                    toolOutputs.Add(new(requiredActionUpdate.ToolCallId, "warm and sunny"));
                }
                if (update is MessageContentUpdate contentUpdate)
                {
                    message += $" {contentUpdate.Text}";
                }
                Print(message);
            }
            if (toolOutputs.Count > 0)
            {
                asyncResults = SyncOrAsync(client,
                    c => c.SubmitToolOutputsToRunStreaming(run, toolOutputs),
                    c => c.SubmitToolOutputsToRunStreamingAsync(run, toolOutputs));
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
        ThreadMessage message = await client.CreateMessageAsync(thread, ["Hello, world!"]);
        Validate(message);
        Assert.That(message.CreatedAt, Is.GreaterThan(s_2024));
        Assert.That(message.Content?.Count, Is.EqualTo(1));
        Assert.That(message.Content[0], Is.Not.Null);
        Assert.That(message.Content[0].Text, Is.EqualTo("Hello, world!"));

        if (aoaiDeleteBugFixed)
        {
            bool deleted = await client.DeleteMessageAsync(message);
            Assert.That(deleted, Is.True);
        }

        message = await client.CreateMessageAsync(thread, ["Goodbye, world!"], new MessageCreationOptions()
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

        message = await client.ModifyMessageAsync(message, new MessageModificationOptions()
        {
            Metadata =
            {
                ["messageMetadata"] = "newValue",
            }
        });
        Assert.That(message.Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");

        var messagePage = await SyncOrAsyncList(client,
            c => c.GetMessages(thread),
            c => c.GetMessagesAsync(thread));
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
        AssistantClient client = GetTestClient();
        ThreadCreationOptions options = new()
        {
            InitialMessages =
            {
                new(["Hello, world!"]),
                new(
                [
                    "Can you describe this image for me?",
                    MessageContent.FromImageUrl(new Uri("https://test.openai.com/image.png"))
                ])
                {
                    Metadata =
                    {
                        ["messageMetadata"] = "messageMetadataValue",
                    },
                },
            },
        };
        AssistantThread thread = await client.CreateThreadAsync (options);
        Validate(thread);
        List<ThreadMessage> messageList = await SyncOrAsyncList(client,
            c => c.GetMessages(thread, resultOrder: ListOrder.OldestFirst),
            c => c.GetMessagesAsync(thread, resultOrder: ListOrder.OldestFirst));
        Assert.That(messageList.Count, Is.EqualTo(2));
        Assert.That(messageList[0].Role, Is.EqualTo(MessageRole.User));
        Assert.That(messageList[0].Content?.Count, Is.EqualTo(1));
        Assert.That(messageList[0].Content[0].Text, Is.EqualTo("Hello, world!"));
        Assert.That(messageList[1].Content?.Count, Is.EqualTo(2));
        Assert.That(messageList[1].Content[0], Is.Not.Null);
        Assert.That(messageList[1].Content[0].Text, Is.EqualTo("Can you describe this image for me?"));
        Assert.That(messageList[1].Content[1], Is.Not.Null);
        Assert.That(messageList[1].Content[1].ImageUrl.AbsoluteUri, Is.EqualTo("https://test.openai.com/image.png"));
    }

    [RecordedTest]
    public async Task BasicRunOperationsWork()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        Assistant assistant = await client.CreateAssistantAsync(modelName);
        Validate(assistant);
        AssistantThread thread = await client.CreateThreadAsync();
        Validate(thread);
        List<ThreadRun> runPage = await SyncOrAsyncList(client,
            c => c.GetRuns(thread.Id),
            c => c.GetRunsAsync(thread.Id));
        Assert.That(runPage.Count, Is.EqualTo(0));
        ThreadMessage message = await client.CreateMessageAsync(thread.Id, ["Hello, assistant!"]);
        Validate(message);
        Thread.Sleep(3000);
        ThreadRun run = await client.CreateRunAsync(thread.Id, assistant.Id);
        Validate(run);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Queued));
        Assert.That(run.CreatedAt, Is.GreaterThan(s_2024));
        ThreadRun retrievedRun = await client.GetRunAsync(thread.Id, run.Id);
        Assert.That(retrievedRun.Id, Is.EqualTo(run.Id));
        runPage = await SyncOrAsyncList(client,
            c => c.GetRuns(thread.Id),
            c => c.GetRunsAsync(thread.Id));
        Assert.That(runPage.Count, Is.EqualTo(1));
        Assert.That(runPage.ElementAt(0).Id, Is.EqualTo(run.Id));

        List<ThreadMessage> messages = await SyncOrAsyncList(client,
            c => c.GetMessages(thread),
            c => c.GetMessagesAsync(thread));
        Assert.That(messages.Count, Is.GreaterThanOrEqualTo(1));

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            await Task.Delay(1000);
            run = await client.GetRunAsync(run);
        }
        Assert.Multiple(() =>
        {
            Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
            Assert.That(run.CompletedAt, Is.GreaterThan(s_2024));
            Assert.That(run.RequiredActions, Is.Empty);
            Assert.That(run.AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(run.FailedAt, Is.Null);
            Assert.That(run.IncompleteDetails, Is.Null);
        });
        messages = await SyncOrAsyncList(client,
            c => c.GetMessages(thread),
            c => c.GetMessagesAsync(thread));
        Assert.That(messages.Count, Is.EqualTo(2));

        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(1).Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages.ElementAt(1).Id, Is.EqualTo(message.Id));
    }

    [RecordedTest]
    public async Task BasicRunStepFunctionalityWorks()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        Assistant assistant = await client.CreateAssistantAsync(modelName, new AssistantCreationOptions()
        {
            Tools = { new CodeInterpreterToolDefinition() },
            Instructions = "Call the code interpreter tool when asked to visualize mathematical concepts.",
        });
        Validate(assistant);

        AssistantThread thread = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            InitialMessages = { new(["Please graph the equation y = 3x + 4"]), },
        });
        Validate(thread);

        ThreadRun run = await client.CreateRunAsync(thread, assistant);
        Validate(run);

        while (!run.Status.IsTerminal)
        {
            await Task.Delay(1000);
            run = await client.GetRunAsync(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
        Assert.That(run.Usage?.TotalTokens, Is.GreaterThan(0));

        List<RunStep> runSteps = await SyncOrAsyncList(client,
            c => c.GetRunSteps(run),
            c => c.GetRunStepsAsync(run));
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
            Assert.That(details.ToolCalls[0].ToolKind, Is.EqualTo(RunStepToolCallKind.CodeInterpreter));
            Assert.That(details.ToolCalls[0].ToolCallId, Is.Not.Null.Or.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterInput, Is.Not.Null.Or.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs?.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs[0].ImageFileId, Is.Not.Null.Or.Empty);
        });
    }

    [RecordedTest]
    public async Task FunctionToolsWork()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        Assistant assistant = await client.CreateAssistantAsync(modelName, new AssistantCreationOptions()
        {
            Tools =
            {
                new FunctionToolDefinition()
                {
                    FunctionName = "get_favorite_food_for_day_of_week",
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
                },
            },
        });
        Validate(assistant);
        Assert.That(assistant.Tools?.Count, Is.EqualTo(1));

        FunctionToolDefinition responseToolDefinition = assistant.Tools[0] as FunctionToolDefinition;
        Assert.That(responseToolDefinition?.FunctionName, Is.EqualTo("get_favorite_food_for_day_of_week"));
        Assert.That(responseToolDefinition?.Parameters, Is.Not.Null);

        ThreadRun run = await client.CreateThreadAndRunAsync(
            assistant,
            new ThreadCreationOptions()
            {
                InitialMessages = { new(["What should I eat on Thursday?"]) },
            },
            new RunCreationOptions()
            {
                AdditionalInstructions = "Call provided tools when appropriate.",
            });
        Validate(run);
        Console.WriteLine($" Run status right after creation: {run.Status}");

        // TODO FIXME: The underlying OpenAI code doesn't consider the "requires_action" status to be terminal even though it is
        //             work around this here
        for (int i = 0; i < 10 && !run.Status.IsTerminal && !run.Status.Equals("requires_action"); i++)
        {
            Thread.Sleep(500);
            run = await client.GetRunAsync(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.RequiresAction));
        Assert.That(run.RequiredActions?.Count, Is.EqualTo(1));
        Assert.That(run.RequiredActions[0].ToolCallId, Is.Not.Null.Or.Empty);
        Assert.That(run.RequiredActions[0].FunctionName, Is.EqualTo("get_favorite_food_for_day_of_week"));
        Assert.That(run.RequiredActions[0].FunctionArguments, Is.Not.Null.Or.Empty);

        run = await client.SubmitToolOutputsToRunAsync(run, [new(run.RequiredActions[0].ToolCallId, "tacos")]);
        Assert.That(run.Status.IsTerminal, Is.False);

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = await client.GetRunAsync(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        List<ThreadMessage> messages = await SyncOrAsyncList(client,
            c => c.GetMessages(run.ThreadId, resultOrder: ListOrder.NewestFirst),
            c => c.GetMessagesAsync(run.ThreadId, resultOrder: ListOrder.NewestFirst));
        Assert.That(messages.Count, Is.GreaterThan(1));
        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(0).Content?[0], Is.Not.Null);
        Assert.That(messages.ElementAt(0).Content?[0].Text, Does.Contain("tacos"));
    }

    [RecordedTest]
    public async Task BasicFileSearchWorks()
    {
        // First, we need to upload a simple test file.
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        FileClient fileClient = GetChildTestClient<FileClient>(client);

        OpenAIFileInfo testFile = await fileClient.UploadFileAsync(
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
        assistant = await client.ModifyAssistantAsync(assistant, new AssistantModificationOptions()
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
            InitialMessages = { new(["Using the files you have available, what's Filip's favorite food?"]) },
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
        thread = await client.ModifyThreadAsync(thread, new ThreadModificationOptions()
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

        ThreadRun run = await client.CreateRunAsync(thread, assistant);
        Validate(run);
        do
        {
            await Task.Delay(1000);
            run = await client.GetRunAsync(run);
        } while (run?.Status.IsTerminal == false);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        AsyncPageableCollection<ThreadMessage> messages = SyncOrAsync(client,
            c => c.GetMessages(thread, resultOrder: ListOrder.NewestFirst),
            c => c.GetMessagesAsync(thread, resultOrder: ListOrder.NewestFirst));
        bool hasAtLeastOne = false;
        bool hasCake = false;
        await foreach (ThreadMessage message in messages)
        {
            hasAtLeastOne = true;
            foreach (MessageContent content in message.Content)
            {
                Console.WriteLine(content.Text);
                hasCake |= content.Text?.ToLowerInvariant().Contains("cake") == true;
                foreach (TextAnnotation annotation in content.TextAnnotations)
                {
                    Console.WriteLine($"  --> From file: {annotation.InputFileId}, replacement: {annotation.TextToReplace}");
                }
            }
        }
        Assert.That(hasAtLeastOne, Is.True);
        Assert.That(hasCake, Is.True);
    }

    [RecordedTest]
    public async Task StreamingRunWorks()
    {
        string modelName = TestConfig.GetDeploymentNameFor<AssistantClient>();
        AssistantClient client = GetTestClient();
        Assistant assistant = await client.CreateAssistantAsync(modelName);
        Validate(assistant);

        AssistantThread thread = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            InitialMessages = { new(["Hello there, assistant! How are you today?"]), },
        });
        Validate(thread);

        AsyncResultCollection<StreamingUpdate> streamingResult = SyncOrAsync(client,
            c => c.CreateRunStreaming(thread.Id, assistant.Id),
            c => c.CreateRunStreamingAsync(thread.Id, assistant.Id));

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
}
