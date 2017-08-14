using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Xunit;

namespace ContainerInstance.Tests
{
	public class ContainerGroupScenarioTests
	{ 
		[Fact]
		public void ContainerGroupCRUDTests()
		{
			using (TestContext context = new TestContext(this))
			{
				string containerInstanceLocation = "westus";

				ResourceGroup resourceGroup = context.CreateResourceGroup("containergroupcrud-", containerInstanceLocation);
				ContainerInstanceManagementClient containerClient = context.GetClient<ContainerInstanceManagementClient>();

				string containerGroupName = TestContext.GenerateName("containergroup");
				string containerOsType = "Linux";

				string containerName = "test1";
				string containerImage = "nginx";
				int containerPort = 80;
				double containerCpu = 1;
				double containerMemoryInGB = 1.5;

				// Add a container via an update
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
				Assert.Equal(containerGroupName, createdContainerGroup.Name);
				Assert.Equal(containerOsType, createdContainerGroup.OsType);
				Assert.Equal(1, createdContainerGroup.Containers.Count);

				Container updatedContainer = createdContainerGroup.Containers.First();
				Assert.Equal(containerName, updatedContainer.Name);
				Assert.Equal(containerImage, updatedContainer.Image);
				Assert.Equal(1, updatedContainer.Ports.Count);
				Assert.Equal(containerPort, updatedContainer.Ports.First().Port);
				Assert.Equal(containerCpu, updatedContainer.Resources.Requests.Cpu);
				Assert.Equal(containerMemoryInGB, updatedContainer.Resources.Requests.MemoryInGB);

				// Wait till the container group is ready before proceeding
				ContainerGroupUtilities.WaitTillProvisioningStateSucceeded(containerClient, resourceGroup.Name, containerGroupName);

				string containerGroupID = createdContainerGroup.Id;

				// Get the container group
				ContainerGroup getContainerGroup = containerClient.ContainerGroups.Get(resourceGroup.Name, containerGroupName);
				Assert.NotNull(createdContainerGroup);
				Assert.Equal(containerGroupName, getContainerGroup.Name);
				Assert.Equal(containerOsType, getContainerGroup.OsType);

				Container getContainer = getContainerGroup.Containers.First();
				Assert.Equal(containerName, getContainer.Name);
				Assert.Equal(containerImage, getContainer.Image);
				Assert.Equal(1, getContainer.Ports.Count);
				Assert.Equal(containerPort, getContainer.Ports.First().Port);
				Assert.Equal(containerCpu, getContainer.Resources.Requests.Cpu);
				Assert.Equal(containerMemoryInGB, getContainer.Resources.Requests.MemoryInGB);

				// List the container group within the resource group
				IPage<ContainerGroup> listRgContainerGroup = containerClient.ContainerGroups.ListByResourceGroup(resourceGroup.Name);
				Assert.NotNull(listRgContainerGroup);
				Assert.Equal(1, listRgContainerGroup.Count());
				Assert.Equal(containerGroupName, listRgContainerGroup.First().Name);

				// List the container group within the subscription
				IPage<ContainerGroup> listSubContainerGroup = containerClient.ContainerGroups.List();
				Assert.NotNull(listRgContainerGroup);
				Assert.True(listRgContainerGroup.Count() >= 1);
				Assert.True(listRgContainerGroup.Any(x => containerGroupID.Equals(x?.Id)));

				// Delete the container group
				containerClient.ContainerGroups.Delete(resourceGroup.Name, containerGroupName);
			}
		}
	}
}
