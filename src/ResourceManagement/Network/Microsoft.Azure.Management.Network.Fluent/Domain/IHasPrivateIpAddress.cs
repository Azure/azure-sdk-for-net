// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Network.Fluent.Models;

namespace Microsoft.Azure.Management.Network.Fluent
{


    /// <summary>
    /// An interface representing a model's ability to reference a private IP address.
    /// </summary>
    public interface IHasPrivateIpAddress 
    {
        /// <returns>the private IP address associated with this resource</returns>
        string PrivateIpAddress { get; }

        /// <returns>the private IP address allocation method within the associated subnet</returns>
        IPAllocationMethod PrivateIpAllocationMethod { get; }

    }
}