// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public class AssistantsModelFactoryTests
{
    [TestCase]
    public void CanMakeListOfAssistants()
    {
        // AssistantsClient mockClient = new(openAIApiKey: "mock");
        // _ = mockClient.GetAssistants();

        string[] assistantIds = new string[] { "first_assistant_id", "second_assistant_id", "last_assistant_id" };
        string[] assistantNames = new string[] { "first assistant name", "second assistant name", "last assistant name" };
        string[] assistantDescriptions = new string[]
        {
            "description of the first assistant",
            "description of the second assistant",
            "description of the last assistant",
        };
        string[] assistantInstructions = new string[]
        {
            "instructions for the first assistant",
            "instructions for the second assistant",
            "instructions for the last assistant",
        };
        string[] assistantModels = new string[] { "first_assistant_model", "second_assistant_model", "last_assistant_model" };
        DateTime[] assistantCreationTimes = new DateTime[]
        {
            DateTime.Now - TimeSpan.FromHours(1),
            DateTime.Now - TimeSpan.FromMinutes(30),
            DateTime.Now - TimeSpan.FromSeconds(30),
        };
        string[][] assistantFileIds = new string[][]
        {
            new string[] { "first_assistant_file_id_1", "first_assistant_file_id_2" },
            null,
            new string[] { "last_assistant_file_id_1" },
        };
        Dictionary<string, string>[] assistantMetadata = new Dictionary<string, string>[]
        {
            new()
            {
                ["first_assistant_metadata_key_1"] = "first_assistant_metadata_value_1",
                ["first_assistant_metadata_key_2"] = "first_assistant_metadata_value_2",
            },
            null,
            new()
            {
                ["second_assistant_metadata_key_1"] = "second_assistant_metadata_value_1",
            },
        };
        ToolDefinition[][] assistantTools = new ToolDefinition[][]
        {
            new ToolDefinition[]
            {
                new FunctionToolDefinition("first_assistant_function_name", "description of first assistant's function tool"),
            },
            null,
            new ToolDefinition[]
            {
                new FunctionToolDefinition(
                    "last_assistant_function_name",
                    "description of last assistant",
                    BinaryData.FromObjectAsJson(new { type = "object" })),
                new RetrievalToolDefinition(),
            },
        };

        List<Assistant> data = new();
        for (int i = 0; i < assistantIds.Length; i++)
        {
            data.Add(AssistantsModelFactory.Assistant(
                id: assistantIds[i],
                name: assistantNames[i],
                description: assistantDescriptions[i],
                createdAt: assistantCreationTimes[i],
                instructions: assistantInstructions[i],
                tools: assistantTools[i],
                model: assistantModels[i],
                fileIds: assistantFileIds[i],
                metadata: assistantMetadata[i]));
        }
        PageableList<Assistant> assistants = AssistantsModelFactory.PageableList(
            data,
            assistantIds[0],
            assistantIds[assistantIds.Length - 1],
            hasMore: false);

        Assert.That(assistants.FirstId, Is.EqualTo(assistantIds[0]));
        Assert.That(assistants.LastId, Is.EqualTo(assistantIds[assistantIds.Length - 1]));
        Assert.That(assistants.HasMore, Is.EqualTo(false));

        Assert.That(assistants.Data.Count, Is.EqualTo(assistantIds.Length));
        for (int i = 0; i < assistants.Data.Count; i++)
        {
            Assert.That(assistants[i], Is.EqualTo(assistants.Data[i]));
            Assert.That(assistants[i].Id, Is.EqualTo(assistantIds[i]));
            Assert.That(assistants[i].Name, Is.EqualTo(assistantNames[i]));
            Assert.That(assistants[i].Description, Is.EqualTo(assistantDescriptions[i]));
            Assert.That(assistants[i].CreatedAt.ToString("o"), Is.EqualTo(assistantCreationTimes[i].ToString("o")));
            Assert.That(assistants[i].Instructions, Is.EqualTo(assistantInstructions[i]));
            Assert.That(assistants[i].Model, Is.EqualTo(assistantModels[i]));
            Assert.That(assistants[i].FileIds?.Count ?? 0, Is.EqualTo(assistantFileIds[i]?.Length ?? 0));
            if (assistants[i].FileIds != null)
            {
                for (int fileIdIndex = 0; fileIdIndex < assistants[i].FileIds.Count; fileIdIndex++)
                {
                    Assert.That(assistants[i].FileIds[fileIdIndex], Is.EqualTo(assistantFileIds[i][fileIdIndex]));
                }
            }
            Assert.That(assistants[i].Metadata?.Count ?? 0, Is.EqualTo(assistantMetadata[i]?.Count ?? 0));
            if (assistantMetadata[i] != null)
            {
                foreach (KeyValuePair<string, string> expectedKeyValuePair in assistantMetadata[i])
                {
                    Assert.That(assistants[i].Metadata.ContainsKey(expectedKeyValuePair.Key), Is.True);
                    Assert.That(assistants[i].Metadata[expectedKeyValuePair.Key], Is.EqualTo(expectedKeyValuePair.Value));
                }
            }
            Assert.That(assistants[i].Tools?.Count ?? 0, Is.EqualTo(assistantTools[i]?.Length ?? 0));
            if (assistantTools[i] != null)
            {
                Assert.That(assistants[i].Tools.Count, Is.EqualTo(assistantTools[i].Length));
                for (int toolIndex = 0; toolIndex < assistants[i].Tools.Count; toolIndex++)
                {
                    if (assistants[i].Tools[toolIndex] is FunctionToolDefinition functionTool)
                    {
                        FunctionToolDefinition expectedFunctionTool = assistantTools[i][toolIndex] as FunctionToolDefinition;
                        Assert.That(expectedFunctionTool, Is.Not.Null);
                        Assert.That(functionTool.Name, Is.EqualTo(expectedFunctionTool.Name));
                        Assert.That(functionTool.Description, Is.EqualTo(expectedFunctionTool.Description));
                        Assert.That(functionTool.Parameters.ToString(), Is.EqualTo(expectedFunctionTool.Parameters.ToString()));
                    }
                    else if (assistants[i].Tools[toolIndex] is RetrievalToolDefinition retrievalTool)
                    {
                        RetrievalToolDefinition expectedRetrievalTool = assistantTools[i][toolIndex] as RetrievalToolDefinition;
                        Assert.That(expectedRetrievalTool, Is.Not.Null);
                    }
                    else if (assistants[i].Tools[toolIndex] is CodeInterpreterToolDefinition codeInterpreterTool)
                    {
                        CodeInterpreterToolDefinition expectedCodeInterpreterTool = assistantTools[i][toolIndex] as CodeInterpreterToolDefinition;
                        Assert.That(expectedCodeInterpreterTool, Is.Not.Null);
                    }
                    else
                    {
                        Assert.Fail($"Unhandled assistant tool definition type: {assistants[i].Tools[toolIndex]}");
                    }
                }
            }
        }
    }

    [TestCase]
    public void CanMakeThread()
    {
        // _ = mockClient.GetThread(mockThreadId);

        string threadId = "first_thread_id";
        Dictionary<string, string> threadMetadata = new Dictionary<string, string>()
        {
            ["first_thread_metadata_key"] = "first_thread_metadata_value",
        };
        AssistantThread mockThread = AssistantsModelFactory.AssistantThread(
            id: threadId,
            metadata: threadMetadata);
        Assert.That(mockThread.Id, Is.EqualTo(threadId));
        Assert.That(mockThread.Metadata?.Count ?? 0, Is.EqualTo(threadMetadata?.Count ?? 0));
        foreach (KeyValuePair<string, string> expectedKeyValuePair in threadMetadata)
        {
            Assert.That(mockThread.Metadata.ContainsKey(expectedKeyValuePair.Key), Is.True);
            Assert.That(mockThread.Metadata[expectedKeyValuePair.Key], Is.EqualTo(expectedKeyValuePair.Value));
        }
    }

    [TestCase]
    public void CanCreateToolCalls()
    {
        string functionToolCallId = "function_tool_call_id";
        string functionCallName = "function_call_name";
        string functionCallArguments = "function_call_arguments";
        string functionCallOutput = "function_call_output";
        RunStepFunctionToolCall mockFunctionToolCall = AssistantsModelFactory.RunStepFunctionToolCall(
            functionToolCallId,
            functionCallName,
            functionCallArguments,
            functionCallOutput);
        Assert.That(mockFunctionToolCall.Id, Is.EqualTo(functionToolCallId));
        Assert.That(mockFunctionToolCall.Name, Is.EqualTo(functionCallName));
        Assert.That(mockFunctionToolCall.Arguments, Is.EqualTo(functionCallArguments));
        Assert.That(mockFunctionToolCall.Output, Is.EqualTo(functionCallOutput));

        string codeInterpreterToolCallId = "code_interpreter_tool_call_id";
        string codeInterpreterToolCallInput = "code_interprter_tool_call_input";
        string codeInterpreterLogOutput = "code_interpreter_log_output";
        string codeInterpreterImageOutputFileId = "code_interpreter_image_file_id";
        RunStepCodeInterpreterToolCallOutput[] codeInterpreterOutputs = new RunStepCodeInterpreterToolCallOutput[]
        {
            AssistantsModelFactory.RunStepCodeInterpreterLogOutput(codeInterpreterLogOutput),
            AssistantsModelFactory.RunStepCodeInterpreterImageOutput(
                AssistantsModelFactory.RunStepCodeInterpreterImageReference(codeInterpreterImageOutputFileId)),
        };
        RunStepCodeInterpreterToolCall mockCodeInterpreterToolCall = AssistantsModelFactory.RunStepCodeInterpreterToolCall(
            codeInterpreterToolCallId,
            codeInterpreterToolCallInput,
            codeInterpreterOutputs);
        Assert.That(mockCodeInterpreterToolCall.Id, Is.EqualTo(codeInterpreterToolCallId));
        Assert.That(mockCodeInterpreterToolCall.Input, Is.EqualTo(codeInterpreterToolCallInput));
        Assert.That(mockCodeInterpreterToolCall.Outputs.Count, Is.EqualTo(codeInterpreterOutputs.Length));
        foreach (RunStepCodeInterpreterToolCallOutput callOutput in mockCodeInterpreterToolCall.Outputs)
        {
            if (callOutput is RunStepCodeInterpreterLogOutput logOutput)
            {
                Assert.That(logOutput.Logs, Is.EqualTo(codeInterpreterLogOutput));
            }
            else if (callOutput is RunStepCodeInterpreterImageOutput imageOutput)
            {
                Assert.That(imageOutput.Image.FileId, Is.EqualTo(codeInterpreterImageOutputFileId));
            }
            else
            {
                Assert.Fail($"Unexpected code interpreter call type: {callOutput}");
            }
        }

        string retrievalToolCallId = "retrieval_tool_call_id";
        Dictionary<string, string> retrievalToolCallRetrievals = new()
        {
            ["retrieval_key"] = "retrieval_value",
        };
        RunStepRetrievalToolCall mockRetrievalToolCall = AssistantsModelFactory.RunStepRetrievalToolCall(retrievalToolCallId, retrievalToolCallRetrievals);
        Assert.That(mockRetrievalToolCall.Id, Is.EqualTo(retrievalToolCallId));
        Assert.That(mockRetrievalToolCall.Retrieval.Count, Is.EqualTo(retrievalToolCallRetrievals.Count));
        foreach (KeyValuePair<string, string> expectedRetrievalKeyValuePair in retrievalToolCallRetrievals)
        {
            Assert.That(mockRetrievalToolCall.Retrieval.ContainsKey(expectedRetrievalKeyValuePair.Key));
            Assert.That(mockRetrievalToolCall.Retrieval[expectedRetrievalKeyValuePair.Key], Is.EqualTo(expectedRetrievalKeyValuePair.Value));
        }
    }

    [TestCase]
    public void CanInstantiateTypes()
    {
        // Placeholder pending deeper tests
        OpenAIFile mockFile = AssistantsModelFactory.OpenAIFile("id", size: 123, "filename", DateTime.Now, OpenAIFilePurpose.Assistants);
        MessageFile mockMessageFile = AssistantsModelFactory.MessageFile("id", DateTime.Now, "messageId");
        RunError mockRunError = AssistantsModelFactory.RunError("errorCode", "errorMessage");
        RunStepDetails mockRunStepDetails = AssistantsModelFactory.RunStepMessageCreationDetails(
            AssistantsModelFactory.RunStepMessageCreationReference("messageId"));
        RunStepDetails mockRunStepToolCallDetails = AssistantsModelFactory.RunStepToolCallDetails(new RunStepToolCall[] { AssistantsModelFactory.RunStepRetrievalToolCall("id", null) });
        RunStepError mockRunStepError = AssistantsModelFactory.RunStepError("errorCode", "errorMessage");
        RunStep mockRunStep = AssistantsModelFactory.RunStep(
            "id",
            RunStepType.MessageCreation,
            "assistantId",
            "threadId",
            "runId",
            RunStepStatus.Completed,
            mockRunStepDetails,
            mockRunStepError,
            DateTime.Now,
            DateTime.Now - TimeSpan.FromSeconds(10),
            DateTime.Now + TimeSpan.FromSeconds(10),
            cancelledAt: null,
            failedAt: null,
            metadata: null);
        ThreadMessage mockMessage = AssistantsModelFactory.ThreadMessage(
            "id",
            DateTime.Now,
            "threadId",
            MessageRole.Assistant,
            new MessageContent[]
            {
                AssistantsModelFactory.MessageTextContent(
                    "text",
                    new MessageTextAnnotation[]
                    {
                        AssistantsModelFactory.MessageFileCitationTextAnnotation("text", 0, 2, "fileId", "quote"),
                        AssistantsModelFactory.MessageFilePathTextAnnotation("text", 0, 2, "fileId"),
                    }),
                AssistantsModelFactory.MessageImageFileContent("fileId"),
            },
            "assistantId",
            "runId",
            fileIds: null,
            metadata: null);
        ThreadRun mockRun = AssistantsModelFactory.ThreadRun(
            "id",
            "threadId",
            "assistantId",
            RunStatus.Completed,
            AssistantsModelFactory.SubmitToolOutputsAction(
                new RequiredToolCall[]
                {
                    AssistantsModelFactory.RequiredFunctionToolCall("id", "name", "arguments"),
                }),
                mockRunError,
                "model",
                "instructions",
                tools: null,
                fileIds: null,
                DateTime.Now,
                DateTime.Now + TimeSpan.FromSeconds(10),
                startedAt: null,
                completedAt: null,
                cancelledAt: null,
                failedAt: null,
                metadata: null);
    }
}
