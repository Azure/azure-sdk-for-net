/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

    /// <summary>
    /// Entry point to providers management API.
    /// </summary>
    public interface IProviders  :
        ISupportsListing<IProvider>,
        ISupportsGettingByName<IProvider>
    {
        /// <summary>
        /// Unregisters provider from a subscription.
        /// </summary>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace Namespace of the resource provider</param>
        /// <returns>the ProviderInner object wrapped in {@link ServiceResponse} if successful</returns>
        IProvider Unregister (string resourceProviderNamespace);

        /// <summary>
        /// Registers provider to be used with a subscription.
        /// </summary>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace Namespace of the resource provider</param>
        /// <returns>the ProviderInner object wrapped in {@link ServiceResponse} if successful</returns>
        IProvider Register (string resourceProviderNamespace);

    }
}