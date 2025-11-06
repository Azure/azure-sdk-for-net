// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Tests.Utils.Config;
using Azure.Core;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.TestFramework;
using OpenAI.VectorStores;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable CS0618
#pragma warning disable OPENAICUA001

public class ResponsesTests : AoaiTestBase<OpenAIResponseClient>
{
    private IConfiguration DefaultResponsesConfig { get; set; }

    private const string Gpt4oMiniDeployment = "gpt-4o-mini";
    private const string ComputerUseDeployment = "computer-use-preview";

    public ResponsesTests(bool isAsync) : base(isAsync)
    {
        DefaultResponsesConfig ??= TestConfig.GetConfig("responses")
            ?? throw new InvalidDataException("Can't find test config for responses");
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    public async Task FileSearch(string deploymentName)
    {
        OpenAIClient topLevelClient = GetTestTopLevelClient(DefaultResponsesConfig);
        OpenAIFileClient fileClient = topLevelClient.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = topLevelClient.GetVectorStoreClient();
        OpenAIResponseClient client = topLevelClient.GetOpenAIResponseClient(deploymentName);

        OpenAIFile testFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("""
                    Travis's favorite food is pizza.
                    """),
            "test_favorite_foods.txt",
            FileUploadPurpose.Assistants);
        Validate(testFile);

        VectorStore vectorStore = await vectorStoreClient.CreateVectorStoreAsync(
            new VectorStoreCreationOptions()
            {
                FileIds = { testFile.Id },
            });
        Validate(vectorStore);

        OpenAIResponse response = await client.CreateResponseAsync(
            "Using the file search tool, what's Travis's favorite food?",
            new ResponseCreationOptions()
            {
                Tools =
                {
                    ResponseTool.CreateFileSearchTool([vectorStore.Id], null),
                }
            });
        Assert.That(response.OutputItems?.Count, Is.EqualTo(2));
        FileSearchCallResponseItem? fileSearchCall = response?.OutputItems?[0] as FileSearchCallResponseItem;
        Assert.That(fileSearchCall, Is.Not.Null);
        Assert.That(fileSearchCall?.Status, Is.EqualTo(FileSearchCallStatus.Completed));
        Assert.That(fileSearchCall?.Queries, Has.Count.GreaterThan(0));
        MessageResponseItem? message = response?.OutputItems?[1] as MessageResponseItem;
        Assert.That(message, Is.Not.Null);
        ResponseContentPart? messageContentPart = message?.Content?.FirstOrDefault();
        Assert.That(messageContentPart, Is.Not.Null);
        Assert.That(messageContentPart?.Text, Does.Contain("pizza"));
        Assert.That(messageContentPart?.OutputTextAnnotations, Is.Not.Null.And.Not.Empty);
        FileCitationMessageAnnotation? citationAnnotation = messageContentPart!.OutputTextAnnotations[0] as FileCitationMessageAnnotation;
        Assert.That(citationAnnotation?.FileId, Is.EqualTo(testFile.Id));
        Assert.That(citationAnnotation?.Index, Is.GreaterThan(0));

        // The AzureOpenAI endpoint does not serve the path for
        // https://{Azure OpenAI endpoint}/responses/{response.Id}/input_items
        //await foreach (ResponseItem inputItem in client.GetResponseInputItemsAsync(response?.Id))
        //{
        //    Console.WriteLine(ModelReaderWriter.Write(inputItem).ToString());
        //}
    }

    [RecordedTest]
    public async Task ComputerToolWithScreenshotRoundTrip()
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(ComputerUseDeployment);

        ResponseTool computerTool = ResponseTool.CreateComputerTool(ComputerToolEnvironment.Windows, 1024, 768);
        ResponseCreationOptions options = new()
        {
            Tools = { computerTool },
            TruncationMode = ResponseTruncationMode.Auto,
        };
        OpenAIResponse response = await client.CreateResponseAsync(
            inputItems:
            [
                ResponseItem.CreateDeveloperMessageItem("Call tools when the user asks to perform computer-related tasks like clicking interface elements."),
                ResponseItem.CreateUserMessageItem("Click on the Save button.")
            ],
            options);

