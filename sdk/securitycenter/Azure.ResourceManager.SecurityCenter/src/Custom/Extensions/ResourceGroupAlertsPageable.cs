// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    internal sealed class ResourceGroupAlertsPageable : Pageable<SecurityAlertData>
    {
        private readonly SubscriptionResource _subscriptionResource;
        private readonly MockableSecurityCenterResourceGroupResource _resourceGroupResource;
        private readonly CancellationToken _cancellationToken;

        public ResourceGroupAlertsPageable(SubscriptionResource subscriptionResource, MockableSecurityCenterResourceGroupResource resourceGroupResource, CancellationToken cancellationToken)
        {
            _subscriptionResource = subscriptionResource;
            _resourceGroupResource = resourceGroupResource;
            _cancellationToken = cancellationToken;
        }

        public override IEnumerable<Page<SecurityAlertData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (SecurityCenterLocationResource location in _subscriptionResource.GetSecurityCenterLocations().GetAll(_cancellationToken))
            {
                foreach (Page<ResourceGroupSecurityAlertResource> page in _resourceGroupResource.GetResourceGroupSecurityAlerts(location.Id.Name).GetAll(_cancellationToken).AsPages(continuationToken, pageSizeHint))
                {
                    List<SecurityAlertData> values = new List<SecurityAlertData>();
                    foreach (ResourceGroupSecurityAlertResource alert in page.Values)
                    {
                        values.Add(alert.Data);
                    }
                    yield return Page<SecurityAlertData>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
