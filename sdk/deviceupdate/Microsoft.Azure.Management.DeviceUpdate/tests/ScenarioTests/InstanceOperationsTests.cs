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
        private const string AccountName = "aducpsdktestaccount2";
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
                        resourceId: "/subscriptions/cba097a0-e1ce-4c43-8bf6-a9dc778278e0/resourceGroups/DeviceUpdateResourceGroup/providers/Microsoft.Devices/IotHubs/orange-aducpsdktestaccount2-iothub",
                        ioTHubConnectionString: "HostName=orange-aducpsdktestaccount2-iothub.azure-devices.net;SharedAccessKeyName=deviceupdateservice;SharedAccessKey=xyz=",
                        eventHubConnectionString: "Endpoint=sb://orange-aducpsdktestaccount2-b93fc34123.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=xyz=;EntityPath=orange-aducpsdktestaccount2")
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