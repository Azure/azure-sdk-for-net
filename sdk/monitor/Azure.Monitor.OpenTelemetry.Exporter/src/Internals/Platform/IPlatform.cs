// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Runtime.InteropServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform
{
    internal interface IPlatform
    {
        public string GetEnvironmentVariable(string name);

        public IDictionary GetEnvironmentVariables();

        public bool IsOSPlatform(OSPlatform osPlatform);

        public string GetOSPlatformName();
    }
}
