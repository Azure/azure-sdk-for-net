// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NextHop.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of next hop parameters definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithTargetResource,
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithSourceIP,
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithDestinationIP,
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithExecute
    {
    }

    /// <summary>
    /// Sets the destination IP address.
    /// </summary>
    public interface IWithDestinationIP 
    {
        /// <summary>
        /// Set the destinationIPAddress value.
        /// </summary>
        /// <param name="destinationIPAddress">The destinationIPAddress value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithExecute WithDestinationIPAddress(string destinationIPAddress);
    }

    /// <summary>
    /// Sets the NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any
    /// of the nics, then this parameter must be specified. Otherwise optional).
    /// </summary>
    public interface IWithNetworkInterface 
    {
        /// <summary>
        /// Set the targetNetworkInterfaceId value.
        /// </summary>
        /// <param name="targetNetworkInterfaceId">The targetNetworkInterfaceId value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithExecute WithTargetNetworkInterfaceId(string targetNetworkInterfaceId);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.INextHop>,
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithNetworkInterface
    {
    }

    /// <summary>
    /// Sets the source IP address.
    /// </summary>
    public interface IWithSourceIP 
    {
        /// <summary>
        /// Set the sourceIPAddress value.
        /// </summary>
        /// <param name="sourceIPAddress">The sourceIPAddress value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithDestinationIP WithSourceIPAddress(string sourceIPAddress);
    }

    /// <summary>
    /// The first stage of a virtual machine definition.
    /// </summary>
    public interface IWithTargetResource 
    {
        /// <summary>
        /// Set the targetResourceId value.
        /// </summary>
        /// <param name="vmId">The targetResourceId value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.NextHop.Definition.IWithSourceIP WithTargetResourceId(string vmId);
    }
}