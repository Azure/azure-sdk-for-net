// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stubs for APIs that were removed or renamed in the TypeSpec migration.
// These members throw at runtime; the [Obsolete(error: true)] attribute surfaces a compile-time error
// with the replacement guidance shown below.
//
// - AlertProcessingRule*: moved out of this TypeSpec project. The APIs still exist in Azure and will be
//   shipped from a separate package in a future release (see PR #57059 changelog).
// - SmartGroup*: moved to Legacy in the spec repo. The APIs still exist in Azure and will be shipped
//   from a separate package in a future release.
// - GetServiceAlert(Guid) on SubscriptionResource: replaced by ArmClient.GetAlertResource(id) /
//   ServiceAlertCollection.Get(alertId.ToString()).
// - GetServiceAlertResource(ArmClient, ResourceIdentifier): renamed to GetAlertResource.

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
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string GetServiceAlertGuidReplacedMessage = "Use ArmClient.GetAlertResource(id) or ServiceAlertCollection.Get(alertId.ToString()) instead.";
        private const string GetServiceAlertResourceRenamedMessage = "This method was renamed to GetAlertResource(ArmClient, ResourceIdentifier).";

        /// <summary> Gets an alert processing rule resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleResource GetAlertProcessingRuleResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets an alert processing rule. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<AlertProcessingRuleResource> GetAlertProcessingRule(this ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets an alert processing rule async. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets alert processing rules collection. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleCollection GetAlertProcessingRules(this ResourceGroupResource resourceGroupResource) { throw new NotSupportedException(); }

        /// <summary> Gets all alert processing rules. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<AlertProcessingRuleResource> GetAlertProcessingRules(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all alert processing rules async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert by Guid (use ArmClient.GetAlertResource(id) instead). </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ServiceAlertResource> GetServiceAlert(this SubscriptionResource subscriptionResource, Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert by Guid async (use ArmClient.GetAlertResource(id) instead). </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<ServiceAlertResource>> GetServiceAlertAsync(this SubscriptionResource subscriptionResource, Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert resource (renamed to GetAlertResource). </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(GetServiceAlertResourceRenamedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceAlertResource GetServiceAlertResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SmartGroupResource> GetSmartGroup(this SubscriptionResource subscriptionResource, Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SmartGroupResource>> GetSmartGroupAsync(this SubscriptionResource subscriptionResource, Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupResource GetSmartGroupResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets smart groups. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupCollection GetSmartGroups(this SubscriptionResource subscriptionResource) { throw new NotSupportedException(); }
    }
}
