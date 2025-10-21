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
    internal class IListFailoverTestDetailsOperationSource : IOperationSource<IList<ExpressRouteFailoverTestDetails>>
    {
        // Remove this file until https://github.com/Azure/azure-sdk-for-net/issues/47572 fixed
        IList<ExpressRouteFailoverTestDetails> IOperationSource<IList<ExpressRouteFailoverTestDetails>>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
            List<ExpressRouteFailoverTestDetails> array = new List<ExpressRouteFailoverTestDetails>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(ExpressRouteFailoverTestDetails.DeserializeExpressRouteFailoverTestDetails(item));
            }
            return array;
        }

        async ValueTask<IList<ExpressRouteFailoverTestDetails>> IOperationSource<IList<ExpressRouteFailoverTestDetails>>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
            List<ExpressRouteFailoverTestDetails> array = new List<ExpressRouteFailoverTestDetails>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(ExpressRouteFailoverTestDetails.DeserializeExpressRouteFailoverTestDetails(item));
            }
            return array;
        }
    }
}
