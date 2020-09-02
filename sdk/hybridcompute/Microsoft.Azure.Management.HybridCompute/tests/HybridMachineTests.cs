// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.HybridCompute;
using Microsoft.Azure.Management.HybridCompute.Models;
using Microsoft.Azure.Management.HybridCompute.Tests.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.HybridCompute.Tests
{
    public class HybridMachineTests : TestBase
    {
        const string _resourceGroupName = "AzcmagentTest";
        const string _machineName = "0.10.20225.002";
        const string _location = "eastus2euap";

        [Fact]
        public void Machines_GetMachine()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridComputeManagementClient(context);
                Machine hybridMachine = client.Machines.Get(_resourceGroupName, _machineName);
                Assert.Equal(_machineName, hybridMachine.Name);
                Assert.Equal(_location, hybridMachine.Location);
            }
        }

        [Fact]
        public async Task Machines_GetMachineAsync()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridComputeManagementClient(context);
                Machine hybridMachine = await client.Machines.GetAsync(_resourceGroupName, _machineName).ConfigureAwait(false);
                Assert.Equal(_machineName, hybridMachine.Name);
                Assert.Equal(_location, hybridMachine.Location);
            }
        }

        [Fact]
        public void Machines_DeleteMachine()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridComputeManagementClient(context);
                Machine machine = client.Machines.ListByResourceGroup(_resourceGroupName)
                    // grab a random machine in the resource group but make sure it's not the one used in the other tests.
                    .First(m => m.Name != _machineName);
                client.Machines.Delete(_resourceGroupName, machine.Name);
                Assert.ThrowsAsync<Exception>(async () => await client.Machines.GetAsync(_resourceGroupName, _machineName).ConfigureAwait(false));
            }
        }

        [Fact]
        public void Machines_ListByResourceGroup()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridComputeManagementClient(context);
                int count = 0;
                IPage<Machine> listResponse = client.Machines.ListByResourceGroup(_resourceGroupName);
                Assert.NotNull(listResponse);
                foreach (Machine machine in listResponse)
                {
                    count++;
                }

                string nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    IPage<Machine> listNextResponse = client.Machines.ListByResourceGroupNext(nextLink);
                    Assert.NotNull(listNextResponse);
                    foreach (Machine machine in listNextResponse)
                    {
                        count++;
                    }
                    nextLink = listNextResponse.NextPageLink;
                }
                Assert.True(count >= 400);
            }
        }

        [Fact]
        public void Machines_ListBySubscription()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridComputeManagementClient(context);
                IPage<Machine> listResponse = client.Machines.ListBySubscription();
                Assert.NotNull(listResponse);
                int count = listResponse.Count();

                string nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    IPage<Machine> listNextResponse = client.Machines.ListBySubscriptionNext(nextLink);
                    Assert.NotNull(listNextResponse);
                    count += listNextResponse.Count();
                    nextLink = listNextResponse.NextPageLink;
                }
                Assert.True(count >= 400);
            }
        }
    }
}
