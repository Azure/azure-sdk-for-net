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
		[Fact(Skip = "Needs to be executed manually due to setup difficulty.")]
		public void TestSetManagedInstanceActiveDirectoryAdministrator()
		{
			string aadAdmin = "aadadmin";
			string managedInstanceName = "miaadadmin";

			using (SqlManagementTestContext context = new SqlManagementTestContext(this))
			{
				Guid objectId = new Guid(TestEnvironmentUtilities.GetUserObjectId());
				Guid tenantId = new Guid(TestEnvironmentUtilities.GetTenantId());

				SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
				ResourceGroup resourceGroup = context.CreateResourceGroup();

				ManagedInstance instance = context.CreateManagedInstance(resourceGroup);

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
