// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    internal sealed class SubscriptionAlertsPageable : Pageable<SecurityAlertData>
    {
        private readonly MockableSecurityCenterSubscriptionResource _subscriptionResource;
        private readonly CancellationToken _cancellationToken;

        public SubscriptionAlertsPageable(MockableSecurityCenterSubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            _subscriptionResource = subscriptionResource;
            _cancellationToken = cancellationToken;
        }

        public override IEnumerable<Page<SecurityAlertData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (SecurityCenterLocationResource location in _subscriptionResource.GetSecurityCenterLocations().GetAll(_cancellationToken))
            {
                foreach (Page<SubscriptionSecurityAlertResource> page in location.GetSubscriptionSecurityAlerts().GetAll(_cancellationToken).AsPages(continuationToken, pageSizeHint))
                {
                    List<SecurityAlertData> values = new List<SecurityAlertData>();
                    foreach (SubscriptionSecurityAlertResource alert in page.Values)
                    {
                        values.Add(alert.Data);
                    }
                    yield return Page<SecurityAlertData>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
