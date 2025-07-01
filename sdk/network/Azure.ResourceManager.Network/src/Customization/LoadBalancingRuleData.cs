// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    public partial class LoadBalancingRuleData : NetworkResourceData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnsureProperties()
        {
            Properties ??= new LoadBalancingRuleProperties(default, default);
        }

        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier FrontendIPConfigurationId
        {
            get => Properties?.FrontendIPConfigurationId;
            set
            {
                EnsureProperties();
                Properties.FrontendIPConfigurationId = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BackendAddressPoolId
        {
            get => Properties?.BackendAddressPoolId;
            set
            {
                EnsureProperties();
                Properties.BackendAddressPoolId = value;
            }
        }

        /// <summary> An array of references to pool of DIPs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> BackendAddressPools
        {
            get
            {
                EnsureProperties();
                return Properties.BackendAddressPools;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ProbeId
        {
            get => Properties?.ProbeId;
            set
            {
                EnsureProperties();
                Properties.ProbeId = value;
            }
        }

        /// <summary> The reference to the transport protocol used by the load balancing rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadBalancingTransportProtocol? Protocol
        {
            get => Properties?.Protocol;
            set
            {
                EnsureProperties();
                Properties.Protocol = value ?? default;
            }
        }

        /// <summary> The load distribution policy for this rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadDistribution? LoadDistribution
        {
            get => Properties?.LoadDistribution;
            set
            {
                EnsureProperties();
                Properties.LoadDistribution = value;
            }
        }

        /// <summary> The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values are between 0 and 65534. Note that value 0 enables "Any Port". </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? FrontendPort
        {
            get => Properties?.FrontendPort;
            set
            {
                EnsureProperties();
                Properties.FrontendPort = value ?? default;
            }
        }

        /// <summary> The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables "Any Port". </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? BackendPort
        {
            get => Properties?.BackendPort;
            set
            {
                EnsureProperties();
                Properties.BackendPort = value;
            }
        }

        /// <summary> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? IdleTimeoutInMinutes
        {
            get => Properties?.IdleTimeoutInMinutes;
            set
            {
                EnsureProperties();
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
                EnsureProperties();
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
                EnsureProperties();
                Properties.EnableTcpReset = value;
            }
        }

        /// <summary> Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableOutboundSnat
        {
            get => Properties?.DisableOutboundSnat;
            set
            {
                EnsureProperties();
                Properties.DisableOutboundSnat = value;
            }
        }

        /// <summary> The provisioning state of the load balancing rule resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;
    }
}
