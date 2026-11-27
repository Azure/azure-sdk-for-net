// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [CollectionDefinition(nameof(GenAiTruncationSwitchCollection), DisableParallelization = true)]
    public class GenAiTruncationSwitchCollection
    {
        // The gen_ai_input_output_limit_increase switch is process-wide; serialize tests that mutate it.
    }
}
