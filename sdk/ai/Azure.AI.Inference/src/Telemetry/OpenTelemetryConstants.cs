// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Inference.Telemetry
{
    public class OpenTelemetryConstants
    {
        public const string ClientName = "Azure.AI.Inference.ChatCompletionsClient";
        public const string AppContextSwitch = "OpenAI.Experimental.EnableOpenTelemetry";
        public const string EnvironmentVariableTraceContents = "AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED";
        public const string EnvironmentVariableSwitchName = "OPENAI_EXPERIMENTAL_ENABLE_OPEN_TELEMETRY";
    }
}
