// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Backward compatibility: mocking support for the old SDK's
    // GetServiceAlerts(SubscriptionResource) extension method. The old SDK placed this on
    // SubscriptionResource; the new generator places it on ArmClient (scope-based). This
    // delegates to the generated MockableAlertsManagementArmClient.GetServiceAlerts(Id).
    public partial class MockableAlertsManagementSubscriptionResource
    {
        /// <summary> Gets a collection of ServiceAlertCollection in the SubscriptionResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ServiceAlertCollection GetServiceAlerts()
        {
            return GetMockableAlertsManagementArmClient().GetServiceAlerts(Id);
        }
    }
}
