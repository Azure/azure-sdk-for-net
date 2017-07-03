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
    public class ServiceBus : Samples.Tests.TestBase
    {
        public ServiceBus(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void QueueBasicTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ServiceBusQueueBasic.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void PublishSubscribeBasicTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ServiceBusPublishSubscribeBasic.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void QueueAdvanceFeaturesTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ServiceBusQueueAdvanceFeatures.Program.RunSample);
        }


        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void WithClaimBasedAuthorizationTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ServiceBusWithClaimBasedAuthorization.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ServiceBus")]
        public void PublishSubscribeAdvanceFeaturesTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ServiceBusPublishSubscribeAdvanceFeatures.Program.RunSample);
        }
    }
}
