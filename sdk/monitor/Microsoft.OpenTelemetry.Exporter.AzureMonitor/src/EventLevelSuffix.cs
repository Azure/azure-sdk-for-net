﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal class EventLevelSuffix
    {
        public const string Critical = ".Critical";
        public const string Error = ".Error";
        public const string Warning = ".Warning";
        public const string Informational = ".Informational";
        public const string Verbose = ".Verbose";
    }
}
