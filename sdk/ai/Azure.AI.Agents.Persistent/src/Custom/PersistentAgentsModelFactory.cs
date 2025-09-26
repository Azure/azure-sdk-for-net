// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This file restores substantial portions of generated model factory surface lost via type customization and
 * visibility adjustments.
 */
[CodeGenClient("AIAgentsPersistentModelFactory")]
public static partial class PersistentAgentsModelFactory
{
    /// <summary> Initializes a new instance of <see cref="Azure.AI.Agents.Persistent.PersistentAgent"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="name"> The name of the agent. </param>
    /// <param name="description"> The description of the agent. </param>
    /// <param name="model"> The ID of the model to use. </param>
    /// <param name="instructions"> The system instructions for the agent to use. </param>
    /// <param name="tools">
    /// The collection of tools enabled for the agent.
    /// Please note <see cref="ToolDefinition"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="CodeInterpreterToolDefinition"/>, <see cref="FileSearchToolDefinition"/> and <see cref="FunctionToolDefinition"/>.
    /// </param>
    /// <param name="toolResources">
    /// A set of resources that are used by the agent's tools. The resources are specific to the type of tool. For example, the `code_interpreter`
    /// tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.
    /// </param>
    /// <param name="temperature">
    /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random,
    /// while lower values like 0.2 will make it more focused and deterministic.
    /// </param>
    /// <param name="topP">
    /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass.
    /// So 0.1 means only the tokens comprising the top 10% probability mass are considered.
    ///
    /// We generally recommend altering this or temperature but not both.
    /// </param>
    /// <param name="responseFormat"> The response format of the tool calls used by this agent. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    public static PersistentAgent PersistentAgent(string id = null, DateTimeOffset createdAt = default, string name = null, string description = null, string model = null, string instructions = null, IEnumerable<ToolDefinition> tools = null, ToolResources toolResources = null, float? temperature = null, float? topP = null, BinaryData responseFormat = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        tools ??= new List<ToolDefinition>();
        metadata ??= new Dictionary<string, string>();

