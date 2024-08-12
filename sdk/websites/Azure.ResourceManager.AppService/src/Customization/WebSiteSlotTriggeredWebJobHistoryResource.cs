// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteSlotTriggeredWebJobHistoryResource
    {
        /// <summary> Generate the resource identifier of a <see cref="WebSiteSlotTriggeredWebJobHistoryResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName, string id)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}";
            return new ResourceIdentifier(resourceId);
        }
        /// <summary> Gets a collection of WebSiteSlotTriggeredWebJobHistoryResources in the WebSiteSlotTriggeredWebJob. </summary>
        /// <returns> An object representing collection of WebSiteSlotTriggeredWebJobHistoryResources and their operations over a WebSiteSlotTriggeredWebJobHistoryResource. </returns>
        public virtual WebSiteSlotTriggeredWebJobHistoryCollection GetWebSiteSlotTriggeredWebJobHistories()
        {
            return GetCachedClient(Client => new WebSiteSlotTriggeredWebJobHistoryCollection(Client, Id));
        }
    }
}
