// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Configuration
{
    internal static class OneSettingsConstants
    {
        internal static readonly TimeSpan DefaultRefreshInterval = TimeSpan.FromHours(1);
    }
}
