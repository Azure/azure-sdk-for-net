// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform
{
    internal interface IPlatform
    {
        /// <summary>
        /// Returns null if the key is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? GetEnvironmentVariable(string name);

        public bool IsOSPlatform(OSPlatform osPlatform);

        public string GetOSPlatformName();

        public void CreateDirectory(string path);

        public string GetEnvironmentUserName();

        public string GetCurrentProcessName();

        public string GetApplicationBaseDirectory();
    }
}
