// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: these members were removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AlertsManagement
{
    public static partial class AlertsManagementExtensions
    {
        /// <summary> Gets an alert processing rule resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleResource GetAlertProcessingRuleResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets an alert processing rule. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<AlertProcessingRuleResource> GetAlertProcessingRule(this ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets an alert processing rule async. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets alert processing rules collection. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleCollection GetAlertProcessingRules(this ResourceGroupResource resourceGroupResource) { throw new NotSupportedException(); }

        /// <summary> Gets all alert processing rules. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<AlertProcessingRuleResource> GetAlertProcessingRules(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all alert processing rules async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ServiceAlertResource> GetServiceAlert(this SubscriptionResource subscriptionResource, Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<ServiceAlertResource>> GetServiceAlertAsync(this SubscriptionResource subscriptionResource, Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceAlertResource GetServiceAlertResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SmartGroupResource> GetSmartGroup(this SubscriptionResource subscriptionResource, Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SmartGroupResource>> GetSmartGroupAsync(this SubscriptionResource subscriptionResource, Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupResource GetSmartGroupResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets smart groups. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupCollection GetSmartGroups(this SubscriptionResource subscriptionResource) { throw new NotSupportedException(); }
    }
}
