// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Models;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
public static partial class SecurityCenterExtensions
    {
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(this SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(this SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(this ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(this ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomAssessmentAutomationCollection GetCustomAssessmentAutomations(this ResourceGroupResource resourceGroupResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(this ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(this ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments(this ResourceGroupResource resourceGroupResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityCloudConnectorResource> GetSecurityCloudConnector(this SubscriptionResource subscriptionResource, string connectorName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(this SubscriptionResource subscriptionResource, string connectorName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityCloudConnectorResource GetSecurityCloudConnectorResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityCloudConnectorCollection GetSecurityCloudConnectors(this SubscriptionResource subscriptionResource) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SoftwareInventoryCollection GetSoftwareInventories(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SoftwareInventoryResource> GetSoftwareInventories(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SoftwareInventoryResource> GetSoftwareInventoriesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SoftwareInventoryResource> GetSoftwareInventory(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SoftwareInventoryResource>> GetSoftwareInventoryAsync(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SoftwareInventoryResource GetSoftwareInventoryResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
