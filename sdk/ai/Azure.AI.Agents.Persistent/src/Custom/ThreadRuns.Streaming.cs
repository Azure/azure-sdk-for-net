// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using static Azure.Core.Pipeline.TaskExtensions;

namespace Azure.AI.Agents.Persistent
{
    public partial class ThreadRuns
    {
        /// <summary>
        /// Begins a new streaming <see cref="ThreadRun"/> that evaluates a <see cref="PersistentAgentThread"/> using a specified
        /// <see cref="PersistentAgent"/>.
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="agentId"> The ID of the agent that should run the thread. </param>
        /// <param name="overrideModelName"> The overridden model name that the agent should use to run the thread. </param>
        /// <param name="overrideInstructions"> The overridden system instructions that the agent should use to run the thread. </param>
        /// <param name="additionalInstructions">
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </param>
        /// <param name="additionalMessages"> Adds additional messages to the thread before creating the run. </param>
        /// <param name="overrideTools"> The overridden list of enabled tools that the agent should use to run the thread. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </param>
        /// <param name="maxPromptTokens">
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="maxCompletionTokens">
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
        /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
        /// <param name="responseFormat"> Specifies the format that the model must output. </param>
        /// <param name="parallelToolCalls"> If `true` functions will run in parallel during tool use. </param>
        /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(string threadId, string agentId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, IEnumerable<ThreadMessageOptions> additionalMessages = null, IEnumerable<ToolDefinition> overrideTools = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, Truncation truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, bool? parallelToolCalls = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            // This method added for compatibility, before the include parameter support was enabled.
            return CreateRunStreamingAsync(
                threadId: threadId,
                agentId: agentId,
                overrideModelName: overrideModelName,
                overrideInstructions: overrideInstructions,
                additionalInstructions: additionalInstructions,
                additionalMessages: additionalMessages,
                overrideTools: overrideTools,
                temperature: temperature,
                topP: topP,
                maxPromptTokens: maxPromptTokens,
                maxCompletionTokens: maxCompletionTokens,
                truncationStrategy: truncationStrategy,
                toolChoice: toolChoice,
                responseFormat: responseFormat,
                parallelToolCalls: parallelToolCalls,
                metadata: metadata,
                include: null,
                cancellationToken: cancellationToken
            );
        }
        /// <summary>
        /// Begins a new streaming <see cref="ThreadRun"/> that evaluates a <see cref="PersistentAgentThread"/> using a specified
        /// <see cref="PersistentAgent"/>.
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="agentId"> The ID of the agent that should run the thread. </param>
        /// <param name="include">
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content`
        /// to fetch the file search result content.
        /// </param>
        /// <param name="overrideModelName"> The overridden model name that the agent should use to run the thread. </param>
        /// <param name="overrideInstructions"> The overridden system instructions that the agent should use to run the thread. </param>
        /// <param name="additionalInstructions">
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </param>
        /// <param name="additionalMessages"> Adds additional messages to the thread before creating the run. </param>
        /// <param name="overrideTools"> The overridden list of enabled tools that the agent should use to run the thread. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </param>
        /// <param name="maxPromptTokens">
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="maxCompletionTokens">
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
        /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
        /// <param name="responseFormat"> Specifies the format that the model must output. </param>
        /// <param name="parallelToolCalls"> If `true` functions will run in parallel during tool use. </param>
        /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(string threadId, string agentId, IEnumerable<RunAdditionalFieldList> include, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, IEnumerable<ThreadMessageOptions> additionalMessages = null, IEnumerable<ToolDefinition> overrideTools = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, Truncation truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, bool? parallelToolCalls = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(agentId, nameof(agentId));

            CreateRunRequest createRunRequest = new CreateRunRequest(
                agentId,
                overrideModelName,
                overrideInstructions,
                additionalInstructions,
                additionalMessages?.ToList() as IReadOnlyList<ThreadMessageOptions> ?? new ChangeTrackingList<ThreadMessageOptions>(),
                overrideTools?.ToList() as IReadOnlyList<ToolDefinition> ?? new ChangeTrackingList<ToolDefinition>(),
                stream: true,
                temperature,
                topP,
                maxPromptTokens,
                maxCompletionTokens,
                truncationStrategy,
                toolChoice,
                responseFormat,
                parallelToolCalls,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                null);
            RequestContext context = FromCancellationToken(cancellationToken);

            async Task<Response> sendRequestAsync() =>
                await CreateRunStreamingAsync(threadId, createRunRequest.ToRequestContent(), context, include:include).ConfigureAwait(false);

            return new AsyncStreamingUpdateCollection(sendRequestAsync, cancellationToken);
        }
        /// <summary>
        /// Begins a new streaming <see cref="ThreadRun"/> that evaluates a <see cref="PersistentAgentThread"/> using a specified
        /// <see cref="PersistentAgent"/>.
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="agentId"> The ID of the agent that should run the thread. </param>
        /// <param name="overrideModelName"> The overridden model name that the agent should use to run the thread. </param>
        /// <param name="overrideInstructions"> The overridden system instructions that the agent should use to run the thread. </param>
        /// <param name="additionalInstructions">
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </param>
        /// <param name="additionalMessages"> Adds additional messages to the thread before creating the run. </param>
        /// <param name="overrideTools"> The overridden list of enabled tools that the agent should use to run the thread. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </param>
        /// <param name="maxPromptTokens">
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="maxCompletionTokens">
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
        /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
        /// <param name="responseFormat"> Specifies the format that the model must output. </param>
        /// <param name="parallelToolCalls"> If `true` functions will run in parallel during tool use. </param>
        /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(string threadId, string agentId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, IEnumerable<ThreadMessageOptions> additionalMessages = null, IEnumerable<ToolDefinition> overrideTools = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, Truncation truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, bool? parallelToolCalls = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return CreateRunStreaming(
                threadId: threadId,
                agentId: agentId,
                overrideModelName: overrideModelName,
                overrideInstructions: overrideInstructions,
                additionalInstructions: additionalInstructions,
                additionalMessages: additionalMessages,
                overrideTools: overrideTools,
                temperature: temperature,
                topP: topP,
                maxPromptTokens: maxPromptTokens,
                maxCompletionTokens: maxCompletionTokens,
                truncationStrategy: truncationStrategy,
                toolChoice: toolChoice,
                responseFormat: responseFormat,
                parallelToolCalls: parallelToolCalls,
                metadata: metadata,
                include: null,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Begins a new streaming <see cref="ThreadRun"/> that evaluates a <see cref="PersistentAgentThread"/> using a specified
        /// <see cref="PersistentAgent"/>.
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="agentId"> The ID of the agent that should run the thread. </param>
        /// <param name="include">
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content`
        /// to fetch the file search result content.
        /// </param>
        /// <param name="overrideModelName"> The overridden model name that the agent should use to run the thread. </param>
        /// <param name="overrideInstructions"> The overridden system instructions that the agent should use to run the thread. </param>
        /// <param name="additionalInstructions">
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </param>
        /// <param name="additionalMessages"> Adds additional messages to the thread before creating the run. </param>
        /// <param name="overrideTools"> The overridden list of enabled tools that the agent should use to run the thread. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </param>
        /// <param name="maxPromptTokens">
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="maxCompletionTokens">
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
        /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
        /// <param name="responseFormat"> Specifies the format that the model must output. </param>
        /// <param name="parallelToolCalls"> If `true` functions will run in parallel during tool use. </param>
        /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(string threadId, string agentId, IEnumerable<RunAdditionalFieldList> include, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, IEnumerable<ThreadMessageOptions> additionalMessages = null, IEnumerable<ToolDefinition> overrideTools = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, Truncation truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, bool? parallelToolCalls = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(agentId, nameof(agentId));

            CreateRunRequest createRunRequest = new CreateRunRequest(
                agentId,
                overrideModelName,
                overrideInstructions,
                additionalInstructions,
                additionalMessages?.ToList() as IReadOnlyList<ThreadMessageOptions> ?? new ChangeTrackingList<ThreadMessageOptions>(),
                overrideTools?.ToList() as IReadOnlyList<ToolDefinition> ?? new ChangeTrackingList<ToolDefinition>(),
                stream: true,
                temperature,
                topP,
                maxPromptTokens,
                maxCompletionTokens,
                truncationStrategy,
                toolChoice,
                responseFormat,
                parallelToolCalls,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                null);
            RequestContext context = FromCancellationToken(cancellationToken);

            Response sendRequest() => CreateRunStreaming(threadId, createRunRequest.ToRequestContent(), context, include: include);
            return new StreamingUpdateCollection(sendRequest, cancellationToken);
        }
        /// <summary> Submits outputs from tools as requested by tool calls in a stream. Stream updates that need submitted tool outputs will have a status of 'RunStatus.RequiresAction'. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
        /// <param name="toolOutputs"> A list of tools for which the outputs are being submitted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/> or <paramref name="toolOutputs"/> is null. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual CollectionResult<StreamingUpdate> SubmitToolOutputsToStream(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            Argument.AssertNotNull(run, nameof(run));
            Argument.AssertNotNull(toolOutputs, nameof(toolOutputs));

