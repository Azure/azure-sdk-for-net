// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.MultiTenantEnabled.Tests
{
    internal static class SwitchInitializer
    {
        /// <remarks>
        /// Runs before any test in this assembly, and therefore before anything touches
        /// <c>MultiTenantConfig</c>, whose value is captured by its static initializer. Setting the
        /// switch from a test method would be too late.
        /// </remarks>
        [ModuleInitializer]
        internal static void EnableMultiTenantExport()
            => AppContext.SetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", true);
    }
}
