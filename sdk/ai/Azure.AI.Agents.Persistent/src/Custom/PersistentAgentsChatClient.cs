// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;

#pragma warning disable MEAI001 // MCP-related types are currently marked as [Experimental]

namespace Azure.AI.Agents.Persistent
{
    /// <summary>Represents an <see cref="IChatClient"/> for an Azure.AI.Agents.Persistent <see cref="PersistentAgentsClient"/>.</summary>
    internal partial class PersistentAgentsChatClient : IChatClient
    {
        /// <summary>The name of the chat client provider.</summary>
        private const string ProviderName = "azure";

        /// <summary>The underlying <see cref="PersistentAgentsClient" />.</summary>
        private readonly PersistentAgentsClient? _client;

        /// <summary>Metadata for the client.</summary>
        private readonly ChatClientMetadata? _metadata;

        /// <summary>The ID of the agent to use.</summary>
        private readonly string? _agentId;

        /// <summary>The thread ID to use if none is supplied in <see cref="ChatOptions.ConversationId"/>.</summary>
        private readonly string? _defaultThreadId;

        /// <summary>Lazily-retrieved agent instance. Used for its properties.</summary>
        private PersistentAgent? _agent;

        /// <summary>Initializes a new instance of the <see cref="PersistentAgentsChatClient"/> class for the specified <see cref="PersistentAgentsClient"/>.</summary>
        public PersistentAgentsChatClient(PersistentAgentsClient client, string agentId, string? defaultThreadId = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrWhiteSpace(agentId, nameof(agentId));

            _client = client;
            _agentId = agentId;
            _defaultThreadId = defaultThreadId;

            _metadata = new(ProviderName);
        }

        protected PersistentAgentsChatClient() { }

        /// <inheritdoc />
        public virtual object? GetService(Type serviceType, object? serviceKey = null) =>
            serviceType is null ? throw new ArgumentNullException(nameof(serviceType)) :
            serviceKey is not null ? null :
            serviceType == typeof(ChatClientMetadata) ? _metadata :
            serviceType == typeof(PersistentAgentsClient) ? _client :
            serviceType.IsInstanceOfType(this) ? this :
            null;

        /// <inheritdoc />
        public virtual Task<ChatResponse> GetResponseAsync(
            IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) =>
            GetStreamingResponseAsync(messages, options, cancellationToken).ToChatResponseAsync(cancellationToken);

        /// <inheritdoc />
        public virtual async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
            IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(messages, nameof(messages));

            // Extract necessary state from messages and options.
            (ThreadAndRunOptions runOptions, List<FunctionResultContent>? toolResults, List<McpServerToolApprovalResponseContent>? approvalResults) =
                await CreateRunOptionsAsync(messages, options, cancellationToken).ConfigureAwait(false);

            // Get the thread ID.
            string? threadId = options?.ConversationId ?? _defaultThreadId;

