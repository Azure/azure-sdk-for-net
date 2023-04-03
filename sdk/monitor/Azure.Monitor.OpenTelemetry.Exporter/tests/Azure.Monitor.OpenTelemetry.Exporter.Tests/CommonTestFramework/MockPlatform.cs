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
        public string OSPlatformName { get; set; } = "UnitTest";
        public Func<OSPlatform, bool> IsOsPlatformFunc { get; set; } = (OSPlatform) => false;

        public string GetEnvironmentVariable(string name) => string.Empty;

        public IDictionary GetEnvironmentVariables() => new Dictionary<string, string>();

        public string GetOSPlatformName() => OSPlatformName;

        public bool IsOSPlatform(OSPlatform osPlatform) => IsOsPlatformFunc(osPlatform);
    }
}