        return new PersistentAgent(
            id,
            @object: null,
            createdAt,
            name,
            description,
            model,
            instructions,
            tools?.ToList(),
            toolResources,
            temperature,
            topP,
            responseFormat,
            metadata,
            serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="o:PersistentAgentThread"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="toolResources">
    /// A set of resources that are made available to the agent's tools in this thread. The resources are specific to the type
    /// of tool. For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list
    /// of vector store IDs.
    /// </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <returns> A new <see cref="Azure.AI.Agents.Persistent.PersistentAgentThread"/> instance for mocking. </returns>
    public static PersistentAgentThread PersistentAgentThread(string id = null, DateTimeOffset createdAt = default, ToolResources toolResources = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        metadata ??= new Dictionary<string, string>();

        return new PersistentAgentThread(
            id,
            @object: null,
            createdAt,
            toolResources,
            metadata,
            serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Azure.AI.Agents.Persistent.ThreadRun"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="threadId"> The ID of the thread associated with this run. </param>
    /// <param name="agentId"> The ID of the agent associated with the thread this run was performed against. </param>
    /// <param name="status"> The status of the agent thread run. </param>
    /// <param name="requiredAction">
    /// The details of the action required for the agent thread run to continue.
    /// Please note <see cref="Azure.AI.Agents.Persistent.RequiredAction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SubmitToolOutputsAction"/>.
    /// </param>
    /// <param name="lastError"> The last error, if any, encountered by this agent thread run. </param>
    /// <param name="model"> The ID of the model to use. </param>
    /// <param name="instructions"> The overridden system instructions used for this agent thread run. </param>
    /// <param name="tools">
    /// The overridden enabled tools used for this agent thread run.
    /// Please note <see cref="ToolDefinition"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="CodeInterpreterToolDefinition"/>, <see cref="FileSearchToolDefinition"/> and <see cref="FunctionToolDefinition"/>.
    /// </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="expiresAt"> The Unix timestamp, in seconds, representing when this item expires. </param>
    /// <param name="startedAt"> The Unix timestamp, in seconds, representing when this item was started. </param>
    /// <param name="completedAt"> The Unix timestamp, in seconds, representing when this completed. </param>
    /// <param name="cancelledAt"> The Unix timestamp, in seconds, representing when this was cancelled. </param>
    /// <param name="failedAt"> The Unix timestamp, in seconds, representing when this failed. </param>
    /// <param name="incompleteDetails"> Details on why the run is incomplete. Will be `null` if the run is not incomplete. </param>
    /// <param name="usage"> Usage statistics related to the run. This value will be `null` if the run is not in a terminal state (i.e. `in_progress`, `queued`, etc.). </param>
    /// <param name="temperature"> The sampling temperature used for this run. If not set, defaults to 1. </param>
    /// <param name="topP"> The nucleus sampling value used for this run. If not set, defaults to 1. </param>
    /// <param name="maxPromptTokens"> The maximum number of prompt tokens specified to have been used over the course of the run. </param>
    /// <param name="maxCompletionTokens"> The maximum number of completion tokens specified to have been used over the course of the run. </param>
    /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
    /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
    /// <param name="responseFormat"> The response format of the tool calls used in this run. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
    /// <param name="toolResources"> Override the tools the agent can use for this run. This is useful for modifying the behavior on a per-run basis. </param>
    /// <param name="parallelToolCalls"> Determines if tools can be executed in parallel within the run. </param>
    /// <returns> A new <see cref="Azure.AI.Agents.Persistent.ThreadRun"/> instance for mocking. </returns>
    public static ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, RunStatus status = default, RequiredAction requiredAction = null, RunError lastError = null, string model = null, string instructions = null, IEnumerable<ToolDefinition> tools = null, DateTimeOffset createdAt = default, DateTimeOffset? expiresAt = null, DateTimeOffset? startedAt = null, DateTimeOffset? completedAt = null, DateTimeOffset? cancelledAt = null, DateTimeOffset? failedAt = null, IncompleteRunDetails incompleteDetails = default, RunCompletionUsage usage = default, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, Truncation truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, IReadOnlyDictionary<string, string> metadata = null, ToolResources toolResources = null, bool? parallelToolCalls = null)
    {
        tools ??= new List<ToolDefinition>();
        metadata ??= new Dictionary<string, string>();

        return new ThreadRun(id, @object: null, threadId, agentId, status, requiredAction, lastError, model, instructions, tools.ToList(), createdAt, expiresAt, startedAt, completedAt, cancelledAt, failedAt, incompleteDetails, usage, temperature, topP, maxPromptTokens, maxCompletionTokens, truncationStrategy, toolChoice, responseFormat, metadata, toolResources, parallelToolCalls ?? true, serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Azure.AI.Agents.Persistent.PersistentAgentFileInfo"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="size"> The size of the file, in bytes. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="purpose"> The intended purpose of a file. </param>
    /// <returns> A new <see cref="Azure.AI.Agents.Persistent.PersistentAgentFileInfo"/> instance for mocking. </returns>
    public static PersistentAgentFileInfo PersistentAgentFile(string id = null, int size = default, string filename = null, DateTimeOffset createdAt = default, PersistentAgentFilePurpose purpose = default)
    {
        return new PersistentAgentFileInfo(id, size, filename, createdAt, purpose);
    }

    /// <summary> Initializes a new instance of <see cref="Azure.AI.Agents.Persistent.RunStep"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="type"> The type of run step, which can be either message_creation or tool_calls. </param>
    /// <param name="agentId"> The ID of the agent associated with the run step. </param>
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
    /// <param name="usage"> Usage statistics related to the run step. </param>
    /// <param name="metadata"> A set of key/value pairs that can be attached to an object, used for storing additional information. </param>
    /// <returns> A new <see cref="Azure.AI.Agents.Persistent.RunStep"/> instance for mocking. </returns>
    public static RunStep RunStep(string id = null, RunStepType type = default, string agentId = null, string threadId = null, string runId = null, RunStepStatus status = default, RunStepDetails stepDetails = null, RunStepError lastError = null, DateTimeOffset createdAt = default, DateTimeOffset? expiredAt = null, DateTimeOffset? completedAt = null, DateTimeOffset? cancelledAt = null, DateTimeOffset? failedAt = null, RunStepCompletionUsage usage = null, IReadOnlyDictionary<string, string> metadata = null)
    {
        metadata ??= new Dictionary<string, string>();

        return new RunStep(id, @object: null, type, agentId, threadId, runId, status, stepDetails, lastError, createdAt, expiredAt, completedAt, cancelledAt, failedAt, usage, metadata, serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Azure.AI.Agents.Persistent.PersistentThreadMessage"/>. </summary>
    /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="createdAt"> The Unix timestamp, in seconds, representing when this object was created. </param>
    /// <param name="threadId"> The ID of the thread that this message belongs to. </param>
    /// <param name="status"> The status of the message. </param>
    /// <param name="incompleteDetails"> On an incomplete message, details about why the message is incomplete. </param>
    /// <param name="completedAt"> The Unix timestamp (in seconds) for when the message was completed. </param>
    /// <param name="incompleteAt"> The Unix timestamp (in seconds) for when the message was marked as incomplete. </param>
    /// <param name="role"> The role associated with the agent thread message. </param>
    /// <param name="contentItems"> The list of content items associated with the agent thread message. </param>
    /// <param name="agentId"> If applicable, the ID of the agent that authored this message. </param>
    /// <param name="runId"> If applicable, the ID of the run associated with the authoring of this message. </param>
    /// <param name="attachments"> A list of files attached to the message, and the tools they were added to. </param>
    /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. </param>
    /// <returns> A new <see cref="Azure.AI.Agents.Persistent.PersistentThreadMessage"/> instance for mocking. </returns>
    public static PersistentThreadMessage ThreadMessage(string id = null, DateTimeOffset createdAt = default, string threadId = null, MessageStatus status = default, MessageIncompleteDetails incompleteDetails = null, DateTimeOffset? completedAt = null, DateTimeOffset? incompleteAt = null, MessageRole role = default, IEnumerable<MessageContent> contentItems = null, string agentId = null, string runId = null, IEnumerable<MessageAttachment> attachments = null, IDictionary<string, string> metadata = null)
    {
        contentItems ??= new List<MessageContent>();
        attachments ??= new List<MessageAttachment>();
        metadata ??= new Dictionary<string, string>();

        return new PersistentThreadMessage(id, @object: null, createdAt, threadId, status, incompleteDetails, completedAt, incompleteAt, role, contentItems?.ToList(), agentId, runId, attachments?.ToList(), (IReadOnlyDictionary<string, string>)metadata, serializedAdditionalRawData: null);
    }

    public static RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments)
    {
        return new RequiredFunctionToolCall(toolCallId, new InternalRequiredFunctionToolCallDetails(functionName, functionArguments));
    }

    public static RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments)
    {
        return new RunStepFunctionToolCall(id, new InternalRunStepFunctionToolCallDetails(name, arguments));
    }

    public static RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, IReadOnlyList<RunStepCodeInterpreterToolCallOutput> outputs)
    {
        return new RunStepCodeInterpreterToolCall(id, new InternalCodeInterpreterToolCallDetails(input, outputs));
    }

    /// <summary>
    /// Instantiates a new instance of <see cref="Azure.AI.Agents.Persistent.SubmitToolOutputsAction"/>.
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
        return new MessageImageFileContent(new InternalMessageImageFileDetails(fileId));
    }

    /// <summary>
    /// Creates a new instance of MessageFileCitationTextAnnotation.
    /// </summary>
    /// <param name="text"> The text for the citation. </param>
    /// <param name="fileId"> The file ID for the citation. </param>
    /// <param name="quote"> The quote for the citation. </param>
    /// <returns> A new instance of MessageFileCitationTextAnnotation. </returns>
    public static MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote)
    {
        return new MessageTextFileCitationAnnotation(text, new InternalMessageTextFileCitationDetails(fileId, quote));
    }

    /// <summary>
    /// Creates a new instance of MessageFilePathTextAnnotation.
    /// </summary>
    /// <param name="text"> The text for the annotation. </param>
    /// <param name="fileId"> The file ID for the annotation. </param>
    /// <returns> A new instance of MessageFilePathTextAnnotation. </returns>
    public static MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId)
    {
        return new MessageTextFilePathAnnotation(text, new InternalMessageTextFilePathDetails(fileId));
    }
}
