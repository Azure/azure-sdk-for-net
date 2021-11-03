// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Threading.Tasks;
using Microsoft.Azure.Management.DeviceUpdate.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.DeviceUpdate.Tests.ScenarioTests
{
    public class InstanceOperationsTests : DeviceUpdateTestBase
    {
        private const string AccountName = "aducpsdktestaccount4";
        private const string InstanceName = "orange";

        [Fact]
        public async Task InstanceCrudTests()
        {
            using MockContext context = MockContext.Start(GetType());
            DeviceUpdateClient client = CreateDeviceUpdateClient(context);

            // 1. Create Account

            Account account = new Account(this.Location);

            account = await client.Accounts.CreateAsync(ResourceGroupName, AccountName, account, this.CancellationToken);
            Assert.NotNull(account);

            // 2. Create Instance

            Instance instance = new Instance(this.Location)
            {
                IotHubs = new[]
                {
                    new IotHubSettings(
                        resourceId: "/subscriptions/c574775c-5bbe-4332-ab92-bd41ff6df882/resourceGroups/DeviceUpdateResourceGroup/providers/Microsoft.Devices/IotHubs/orange-aducpsdktestaccount4-iothub",
                        ioTHubConnectionString: "",
                        eventHubConnectionString: "")
                    }
            };

            instance = await client.Instances.CreateAsync(ResourceGroupName, AccountName, InstanceName, instance, this.CancellationToken);
            Assert.NotNull(instance);

            // 3. Get Instance

            instance = await client.Instances.GetAsync(ResourceGroupName, AccountName, InstanceName, this.CancellationToken);
            Assert.NotNull(instance);

            // 4. List Instances by Account

            IPage<Instance> instances = await client.Instances.ListByAccountAsync(ResourceGroupName, AccountName, this.CancellationToken);
            Assert.NotEmpty(instances);

            // 5. Delete Instance

            await client.Instances.DeleteAsync(ResourceGroupName, AccountName, InstanceName, this.CancellationToken);

            // 6. Delete Account

            await client.Accounts.DeleteAsync(ResourceGroupName, AccountName, this.CancellationToken);
        }
    }
}