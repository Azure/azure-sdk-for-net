// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    internal sealed class SubscriptionAlertsAsyncPageable : AsyncPageable<SecurityAlertData>
    {
        private readonly MockableSecurityCenterSubscriptionResource _subscriptionResource;
        private readonly CancellationToken _cancellationToken;

        public SubscriptionAlertsAsyncPageable(MockableSecurityCenterSubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            _subscriptionResource = subscriptionResource;
            _cancellationToken = cancellationToken;
        }

        public override async IAsyncEnumerable<Page<SecurityAlertData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            await foreach (SecurityCenterLocationResource location in _subscriptionResource.GetSecurityCenterLocations().GetAllAsync(_cancellationToken).ConfigureAwait(false))
            {
                await foreach (Page<SubscriptionSecurityAlertResource> page in location.GetSubscriptionSecurityAlerts().GetAllAsync(_cancellationToken).AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
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
