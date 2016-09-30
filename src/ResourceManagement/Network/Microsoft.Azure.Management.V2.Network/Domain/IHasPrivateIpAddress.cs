// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{


    /// <summary>
    /// An interface representing a model's ability to reference a private IP address.
    /// </summary>
    public interface IHasPrivateIpAddress 
    {
        /// <returns>the private IP address associated with this resource</returns>
        string PrivateIpAddress { get; }

        /// <returns>the private IP address allocation method within the associated subnet</returns>
        string PrivateIpAllocationMethod { get; }

    }
}