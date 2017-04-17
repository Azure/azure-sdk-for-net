// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// An interface representing a model's ability to reference a private IP address.
    /// </summary>
    public interface IHasPrivateIPAddress 
    {
        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string PrivateIPAddress { get; }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        Models.IPAllocationMethod PrivateIPAllocationMethod { get; }
    }
}