        while (true)
        {
            Assert.That(response?.OutputItems?.Count, Is.GreaterThan(0));
            ResponseItem? outputItem = response?.OutputItems?.LastOrDefault();
            if (outputItem is ComputerCallResponseItem computerCall)
            {
                if (computerCall.Action.Kind == ComputerCallActionKind.Screenshot)
                {
                    string screenshotPath = Assets.ScreenshotWithSaveButton.RelativePath;
                    BinaryData screenshotBytes = BinaryData.FromBytes(File.ReadAllBytes(screenshotPath));
                    ResponseItem screenshotReply = ResponseItem.CreateComputerCallOutputItem(
                        computerCall.CallId,
                        ComputerCallOutput.CreateScreenshotOutput(screenshotBytes, "image/png"));

                    options.PreviousResponseId = response!.Id;
                    response = await client.CreateResponseAsync(
                        [screenshotReply],
                        options);
                }
                else if (computerCall.Action.Kind == ComputerCallActionKind.Click)
                {
                    Console.WriteLine($"Instruction from model: click");
                    break;
                }
            }
            else if (outputItem is MessageResponseItem message
                && message.Content?.FirstOrDefault()?.Text?.ToLower() is string assistantText
                && (
                    assistantText.Contains("should i")
                    || assistantText.Contains("shall i")
                    || assistantText.Contains("can you confirm")
                    || assistantText.Contains("could you confirm")
                    || assistantText.Contains("please confirm")))
            {
                options.PreviousResponseId = response!.Id;
                response = await client.CreateResponseAsync(
                    "Yes, proceed.",
                    options);
            }
            else
            {
                break;
            }
        }
    }

    [RecordedTest]
    public void WebSearchNotSupported()
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(Gpt4oMiniDeployment);
        ClientResultException? expectedException = Assert.ThrowsAsync<ClientResultException>(() =>
            client.CreateResponseAsync(
                "What was a positive news story from today?",
                new ResponseCreationOptions()
                {
                    Tools =
                    {
                        ResponseTool.CreateWebSearchTool()
                    }
                }));
        Assert.That(expectedException, Is.Not.Null);
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task StreamingResponses(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        List<ResponseItem> inputItems = [ResponseItem.CreateUserMessageItem("Hello, world!")];
        List<string> deltaTextSegments = [];
        string? finalResponseText = null;
        await foreach (StreamingResponseUpdate update
            in client.CreateResponseStreamingAsync(inputItems, options))
        {
            Console.WriteLine(ModelReaderWriter.Write(update));
            Assert.That(update, Is.Not.InstanceOf<StreamingResponseErrorUpdate>());
            if (update is StreamingResponseOutputTextDeltaUpdate outputTextDeltaUpdate)
            {
                deltaTextSegments.Add(outputTextDeltaUpdate.Delta);
                Console.Write(outputTextDeltaUpdate.Delta);
            }
            else if (update is StreamingResponseCompletedUpdate responseCompletedUpdate)
            {
                finalResponseText = responseCompletedUpdate.Response.GetOutputText();
            }
        }
        Assert.That(deltaTextSegments, Has.Count.GreaterThan(0));
        Assert.That(finalResponseText, Is.Not.Null.And.Not.Empty);
        Assert.That(string.Join(string.Empty, deltaTextSegments), Is.EqualTo(finalResponseText));
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task ResponsesHelloWorldWithTool(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new()
        {
            Tools =
            {
                ResponseTool.CreateFunctionTool(
                    functionName: "get_custom_greeting",
                    functionDescription: "invoked when user provides a typical greeting",
                    functionParameters: BinaryData.FromString(
                        """
                        {
                          "type": "object",
                          "properties": {
                            "time_of_day": {
                              "type": "string"
                            }
                          }
                        }
                        """),
                    strictModeEnabled: false),
            },
        };
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            [
                ResponseItem.CreateUserMessageItem(
                [
                    ResponseContentPart.CreateInputTextPart("good morning, responses!"),
                ]),
            ],
            options);

        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.CreatedAt, Is.GreaterThan(new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)));
        // Assert.That(response.Status, Is.EqualTo(ResponsesStatus.Completed));
        Assert.That(response.Model, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PreviousResponseId, Is.Null);
        // Observed: input may not exist on normal responses
        // Assert.That(response.Input.Count, Is.EqualTo(1));
        Assert.That(response.OutputItems.Count, Is.EqualTo(1));
    }

    [RecordedTest]
    public async Task ResponsesWithReasoning()
    {
        OpenAIResponseClient client = GetTestClient("chat_o3-mini");

        ResponseCreationOptions options = new()
        {
            ReasoningOptions = new()
            {
                ReasoningSummaryVerbosity = ResponseReasoningSummaryVerbosity.Detailed,
                ReasoningEffortLevel = ResponseReasoningEffortLevel.Medium,
            },
            Metadata =
            {
                ["superfluous_key"] = "superfluous_value",
            },
            Instructions = "Perform reasoning over any questions asked by the user.",
        };

        OpenAIResponse response = await client.CreateResponseAsync([ResponseItem.CreateUserMessageItem("What's the best way to fold a burrito?")], options);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null);
        Assert.That(response.CreatedAt, Is.GreaterThan(new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)));
        Assert.That(response.MaxOutputTokenCount, Is.Null);
        Assert.That(response.Model, Does.StartWith("o3-mini"));
        Assert.That(response.Usage, Is.Not.Null);
        Assert.That(response.Usage.OutputTokenDetails, Is.Not.Null);
        Assert.That(response.Usage.OutputTokenDetails.ReasoningTokenCount, Is.GreaterThan(0));
        Assert.That(response.Metadata, Is.Not.Null.Or.Empty);
        Assert.That(response.Metadata["superfluous_key"], Is.EqualTo("superfluous_value"));
        Assert.That(response.OutputItems, Has.Count.EqualTo(2));
        ReasoningResponseItem? reasoningItem = response.OutputItems?[0] as ReasoningResponseItem;
        MessageResponseItem? messageItem = response.OutputItems?[1] as MessageResponseItem;
        Assert.That(reasoningItem?.SummaryParts, Is.Not.Null);
        Assert.That(reasoningItem?.GetSummaryText(), Is.Not.Null.And.Not.Empty);
        Assert.That(reasoningItem?.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(messageItem?.Content?.FirstOrDefault()?.Text, Has.Length.GreaterThan(0));
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task HelloWorldStreaming(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        ResponseContentPart contentPart = ResponseContentPart.CreateInputTextPart("Hello, responses!");
        ResponseItem inputItem = ResponseItem.CreateUserMessageItem([contentPart]);

        await foreach (StreamingResponseUpdate update
            in client.CreateResponseStreamingAsync([inputItem], options))
        {
            Console.WriteLine(ModelReaderWriter.Write(update));
        }
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task CanDeleteResponse(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, model!")],
            options);

        async Task RetrieveThatResponseAsync()
        {
            OpenAIResponse retrievedResponse = await client.GetResponseAsync(response.Id);
            Assert.That(retrievedResponse.Id, Is.EqualTo(response.Id));
        }

        Assert.DoesNotThrowAsync(RetrieveThatResponseAsync);

        ResponseDeletionResult deletionResult = await client.DeleteResponseAsync(response.Id);
        Assert.That(deletionResult.Deleted, Is.True);

        Assert.ThrowsAsync<ClientResultException>(RetrieveThatResponseAsync);
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task CanOptOutOfStorage(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new()
        {
            StoredOutputEnabled = false
        };
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, model!")],
            options);

        ClientResultException? expectedException = Assert.ThrowsAsync<ClientResultException>(async () => await client.GetResponseAsync(response.Id));
        Assert.That(expectedException?.Message, Does.Contain("not found"));
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task OutputTextProperty(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);
        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            "Respond with only the word hello.",
            options);
        Assert.That(response?.GetOutputText()?.Length, Is.GreaterThan(0).And.LessThan(7));
        Assert.That(response?.GetOutputText()?.ToLower(), Does.Contain("hello"));

        response = await client.CreateResponseAsync(
            "How's the weather?",
            new ResponseCreationOptions()
            {
                Tools = { ResponseTool.CreateFunctionTool("get_weather", functionDescription: "gets the weather", functionParameters: BinaryData.FromString("{}"), strictModeEnabled: false) },
                ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
                TruncationMode = ResponseTruncationMode.Auto,
            });
        Assert.That(response.GetOutputText(), Is.Null);
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task MessageHistoryWorks(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            [
                ResponseItem.CreateDeveloperMessageItem("You are a helpful assistant."),
                ResponseItem.CreateUserMessageItem("Hello, Assistant, my name is Bob!"),
                ResponseItem.CreateAssistantMessageItem("Hello, Bob. It's a nice, sunny day!"),
                ResponseItem.CreateUserMessageItem("What's my name and what did you tell me the weather was like?"),
            ],
            options);

        Assert.That(response, Is.Not.Null);
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment, Ignore = "image input not currently supported")]
    public async Task ImageInputWorks(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        string imagePath = Assets.DogAndCat.RelativePath;
        BinaryData imageBytes = BinaryData.FromBytes(File.ReadAllBytes(imagePath)!);

        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            [
                ResponseItem.CreateUserMessageItem(
                    [
                        ResponseContentPart.CreateInputTextPart("Please describe this picture for me"),
                        ResponseContentPart.CreateInputImagePart(imageBytes, "image/png", ResponseImageDetailLevel.Low),
                    ]),
            ],
            options);
    }

    public enum ResponsesTestInstructionMethod
    {
        InstructionsProperty,
        SystemMessage,
        DeveloperMessage
    }

    [RecordedTest]
    [TestCase(ResponsesTestInstructionMethod.DeveloperMessage, Gpt4oMiniDeployment)]
    [TestCase(ResponsesTestInstructionMethod.DeveloperMessage, ComputerUseDeployment)]
    [TestCase(ResponsesTestInstructionMethod.InstructionsProperty, Gpt4oMiniDeployment)]
    [TestCase(ResponsesTestInstructionMethod.InstructionsProperty, ComputerUseDeployment)]
    [TestCase(ResponsesTestInstructionMethod.SystemMessage, Gpt4oMiniDeployment)]
    [TestCase(ResponsesTestInstructionMethod.SystemMessage, ComputerUseDeployment)]
    public async Task AllInstructionMethodsWork(ResponsesTestInstructionMethod instructionMethod, string deploymentName)
    {
        const string instructions = "Always begin your replies with 'Arr, matey'";

        List<MessageResponseItem> messages = new();

        if (instructionMethod == ResponsesTestInstructionMethod.SystemMessage)
        {
            messages.Add(ResponseItem.CreateSystemMessageItem(instructions));
        }
        else if (instructionMethod == ResponsesTestInstructionMethod.DeveloperMessage)
        {
            messages.Add(ResponseItem.CreateDeveloperMessageItem(instructions));
        }

        const string userMessage = "Hello, model!";
        messages.Add(ResponseItem.CreateUserMessageItem(userMessage));

        ResponseCreationOptions options = new();
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        if (instructionMethod == ResponsesTestInstructionMethod.InstructionsProperty)
        {
            options.Instructions = instructions;
        }

        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);
        OpenAIResponse response = await client.CreateResponseAsync(messages, options);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.OutputItems, Is.Not.Null.And.Not.Empty);
        Assert.That(response.OutputItems?[0], Is.InstanceOf<MessageResponseItem>());
        Assert.That((response?.OutputItems?[0] as MessageResponseItem)?.Content, Is.Not.Null.And.Not.Empty);
        Assert.That((response?.OutputItems?[0] as MessageResponseItem)?.Content[0].Text, Does.StartWith("Arr, matey"));

        OpenAIResponse retrievedResponse = await client.GetResponseAsync(response?.Id);
        Assert.That((retrievedResponse?.OutputItems?.FirstOrDefault() as MessageResponseItem)?.Content?.FirstOrDefault()?.Text, Does.StartWith("Arr, matey"));

        if (instructionMethod == ResponsesTestInstructionMethod.InstructionsProperty)
        {
            Assert.That(retrievedResponse?.Instructions, Is.EqualTo(instructions));
        }
        // The AzureOpenAI endpoint does not serve the path for
        // https://{Azure OpenAI endpoint}/responses/{response.Id}/input_items
        //List<ResponseItem> listedItems = [];
        //await foreach (ResponseItem item in client.GetResponseInputItemsAsync(response?.Id))
        //{
        //    listedItems.Add(item);
        //}

        //if (instructionMethod == ResponsesTestInstructionMethod.InstructionsProperty)
        //{
        //    Assert.That(listedItems, Has.Count.EqualTo(1));
        //    Assert.That((listedItems[0] as MessageResponseItem)?.Content?.FirstOrDefault()?.Text, Is.EqualTo(userMessage));
        //}
        //else
        //{
        //    Assert.That(listedItems, Has.Count.EqualTo(2));
        //    MessageResponseItem? systemOrDeveloperMessage = listedItems?[1] as MessageResponseItem;
        //    Assert.That(systemOrDeveloperMessage, Is.Not.Null);
        //    Assert.That(systemOrDeveloperMessage?.Role, Is.EqualTo(instructionMethod switch
        //    {
        //        ResponsesTestInstructionMethod.DeveloperMessage => MessageRole.Developer,
        //        ResponsesTestInstructionMethod.SystemMessage => MessageRole.System,
        //        _ => throw new ArgumentException()
        //    }));
        //    Assert.That(systemOrDeveloperMessage?.Content?.FirstOrDefault()?.Text, Is.EqualTo(instructions));
        //    Assert.That((listedItems?[0] as MessageResponseItem)?.Content?.FirstOrDefault()?.Text, Is.EqualTo(userMessage));
        //}
    }

    [RecordedTest]
    public async Task TwoTurnCrossModel()
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(Gpt4oMiniDeployment);
        OpenAIResponseClient client2 = GetResponseTestClientForDeployment(ComputerUseDeployment);

        ResponseCreationOptions options = new()
        {
            TruncationMode = ResponseTruncationMode.Auto
        };

        OpenAIResponse response = await client.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, Assistant! My name is Travis.")],
            options);
        options.PreviousResponseId = response.Id;
        OpenAIResponse response2 = await client2.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What's my name?")],
            options);
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment, Ignore = "Not yet supported with computer-use-preview")]
    public async Task StructuredOutputs(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new ResponseCreationOptions()
        {
            TextOptions = new ResponseTextOptions()
            {
                TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
                        "data_list",
                        BinaryData.FromString("""
                            {
                              "type": "object",
                              "properties": {
                                "animal_data_list": {
                                  "type": "array",
                                  "items": {
                                    "type": "string"
                                  }
                                }
                              },
                              "required": ["animal_data_list"],
                              "additionalProperties": false
                            }
                            """)),
            }
        };
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            "Write a JSON document with a list of five animals",
            options);

        Assert.That(
            response?.TextOptions?.TextFormat?.Kind,
            Is.EqualTo(ResponseTextFormatKind.JsonSchema));
        Assert.That(response?.OutputItems, Has.Count.EqualTo(1));
        MessageResponseItem? message = response?.OutputItems?[0] as MessageResponseItem;
        Assert.That(message?.Content, Has.Count.EqualTo(1));
        Assert.That(message?.Content[0].Text, Is.Not.Null.And.Not.Empty);

        Assert.DoesNotThrow(() =>
        {
            using JsonDocument document = JsonDocument.Parse(message?.Content?[0].Text!);
            bool hasListElement = document.RootElement.TryGetProperty("animal_data_list", out JsonElement listElement);
            Assert.That(hasListElement, Is.True);
        });
    }

    [RecordedTest]
    [TestCase(ComputerUseDeployment)]
    [TestCase(Gpt4oMiniDeployment)]
    public async Task FunctionCall(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new()
        {
            Tools = { s_GetWeatherAtLocationTool }
        };
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What should I wear for the weather in San Francisco, CA?")],
            options);

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        FunctionCallResponseItem? functionCall = response.OutputItems?[0] as FunctionCallResponseItem;
        Assert.That(functionCall, Is.Not.Null);
        Assert.That(functionCall?.Id, Has.Length.GreaterThan(0));
        Assert.That(functionCall?.FunctionName, Is.EqualTo("get_weather_at_location"));
        Assert.That(functionCall?.FunctionArguments, Is.Not.Null);

        Assert.DoesNotThrow(() =>
        {
            using JsonDocument document = JsonDocument.Parse(functionCall?.FunctionArguments);
            _ = document.RootElement.GetProperty("location");
        });

        options.PreviousResponseId = response.Id;
        ResponseItem functionReply = ResponseItem.CreateFunctionCallOutputItem(functionCall?.CallId, "22 celcius and windy");
        OpenAIResponse turn2Response = await client.CreateResponseAsync(
            [functionReply],
            options);
        Assert.That(turn2Response.OutputItems?.Count, Is.EqualTo(1));
        MessageResponseItem? turn2Message = turn2Response?.OutputItems?[0] as MessageResponseItem;
        Assert.That(turn2Message, Is.Not.Null);
        Assert.That(turn2Message?.Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(turn2Message?.Content, Has.Count.EqualTo(1));
        Assert.That(turn2Message?.Content?[0].Text, Does.Contain("22"));
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task MaxTokens(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new()
        {
            MaxOutputTokenCount = 20,
        };
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        OpenAIResponse response = await client.CreateResponseAsync(
            "Write three haikus about tropical fruit",
            options);

        Assert.That(
            response?.IncompleteStatusDetails?.Reason,
            Is.EqualTo(ResponseIncompleteStatusReason.MaxOutputTokens));
        MessageResponseItem? message = response?.OutputItems?.FirstOrDefault() as MessageResponseItem;
        Assert.That(message?.Content?.FirstOrDefault(), Is.Not.Null);
        Assert.That(message?.Status, Is.EqualTo(MessageStatus.Incomplete));
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task FunctionCallStreaming(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseCreationOptions options = new()
        {
            Tools = { s_GetWeatherAtLocationTool },
        };
        if (deploymentName == ComputerUseDeployment)
        {
            options.TruncationMode = ResponseTruncationMode.Auto;
        }

        await foreach (StreamingResponseUpdate update
            in client.CreateResponseStreamingAsync(
                "What should I wear for the weather in San Francisco right now?",
                options))
        {
            Console.WriteLine(ModelReaderWriter.Write(update).ToString());
            if (update is StreamingResponseCreatedUpdate responseCreatedUpdate)
            {
                Console.WriteLine($"response.created: {responseCreatedUpdate.Response.Id}");
            }
            else if (update is StreamingResponseFunctionCallArgumentsDeltaUpdate functionCallArgumentsDeltaUpdate)
            {
                Console.Write(functionCallArgumentsDeltaUpdate.Delta);
            }
        }
    }

    [RecordedTest]
    [TestCase(Gpt4oMiniDeployment)]
    [TestCase(ComputerUseDeployment)]
    public async Task FunctionToolChoiceWorks(string deploymentName)
    {
        OpenAIResponseClient client = GetResponseTestClientForDeployment(deploymentName);

        ResponseToolChoice toolChoice
            = ResponseToolChoice.CreateFunctionChoice(s_GetWeatherAtLocationToolName);

        ResponseCreationOptions options = new()
        {
            Tools = { s_GetWeatherAtLocationTool },
            ToolChoice = toolChoice,
            TruncationMode = ResponseTruncationMode.Auto,
        };

        OpenAIResponse response = await client.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What should I wear for the weather in San Francisco, CA?")],
            options);

        Assert.That(response.ToolChoice, Is.Not.Null);
        Assert.That(response.ToolChoice.Kind, Is.EqualTo(ResponseToolChoiceKind.Function));
        Assert.That(response.ToolChoice.FunctionName, Is.EqualTo(toolChoice.FunctionName));

        FunctionCallResponseItem? functionCall = response.OutputItems.FirstOrDefault() as FunctionCallResponseItem;
        Assert.That(functionCall, Is.Not.Null);
        Assert.That(functionCall?.FunctionName, Is.EqualTo(toolChoice.FunctionName));
    }

    [RecordedTest]
    [Category("Smoke")]
    public void ItemSerialization()
    {
        foreach (ResponseItem item in new ResponseItem[]
        {
            ResponseItem.CreateComputerCallItem("call_abcd", ComputerCallAction.CreateScreenshotAction(), []),
            ResponseItem.CreateComputerCallOutputItem("call_abcd", ComputerCallOutput.CreateScreenshotOutput("file_abcd")),
            ResponseItem.CreateFileSearchCallItem(["query1"]),
            ResponseItem.CreateFunctionCallItem("call_abcd", "function_name", BinaryData.Empty),
            ResponseItem.CreateFunctionCallOutputItem("call_abcd", "functionOutput"),
            ResponseItem.CreateReasoningItem("summary goes here"),
            ResponseItem.CreateReasoningItem([new ReasoningSummaryTextPart("another summary"), new ReasoningSummaryTextPart("with multiple parts")]),
            ResponseItem.CreateReferenceItem("msg_1234"),
            ResponseItem.CreateAssistantMessageItem("Goodbye!", []),
            ResponseItem.CreateDeveloperMessageItem("Talk like a pirate"),
            ResponseItem.CreateSystemMessageItem("Talk like a ninja"),
            ResponseItem.CreateUserMessageItem("Hello, world"),
        })
        {
            BinaryData serializedItem = ModelReaderWriter.Write(item);
            Assert.That(serializedItem?.ToMemory().IsEmpty, Is.False);
            ResponseItem deserializedItem = ModelReaderWriter.Read<ResponseItem>(serializedItem!)!;
            Assert.That(deserializedItem?.GetType(), Is.EqualTo(item.GetType()));
        }

        AssertSerializationRoundTrip<MessageResponseItem>(
            @"{""type"":""message"",""role"":""potato"",""potato_details"":{""cultivar"":""russet""}}",
            potatoMessage =>
            {
                Assert.That(potatoMessage.Role, Is.EqualTo(MessageRole.Unknown));
                Assert.That(potatoMessage.Content, Has.Count.EqualTo(0));
            });
    }

    [RecordedTest]
    [Category("Smoke")]
    public void ToolChoiceSerialization()
    {
        void AssertChoiceEqual(ResponseToolChoice choice, string expected)
        {
            string serialized = ModelReaderWriter.Write(choice).ToString();
            Assert.That(serialized, Is.EqualTo(expected));
        }
        AssertChoiceEqual(
            ResponseToolChoice.CreateAutoChoice(), @"""auto""");
        AssertChoiceEqual(
            ResponseToolChoice.CreateNoneChoice(), @"""none""");
        AssertChoiceEqual(
            ResponseToolChoice.CreateRequiredChoice(), @"""required""");
        AssertChoiceEqual(
            ResponseToolChoice.CreateFunctionChoice("foo"),
            @"{""type"":""function"",""name"":""foo""}");
        AssertChoiceEqual(
            ResponseToolChoice.CreateFileSearchChoice(),
            @"{""type"":""file_search""}");
        AssertChoiceEqual(
            ResponseToolChoice.CreateComputerChoice(),
            @"{""type"":""computer_use_preview""}");
        AssertChoiceEqual(
            ResponseToolChoice.CreateWebSearchChoice(),
            @"{""type"":""web_search_preview""}");

        Assert.That(
            ModelReaderWriter.Read<ResponseToolChoice>(
                BinaryData.FromString(@"{""type"": ""something_else""}"))!.Kind,
            Is.EqualTo(ResponseToolChoiceKind.Unknown));
    }

    [RecordedTest]
    [Category("Smoke")]
    public void ToolSerialization()
    {
        Assert.That(
            ModelReaderWriter.Read<ResponseTool>(
                BinaryData.FromString(@"{""type"": ""file_search""}")),
            Is.InstanceOf<ResponseTool>());
        Assert.That(
            ModelReaderWriter.Read<ResponseTool>(
                BinaryData.FromString(@"{""type"": ""something_else""}")),
            Is.InstanceOf<ResponseTool>());
    }

    [RecordedTest]
    [Category("Smoke")]
    public void ContentPartSerialization()
    {
        AssertSerializationRoundTrip<ResponseContentPart>(
            @"{""type"":""input_text"",""text"":""hello""}",
            textPart =>
            {
                Assert.That(textPart.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
                Assert.That(textPart.Text, Is.EqualTo("hello"));
            });

        AssertSerializationRoundTrip<ResponseContentPart>(
            @"{""type"":""potato"",""potato_details"":{""cultivar"":""russet""}}",
            potatoPart =>
            {
                Assert.That(potatoPart.Kind, Is.EqualTo(ResponseContentPartKind.Unknown));
                Assert.That(potatoPart.Text, Is.Null);
            });
    }

    [RecordedTest]
    [Category("Smoke")]
    public void TextFormatSerialization()
    {
        AssertSerializationRoundTrip<ResponseTextFormat>(
            @"{""type"":""text""}",
            textFormat => Assert.That(textFormat.Kind == ResponseTextFormatKind.Text));
    }

    public override OpenAIResponseClient GetTestClient(TestClientOptions? options = null, TokenCredential? tokenCredential = null, ApiKeyCredential? keyCredential = null)
    {
        throw new NotImplementedException($"Please use the deployment-specific {nameof(GetResponseTestClientForDeployment)} for this fixture.");
    }

    private OpenAIResponseClient GetResponseTestClientForDeployment(string? deploymentName = null)
    {
        if (deploymentName is null)
        {
            return GetTestClient("responses");
        }
        AzureOpenAIClient toplevelClient = GetTestTopLevelClient(
            TestConfig.GetConfig("responses"));
        return toplevelClient.GetOpenAIResponseClient(deploymentName);
    }

    private static void AssertSerializationRoundTrip<T>(
        string serializedJson,
        Action<T> instanceAssertionsAction)
            where T : class, IJsonModel<T>
    {
        BinaryData jsonBytes = BinaryData.FromString(serializedJson);
        Assert.That(jsonBytes?.ToMemory().IsEmpty, Is.False);
        T? deserializedValue = ModelReaderWriter.Read<T>(jsonBytes!);
        Assert.That(deserializedValue, Is.InstanceOf<T>());
        Assert.Multiple(() =>
        {
            instanceAssertionsAction.Invoke(deserializedValue!);
        });
        BinaryData reserializedBytes = ModelReaderWriter.Write(deserializedValue!);
        Assert.That(reserializedBytes.ToMemory().IsEmpty, Is.False);
        Assert.That(reserializedBytes.ToString(), Is.EqualTo(serializedJson));
    }

    private static readonly string s_GetWeatherAtLocationToolName = "get_weather_at_location";
    private static readonly ResponseTool s_GetWeatherAtLocationTool = ResponseTool.CreateFunctionTool(
            s_GetWeatherAtLocationToolName,
            functionDescription: "Gets the weather at a specified location, optionally specifying units for temperature",
            functionParameters: BinaryData.FromString("""
                {
                    "type": "object",
                    "properties": {
                    "location": {
                        "type": "string"
                    },
                    "unit": {
                        "type": "string",
                        "enum": ["C", "F", "K"]
                    }
                    },
                    "required": ["location"]
                }
                """),
            strictModeEnabled: false);
}
