// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    public static partial class EdgeOrderExtensions
    {
        /// <summary>
        /// Upload the device artifacts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/bootstrapConfigurations/{name}/uploadArtifacts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Upload_Artifacts</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="bootstrapConfigurationResource"> BootstrapConfigurationResource for extension method. </param>
        /// <param name="serialNumber"> Device Serial Number. </param>
        /// <param name="deviceMetadataContent"> Device Artifacts content. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static ArmOperation<UploadArtifactsResponse> UploadDeviceArtifacts(this BootstrapConfigurationResource bootstrapConfigurationResource, string serialNumber, string deviceMetadataContent, WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(deviceMetadataContent, nameof(deviceMetadataContent));
            Argument.AssertNotNullOrWhiteSpace(serialNumber, nameof(serialNumber));

            var plainTextBytes = Encoding.Unicode.GetBytes(deviceMetadataContent);
            var encodedInventoryDetails = Convert.ToBase64String(plainTextBytes);

            UploadArtifactsContent uploadArtifactsContent = new UploadArtifactsContent(encodedInventoryDetails, serialNumber);
            return bootstrapConfigurationResource.ArtifactsUpload(waitUntil, uploadArtifactsContent, cancellationToken);
        }
    }
}
