/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{


    /// <summary>
    /// An interface representing a model's ability to reference a subnet by its name and network's ID.
    /// </summary>
    public interface IHasSubnet 
    {
        /// <returns>the resource ID of the virtual network whose subnet is associated with this resource</returns>
        string NetworkId { get; }

        /// <returns>the name of the subnet associated with this resource</returns>
        string SubnetName { get; }

    }
}