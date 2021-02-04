// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;

namespace Sql.Tests
{
	public class ManagedInstanceActiveDirectoryAdministratorTest
	{
		[Fact]
		public void TestSetManagedInstanceActiveDirectoryAdministrator()
		{
			string aadAdmin = "aadadmin";
			string managedInstanceName = "miaadadmin";

			using (SqlManagementTestContext context = new SqlManagementTestContext(this))
			{
				Guid objectId = new Guid(TestEnvironmentUtilities.GetUserObjectId());
				Guid tenantId = new Guid(TestEnvironmentUtilities.GetTenantId());

				SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
				ResourceGroup resourceGroup= context.CreateResourceGroup();

				// Create vnet and get the subnet id
				VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

				Sku sku = new Sku();
				sku.Name = "MIGP8G4";
				sku.Tier = "GeneralPurpose";
				ManagedInstance instance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name,
					"crud-tests-" + managedInstanceName, new ManagedInstance()
					{
						AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
						AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
						Sku = sku,
						SubnetId = vnet.Subnets[0].Id,
						Tags = new Dictionary<string, string>(),
						Location = TestEnvironmentUtilities.DefaultLocationId,
					});

				Assert.NotNull(instance);

				// Add new Active Directory Admin
				ManagedInstanceAdministrator newAdmin = new ManagedInstanceAdministrator(login: aadAdmin, sid: objectId, tenantId: tenantId);
				ManagedInstanceAdministrator createResult = sqlClient.ManagedInstanceAdministrators.CreateOrUpdate(resourceGroup.Name, instance.Name, newAdmin);
				Assert.Equal(aadAdmin, createResult.Login);

				// Get the current Active Directory Admin
				ManagedInstanceAdministrator getResult = sqlClient.ManagedInstanceAdministrators.Get(resourceGroup.Name, instance.Name);
				Assert.Equal(aadAdmin, getResult.Login);
				Assert.Equal(objectId, getResult.Sid);
				Assert.Equal(tenantId, getResult.TenantId);

				// Delete the Active Directory Admin on server
				sqlClient.ManagedInstanceAdministrators.Delete(resourceGroup.Name, instance.Name);

				// List all Active Directory Admins for isntance.
				Microsoft.Azure.Management.Sql.Models.Page1<ManagedInstanceAdministrator> admins = (Microsoft.Azure.Management.Sql.Models.Page1<ManagedInstanceAdministrator>)sqlClient.ManagedInstanceAdministrators.ListByInstance(resourceGroup.Name, instance.Name);
				Assert.True(admins == null || !admins.GetEnumerator().MoveNext());
			}
		}
	}
}
