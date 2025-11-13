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
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

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

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            "Using the file search tool, what's Travis's favorite food?",
            new ResponseCreationOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                Tools =
                {
                    ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]),
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

        OpenAIResponse response = await responsesClient.CreateResponseAsync("Hello, agent or model!");

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
        ResponseCreationOptions responseOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            Tools = { codeInterpreterTool },
        };

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            "Calculate the factorial of 5 using Python code.",
            responseOptions);

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

        ResponseCreationOptions responseCreationOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            Tools = { functionTool },
        };

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What's my favorite food?")],
            responseCreationOptions);
        Assert.That(response.Id, Does.StartWith("resp_"));
        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));

        FunctionCallResponseItem functionCallResponseItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallResponseItem?.FunctionName, Is.EqualTo("get_user_favorite_food"));
        Assert.That(functionCallResponseItem?.CallId, Is.Not.Null.And.Not.Empty);
        Assert.That(functionCallResponseItem?.Id, Is.Not.Null.And.Not.Empty);

        // previous_response_id not yet supported
        //responseCreationOptions.PreviousResponseId = response.Id;
        //response = await client.Responses.CreateResponseAsync(
        //    [ResponseItem.CreateFunctionCallOutputItem(functionCallResponseItem.CallId, "pizza")],
        //    responseCreationOptions);

        //Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));
        //MessageResponseItem messageResponseItem = response.OutputItems.Last() as MessageResponseItem;
        //Assert.That(response.GetOutputText().ToLower(), Does.Contain("pizza"));
    }

    [RecordedTest]
    // [AsyncOnly]
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
        Assert.That(messageItem?.Role, Is.EqualTo(MessageRole.Assistant));

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
        OpenAIResponseClient responseClient = client.GetProjectResponsesClientForModel(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAIResponse response = await responseClient.CreateResponseAsync([ResponseItem.CreateUserMessageItem("Hello, model!")]);
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);

        OpenAIResponse retrievedResponse = await client.Responses.GetResponseAsync(response.Id);
        Assert.That(retrievedResponse.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(retrievedResponse.Id, Is.EqualTo(response.Id));
    }

    [RecordedTest]
    public async Task ResponseBackgroundModeWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello again, model")],
            new ResponseCreationOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                BackgroundModeEnabled = true,
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
    [Ignore("Bug 4755034")]
    public async Task GetResponseStreamingWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, model!")],
            new ResponseCreationOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
                BackgroundModeEnabled = true,
            });
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Queued).Or.EqualTo(ResponseStatus.InProgress));

        List<StreamingResponseUpdate> streamedUpdates = [];
        await foreach (StreamingResponseUpdate responseUpdate in client.Responses.GetResponseStreamingAsync(response.Id))
        {
            streamedUpdates.Add(responseUpdate);
        }

        Assert.That(streamedUpdates.Count, Is.GreaterThan(2));
        Assert.That(streamedUpdates.First(), Is.InstanceOf<StreamingResponseCreatedUpdate>());
        Assert.That(streamedUpdates.Last(), Is.InstanceOf<StreamingResponseCompletedUpdate>());
    }

    [RecordedTest]
    public async Task ResponseDeletionWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            "Hello, model!",
            new ResponseCreationOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME
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

        AgentConversation conversation = await client.Conversations.CreateAgentConversationAsync();
        Assert.That(conversation.Id, Does.StartWith("conv_"));

        FunctionTool functionTool = ResponseTool.CreateFunctionTool(
            "get_user_favorite_food",
            BinaryData.FromString("{}"),
            strictModeEnabled: false,
            functionDescription: "Gets the favorite food of the user");

        ResponseCreationOptions responseCreationOptions = new()
        {
            Model = TestEnvironment.MODELDEPLOYMENTNAME,
            AgentConversationId = conversation,
            Tools = { functionTool },
        };

        OpenAIResponse response = await client.Responses.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What's my favorite food?")],
            responseCreationOptions);
        Assert.That(response.Id, Does.StartWith("resp_"));
        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));

        FunctionCallResponseItem functionCallResponseItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallResponseItem?.FunctionName, Is.EqualTo("get_user_favorite_food"));
        Assert.That(functionCallResponseItem?.CallId, Is.Not.Null.And.Not.Empty);
        Assert.That(functionCallResponseItem?.Id, Is.Not.Null.And.Not.Empty);

        response = await client.Responses.CreateResponseAsync(
            [ResponseItem.CreateFunctionCallOutputItem(functionCallResponseItem.CallId, "pizza")],
            responseCreationOptions);

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

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            "Hello, model!",
            new ResponseCreationOptions()
            {
                Model = TestEnvironment.MODELDEPLOYMENTNAME,
            });
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response?.OutputItems, Has.Count.GreaterThan(0));
    }
}
