// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.AI.Projects.OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;
// We need this alias to avoid conflict with internal enum MessageRole.
using RealOpenAI = OpenAI;

namespace Azure.AI.Projects.OpenAI.Tests;

/// <summary>
/// Many of these tests are adapted from https://github.com/openai/openai-dotnet/tree/main/tests/Responses.
/// </summary>
public class ResponsesParityTests : ProjectsOpenAITestBase
{
    public ResponsesParityTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task FileSearchToolWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        OpenAIFile testFile = await client.Files.UploadFileAsync(
            BinaryData.FromString("""
                    Travis's favorite food is pizza.
                    """),
            "test_favorite_foods.txt",
            FileUploadPurpose.Assistants);
        // Bug 4755030
        // FileUploadPurpose.UserData);

        //Validate(testFile);

        VectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
            new VectorStoreCreationOptions()
            {
                FileIds = { testFile.Id },
            });
        //Validate(vectorStore);

        ResponseResult response = await client.Responses.CreateResponseAsync(
            new CreateResponseOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                Tools =
                {
                    ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]),
                },
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Using the file search tool, what's Travis's favorite food?"),
                }
            });
        Assert.That(response.OutputItems?.Count, Is.GreaterThanOrEqualTo(2));
        FileSearchCallResponseItem fileSearchCall = response.OutputItems.FirstOrDefault(item => item is FileSearchCallResponseItem) as FileSearchCallResponseItem;
        Assert.That(fileSearchCall, Is.Not.Null);
        Assert.That(fileSearchCall?.Status, Is.EqualTo(FileSearchCallStatus.Completed));
        Assert.That(fileSearchCall?.Queries, Has.Count.GreaterThan(0));
        MessageResponseItem message = response.OutputItems.FirstOrDefault(item => item is MessageResponseItem) as MessageResponseItem;
        Assert.That(message, Is.Not.Null);
        ResponseContentPart messageContentPart = message.Content?.FirstOrDefault();
        Assert.That(messageContentPart, Is.Not.Null);
        Assert.That(messageContentPart.Text, Does.Contain("pizza"));
        Assert.That(messageContentPart.OutputTextAnnotations, Is.Not.Null.And.Not.Empty);
        FileCitationMessageAnnotation annotation = messageContentPart.OutputTextAnnotations[0] as FileCitationMessageAnnotation;
        Assert.That(annotation.FileId, Is.EqualTo(testFile.Id));
        Assert.That(annotation.Index, Is.GreaterThan(0));

        await foreach (ResponseItem inputItem in client.Responses.GetResponseInputItemsAsync(response.Id))
        {
            Console.WriteLine(ModelReaderWriter.Write(inputItem).ToString());
        }
    }

    public enum ResponsesClientCreationMethod
    {
        UseFactory,
        UseConstructor
    }

    public enum ResponsesClientDefault
    {
        DefaultAgent,
        DefaultModel,
        DefaultConversation
    }

    [RecordedTest]
    [TestCase(ResponsesClientCreationMethod.UseFactory, ResponsesClientDefault.DefaultAgent)]
    [TestCase(ResponsesClientCreationMethod.UseFactory, ResponsesClientDefault.DefaultAgent, ResponsesClientDefault.DefaultConversation)]
    [TestCase(ResponsesClientCreationMethod.UseFactory, ResponsesClientDefault.DefaultModel)]
    [TestCase(ResponsesClientCreationMethod.UseFactory, ResponsesClientDefault.DefaultModel, ResponsesClientDefault.DefaultConversation)]
    [TestCase(ResponsesClientCreationMethod.UseConstructor, ResponsesClientDefault.DefaultAgent)]
    [TestCase(ResponsesClientCreationMethod.UseConstructor, ResponsesClientDefault.DefaultAgent, ResponsesClientDefault.DefaultConversation)]
    [TestCase(ResponsesClientCreationMethod.UseConstructor, ResponsesClientDefault.DefaultModel)]
    [TestCase(ResponsesClientCreationMethod.UseConstructor, ResponsesClientDefault.DefaultModel, ResponsesClientDefault.DefaultConversation)]
    public async Task ClientDefaultsWork(ResponsesClientCreationMethod creationMethod, params ResponsesClientDefault[] defaults)
    {
        bool isDefaultAgent = defaults?.Any(defaultItem => defaultItem == ResponsesClientDefault.DefaultAgent) == true;
        bool isDefaultModel = defaults?.Any(defaultItem => defaultItem == ResponsesClientDefault.DefaultModel) == true;
        bool isDefaultConversation = defaults?.Any(defaultItem => defaultItem == ResponsesClientDefault.DefaultConversation) == true;

        ProjectResponsesClient responsesClient = null;
        if (creationMethod == ResponsesClientCreationMethod.UseFactory)
        {
            ProjectOpenAIClient openAIClient = GetTestProjectOpenAIClient();
            if (isDefaultModel && !isDefaultAgent)
            {
                responsesClient = openAIClient.GetProjectResponsesClientForModel(
                    TestEnvironment.MODELDEPLOYMENTNAME,
                    isDefaultConversation ? TestEnvironment.KNOWN_CONVERSATION_ID : null);
            }
            else if (isDefaultAgent && !isDefaultModel)
            {
                responsesClient = openAIClient.GetProjectResponsesClientForAgent(
                    TestEnvironment.AGENT_NAME,
                    isDefaultConversation ? TestEnvironment.KNOWN_CONVERSATION_ID : null);
            }
            else if (!isDefaultAgent && !isDefaultModel)
            {
                responsesClient = openAIClient.GetProjectResponsesClient();
            }
            else if (isDefaultAgent && isDefaultModel)
            {
                throw new InvalidOperationException();
            }
            responsesClient = CreateProxyFromClient(responsesClient);
        }
        else
        {
            responsesClient = GetTestProjectResponsesClient(
                defaultAgentName: isDefaultAgent ? TestEnvironment.AGENT_NAME : null,
                defaultModelName: isDefaultModel ? TestEnvironment.MODELDEPLOYMENTNAME : null,
                defaultConversationId: isDefaultConversation ? TestEnvironment.KNOWN_CONVERSATION_ID : null);
        }

        ResponseResult response = await responsesClient.CreateResponseAsync("Hello, agent or model!");

        Assert.That(
            response?.Agent?.Name,
            isDefaultAgent ? Is.EqualTo(TestEnvironment.AGENT_NAME) : Is.Null);
        Assert.That(
            response?.AgentConversationId,
            isDefaultConversation ? Is.EqualTo(TestEnvironment.KNOWN_CONVERSATION_ID) : Is.Null);
        if (isDefaultModel)
        {
            Assert.That(response?.Model, Does.StartWith(TestEnvironment.MODELDEPLOYMENTNAME));
        }
    }

    [RecordedTest]
    public async Task CodeInterpreterToolWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ResponseTool codeInterpreterTool
            = ResponseTool.CreateCodeInterpreterTool(
                new CodeInterpreterToolContainer(
                    CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])));
        CreateResponseOptions responseOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            Tools = { codeInterpreterTool },
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Calculate the factorial of 5 using Python code."),
            },
        };

        ResponseResult response = await client.Responses.CreateResponseAsync(responseOptions);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.OutputItems, Has.Count.GreaterThanOrEqualTo(2));
        Assert.That(response.OutputItems[response.OutputItems.Count - 2], Is.InstanceOf<CodeInterpreterCallResponseItem>());
        Assert.That(response.OutputItems[response.OutputItems.Count - 1], Is.InstanceOf<MessageResponseItem>());

        MessageResponseItem message = (MessageResponseItem)response.OutputItems[response.OutputItems.Count - 1];
        Assert.That(message.Content, Has.Count.GreaterThan(0));
        Assert.That(message.Content[0].Kind, Is.EqualTo(ResponseContentPartKind.OutputText));
        Assert.That(message.Content[0].Text, Is.Not.Null.And.Not.Empty);

        // Basic validation that the response was created successfully
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);

        Assert.That(response.Tools.FirstOrDefault(), Is.TypeOf<CodeInterpreterTool>());
    }

    [RecordedTest]
    public async Task FunctionToolWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        FunctionTool functionTool = ResponseTool.CreateFunctionTool(
            "get_user_favorite_food",
            BinaryData.FromString("{}"),
            strictModeEnabled: false,
            functionDescription: "Gets the favorite food of the user");

        CreateResponseOptions responseOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            Tools = { functionTool },
            InputItems = { ResponseItem.CreateUserMessageItem("What's my favorite food?") },
        };

        ResponseResult response = await client.Responses.CreateResponseAsync(responseOptions);
        Assert.That(response.Id, Does.StartWith("resp_"));
        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));

        FunctionCallResponseItem functionCallResponseItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallResponseItem?.FunctionName, Is.EqualTo("get_user_favorite_food"));
        Assert.That(functionCallResponseItem?.CallId, Is.Not.Null.And.Not.Empty);
        Assert.That(functionCallResponseItem?.Id, Is.Not.Null.And.Not.Empty);

        // previous_response_id not yet supported
        //CreateResponseOptions.PreviousResponseId = response.Id;
        //response = await client.Responses.CreateResponseAsync(
        //    [ResponseItem.CreateFunctionCallOutputItem(functionCallResponseItem.CallId, "pizza")],
        //    CreateResponseOptions);

        //Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));
        //MessageResponseItem messageResponseItem = response.OutputItems.Last() as MessageResponseItem;
        //Assert.That(response.GetOutputText().ToLower(), Does.Contain("pizza"));
    }

    [RecordedTest]
    public async Task StreamingResponsesWork()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();
        ProjectResponsesClient responseClient = client.GetProjectResponsesClientForModel(TestEnvironment.MODELDEPLOYMENTNAME);

        List<StreamingResponseUpdate> streamedUpdates = [];
        await foreach (StreamingResponseUpdate streamedUpdate in responseClient.CreateResponseStreamingAsync("Hello, model!"))
        {
            Assert.That(streamedUpdate.SequenceNumber, Is.EqualTo(streamedUpdates.Count));
            streamedUpdates.Add(streamedUpdate);
        }

        Assert.That(streamedUpdates.Count, Is.GreaterThan(2));
        StreamingResponseCreatedUpdate createdUpdate = streamedUpdates.First() as StreamingResponseCreatedUpdate;
        Assert.That(createdUpdate?.Response?.Id, Is.Not.Null);

        StreamingResponseCompletedUpdate completedUpdate = streamedUpdates.Last() as StreamingResponseCompletedUpdate;
        Assert.That(completedUpdate?.Response?.Id, Is.EqualTo(createdUpdate.Response.Id));

        MessageResponseItem messageItem = completedUpdate.Response.OutputItems?.LastOrDefault() as MessageResponseItem;
        Assert.That(messageItem?.Role, Is.EqualTo(RealOpenAI::Responses.MessageRole.Assistant));

        StringBuilder deltaBuilder = new();
        foreach (StreamingResponseUpdate streamedUpdate in streamedUpdates)
        {
            if (streamedUpdate is StreamingResponseOutputTextDeltaUpdate textDeltaUpdate)
            {
                deltaBuilder.Append(textDeltaUpdate.Delta);
            }
        }
        Assert.That(deltaBuilder.ToString(), Is.EqualTo(completedUpdate.Response.GetOutputText()));
    }

    [RecordedTest]
    public async Task GetResponseWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();
        ResponsesClient responseClient = client.GetProjectResponsesClientForModel(TestEnvironment.MODELDEPLOYMENTNAME);

        ResponseResult response = await responseClient.CreateResponseAsync([ResponseItem.CreateUserMessageItem("Hello, model!")]);
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);

        ResponseResult retrievedResponse = await client.Responses.GetResponseAsync(response.Id);
        Assert.That(retrievedResponse.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(retrievedResponse.Id, Is.EqualTo(response.Id));
    }

    [RecordedTest]
    public async Task ResponseBackgroundModeWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ResponseResult response = await client.Responses.CreateResponseAsync(
            new CreateResponseOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                BackgroundModeEnabled = true,
                InputItems = { ResponseItem.CreateUserMessageItem("Hello again, model") },
            });
        Assert.That(response?.Id, Does.StartWith("resp_"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Queued).Or.EqualTo(ResponseStatus.InProgress));

        TimeSpan pollingDelay = Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(5) : TimeSpan.FromMilliseconds(500);

        for (int i = 0; (response.Status == ResponseStatus.Queued || response.Status == ResponseStatus.InProgress) && i < 20; i++)
        {
            await Task.Delay(pollingDelay);
            response = await client.Responses.GetResponseAsync(response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [RecordedTest]
    [TestCase(OpenAIClientMode.UseFDPOpenAI)]
    [TestCase(OpenAIClientMode.UseExternalOpenAI)]
    public async Task GetResponseStreamingWorks(OpenAIClientMode clientMode)
    {
        ResponsesClient client = GetTestResponsesClient(clientMode);

        ResponseResult startedResponse = null;
        await foreach (StreamingResponseUpdate update
            in client.CreateResponseStreamingAsync(
                new CreateResponseOptions()
                {
                    Model = TestEnvironment.MODELDEPLOYMENTNAME,
                    BackgroundModeEnabled = true,
                    StreamingEnabled = true,
                    InputItems =
                    {
                        ResponseItem.CreateUserMessageItem("Hello, model!"),
                    },
                }))
        {
            if (update is StreamingResponseCreatedUpdate createdUpdate)
            {
                startedResponse = createdUpdate.Response;
                break;
            }
        }

        Assert.That(startedResponse?.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(startedResponse.Status, Is.EqualTo(ResponseStatus.Queued).Or.EqualTo(ResponseStatus.InProgress));

        List<StreamingResponseUpdate> streamedUpdates = [];
        await foreach (StreamingResponseUpdate responseUpdate in client.GetResponseStreamingAsync(startedResponse.Id))
        {
            streamedUpdates.Add(responseUpdate);
        }

        Assert.That(streamedUpdates.Count, Is.GreaterThan(2));
        Assert.That(streamedUpdates.First(), Is.InstanceOf<StreamingResponseCreatedUpdate>());
        Assert.That(streamedUpdates.Last(), Is.InstanceOf<StreamingResponseCompletedUpdate>());
    }

    [RecordedTest]
    public async Task ListingResponsesWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        Dictionary<string, ResponseResult> firstResponsesById = [];

        await foreach (ResponseResult response in client.Responses.GetProjectResponsesAsync())
        {
            Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(firstResponsesById.ContainsKey(response.Id), Is.False);
            firstResponsesById[response.Id] = response;

            if (firstResponsesById.Count >= 20)
            {
                break;
            }
        }

        ProjectConversation newConversation = await client.Conversations.CreateProjectConversationAsync();
        ProjectResponsesClient responsesForNewConversation = client.GetProjectResponsesClientForModel(TestEnvironment.MODELDEPLOYMENTNAME, newConversation.Id);
        ResponseResult newResponse = await responsesForNewConversation.CreateResponseAsync("Hello, new conversation!");

        List<ResponseResult> matchingResponses = [];

        await foreach (ResponseResult response in client.Responses.GetProjectResponsesAsync(conversationId: newConversation.Id))
        {
            matchingResponses.Add(response);
        }

        Assert.That(matchingResponses, Has.Count.EqualTo(1));
        Assert.That(matchingResponses[0].Id, Is.EqualTo(newResponse.Id));

        // TODO: add validation for agent reference

        Assert.That(firstResponsesById, Is.Not.Empty);
    }

    [RecordedTest]
    public async Task ResponseDeletionWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ResponseResult response = await client.Responses.CreateResponseAsync(
            new CreateResponseOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Hello, model!"),
                },
            });
        Assert.That(response?.Id, Does.StartWith("resp_"));

        Assert.DoesNotThrowAsync(async () => await client.Responses.GetResponseAsync(response.Id));

        ResponseDeletionResult deletionResult = await client.Responses.DeleteResponseAsync(response.Id);
        Assert.That(deletionResult.Deleted, Is.True);

        Assert.ThrowsAsync<ClientResultException>(async () => await client.Responses.GetResponseAsync(response.Id));
    }

    [RecordedTest]
    public async Task FunctionToolWorksWithConversation()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ProjectConversation conversation = await client.Conversations.CreateProjectConversationAsync();
        Assert.That(conversation.Id, Does.StartWith("conv_"));

        FunctionTool functionTool = ResponseTool.CreateFunctionTool(
            "get_user_favorite_food",
            BinaryData.FromString("{}"),
            strictModeEnabled: false,
            functionDescription: "Gets the favorite food of the user");

        CreateResponseOptions responseOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            AgentConversationId = conversation,
            Tools = { functionTool },
            InputItems = { ResponseItem.CreateUserMessageItem("What's my favorite food?") },
        };

        ResponseResult response = await client.Responses.CreateResponseAsync(responseOptions);
        Assert.That(response.Id, Does.StartWith("resp_"));
        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));

        FunctionCallResponseItem functionCallResponseItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallResponseItem?.FunctionName, Is.EqualTo("get_user_favorite_food"));
        Assert.That(functionCallResponseItem?.CallId, Is.Not.Null.And.Not.Empty);
        Assert.That(functionCallResponseItem?.Id, Is.Not.Null.And.Not.Empty);

        CreateResponseOptions followupOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            AgentConversationId = conversation,
            InputItems = { ResponseItem.CreateFunctionCallOutputItem(functionCallResponseItem.CallId, "pizza") },
        };

        response = await client.Responses.CreateResponseAsync(followupOptions);
        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));
        MessageResponseItem messageResponseItem = response.OutputItems.Last() as MessageResponseItem;
        Assert.That(response.GetOutputText().ToLower(), Does.Contain("pizza"));
    }

    public enum TestResponseClientInitializationType
    {
        FromProjectsClient,
        FromProjectsOpenAIClientWithConstructorEndpoint,
        FromProjectsOpenAIClientWithOptionsEndpoint,
        DirectWithProjectEndpoint,
        DirectWithOptions,
    }

    [RecordedTest]
    [TestCase(TestResponseClientInitializationType.FromProjectsClient)]
    [TestCase(TestResponseClientInitializationType.FromProjectsOpenAIClientWithConstructorEndpoint)]
    [TestCase(TestResponseClientInitializationType.FromProjectsOpenAIClientWithOptionsEndpoint)]
    [TestCase(TestResponseClientInitializationType.DirectWithProjectEndpoint)]
    [TestCase(TestResponseClientInitializationType.DirectWithOptions)]
    public async Task DirectlyInitializedResponsesClientsWork(
        TestResponseClientInitializationType clientInitializationType)
    {
        ProjectResponsesClient responseClient = null;
        if (clientInitializationType == TestResponseClientInitializationType.FromProjectsClient)
        {
            AIProjectClient projectClient = GetTestProjectClient();
            responseClient = projectClient.OpenAI.Responses;
        }
        else if (clientInitializationType == TestResponseClientInitializationType.FromProjectsOpenAIClientWithConstructorEndpoint)
        {
            ProjectOpenAIClient openAIClient = GetTestProjectOpenAIClient(endpointInConstructor: true, endpointInOptions: false);
            responseClient = openAIClient.Responses;
        }
        else if (clientInitializationType == TestResponseClientInitializationType.FromProjectsOpenAIClientWithOptionsEndpoint)
        {
            ProjectOpenAIClient openAIClient = GetTestProjectOpenAIClient(endpointInConstructor: false, endpointInOptions: true);
            responseClient = openAIClient.Responses;
        }
        else if (clientInitializationType == TestResponseClientInitializationType.DirectWithProjectEndpoint)
        {
            responseClient = GetTestProjectResponsesClient();
        }
        else if (clientInitializationType == TestResponseClientInitializationType.DirectWithOptions)
        {
            responseClient = GetTestProjectResponsesClient(endpointInConstructor: false, endpointInOptions: true);
        }
        else
        {
            Assert.Fail($"Unexpected initialization type for test: {clientInitializationType}");
        }

        ResponseResult response = await responseClient.CreateResponseAsync(
            new CreateResponseOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Hello, model!"),
                },
            });
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response?.OutputItems, Has.Count.GreaterThan(0));
    }

    [RecordedTest]
    [TestCase(OpenAIClientMode.UseExternalOpenAI)]
    [TestCase(OpenAIClientMode.UseFDPOpenAI, Ignore = "'none' not yet supported on FDP")]
    public async Task ExtensibleReasoningEffortWorks(OpenAIClientMode clientMode)
    {
        ResponsesClient responseClient = GetTestResponsesClient(clientMode, "gpt-5.1");

        ResponseResult response = await responseClient.CreateResponseAsync(
            new CreateResponseOptions()
            {
                ReasoningOptions = new()
                {
                    ReasoningEffortLevel = "none",
                },
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Hello, gpt-5.1!"),
                }
            });

        Assert.That(response.ReasoningOptions?.ReasoningEffortLevel?.ToString(), Is.EqualTo("none"));
    }

    [RecordedTest]
    public async Task TestPublishedAgent()
    {
        ProjectOpenAIClientOptions clientOptions = CreateTestOpenAIClientOptions<ProjectOpenAIClientOptions>(
           endpoint: new Uri($"{TestEnvironment.PUBLISHED_ENDPOINT}/openai"));
        ProjectOpenAIClient client = CreateProxyFromClient(new ProjectOpenAIClient(GetTestAuthenticationPolicy(), clientOptions));
        ResponseResult response = await client.Responses.CreateResponseAsync("What is the size of France in square miles?");
        Assert.That(string.IsNullOrEmpty(response.GetOutputText()), Is.False, "The Agent did not returned a response.");
    }
}
