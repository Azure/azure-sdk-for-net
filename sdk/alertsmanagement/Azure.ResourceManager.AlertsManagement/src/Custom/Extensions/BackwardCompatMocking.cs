// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Backward compatibility: old SDK had GetServiceAlerts on SubscriptionResource.
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
