// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Management.ResourceManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure location.
    /// </summary>
    public interface ILocation  :
        IIndexable,
        IHasInner<Location>
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

        /// <returns>the region of the data center location</returns>
        Region Region { get; }
    }
}