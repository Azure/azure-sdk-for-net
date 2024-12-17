// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    internal class IListFailoverSingleTestDetailsOperationSource : IOperationSource<IList<ExpressRouteFailoverSingleTestDetails>>
    {
        // Remove this file until https://github.com/Azure/azure-sdk-for-net/issues/47572 fixed
        IList<ExpressRouteFailoverSingleTestDetails> IOperationSource<IList<ExpressRouteFailoverSingleTestDetails>>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            List<ExpressRouteFailoverSingleTestDetails> array = new List<ExpressRouteFailoverSingleTestDetails>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(ExpressRouteFailoverSingleTestDetails.DeserializeExpressRouteFailoverSingleTestDetails(item));
            }
            return array;
        }

        async ValueTask<IList<ExpressRouteFailoverSingleTestDetails>> IOperationSource<IList<ExpressRouteFailoverSingleTestDetails>>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<ExpressRouteFailoverSingleTestDetails> array = new List<ExpressRouteFailoverSingleTestDetails>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(ExpressRouteFailoverSingleTestDetails.DeserializeExpressRouteFailoverSingleTestDetails(item));
            }
            return array;
        }
    }
}
