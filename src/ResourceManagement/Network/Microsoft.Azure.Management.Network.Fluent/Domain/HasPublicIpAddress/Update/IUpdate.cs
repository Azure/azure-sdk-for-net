// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage definition allowing to associate the resource with an existing public IP address.
    /// </summary>
    public interface IWithExistingPublicIpAddress<ReturnT> 
    {
        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        ReturnT WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress);

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        ReturnT WithExistingPublicIpAddress(string resourceId);

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        ReturnT WithoutPublicIpAddress();
    }

    /// <summary>
    /// The stage definition allowing to associate the resource with a new public IP address.
    /// </summary>
    public interface IWithNewPublicIpAddress<ReturnT> 
    {
        /// <summary>
        /// Creates a new public IP address to associate with the resource, based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP address.</param>
        ReturnT WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        ReturnT WithNewPublicIpAddress();

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        ReturnT WithNewPublicIpAddress(string leafDnsLabel);
    }

    /// <summary>
    /// The stage definition allowing to associate the resource with a public IP address.
    /// </summary>
    public interface IWithPublicIpAddress<ReturnT>  :
        IWithExistingPublicIpAddress<ReturnT>,
        IWithNewPublicIpAddress<ReturnT>
    {
    }
}