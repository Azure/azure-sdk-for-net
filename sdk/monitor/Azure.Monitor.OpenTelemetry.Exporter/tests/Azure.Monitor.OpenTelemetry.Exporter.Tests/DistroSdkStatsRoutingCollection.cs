// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [CollectionDefinition(nameof(DistroSdkStatsRoutingCollection), DisableParallelization = true)]
    public class DistroSdkStatsRoutingCollection
    {
        // AppContext switches are process-wide; serialize tests that mutate this switch.
    }
}
