// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [CollectionDefinition(nameof(DistroStatsbeatRoutingCollection), DisableParallelization = true)]
    public class DistroStatsbeatRoutingCollection
    {
        // AppContext switches are process-wide; serialize tests that mutate this switch.
    }
}
