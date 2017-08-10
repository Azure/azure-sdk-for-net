// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class PacketCaptureImpl 
    {
        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the
        /// capture file (.cap). For linux virtual machine it must start with
        /// /var/captures. Required if no storage ID is provided, otherwise
        /// optional.
        /// </summary>
        /// <param name="filePath">A valid local path on the targeting VM.</param>
        /// <return>The next stage.</return>
        PacketCapture.Definition.IWithCreate PacketCapture.Definition.IWithStorageLocation.WithFilePath(string filePath)
        {
            return this.WithFilePath(filePath) as PacketCapture.Definition.IWithCreate;
        }

        /// <summary>
        /// The ID of the storage account to save the packet capture session.
        /// Required if no local file path is provided.
        /// </summary>
        /// <param name="storageId">The ID of the storage account to save the packet capture session.</param>
        /// <return>The next stage of the definition.</return>
        PacketCapture.Definition.IWithCreateAndStoragePath PacketCapture.Definition.IWithStorageLocation.WithStorageAccountId(string storageId)
        {
            return this.WithStorageAccountId(storageId) as PacketCapture.Definition.IWithCreateAndStoragePath;
        }

        /// <summary>
        /// Set target resource ID, only VM is currently supported.
        /// </summary>
        /// <param name="target">The ID of the targeted resource.</param>
        /// <return>The next stage.</return>
        PacketCapture.Definition.IWithStorageLocation PacketCapture.Definition.IWithTarget.WithTarget(string target)
        {
            return this.WithTarget(target) as PacketCapture.Definition.IWithStorageLocation;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the target id value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPacketCapture.TargetId
        {
            get
            {
                return this.TargetId();
            }
        }

        /// <summary>
        /// Query the status of a running packet capture session asynchronously.
        /// </summary>
        /// <return>Packet capture status.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus> Microsoft.Azure.Management.Network.Fluent.IPacketCapture.GetStatusAsync(CancellationToken cancellationToken)
        {
            return await this.GetStatusAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus;
        }

        /// <summary>
        /// Gets the maximum size of the capture output.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IPacketCapture.TotalBytesPerSession
        {
            get
            {
                return this.TotalBytesPerSession();
            }
        }

        /// <summary>
        /// Gets the number of bytes captured per packet, the remaining bytes are truncated.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IPacketCapture.BytesToCapturePerPacket
        {
            get
            {
                return this.BytesToCapturePerPacket();
            }
        }

        /// <summary>
        /// Stops a specified packet capture session asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task Microsoft.Azure.Management.Network.Fluent.IPacketCapture.StopAsync(CancellationToken cancellationToken)
        {
 
            await this.StopAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the filters value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.PacketCaptureFilter> Microsoft.Azure.Management.Network.Fluent.IPacketCapture.Filters
        {
            get
            {
                return this.Filters() as System.Collections.Generic.IReadOnlyList<Models.PacketCaptureFilter>;
            }
        }

        /// <summary>
        /// Gets the maximum duration of the capture session in seconds.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IPacketCapture.TimeLimitInSeconds
        {
            get
            {
                return this.TimeLimitInSeconds();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the packet capture session. Possible values
        /// include: 'Succeeded', 'Updating', 'Deleting', 'Failed'.
        /// </summary>
        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        Models.ProvisioningState Microsoft.Azure.Management.Network.Fluent.IPacketCapture.ProvisioningState
        {
            get
            {
                return this.ProvisioningState() as Models.ProvisioningState;
            }
        }

        /// <summary>
        /// Query the status of a running packet capture session.
        /// </summary>
        /// <return>Packet capture status.</return>
        Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus Microsoft.Azure.Management.Network.Fluent.IPacketCapture.GetStatus()
        {
            return this.GetStatus() as Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus;
        }

        /// <summary>
        /// Gets the storageLocation value.
        /// </summary>
        Models.PacketCaptureStorageLocation Microsoft.Azure.Management.Network.Fluent.IPacketCapture.StorageLocation
        {
            get
            {
                return this.StorageLocation() as Models.PacketCaptureStorageLocation;
            }
        }

        /// <summary>
        /// Stops a specified packet capture session.
        /// </summary>
        void Microsoft.Azure.Management.Network.Fluent.IPacketCapture.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a
        /// well-formed URI describing the location to save the packet capture.
        /// </summary>
        /// <param name="storagePath">The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the packet capture.</param>
        /// <return>The next stage.</return>
        PacketCapture.Definition.IWithCreate PacketCapture.Definition.IWithCreateAndStoragePath.WithStoragePath(string storagePath)
        {
            return this.WithStoragePath(storagePath) as PacketCapture.Definition.IWithCreate;
        }

        /// <summary>
        /// Set maximum size of the capture output.
        /// </summary>
        /// <param name="totalBytesPerSession">Maximum size of the capture output.</param>
        /// <return>The next stage.</return>
        PacketCapture.Definition.IWithCreate PacketCapture.Definition.IWithCreate.WithTotalBytesPerSession(int totalBytesPerSession)
        {
            return this.WithTotalBytesPerSession(totalBytesPerSession) as PacketCapture.Definition.IWithCreate;
        }

        /// <summary>
        /// Set number of bytes captured per packet, the remaining bytes are truncated.
        /// </summary>
        /// <param name="bytesToCapturePerPacket">Number of bytes captured per packet.</param>
        /// <return>The next stage.</return>
        PacketCapture.Definition.IWithCreate PacketCapture.Definition.IWithCreate.WithBytesToCapturePerPacket(int bytesToCapturePerPacket)
        {
            return this.WithBytesToCapturePerPacket(bytesToCapturePerPacket) as PacketCapture.Definition.IWithCreate;
        }

        /// <summary>
        /// Set maximum duration of the capture session in seconds.
        /// </summary>
        /// <param name="timeLimitInSeconds">Maximum duration of the capture session in seconds.</param>
        /// <return>The next stage.</return>
        PacketCapture.Definition.IWithCreate PacketCapture.Definition.IWithCreate.WithTimeLimitInSeconds(int timeLimitInSeconds)
        {
            return this.WithTimeLimitInSeconds(timeLimitInSeconds) as PacketCapture.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets Begin the definition of packet capture filter.
        /// </summary>
        /// <summary>
        /// Gets the next stage.
        /// </summary>
        PCFilter.Definition.IBlank<PacketCapture.Definition.IWithCreate> PacketCapture.Definition.IWithCreate.DefinePacketCaptureFilter
        {
            get
            {
                return this.DefinePacketCaptureFilter() as PCFilter.Definition.IBlank<PacketCapture.Definition.IWithCreate>;
            }
        }
    }
}