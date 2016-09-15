/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Resource;

    /// <summary>
    /// A resource group definition with sufficient inputs to create a new
    /// resource group in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IResourceGroup>,
        IDefinitionWithTags<IWithCreate>
    {
    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithCreate
    {
    }

    /// <summary>
    /// A resource group definition allowing location to be set.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<IWithCreate>
    {
    }
}