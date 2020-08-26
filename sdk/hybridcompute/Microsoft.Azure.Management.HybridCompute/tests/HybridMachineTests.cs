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
    public class HybridMachineTests : TestBase, IDisposable
    {
        const string _resourceGroupName = "AzcmagentTest";
        const string _machineName = "0.10.20225.002";
        const string _location = "eastus2euap";
        private readonly MockContext _context;

        private HybridComputeManagementClient _client;

        public HybridMachineTests()
        {
            _context = MockContext.Start(GetType().FullName);
        }

        private void Initialize()
        {
            _client = this.GetHybridComputeManagementClient(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void Machines_GetMachine()
        {
            Initialize();
            Machine hybridMachine = _client.Machines.Get(_resourceGroupName, _machineName);
            Assert.Equal(_machineName, hybridMachine.Name);
            Assert.Equal(_location, hybridMachine.Location);
        }

        [Fact]
        public async Task Machines_GetMachineAsync()
        {
            Initialize();
            Machine hybridMachine = await _client.Machines.GetAsync(_resourceGroupName, _machineName).ConfigureAwait(false);
            Assert.Equal(_machineName, hybridMachine.Name);
            Assert.Equal("westus2", hybridMachine.Location);
        }

        [Fact]
        public void Machines_DeleteMachine()
        {
            Initialize();
            Machine machine = _client.Machines.ListByResourceGroup(_resourceGroupName)
                // grab a random machine in the resource group but make sure it's not the one used in the other tests.
                .First(m => m.Name != _machineName);
            _client.Machines.Delete(_resourceGroupName, machine.Name);
            Assert.ThrowsAsync<Exception>(async () => await _client.Machines.GetAsync(_resourceGroupName, _machineName).ConfigureAwait(false));
        }

        [Fact]
        public void Machines_ListByResourceGroup()
        {
            Initialize();
            int count = 0;
            IPage<Machine> listResponse = _client.Machines.ListByResourceGroup(_resourceGroupName);
            Assert.NotNull(listResponse);
            foreach (Machine machine in listResponse)
            {
                count++;
            }

            string nextLink = listResponse.NextPageLink;
            while (!string.IsNullOrEmpty(nextLink))
            {
                IPage<Machine> listNextResponse = _client.Machines.ListByResourceGroupNext(nextLink);
                Assert.NotNull(listNextResponse);
                foreach (Machine machine in listNextResponse)
                {
                    count++;
                }
                nextLink = listNextResponse.NextPageLink;
            }
            Assert.Equal(429, count);
        }

        [Fact]
        public void Machines_ListBySubscription()
        {
            IPage<Machine> listResponse = _client.Machines.ListBySubscription();
            Assert.NotNull(listResponse);
            int count = listResponse.Count();

            string nextLink = listResponse.NextPageLink;
            while (!string.IsNullOrEmpty(nextLink))
            {
                IPage<Machine> listNextResponse = _client.Machines.ListBySubscriptionNext(nextLink);
                Assert.NotNull(listNextResponse);
                count += listNextResponse.Count();
                nextLink = listNextResponse.NextPageLink;
            }
            Assert.Equal(440, count);
        }
    }
}
