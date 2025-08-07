// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
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

        /// <summary>
        /// This operation retrieves the details of all the failover tests performed on the gateway for different peering locations
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/getFailoverAllTestsDetails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_GetFailoverAllTestDetails</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualNetworkGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="type"> The type of failover test. </param>
        /// <param name="fetchLatest"> Fetch only the latest tests for each peering location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        public virtual async Task<ArmOperation<IList<ExpressRouteFailoverTestDetails>>> GetFailoverAllTestDetailsAsync(WaitUntil waitUntil, string type, bool fetchLatest, CancellationToken cancellationToken = default)
        {
            // Remove until https://github.com/Azure/azure-sdk-for-net/issues/47572 fixed
            Argument.AssertNotNull(type, nameof(type));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayResource.GetFailoverAllTestDetails");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayRestClient.GetFailoverAllTestDetailsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, type, fetchLatest, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<IList<ExpressRouteFailoverTestDetails>>(new IListFailoverTestDetailsOperationSource(), _virtualNetworkGatewayClientDiagnostics, Pipeline, _virtualNetworkGatewayRestClient.CreateGetFailoverAllTestDetailsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, type, fetchLatest).Request, response, OperationFinalStateVia.Location);
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
        /// This operation retrieves the details of all the failover tests performed on the gateway for different peering locations
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/getFailoverAllTestsDetails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_GetFailoverAllTestDetails</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualNetworkGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="type"> The type of failover test. </param>
        /// <param name="fetchLatest"> Fetch only the latest tests for each peering location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        public virtual ArmOperation<IList<ExpressRouteFailoverTestDetails>> GetFailoverAllTestDetails(WaitUntil waitUntil, string type, bool fetchLatest, CancellationToken cancellationToken = default)
        {
            // Remove until https://github.com/Azure/azure-sdk-for-net/issues/47572 fixed
            Argument.AssertNotNull(type, nameof(type));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayResource.GetFailoverAllTestDetails");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayRestClient.GetFailoverAllTestDetails(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, type, fetchLatest, cancellationToken);
                var operation = new NetworkArmOperation<IList<ExpressRouteFailoverTestDetails>>(new IListFailoverTestDetailsOperationSource(), _virtualNetworkGatewayClientDiagnostics, Pipeline, _virtualNetworkGatewayRestClient.CreateGetFailoverAllTestDetailsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, type, fetchLatest).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the details of a particular failover test performed on the gateway based on the test Guid
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/getFailoverSingleTestDetails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_GetFailoverSingleTestDetails</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualNetworkGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="peeringLocation"> Peering location of the test. </param>
        /// <param name="failoverTestId"> The unique Guid value which identifies the test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringLocation"/> or <paramref name="failoverTestId"/> is null. </exception>
        public virtual async Task<ArmOperation<IList<ExpressRouteFailoverSingleTestDetails>>> GetFailoverSingleTestDetailsAsync(WaitUntil waitUntil, string peeringLocation, string failoverTestId, CancellationToken cancellationToken = default)
        {
            // Remove until https://github.com/Azure/azure-sdk-for-net/issues/47572 fixed
            Argument.AssertNotNull(peeringLocation, nameof(peeringLocation));
            Argument.AssertNotNull(failoverTestId, nameof(failoverTestId));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayResource.GetFailoverSingleTestDetails");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayRestClient.GetFailoverSingleTestDetailsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringLocation, failoverTestId, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<IList<ExpressRouteFailoverSingleTestDetails>>(new IListFailoverSingleTestDetailsOperationSource(), _virtualNetworkGatewayClientDiagnostics, Pipeline, _virtualNetworkGatewayRestClient.CreateGetFailoverSingleTestDetailsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringLocation, failoverTestId).Request, response, OperationFinalStateVia.Location);
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
        /// This operation retrieves the details of a particular failover test performed on the gateway based on the test Guid
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}/getFailoverSingleTestDetails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualNetworkGateways_GetFailoverSingleTestDetails</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualNetworkGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="peeringLocation"> Peering location of the test. </param>
        /// <param name="failoverTestId"> The unique Guid value which identifies the test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringLocation"/> or <paramref name="failoverTestId"/> is null. </exception>
        public virtual ArmOperation<IList<ExpressRouteFailoverSingleTestDetails>> GetFailoverSingleTestDetails(WaitUntil waitUntil, string peeringLocation, string failoverTestId, CancellationToken cancellationToken = default)
        {
            // Remove until https://github.com/Azure/azure-sdk-for-net/issues/47572 fixed
            Argument.AssertNotNull(peeringLocation, nameof(peeringLocation));
            Argument.AssertNotNull(failoverTestId, nameof(failoverTestId));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayResource.GetFailoverSingleTestDetails");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayRestClient.GetFailoverSingleTestDetails(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringLocation, failoverTestId, cancellationToken);
                var operation = new NetworkArmOperation<IList<ExpressRouteFailoverSingleTestDetails>>(new IListFailoverSingleTestDetailsOperationSource(), _virtualNetworkGatewayClientDiagnostics, Pipeline, _virtualNetworkGatewayRestClient.CreateGetFailoverSingleTestDetailsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringLocation, failoverTestId).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
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
