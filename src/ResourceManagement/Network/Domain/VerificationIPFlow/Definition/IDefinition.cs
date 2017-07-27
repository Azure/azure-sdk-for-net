// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The direction of the packet represented as a 5-tuple. Possible values
    /// include: 'Inbound', 'Outbound'.
    /// </summary>
    public interface IWithDirection 
    {
        /// <summary>
        /// Set the direction value.
        /// </summary>
        /// <param name="direction">The direction value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithProtocol WithDirection(Direction direction);

        /// <summary>
        /// Gets Set inbound direction.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithProtocol Inbound { get; }

        /// <summary>
        /// Gets Set outbound direction.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithProtocol Outbound { get; }
    }

    /// <summary>
    /// The local port. Acceptable values are a single integer in the range
    /// (0-65535). Support for  for the source port, which depends on the
    /// direction.
    /// </summary>
    public interface IWithLocalPort 
    {
        /// <summary>
        /// Set the localPort value.
        /// </summary>
        /// <param name="localPort">The localPort value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithRemotePort WithLocalPort(string localPort);
    }

    /// <summary>
    /// The entirety of verification ip flow parameters definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithTargetResource,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithDirection,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithLocalIP,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithRemoteIP,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithLocalPort,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithRemotePort,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithExecute
    {
    }

    /// <summary>
    /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any
    /// of them, then this parameter must be specified. Otherwise optional).
    /// </summary>
    public interface IWithNetworkInterface 
    {
        /// <summary>
        /// Set the targetNetworkInterfaceId value.
        /// </summary>
        /// <param name="targetNetworkInterfaceId">The targetNetworkInterfaceId value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow WithTargetNetworkInterfaceId(string targetNetworkInterfaceId);
    }

    /// <summary>
    /// Protocol to be verified on. Possible values include: 'TCP', 'UDP'.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithLocalIP,Microsoft.Azure.Management.Network.Fluent.Models.Protocol>
    {
        /// <summary>
        /// Set TCP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithLocalIP WithTCP();

        /// <summary>
        /// Set UDP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithLocalIP WithUDP();
    }

    /// <summary>
    /// The remote IP address. Acceptable values are valid IPv4 addresses.
    /// </summary>
    public interface IWithRemoteIP 
    {
        /// <summary>
        /// Set the remoteIPAddress value.
        /// </summary>
        /// <param name="remoteIPAddress">The remoteIPAddress value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithLocalPort WithRemoteIPAddress(string remoteIPAddress);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required parameters
    /// to execute an action, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow>,
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithNetworkInterface
    {
    }

    /// <summary>
    /// The local IP address. Acceptable values are valid IPv4 addresses.
    /// </summary>
    public interface IWithLocalIP 
    {
        /// <summary>
        /// Set the localIPAddress value.
        /// </summary>
        /// <param name="localIPAddress">The localIPAddress value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithRemoteIP WithLocalIPAddress(string localIPAddress);
    }

    /// <summary>
    /// The ID of the target resource to perform next-hop on.
    /// </summary>
    public interface IWithTargetResource 
    {
        /// <summary>
        /// Set the targetResourceId value.
        /// </summary>
        /// <param name="vmId">The targetResourceId value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithDirection WithTargetResourceId(string vmId);
    }

    /// <summary>
    /// The remote port. Acceptable values are a single integer in the range
    /// (0-65535). Support for  for the source port, which depends on the
    /// direction.
    /// </summary>
    public interface IWithRemotePort 
    {
        /// <summary>
        /// Set the remotePort value.
        /// </summary>
        /// <param name="remotePort">The remotePort value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition.IWithExecute WithRemotePort(string remotePort);
    }
}