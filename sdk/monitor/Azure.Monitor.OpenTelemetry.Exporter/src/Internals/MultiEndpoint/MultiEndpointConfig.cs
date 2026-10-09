// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    internal static class MultiEndpointConfig
    {
        internal const string EnableMultiEndpointRoutingSwitchName = "Azure.Monitor.OpenTelemetry.EnableMultiEndpointRouting";

        /// <remarks>
        /// The <see cref="AppContext"/> switch is read once, when this type is first touched, so it
        /// must be set before the first exporter is constructed.
        /// </remarks>
        internal static readonly bool Enabled = AppContext.TryGetSwitch(EnableMultiEndpointRoutingSwitchName, out var enabled) && enabled;
    }
}
