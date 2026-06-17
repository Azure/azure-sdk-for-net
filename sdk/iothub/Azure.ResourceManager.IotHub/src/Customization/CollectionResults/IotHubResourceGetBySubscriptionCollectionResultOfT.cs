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
        // Generator workaround: allow relative continuation tokens when resuming next-link paging.
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
