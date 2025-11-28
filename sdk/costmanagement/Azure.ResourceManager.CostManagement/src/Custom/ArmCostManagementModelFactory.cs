// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using static Azure.Core.Pipeline.TaskExtensions;

namespace Azure.ResourceManager.CostManagement.Models
{
    public static partial class ArmCostManagementModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="CostManagement.ScheduledActionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> Scheduled action name. </param>
        /// <param name="fileFormats"> Destination format of the view data. This is optional. </param>
        /// <param name="notification"> Notification properties based on scheduled action kind. </param>
        /// <param name="notificationEmail"> Email address of the point of contact that should get the unsubscribe requests and notification emails. </param>
        /// <param name="schedule"> Schedule of the scheduled action. </param>
        /// <param name="scope"> Cost Management scope like 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription scope. </param>
        /// <param name="status"> Status of the scheduled action. </param>
        /// <param name="viewId"> Cost analysis viewId used for scheduled action. For example, '/providers/Microsoft.CostManagement/views/swaggerExample'. </param>
        /// <param name="eTag"> Resource Etag. For update calls, eTag is optional and can be specified to achieve optimistic concurrency. Fetch the resource's eTag by doing a 'GET' call first and then including the latest eTag as part of the request body or 'If-Match' header while performing the update. For create calls, eTag is not required. </param>
        /// <param name="kind"> Kind of the scheduled action. </param>
        /// <returns> A new <see cref="CostManagement.ScheduledActionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ScheduledActionData ScheduledActionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string displayName, IEnumerable<ScheduledActionFileFormat> fileFormats = null, NotificationProperties notification = null, string notificationEmail = null, ScheduleProperties schedule = null, ResourceIdentifier scope = null, ScheduledActionStatus? status = null, ResourceIdentifier viewId = null, ETag? eTag = null, ScheduledActionKind? kind = null)
            => ScheduledActionData(id, name, resourceType, systemData, eTag, kind, displayName, fileFormats, notification, notificationEmail, schedule, scope, status, viewId);
    }
}
