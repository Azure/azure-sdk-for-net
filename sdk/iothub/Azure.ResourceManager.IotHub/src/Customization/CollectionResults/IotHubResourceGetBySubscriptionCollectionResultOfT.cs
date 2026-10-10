// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.ResourceManager.IotHub.Models;

namespace Azure.ResourceManager.IotHub
{
    internal partial class IotHubResourceGetBySubscriptionCollectionResultOfT
    {
        // Customization justification:
        // Some IoT Hub list responses return relative nextLink values. The generated collection result
        // path expects a continuation token that can be converted back into a URI when callers resume
        // paging through AsPages. Accepting both relative and absolute tokens preserves the service
        // contract and prevents paging from failing after the first page. This is intentionally scoped to
        // the subscription-level IoT Hub collection result until the generator can handle relative
        // nextLink values consistently.
        public override IEnumerable<Page<IotHubDescriptionData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = string.IsNullOrEmpty(continuationToken) ? null : new Uri(continuationToken, UriKind.RelativeOrAbsolute);
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                IotHubDescriptionListResult result = IotHubDescriptionListResult.FromResponse(response);
                yield return Page<IotHubDescriptionData>.FromValues((IReadOnlyList<IotHubDescriptionData>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }
    }
}
