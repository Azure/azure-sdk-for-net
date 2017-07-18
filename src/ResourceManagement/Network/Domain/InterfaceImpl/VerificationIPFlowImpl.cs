// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VerificationIPFlowImpl 
    {
        /// <summary>
        /// Set the remotePort value.
        /// </summary>
        /// <param name="remotePort">The remotePort value to set.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithExecute VerificationIPFlow.Definition.IWithRemotePort.WithRemotePort(string remotePort)
        {
            return this.WithRemotePort(remotePort) as VerificationIPFlow.Definition.IWithExecute;
        }

        /// <summary>
        /// Set UDP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithLocalIP VerificationIPFlow.Definition.IWithProtocol.WithUDP()
        {
            return this.WithUDP() as VerificationIPFlow.Definition.IWithLocalIP;
        }

        /// <summary>
        /// Set TCP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithLocalIP VerificationIPFlow.Definition.IWithProtocol.WithTCP()
        {
            return this.WithTCP() as VerificationIPFlow.Definition.IWithLocalIP;
        }

        /// <summary>
        /// Set the localPort value.
        /// </summary>
        /// <param name="localPort">The localPort value to set.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithRemotePort VerificationIPFlow.Definition.IWithLocalPort.WithLocalPort(string localPort)
        {
            return this.WithLocalPort(localPort) as VerificationIPFlow.Definition.IWithRemotePort;
        }

        /// <summary>
        /// Set the remoteIPAddress value.
        /// </summary>
        /// <param name="remoteIPAddress">The remoteIPAddress value to set.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithLocalPort VerificationIPFlow.Definition.IWithRemoteIP.WithRemoteIPAddress(string remoteIPAddress)
        {
            return this.WithRemoteIPAddress(remoteIPAddress) as VerificationIPFlow.Definition.IWithLocalPort;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.INetworkWatcher;
            }
        }

        /// <summary>
        /// Set the localIPAddress value.
        /// </summary>
        /// <param name="localIPAddress">The localIPAddress value to set.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithRemoteIP VerificationIPFlow.Definition.IWithLocalIP.WithLocalIPAddress(string localIPAddress)
        {
            return this.WithLocalIPAddress(localIPAddress) as VerificationIPFlow.Definition.IWithRemoteIP;
        }

        /// <summary>
        /// Gets the access value. Indicates whether the traffic is allowed or denied. Possible values
        /// include: 'Allow', 'Deny'.
        /// </summary>
        /// <summary>
        /// Gets the access value.
        /// </summary>
        Models.Access Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow.Access
        {
            get
            {
                return this.Access() as Models.Access;
            }
        }

        /// <summary>
        /// Gets the ruleName value. If input is not matched against any security rule, it
        /// is not displayed.
        /// </summary>
        /// <summary>
        /// Gets the ruleName value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow.RuleName
        {
            get
            {
                return this.RuleName();
            }
        }

        /// <summary>
        /// Gets Set outbound direction.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        VerificationIPFlow.Definition.IWithProtocol VerificationIPFlow.Definition.IWithDirection.Outbound
        {
            get
            {
                return this.Outbound() as VerificationIPFlow.Definition.IWithProtocol;
            }
        }

        /// <summary>
        /// Set the direction value.
        /// </summary>
        /// <param name="direction">The direction value to set.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithProtocol VerificationIPFlow.Definition.IWithDirection.WithDirection(Direction direction)
        {
            return this.WithDirection(direction) as VerificationIPFlow.Definition.IWithProtocol;
        }

        /// <summary>
        /// Gets Set inbound direction.
        /// </summary>
        /// <summary>
        /// Gets the next stage of the definition.
        /// </summary>
        VerificationIPFlow.Definition.IWithProtocol VerificationIPFlow.Definition.IWithDirection.Inbound
        {
            get
            {
                return this.Inbound() as VerificationIPFlow.Definition.IWithProtocol;
            }
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithLocalIP HasProtocol.Definition.IWithProtocol<VerificationIPFlow.Definition.IWithLocalIP,Models.Protocol>.WithProtocol(Protocol protocol)
        {
            return this.WithProtocol(protocol) as VerificationIPFlow.Definition.IWithLocalIP;
        }

        /// <summary>
        /// Set the targetNetworkInterfaceId value.
        /// </summary>
        /// <param name="targetNetworkInterfaceId">The targetNetworkInterfaceId value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow VerificationIPFlow.Definition.IWithNetworkInterface.WithTargetNetworkInterfaceId(string targetNetworkInterfaceId)
        {
            return this.WithTargetNetworkInterfaceId(targetNetworkInterfaceId) as Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow;
        }

        /// <summary>
        /// Set the targetResourceId value.
        /// </summary>
        /// <param name="vmId">The targetResourceId value to set.</param>
        /// <return>The next stage of the definition.</return>
        VerificationIPFlow.Definition.IWithDirection VerificationIPFlow.Definition.IWithTargetResource.WithTargetResourceId(string vmId)
        {
            return this.WithTargetResourceId(vmId) as VerificationIPFlow.Definition.IWithDirection;
        }
    }
}