            // Get any active run ID for this thread.
            ThreadRun? threadRun = null;
            if (threadId is not null)
            {
                await foreach (ThreadRun? run in _client!.Runs.GetRunsAsync(threadId, limit: 1, ListSortOrder.Descending, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (run.Status != RunStatus.Completed && run.Status != RunStatus.Cancelled && run.Status != RunStatus.Failed && run.Status != RunStatus.Expired)
                    {
                        threadRun = run;
                        break;
                    }
                }
            }

            // Submit the request.
            IAsyncEnumerable<StreamingUpdate> updates;
            if ((toolResults is not null || approvalResults is not null) &&
                threadRun is not null &&
                ConvertFunctionResultsToToolOutput(toolResults, approvalResults, out List<ToolOutput> toolOutputs, out List<ToolApproval> toolApprovals) is { } toolRunId &&
                toolRunId == threadRun.Id)
            {
                // There's an active run and we have tool results to submit for that run, so submit the results and continue streaming.
                // This is going to ignore any additional messages in the run options, as we are only submitting tool outputs,
                // but there doesn't appear to be a way to submit additional messages, and having such additional messages is rare.
                updates = _client!.Runs.SubmitToolOutputsToStreamAsync(threadRun, toolOutputs, toolApprovals, cancellationToken);
            }
            else
            {
                if (threadId is null)
                {
                    // No thread ID was provided, so create a new thread.
                    PersistentAgentThread thread = await _client!.Threads.CreateThreadAsync(runOptions.ThreadOptions.Messages, runOptions.ToolResources, runOptions.Metadata, cancellationToken).ConfigureAwait(false);
                    runOptions.ThreadOptions.Messages.Clear();
                    threadId = thread.Id;
                }
                else if (threadRun is not null)
                {
                    // There was an active run; we need to cancel it before starting a new run.
                    await _client!.Runs.CancelRunAsync(threadId, threadRun.Id, cancellationToken).ConfigureAwait(false);
                    threadRun = null;
                }

                // Now create a new run and stream the results.
                CreateRunStreamingOptions opts = new()
                {
                    OverrideModelName = runOptions.OverrideModelName,
                    OverrideInstructions = runOptions.OverrideInstructions,
                    AdditionalInstructions = null,
                    AdditionalMessages = runOptions.ThreadOptions.Messages,
                    OverrideTools = runOptions.OverrideTools,
                    ToolResources = runOptions.ToolResources,
                    Temperature = runOptions.Temperature,
                    TopP = runOptions.TopP,
                    MaxPromptTokens = runOptions.MaxPromptTokens,
                    MaxCompletionTokens = runOptions.MaxCompletionTokens,
                    TruncationStrategy = runOptions.TruncationStrategy,
                    ToolChoice = runOptions.ToolChoice,
                    ResponseFormat = runOptions.ResponseFormat,
                    ParallelToolCalls = runOptions.ParallelToolCalls,
                    Metadata = runOptions.Metadata
                };

                // This method added for compatibility, before the include parameter support was enabled.
                updates = _client!.Runs.CreateRunStreamingAsync(
                    threadId: threadId,
                    agentId: _agentId,
                    options: opts,
                    cancellationToken: cancellationToken
                );
            }

            // Process each update.
            string? responseId = null;
            await foreach (StreamingUpdate? update in updates.ConfigureAwait(false))
            {
                switch (update)
                {
                    case ThreadUpdate tu:
                        threadId ??= tu.Value.Id;
                        goto default;

                    case RunUpdate ru:
                        threadId ??= ru.Value.ThreadId;
                        responseId ??= ru.Value.Id;

                        ChatResponseUpdate ruUpdate = new()
                        {
                            AuthorName = ru.Value.AssistantId,
                            ConversationId = threadId,
                            CreatedAt = ru.Value.CreatedAt,
                            MessageId = responseId,
                            ModelId = ru.Value.Model,
                            RawRepresentation = ru,
                            ResponseId = responseId,
                            Role = ChatRole.Assistant,
                        };

                        if (ru.Value.Usage is { } usage)
                        {
                            ruUpdate.Contents.Add(new UsageContent(new()
                            {
                                InputTokenCount = usage.PromptTokens,
                                OutputTokenCount = usage.CompletionTokens,
                                TotalTokenCount = usage.TotalTokens,
                            }));
                        }

                        switch (ru)
                        {
                            case RequiredActionUpdate rau when rau.ToolCallId is string toolCallId && rau.FunctionName is string functionName:
                                ruUpdate.Contents.Add(new FunctionCallContent(
                                    JsonSerializer.Serialize([ru.Value.Id, toolCallId], AgentsChatClientJsonContext.Default.StringArray),
                                    functionName,
                                    JsonSerializer.Deserialize(rau.FunctionArguments, AgentsChatClientJsonContext.Default.IDictionaryStringObject)!));
                                break;

                            case SubmitToolApprovalUpdate stau:
                                ruUpdate.Contents.Add(new McpServerToolApprovalRequestContent(
                                    JsonSerializer.Serialize([stau.Value.Id, stau.ToolCallId], AgentsChatClientJsonContext.Default.StringArray),
                                    new McpServerToolCallContent(stau.ToolCallId, stau.Name, stau.ServerLabel)
                                    {
                                        Arguments = JsonSerializer.Deserialize(stau.Arguments, AgentsChatClientJsonContext.Default.IReadOnlyDictionaryStringObject)!,
                                    }));
                                break;
                        }

                        yield return ruUpdate;
                        break;

                    case RunStepDetailsUpdate details:
                        if (!string.IsNullOrEmpty(details.CodeInterpreterInput))
                        {
                            CodeInterpreterToolCallContent citcc = new()
                            {
                                CallId = details.ToolCallId,
                                Inputs = [new DataContent(Encoding.UTF8.GetBytes(details.CodeInterpreterInput), "text/x-python")],
                                RawRepresentation = details,
                            };

                            yield return new ChatResponseUpdate(ChatRole.Assistant, [citcc])
                            {
                                AuthorName = _agentId,
                                ConversationId = threadId,
                                MessageId = responseId,
                                RawRepresentation = update,
                                ResponseId = responseId,
                            };
                        }

                        if (details.CodeInterpreterOutputs is { Count: > 0 })
                        {
                            CodeInterpreterToolResultContent citrc = new()
                            {
                                CallId = details.ToolCallId,
                                RawRepresentation = details,
                            };

                            foreach (var output in details.CodeInterpreterOutputs)
                            {
                                switch (output)
                                {
                                    case RunStepDeltaCodeInterpreterImageOutput imageOutput when imageOutput.Image?.FileId is string imageFileId && !string.IsNullOrWhiteSpace(imageFileId):
                                        (citrc.Outputs ??= []).Add(new HostedFileContent(imageFileId) { MediaType = "image/*" });
                                        break;

                                    case RunStepDeltaCodeInterpreterLogOutput logOutput when logOutput.Logs is string logs && !string.IsNullOrEmpty(logs):
                                        (citrc.Outputs ??= []).Add(new TextContent(logs));
                                        break;
                                }
                            }

                            yield return new ChatResponseUpdate(ChatRole.Assistant, [citrc])
                            {
                                AuthorName = _agentId,
                                ConversationId = threadId,
                                MessageId = responseId,
                                RawRepresentation = update,
                                ResponseId = responseId,
                            };
                        }
                        break;

                    case MessageContentUpdate mcu:
                        ChatResponseUpdate textUpdate = new(mcu.Role == MessageRole.User ? ChatRole.User : ChatRole.Assistant, mcu.Text)
                        {
                            AuthorName = _agentId,
                            ConversationId = threadId,
                            MessageId = responseId,
                            RawRepresentation = mcu,
                            ResponseId = responseId,
                        };

                        // Add any annotations from the text update. The OpenAI Assistants API does not support passing these back
                        // into the model (MessageContent.FromXx does not support providing annotations), so they end up being one way and are dropped
                        // on subsequent requests.
                        if (mcu.TextAnnotation is { } tau)
                        {
                            string? fileId = null;
                            string? toolName = null;
                            if (!string.IsNullOrWhiteSpace(tau.InputFileId))
                            {
                                fileId = tau.InputFileId;
                                toolName = "file_search";
                            }
                            else if (!string.IsNullOrWhiteSpace(tau.OutputFileId))
                            {
                                fileId = tau.OutputFileId;
                                toolName = "code_interpreter";
                            }

                            if (fileId is not null)
                            {
                                if (textUpdate.Contents.Count == 0)
                                {
                                    // In case a chunk doesn't have text content, create one with empty text to hold the annotation.
                                    textUpdate.Contents.Add(new TextContent(string.Empty));
                                }

                                (((TextContent)textUpdate.Contents[0]).Annotations ??= []).Add(new CitationAnnotation
                                {
                                    RawRepresentation = tau,
                                    AnnotatedRegions = [new TextSpanAnnotatedRegion { StartIndex = tau.StartIndex, EndIndex = tau.EndIndex }],
                                    FileId = fileId,
                                    ToolName = toolName,
                                });
                            }
                        }

                        yield return textUpdate;
                        break;

                    default:
                        yield return new ChatResponseUpdate
                        {
                            AuthorName = _agentId,
                            ConversationId = threadId,
                            MessageId = responseId,
                            RawRepresentation = update,
                            ResponseId = responseId,
                            Role = ChatRole.Assistant,
                        };
                        break;
                }
            }
        }

