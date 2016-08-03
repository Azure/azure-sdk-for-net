/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource.GenericResource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure generic resource.
    /// </summary>
    public interface IGenericResource  :
        IGroupableResource,
        IRefreshable<IGenericResource>,
        IUpdatable<GenericResource.Update.IWithApiVersion>,
        IWrapper<GenericResourceInner>
    {
        /// <returns>the namespace of the resource provider</returns>
        string ResourceProviderNamespace { get; }

        /// <returns>the id of the parent resource if this is a child resource</returns>
        string ParentResourceId { get; }

        /// <returns>the type of the resource</returns>
        string ResourceType { get; }

        /// <returns>the api version of the resource</returns>
        string ApiVersion { get; }

        /// <returns>the plan of the resource</returns>
        Plan Plan { get; }

        /// <returns>other properties of the resource</returns>
        object Properties { get; }

    }
}