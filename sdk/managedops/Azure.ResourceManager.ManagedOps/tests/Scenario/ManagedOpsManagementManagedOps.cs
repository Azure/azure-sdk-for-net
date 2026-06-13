// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedOps.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedOps.Tests.Scenario
{
	public class ManagedOpsManagementManagedOps : ManagedOpsManagementTestBase
	{
		private const string ManagedOpsName = "default";

		public ManagedOpsManagementManagedOps(bool isAsync)
			: base(isAsync)
		{
		}

		/// <summary>
		/// Tests for Create/Update, Get, Patch, Get, and Delete operations for ManagedOps resource.
		/// Creates a ManagedOps resource without enabling Defender, then updates it to enable
		/// Defender before deleting it, verifying each operation's success along the way.
		/// </summary>
		[TestCase]
		[RecordedTest]
		public async Task CreateManagedOpsUpdateAndDelete()
		{
			ManagedOpCollection collection = DefaultSubscription.GetManagedOps();

			try {
				// Create the ManagedOps resource with Defender disabled
				ManagedOpResource managedOp = await CreateOrUpdateManagedOpAsync(enableDefender: false);
				Assert.IsNotNull(managedOp);
				Assert.IsNotNull(managedOp.Data);

				ManagedOpResource fetched = await collection.GetAsync(ManagedOpsName);
				Assert.AreEqual(managedOp.Id, fetched.Id);

				// Update the ManagedOps resource to dnable Defender
				var patchBody = new ManagedOpPatch
				{
					ManagedOpUpdateDesiredConfiguration = new ManagedOpsDesiredConfigurationUpdate()
					{
						DefenderForServers = ManagedOpsDesiredEnablementState.Enable,
						DefenderCspm = ManagedOpsDesiredEnablementState.Enable,
					}
				};

				ArmOperation<ManagedOpResource> updateLro = await managedOp.UpdateAsync(WaitUntil.Completed, patchBody);
				ManagedOpResource updated = updateLro.Value;
				Assert.IsNotNull(updated.Data);

				ManagedOpResource fetchedAfterPatch = await collection.GetAsync(ManagedOpsName);
				var desiredConfig = fetchedAfterPatch.Data.Properties.DesiredConfiguration;
				Assert.AreEqual(ManagedOpsDesiredEnablementState.Enable, desiredConfig.DefenderForServers);
				Assert.AreEqual(ManagedOpsDesiredEnablementState.Enable, desiredConfig.DefenderCspm);
			}
			finally
			{
				// Regardless of test success, attempt to delete the created resource
				ManagedOpResource managedOp = await collection.GetAsync(ManagedOpsName);

				await managedOp.DeleteAsync(WaitUntil.Completed);

				// If deletion was successful, verify the resource is gone and a 404 is returned
				RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await collection.GetAsync(ManagedOpsName));
				Assert.AreEqual(404, ex.Status);
			}
		}

		private async Task<ManagedOpResource> CreateOrUpdateManagedOpAsync(bool enableDefender)
		{
			ManagedOpCollection collection = DefaultSubscription.GetManagedOps();
			var data = new ManagedOpData
            {
				Properties = new ManagedOpsProperties(CreateDesiredConfiguration(enableDefender))
			};

			ArmOperation<ManagedOpResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ManagedOpsName, data);
			return lro.Value;
		}

		private ManagedOpsDesiredConfiguration CreateDesiredConfiguration(bool enableDefender)
		{
			var logAnalyticsWorkspaceId = new ResourceIdentifier(TestEnvironment.ChangeTrackingWorkspaceId);
			var azureMonitorWorkspaceId = new ResourceIdentifier(TestEnvironment.AzureMonitorWorkspaceId);
			var userAssignedIdentityId = new ResourceIdentifier(TestEnvironment.UserAssignedManagedIdentityId);

			ManagedOpsDesiredEnablementState defenderSetting = enableDefender
				? ManagedOpsDesiredEnablementState.Enable
				: ManagedOpsDesiredEnablementState.Disable;

			return new ManagedOpsDesiredConfiguration(
				logAnalyticsWorkspaceId,
				azureMonitorWorkspaceId,
				userAssignedIdentityId)
			{
				DefenderForServers = defenderSetting,
				DefenderCspm = defenderSetting
			};
		}
	}
}
