// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService;

namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceArmClient : ArmResource
    {
        // we have to customize this because the WebSiteTriggeredwebJobResource.CreateResourceIdentifier method now has an overload and the generated version cannot compile
        /// <summary>
        /// Gets an object representing a <see cref="WebSiteTriggeredwebJobResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="WebSiteTriggeredwebJobResource.CreateResourceIdentifier(string, string, string, string)" /> to create a <see cref="WebSiteTriggeredwebJobResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="WebSiteTriggeredwebJobResource" /> object. </returns>
        public virtual WebSiteTriggeredwebJobResource GetWebSiteTriggeredwebJobResource(ResourceIdentifier id)
        {
            WebSiteTriggeredwebJobResource.ValidateResourceId(id);
            return new WebSiteTriggeredwebJobResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="WebSiteSlotTriggeredWebJobResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="WebSiteSlotTriggeredWebJobResource.CreateResourceIdentifier(string, string, string, string, string)" /> to create a <see cref="WebSiteSlotTriggeredWebJobResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="WebSiteSlotTriggeredWebJobResource" /> object. </returns>
        public virtual WebSiteSlotTriggeredWebJobResource GetWebSiteSlotTriggeredWebJobResource(ResourceIdentifier id)
        {
            WebSiteSlotTriggeredWebJobResource.ValidateResourceId(id);
            return new WebSiteSlotTriggeredWebJobResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="WebSiteSlotTriggeredWebJobHistoryResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="WebSiteSlotTriggeredWebJobHistoryResource.CreateResourceIdentifier(string, string, string, string, string, string)" /> to create a <see cref="WebSiteSlotTriggeredWebJobHistoryResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="WebSiteSlotTriggeredWebJobHistoryResource" /> object. </returns>
        public virtual WebSiteSlotTriggeredWebJobHistoryResource GetWebSiteSlotTriggeredWebJobHistoryResource(ResourceIdentifier id)
        {
            WebSiteSlotTriggeredWebJobHistoryResource.ValidateResourceId(id);
            return new WebSiteSlotTriggeredWebJobHistoryResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="WebSiteTriggeredWebJobHistoryResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="WebSiteTriggeredWebJobHistoryResource.CreateResourceIdentifier(string, string, string, string, string)" /> to create a <see cref="WebSiteTriggeredWebJobHistoryResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="WebSiteTriggeredWebJobHistoryResource" /> object. </returns>
        public virtual WebSiteTriggeredWebJobHistoryResource GetWebSiteTriggeredWebJobHistoryResource(ResourceIdentifier id)
        {
            WebSiteTriggeredWebJobHistoryResource.ValidateResourceId(id);
            return new WebSiteTriggeredWebJobHistoryResource(Client, id);
        }
    }
}
