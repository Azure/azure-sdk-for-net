/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{
    using Core;
    using Microsoft.Azure;

    /// <summary>
    /// Implementations of this interface defines how to create a connector.
    /// 
    /// @param <T> the type of the connector to create.
    /// </summary>
    public interface IBuilder<T> 
    {
        T Create (RestClient restClient, string subscriptionId, IResourceGroup resourceGroup);

    }
    /// <summary>
    /// Defines a connector that connects other resources to a resource group.
    /// Implementations of this class can let users browse resources inside a
    /// specific resource group.
    /// </summary>
    public interface IResourceConnector 
    {
    }
}