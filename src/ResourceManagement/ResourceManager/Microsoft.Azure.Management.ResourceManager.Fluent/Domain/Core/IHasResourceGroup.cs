// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// An interface representing a model that has a resource group name.
    /// </summary>
    public interface IHasResourceGroup 
    {
        /// <return>The name of the resource group.</return>
        string ResourceGroupName { get; }
    }
}