            SubmitToolOutputsToRunRequest submitToolOutputsToRunRequest = new(toolOutputs.ToList(), true, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response sendRequest() => SubmitToolOutputsInternal(run.ThreadId, run.Id, true, submitToolOutputsToRunRequest.ToRequestContent(), context);
            return new StreamingUpdateCollection(sendRequest, cancellationToken);
        }

        /// <summary> Submits outputs from tools as requested by tool calls in a stream. Stream updates that need submitted tool outputs will have a status of 'RunStatus.RequiresAction'. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
        /// <param name="toolOutputs"> A list of tools for which the outputs are being submitted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/> or <paramref name="toolOutputs"/> is null. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual AsyncCollectionResult<StreamingUpdate> SubmitToolOutputsToStreamAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            Argument.AssertNotNull(run, nameof(run));
            Argument.AssertNotNull(toolOutputs, nameof(toolOutputs));

            SubmitToolOutputsToRunRequest submitToolOutputsToRunRequest = new(toolOutputs.ToList(), true, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            async Task<Response> sendRequestAsync() => await SubmitToolOutputsInternalAsync(run.ThreadId, run.Id, true, submitToolOutputsToRunRequest.ToRequestContent(), context).ConfigureAwait(false);
            return new AsyncStreamingUpdateCollection(sendRequestAsync, cancellationToken);
        }

        internal async Task<Response> CreateRunStreamingAsync(string threadId, RequestContent content, RequestContext context = null, IEnumerable<RunAdditionalFieldList> include = null)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.CreateRun");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRunRequest(threadId, content, include, context);
                message.BufferResponse = false;
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal Response CreateRunStreaming(string threadId, RequestContent content, RequestContext context = null, IEnumerable<RunAdditionalFieldList> include = null)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.CreateRun");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRunRequest(threadId, content, include, context);
                message.BufferResponse = false;
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
