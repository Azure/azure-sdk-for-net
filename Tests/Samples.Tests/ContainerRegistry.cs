﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class ContainerRegistry : Samples.Tests.TestBase
    {
        public ContainerRegistry(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "ContainerRegistry")]
        public void ManageContainerRegistryTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                if (Microsoft.Azure.Test.HttpRecorder.HttpMockServer.Mode == Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode.Playback)
                {
                    ManageContainerRegistry.Program.RunSample(rollUpClient, true);
                } else
                {
                    ManageContainerRegistry.Program.RunSample(rollUpClient, false);
                }
            }
        }
    }
}
