// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure service bus operation description object.
    /// </summary>
    public interface IServiceBusOperation  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.Operation>
    {
        /// <summary>
        /// Gets the description of the operation.
        /// </summary>
        Models.OperationDisplay DisplayInformation { get; }

        /// <summary>
        /// Gets the operation name.
        /// </summary>
        string Name { get; }
    }
}