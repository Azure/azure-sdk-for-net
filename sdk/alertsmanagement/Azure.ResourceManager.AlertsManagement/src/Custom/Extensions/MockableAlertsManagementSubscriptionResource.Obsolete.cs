// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stubs: these members were removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementSubscriptionResource
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string GetServiceAlertGuidReplacedMessage = "Use MockableAlertsManagementArmClient.GetServiceAlertResource(id) or ServiceAlertCollection.Get(alertId.ToString()) instead.";

        /// <summary> Gets alert processing rules. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AlertProcessingRuleResource> GetAlertProcessingRules(CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets alert processing rules async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AlertProcessingRuleResource> GetAlertProcessingRulesAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets a service alert. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertResource> GetServiceAlert(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(GetServiceAlertGuidReplacedMessage); }

        /// <summary> Gets a service alert async. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ServiceAlertResource>> GetServiceAlertAsync(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(GetServiceAlertGuidReplacedMessage); }

        /// <summary> Gets a smart group. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SmartGroupResource> GetSmartGroup(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets a smart group async. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SmartGroupResource>> GetSmartGroupAsync(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets smart groups. </summary>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SmartGroupCollection GetSmartGroups() { throw new NotSupportedException(SmartGroupRemovedMessage); }
    }
}
