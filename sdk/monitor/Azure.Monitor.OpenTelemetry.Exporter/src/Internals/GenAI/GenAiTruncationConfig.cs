// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI
{
    /// <summary>
    /// Selects the custom property value length limits for GenAI semantic convention attributes.
    /// </summary>
    internal static class GenAiTruncationConfig
    {
        /// <summary>
        /// Experimental opt-in that raises the limit for <c>gen_ai.input.messages</c> and
        /// <c>gen_ai.output.messages</c> from 256 KiB to 4 MiB, so that multimodal content
        /// (e.g. base64-encoded images or audio) is kept. Settable through <c>AppContext.SetSwitch</c>
        /// or a runtimeconfig.json configProperty.
        /// </summary>
        /// <remarks>
        /// The feature name matches the Python exporter's <c>gen_ai_input_output_limit_increase</c>
        /// experimental feature.
        /// </remarks>
        internal const string InputOutputLimitIncreaseSwitchName = "Azure.Monitor.OpenTelemetry.Exporter.Experimental.gen_ai_input_output_limit_increase";

        /// <summary>
        /// Limits used by default: every GenAI attribute is truncated at 256 KiB.
        /// </summary>
        internal static readonly Dictionary<string, int> DefaultMaxValueLengths = new Dictionary<string, int>(StringComparer.Ordinal)
        {
            ["gen_ai.input.messages"] = SchemaConstants.GenAi_Properties_MaxValueLength,
            ["gen_ai.output.messages"] = SchemaConstants.GenAi_Properties_MaxValueLength,
            ["gen_ai.system_instructions"] = SchemaConstants.GenAi_Properties_MaxValueLength,
            ["gen_ai.tool.definitions"] = SchemaConstants.GenAi_Properties_MaxValueLength,
            ["gen_ai.tool.call.arguments"] = SchemaConstants.GenAi_Properties_MaxValueLength,
            ["gen_ai.tool.call.result"] = SchemaConstants.GenAi_Properties_MaxValueLength,
            ["gen_ai.evaluation.explanation"] = SchemaConstants.GenAi_Properties_MaxValueLength,
        };

        /// <summary>
        /// Limits used when <see cref="InputOutputLimitIncreaseSwitchName"/> is enabled: GenAI input and
        /// output messages are truncated at 4 MiB, other GenAI attributes at 256 KiB.
        /// </summary>
        internal static readonly Dictionary<string, int> IncreasedMaxValueLengths = new Dictionary<string, int>(DefaultMaxValueLengths, StringComparer.Ordinal)
        {
            ["gen_ai.input.messages"] = SchemaConstants.GenAi_Messages_MaxValueLength,
            ["gen_ai.output.messages"] = SchemaConstants.GenAi_Messages_MaxValueLength,
        };

        /// <remarks>
        /// The <see cref="AppContext"/> switch is read once, when this type is first touched, so it
        /// must be set before the first telemetry is exported. Not readonly so that tests can override it.
        /// </remarks>
        internal static bool IsInputOutputLimitIncreaseEnabled = IsSwitchEnabled(InputOutputLimitIncreaseSwitchName);

        /// <remarks>
        /// <see cref="AppContext.TryGetSwitch"/> also accepts a "true"/"false" string set through
        /// <c>AppContext.SetData</c>, which is how runtimeconfig.json configProperties are surfaced.
        /// </remarks>
        internal static bool IsSwitchEnabled(string switchName)
            => AppContext.TryGetSwitch(switchName, out var enabled) && enabled;

        /// <summary>
        /// Returns the maximum value length for a custom property key.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="defaultMaxValueLength">The limit to use when the key is not a GenAI attribute.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int GetPropertyMaxValueLength(string key, int defaultMaxValueLength)
        {
            var maxValueLengths = IsInputOutputLimitIncreaseEnabled ? IncreasedMaxValueLengths : DefaultMaxValueLengths;
            return maxValueLengths.TryGetValue(key, out var maxValueLength) ? maxValueLength : defaultMaxValueLength;
        }
    }
}
