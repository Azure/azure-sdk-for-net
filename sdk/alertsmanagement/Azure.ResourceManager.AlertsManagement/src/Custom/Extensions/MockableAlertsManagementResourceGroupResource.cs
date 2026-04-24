// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    /// <summary> Backward compatibility stub. The AlertProcessingRule APIs have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The AlertProcessingRule APIs have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MockableAlertsManagementResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected MockableAlertsManagementResourceGroupResource() { }

        /// <summary> Gets alert processing rules. </summary>
        public virtual AlertProcessingRuleCollection GetAlertProcessingRules() { throw new NotSupportedException(); }

        /// <summary> Gets an alert processing rule. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public virtual Response<AlertProcessingRuleResource> GetAlertProcessingRule(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets an alert processing rule async. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public virtual Task<Response<AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
    }
}