// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Network : Samples.Tests.TestBase
    {
        public Network(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageApplicationGatewayTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageApplicationGateway.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageInternalLoadBalancerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageInternalLoadBalancer.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void CreateSimpleInternetFacingLoadBalancerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                CreateSimpleInternetFacingLoadBalancer.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageInternetFacingLoadBalancerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageInternetFacingLoadBalancer.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageIPAddressTest()
        {            RunSampleAsTest(
                this.GetType().FullName,
                ManageIPAddress.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageNetworkInterfaceTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkInterface.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageNetworkSecurityGroupTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkSecurityGroup.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageSimpleApplicationGatewayTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageSimpleApplicationGateway.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageVirtualNetworkTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageVirtualNetwork.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageVirtualNetworkTestAsync()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                (azure) => ManageVirtualNetworkAsync.Program
                            .RunSampleAsync(azure)
                            .GetAwaiter()
                            .GetResult());
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageNetworkWatcherTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageNetworkWatcher.Program.RunSample);
        }
    }
}
