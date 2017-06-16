// Copyright (c) Microsoft Corporation. All rights reserved.
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

        [Fact (Skip ="Docker .Net client and SSHShell require real network connections to be made")]
        [Trait("Samples", "ContainerRegistry")]
        public void ManageContainerRegistryTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageContainerRegistry.Program.RunSample(rollUpClient);
            }
        }
    }
}
