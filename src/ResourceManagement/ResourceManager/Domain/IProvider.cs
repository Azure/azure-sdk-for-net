// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using Management.ResourceManager.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure resource provider.
    /// </summary>
    public interface IProvider  :
        IIndexable,
        IHasInner<ProviderInner>
    {
        /// <returns>the namespace of the provider</returns>
        string Namespace { get; }

        /// <returns>the registration state of the provider, indicating whether this</returns>
        /// <returns>resource provider is registered in the current subscription</returns>
        string RegistrationState { get; }

        /// <returns>the list of provider resource types</returns>
        IList<ProviderResourceType> ResourceTypes { get; }

    }
}