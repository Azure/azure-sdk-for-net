// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    internal interface INetworkSdkStatsBatch
    {
        int Count { get; }
        IEnumerable<string> InstrumentationKeys { get; }
        IReadOnlyDictionary<string, int> ItemCountsByInstrumentationKey { get; }
        string? GetInstrumentationKey(int index);
    }
}
