// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to specify the private IP address.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithPrivateIPAddress<ReturnT> 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT WithPrivateIPAddressDynamic();

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithPrivateIPAddressStatic(string ipAddress);
    }
}