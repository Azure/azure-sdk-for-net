// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System.Collections.Generic;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;

    public static partial class TestUtilities
    {

        /// <summary>
        /// Returns alerts given an odata filter
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IPage<Alert> GetAlerts(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                ODataQuery<AlertFilter> filter)
        {
            return client.Alerts.ListByManager(resourceGroupName, managerName, filter);
        }

        /// <summary>
        /// Clears alerts
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="alertId"></param>
        public static void ClearAlerts(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                string alertId)
        {
            var clearAlertRequest = new ClearAlertRequest()
            {
                Alerts = new List<string>()
                {
                    alertId
                }
            };

            client.Alerts.Clear(clearAlertRequest, resourceGroupName, managerName);
        }

        public static void SendEmail(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                string deviceName,
                SendTestAlertEmailRequest sendTestAlertEmailRequest)
        {
            client.Alerts.SendTestEmailWithHttpMessagesAsync(
                    deviceName.GetDoubleEncoded(),
                    sendTestAlertEmailRequest,
                    resourceGroupName,
                    managerName);
        }
    }
}