        /// <inheritdoc />
        public void Dispose() { }

        /// <summary>
        /// Creates the <see cref="ThreadAndRunOptions"/> to use for the request and extracts any function result contents
        /// that need to be submitted as tool results.
        /// </summary>
        private async ValueTask<(ThreadAndRunOptions RunOptions, List<FunctionResultContent>? ToolResults, List<McpServerToolApprovalResponseContent>? ApprovalResults)> CreateRunOptionsAsync(
            IEnumerable<ChatMessage> messages, ChatOptions? options, CancellationToken cancellationToken)
        {
            // Create the options instance to populate, either a fresh or using one the caller provides.
            ThreadAndRunOptions runOptions =
                options?.RawRepresentationFactory?.Invoke(this) as ThreadAndRunOptions ??
                new();

            // Load details about the agent if not already loaded.
            if (_agent is null)
            {
                PersistentAgent agent = await _client!.Administration.GetAgentAsync(_agentId, cancellationToken).ConfigureAwait(false);
                Interlocked.CompareExchange(ref _agent, agent, null);
            }

            // Populate the run options from the ChatOptions, if provided.
            if (options is not null)
            {
                runOptions.MaxCompletionTokens ??= options.MaxOutputTokens;
                runOptions.OverrideModelName ??= options.ModelId;
                runOptions.TopP ??= options.TopP;
                runOptions.Temperature ??= options.Temperature;
                runOptions.ParallelToolCalls ??= options.AllowMultipleToolCalls;
                // Ignored: options.TopK, options.FrequencyPenalty, options.Seed, options.StopSequences

                if (options.Tools is { Count: > 0 } tools)
                {
                    HashSet<ToolDefinition> toolDefinitions = new(ToolDefinitionNameEqualityComparer.Instance);
                    ToolResources? toolResources = null;

                    // If the caller has provided any tool overrides, we'll assume they don't want to use the agent's tools.
                    // But if they haven't, the only way we can provide our tools is via an override, whereas we'd really like to
                    // just add them. To handle that, we'll get all of the agent's tools and add them to the override list
                    // along with our tools.
                    if (runOptions.OverrideTools is null || !runOptions.OverrideTools.Any())
                    {
                        toolDefinitions.UnionWith(_agent.Tools);
                    }

                    // The caller can provide tools in the supplied ThreadAndRunOptions.
                    if (runOptions.OverrideTools is not null)
                    {
                        toolDefinitions.UnionWith(runOptions.OverrideTools);
                    }

                    // Now add the tools from ChatOptions.Tools.
                    foreach (AITool tool in tools)
                    {
                        switch (tool)
                        {
                            case ToolDefinitionAITool rawTool:
                                toolDefinitions.Add(rawTool.Tool);
                                break;

                            case AIFunctionDeclaration aiFunction:
                                toolDefinitions.Add(new FunctionToolDefinition(
                                    aiFunction.Name,
                                    aiFunction.Description,
                                    BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(aiFunction.JsonSchema, AgentsChatClientJsonContext.Default.JsonElement))));
                                break;

                            case HostedCodeInterpreterTool codeTool:
                                toolDefinitions.Add(new CodeInterpreterToolDefinition());

                                if (codeTool.Inputs is { Count: > 0 })
                                {
                                    foreach (var input in codeTool.Inputs)
                                    {
                                        switch (input)
                                        {
                                            case HostedFileContent hostedFile:
                                                // If the input is a HostedFileContent, we can use its ID directly.
                                                (toolResources ??= new() { CodeInterpreter = new() }).CodeInterpreter.FileIds.Add(hostedFile.FileId);
                                                break;
                                        }
                                    }
                                }
                                break;

                            case HostedFileSearchTool fileSearchTool:
                                toolDefinitions.Add(new FileSearchToolDefinition(
                                    type: "file_search",
                                    serializedAdditionalRawData: null,
                                    fileSearch: new() { MaxNumResults = fileSearchTool.MaximumResultCount }));

                                if (fileSearchTool.Inputs is { Count: > 0 })
                                {
                                    foreach (var input in fileSearchTool.Inputs)
                                    {
                                        switch (input)
                                        {
                                            case HostedVectorStoreContent hostedVectorStore:
                                                (toolResources ??= new() { FileSearch = new() }).FileSearch.VectorStoreIds.Add(hostedVectorStore.VectorStoreId);
                                                break;
                                        }
                                    }
                                }
                                break;

                            case HostedWebSearchTool webSearch when webSearch.AdditionalProperties?.TryGetValue("connectionId", out object? connectionId) is true:
                                toolDefinitions.Add(new BingGroundingToolDefinition(new BingGroundingSearchToolParameters([new BingGroundingSearchConfiguration(connectionId!.ToString())])));
                                break;

                            case HostedMcpServerTool mcpTool:
                                MCPToolDefinition mcp = new(mcpTool.ServerName, mcpTool.ServerAddress);

                                if (mcpTool.AllowedTools is { Count: > 0 })
                                {
                                    foreach (string toolName in mcpTool.AllowedTools)
                                    {
                                        mcp.AllowedTools.Add(toolName);
                                    }
                                }

                                MCPToolResource mcpResource = !string.IsNullOrEmpty(mcpTool.AuthorizationToken) ?
                                    new(mcpTool.ServerName, new Dictionary<string, string>() { ["Authorization"] = $"Bearer {mcpTool.AuthorizationToken}" }) :
                                    new(mcpTool.ServerName);

                                switch (mcpTool.ApprovalMode)
                                {
                                    case HostedMcpServerToolAlwaysRequireApprovalMode:
                                        mcpResource.RequireApproval = new MCPApproval("always");
                                        break;

                                    case HostedMcpServerToolNeverRequireApprovalMode:
                                        mcpResource.RequireApproval = new MCPApproval("never");
                                        break;

                                    case HostedMcpServerToolRequireSpecificApprovalMode requireSpecific:
                                        mcpResource.RequireApproval = new MCPApproval(new MCPApprovalPerTool()
                                        {
                                            Always = requireSpecific.AlwaysRequireApprovalToolNames is { Count: > 0 } alwaysRequireNames ? new(alwaysRequireNames) : null,
                                            Never = requireSpecific.NeverRequireApprovalToolNames is { Count: > 0 } neverRequireNames ? new(neverRequireNames) : null,
                                        });
                                        break;
                                }

                                (toolResources ??= new()).Mcp.Add(mcpResource);
                                toolDefinitions.Add(mcp);
                                break;
                        }
                    }

                    if (toolDefinitions.Count > 0)
                    {
                        runOptions.OverrideTools = toolDefinitions;
                    }

                    if (toolResources is not null)
                    {
                        runOptions.ToolResources = toolResources;
                    }
                }

                // Store the tool mode, if relevant.
                if (runOptions.ToolChoice is null)
                {
                    switch (options.ToolMode)
                    {
                        case NoneChatToolMode:
                            runOptions.ToolChoice = BinaryData.FromString("\"none\"");
                            break;

                        case RequiredChatToolMode required:
                            runOptions.ToolChoice = required.RequiredFunctionName is string functionName ?
                                BinaryData.FromString($$"""{"type": "function", "function": {"name": "{{functionName}}"} }""") :
                                BinaryData.FromString("required");
                            break;
                        case AutoChatToolMode:
                            runOptions.ToolChoice = BinaryData.FromString("\"auto\"");
                            break;
                    }
                }

                // Store the response format, if relevant.
                if (runOptions.ResponseFormat is null)
                {
                    if (options.ResponseFormat is ChatResponseFormatJson jsonFormat)
                    {
                        if (jsonFormat.Schema is JsonElement schema)
                        {
                            var schemaNode = JsonSerializer.SerializeToNode(schema, AgentsChatClientJsonContext.Default.JsonElement)!;

                            var jsonSchemaObject = new JsonObject
                            {
                                ["schema"] = schemaNode
                            };

                            if (jsonFormat.SchemaName is not null)
                            {
                                jsonSchemaObject["name"] = jsonFormat.SchemaName;
                            }
                            if (jsonFormat.SchemaDescription is not null)
                            {
                                jsonSchemaObject["description"] = jsonFormat.SchemaDescription;
                            }

                            runOptions.ResponseFormat =
                                BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(new()
                                {
                                    ["type"] = "json_schema",
                                    ["json_schema"] = jsonSchemaObject,
                                }, AgentsChatClientJsonContext.Default.JsonObject));
                        }
                        else
                        {
                            runOptions.ResponseFormat = BinaryData.FromString("""{ "type": "json_object" }""");
                        }
                    }
                    else if (options.ResponseFormat is ChatResponseFormatText textFormat)
                    {
                        runOptions.ResponseFormat = BinaryData.FromString("""{ "type": "text" }""");
                    }
                }
            }

