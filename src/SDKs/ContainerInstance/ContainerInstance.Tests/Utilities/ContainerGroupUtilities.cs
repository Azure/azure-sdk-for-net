using System;
using System.Threading;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Azure.Test.HttpRecorder;

namespace ContainerInstance.Tests
{
    public class ContainerGroupUtilities
    {
		private static readonly TimeSpan WaitTillTimeout = TimeSpan.FromMinutes(15);
		private static readonly TimeSpan DefaultSleepPeriod = TimeSpan.FromSeconds(45);

		private const string SucceededProvisioningState = "Succeeded";
		private const string CreatingProvisioningState = "Creating";

		public static void WaitTillProvisioningStateSucceeded(ContainerInstanceManagementClient client, string resourceGroupName, string containerGroupName)
		{
			DateTime startTime = DateTime.Now;

			TimeSpan sleepPeriod = HttpMockServer.Mode == HttpRecorderMode.Record ? DefaultSleepPeriod : TimeSpan.Zero;

			string status = null;

			while (status == null || status.Equals(CreatingProvisioningState, StringComparison.OrdinalIgnoreCase))
			{
				if(DateTime.Now - startTime > WaitTillTimeout)
				{
					throw new TimeoutException($"Container Group didn't enter provisioning state '{SucceededProvisioningState}' within timeout");
				}

				Thread.Sleep((int)sleepPeriod.TotalMilliseconds);

				ContainerGroup group = client.ContainerGroups.Get(resourceGroupName, containerGroupName);

				status = group.ProvisioningState;
			}

			if(!status.Equals(SucceededProvisioningState, StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException($"Container Group is in '{status}' status, expected '{SucceededProvisioningState}'");
			}
		}
	}
}
