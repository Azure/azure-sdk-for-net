// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to features management API.
    /// </summary>
    public interface IFeatures  :
        ISupportsListing<IFeature>
    {
        /// <summary>
        /// Registers a feature in a resource provider.
        /// </summary>
        /// <param name="resourceProviderNamespace">the namespace of resource provider</param>
        /// <param name="featureName">the name of the feature</param>
        /// <returns>the immutable client-side feature object created</returns>
        IFeature Register(string resourceProviderNamespace, string featureName);

        /// <summary>
        /// Registers a feature in a resource provider.
        /// </summary>
        /// <param name="resourceProviderNamespace">the namespace of resource provider</param>
        /// <param name="featureName">featureName the name of the feature</param>
        /// <returns>the immutable client-side feature object created</returns>
        Task<IFeature> RegisterAsync(string resourceProviderNamespace, string featureName, CancellationToken cancellationToken = default(CancellationToken));
    }
}