/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.ResourceManager.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure subscription.
    /// </summary>
    public interface ISubscription  :
        IIndexable,
        IWrapper<SubscriptionInner>
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
        PagedList<ILocation> ListLocations();

    }
}