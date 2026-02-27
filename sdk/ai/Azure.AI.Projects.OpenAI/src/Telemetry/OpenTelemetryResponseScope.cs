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

namespace Azure.AI.Projects.OpenAI.Telemetry
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
                if (root.TryGetProperty("type", out var typeProp) &&
                    typeProp.GetString() == "function_call_output")
                {
                    string callId = root.TryGetProperty("call_id", out var callIdProp)
                        ? callIdProp.GetString()
                        : null;
                    string output = root.TryGetProperty("output", out var outputProp)
                        ? outputProp.GetString()
                        : null;
                    return new ToolCallOutputInfo(callId, output);
                }
            }
            catch
            {
                // Telemetry extraction should never break the user's call.
            }
            return null;
        }

        /// <summary>
        /// Represents a function call tool invocation from the model's response output.
        /// </summary>
        internal readonly struct ToolCallInfo
        {
            public string CallId { get; }
            public string FunctionName { get; }
            public string Arguments { get; }

            public ToolCallInfo(string callId, string functionName, string arguments)
            {
                CallId = callId;
                FunctionName = functionName;
                Arguments = arguments;
            }
        }

        /// <summary>
        /// Represents a function call output provided as input to the model.
        /// </summary>
        internal readonly struct ToolCallOutputInfo
        {
            public string CallId { get; }
            public string Output { get; }

            public ToolCallOutputInfo(string callId, string output)
            {
                CallId = callId;
                Output = output;
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

            RecordResponse(
                responseModel: response.Model,
                responseId: response.Id,
                inputTokens: inputTokens,
                outputTokens: outputTokens,
                outputText: response.GetOutputText(),
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
                        string json = WriteMessagesJson(new[] { _streamedTextBuilder.ToString() }, "assistant", finishReason);
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
                    if (outputItem.TryGetProperty("type", out var typeProp) &&
                        typeProp.GetString() == "function_call")
                    {
                        string callId = outputItem.TryGetProperty("call_id", out var callIdProp)
                            ? callIdProp.GetString()
                            : null;
                        string name = outputItem.TryGetProperty("name", out var nameProp)
                            ? nameProp.GetString()
                            : null;
                        string arguments = outputItem.TryGetProperty("arguments", out var argsProp)
                            ? argsProp.GetRawText()
                            : null;

                        toolCalls ??= new List<ToolCallInfo>();
                        toolCalls.Add(new ToolCallInfo(callId, name, arguments));
                    }
                }
            }
            catch
            {
                // Telemetry extraction should never break the user's call.
            }
            return toolCalls;
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
        /// Uses simple OTEL-compliant format: {"type": "tool_call", "id": "...", "name": "...", "arguments": ...}
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
                            // Write arguments as raw JSON if valid, otherwise as string
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
        /// Uses simple OTEL-compliant format: {"type": "tool_call_response", "id": "...", "result": "..."}
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
                    writer.WriteString("type", "tool_call_response");
                    if (to.CallId != null)
                    {
                        writer.WriteString("id", to.CallId);
                    }
                    if (s_traceContent && to.Output != null)
                    {
                        writer.WritePropertyName("result");
                        // Write result as raw JSON if valid, otherwise as string
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
