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
                SkipToken = skipToken
            };
            var tenantResource = armClient.GetTenants().First();
            Pageable<EdgeOrderItem> edgeOrderItem = EdgeOrderExtensions.GetOrderItemsByResourceGroup(tenantResource, tenantResourceGetOrderItemsByResourceGroupOptions);

            EdgeOrderDeviceResponse edgeOrderDeviceResponse = new EdgeOrderDeviceResponse();
            var EdgeOrderDevice = new List<EdgeOrderDevice>();

            foreach (EdgeOrderItem item in edgeOrderItem)
            {
                EdgeOrderDevice edgeOrderDevice = new EdgeOrderDevice();
                edgeOrderDevice.OrderItemId = item.Id;
                edgeOrderDevice.SerialNumber = item.OrderItemDetails.ProductDetails?.ParentProvisioningDetails?.SerialNumber;
                edgeOrderDevice.ModelName = item.OrderItemDetails.ProductDetails?.HierarchyInformation?.ConfigurationIdDisplayName;
                edgeOrderDevice.DeviceConfigurations = item.OrderItemDetails.ProductDetails?.ParentProvisioningDetails?.DeviceConfigurations;
                EdgeOrderDevice.Add(edgeOrderDevice);
            }
            edgeOrderDeviceResponse.EdgeOrderDevice = EdgeOrderDevice;
            edgeOrderDeviceResponse.SkipToken = skipToken;

            return edgeOrderDeviceResponse;
        }
    }
}
