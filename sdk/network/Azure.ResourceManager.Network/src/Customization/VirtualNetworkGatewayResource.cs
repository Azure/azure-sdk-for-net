// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A Class representing a VirtualNetworkGateway along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualNetworkGatewayResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualNetworkGatewayResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetVirtualNetworkGateway method.
    /// </summary>
    public partial class VirtualNetworkGatewayResource : ArmResource
    {
        /// <summary>
        /// Generates VPN client package for P2S client of the virtual network gateway in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/generatevpnclientpackage</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_Generatevpnclientpackage</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnClientParameters"> Parameters supplied to the generate virtual network gateway VPN client package operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnClientParameters"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<string>> GeneratevpnclientpackageAsync(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default) => await GenerateVpnClientPackageAsync(waitUntil, (VpnClientContent)vpnClientParameters, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Generates VPN client package for P2S client of the virtual network gateway in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/generatevpnclientpackage</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_Generatevpnclientpackage</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnClientParameters"> Parameters supplied to the generate virtual network gateway VPN client package operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnClientParameters"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<string> Generatevpnclientpackage(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default)  => GenerateVpnClientPackage(waitUntil, (VpnClientContent)vpnClientParameters, cancellationToken);

        /// <summary>
        /// Generates VPN profile for P2S client of the virtual network gateway in the specified resource group. Used for IKEV2 and radius based authentication.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/generatevpnprofile</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_GenerateVpnProfile</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnClientParameters"> Parameters supplied to the generate virtual network gateway VPN client package operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnClientParameters"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<string>> GenerateVpnProfileAsync(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default) => await GenerateVpnProfileAsync(waitUntil, (VpnClientContent)vpnClientParameters, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Generates VPN profile for P2S client of the virtual network gateway in the specified resource group. Used for IKEV2 and radius based authentication.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/generatevpnprofile</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_GenerateVpnProfile</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnClientParameters"> Parameters supplied to the generate virtual network gateway VPN client package operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnClientParameters"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<string> GenerateVpnProfile(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default) => GenerateVpnProfile(waitUntil, (VpnClientContent)vpnClientParameters, cancellationToken);

        /// <summary>
        /// Starts packet capture on virtual network gateway in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/startPacketCapture</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_StartPacketCapture</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnPacketCaptureStartParameters"> Virtual network gateway packet capture parameters supplied to start packet capture on gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters vpnPacketCaptureStartParameters, CancellationToken cancellationToken = default) => await StartPacketCaptureAsync(waitUntil, (VpnPacketCaptureStartContent)vpnPacketCaptureStartParameters, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Starts packet capture on virtual network gateway in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/startPacketCapture</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_StartPacketCapture</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnPacketCaptureStartParameters"> Virtual network gateway packet capture parameters supplied to start packet capture on gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters vpnPacketCaptureStartParameters, CancellationToken cancellationToken = default) => StartPacketCapture(waitUntil, (VpnPacketCaptureStartContent)vpnPacketCaptureStartParameters, cancellationToken);

        /// <summary>
        /// Stops packet capture on virtual network gateway in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/stopPacketCapture</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_StopPacketCapture</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnPacketCaptureStopParameters"> Virtual network gateway packet capture parameters supplied to stop packet capture on gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnPacketCaptureStopParameters"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters vpnPacketCaptureStopParameters, CancellationToken cancellationToken = default) => await StopPacketCaptureAsync(waitUntil, (VpnPacketCaptureStopContent)vpnPacketCaptureStopParameters, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Stops packet capture on virtual network gateway in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/stopPacketCapture</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_StopPacketCapture</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vpnPacketCaptureStopParameters"> Virtual network gateway packet capture parameters supplied to stop packet capture on gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnPacketCaptureStopParameters"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters vpnPacketCaptureStopParameters, CancellationToken cancellationToken = default) => StopPacketCapture(waitUntil, (VpnPacketCaptureStopContent)vpnPacketCaptureStopParameters, cancellationToken);
    }
}
