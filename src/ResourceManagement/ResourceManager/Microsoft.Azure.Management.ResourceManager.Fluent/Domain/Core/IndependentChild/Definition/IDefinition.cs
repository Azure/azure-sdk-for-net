// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// A resource definition allowing a new resource group to be created.
    /// </summary>
    /// <typeparam name="">The resource type.</typeparam>
    /// <typeparam name="Parent">Parent resource type.</typeparam>
    public interface IWithParentResource<T,ParentT> 
    {
        /// <summary>
        /// Creates a new child resource under parent resource.
        /// </summary>
        /// <param name="parentResourceCreatable">A creatable definition for the parent resource.</param>
        /// <return>The creatable for the child resource.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.ICreatable<T> WithNewParentResource(ICreatable<ParentT> parentResourceCreatable);

        /// <summary>
        /// Creates a new child resource under parent resource.
        /// </summary>
        /// <param name="groupName">The name of the resource group for parent resource.</param>
        /// <param name="parentName">The name of the parent resource.</param>
        /// <return>The creatable for the child resource.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.ICreatable<T> WithExistingParentResource(string groupName, string parentName);

        /// <summary>
        /// Creates a new child resource under parent resource.
        /// </summary>
        /// <param name="existingParentResource">The parent resource under which this resource to be created.</param>
        /// <return>The creatable for the child resource.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.ICreatable<T> WithExistingParentResource(ParentT existingParentResource);
    }
}