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
	/// To run this test case in record mode, we will have to do following presetup.
	/// 1.	Create resource and resource group and replace the value accordingly in following lines of the code.
	/// 			private const string azureSqlVaultName = "sqlpaasrn";
	/// 			private const string azureSqlResourceGroupName = "sqlpaasrg";
	///
	///	2.	Create a policy , Sql Server and and protect the database from Azure Sql Portal.
	///	3.	Replace the values accordingly in TestSetting.json
	///				"AzureSqlItemName": "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c",
	///				"AzureSqlPolicyName": "sqlpaaspolicy",
	///				"AzureSqlContainerName": "AzureSqlContainer;Sql;sqlpaasrg;sqlpaasserver"
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
