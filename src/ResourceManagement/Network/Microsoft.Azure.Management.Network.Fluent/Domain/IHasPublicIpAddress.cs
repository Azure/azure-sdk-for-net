// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to reference a public IP address.
    /// </summary>
    public interface IHasPublicIpAddress 
    {
        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string PublicIpAddressId { get; }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress GetPublicIpAddress();
    }
}