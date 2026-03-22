// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    // Backward-compat: baseline had factory methods for NotificationHubCreateOrUpdateContent
    // and NotificationHubNamespaceCreateOrUpdateContent.
    public static partial class ArmNotificationHubsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.NotificationHubCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NotificationHubCreateOrUpdateContent NotificationHubCreateOrUpdateContent(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            IDictionary<string, string> tags = null,
            AzureLocation location = default,
            string notificationHubName = null,
            TimeSpan? registrationTtl = default,
            IEnumerable<SharedAccessAuthorizationRuleProperties> authorizationRules = null,
            NotificationHubApnsCredential apnsCredential = null,
            NotificationHubWnsCredential wnsCredential = null,
            NotificationHubGcmCredential gcmCredential = null,
            NotificationHubMpnsCredential mpnsCredential = null,
            NotificationHubAdmCredential admCredential = null,
            NotificationHubBaiduCredential baiduCredential = null,
            NotificationHubSku sku = null)
        {
            tags ??= new Dictionary<string, string>();
            authorizationRules ??= new List<SharedAccessAuthorizationRuleProperties>();

            return new NotificationHubCreateOrUpdateContent(id, name, resourceType, systemData, tags, location,
                notificationHubName, registrationTtl, new List<SharedAccessAuthorizationRuleProperties>(authorizationRules),
                apnsCredential, wnsCredential, gcmCredential, mpnsCredential, admCredential, baiduCredential, sku, null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NotificationHubNamespaceCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NotificationHubNamespaceCreateOrUpdateContent NotificationHubNamespaceCreateOrUpdateContent(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            IDictionary<string, string> tags = null,
            AzureLocation location = default,
            string namespaceName = null,
            string provisioningState = null,
            string region = null,
            string metricId = null,
            string status = null,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? updatedOn = default,
            Uri serviceBusEndpoint = null,
            string subscriptionId = null,
            string scaleUnit = null,
            bool? isEnabled = default,
            bool? isCritical = default,
            string dataCenter = null,
            NotificationHubNamespaceType? namespaceType = default,
            NotificationHubSku sku = null)
        {
            tags ??= new Dictionary<string, string>();

            return new NotificationHubNamespaceCreateOrUpdateContent(id, name, resourceType, systemData, tags, location,
                namespaceName, provisioningState, region, metricId, status, createdOn, updatedOn, serviceBusEndpoint,
                subscriptionId, scaleUnit, isEnabled, isCritical, dataCenter, namespaceType, sku, null);
        }
    }
}
