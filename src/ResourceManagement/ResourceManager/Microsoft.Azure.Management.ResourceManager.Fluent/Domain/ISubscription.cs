// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Management.ResourceManager.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure subscription.
    /// </summary>
    public interface ISubscription :
        IIndexable,
        IHasInner<SubscriptionInner>
    {
        /// <returns>the UUID of the subscription</returns>
        string SubscriptionId { get; }

        /// <returns>the name of the subscription for humans to read</returns>
        string DisplayName { get; }

        /// <returns>the state of the subscription.</returns>
        string State { get; }

        /// <returns>the policies defined in the subscription</returns>
        SubscriptionPolicies SubscriptionPolicies { get; }

        /// <summary>
        /// List the locations the subscription has access to.
        /// </summary>
        /// <returns>the lazy list of locations</returns>
        IEnumerable<ILocation> ListLocations();

        /// <summary>
        /// Gets the data center location for the specified region, if the selected subscription has access to it.
        /// </summary>
        /// <param name="region">an Azure region</param>
        /// <returns>an Azure data center location, or null if the location is not accessible to this subscription</returns>
        ILocation GetLocationByRegion(Region region);
    }
}