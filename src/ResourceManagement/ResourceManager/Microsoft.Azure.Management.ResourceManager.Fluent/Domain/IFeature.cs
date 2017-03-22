// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Management.ResourceManager.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure feature.
    /// </summary>
    public interface IFeature  :
        IIndexable,
        IHasInner<FeatureResultInner>
    {
        /// <returns>the name of the feature</returns>
        string Name { get; }

        /// <returns>the type of the feature</returns>
        string Type { get; }

        /// <returns>the state of the previewed feature</returns>
        string State { get; }

    }
}