// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using OpenAI.Chat;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests;

public partial class ChatTests
{
    [Obsolete]
    private static readonly ChatFunction FUNCTION_TEMPERATURE = new("get_future_temperature") {
        FunctionDescription = "requests the anticipated future temperature at a provided location to help inform advice about topics like choice of attire",
        FunctionParameters = BinaryData.FromString(
            """
            {
                "type": "object",
                "properties": {
                    "locationName": {
                        "type": "string",
                        "description": "the name or brief description of a location for weather information"
                    },
                    "date": {
                        "type": "string",
                        "description": "the day, month, and year for which to retrieve weather information"
                    }
                }
            }
            """)};

    public enum FunctionCallTestType
    {
        Auto,
        None,
        Function,
    }

    [RecordedTest]
    [TestCase(FunctionCallTestType.None)]
    [TestCase(FunctionCallTestType.Auto)]
    [TestCase(FunctionCallTestType.Function)]
    [Obsolete]
    public async Task SimpleFunctionCallWorks(FunctionCallTestType functionCallType)
    {
        ChatClient client = GetTestClient();

        List<ChatMessage> messages = new()
        {
            new SystemChatMessage("You are a helpful assistant."),
            new UserChatMessage("What should I wear in Honolulu next Thursday?")
        };
        var requestOptions = new ChatCompletionOptions()
        {
            FunctionChoice = functionCallType switch
            {
                FunctionCallTestType.Auto => ChatFunctionChoice.CreateAutoChoice(),
                FunctionCallTestType.None => ChatFunctionChoice.CreateNoneChoice(),
                FunctionCallTestType.Function => ChatFunctionChoice.CreateNamedChoice(FUNCTION_TEMPERATURE.FunctionName),
                _ => throw new NotImplementedException(),
            },
            Functions = { FUNCTION_TEMPERATURE },
            MaxOutputTokenCount = 512,
        };

        ClientResult<ChatCompletion> response = await client.CompleteChatAsync(messages, requestOptions);
        Assert.That(response, Is.Not.Null);

        ChatCompletion completion = response.Value;
        Assert.IsNotNull(completion);
        Assert.That(completion.Id, Is.Not.Null.Or.Empty);

        RequestContentFilterResult filter = completion.GetRequestContentFilterResult();
        Assert.IsNotNull(filter);
        Assert.That(filter.SelfHarm, Is.Not.Null);
        Assert.That(filter.SelfHarm.Filtered, Is.False);
        Assert.That(filter.SelfHarm.Severity, Is.EqualTo(ContentFilterSeverity.Safe));

        if (functionCallType == FunctionCallTestType.None)
        {
            Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
            Assert.That(completion.FunctionCall, Is.Null);

            Assert.That(completion.Content, Has.Count.GreaterThan(0));
            Assert.That(completion.Content, Has.All.Not.Null);

            ChatMessageContentPart content = completion.Content[0];
            Assert.That(content.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
            Assert.That(content.Text, Is.Not.Null.Or.Empty);

            // test complete, as we were merely validating that we didn't get what we shouldn't
            return;
        }

        // TODO old tests look for stop reason of function_call for both auto and function, but the service currently returns "stop"
        // for function
        if (functionCallType == FunctionCallTestType.Auto)
        {
            Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.FunctionCall));
        }
        else
        {
            Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        }

        Assert.That(completion.Content, Has.Count.EqualTo(0));

        Assert.That(completion.FunctionCall, Is.Not.Null);
        Assert.That(completion.FunctionCall.FunctionName, Is.EqualTo(FUNCTION_TEMPERATURE.FunctionName));
        Assert.That(completion.FunctionCall.FunctionArguments, Is.Not.Null);
        var parsedArgs = JsonSerializer.Deserialize<TemperatureFunctionRequestArguments>(completion.FunctionCall.FunctionArguments, SERIALIZER_OPTIONS)!;
        Assert.That(parsedArgs, Is.Not.Null);
        Assert.That(parsedArgs.LocationName, Is.Not.Null.Or.Empty);
        Assert.That(parsedArgs.Date, Is.Not.Null.Or.Empty);

        // Complete the function call
        messages.Add(new AssistantChatMessage(completion.FunctionCall));
        messages.Add(new FunctionChatMessage(FUNCTION_TEMPERATURE.FunctionName, JsonSerializer.Serialize(new
        {
            temperature = 31,
            unit = "celsius"
        })));

        requestOptions = new()
        {
            Functions = { FUNCTION_TEMPERATURE },
            MaxOutputTokenCount = 512,
        };

