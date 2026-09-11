// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class RuntimeConfigurationTests
    {
        [Test]
        public void MultiTenantExportIsEnabledAtProcessStartup()
        {
            Assert.That(AppContext.TryGetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", out var enabled) && enabled, Is.True);
        }
    }
}
#endif