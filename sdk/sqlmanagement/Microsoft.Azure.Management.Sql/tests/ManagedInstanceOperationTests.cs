// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System.Linq;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceOperationTests
    {
        [Fact]
        public void TestCancelManagedInstanceOperation()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                var resourceGroup = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                var managedInstance = context.CreateManagedInstance(resourceGroup);
                var managedInstanceName = managedInstance.Name;
                var resourceGroupName = resourceGroup.Name;

                // Old operations should be excluded from validation.
                var managedInstanceOperations = sqlClient.ManagedInstanceOperations.ListByManagedInstance(resourceGroupName, managedInstanceName);
                int oldOperations = managedInstanceOperations.Count();

                // Sync update managed server.
                sqlClient.ManagedInstances.Update(resourceGroupName, managedInstanceName, new ManagedInstanceUpdate { StorageSizeInGB = 128 });

                managedInstanceOperations = sqlClient.ManagedInstanceOperations.ListByManagedInstance(resourceGroupName, managedInstanceName);
                var operationId = managedInstanceOperations.ElementAt(oldOperations).Name;

                var firstManagedInstanceOperation = sqlClient.ManagedInstanceOperations.Get(resourceGroupName, managedInstanceName, System.Guid.Parse(operationId));

                // Validate that operation finished successfully.
                SqlManagementTestUtilities.ValidateManagedInstanceOperation(firstManagedInstanceOperation, operationId, "UPDATE MANAGED SERVER", 100, "Succeeded", false);

                // Async update server
                var updateManagedInstance = sqlClient.ManagedInstances.UpdateAsync(resourceGroupName, managedInstanceName, new ManagedInstanceUpdate { VCores = 16 });

                do
                {
                    managedInstanceOperations = sqlClient.ManagedInstanceOperations.ListByManagedInstance(resourceGroupName, managedInstanceName);

                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(20000);
                    }
                } while (managedInstanceOperations.Count() < oldOperations + 2 || !managedInstanceOperations.ElementAt(oldOperations + 1).IsCancellable.Value);

                operationId = managedInstanceOperations.ElementAt(oldOperations + 1).Name;

                // Initiate cancel of second update which is in progress.
                sqlClient.ManagedInstanceOperations.Cancel(resourceGroupName, managedInstanceName, System.Guid.Parse(operationId));

                var secondManagedInstanceOperation = sqlClient.ManagedInstanceOperations.Get(resourceGroupName, managedInstanceName, System.Guid.Parse(operationId));

                while (!secondManagedInstanceOperation.State.Equals("Cancelled"))
                {
                    secondManagedInstanceOperation = sqlClient.ManagedInstanceOperations.Get(resourceGroupName, managedInstanceName, System.Guid.Parse(operationId));
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(20000);
                    }
                }

                // Validate that operation was cancelled.
                SqlManagementTestUtilities.ValidateManagedInstanceOperation(secondManagedInstanceOperation, operationId, "UPDATE MANAGED SERVER", 100, "Cancelled", false);
            }
        }
    }
}