        completion = await client.CompleteChatAsync(messages, requestOptions);
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));

        ResponseContentFilterResult responseFilter = completion.GetResponseContentFilterResult();
        Assert.That(responseFilter, Is.Not.Null);
        Assert.That(responseFilter.Hate, Is.Not.Null);
        Assert.That(responseFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        Assert.That(responseFilter.Hate.Filtered, Is.False);

        Assert.That(completion.Content, Has.Count.GreaterThan(0));
        Assert.That(completion.Content[0], Is.Not.Null);
        Assert.That(completion.Content[0].Text, Is.Not.Null.Or.Empty);
        Assert.That(completion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
    }

    [RecordedTest]
    [TestCase(FunctionCallTestType.None)]
    [TestCase(FunctionCallTestType.Auto)]
    [TestCase(FunctionCallTestType.Function)]
    [Obsolete]
    public async Task SimpleFunctionCallWorksStreaming(FunctionCallTestType functionCallType)
    {
        StringBuilder content = new();
        bool foundPromptFilter = false;
        bool foundResponseFilter = false;
        string? functionName = null;
        StringBuilder functionArgs = new();

        ChatClient client = GetTestClient();

        List<ChatMessage> messages = new()
        {
            new SystemChatMessage("You are a helpful assistant."),
            new UserChatMessage("What should I wear in Honolulu next Thursday?")
        };
        var requestOptions = new ChatCompletionOptions()
        {
            FunctionChoice = functionCallType switch
            {
                FunctionCallTestType.Auto => ChatFunctionChoice.CreateAutoChoice(),
                FunctionCallTestType.None => ChatFunctionChoice.CreateNoneChoice(),
                FunctionCallTestType.Function => ChatFunctionChoice.CreateNamedChoice(FUNCTION_TEMPERATURE.FunctionName),
                _ => throw new NotImplementedException(),
            },
            Functions = { FUNCTION_TEMPERATURE },
            MaxOutputTokenCount = 512,
        };

        Action<StreamingChatCompletionUpdate> validateUpdate = (update) =>
        {
            Assert.That(update.ContentUpdate, Is.Not.Null);
            Assert.That(update.ContentUpdate, Has.All.Not.Null);

            if (update.FunctionCallUpdate != null)
            {
                Assert.That(update.FunctionCallUpdate.FunctionName, Is.Null.Or.EqualTo(FUNCTION_TEMPERATURE.FunctionName));
                functionName ??= update.FunctionCallUpdate.FunctionName; 

                Assert.That(update.FunctionCallUpdate.FunctionArgumentsUpdate, Is.Not.Null);
                if (!update.FunctionCallUpdate.FunctionArgumentsUpdate.ToMemory().IsEmpty)
                {
                    functionArgs.Append(update.FunctionCallUpdate.FunctionArgumentsUpdate.ToString());
                }
            }

            foreach (var part in update.ContentUpdate)
            {
                Assert.That(part.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
                Assert.That(part.Text, Is.Not.Null); // Could be empty string

                content.Append(part.Text);
            }

            var promptFilter = update.GetRequestContentFilterResult();
            if (!foundPromptFilter && promptFilter?.Hate != null)
            {
                Assert.That(promptFilter.Hate.Filtered, Is.False);
                Assert.That(promptFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                foundPromptFilter = true;
            }

            var responseFilter = update.GetResponseContentFilterResult();
            if (!foundResponseFilter && responseFilter?.Hate != null)
            {
                Assert.That(responseFilter.Hate.Filtered, Is.False);
                Assert.That(responseFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                foundResponseFilter = true;
            }
        };

        AsyncCollectionResult<StreamingChatCompletionUpdate> response = client.CompleteChatStreamingAsync(messages, requestOptions);
        Assert.That(response, Is.Not.Null);

        await foreach (StreamingChatCompletionUpdate update in response)
        {
            validateUpdate(update);
        }

        Assert.That(foundPromptFilter, Is.True);

        if (functionCallType != FunctionCallTestType.None)
        {
            Assert.That(functionName, Is.Not.Null);
            var parsedArgs = JsonSerializer.Deserialize<TemperatureFunctionRequestArguments>(functionArgs.ToString(), SERIALIZER_OPTIONS)!;
            Assert.That(parsedArgs, Is.Not.Null);
            Assert.That(parsedArgs.LocationName, Is.Not.Null.Or.Empty);
            Assert.That(parsedArgs.Date, Is.Not.Null.Or.Empty);

            // TODO FIXME: There isn't a clear or obvious way to pass the assistant function message back to the service, and the constructors that allow
            //             us manual control are internal. So let's use JSON.
            var converted = ModelReaderWriter.Read<ChatFunctionCall>(BinaryData.FromString(JsonSerializer.Serialize(new { name = functionName, arguments = functionArgs.ToString() })));
            messages.Add(new AssistantChatMessage(converted));
            messages.Add(new FunctionChatMessage(FUNCTION_TEMPERATURE.FunctionName, JsonSerializer.Serialize(new
            {
                temperature = 31,
                unit = "celsius"
            })));

            requestOptions = new()
            {
                Functions = { FUNCTION_TEMPERATURE },
                MaxOutputTokenCount = requestOptions.MaxOutputTokenCount,
            };

            content.Clear();
            foundPromptFilter = false;
            foundResponseFilter = false;
            functionName = null;
            functionArgs.Clear();

            response = client.CompleteChatStreamingAsync(messages, requestOptions);
            Assert.That(response, Is.Not.Null);

            await foreach (StreamingChatCompletionUpdate update in response)
            {
                validateUpdate(update);
            }
        }

        Assert.That(foundPromptFilter, Is.True);
        Assert.That(foundResponseFilter, Is.True);
        Assert.That(functionName, Is.Null);
        Assert.That(functionArgs, Has.Length.EqualTo(0));
        Assert.That(content.ToString(), Is.Not.Null.Or.Empty);
    }
}