            // Process ChatMessages. System messages are turned into additional instructions.
            // All other messages are added 1:1, treating assistant messages as agent messages
            // and everything else as user messages.
            StringBuilder? instructions = null;
            List<FunctionResultContent>? functionResults = null;
            List<McpServerToolApprovalResponseContent>? approvalResults = null;

            runOptions.ThreadOptions ??= new();

            bool treatInstructionsAsOverride = false;
            if (runOptions.OverrideInstructions is not null)
            {
                treatInstructionsAsOverride = true;
                (instructions ??= new()).Append(runOptions.OverrideInstructions);
            }

            if (options?.Instructions is not null)
            {
                (instructions ??= new()).Append(options.Instructions);
            }

            foreach (ChatMessage chatMessage in messages)
            {
                List<MessageInputContentBlock> messageContents = [];

                if (chatMessage.Role == ChatRole.System ||
                    chatMessage.Role == new ChatRole("developer"))
                {
                    instructions ??= new();
                    foreach (TextContent textContent in chatMessage.Contents.OfType<TextContent>())
                    {
                        _ = instructions.Append(textContent);
                    }

                    continue;
                }

                foreach (AIContent content in chatMessage.Contents)
                {
                    switch (content)
                    {
                        case TextContent text:
                            messageContents.Add(new MessageInputTextBlock(text.Text));
                            break;

                        case DataContent image when image.HasTopLevelMediaType("image"):
                            messageContents.Add(new MessageInputImageUriBlock(new MessageImageUriParam(image.Uri)));
                            break;

                        case UriContent image when image.HasTopLevelMediaType("image"):
                            messageContents.Add(new MessageInputImageUriBlock(new MessageImageUriParam(image.Uri.AbsoluteUri)));
                            break;

                        case FunctionResultContent result:
                            (functionResults ??= []).Add(result);
                            break;

                        case McpServerToolApprovalResponseContent mcpApproval:
                            (approvalResults ??= []).Add(mcpApproval);
                            break;

                        default:
                            if (content.RawRepresentation is MessageInputContentBlock rawContent)
                            {
                                messageContents.Add(rawContent);
                            }
                            break;
                    }
                }

                if (messageContents.Count > 0)
                {
                    runOptions.ThreadOptions.Messages.Add(new ThreadMessageOptions(
                        chatMessage.Role == ChatRole.Assistant ? MessageRole.Agent : MessageRole.User,
                        messageContents));
                }
            }

