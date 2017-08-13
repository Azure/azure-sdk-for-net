// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    public interface IWithTarget 
    {
        /// <summary>
        /// Set target resource ID, only VM is currently supported.
        /// </summary>
        /// <param name="target">The ID of the targeted resource.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithStorageLocation WithTarget(string target);
    }

    public interface IWithCreateAndStoragePath  :
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate
    {
        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a
        /// well-formed URI describing the location to save the packet capture.
        /// </summary>
        /// <param name="storagePath">The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the packet capture.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate WithStoragePath(string storagePath);
    }

    public interface IWithStorageLocation 
    {
        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the
        /// capture file (.cap). For linux virtual machine it must start with
        /// /var/captures. Required if no storage ID is provided, otherwise
        /// optional.
        /// </summary>
        /// <param name="filePath">A valid local path on the targeting VM.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate WithFilePath(string filePath);

        /// <summary>
        /// The ID of the storage account to save the packet capture session.
        /// Required if no local file path is provided.
        /// </summary>
        /// <param name="storageId">The ID of the storage account to save the packet capture session.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreateAndStoragePath WithStorageAccountId(string storageId);
    }

    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>
    {
        /// <summary>
        /// Set maximum duration of the capture session in seconds.
        /// </summary>
        /// <param name="timeLimitInSeconds">Maximum duration of the capture session in seconds.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate WithTimeLimitInSeconds(int timeLimitInSeconds);

        /// <summary>
        /// Gets Begin the definition of packet capture filter.
        /// </summary>
        /// <summary>
        /// Gets the next stage.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate> DefinePacketCaptureFilter { get; }

        /// <summary>
        /// Set maximum size of the capture output.
        /// </summary>
        /// <param name="totalBytesPerSession">Maximum size of the capture output.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate WithTotalBytesPerSession(int totalBytesPerSession);

        /// <summary>
        /// Set number of bytes captured per packet, the remaining bytes are truncated.
        /// </summary>
        /// <param name="bytesToCapturePerPacket">Number of bytes captured per packet.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate WithBytesToCapturePerPacket(int bytesToCapturePerPacket);
    }

    /// <summary>
    /// The entirety of the packet capture definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithTarget,
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithStorageLocation,
        Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreateAndStoragePath
    {
    }
}