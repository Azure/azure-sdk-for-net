// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
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

                string managedInstanceName = "v-urmila-mi-test";
                string resourceGroup = "v-urmila";

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku();
                sku.Name = "MIGP4G5";
                sku.Tier = "GeneralPurpose";
                sku.Family = "Gen5";

                var managedInstance = sqlClient.ManagedInstances.Get(resourceGroup, managedInstanceName);

                var managedInstanceOperations = sqlClient.ManagedInstanceOperations.ListByManagedInstance(resourceGroup, managedInstanceName);
                int oldOperations = managedInstanceOperations.Count();

                // Update server
                sqlClient.ManagedInstances.Update(resourceGroup, managedInstanceName, new ManagedInstanceUpdate { StorageSizeInGB = 128 });

                managedInstanceOperations = sqlClient.ManagedInstanceOperations.ListByManagedInstance(resourceGroup, managedInstanceName);
                var operationId = managedInstanceOperations.ElementAt(oldOperations).Name;

                var firstManagedInstanceOperation = sqlClient.ManagedInstanceOperations.Get(resourceGroup, managedInstanceName, System.Guid.Parse(operationId));

                SqlManagementTestUtilities.ValidateManagedInstanceOperation(firstManagedInstanceOperation, operationId, "UPDATE MANAGED SERVER", 100, "Succeeded", false);

                // Update server
                var updateManagedInstance = sqlClient.ManagedInstances.UpdateAsync(resourceGroup, managedInstanceName, new ManagedInstanceUpdate { VCores = 16 });

                do
                {
                    managedInstanceOperations = sqlClient.ManagedInstanceOperations.ListByManagedInstance(resourceGroup, managedInstanceName);
                    Thread.Sleep(20000);
                } while (managedInstanceOperations.Count() < oldOperations + 2 || !managedInstanceOperations.ElementAt(oldOperations + 1).IsCancellable.Value);

                operationId = managedInstanceOperations.ElementAt(oldOperations + 1).Name;
                sqlClient.ManagedInstanceOperations.Cancel(resourceGroup, managedInstanceName, System.Guid.Parse(operationId));

                var secondManagedInstanceOperation = sqlClient.ManagedInstanceOperations.Get(resourceGroup, managedInstanceName, System.Guid.Parse(operationId));

                while (!secondManagedInstanceOperation.State.Equals("Cancelled"))
                {
                    secondManagedInstanceOperation = sqlClient.ManagedInstanceOperations.Get(resourceGroup, managedInstanceName, System.Guid.Parse(operationId));
                    Thread.Sleep(20000);
                }

                SqlManagementTestUtilities.ValidateManagedInstanceOperation(secondManagedInstanceOperation, operationId, "UPDATE MANAGED SERVER", 100, "Cancelled", false);
            }
        }
    }
}
