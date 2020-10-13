// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.HybridCompute.Tests
{
    using System.Net;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.HybridCompute;
    using Microsoft.Azure.Management.HybridCompute.Tests.Helpers;
    using Microsoft.Azure.Management.Resources.Models;
    using System.Net.Http;
    using Microsoft.Rest;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.HybridCompute.Models;
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;

    public class HybridOperationsTest : TestBase
    {
        [Fact]
        public void GetMachine()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string resourceGroup = "azure-sdk-test";
                string machineName = "TestMachine1";
                HybridComputeManagementClient hybridComputeManagementClient = this.GetHybridComputeManagementClient(context);
                Machine hybridMachine = hybridComputeManagementClient.Machines.Get(resourceGroup, machineName);
                Assert.Equal(machineName, hybridMachine.Name);
                Assert.Equal("westus2", hybridMachine.Location);
                Assert.Equal(1, hybridMachine.Tags.Count);
                Assert.Equal("hybrid", hybridMachine.Tags["type"]);
            }
        }

        [Fact]
        public void GetMachineAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string resourceGroup = "azure-sdk-test";
                string machineName = "TestMachine2";
                HybridComputeManagementClient hybridComputeManagementClient = this.GetHybridComputeManagementClient(context);
                Task<Machine> t = hybridComputeManagementClient.Machines.GetAsync(resourceGroup, machineName);                    
                Machine hybridMachine = t.GetAwaiter().GetResult();                
                Assert.Equal(machineName, hybridMachine.Name);
                Assert.Equal("westus2", hybridMachine.Location);
            }
        }

        [Fact]
        public void DeleteMachine()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string resourceGroup = "hybridrptest";
                string machineName = "testmachine6";
                HybridComputeManagementClient hybridComputeManagementClient = this.GetHybridComputeManagementClient(context);
                hybridComputeManagementClient.Machines.Delete(resourceGroup, machineName);
                Assert.ThrowsAsync<System.Exception>(() => hybridComputeManagementClient.Machines.GetAsync(resourceGroup, machineName));           
            }
        }

        [Fact]
        public void ListByResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string resourceGroup = "hybridrptest";
                int count = 0;
                HybridComputeManagementClient hybridComputeManagementClient = this.GetHybridComputeManagementClient(context);
                var listResponse = hybridComputeManagementClient.Machines.ListByResourceGroup(resourceGroup);
                Assert.NotNull(listResponse);
                foreach (Machine machine in listResponse)
                {
                    count++;
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = hybridComputeManagementClient.Machines.ListByResourceGroupNext(nextLink);
                    Assert.NotNull(listNextResponse);
                    foreach (Machine machine in listNextResponse)
                    {
                        count++;
                    }
                    nextLink = listNextResponse.NextPageLink;
                }
                Assert.Equal(1322, count);
            }
        }

        
        [Fact]
        public void ListBySubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                int testMachineCount = 0;
                int count = 0;
                HybridComputeManagementClient hybridComputeManagementClient = this.GetHybridComputeManagementClient(context);
                var listResponse = hybridComputeManagementClient.Machines.ListBySubscriptionAsync().GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (Machine machine in listResponse)
                {                    
                    if (machine.Name.Contains("TestMachine"))
                    {   
                        testMachineCount++;
                    }
                    count++;
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = hybridComputeManagementClient.Machines.ListBySubscriptionNext(nextLink);
                    Assert.NotNull(listNextResponse);
                    foreach (Machine machine in listNextResponse)
                    {
                        if (machine.Name.Contains("TestMachine"))
                        {
                            testMachineCount++;
                        }
                        count++;
                    }
                    nextLink = listNextResponse.NextPageLink;                    
                }
                Assert.Equal(2, testMachineCount);
                Assert.Equal(1429, count);
            }
        }

    }
}
