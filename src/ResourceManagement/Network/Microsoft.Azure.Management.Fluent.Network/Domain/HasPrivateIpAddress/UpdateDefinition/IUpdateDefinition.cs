// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.UpdateDefinition
{


    /// <summary>
    /// The stage of a definition allowing to specify the private IP address.
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithPrivateIpAddress<ReturnT> 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithPrivateIpAddressDynamic ();

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithPrivateIpAddressStatic (string ipAddress);

    }
}