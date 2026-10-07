// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(MatchConditions), typeof(CancellationToken))]
    public partial class NetworkCloudVirtualMachineConsoleResource
    {
        /// <summary>
        /// Patch the properties of the provided virtual machine console, or update the tags associated with the virtual machine console. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudVirtualMachineConsoleResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudVirtualMachineConsolePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Patch the properties of the provided virtual machine console, or update the tags associated with the virtual machine console. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudVirtualMachineConsoleResource> Update(WaitUntil waitUntil, NetworkCloudVirtualMachineConsolePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, cancellationToken);

        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudOperationStatusResult> DeleteWithResponse(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, null, cancellationToken);

        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            var operation = await DeleteAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);
            return new CustomNetworkCloudArmOperationWrapper<NetworkCloudOperationStatusResult>(operation);
        }

        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            var operation = Delete(waitUntil, null, cancellationToken);
            return new CustomNetworkCloudArmOperationWrapper<NetworkCloudOperationStatusResult>(operation);
        }

        /// <summary>
        /// Patch the properties of the provided virtual machine console, or update the tags associated with the virtual machine console. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudVirtualMachineConsoleResource> Update(WaitUntil waitUntil, NetworkCloudVirtualMachineConsolePatch patch, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(waitUntil, patch, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);

        /// <summary>
        /// Patch the properties of the provided virtual machine console, or update the tags associated with the virtual machine console. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudVirtualMachineConsoleResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudVirtualMachineConsolePatch patch, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, patch, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudOperationStatusResult> Delete(WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Delete(waitUntil, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);

        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteAsync(WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await DeleteAsync(waitUntil, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);
        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Consoles_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-05-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="NetworkCloudVirtualMachineConsoleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteAsync(WaitUntil waitUntil, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _consolesClientDiagnostics.CreateScope("NetworkCloudVirtualMachineConsoleResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _consolesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, matchConditions, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkCloudArmOperation<NetworkCloudOperationStatusResult> operation = new NetworkCloudArmOperation<NetworkCloudOperationStatusResult>(
                    new NetworkCloudOperationStatusResultOperationSource(),
                    _consolesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary>
        /// Delete the provided virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Consoles_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-05-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="NetworkCloudVirtualMachineConsoleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<NetworkCloudOperationStatusResult> Delete(WaitUntil waitUntil, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _consolesClientDiagnostics.CreateScope("NetworkCloudVirtualMachineConsoleResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _consolesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, matchConditions, context);
                Response response = Pipeline.ProcessMessage(message, context);
                NetworkCloudArmOperation<NetworkCloudOperationStatusResult> operation = new NetworkCloudArmOperation<NetworkCloudOperationStatusResult>(
                    new NetworkCloudOperationStatusResultOperationSource(),
                    _consolesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
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
