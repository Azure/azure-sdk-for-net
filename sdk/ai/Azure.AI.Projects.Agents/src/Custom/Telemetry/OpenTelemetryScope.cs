// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Core;
using static Azure.AI.Projects.Agents.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Projects.Agents.Telemetry
{
    internal class OpenTelemetryScope : IDisposable
    {
        private const int MaxVoiceAgentInstructionsLength = 4096;

        internal enum OpenTelemetryScopeType
        {
            Unknown,
            CreateAgent,
            CreateThread,
            CreateMessage,
            CreateRun,
            ListMessages,
            SubmitToolOutputs,
            ListRunSteps
        }

        /// <summary>
        /// Activity source is used to save events and log the tags.
        /// On the ApplicationInsights events are logged to traces table.
        /// The tags are not logged, but are shown in the console.
        /// </summary>
        private static readonly ActivitySource s_agentSource = new(ClientName);
        /// <summary>
        /// Add histograms to log metrics.
        /// On the ApplicationInsights metrics are logged to customMetrics table.
        /// </summary>
        private static readonly Meter s_meter = new Meter(ClientName);
        private static readonly Histogram<double> s_duration = s_meter.CreateHistogram<double>(
            GenAiClientOperationDurationMetricName, "s", "Measures GenAI operation duration.");
        private static readonly Histogram<long> s_tokens = s_meter.CreateHistogram<long>(
            GenAiClientTokenUsageMetricName, "{token}", "Measures the number of input and output token used.");
        private static readonly JsonSerializerOptions s_jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Allow non-ASCII characters
        };

        private readonly Activity _activity;
        private readonly Stopwatch _duration;
        private readonly TagList _commonTags;
        private static bool s_traceContent = AppContextSwitchHelper.GetConfigValue(
            TraceContentsSwitch,
            TraceContentsEnvironmentVariable);
        private static bool s_enableTelemetry = InitializeGenAITelemetry();
        private static bool s_useMessageEvents = AppContextSwitchHelper.GetConfigValue(
            UseMessageEventsSwitch,
            UseMessageEventsEnvironmentVariable);
        private RecordedResponse _response;
        private string _errorType;
        private Exception _exception;

        private int _hasEnded = 0;
        private readonly OpenTelemetryScopeType _scopeType;
        private readonly bool _isVoiceAgentOperation;

        private void RecordVoiceAgentResponse(PipelineResponse response, bool bufferResponse)
        {
            if (!s_enableTelemetry || Volatile.Read(ref _hasEnded) != 0)
            {
                return;
            }

            _activity?.SetTag(HttpResponseStatusCodeKey, response.Status);
            if (response.IsError)
            {
                _errorType = response.Status.ToString(CultureInfo.InvariantCulture);
            }
            else if (bufferResponse)
            {
                // Never buffer or consume a protocol caller's streaming response for telemetry.
                try
                {
                    using JsonDocument document = JsonDocument.Parse(response.Content);
                    JsonElement root = document.RootElement;
                    if (root.ValueKind == JsonValueKind.Object)
                    {
                        _response = new RecordedResponse(false);
                        if (root.TryGetProperty("id", out JsonElement id) && id.ValueKind == JsonValueKind.String)
                        {
                            _response.AgentId = id.GetString();
                        }
                        if (root.TryGetProperty("name", out JsonElement name) && name.ValueKind == JsonValueKind.String)
                        {
                            SetTagMaybe(GenAiAgentNameKey, name.GetString());
                        }
                        if (root.TryGetProperty("version", out JsonElement version) && version.ValueKind == JsonValueKind.String)
                        {
                            _response.Version = version.GetString();
                        }
                        else if (root.TryGetProperty("versions", out JsonElement versions) && versions.ValueKind == JsonValueKind.Object &&
                            versions.TryGetProperty("latest", out JsonElement latest) && latest.ValueKind == JsonValueKind.Object &&
                            latest.TryGetProperty("version", out version) && version.ValueKind == JsonValueKind.String)
                        {
                            _response.Version = version.GetString();
                        }
                    }
                }
                catch (JsonException)
                {
                    // A malformed protocol response must not turn a successful HTTP call into a failure.
                    SetTagMaybe(VoiceAgentTelemetryErrorTypeKey, typeof(JsonException).FullName);
                }
            }
        }

        /// <summary>
        /// Initializes GenAI telemetry by checking the GenAI-specific feature flag and
        /// enabling the underlying Azure.Core ActivitySource when GenAI tracing is enabled.
        /// This allows GenAI tracing to remain experimental independently of when general
        /// OpenTelemetry support becomes stable in Azure SDKs.
        /// </summary>
        private static bool InitializeGenAITelemetry()
        {
            bool isEnabled = AppContextSwitchHelper.GetConfigValue(
                EnableOpenTelemetrySwitch,
                EnableOpenTelemetryEnvironmentVariable);

            // When GenAI tracing is enabled, also enable the underlying Azure.Core ActivitySource
            if (isEnabled)
            {
                AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
            }

            return isEnabled;
        }

        private static void ReinitializeConfiguration()
        {
            s_traceContent = AppContextSwitchHelper.GetConfigValue(
                TraceContentsSwitch,
                TraceContentsEnvironmentVariable);

            s_enableTelemetry = InitializeGenAITelemetry();

            s_useMessageEvents = AppContextSwitchHelper.GetConfigValue(
                UseMessageEventsSwitch,
                UseMessageEventsEnvironmentVariable);
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for agent creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="endpoint">The endpoint being called.</param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public static OpenTelemetryScope StartCreateAgent(Uri endpoint, BinaryContent content, RequestOptions options = null)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            // Convert BinaryContent back to AgentVersionCreationOptions
            using var memoryStream = new MemoryStream();
            content.WriteTo(memoryStream, CancellationToken.None);
            memoryStream.Position = 0;

            BinaryData binaryData = BinaryData.FromStream(memoryStream);
            InternalCreateAgentRequest creationOptions = ModelReaderWriter.Read<InternalCreateAgentRequest>(
                binaryData,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsAgentsContext.Default
            );
            // The create-request deserialization hook does not populate Definition. Recover voice
            // metadata without changing the existing telemetry for other agent definitions.
            ProjectsAgentDefinition definition = creationOptions.Definition ?? ReadVoiceAgentDefinition(binaryData);
#pragma warning disable AAIP001
            bool isVoiceAgent = definition is VoiceAgentDefinition;
#pragma warning restore AAIP001
            string operationName = isVoiceAgent ? OperationNameValueCreateAgent : OperationNameValueCreateAgent + " " + creationOptions.Name;
            var scope = new OpenTelemetryScope(operationName, endpoint, OperationNameValueCreateAgent, isVoiceAgent);
            if (!isVoiceAgent && scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            SetAgentDefinitionTelemetryTags(scope, definition, creationOptions.Name);

            return scope;
        }

        private static ProjectsAgentDefinition ReadVoiceAgentDefinition(BinaryData content)
        {
            using JsonDocument document = JsonDocument.Parse(content);
            if (document.RootElement.TryGetProperty("definition", out JsonElement definition) &&
                definition.ValueKind == JsonValueKind.Object &&
                definition.TryGetProperty("kind", out JsonElement kind) &&
                kind.ValueKind == JsonValueKind.String && kind.ValueEquals("voice"))
            {
#pragma warning disable AAIP001
                return VoiceAgentDefinition.DeserializeVoiceAgentDefinition(definition, ModelSerializationExtensions.WireOptions);
#pragma warning restore AAIP001
            }
            return null;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for agent update.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="endpoint">The endpoint being called.</param>
        /// <param name="agentName"> The name of the agent to create/modify. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public static OpenTelemetryScope StartUpdateAgent(Uri endpoint, string agentName, BinaryContent content, RequestOptions options = null)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            // Convert BinaryContent back to AgentVersionCreationOptions
            using var memoryStream = new MemoryStream();
            content.WriteTo(memoryStream, CancellationToken.None);
            memoryStream.Position = 0;
            BinaryData binaryData = BinaryData.FromStream(memoryStream);
            ProjectsAgentVersionCreationOptions updateOptions = ModelReaderWriter.Read<ProjectsAgentVersionCreationOptions>(
                binaryData,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsAgentsContext.Default
            );

#pragma warning disable AAIP001
            bool isVoiceAgent = updateOptions.Definition is VoiceAgentDefinition;
#pragma warning restore AAIP001
            string operationName = isVoiceAgent ? OperationNameValueCreateAgent : OperationNameValueCreateAgent + " " + agentName;
            var scope = new OpenTelemetryScope(operationName, endpoint, OperationNameValueCreateAgent, isVoiceAgent);
            if (!isVoiceAgent && scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            SetAgentDefinitionTelemetryTags(scope, updateOptions.Definition, agentName);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for agent creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="endpoint">The endpoint being called.</param>
        /// <param name="agentName"> The name of the agent to create/modify. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public static OpenTelemetryScope StartCreateAgentVersion(Uri endpoint, string agentName, BinaryContent content, RequestOptions options = null)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            // Convert BinaryContent back to AgentVersionCreationOptions
            using var memoryStream = new MemoryStream();
            content.WriteTo(memoryStream, CancellationToken.None);
            memoryStream.Position = 0;
            BinaryData binaryData = BinaryData.FromStream(memoryStream);
            ProjectsAgentVersionCreationOptions creationOptions = ModelReaderWriter.Read<ProjectsAgentVersionCreationOptions>(
                binaryData,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsAgentsContext.Default
            );

#pragma warning disable AAIP001
            bool isVoiceAgent = creationOptions.Definition is VoiceAgentDefinition;
#pragma warning restore AAIP001
            string operationName = isVoiceAgent ? OperationNameValueCreateAgent : OperationNameValueCreateAgent + " " + agentName;
            var scope = new OpenTelemetryScope(operationName, endpoint, OperationNameValueCreateAgent, isVoiceAgent);
            if (!isVoiceAgent && scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            SetAgentDefinitionTelemetryTags(scope, creationOptions.Definition, agentName);

            return scope;
        }

        /// <summary>
        /// Sets telemetry tags and events for the agent definition.
        /// </summary>
        /// <param name="scope">The OpenTelemetryScope instance to set tags on.</param>
        /// <param name="agentDefinition">The agent definition to process.</param>
        /// <param name="agentName">The name of the agent.</param>
        private static void SetAgentDefinitionTelemetryTags(OpenTelemetryScope scope, ProjectsAgentDefinition agentDefinition, string agentName)
        {
            // Determine agent type based on the definition type
            string agentType = DetermineAgentType(agentDefinition);

            // Always set agent type and name
            scope.SetTagMaybe(GenAiAgentType, agentType);
            scope.SetTagMaybe(GenAiAgentNameKey, agentName);

            if (agentDefinition is DeclarativeAgentDefinition promptAgentDefinition)
            {
                scope.SetTagMaybe(GenAiRequestModelKey, promptAgentDefinition.Model);
                scope.SetTagMaybe(GenAiRequestTemperatureKey, promptAgentDefinition.Temperature);
                scope.SetTagMaybe(GenAiRequestTopPKey, promptAgentDefinition.TopP);

                var reasoningOptions = promptAgentDefinition.ReasoningOptions;
                if (reasoningOptions != null)
                {
                    scope.SetTagMaybe(GenAiRequestReasoningEffort, reasoningOptions.ReasoningEffortLevel);
                    scope.SetTagMaybe(GenAiRequestReasoningSummary, reasoningOptions.ReasoningSummaryVerbosity);
                }

                RecordSystemInstructions(scope, promptAgentDefinition.Instructions);
            }
#pragma warning disable AAIP001
            else if (agentDefinition is VoiceAgentDefinition voiceAgentDefinition)
            {
                scope.SetTagMaybe(GenAiRequestModelKey, voiceAgentDefinition.Model);
                if (s_traceContent && !string.IsNullOrEmpty(voiceAgentDefinition.Instructions))
                {
                    string instructions = voiceAgentDefinition.Instructions;
                    RecordSystemInstructions(scope, instructions.Length > MaxVoiceAgentInstructionsLength
                        ? instructions.Substring(0, MaxVoiceAgentInstructionsLength)
                        : instructions);
                }
            }
            else if (agentDefinition is WorkflowAgentDefinition workflowAgentDefinition)
            {
                // Handle workflow agent
                // Note: Workflow agents do not have a model, so we don't set GenAiRequestModelKey

                // Get the workflow YAML using reflection since WorkflowYaml is private
                var workflowYamlProperty = typeof(WorkflowAgentDefinition).GetProperty("WorkflowYaml",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                string workflowYaml = workflowYamlProperty?.GetValue(workflowAgentDefinition) as string;

                // Add workflow event - always create event, content depends on recording setting
                string workflowEventContent;
                if (s_traceContent && !string.IsNullOrEmpty(workflowYaml))
                {
                    // Include actual workflow YAML when content recording is enabled
                    workflowEventContent = JsonSerializer.Serialize(
                        new[] { new WorkflowEventContent(workflowYaml) },
                        EventsContext.Default.WorkflowEventContentArray);
                }
                else
                {
                    // Empty array when content recording is disabled
                    workflowEventContent = "[]";
                }

                ActivityTagsCollection workflowTags = new() {
                    { GenAiProviderNameKey, GenAiProviderNameValue},
                    { GenAiEventContent, workflowEventContent }
                };

                scope._activity?.AddEvent(
                    new ActivityEvent(EventNameAgentWorkflow, tags: workflowTags)
                );
            }
#pragma warning restore AAIP001
            // Check for ImageBasedHostedAgentDefinition BEFORE checking for HostedAgentDefinition
            // since ImageBasedHostedAgentDefinition inherits from HostedAgentDefinition
            else if (agentDefinition is HostedAgentDefinition imageBasedHostedAgentDefinition)
            {
                // Handle image-based hosted agent - add all hosted-specific attributes including image
                scope.SetTagMaybe(GenAiAgentHostedCpu, imageBasedHostedAgentDefinition.Cpu);
                scope.SetTagMaybe(GenAiAgentHostedMemory, imageBasedHostedAgentDefinition.Memory);
                scope.SetTagMaybe(GenAiAgentHostedImage, imageBasedHostedAgentDefinition.ContainerConfiguration.Image);

                // Extract protocol and version from ContainerProtocolVersions if available
                if (imageBasedHostedAgentDefinition.Versions != null &&
                    imageBasedHostedAgentDefinition.Versions.Count > 0)
                {
                    var protocolVersion = imageBasedHostedAgentDefinition.Versions[0];

                    // Set protocol name (convert enum to lowercase string for consistency with Python)
                    string protocolName = protocolVersion.Protocol.ToString().ToLowerInvariant();
                    scope.SetTagMaybe(GenAiAgentHostedProtocol, protocolName);
                    scope.SetTagMaybe(GenAiAgentHostedProtocolVersion, protocolVersion.Version);
                }
            }
            else if (agentDefinition is HostedAgentDefinition hostedAgentDefinition)
            {
                // Handle non-image-based hosted agent (fallback for base HostedAgentDefinition)
                scope.SetTagMaybe(GenAiAgentHostedCpu, hostedAgentDefinition.Cpu);
                scope.SetTagMaybe(GenAiAgentHostedMemory, hostedAgentDefinition.Memory);
                scope.SetTagMaybe(GenAiAgentHostedImage, hostedAgentDefinition.ContainerConfiguration.Image);

                // Extract protocol and version from ContainerProtocolVersions if available
                if (hostedAgentDefinition.Versions != null &&
                    hostedAgentDefinition.Versions.Count > 0)
                {
                    var protocolVersion = hostedAgentDefinition.Versions[0];

                    // Set protocol name (convert enum to lowercase string for consistency with Python)
                    string protocolName = protocolVersion.Protocol.ToString().ToLowerInvariant();
                    scope.SetTagMaybe(GenAiAgentHostedProtocol, protocolName);
                    scope.SetTagMaybe(GenAiAgentHostedProtocolVersion, protocolVersion.Version);
                }
            }
            else
            {
                // Unknown agent type - set minimal attributes
                scope.SetTagMaybe(GenAiRequestModelKey, "unknown");
            }
        }

        private static void RecordSystemInstructions(OpenTelemetryScope scope, string instructions)
        {
            if (string.IsNullOrEmpty(instructions))
            {
                return;
            }

            string instructionsJson = JsonSerializer.Serialize(
                new[] { new EventContent(s_traceContent ? instructions : null) },
                EventsContext.Default.EventContentArray
            );

            if (s_useMessageEvents)
            {
                ActivityTagsCollection messageTags = new() {
                    { GenAiProviderNameKey, GenAiProviderNameValue},
                    { GenAiEventContent, instructionsJson }
                };

                scope._activity?.AddEvent(
                    new ActivityEvent(EventNameSystemMessage, tags: messageTags)
                );
            }
            else
            {
                scope._activity?.SetTag(EventNameSystemMessage, instructionsJson);
            }
        }

        /// <summary>
        /// Determines the agent type based on the agent definition.
        /// </summary>
        /// <param name="agentDefinition">The agent definition to analyze.</param>
        /// <returns>The agent type string.</returns>
        private static string DetermineAgentType(ProjectsAgentDefinition agentDefinition)
        {
            // Check for hosted agent first (most specific)
            if (agentDefinition is HostedAgentDefinition)
            {
                return AgentTypeHosted;
            }

            // Check for workflow agent
#pragma warning disable AAIP001
            if (agentDefinition is VoiceAgentDefinition)
            {
                return AgentTypeVoice;
            }

            if (agentDefinition is WorkflowAgentDefinition)
            {
                return AgentTypeWorkflow;
            }
#pragma warning restore AAIP001
            // Check for prompt agent
            if (agentDefinition is DeclarativeAgentDefinition)
            {
                return AgentTypePrompt;
            }

            // Unknown type
            return AgentTypeUnknown;
        }

        private OpenTelemetryScope(string activityName, Uri endpoint, string operationName = null, bool isVoiceAgentOperation = false)
        {
            _isVoiceAgentOperation = isVoiceAgentOperation;
            _scopeType = activityName switch
            {
                var n when n == OperationNameValueCreateAgent => OpenTelemetryScopeType.CreateAgent,
                var n when n == OperationNameValueCreateThread => OpenTelemetryScopeType.CreateThread,
                var n when n == OperationNameValueCreateMessage => OpenTelemetryScopeType.CreateMessage,
                var n when n == OperationNameValueStartThreadRun => OpenTelemetryScopeType.CreateRun,
                var n when n == OperationNameValueListMessage => OpenTelemetryScopeType.ListMessages,
                var n when n == OperationNameValueSubmitToolOutputs => OpenTelemetryScopeType.SubmitToolOutputs,
                var n when n == OperationNameValueListRunSteps => OpenTelemetryScopeType.ListRunSteps,
                _ => OpenTelemetryScopeType.Unknown
            };

            if (operationName == null)
            {
                operationName = activityName;
            }

            _activity = s_agentSource.StartActivity(activityName, ActivityKind.Client);

            // suppress nested client activities from generated code.
            _activity?.SetCustomProperty("az.sdk.scope", bool.TrueString);
            if (isVoiceAgentOperation)
            {
                _activity?.SetCustomProperty("scm.sdk.scope", bool.TrueString);
            }

            // Record the request to telemetry.
            _commonTags = new TagList()
            {
                { GenAiProviderNameKey, GenAiProviderNameValue},
                { GenAiOperationNameKey, operationName},
                { ServerAddressKey, endpoint.Host }
            };
            // Only record port if it is different from 443.
            if (endpoint.Port != 443)
            {
                _commonTags.Add(ServerPortKey, endpoint.Port);
            }
            if (isVoiceAgentOperation)
            {
                _commonTags.Add(VoiceAgentOperationKey, operationName.Substring(operationName.LastIndexOf('.') + 1));
            }

            // Set tags for reporting them to console.
            foreach (KeyValuePair<string, object> kv in _commonTags)
            {
                _activity?.SetTag(kv.Key, kv.Value);
            }
            _activity?.SetTag(AzNamespaceKey, AzureRpNamespaceValue);
            _duration = Stopwatch.StartNew();
        }

        public void RecordCreateAgentResponse(ClientResult response, bool bufferResponse = true)
        {
            if (_isVoiceAgentOperation)
            {
                RecordVoiceAgentResponse(response.GetRawResponse(), bufferResponse);
            }
            else if (s_enableTelemetry)
            {
                ProjectsAgentRecord agentClientResult = response.ToProjectAgentsResult<ProjectsAgentRecord>();
                _response = new RecordedResponse(s_traceContent);
                //var agentResponse = Response.FromValue(PersistentAgent.FromResponse(response), response);
                _response.AgentId = agentClientResult.Id;
            }
        }

        public void RecordUpdateAgentResponse(ClientResult response, bool bufferResponse = true)
        {
            if (_isVoiceAgentOperation)
            {
                RecordVoiceAgentResponse(response.GetRawResponse(), bufferResponse);
            }
            else if (s_enableTelemetry)
            {
                ProjectsAgentRecord agentClientResult = response.ToProjectAgentsResult<ProjectsAgentRecord>();
                _response = new RecordedResponse(s_traceContent);
                //var agentResponse = Response.FromValue(PersistentAgent.FromResponse(response), response);
                _response.AgentId = agentClientResult.Id;
                _response.Version = agentClientResult.Versions.Latest.Version;
            }
        }

        public void RecordCreateAgentVersionResponse(ClientResult response, bool bufferResponse = true)
        {
            if (_isVoiceAgentOperation)
            {
                RecordVoiceAgentResponse(response.GetRawResponse(), bufferResponse);
            }
            else if (s_enableTelemetry)
            {
                ProjectsAgentVersion agentVersion = response.ToProjectAgentsResult<ProjectsAgentVersion>();
                _response = new RecordedResponse(s_traceContent);
                //var agentResponse = Response.FromValue(PersistentAgent.FromResponse(response), response);
                _response.AgentId = agentVersion.Id;
                _response.Version = agentVersion.Version;
            }
        }
        /// <summary>
        /// Log the error.
        /// </summary>
        /// <param name="e">Exception thrown by completion call.</param>
        public void RecordError(Exception e)
        {
            if (s_enableTelemetry)
            {
                if (_isVoiceAgentOperation && e is OperationCanceledException)
                {
                    RecordCancellation();
                    return;
                }

                if (_isVoiceAgentOperation && e is ClientResultException clientResult && clientResult.Status > 0)
                {
                    _errorType = clientResult.Status.ToString(CultureInfo.InvariantCulture);
                    _activity?.SetTag(HttpResponseStatusCodeKey, clientResult.Status);
                }
                else if (e is RequestFailedException requestFailed && requestFailed.Status != 0)
                {
                    _errorType = requestFailed.Status.ToString();
                    if (_isVoiceAgentOperation)
                    {
                        _activity?.SetTag(HttpResponseStatusCodeKey, requestFailed.Status);
                    }
                }
                else
                {
                    _errorType = e?.GetType()?.FullName ?? "error";
                }
                _exception = _isVoiceAgentOperation ? null : e;
            }
        }

        /// <summary>
        /// Record the task cancellation event.
        /// </summary>
        public void RecordCancellation()
        {
            if (s_enableTelemetry)
            {
                if (_isVoiceAgentOperation)
                {
                    _errorType = null;
                    _activity?.SetTag(VoiceAgentCancelledKey, true);
                }
                else
                {
                    _errorType = typeof(TaskCanceledException).FullName;
                }
                _exception = null;
            }
        }

        /// <summary>
        /// Record the events and metrics associated with the response.
        /// </summary>
        private void End()
        {
            TagList finalTags = _commonTags;

            if (!_isVoiceAgentOperation && _errorType == null && !IsResponseValid(_response))
            {
                // If there is no response and no error, it is an unexpected error.
                _errorType = "error";
            }

            if (_errorType != null)
            {
                finalTags.Add(ErrorTypeKey, _errorType);
                _activity?.SetTag(ErrorTypeKey, _errorType);
                _activity?.SetStatus(ActivityStatusCode.Error, _isVoiceAgentOperation ? null : _exception?.Message);
            }

            if (_response == null)
            {
                s_duration.Record(_duration.Elapsed.TotalSeconds, finalTags);
                return;
            }

            if (!string.IsNullOrEmpty(_response.Model))
            {
                finalTags.Add(GenAiResponseModelKey, _response.Model);
                _activity?.SetTag(GenAiResponseModelKey, _response.Model);
            }

            if (!string.IsNullOrEmpty(_response.Version))
            {
                finalTags.Add(GenAiAgentVersion, _response.Version);
                _activity?.SetTag(GenAiAgentVersion, _response.Version);
            }

            if (_response.PromptTokens.HasValue)
            {
                finalTags.Add(GenAiUsageInputTokensKey, _response.PromptTokens);
                _activity?.SetTag(GenAiUsageInputTokensKey, _response.PromptTokens);
            }

            if (_response.CompletionTokens.HasValue)
            {
                finalTags.Add(GenAiUsageOutputTokensKey, _response.CompletionTokens);
                _activity?.SetTag(GenAiUsageOutputTokensKey, _response.CompletionTokens);
            }

            SetTagMaybe(GenAiAgentIdKey, _response.AgentId);
            SetTagMaybe(GenAiThreadIdKey, _response.ThreadId);
            SetTagMaybe(GenAiMessageIdKey, _response.MessageId);
            SetTagMaybe(GenAiRunIdKey, _response.RunId);
            SetTagMaybe(GenAiRunStatusKey, _response.RunStatus);

            // Record input tokens
            if (_response.PromptTokens.HasValue)
            {
                TagList input_tags = finalTags;
                input_tags.Add(GenAiUsageInputTokensKey, "input");
                s_tokens.Record(_response.PromptTokens.Value, input_tags);
            }
            // Record output tokens
            if (_response.CompletionTokens.HasValue)
            {
                TagList output_tags = finalTags;
                output_tags.Add(GenAiUsageOutputTokensKey, "output");
                s_tokens.Record(_response.CompletionTokens.Value, output_tags);
            }
            if (_isVoiceAgentOperation)
            {
                s_duration.Record(_duration.Elapsed.TotalSeconds, finalTags);
            }
        }

        public void Dispose()
        {
            // check if the scope has already ended
            if (s_enableTelemetry && Interlocked.Exchange(ref _hasEnded, 1) == 0)
            {
                try
                {
                    End();
                }
                finally
                {
                    _activity?.Dispose();
                }
            }
        }

        private static bool IsResponseValid(RecordedResponse response)
        {
            return response != null;// && response.Id != null && response.FinishReasons != null;
        }

        /// <summary>
        /// Set the tag on the activity, if the tag is present.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name of tag to set.</param>
        /// <param name="value">Nullable value to be set.</param>
        private void SetTagMaybe<T>(string name, T? value) where T : struct
        {
            if (value.HasValue)
            {
                _activity?.SetTag(name, value.Value);
            }
        }

        private void SetTagMaybe(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _activity?.SetTag(name, value);
            }
        }

        internal static void ResetEnvironmentForTests()
        {
            s_traceContent = AppContextSwitchHelper.GetConfigValue(TraceContentsSwitch, TraceContentsEnvironmentVariable);
            s_enableTelemetry = InitializeGenAITelemetry();
            s_useMessageEvents = AppContextSwitchHelper.GetConfigValue(UseMessageEventsSwitch, UseMessageEventsEnvironmentVariable);
        }
    }
}
