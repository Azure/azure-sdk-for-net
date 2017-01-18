// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class AppService
    {
        public AppService(ITestOutputHelper output)
        {
            Microsoft.Azure.Management.Samples.Common.Utilities.LoggerMethod = output.WriteLine;
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppBasicTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppBasic.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSlotsTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppSlots.Program.RunSample(rollUpClient);
            }
        }

    }
}
