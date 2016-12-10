// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to reference a private IP address.
    /// </summary>
    public interface IHasPrivateIpAddress 
    {
        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string PrivateIpAddress { get; }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        string PrivateIpAllocationMethod { get; }
    }
}