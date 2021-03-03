// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using FluentAssertions;
using Microsoft.Azure.Management.DeviceUpdate;
using Microsoft.Azure.Management.DeviceUpdate.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalTwins.Tests.ScenarioTests;
using Xunit;

namespace DeviceUpdate.Tests.ScenarioTests
{
    public class DigitalTwinsLifecycleTests : DeviceUpdateTestBase
    {
        [Fact]
        public async Task SimpleTest()
        {
            Assert.True(true);
        }
    }
}
