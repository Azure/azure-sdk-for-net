// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal class MockPlatform : IPlatform
    {
        private readonly Dictionary<string, string> environmentVariables = new Dictionary<string, string>();

        public string OSPlatformName { get; set; } = "UnitTest";
        public Func<OSPlatform, bool> IsOsPlatformFunc { get; set; } = (OSPlatform) => false;
        public void SetEnvironmentVariable(string key, string value) => environmentVariables.Add(key, value);

        public string? GetEnvironmentVariable(string name) => environmentVariables.TryGetValue(name, out var value) ? value : null;

        public IDictionary GetEnvironmentVariables() => environmentVariables;

        public string GetOSPlatformName() => OSPlatformName;

        public bool IsOSPlatform(OSPlatform osPlatform) => IsOsPlatformFunc(osPlatform);
    }
}