            if (instructions is not null)
            {
                // If runOptions.OverrideInstructions was set by the caller, then all instructions are treated
                // as an override. Otherwise, we want all of the instructions to augment the agent's instructions,
                // so insert the agent's at the beginning.
                if (!treatInstructionsAsOverride && !string.IsNullOrEmpty(_agent.Instructions))
                {
                    instructions.Insert(0, _agent.Instructions);
                }

                runOptions.OverrideInstructions = instructions.ToString();
            }

            return (runOptions, functionResults, approvalResults);
        }

        /// <summary>Convert <see cref="FunctionResultContent"/> instances to <see cref="ToolOutput"/> instances.</summary>
        /// <param name="functionResults">The function results to process.</param>
        /// <param name="approvalResults">The MCP tool approval results to process.</param>
        /// <param name="toolOutputs">The generated list of tool outputs, if any could be created.</param>
        /// <param name="toolApprovals">The generated list of tool approvals, if any could be created.</param>
        /// <returns>The run ID associated with the corresponding function call requests.</returns>
        private static string? ConvertFunctionResultsToToolOutput(
            List<FunctionResultContent>? functionResults,
            List<McpServerToolApprovalResponseContent>? approvalResults,
            out List<ToolOutput> toolOutputs,
            out List<ToolApproval> toolApprovals)
        {
            string? runId = null;
            toolOutputs = [];
            toolApprovals = [];

            if (functionResults?.Count > 0)
            {
                foreach (FunctionResultContent frc in functionResults)
                {
                    if (TryParseRunAndCallIds(frc.CallId, out string? parsedRunId, out string? callId) &&
                        (runId is null || runId == parsedRunId))
                    {
                        runId = parsedRunId;
                        toolOutputs.Add(new(callId, frc.Result?.ToString() ?? string.Empty));
                    }
                }
            }

            if (approvalResults?.Count > 0)
            {
                foreach (McpServerToolApprovalResponseContent trc in approvalResults)
                {
                    if (TryParseRunAndCallIds(trc.Id, out string? parsedRunId, out string? callId) &&
                        (runId is null || runId == parsedRunId))
                    {
                        runId = parsedRunId;
                        toolApprovals.Add(new(callId, trc.Approved));
                    }
                }
            }

            return runId;

            static bool TryParseRunAndCallIds(string id, out string? runId, out string? callId)
            {
                // When creating the AIContent instances, we created it with a CallId == [runId, callId].
                // We need to extract the run ID and ensure that the ToolOutput we send back to Azure
                // is only the call ID.
                runId = null;
                callId = null;

                string[]? runAndCallIDs;
                try
                {
                    runAndCallIDs = JsonSerializer.Deserialize(id, AgentsChatClientJsonContext.Default.StringArray);
                }
                catch
                {
                    return false;
                }

                if (runAndCallIDs is null ||
                    runAndCallIDs.Length != 2 ||
                    string.IsNullOrWhiteSpace(runAndCallIDs[0]) || // run ID
                    string.IsNullOrWhiteSpace(runAndCallIDs[1]))   // call ID
                {
                    return false;
                }

                runId = runAndCallIDs[0];
                callId = runAndCallIDs[1];
                return true;
            }
        }

        /// <summary>
        /// <see cref="AITool"/> type that allows for any <see cref="ToolDefinition"/> to be
        /// passed into the <see cref="IChatClient"/> via <see cref="ChatOptions.Tools"/>.
        /// </summary>
        internal sealed class ToolDefinitionAITool(ToolDefinition tool) : AITool
        {
            public override string Name => tool.GetType().Name;
            public ToolDefinition Tool => tool;
            public override object? GetService(Type serviceType, object? serviceKey) =>
                serviceKey is null && serviceType?.IsInstanceOfType(Tool) is true ? Tool :
                base.GetService(serviceType!, serviceKey);
        }

        [JsonSerializable(typeof(JsonElement))]
        [JsonSerializable(typeof(JsonNode))]
        [JsonSerializable(typeof(JsonObject))]
        [JsonSerializable(typeof(string[]))]
        [JsonSerializable(typeof(IDictionary<string, object>))]
        [JsonSerializable(typeof(IReadOnlyDictionary<string, object>))]
        private sealed partial class AgentsChatClientJsonContext : JsonSerializerContext;

        /// <summary>
        /// Provides the same behavior as <see cref="EqualityComparer{ToolDefinition}.Default"/>, except
        /// for FunctionToolDefinition it compares names so that two function tool definitions with the
        /// same name compare equally.
        /// </summary>
        private sealed class ToolDefinitionNameEqualityComparer : IEqualityComparer<ToolDefinition>
        {
            public static ToolDefinitionNameEqualityComparer Instance { get; } = new();

            public bool Equals(ToolDefinition? x, ToolDefinition? y) =>
                x is FunctionToolDefinition xFtd && y is FunctionToolDefinition yFtd ? xFtd.Name.Equals(yFtd.Name) :
                EqualityComparer<ToolDefinition?>.Default.Equals(x, y);

            public int GetHashCode(ToolDefinition obj) =>
                obj is FunctionToolDefinition ftd ? ftd.Name.GetHashCode() :
                EqualityComparer<ToolDefinition>.Default.GetHashCode(obj);
        }
    }
}
