// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using Xunit;

namespace Sql.Tests
{
	public class ManagedInstanceActiveDirectoryAdministratorTest
	{
		// Use existing resource group and MI for testing.
		//
		private const string ResourceGroupName = "cl_pilot";
		private const string ManagedInstanceName = "t45-bc-wcus";

		[Fact]
		public void TestSetManagedInstanceActiveDirectoryAdministrator()
		{
			string aadAdmin = "DSEngAll";

			using (SqlManagementTestContext context = new SqlManagementTestContext(this))
			{
				Guid tenantId = new Guid(TestEnvironmentUtilities.GetTenantId());
				Guid objectId = new Guid(TestEnvironmentUtilities.GetUserObjectId());

				SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
				ResourceManagementClient resourceClient = context.GetClient<ResourceManagementClient>();
				ManagedInstance instance = sqlClient.ManagedInstances.Get(ResourceGroupName, ManagedInstanceName);

				// Add new Active Directory Admin
				ManagedInstanceAdministrator newAdmin = new ManagedInstanceAdministrator(login: aadAdmin, sid: objectId, tenantId: tenantId);
				ManagedInstanceAdministrator createResult = sqlClient.ManagedInstanceAdministrators.CreateOrUpdate(ResourceGroupName, instance.Name, "ActiveDirectory", newAdmin);
				Assert.Equal(aadAdmin, createResult.Login);

				// Get the current Active Directory Admin
				ManagedInstanceAdministrator getResult = sqlClient.ManagedInstanceAdministrators.Get(ResourceGroupName, instance.Name, "ActiveDirectory");
				Assert.Equal(aadAdmin, getResult.Login);
				Assert.Equal(objectId, getResult.Sid);
				Assert.Equal(tenantId, getResult.TenantId);

				// Delete the Active Directory Admin on server
				sqlClient.ManagedInstanceAdministrators.Delete(ResourceGroupName, instance.Name, "ActiveDirectory");

				// List all Active Directory Admins for isntance.
				Page1<ManagedInstanceAdministrator> admins = (Page1<ManagedInstanceAdministrator>) sqlClient.ManagedInstanceAdministrators.ListByInstance(ResourceGroupName, instance.Name);
				Assert.True(admins == null || !admins.GetEnumerator().MoveNext());
			}
		}
	}
}
