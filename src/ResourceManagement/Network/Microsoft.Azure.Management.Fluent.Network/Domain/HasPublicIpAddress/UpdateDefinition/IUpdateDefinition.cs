// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Network;
    /// <summary>
    /// The stage of the definition allowing to associate the resource with a public IP address.
    /// 
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithPublicIpAddress<ReturnT>  :
        IWithExistingPublicIpAddress<ReturnT>,
        IWithNewPublicIpAddress<ReturnT>
    {
    }
    /// <summary>
    /// The stage of the definition allowing to associate the resource with a new public IP address.
    /// 
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithNewPublicIpAddress<ReturnT> 
    {
        /// <summary>
        /// Creates a new public IP address to associate with the resource, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP address</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithNewPublicIpAddress();

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithNewPublicIpAddress(string leafDnsLabel);

    }
    /// <summary>
    /// The stage of the definition allowing to associate the resource with an existing public IP address.
    /// 
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithExistingPublicIpAddress<ReturnT> 
    {
        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress);

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithExistingPublicIpAddress(string resourceId);

    }
}