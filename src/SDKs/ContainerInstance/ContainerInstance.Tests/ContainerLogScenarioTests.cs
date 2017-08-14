using System.Collections.Generic;
using System.Threading;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;

namespace ContainerInstance.Tests
{
    public class ContainerLogScenarioTests
    {
		[Fact]
		public void ContainerLogGetTest()
		{
			using (TestContext context = new TestContext(this))
			{
				string containerInstanceLocation = "westus";

				ResourceGroup resourceGroup = context.CreateResourceGroup("containerlogget-", containerInstanceLocation);
				ContainerInstanceManagementClient containerClient = context.GetClient<ContainerInstanceManagementClient>();

				string containerGroupName = context.GenerateName("containergroup");
				string containerOsType = "Linux";
				string containerName = "test1";
				string containerImage = "nginx";
				int containerPort = 80;
				double containerCpu = 1;
				double containerMemoryInGB = 1.5;

				// Create an empty container group
				ContainerGroup createdContainerGroup = containerClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName, new ContainerGroup
				{
					Location = resourceGroup.Location,
					OsType = containerOsType,
					Containers = new List<Container>
					{
						new Container
						{
							Name = containerName,
							Image = containerImage,
							Ports = new List<ContainerPort>
							{
								new ContainerPort(containerPort)
							},
							Resources = new ResourceRequirements
							{
								Requests = new ResourceRequests
								{
									Cpu = containerCpu,
									MemoryInGB = containerMemoryInGB
								}
							}
						}
					}
				});
				Assert.NotNull(createdContainerGroup);

				// Wait till ready
				ContainerGroupUtilities.WaitTillProvisioningStateSucceeded(containerClient, resourceGroup.Name, containerGroupName);

				// Check that we can list the logs
				Logs logs = containerClient.ContainerLogs.List(resourceGroup.Name, containerName, containerGroupName);
				Assert.NotNull(logs);
				Assert.NotNull(logs.Content);

				// Delete the container group
				containerClient.ContainerGroups.Delete(resourceGroup.Name, containerGroupName);
			}
		}
	}
}
