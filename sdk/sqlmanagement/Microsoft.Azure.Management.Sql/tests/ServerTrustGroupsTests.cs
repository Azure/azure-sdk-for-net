// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using Xunit;
using Microsoft.Azure.Management.Network;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;

namespace Sql.Tests
{
	/// <summary>
	/// Contains tests for testing API for Server Trust Groups
	/// </summary>
	public class ServerTrustGroupsTests
	{
		private void createManagedInstances(SqlManagementTestContext context, ResourceGroup resourceGroup, IList<string> managedInstanceNames)
		{
			SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

			Sku sku = new Sku();
			sku.Name = "MIGP8G4";
			sku.Tier = "GeneralPurpose";

			VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

			foreach(string miName in managedInstanceNames) 
			{
				ManagedInstance managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, miName, new ManagedInstance()
				{
					AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
					AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
					SubnetId = vnet.Subnets[0].Id,
					Tags = new Dictionary<string, string>(),
					Location = TestEnvironmentUtilities.DefaultLocationId,
					Sku = sku,
				});
				Assert.NotNull(managedInstance);
			}
		}

		private IList<ServerInfo> createGroupMembers(SqlManagementClient sqlClient, string resourceGroupName, IList<string> miNames)
		{
			IList<ServerInfo> groupMembers = new List<ServerInfo>();

			foreach(string miName in miNames)
			{
				groupMembers.Add(new ServerInfo($"/subscriptions/{sqlClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{miName}"));
			}

			return groupMembers;
		}

		private void deleteManagedInstances(SqlManagementClient sqlClient, string resourceGroupName, IList<string> miNames)
		{
			foreach(string miName in miNames)
			{
				sqlClient.ManagedInstances.Delete(resourceGroupName, miName);
			}
		}

		[Fact]
		public void TestCreateGetDropServerTrustGroup()
		{
			string stgName = "stg-test";
			IList<string> managedInstanceNames = new List<string>() { "mi1-stg-test", "mi2-stg-test" };
			using (SqlManagementTestContext context = new SqlManagementTestContext(this))
			{
				SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

				ResourceGroup resourceGroup = context.CreateResourceGroup(TestEnvironmentUtilities.DefaultLocationId);
				Assert.NotNull(resourceGroup);
				createManagedInstances(context, resourceGroup, managedInstanceNames);

				IList<ServerInfo> groupMembers = createGroupMembers(sqlClient, resourceGroup.Name, managedInstanceNames);
				IList<string> trustScopes = new List<string>() {"GlobalTransactions"};
				ServerTrustGroup parameters = new ServerTrustGroup(groupMembers, trustScopes);

				ServerTrustGroup serverTrustGroup = sqlClient.ServerTrustGroups.CreateOrUpdate(resourceGroup.Name, TestEnvironmentUtilities.DefaultLocationId, stgName, parameters);
				Assert.NotNull(serverTrustGroup);

				ServerTrustGroup stg = sqlClient.ServerTrustGroups.Get(resourceGroup.Name, TestEnvironmentUtilities.DefaultLocationId, stgName);
				Assert.NotNull(stg);

				IPage<ServerTrustGroup> stgByInstance = sqlClient.ServerTrustGroups.ListByInstance(resourceGroup.Name, managedInstanceNames[0]);
				Assert.True(stgByInstance != null && stgByInstance.GetEnumerator().MoveNext());

				IPage<ServerTrustGroup> stgByLocation = sqlClient.ServerTrustGroups.ListByLocation(resourceGroup.Name, TestEnvironmentUtilities.DefaultLocation);
				Assert.True(stgByLocation != null && stgByLocation.GetEnumerator().MoveNext());

				sqlClient.ServerTrustGroups.Delete(resourceGroup.Name, TestEnvironmentUtilities.DefaultLocationId, stgName);
				deleteManagedInstances(sqlClient, resourceGroup.Name, managedInstanceNames);
				context.DeleteResourceGroup(resourceGroup.Name);
			}
		}
	}
}