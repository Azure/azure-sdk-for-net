// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stubs: these members were removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementArmClient
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";

        /// <summary> Gets an alert processing rule resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AlertProcessingRuleResource GetAlertProcessingRuleResource(ResourceIdentifier id) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets a smart group resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SmartGroupResource GetSmartGroupResource(ResourceIdentifier id) { throw new NotSupportedException(SmartGroupRemovedMessage); }
    }
}
