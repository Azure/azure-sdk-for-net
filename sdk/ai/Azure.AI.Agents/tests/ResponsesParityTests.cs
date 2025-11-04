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
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Agents.Tests;

/// <summary>
/// Many of these tests are adapted from https://github.com/openai/openai-dotnet/tree/main/tests/Responses.
/// </summary>
public class ResponsesParityTests : AgentsTestBase
{
    public ResponsesParityTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task FileSearchToolWorks()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        OpenAIFile testFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("""
                    Travis's favorite food is pizza.
                    """),
            "test_favorite_foods.txt",
            FileUploadPurpose.Assistants);
        // Bug 4755030
        // FileUploadPurpose.UserData);

        //Validate(testFile);

        VectorStoreClient vectorStoreClient = openAIClient.GetVectorStoreClient();
        VectorStore vectorStore = await vectorStoreClient.CreateVectorStoreAsync(
            new VectorStoreCreationOptions()
            {
                FileIds = { testFile.Id },
            });
        //Validate(vectorStore);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            "Using the file search tool, what's Travis's favorite food?",
            new ResponseCreationOptions()
            {
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

        await foreach (ResponseItem inputItem in responseClient.GetResponseInputItemsAsync(response.Id))
        {
            Console.WriteLine(ModelReaderWriter.Write(inputItem).ToString());
        }
    }

    [RecordedTest]
    public async Task CodeInterpreterToolWorks()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        ResponseTool codeInterpreterTool
            = ResponseTool.CreateCodeInterpreterTool(
                new CodeInterpreterToolContainer(
                    CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])));
        ResponseCreationOptions responseOptions = new()
        {
            Tools = { codeInterpreterTool },
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync(
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

        Assert.That(response.Tools.FirstOrDefault(), Is.TypeOf<OpenAI.Responses.CodeInterpreterTool>());
    }

    [RecordedTest]
    public async Task FunctionToolWorks()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAI.Responses.FunctionTool functionTool = ResponseTool.CreateFunctionTool(
            "get_user_favorite_food",
            BinaryData.FromString("{}"),
            strictModeEnabled: false,
            functionDescription: "Gets the favorite food of the user");

        ResponseCreationOptions responseCreationOptions = new()
        {
            Tools = { functionTool },
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync(
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
        //response = await responseClient.CreateResponseAsync(
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
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

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
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = GetTestOpenAIClientFrom(agentsClient);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAIResponse response = await responseClient.CreateResponseAsync([ResponseItem.CreateUserMessageItem("Hello, model!")]);
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);

        await Task.Delay(TimeSpan.FromSeconds(5));

        OpenAIResponse retrievedResponse = await responseClient.GetResponseAsync(response.Id);
        Assert.That(retrievedResponse.Id, Is.EqualTo(response.Id));
        Assert.That(retrievedResponse.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [RecordedTest]
    public async Task ResponseBackgroundModeWorks()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello again, model")],
            new ResponseCreationOptions()
            {
                BackgroundModeEnabled = true,
            });
        Assert.That(response?.Id, Does.StartWith("resp_"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Queued).Or.EqualTo(ResponseStatus.InProgress));

        TimeSpan pollingDelay = Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(5) : TimeSpan.FromMilliseconds(500);

        for (int i = 0; (response.Status == ResponseStatus.Queued || response.Status == ResponseStatus.InProgress) && i < 20; i++)
        {
            await Task.Delay(pollingDelay);
            response = await responseClient.GetResponseAsync(response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [RecordedTest]
    [Ignore("Bug 4755034")]
    public async Task GetResponseStreamingWorks()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, model!")],
            new ResponseCreationOptions()
            {
                BackgroundModeEnabled = true,
            });
        Assert.That(response?.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Queued).Or.EqualTo(ResponseStatus.InProgress));

        List<StreamingResponseUpdate> streamedUpdates = [];
        await foreach (StreamingResponseUpdate responseUpdate in responseClient.GetResponseStreamingAsync(response.Id))
        {
            streamedUpdates.Add(responseUpdate);
        }

        Assert.That(streamedUpdates.Count, Is.GreaterThan(2));
        Assert.That(streamedUpdates.First(), Is.InstanceOf<StreamingResponseCreatedUpdate>());
        Assert.That(streamedUpdates.Last(), Is.InstanceOf<StreamingResponseCompletedUpdate>());
    }

    [RecordedTest]
    [Ignore("Bug 4755148")]
    public async Task ResponseDeletionWorks()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        OpenAIResponse response = await responseClient.CreateResponseAsync("Hello, model!");
        Assert.That(response?.Id, Does.StartWith("resp_"));

        Assert.DoesNotThrowAsync(async () => await responseClient.GetResponseAsync(response.Id));

        ResponseDeletionResult deletionResult = await responseClient.DeleteResponseAsync(response.Id);
        Assert.That(deletionResult.Deleted, Is.True);

        Assert.ThrowsAsync<ClientResultException>(async () => await responseClient.GetResponseAsync(response.Id));
    }

    [RecordedTest]
    public async Task FunctionToolWorksWithConversation()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
        Assert.That(conversation.Id, Does.StartWith("conv_"));

        OpenAI.Responses.FunctionTool functionTool = ResponseTool.CreateFunctionTool(
            "get_user_favorite_food",
            BinaryData.FromString("{}"),
            strictModeEnabled: false,
            functionDescription: "Gets the favorite food of the user");

        ResponseCreationOptions responseCreationOptions = new()
        {
            Tools = { functionTool },
            Conversation = conversation,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What's my favorite food?")],
            responseCreationOptions);
        Assert.That(response.Id, Does.StartWith("resp_"));
        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));

        FunctionCallResponseItem functionCallResponseItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallResponseItem?.FunctionName, Is.EqualTo("get_user_favorite_food"));
        Assert.That(functionCallResponseItem?.CallId, Is.Not.Null.And.Not.Empty);
        Assert.That(functionCallResponseItem?.Id, Is.Not.Null.And.Not.Empty);

        response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateFunctionCallOutputItem(functionCallResponseItem.CallId, "pizza")],
            responseCreationOptions);

        Assert.That(response.OutputItems.Count, Is.GreaterThanOrEqualTo(1));
        MessageResponseItem messageResponseItem = response.OutputItems.Last() as MessageResponseItem;
        Assert.That(response.GetOutputText().ToLower(), Does.Contain("pizza"));
    }
}
