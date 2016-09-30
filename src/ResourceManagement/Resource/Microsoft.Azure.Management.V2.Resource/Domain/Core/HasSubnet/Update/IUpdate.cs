/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Resource.Core.HasSubnet.Update
{


    /// <summary>
    /// The stage of an update allowing to associate a subnet with a resource.
    /// @param <ReturnT> the next stage of the update
    /// </summary>
    public interface IWithSubnet<ReturnT> 
    {
        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">parentNetworkResourceId the resource ID of the virtual network the subnet is part of</param>
        /// <param name="subnetName">subnetName the name of the subnet</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithExistingSubnet (string parentNetworkResourceId, string subnetName);

    }
}