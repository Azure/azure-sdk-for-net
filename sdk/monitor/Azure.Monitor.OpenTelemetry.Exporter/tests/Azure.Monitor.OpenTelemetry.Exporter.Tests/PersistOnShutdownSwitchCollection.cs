// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [CollectionDefinition(nameof(PersistOnShutdownSwitchCollection), DisableParallelization = true)]
    public class PersistOnShutdownSwitchCollection
    {
        // AppContext switches are process-wide; serialize tests that mutate them.
    }
}
