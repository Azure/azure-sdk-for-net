/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Feature
{

    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

    /// <summary>
    /// Entry point to features management API in a specific resource provider.
    /// </summary>
    public interface IInResourceProvider  :
        ISupportsListing<IFeature>,
        ISupportsGettingByName<IFeature>
    {
        /// <summary>
        /// Registers a feature in a resource provider.
        /// </summary>
        /// <param name="featureName">featureName the name of the feature</param>
        /// <returns>the immutable client-side feature object created</returns>
        IFeature Register (string featureName);

    }
}