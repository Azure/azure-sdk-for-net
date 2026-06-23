// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.IotHub
{
    /// <summary>
    /// A class representing a collection of <see cref="IotHubDescriptionResource"/> and their operations.
    /// Each <see cref="IotHubDescriptionResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="IotHubDescriptionCollection"/> instance call the GetIotHubDescriptions method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    // Customization justification:
    // The generated ARM method uses Azure.Core.ETag for If-Match, which is the preferred Azure SDK type.
    // The previous GA IoT Hub package exposed the same header as string on hub create/update, so removing
    // the string overload would force existing callers to change source. This overload is a thin adapter:
    // it converts string to nullable ETag and delegates to generated code so request construction,
    // diagnostics, and long-running-operation handling stay centralized.
    public partial class IotHubDescriptionCollection
    {
        /// <summary>
        /// Create or update the metadata of an Iot hub. The usual pattern to modify a property is to retrieve the IoT hub metadata and security metadata, and then combine them with the modified values in a new body to update the IoT hub.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> IotHubDescriptions_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceName"> The name of the IoT hub. </param>
        /// <param name="data"> The IoT hub metadata and security metadata. </param>
        /// <param name="ifMatch"> ETag of the IoT Hub. Do not specify for creating a brand new IoT Hub. Required to update an existing IoT Hub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IotHubDescriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resourceName, IotHubDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, resourceName, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create or update the metadata of an Iot hub. The usual pattern to modify a property is to retrieve the IoT hub metadata and security metadata, and then combine them with the modified values in a new body to update the IoT hub.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> IotHubDescriptions_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceName"> The name of the IoT hub. </param>
        /// <param name="data"> The IoT hub metadata and security metadata. </param>
        /// <param name="ifMatch"> ETag of the IoT Hub. Do not specify for creating a brand new IoT Hub. Required to update an existing IoT Hub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IotHubDescriptionResource> CreateOrUpdate(WaitUntil waitUntil, string resourceName, IotHubDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, resourceName, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }
}
