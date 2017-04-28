// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
	/// <summary>
	/// In order to run the tests in Record mode, some test artifacts need to be created manually. Here are the details:
	/// 1. Resource Group - Any permissible name is allowed.
	/// 2. Azure VM: any size, version, created in the above resource group.
	/// 3. Resource Group for Storage Account - Any permissible name is allowed.
	/// 4. Storage Account: any configuration, but should be of the same version of the above VM, created in the resource group specified for the storage account. 
	///    This will be used for the restore operation.
	/// NOTE: Region should preferably be West US. Otherwise, it should be in the same region as the test vault being created.
	/// 
	/// These details need to be updated in the TestSettings.json file. A sample is given here:
	/// 
	/// {
	/// "VirtualMachineName": "pstestv2vm1",
	/// "VirtualMachineResourceGroupName": "pstestrg",
	/// "VirtualMachineType": "Compute",
	/// "RestoreStorageAccountName": "pstestrg4762",
	/// "RestoreStorageAccountResourceGroupName": "pstestrg"
	/// }
	/// 
	/// Here, if the VM is a Classic Compute VM, set VirtualMachineType as "Classic" and if it is a Compute VM, set VirtualMachineType as "Compute"
	/// </summary>
	public class AzureSqlScenarioTests : TestBase, IDisposable
	{
		private const string azureSqlVaultName = "sqlpaasrn";
		private const string azureSqlResourceGroupName = "sqlpaasrg";

		[Fact]
		public void AzureSqlItemContainerPolicyGetTest()
		{
			var testHelper = new TestHelper() { VaultName = azureSqlVaultName, ResourceGroup = azureSqlResourceGroupName };

			using (var context = MockContext.Start(this.GetType().FullName))
			{
				testHelper.Initialize(context);
				var containerUniqueName = TestSettings.Instance.AzureSqlContainerName;
				var itemName = TestSettings.Instance.AzureSqlItemName;
				var policyName = TestSettings.Instance.AzureSqlPolicyName;
				string azureSqlItemType = "AzureSqlDb";
				string itemUniqueName = string.Join(";", azureSqlItemType, itemName);

				// 1. List protected items
				var items = testHelper.ListProtectedItems();
				Assert.NotNull(items);
				Assert.True(items.Any(item => itemName.Contains(item.Name.ToLower())));

				// 2. Get ProtectedItem
				var protectedItem = testHelper.GetProtectedItem(containerUniqueName, itemUniqueName);
				Assert.NotNull(protectedItem);
				Assert.True(itemName == protectedItem.Name);

				// 3. Get policy
				var policy = testHelper.GetPolicyWithRetries(policyName);
				Assert.NotNull(policy);
				Assert.True(policyName == policy.Name);

				// 4. Get container
				Microsoft.Rest.Azure.OData.ODataQuery<BMSContainerQueryObject> odataQuery = new Rest.Azure.OData.ODataQuery<BMSContainerQueryObject>();
				odataQuery.Filter = "backupManagementType eq 'AzureSql'";
				var containers = testHelper.ListContainers(odataQuery);
				Assert.NotNull(containers);
				Assert.True(containers.Any(container => containerUniqueName.Contains(container.Name)));
			}
		}

		public void Dispose()
		{

		}
	}
}
