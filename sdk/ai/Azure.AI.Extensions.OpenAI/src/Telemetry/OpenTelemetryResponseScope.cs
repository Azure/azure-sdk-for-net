// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Telemetry
{
    /// <summary>
    /// OpenTelemetry scope for Responses API operations (CreateResponse).
    /// Handles span creation, input/output message tracing, response attributes, and metrics.
    /// </summary>
    internal sealed class OpenTelemetryResponseScope : IDisposable
    {
        // Semantic convention constants (inlined to avoid cross-assembly dependency)
        private const string ActivitySourceName = "Azure.AI.Projects.ProjectResponsesClient";
        private const string ProviderName = "microsoft.foundry";
        private const string AzNamespace = "Microsoft.CognitiveServices";
        private const string EnableSwitch = "Azure.Experimental.EnableGenAITracing";
        private const string EnableEnvVar = "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING";
        private const string TraceContentSwitch = "Azure.Experimental.TraceGenAIMessageContent";
        private const string TraceContentEnvVar = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";

        private static readonly ActivitySource s_source = new(ActivitySourceName);
        private static readonly Meter s_meter = new(ActivitySourceName);
        private static readonly Histogram<double> s_duration = s_meter.CreateHistogram<double>(
            "gen_ai.client.operation.duration", "s", "Measures GenAI operation duration.");
        private static readonly Histogram<long> s_tokens = s_meter.CreateHistogram<long>(
            "gen_ai.client.token.usage", "{token}", "Measures the number of input and output token used.");

        private readonly Activity _activity;
        private readonly Stopwatch _stopwatch;
        private readonly TagList _commonTags;

        private string _errorType;
        private int _hasEnded;
        private string _responseModel;
        private long? _inputTokens;
        private long? _outputTokens;

        private readonly StringBuilder _streamedTextBuilder = new();
        private string _streamedResponseId;
        private ResponseStatus? _streamedStatus;

        private static bool s_traceContent = GetConfigValue(TraceContentSwitch, TraceContentEnvVar);
        private static bool s_enableTelemetry = InitializeGenAITelemetry();

        /// <summary>
        /// Initializes GenAI telemetry by checking the GenAI-specific feature flag and
        /// enabling the underlying Azure.Core ActivitySource when GenAI tracing is enabled.
        /// This allows GenAI tracing to remain experimental independently of when general
        /// OpenTelemetry support becomes stable in Azure SDKs.
        /// </summary>
        private static bool InitializeGenAITelemetry()
        {
            bool isEnabled = GetConfigValue(
                EnableSwitch,
                EnableEnvVar);

            // When GenAI tracing is enabled, also enable the underlying Azure.Core ActivitySource
            if (isEnabled)
            {
                AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
            }

            return isEnabled;
        }

        internal static void ReinitializeConfiguration()
        {
            s_traceContent = GetConfigValue(TraceContentSwitch, TraceContentEnvVar);
            s_enableTelemetry = GetConfigValue(EnableSwitch, EnableEnvVar);
        }

        internal static bool IsEnabled => s_enableTelemetry && (s_source.HasListeners() || s_duration.Enabled);

        private OpenTelemetryResponseScope(string spanName, string operationName, Uri endpoint)
        {
            _activity = s_source.StartActivity(spanName, ActivityKind.Client);
            _activity?.SetCustomProperty("az.sdk.scope", bool.TrueString);

            _commonTags = new TagList
            {
                { "gen_ai.provider.name", ProviderName },
                { "gen_ai.operation.name", operationName },
                { "server.address", endpoint.Host }
            };

            if (endpoint.Port != 443)
            {
                _commonTags.Add("server.port", endpoint.Port);
            }

            foreach (KeyValuePair<string, object> kv in _commonTags)
            {
                _activity?.SetTag(kv.Key, kv.Value);
            }
            _activity?.SetTag("az.namespace", AzNamespace);

            _stopwatch = Stopwatch.StartNew();
        }

        public static OpenTelemetryResponseScope StartResponseGeneration(
            Uri endpoint,
            string model,
            string agentName,
            string agentId,
            string conversationId,
            IReadOnlyList<string> inputTexts)
        {
            if (!IsEnabled)
            {
                return null;
            }

            string operationName;
            string spanName;
            if (!string.IsNullOrEmpty(agentName))
            {
                operationName = "invoke_agent";
                spanName = $"invoke_agent {agentName}";
            }
            else if (!string.IsNullOrEmpty(model))
            {
                operationName = "chat";
                spanName = $"chat {model}";
            }
            else
            {
                operationName = "chat";
                spanName = "chat";
            }

            var scope = new OpenTelemetryResponseScope(spanName, operationName, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                scope._activity?.Dispose();
                return null;
            }

            scope.SetTagIfNotEmpty("gen_ai.request.model", model);
            scope.SetTagIfNotEmpty("gen_ai.agent.name", agentName);
            scope.SetTagIfNotEmpty("gen_ai.agent.id", agentId);
            scope.SetTagIfNotEmpty("gen_ai.conversation.id", conversationId);

            scope.AddInputMessages(inputTexts);

            return scope;
        }

        internal static OpenTelemetryResponseScope Start(CreateResponseOptions options, Uri endpoint, string defaultModelName)
        {
            if (!IsEnabled)
            {
                return null;
            }

            ExtractOptionsContext(options, defaultModelName, out string agentName, out string agentId, out string model, out string conversationId, out var inputTexts, out var toolOutputs);

            var scope = StartResponseGeneration(endpoint, model, agentName, agentId, conversationId, inputTexts);
            scope?.AddToolCallInputMessages(toolOutputs);
            return scope;
        }

        internal static void ExtractOptionsContext(
            CreateResponseOptions options,
            string defaultModelName,
            out string agentName,
            out string agentId,
            out string model,
            out string conversationId,
            out List<string> inputTexts,
            out List<ToolCallOutputInfo> toolOutputs)
        {
            agentName = options.Agent?.Name;
            agentId = options.Agent is not null
                ? (!string.IsNullOrEmpty(options.Agent.Version)
                    ? $"{options.Agent.Name}:{options.Agent.Version}"
                    : options.Agent.Name)
                : null;
            model = options.Model ?? defaultModelName;
            conversationId = options.AgentConversationId;

            inputTexts = new List<string>();
            toolOutputs = new List<ToolCallOutputInfo>();
            foreach (ResponseItem inputItem in options.InputItems)
            {
                string text = ExtractInputText(inputItem);
                if (text != null)
                {
                    inputTexts.Add(text);
                    continue;
                }

                var toolOutput = ExtractToolCallOutput(inputItem);
                if (toolOutput != null)
                {
                    toolOutputs.Add(toolOutput.Value);
                }
            }
        }

        private static string ExtractInputText(ResponseItem item)
        {
            try
            {
                using var doc = JsonDocument.Parse(
                    ModelReaderWriter.Write(
                        item,
                        ModelReaderWriterOptions.Json,
                        OpenAIContext.Default).ToString());

                var root = doc.RootElement;
                if (root.TryGetProperty("role", out var roleProp) &&
                    roleProp.GetString() == "user" &&
                    root.TryGetProperty("content", out var contentProp))
                {
                    if (contentProp.ValueKind == JsonValueKind.String)
                    {
                        return contentProp.GetString();
                    }
                    if (contentProp.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var part in contentProp.EnumerateArray())
                        {
                            if (part.TryGetProperty("type", out var typeProp) &&
                                (typeProp.GetString() == "input_text" || typeProp.GetString() == "text") &&
                                part.TryGetProperty("text", out var textProp))
                            {
                                return textProp.GetString();
                            }
                        }
                    }
                }
            }
            catch
            {
                // Telemetry extraction should never break the user's call.
            }
            return null;
        }

        private static ToolCallOutputInfo? ExtractToolCallOutput(ResponseItem item)
        {
            try
            {
                using var doc = JsonDocument.Parse(
                    ModelReaderWriter.Write(
                        item,
                        ModelReaderWriterOptions.Json,
                        OpenAIContext.Default).ToString());

                var root = doc.RootElement;
                if (!root.TryGetProperty("type", out var typeProp))
                {
                    return null;
                }

                string type = typeProp.GetString();
                if (type == null)
                {
                    return null;
                }

                // function_call_output: simple format (backward compatible)
                if (type == "function_call_output")
                {
                    string callId = GetStringProp(root, "call_id");
                    // Only extract tool output content when content recording is enabled.
                    string output = s_traceContent && root.TryGetProperty("output", out var outputProp)
                        ? outputProp.GetString()
                        : null;
                    return new ToolCallOutputInfo(callId, output);
                }

                // All other *_output types: nested format
                if (type.EndsWith("_output", StringComparison.Ordinal))
                {
                    string callId = GetCallIdFromElement(root);
                    string contentJson = BuildToolOutputContentJson(root, type, callId);
                    return new ToolCallOutputInfo(type, callId, contentJson);
                }
            }
            catch
            {
                // Telemetry extraction should never break the user's call.
            }
            return null;
        }

        /// <summary>
        /// Represents a tool call invocation from the model's response output.
        /// For function_call: uses CallId/FunctionName/Arguments (simple format).
        /// For all other tool types: uses Type/CallId/ContentJson (nested format).
        /// </summary>
        internal readonly struct ToolCallInfo
        {
            public string Type { get; }
            public string CallId { get; }
            public string FunctionName { get; }
            public string Arguments { get; }
            /// <summary>
            /// For non-function tool types, contains the JSON content object
            /// (including type and id) to be written inside the "content" wrapper.
            /// </summary>
            public string ContentJson { get; }

            /// <summary>Constructor for function_call tool type (backward compatible).</summary>
            public ToolCallInfo(string callId, string functionName, string arguments)
            {
                Type = "function_call";
                CallId = callId;
                FunctionName = functionName;
                Arguments = arguments;
                ContentJson = null;
            }

            /// <summary>Constructor for all other tool types (nested format).</summary>
            public ToolCallInfo(string type, string callId, string functionName, string arguments, string contentJson)
            {
                Type = type;
                CallId = callId;
                FunctionName = functionName;
                Arguments = arguments;
                ContentJson = contentJson;
            }
        }

        /// <summary>
        /// Represents a tool call output provided as input to the model.
        /// For function_call_output: uses CallId/Output (simple format).
        /// For all other tool output types: uses Type/CallId/ContentJson (nested format).
        /// </summary>
        internal readonly struct ToolCallOutputInfo
        {
            public string Type { get; }
            public string CallId { get; }
            public string Output { get; }
            /// <summary>
            /// For non-function tool output types, contains the JSON content object
            /// (including type and id) to be written inside the "content" wrapper.
            /// </summary>
            public string ContentJson { get; }

            /// <summary>Constructor for function_call_output (backward compatible).</summary>
            public ToolCallOutputInfo(string callId, string output)
            {
                Type = "function_call_output";
                CallId = callId;
                Output = output;
                ContentJson = null;
            }

            /// <summary>Constructor for all other tool output types (nested format).</summary>
            public ToolCallOutputInfo(string type, string callId, string contentJson)
            {
                Type = type;
                CallId = callId;
                Output = null;
                ContentJson = contentJson;
            }
        }

        public void RecordResponse(
            string responseModel,
            string responseId,
            long? inputTokens,
            long? outputTokens,
            string outputText,
            IReadOnlyList<ToolCallInfo> toolCalls = null,
            string finishReason = null)
        {
            _responseModel = responseModel;
            _inputTokens = inputTokens;
            _outputTokens = outputTokens;

            SetTagIfNotEmpty("gen_ai.response.model", _responseModel);
            SetTagIfNotEmpty("gen_ai.response.id", responseId);

            if (_inputTokens.HasValue)
            {
                _activity?.SetTag("gen_ai.usage.input_tokens", _inputTokens.Value);
            }
            if (_outputTokens.HasValue)
            {
                _activity?.SetTag("gen_ai.usage.output_tokens", _outputTokens.Value);
            }

            AddToolCallOutputMessages(toolCalls);
            AddOutputMessage(outputText, finishReason);
        }

        public void RecordResponse(ResponseResult response)
        {
            if (response == null)
            {
                return;
            }

            long? inputTokens = null;
            long? outputTokens = null;
            if (response.Usage != null)
            {
                inputTokens = response.Usage.InputTokenCount;
                outputTokens = response.Usage.OutputTokenCount;
            }

            string finishReason = response.Status.HasValue ? GetFinishReason(response.Status.Value) : null;

            // Defense-in-depth: strip output text when content recording is off.
            // WriteMessagesJson also guards on s_traceContent, but we avoid passing
            // the raw text through multiple layers when it should not be recorded.
            string outputText;
            if (s_traceContent)
            {
                outputText = response.GetOutputText();
            }
            else
            {
                // Use empty string as a non-null sentinel so the message envelope
                // (with finish_reason) is still emitted without any content.
                if (response.GetOutputText() != null)
                {
                    outputText = string.Empty;
                }
                else
                {
                    outputText = null;
                }
            }

            RecordResponse(
                responseModel: response.Model,
                responseId: response.Id,
                inputTokens: inputTokens,
                outputTokens: outputTokens,
                outputText: outputText,
                toolCalls: ExtractToolCallsFromResponse(response),
                finishReason: finishReason);
        }

        public void RecordError(Exception e)
        {
            _errorType = e?.GetType()?.FullName ?? "error";
            _activity?.SetTag("error.type", _errorType);
            _activity?.SetStatus(ActivityStatusCode.Error, e?.Message);
        }

        internal void RecordStreamingUpdate(StreamingResponseUpdate update)
        {
            if (update == null)
            {
                return;
            }

            try
            {
                if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
                {
                    // Always accumulate text regardless of content recording setting.
                    // We need to know whether text output exists to emit the output message
                    // envelope with finish_reason. The actual text content is only written
                    // to the trace when s_traceContent is true (see WriteMessagesJson).
                    _streamedTextBuilder.Append(textDelta.Delta);
                }
                else if (update is StreamingResponseCompletedUpdate completedUpdate)
                {
                    _responseModel = completedUpdate.Response.Model;
                    _streamedResponseId = completedUpdate.Response.Id;
                    _streamedStatus = completedUpdate.Response.Status;

                    if (completedUpdate.Response.Usage != null)
                    {
                        _inputTokens = completedUpdate.Response.Usage.InputTokenCount;
                        _outputTokens = completedUpdate.Response.Usage.OutputTokenCount;
                    }

                    SetTagIfNotEmpty("gen_ai.response.model", _responseModel);
                    SetTagIfNotEmpty("gen_ai.response.id", _streamedResponseId);

                    if (_inputTokens.HasValue)
                    {
                        _activity?.SetTag("gen_ai.usage.input_tokens", _inputTokens.Value);
                    }
                    if (_outputTokens.HasValue)
                    {
                        _activity?.SetTag("gen_ai.usage.output_tokens", _outputTokens.Value);
                    }

                    var toolCalls = ExtractToolCallsFromResponse(completedUpdate.Response);
                    if (toolCalls != null && toolCalls.Count > 0)
                    {
                        string json = WriteToolCallsJson(toolCalls);
                        AppendToAttribute("gen_ai.output.messages", json);
                    }

                    if (_streamedTextBuilder.Length > 0)
                    {
                        string finishReason = _streamedStatus.HasValue ? GetFinishReason(_streamedStatus.Value) : null;
                        string outputText = s_traceContent ? _streamedTextBuilder.ToString() : null;
                        string json = WriteMessagesJson(new[] { outputText }, "assistant", finishReason);
                        AppendToAttribute("gen_ai.output.messages", json);
                    }

                    RecordMetricsAndCloseActivity();
                }
            }
            catch
            {
            }
        }

        private void RecordMetricsAndCloseActivity()
        {
            if (Interlocked.Exchange(ref _hasEnded, 1) != 0)
            {
                return;
            }

            _stopwatch.Stop();
            TagList finalTags = _commonTags;

            if (_errorType != null)
            {
                finalTags.Add("error.type", _errorType);
            }

            if (!string.IsNullOrEmpty(_responseModel))
            {
                finalTags.Add("gen_ai.response.model", _responseModel);
            }

            s_duration.Record(_stopwatch.Elapsed.TotalSeconds, finalTags);

            if (_inputTokens.HasValue)
            {
                TagList inputTags = finalTags;
                inputTags.Add("gen_ai.token.type", "input");
                s_tokens.Record(_inputTokens.Value, inputTags);
            }
            if (_outputTokens.HasValue)
            {
                TagList outputTags = finalTags;
                outputTags.Add("gen_ai.token.type", "output");
                s_tokens.Record(_outputTokens.Value, outputTags);
            }

            _activity?.Dispose();
        }

        private static string GetFinishReason(ResponseStatus status)
        {
            return status.ToString()?.ToLower();
        }

        private static List<ToolCallInfo> ExtractToolCallsFromResponse(ResponseResult response)
        {
            List<ToolCallInfo> toolCalls = null;
            try
            {
                using var doc = JsonDocument.Parse(
                    ModelReaderWriter.Write(
                        response,
                        ModelReaderWriterOptions.Json,
                        OpenAIContext.Default).ToString());

                var root = doc.RootElement;
                if (!root.TryGetProperty("output", out var outputProp) ||
                    outputProp.ValueKind != JsonValueKind.Array)
                {
                    return null;
                }

                foreach (var outputItem in outputProp.EnumerateArray())
                {
                    if (!outputItem.TryGetProperty("type", out var typeProp))
                    {
                        continue;
                    }

                    string type = typeProp.GetString();
                    if (type == null)
                    {
                        continue;
                    }

                    if (type == "function_call")
                    {
                        string callId = GetStringProp(outputItem, "call_id");
                        // Only extract function name and arguments when content recording is enabled.
                        string name = s_traceContent ? GetStringProp(outputItem, "name") : null;
                        string arguments = s_traceContent && outputItem.TryGetProperty("arguments", out var argsProp)
                            ? argsProp.GetRawText()
                            : null;

                        toolCalls ??= new List<ToolCallInfo>();
                        toolCalls.Add(new ToolCallInfo(callId, name, arguments));
                    }
                    else if (type == "file_search_call" ||
                             type == "code_interpreter_call" ||
                             type == "web_search_call" ||
                             type == "computer_call" ||
                             type == "image_generation_call" ||
                             type == "mcp_call" ||
                             type == "azure_ai_search_call" ||
                             (type.StartsWith("mcp_", StringComparison.Ordinal) && !type.EndsWith("_output", StringComparison.Ordinal)) ||
                             (type.Contains("_call") && !type.EndsWith("_output", StringComparison.Ordinal)))
                    {
                        string callId = GetCallIdFromElement(outputItem);
                        string contentJson = BuildToolContentJson(outputItem, type, callId);

                        toolCalls ??= new List<ToolCallInfo>();
                        toolCalls.Add(new ToolCallInfo(type, callId, null, null, contentJson));
                    }
                }
            }
            catch
            {
                // Telemetry extraction should never break the user's call.
            }
            return toolCalls;
        }

        /// <summary>Extracts id or call_id from a JSON element.</summary>
        private static string GetCallIdFromElement(JsonElement element)
        {
            return GetStringProp(element, "call_id") ?? GetStringProp(element, "id");
        }

        /// <summary>Gets a string property value from a JSON element, or null.</summary>
        private static string GetStringProp(JsonElement element, string propertyName)
        {
            return element.TryGetProperty(propertyName, out var prop) && prop.ValueKind == JsonValueKind.String
                ? prop.GetString()
                : null;
        }

        /// <summary>
        /// Builds the JSON content object for a non-function tool call.
        /// Always includes type and id (safe, non-PII).
        /// Includes type-specific details only when content recording is enabled.
        /// Never includes binary data (images, files).
        /// </summary>
        private static string BuildToolContentJson(JsonElement outputItem, string type, string callId)
        {
            using var ms = new MemoryStream();
            using (var w = new Utf8JsonWriter(ms, new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }))
            {
                w.WriteStartObject();
                w.WriteString("type", type);
                if (callId != null)
                {
                    w.WriteString("id", callId);
                }

                if (s_traceContent)
                {
                    WriteToolSpecificDetails(w, outputItem, type);
                }

                w.WriteEndObject();
            }
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>
        /// Writes type-specific detail properties for each recognized tool type.
        /// Only called when content recording is enabled.
        /// </summary>
        private static void WriteToolSpecificDetails(Utf8JsonWriter w, JsonElement item, string type)
        {
            switch (type)
            {
                case "file_search_call":
                    CopyJsonProp(w, item, "queries");
                    CopyJsonProp(w, item, "results");
                    CopyJsonProp(w, item, "status");
                    break;

                case "code_interpreter_call":
                    CopyJsonProp(w, item, "code");
                    CopyJsonProp(w, item, "outputs");
                    CopyJsonProp(w, item, "status");
                    break;

                case "web_search_call":
                    CopyJsonProp(w, item, "action");
                    CopyJsonProp(w, item, "status");
                    break;

                case "computer_call":
                    CopyJsonProp(w, item, "action");
                    CopyJsonProp(w, item, "status");
                    break;

                case "image_generation_call":
                    // Include metadata but never binary image data (result)
                    CopyJsonProp(w, item, "prompt");
                    CopyJsonProp(w, item, "quality");
                    CopyJsonProp(w, item, "size");
                    CopyJsonProp(w, item, "style");
                    CopyJsonProp(w, item, "status");
                    break;

                case "mcp_call":
                    CopyJsonProp(w, item, "name");
                    CopyJsonProp(w, item, "arguments");
                    CopyJsonProp(w, item, "server_label");
                    CopyJsonProp(w, item, "status");
                    break;

                case "azure_ai_search_call":
                    CopyJsonProp(w, item, "input");
                    CopyJsonProp(w, item, "results");
                    CopyJsonProp(w, item, "status");
                    break;

                case "local_shell_call":
                case "shell_call":
                    CopyJsonProp(w, item, "command");
                    CopyJsonProp(w, item, "output");
                    CopyJsonProp(w, item, "status");
                    break;

                case "apply_patch_call":
                    CopyJsonProp(w, item, "patch");
                    CopyJsonProp(w, item, "status");
                    break;

                case "custom_tool_call":
                    CopyJsonProp(w, item, "name");
                    CopyJsonProp(w, item, "arguments");
                    CopyJsonProp(w, item, "status");
                    break;

                default:
                    // Generic handler for mcp_* types and unknown *_call types:
                    // copy common fields that may be present.
                    CopyJsonProp(w, item, "name");
                    CopyJsonProp(w, item, "arguments");
                    CopyJsonProp(w, item, "server_label");
                    CopyJsonProp(w, item, "input");
                    CopyJsonProp(w, item, "output");
                    CopyJsonProp(w, item, "query");
                    CopyJsonProp(w, item, "status");
                    CopyJsonProp(w, item, "approve");
                    CopyJsonProp(w, item, "approval_request_id");
                    break;
            }
        }

        /// <summary>Copies a JSON property from source to writer if present.</summary>
        private static void CopyJsonProp(Utf8JsonWriter writer, JsonElement source, string propertyName)
        {
            if (source.TryGetProperty(propertyName, out var prop) &&
                prop.ValueKind != JsonValueKind.Null)
            {
                writer.WritePropertyName(propertyName);
                prop.WriteTo(writer);
            }
        }

        /// <summary>
        /// Builds the JSON content object for a non-function tool output item.
        /// Always includes type and id (safe, non-PII).
        /// Includes type-specific output details only when content recording is enabled.
        /// Never includes binary data (images, screenshots).
        /// </summary>
        private static string BuildToolOutputContentJson(JsonElement outputItem, string type, string callId)
        {
            using var ms = new MemoryStream();
            using (var w = new Utf8JsonWriter(ms, new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }))
            {
                w.WriteStartObject();
                w.WriteString("type", type);
                if (callId != null)
                {
                    w.WriteString("id", callId);
                }

                if (s_traceContent)
                {
                    WriteToolOutputSpecificDetails(w, outputItem, type);
                }

                w.WriteEndObject();
            }
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>
        /// Writes type-specific detail properties for each recognized tool output type.
        /// Only called when content recording is enabled.
        /// Binary data (screenshots, images) is never included.
        /// </summary>
        private static void WriteToolOutputSpecificDetails(Utf8JsonWriter w, JsonElement item, string type)
        {
            switch (type)
            {
                case "computer_call_output":
                    // Include output but strip binary data (image_url from computer screenshots).
                    if (item.TryGetProperty("output", out var computerOutput) &&
                        computerOutput.ValueKind == JsonValueKind.Object)
                    {
                        w.WritePropertyName("output");
                        w.WriteStartObject();
                        foreach (var prop in computerOutput.EnumerateObject())
                        {
                            // Skip image_url - binary screenshot data, potential PII/large payload.
                            if (prop.Name == "image_url")
                            {
                                continue;
                            }
                            prop.WriteTo(w);
                        }
                        w.WriteEndObject();
                    }
                    CopyJsonProp(w, item, "status");
                    break;

                case "local_shell_call_output":
                case "shell_call_output":
                    CopyJsonProp(w, item, "output");
                    CopyJsonProp(w, item, "status");
                    break;

                case "apply_patch_call_output":
                    CopyJsonProp(w, item, "output");
                    CopyJsonProp(w, item, "status");
                    break;

                case "custom_tool_call_output":
                    CopyJsonProp(w, item, "output");
                    CopyJsonProp(w, item, "status");
                    break;

                default:
                    // Generic handler for any future *_output types.
                    CopyJsonProp(w, item, "output");
                    CopyJsonProp(w, item, "result");
                    CopyJsonProp(w, item, "status");
                    break;
            }
        }

        public void Dispose()
        {
            RecordMetricsAndCloseActivity();
        }

        private void AddInputMessages(IReadOnlyList<string> inputTexts)
        {
            if (_activity == null || inputTexts == null || inputTexts.Count == 0)
            {
                return;
            }

            string json = WriteMessagesJson(inputTexts, "user");
            _activity.SetTag("gen_ai.input.messages", json);
        }

        /// <summary>
        /// Appends function_call_output items to the input messages attribute.
        /// These represent tool results the user is feeding back to the model.
        /// </summary>
        internal void AddToolCallInputMessages(IReadOnlyList<ToolCallOutputInfo> toolOutputs)
        {
            if (_activity == null || toolOutputs == null || toolOutputs.Count == 0)
            {
                return;
            }

            string json = WriteToolCallOutputsJson(toolOutputs);
            AppendToAttribute("gen_ai.input.messages", json);
        }

        /// <summary>
        /// Appends function_call items from the response to the output messages attribute.
        /// These represent tool calls the model wants the user to execute.
        /// </summary>
        private void AddToolCallOutputMessages(IReadOnlyList<ToolCallInfo> toolCalls)
        {
            if (_activity == null || toolCalls == null || toolCalls.Count == 0)
            {
                return;
            }

            string json = WriteToolCallsJson(toolCalls);
            AppendToAttribute("gen_ai.output.messages", json);
        }

        private void AddOutputMessage(string outputText, string finishReason = null)
        {
            if (_activity == null || outputText == null)
            {
                return;
            }

            string json = WriteMessagesJson(new[] { outputText }, "assistant", finishReason);
            AppendToAttribute("gen_ai.output.messages", json);
        }

        /// <summary>
        /// Appends JSON array content to an existing attribute value, merging the arrays.
        /// </summary>
        private void AppendToAttribute(string attributeName, string newJsonArray)
        {
            string existing = _activity?.GetTagItem(attributeName) as string;
            if (string.IsNullOrEmpty(existing))
            {
                _activity?.SetTag(attributeName, newJsonArray);
                return;
            }

            // Merge two JSON arrays: strip trailing ] from existing, strip leading [ from new
            string merged = existing.Substring(0, existing.Length - 1) + "," + newJsonArray.Substring(1);
            _activity?.SetTag(attributeName, merged);
        }

        private static string WriteMessagesJson(IReadOnlyList<string> texts, string role, string finishReason = null)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }))
            {
                writer.WriteStartArray();
                foreach (string text in texts)
                {
                    writer.WriteStartObject();
                    writer.WriteString("role", role);
                    writer.WriteStartArray("parts");
                    writer.WriteStartObject();
                    writer.WriteString("type", "text");
                    if (s_traceContent && text != null)
                    {
                        writer.WriteString("content", text);
                    }
                    writer.WriteEndObject();
                    writer.WriteEndArray();
                    if (finishReason != null)
                    {
                        writer.WriteString("finish_reason", finishReason);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// Writes tool call items (from model response output) as JSON.
        /// function_call uses simple format: {"type": "tool_call", "id": "...", "name": "...", "arguments": ...}
        /// All other tool types use nested format: {"type": "tool_call", "content": {"type": "web_search_call", ...}}
        /// </summary>
        private static string WriteToolCallsJson(IReadOnlyList<ToolCallInfo> toolCalls)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }))
            {
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WriteString("role", "assistant");
                writer.WriteStartArray("parts");
                foreach (var tc in toolCalls)
                {
                    writer.WriteStartObject();
                    writer.WriteString("type", "tool_call");

                    if (tc.Type == "function_call")
                    {
                        // Simple format for function_call
                        if (tc.CallId != null)
                        {
                            writer.WriteString("id", tc.CallId);
                        }
                        if (s_traceContent)
                        {
                            if (tc.FunctionName != null)
                            {
                                writer.WriteString("name", tc.FunctionName);
                            }
                            if (tc.Arguments != null)
                            {
                                writer.WritePropertyName("arguments");
                                try
                                {
                                    using var argDoc = JsonDocument.Parse(tc.Arguments);
                                    argDoc.RootElement.WriteTo(writer);
                                }
                                catch
                                {
                                    writer.WriteStringValue(tc.Arguments);
                                }
                            }
                        }
                    }
                    else if (tc.ContentJson != null)
                    {
                        // Nested format for all other tool types
                        writer.WritePropertyName("content");
                        try
                        {
                            using var contentDoc = JsonDocument.Parse(tc.ContentJson);
                            contentDoc.RootElement.WriteTo(writer);
                        }
                        catch
                        {
                            writer.WriteStringValue(tc.ContentJson);
                        }
                    }

                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
                writer.WriteEndArray();
            }
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// Writes tool call output items (from user input) as JSON.
        /// function_call_output uses simple format: {"type": "tool_call_response", "id": "...", "result": "..."}
        /// All other tool output types use nested format: {"type": "tool_call_output", "content": {"type": "...", ...}}
        /// </summary>
        private static string WriteToolCallOutputsJson(IReadOnlyList<ToolCallOutputInfo> toolOutputs)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }))
            {
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WriteString("role", "tool");
                writer.WriteStartArray("parts");
                foreach (var to in toolOutputs)
                {
                    writer.WriteStartObject();

                    if (to.Type == "function_call_output")
                    {
                        // Simple format for function_call_output
                        writer.WriteString("type", "tool_call_response");
                        if (to.CallId != null)
                        {
                            writer.WriteString("id", to.CallId);
                        }
                        if (s_traceContent && to.Output != null)
                        {
                            writer.WritePropertyName("result");
                            try
                            {
                                using var resultDoc = JsonDocument.Parse(to.Output);
                                resultDoc.RootElement.WriteTo(writer);
                            }
                            catch
                            {
                                writer.WriteStringValue(to.Output);
                            }
                        }
                    }
                    else if (to.ContentJson != null)
                    {
                        // Nested format for all other tool output types
                        writer.WriteString("type", "tool_call_output");
                        writer.WritePropertyName("content");
                        try
                        {
                            using var contentDoc = JsonDocument.Parse(to.ContentJson);
                            contentDoc.RootElement.WriteTo(writer);
                        }
                        catch
                        {
                            writer.WriteStringValue(to.ContentJson);
                        }
                    }

                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
                writer.WriteEndArray();
            }
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private void SetTagIfNotEmpty(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _activity?.SetTag(name, value);
            }
        }

        private static bool GetConfigValue(string switchName, string envVarName)
        {
            if (AppContext.TryGetSwitch(switchName, out bool value))
            {
                return value;
            }
            string envVar = Environment.GetEnvironmentVariable(envVarName);
            if (envVar != null && (envVar.Equals("true", StringComparison.OrdinalIgnoreCase) || envVar.Equals("1")))
            {
                return true;
            }
            return false;
        }
    }
}
