// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This file restores substantial portions of generated model factory surface lost via type customization and
 * visibility adjustments.
 */

[CodeGenType("AIOpenAIAssistantsModelFactory")]
public static partial class AssistantsModelFactory
{
    /// <summary> Initializes a new instance of <see cref="Assistants.Assistant"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="name"> The name of the assistant. </param>
    /// <param name="description"> The description of the assistant. </param>
    /// <param name="model"> The ID of the model to use. </param>
    /// <param name="instructions"> The system instructions for the assistant to use. </param>
    /// <param name="tools"> The collection of tools enabled for the assistant. </param>
    /// <param name="fileIds"> A list of attached file IDs, ordered by creation date in ascending order. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <returns> A new <see cref="Assistants.Assistant"/> instance for mocking. </returns>
    public static Assistant Assistant(string id = null, DateTimeOffset createdAt = default, string name = null, string description = null, string model = null, string instructions = null, IEnumerable<ToolDefinition> tools = null, IEnumerable<string> fileIds = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        tools ??= new List<ToolDefinition>();
        fileIds ??= new List<string>();
        metadata ??= new Dictionary<string, string>();

        return new Assistant(
            id,
            @object: null,
            createdAt,
            name,
            description,
            model,
            instructions, tools?.ToList(),
            fileIds?.ToList(),
            metadata,
            serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.AssistantFile"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="assistantId"> The assistant ID that the file is attached to. </param>
    /// <returns> A new <see cref="Assistants.AssistantFile"/> instance for mocking. </returns>
    public static AssistantFile AssistantFile(string id = null, DateTimeOffset createdAt = default, string assistantId = null)
    {
        return new AssistantFile(id, createdAt, assistantId);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.AssistantThread"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <returns> A new <see cref="Assistants.AssistantThread"/> instance for mocking. </returns>
    public static AssistantThread AssistantThread(string id = null, DateTimeOffset createdAt = default, IReadOnlyDictionary<string, string> metadata = null)
    {
        metadata ??= new Dictionary<string, string>();

        return new AssistantThread(id, @object: null, createdAt, metadata, serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.MessageFile"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="messageId"> The ID of the message that this file is attached to. </param>
    /// <returns> A new <see cref="Assistants.MessageFile"/> instance for mocking. </returns>
    public static MessageFile MessageFile(string id = null, DateTimeOffset createdAt = default, string messageId = null)
    {
        return new MessageFile(id, createdAt, messageId);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.ThreadRun"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="threadId"> The ID of the thread associated with this run. </param>
    /// <param name="assistantId"> The ID of the assistant associated with the thread this run was performed against. </param>
    /// <param name="status"> The status of the assistant thread run. </param>
    /// <param name="requiredAction"> The details of the action required for the assistant thread run to continue. </param>
    /// <param name="lastError"> The last error, if any, encountered by this assistant thread run. </param>
    /// <param name="model"> The ID of the model to use. </param>
    /// <param name="instructions"> The overridden system instructions used for this assistant thread run. </param>
    /// <param name="tools"> The overridden enabled tools used for this assistant thread run. </param>
    /// <param name="fileIds"> A list of attached file IDs, ordered by creation date in ascending order. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="expiresAt"> The Unix timestamp, in seconds, representing when this item expires. </param>
    /// <param name="startedAt"> The Unix timestamp, in seconds, representing when this item was started. </param>
    /// <param name="completedAt"> The Unix timestamp, in seconds, representing when this completed. </param>
    /// <param name="cancelledAt"> The Unix timestamp, in seconds, representing when this was cancelled. </param>
    /// <param name="failedAt"> The Unix timestamp, in seconds, representing when this failed. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <returns> A new <see cref="Assistants.ThreadRun"/> instance for mocking. </returns>
    public static ThreadRun ThreadRun(string id = null, string threadId = null, string assistantId = null, RunStatus status = default, RequiredAction requiredAction = null, RunError lastError = null, string model = null, string instructions = null, IEnumerable<ToolDefinition> tools = null, IEnumerable<string> fileIds = null, DateTimeOffset createdAt = default, DateTimeOffset? expiresAt = null, DateTimeOffset? startedAt = null, DateTimeOffset? completedAt = null, DateTimeOffset? cancelledAt = null, DateTimeOffset? failedAt = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        tools ??= new List<ToolDefinition>();
        fileIds ??= new List<string>();
        metadata ??= new Dictionary<string, string>();

        return new ThreadRun(id, @object: null, threadId, assistantId, status, requiredAction, lastError, model, instructions, tools?.ToList(), fileIds?.ToList(), createdAt, expiresAt, startedAt, completedAt, cancelledAt, failedAt, metadata, serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.OpenAIFile"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="size"> The size of the file, in bytes. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="purpose"> The intended purpose of a file. </param>
    /// <returns> A new <see cref="Assistants.OpenAIFile"/> instance for mocking. </returns>
    public static OpenAIFile OpenAIFile(string id = null, int size = default, string filename = null, DateTimeOffset createdAt = default, OpenAIFilePurpose purpose = default)
    {
        return new OpenAIFile(id, size, filename, createdAt, purpose);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.RunStep"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="type"> The type of run step, which can be either message_creation or tool_calls. </param>
    /// <param name="assistantId"> The ID of the assistant associated with the run step. </param>
    /// <param name="threadId"> The ID of the thread that was run. </param>
    /// <param name="runId"> The ID of the run that this run step is a part of. </param>
    /// <param name="status"> The status of this run step. </param>
    /// <param name="stepDetails"> The details for this run step. </param>
    /// <param name="lastError"> If applicable, information about the last error encountered by this run step. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="expiredAt"> The Unix timestamp, in seconds, representing when this item expired. </param>
    /// <param name="completedAt"> The Unix timestamp, in seconds, representing when this completed. </param>
    /// <param name="cancelledAt"> The Unix timestamp, in seconds, representing when this was cancelled. </param>
    /// <param name="failedAt"> The Unix timestamp, in seconds, representing when this failed. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <returns> A new <see cref="Assistants.RunStep"/> instance for mocking. </returns>
    public static RunStep RunStep(string id = null, RunStepType type = default, string assistantId = null, string threadId = null, string runId = null, RunStepStatus status = default, RunStepDetails stepDetails = null, RunStepError lastError = null, DateTimeOffset createdAt = default, DateTimeOffset? expiredAt = null, DateTimeOffset? completedAt = null, DateTimeOffset? cancelledAt = null, DateTimeOffset? failedAt = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        metadata ??= new Dictionary<string, string>();

        return new RunStep(id, @object: null, type, assistantId, threadId, runId, status, stepDetails, lastError, createdAt, expiredAt, completedAt, cancelledAt, failedAt, metadata, serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Assistants.ThreadMessage"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="threadId"> The ID of the thread that this message belongs to. </param>
    /// <param name="role"> The role associated with the assistant thread message. </param>
    /// <param name="contentItems"> The list of content items associated with the assistant thread message. </param>
    /// <param name="assistantId"> If applicable, the ID of the assistant that authored this message. </param>
    /// <param name="runId"> If applicable, the ID of the run associated with the authoring of this message. </param>
    /// <param name="fileIds">
    /// A list of file IDs that the assistant should use. Useful for tools like retrieval and code_interpreter that can
    /// access files.
    /// </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <returns> A new <see cref="Assistants.ThreadMessage"/> instance for mocking. </returns>
    public static ThreadMessage ThreadMessage(string id = null, DateTimeOffset createdAt = default, string threadId = null, MessageRole role = default, IEnumerable<MessageContent> contentItems = null, string assistantId = null, string runId = null, IEnumerable<string> fileIds = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        contentItems ??= new List<MessageContent>();
        fileIds ??= new List<string>();
        metadata ??= new Dictionary<string, string>();

        return new ThreadMessage(id, @object: null, createdAt, threadId, role, contentItems?.ToList(), assistantId, runId, fileIds?.ToList(), metadata, serializedAdditionalRawData: null);
    }

    public static RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments)
    {
        return new RequiredFunctionToolCall(toolCallId, new InternalRequiredFunctionToolCallDetails(functionName, functionArguments));
    }

    public static RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output)
    {
        return new RunStepFunctionToolCall(id, new InternalRunStepFunctionToolCallDetails(name, arguments, output));
    }

    public static RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, IReadOnlyList<RunStepCodeInterpreterToolCallOutput> outputs)
    {
        return new RunStepCodeInterpreterToolCall(id, new InternalCodeInterpreterToolCallDetails(input, outputs));
    }

    /// <summary>
    /// Instantiates a new instance of <see cref="Assistants.SubmitToolOutputsAction"/>.
    /// </summary>
    /// <param name="toolCalls"> The tool calls to include in the mocked action. </param>
    /// <returns> A new instance of SubmitToolOutputsAction. </returns>
    public static SubmitToolOutputsAction SubmitToolOutputsAction(IEnumerable<RequiredToolCall> toolCalls)
    {
        return new SubmitToolOutputsAction(new InternalSubmitToolOutputsDetails(toolCalls));
    }

    /// <summary>
    /// Creates a new instance of MessageTextContent.
    /// </summary>
    /// <param name="text"> The text for the content item. </param>
    /// <param name="annotations"> The annotations for the content item. </param>
    /// <returns> A new instance of MessageTextContent. </returns>
    public static MessageTextContent MessageTextContent(string text, IEnumerable<MessageTextAnnotation> annotations)
    {
        return new MessageTextContent(new InternalMessageTextDetails(text, annotations));
    }

    /// <summary>
    /// Creates a new instance of MessageImageFileContent.
    /// </summary>
    /// <param name="fileId"> The file ID for the image file content. </param>
    /// <returns> A new instance of MessageImageFileContent. </returns>
    public static MessageImageFileContent MessageImageFileContent(string fileId)
    {
        return new MessageImageFileContent(new InternalMessageImageFileDetails(new InternalMessageImageFileIdDetails(fileId)));
    }

    /// <summary>
    /// Creates a new instance of MessageFileCitationTextAnnotation.
    /// </summary>
    /// <param name="text"> The text for the citation. </param>
    /// <param name="startIndex"> The start index of the citation. </param>
    /// <param name="endIndex"> The end index of the citation. </param>
    /// <param name="fileId"> The file ID for the citation. </param>
    /// <param name="quote"> The quote for the citation. </param>
    /// <returns> A new instance of MessageFileCitationTextAnnotation. </returns>
    public static MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, int startIndex, int endIndex, string fileId, string quote)
    {
        return new MessageTextFileCitationAnnotation(text, startIndex, endIndex, new InternalMessageTextFileCitationDetails(fileId, quote));
    }

    /// <summary>
    /// Creates a new instance of MessageFilePathTextAnnotation.
    /// </summary>
    /// <param name="text"> The text for the annotation. </param>
    /// <param name="startIndex"> The start index for the annotation. </param>
    /// <param name="endIndex"> The end index for the annotation. </param>
    /// <param name="fileId"> The file ID for the annotation. </param>
    /// <returns> A new instance of MessageFilePathTextAnnotation. </returns>
    public static MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, int startIndex, int endIndex, string fileId)
    {
        return new MessageTextFilePathAnnotation(text, startIndex, endIndex, new InternalMessageTextFilePathDetails(fileId));
    }

    /// <summary>
    /// Creates a new instance of PageableList<typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The data type of the listed items. </typeparam>
    /// <param name="data"> The items for the list. </param>
    /// <param name="firstId"> The ID of the first item in the list. </param>
    /// <param name="lastId"> The ID of the last item in the list. </param>
    /// <param name="hasMore"> Whether more items not included in the list exist. </param>
    /// <returns> A new instance of PageableList<typeparamref name="T"/>. </returns>
    public static PageableList<T> PageableList<T>(IReadOnlyList<T> data, string firstId, string lastId, bool hasMore)
        => new(data, firstId, lastId, hasMore);
}
