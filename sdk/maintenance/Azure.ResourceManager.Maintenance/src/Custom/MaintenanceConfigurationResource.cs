// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

// In the swagger this delete operation is defined to returen a `MaintenanceConfigurationData` model, but actually the service doesn't return, that cause exception when try to descerialize the response payload .
// Use `directive` to fix the swagger and custom code to keep backward compatibility as this lib has already GAed.

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// A Class representing a MaintenanceConfiguration along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="MaintenanceConfigurationResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetMaintenanceConfigurationResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetMaintenanceConfiguration method.
    /// </summary>
    public partial class MaintenanceConfigurationResource : ArmResource
    {
        /// <summary>
        /// Delete Configuration record
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<MaintenanceConfigurationResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationResource.Delete");
            scope.Start();
            try
            {
                var response = await _maintenanceConfigurationRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(this, response));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete Configuration record
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<MaintenanceConfigurationResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationResource.Delete");
            scope.Start();
            try
            {
                var response = _maintenanceConfigurationRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(this, response));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionAsync(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
