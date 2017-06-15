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

namespace Tests
{
    public class ServiceBus : Samples.Tests.TestBase
    {
        public ServiceBus(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void ServiceBusQueueBasicTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ServiceBusQueueBasic.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void ServiceBusPublishSubscribeBasicTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ServiceBusPublishSubscribeBasic.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void ServiceBusQueueAdvanceFeaturesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ServiceBusQueueAdvanceFeatures.Program.RunSample(rollUpClient);
            }
        }


        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void ServiceBusWithClaimBasedAuthorizationTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ServiceBusWithClaimBasedAuthorization.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void ServiceBusPublishSubscribeAdvanceFeaturesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ServiceBusPublishSubscribeAdvanceFeatures.Program.RunSample(rollUpClient);
            }
        }
    }
}
