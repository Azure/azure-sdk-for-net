// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    // These models have been deleted from the TypeSpec spec. Factory methods are kept only
    // for backward API compatibility (ApiCompat). All methods throw NotSupportedException.
    public static partial class ArmNotificationHubsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.NotificationHubCreateOrUpdateContent"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
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
            throw new NotSupportedException($"{nameof(NotificationHubCreateOrUpdateContent)} is obsolete and not supported.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.NotificationHubNamespaceCreateOrUpdateContent"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
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
            throw new NotSupportedException($"{nameof(NotificationHubNamespaceCreateOrUpdateContent)} is obsolete and not supported.");
        }
    }
}
