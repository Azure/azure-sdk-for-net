// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        /// <summary>
        /// Lists all available web application firewall rule sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableWafRuleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplicationGateways_ListAvailableWafRuleSets</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationGatewayFirewallRuleSet" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSetsAsync` instead", false)]
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetAppGatewayAvailableWafRuleSetsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all available web application firewall rule sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableWafRuleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplicationGateways_ListAvailableWafRuleSets</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationGatewayFirewallRuleSet" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSets` instead", false)]
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetAppGatewayAvailableWafRuleSets(cancellationToken);
        }

        #region VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource" /> object. </returns>
        public static VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource GetVirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetNetworkResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetNetworkResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetNetworkResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetNetworkResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetNetworkResource" /> object. </returns>
        public static VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetNetworkResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetNetworkResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetVmNetworkResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetVmNetworkResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetVmNetworkResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetVmNetworkResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVmNetworkResource" /> object. </returns>
        public static VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetVmNetworkResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetVmNetworkResource(client, id);
            }
            );
        }
        #endregion
    }
}
