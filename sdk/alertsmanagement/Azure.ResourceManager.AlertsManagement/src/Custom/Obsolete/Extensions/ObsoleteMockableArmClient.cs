// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: these members were removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementArmClient
    {
        /// <summary> Gets an alert processing rule resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AlertProcessingRuleResource GetAlertProcessingRuleResource(ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets a service alert resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ServiceAlertResource GetServiceAlertResource(ResourceIdentifier id) { throw new NotSupportedException(); }

        /// <summary> Gets a smart group resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is no longer supported.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SmartGroupResource GetSmartGroupResource(ResourceIdentifier id) { throw new NotSupportedException(); }
    }
}
