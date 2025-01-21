// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class LoadBalancerInboundNatPool : NetworkResourceData
    {
        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier FrontendIPConfigurationId
        {
            get => Properties?.FrontendIPConfigurationId;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.FrontendIPConfigurationId = value;
            }
        }

        /// <summary> The reference to the transport protocol used by the inbound NAT pool. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadBalancingTransportProtocol? Protocol
        {
            get => Properties?.Protocol;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.Protocol = value ?? default;
            }
        }

        /// <summary> The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65534. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? FrontendPortRangeStart
        {
            get => Properties?.FrontendPortRangeStart;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.FrontendPortRangeStart = value ?? default;
            }
        }

        /// <summary> The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65535. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? FrontendPortRangeEnd
        {
            get => Properties?.FrontendPortRangeEnd;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.FrontendPortRangeEnd = value ?? default;
            }
        }

        /// <summary> The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? BackendPort
        {
            get => Properties?.BackendPort;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.BackendPort = value ?? default;
            }
        }

        /// <summary> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? IdleTimeoutInMinutes
        {
            get => Properties?.IdleTimeoutInMinutes;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.IdleTimeoutInMinutes = value;
            }
        }

        /// <summary> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableFloatingIP
        {
            get => Properties?.EnableFloatingIP;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.EnableFloatingIP = value;
            }
        }

        /// <summary> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableTcpReset
        {
            get => Properties?.EnableTcpReset;
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadBalancerInboundNatPoolProperties();
                }
                Properties.EnableTcpReset = value;
            }
        }

        /// <summary> The provisioning state of the inbound NAT pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;
    }
}
