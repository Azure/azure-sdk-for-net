/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure location.
    /// </summary>
    public interface ILocation  :
        IIndexable,
        IWrapper<LocationInner>
    {
        /// <returns>the subscription UUID</returns>
        string SubscriptionId { get; }

        /// <returns>the name of the location</returns>
        string Name { get; }

        /// <returns>the display name of the location readable by humans</returns>
        string DisplayName { get; }

        /// <returns>the latitude of the location</returns>
        string Latitude { get; }

        /// <returns>the longitude of the location</returns>
        string Longitude { get; }

    }
}