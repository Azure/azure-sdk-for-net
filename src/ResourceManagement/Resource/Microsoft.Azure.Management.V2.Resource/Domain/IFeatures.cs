/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Feature;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

    /// <summary>
    /// Entry point to features management API.
    /// </summary>
    public interface IFeatures  :
        ISupportsListing<IFeature>
    {
        /// <summary>
        /// Filter the features by a specific resource provider.
        /// </summary>
        /// <param name="resourceProviderName">resourceProviderName the name of the resource provider</param>
        /// <returns>an instance for accessing features in a resource provider</returns>
        IInResourceProvider ResourceProvider (string resourceProviderName);

    }
}