// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Customizations.Models;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Resources;
using System.Linq;
using System.Collections.Generic;

namespace Azure.ResourceManager.EdgeOrder
{
    public static partial class EdgeOrderExtensions
    {
        private static string orderItemFilter = "Properties.OrderItemDetails.OrderItemType eq 'External'";
        private static void ValidateValidSiteKeyObject(SiteKey siteKeyObject)
        {
            Argument.AssertNotNullOrWhiteSpace(siteKeyObject.ResourceId, nameof(siteKeyObject.ResourceId));
            Argument.AssertNotNullOrWhiteSpace(siteKeyObject.AadEndpoint, nameof(siteKeyObject.AadEndpoint));
            Argument.AssertNotNullOrWhiteSpace(siteKeyObject.TenantId, nameof(siteKeyObject.TenantId));
            Argument.AssertNotNullOrWhiteSpace(siteKeyObject.ClientId, nameof(siteKeyObject.ClientId));
            Argument.AssertNotNullOrWhiteSpace(siteKeyObject.ClientSecret, nameof(siteKeyObject.ClientSecret));
        }

        /// <summary>
        /// Get EdgeOrderDevices for a site.
        /// </summary>
        /// <param name="siteKey"></param>
        /// <param name="top"></param>
        /// <param name="skipToken"></param>
        /// <returns></returns>
        public static EdgeOrderDeviceResponse GetEdgeOrderDevices(string siteKey, int? top = null, string skipToken = null)
        {
            Argument.AssertNotNullOrWhiteSpace(siteKey, nameof(siteKey));

            SiteKey siteKeyObject = siteKey.DeserializeSiteKey();

            ValidateValidSiteKeyObject(siteKeyObject);
            ArmClient armClient = siteKeyObject.CreateArmClient(null);
            ResourceIdentifier siteResource = new ResourceIdentifier(siteKeyObject.ResourceId);

            TenantResourceGetOrderItemsByResourceGroupOptions tenantResourceGetOrderItemsByResourceGroupOptions = new TenantResourceGetOrderItemsByResourceGroupOptions(new Guid(siteResource.SubscriptionId), siteResource.ResourceGroupName)
            {
                Top = top,
                SkipToken = skipToken,
                Filter = orderItemFilter
            };
            var tenantResource = armClient.GetTenants().First();
            Pageable<EdgeOrderItem> edgeOrderItem = GetOrderItemsByResourceGroup(tenantResource, tenantResourceGetOrderItemsByResourceGroupOptions);

            EdgeOrderDeviceResponse edgeOrderDeviceResponse = new EdgeOrderDeviceResponse();
            var EdgeOrderDevice = new List<EdgeOrderDevice>();

            foreach (EdgeOrderItem item in edgeOrderItem)
            {
                EdgeOrderDevice edgeOrderDevice = new EdgeOrderDevice();
                edgeOrderDevice.OrderItemId = item.Id;
                edgeOrderDevice.Manufacturer = item.OrderItemDetails.ProductDetails?.ParentProvisioningDetails?.VendorName;
                edgeOrderDevice.SerialNumber = item.OrderItemDetails.ProductDetails?.ParentProvisioningDetails?.SerialNumber;
                edgeOrderDevice.ModelName = item.OrderItemDetails.ProductDetails?.HierarchyInformation?.ConfigurationIdDisplayName;
                edgeOrderDevice.DeviceConfiguration = GetDeviceConfigurationFromOrderItem(item.OrderItemDetails.ProductDetails?.ParentProvisioningDetails?.DeviceConfigurations);
                EdgeOrderDevice.Add(edgeOrderDevice);
            }
            edgeOrderDeviceResponse.EdgeOrderDevice = EdgeOrderDevice;
            edgeOrderDeviceResponse.SkipToken = skipToken;

            return edgeOrderDeviceResponse;
        }

        private static DeviceConfiguration GetDeviceConfigurationFromOrderItem(DeviceConfigurations deviceConfigurations)
        {
            DeviceConfiguration deviceConfiguration = new DeviceConfiguration();

            //Setting up Network Configurations
            Models.NetworkConfiguration networkConfiguration = deviceConfigurations.NetworkConfigurations.FirstOrDefault();
            Enum.TryParse(networkConfiguration?.Properties?.IPAssignments.IPAssignmentType, out IPAssignmentType ipAssignmentType);
            deviceConfiguration.Network = new Customizations.Models.NetworkConfiguration
            {
                IpAssignmentType = ipAssignmentType,
                Gateway = networkConfiguration?.Properties?.IPAssignments?.IPv4?.DefaultGateway,
                IpAddress = networkConfiguration?.Properties?.IPAssignments?.IPv4?.IPAddress,
                IpAddressRange = new IPAddressRange {
                   StartIp = networkConfiguration?.Properties?.IPAssignments?.IPv4?.AddressRange?.StartIP,
                   EndIp = networkConfiguration?.Properties?.IPAssignments?.IPv4?.AddressRange?.EndIP
                },
                SubnetMask = networkConfiguration?.Properties?.IPAssignments?.IPv4?.SubnetMask,
                DnsAddressArray = networkConfiguration?.Properties?.IPAssignments?.IPv4?.DnsServers,
                VlanId = networkConfiguration?.Properties?.IPAssignments?.IPv4?.VLanId.ToString()
            };

            // Host name config
            deviceConfiguration.HostName = deviceConfigurations?.HostName;

            // Web proxy setup
            deviceConfiguration.WebProxy = new WebProxyConfiguration
            {
                ConnectionUri = deviceConfigurations?.ConnectivityConfiguration?.Properties?.ProxyConfiguration?.Uri.AbsoluteUri,
                Port = deviceConfigurations?.ConnectivityConfiguration?.Properties?.ProxyConfiguration?.Port.ToString(),
                BypassList = deviceConfigurations?.ConnectivityConfiguration?.Properties?.ProxyConfiguration.ByPassUrls
            };

            // Time server settings
            deviceConfiguration.Time = new TimeConfiguration
            {
                PrimaryTimeServer = deviceConfigurations?.TimeServerConfiguration?.Properties?.Timezone,
                SecondaryTimeServer = deviceConfigurations?.TimeServerConfiguration?.Properties?.Timezone,
                TimeZone = deviceConfigurations?.TimeServerConfiguration?.Properties?.Timezone
            };

            return deviceConfiguration;
        }
    }
}
