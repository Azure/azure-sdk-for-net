// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{


    /// <summary>
    /// An interface representing a model's ability to reference a public IP address.
    /// </summary>
    public interface IHasPublicIpAddress 
    {
        /// <returns>the resource ID of the associated public IP address</returns>
        string PublicIpAddressId { get; }

        /// <returns>the associated public IP address</returns>
        IPublicIpAddress GetPublicIpAddress ();

    }
}