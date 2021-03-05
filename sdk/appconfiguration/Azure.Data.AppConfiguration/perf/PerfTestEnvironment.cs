// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    public sealed class PerfTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetVariable("APPCONFIGURATION_CONNECTION_STRING");

        public static PerfTestEnvironment Instance { get; } = new ();
    }
}