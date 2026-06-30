// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayClientRevocationOption type. </summary>
    public readonly partial struct ApplicationGatewayClientRevocationOption
    {
    }

    /// <summary> Compatibility declaration for the ApplicationGatewayCustomErrorStatusCode type. </summary>
    public readonly partial struct ApplicationGatewayCustomErrorStatusCode
    {
        /// <summary> Invokes the ApplicationGatewayCustomErrorStatusCode compatibility operation. </summary>
        [System.ObsoleteAttribute("This status is obsolete and will be removed in a future release", false)]
        public static ApplicationGatewayCustomErrorStatusCode HttpStatus499 { get; } = new ApplicationGatewayCustomErrorStatusCode("HttpStatus499");
    }

    /// <summary> Compatibility declaration for the ApplicationGatewayLoadDistributionAlgorithm type. </summary>
    public readonly partial struct ApplicationGatewayLoadDistributionAlgorithm
    {
    }

    /// <summary> Compatibility declaration for the ApplicationGatewaySslCipherSuite type. </summary>
    public readonly partial struct ApplicationGatewaySslCipherSuite
    {
        /// <summary> Gets or sets the TlsECDiffieHellmanECDsaWithAes128CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128CbcSha { get; } = TLSECDHEECDSAWITHAES128CBCSHA;
        /// <summary> Gets or sets the TlsECDiffieHellmanECDsaWithAes128CbcSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128CbcSha256 { get; } = TLSECDHEECDSAWITHAES128CBCSHA256;
        /// <summary> Gets or sets the TlsECDiffieHellmanECDsaWithAes128GcmSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128GcmSha256 { get; } = TLSECDHEECDSAWITHAES128GCMSHA256;
        /// <summary> Gets or sets the TlsECDiffieHellmanECDsaWithAes256CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256CbcSha { get; } = TLSECDHEECDSAWITHAES256CBCSHA;
        /// <summary> Gets or sets the TlsECDiffieHellmanECDsaWithAes256CbcSha384 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256CbcSha384 { get; } = TLSECDHEECDSAWITHAES256CBCSHA384;
        /// <summary> Gets or sets the TlsECDiffieHellmanECDsaWithAes256GcmSha384 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256GcmSha384 { get; } = TLSECDHEECDSAWITHAES256GCMSHA384;
        /// <summary> Gets or sets the TlsECDiffieHellmanRsaWithAes128CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128CbcSha { get; } = TLSECDHERSAWITHAES128CBCSHA;
        /// <summary> Gets or sets the TlsECDiffieHellmanRsaWithAes128CbcSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128CbcSha256 { get; } = TLSECDHERSAWITHAES128CBCSHA256;
        /// <summary> Gets or sets the TlsECDiffieHellmanRsaWithAes128GcmSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128GcmSha256 { get; } = TLSECDHERSAWITHAES128GCMSHA256;
        /// <summary> Gets or sets the TlsECDiffieHellmanRsaWithAes256CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256CbcSha { get; } = TLSECDHERSAWITHAES256CBCSHA;
        /// <summary> Gets or sets the TlsECDiffieHellmanRsaWithAes256CbcSha384 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256CbcSha384 { get; } = TLSECDHERSAWITHAES256CBCSHA384;
        /// <summary> Gets or sets the TlsECDiffieHellmanRsaWithAes256GcmSha384 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256GcmSha384 { get; } = TLSECDHERSAWITHAES256GCMSHA384;
    }

    /// <summary> Compatibility declaration for the ApplicationGatewaySslProtocol type. </summary>
    public readonly partial struct ApplicationGatewaySslProtocol
    {
        /// <summary> Gets or sets the Tls1_0 compatibility property. </summary>
        public static ApplicationGatewaySslProtocol Tls1_0 { get; } = TLSv10;
        /// <summary> Gets or sets the Tls1_1 compatibility property. </summary>
        public static ApplicationGatewaySslProtocol Tls1_1 { get; } = TLSv11;
        /// <summary> Gets or sets the Tls1_2 compatibility property. </summary>
        public static ApplicationGatewaySslProtocol Tls1_2 { get; } = TLSv12;
    }

    /// <summary> Compatibility declaration for the ApplicationGatewayTierType type. </summary>
    public readonly partial struct ApplicationGatewayTierType
    {
    }

    /// <summary> Compatibility declaration for the ApplicationGatewayWafRuleSensitivityType type. </summary>
    public readonly partial struct ApplicationGatewayWafRuleSensitivityType
    {
        /// <summary> Invokes the ApplicationGatewayWafRuleSensitivityType compatibility operation. </summary>
        public static ApplicationGatewayWafRuleSensitivityType None { get; } = new ApplicationGatewayWafRuleSensitivityType("None");
    }

    /// <summary> Compatibility declaration for the AzureFirewallNetworkRuleProtocol type. </summary>
    public readonly partial struct AzureFirewallNetworkRuleProtocol
    {
    }

    /// <summary> Compatibility declaration for the AzureFirewallSkuName type. </summary>
    public readonly partial struct AzureFirewallSkuName
    {
    }

    /// <summary> Compatibility declaration for the ConnectionMonitorEndpointType type. </summary>
    public readonly partial struct ConnectionMonitorEndpointType
    {
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType AzureArcNetwork { get; } = new ConnectionMonitorEndpointType("AzureArcNetwork");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType AzureArcVm { get; } = new ConnectionMonitorEndpointType("AzureArcVM");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType AzureSubnet { get; } = new ConnectionMonitorEndpointType("AzureSubnet");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType AzureVNet { get; } = new ConnectionMonitorEndpointType("AzureVNet");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType AzureVm { get; } = new ConnectionMonitorEndpointType("AzureVM");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType AzureVmss { get; } = new ConnectionMonitorEndpointType("AzureVMSS");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType ExternalAddress { get; } = new ConnectionMonitorEndpointType("ExternalAddress");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType MMAWorkspaceMachine { get; } = new ConnectionMonitorEndpointType("MMAWorkspaceMachine");
        /// <summary> Invokes the ConnectionMonitorEndpointType compatibility operation. </summary>
        public static ConnectionMonitorEndpointType MMAWorkspaceNetwork { get; } = new ConnectionMonitorEndpointType("MMAWorkspaceNetwork");
    }

    /// <summary> Compatibility declaration for the ConnectionMonitorSourceStatus type. </summary>
    public readonly partial struct ConnectionMonitorSourceStatus
    {
        /// <summary> Invokes the ConnectionMonitorSourceStatus compatibility operation. </summary>
        public static ConnectionMonitorSourceStatus Active { get; } = new ConnectionMonitorSourceStatus("Active");
        /// <summary> Invokes the ConnectionMonitorSourceStatus compatibility operation. </summary>
        public static ConnectionMonitorSourceStatus Inactive { get; } = new ConnectionMonitorSourceStatus("Inactive");
        /// <summary> Invokes the ConnectionMonitorSourceStatus compatibility operation. </summary>
        public static ConnectionMonitorSourceStatus Unknown { get; } = new ConnectionMonitorSourceStatus("Unknown");
    }

    /// <summary> Compatibility declaration for the DHGroup type. </summary>
    public readonly partial struct DHGroup
    {
    }
    /// <summary> Compatibility declaration for the DdosCustomPolicyProtocol type. </summary>

    [System.ObsoleteAttribute("This struct is obsolete and will be removed in a future release", false)]
    public readonly partial struct DdosCustomPolicyProtocol
    {
        /// <summary> Invokes the DdosCustomPolicyProtocol compatibility operation. </summary>
        public static DdosCustomPolicyProtocol Syn { get; } = new DdosCustomPolicyProtocol("Syn");
    }

    /// <summary> Compatibility declaration for the DdosSettingsProtectionCoverage type. </summary>
    public readonly partial struct DdosSettingsProtectionCoverage
    {
        /// <summary> Invokes the DdosSettingsProtectionCoverage compatibility operation. </summary>
        public static DdosSettingsProtectionCoverage Basic { get; } = new DdosSettingsProtectionCoverage("Basic");
        /// <summary> Invokes the DdosSettingsProtectionCoverage compatibility operation. </summary>
        public static DdosSettingsProtectionCoverage Standard { get; } = new DdosSettingsProtectionCoverage("Standard");
    }

    /// <summary> Compatibility declaration for the EvaluationState type. </summary>
    public readonly partial struct EvaluationState
    {
        /// <summary> Invokes the EvaluationState compatibility operation. </summary>
        public static EvaluationState Completed { get; } = new EvaluationState("Completed");
        /// <summary> Invokes the EvaluationState compatibility operation. </summary>
        public static EvaluationState InProgress { get; } = new EvaluationState("InProgress");
        /// <summary> Invokes the EvaluationState compatibility operation. </summary>
        public static EvaluationState NotStarted { get; } = new EvaluationState("NotStarted");
    }

    /// <summary> Compatibility declaration for the ExceptionEntryMatchVariable type. </summary>
    public readonly partial struct ExceptionEntryMatchVariable
    {
    }

    /// <summary> Compatibility declaration for the FirewallPolicyIntrusionDetectionProfileType type. </summary>
    public readonly partial struct FirewallPolicyIntrusionDetectionProfileType
    {
        /// <summary> Invokes the FirewallPolicyIntrusionDetectionProfileType compatibility operation. </summary>
        public static FirewallPolicyIntrusionDetectionProfileType Advanced { get; } = new FirewallPolicyIntrusionDetectionProfileType("Advanced");
        /// <summary> Invokes the FirewallPolicyIntrusionDetectionProfileType compatibility operation. </summary>
        public static FirewallPolicyIntrusionDetectionProfileType Basic { get; } = new FirewallPolicyIntrusionDetectionProfileType("Basic");
        /// <summary> Invokes the FirewallPolicyIntrusionDetectionProfileType compatibility operation. </summary>
        public static FirewallPolicyIntrusionDetectionProfileType Standard { get; } = new FirewallPolicyIntrusionDetectionProfileType("Standard");
    }

    /// <summary> Compatibility declaration for the FirewallPolicyIntrusionDetectionProtocol type. </summary>
    public readonly partial struct FirewallPolicyIntrusionDetectionProtocol
    {
    }

    /// <summary> Compatibility declaration for the FirewallPolicyNatRuleCollectionActionType type. </summary>
    public readonly partial struct FirewallPolicyNatRuleCollectionActionType
    {
    }

    /// <summary> Compatibility declaration for the FirewallPolicyRuleNetworkProtocol type. </summary>
    public readonly partial struct FirewallPolicyRuleNetworkProtocol
    {
    }

    /// <summary> Compatibility declaration for the FlowLogFormatType type. </summary>
    public readonly partial struct FlowLogFormatType
    {
    }

    /// <summary> Compatibility declaration for the GatewayLoadBalancerTunnelProtocol type. </summary>
    public readonly partial struct GatewayLoadBalancerTunnelProtocol
    {
    }

    /// <summary> Compatibility declaration for the IPFlowProtocol type. </summary>
    public readonly partial struct IPFlowProtocol
    {
    }

    /// <summary> Compatibility declaration for the IPsecEncryption type. </summary>
    public readonly partial struct IPsecEncryption
    {
    }

    /// <summary> Compatibility declaration for the IPsecIntegrity type. </summary>
    public readonly partial struct IPsecIntegrity
    {
        /// <summary> Invokes the IPsecIntegrity compatibility operation. </summary>
        public static IPsecIntegrity Sha384 { get; } = new IPsecIntegrity("SHA384");
    }

    /// <summary> Compatibility declaration for the IkeEncryption type. </summary>
    public readonly partial struct IkeEncryption
    {
    }

    /// <summary> Compatibility declaration for the IkeIntegrity type. </summary>
    public readonly partial struct IkeIntegrity
    {
    }

    /// <summary> Compatibility declaration for the InboundSecurityRulesProtocol type. </summary>
    public readonly partial struct InboundSecurityRulesProtocol
    {
    }

    /// <summary> Compatibility declaration for the LoadBalancerBackendAddressAdminState type. </summary>
    public readonly partial struct LoadBalancerBackendAddressAdminState
    {
        /// <summary> Invokes the LoadBalancerBackendAddressAdminState compatibility operation. </summary>
        [System.ObsoleteAttribute("This state is obsolete and will be removed in a future release", false)]
        public static LoadBalancerBackendAddressAdminState Drain { get; } = new LoadBalancerBackendAddressAdminState("Drain");
    }

    /// <summary> Compatibility declaration for the ManagedRuleSensitivityType type. </summary>
    public readonly partial struct ManagedRuleSensitivityType
    {
        /// <summary> Invokes the ManagedRuleSensitivityType compatibility operation. </summary>
        public static ManagedRuleSensitivityType None { get; } = new ManagedRuleSensitivityType("None");
    }

    /// <summary> Compatibility declaration for the NetworkAuthenticationMethod type. </summary>
    public readonly partial struct NetworkAuthenticationMethod
    {
    }

    /// <summary> Compatibility declaration for the NetworkProtocol type. </summary>
    public readonly partial struct NetworkProtocol
    {
    }

    /// <summary> Compatibility declaration for the PcProtocol type. </summary>
    public readonly partial struct PcProtocol
    {
    }

    /// <summary> Compatibility declaration for the PfsGroup type. </summary>
    public readonly partial struct PfsGroup
    {
        /// <summary> Invokes the PfsGroup compatibility operation. </summary>
        public static PfsGroup Pfs { get; } = new PfsGroup("PFS");
    }

    /// <summary> Compatibility declaration for the RuleMatchActionType type. </summary>
    public readonly partial struct RuleMatchActionType
    {
    }

    /// <summary> Compatibility declaration for the ScrubbingRuleEntryMatchVariable type. </summary>
    public readonly partial struct ScrubbingRuleEntryMatchVariable
    {
    }

    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionProtocol type. </summary>
    public readonly partial struct VirtualNetworkGatewayConnectionProtocol
    {
    }

    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionType type. </summary>
    public readonly partial struct VirtualNetworkGatewayConnectionType
    {
    }
    /// <summary> Compatibility declaration for the VpnAuthenticationType type. </summary>

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AAD")]
    public readonly partial struct VpnAuthenticationType
    {
        /// <summary> Invokes the VpnAuthenticationType compatibility operation. </summary>
        [System.ObsoleteAttribute("This value is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public static VpnAuthenticationType AAD { get; } = new VpnAuthenticationType("AAD");
        /// <summary> Invokes the VpnAuthenticationType compatibility operation. </summary>
        public static VpnAuthenticationType Aad { get; } = new VpnAuthenticationType("AAD");
    }

    /// <summary> Compatibility declaration for the VpnClientProtocol type. </summary>
    public readonly partial struct VpnClientProtocol
    {
    }

    /// <summary> Compatibility declaration for the VpnGatewayTunnelingProtocol type. </summary>
    public readonly partial struct VpnGatewayTunnelingProtocol
    {
    }

    /// <summary> Compatibility declaration for the VpnPolicyMemberAttributeType type. </summary>
    public readonly partial struct VpnPolicyMemberAttributeType
    {
    }

    /// <summary> Compatibility declaration for the WebApplicationFirewallAction type. </summary>
    public readonly partial struct WebApplicationFirewallAction
    {
    }
}
