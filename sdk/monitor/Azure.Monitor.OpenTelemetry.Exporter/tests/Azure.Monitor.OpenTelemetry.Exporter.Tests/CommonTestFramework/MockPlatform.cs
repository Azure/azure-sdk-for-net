// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public Action<string> CreateDirectoryFunc { get; set; } = (path) => { };
        public string UserName { get; set; } = "UnitTestUser";
        public string ProcessName { get; set; } = "UnitTestProcess";
        public string ApplicationBaseDirectory { get; set; } = "UnitTestDirectory";

        public void SetEnvironmentVariable(string key, string value) => environmentVariables.Add(key, value);

        public string? GetEnvironmentVariable(string name) => environmentVariables.TryGetValue(name, out var value) ? value : null;

        public string GetOSPlatformName() => OSPlatformName;

        public bool IsOSPlatform(OSPlatform osPlatform) => IsOsPlatformFunc(osPlatform);

        public void CreateDirectory(string path) => CreateDirectoryFunc(path);

        public string GetEnvironmentUserName() => UserName;

        public string GetCurrentProcessName() => ProcessName;

        public string GetApplicationBaseDirectory() => ApplicationBaseDirectory;
    }
}
