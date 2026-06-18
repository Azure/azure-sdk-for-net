// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayClientRevocationOption type. </summary>
    public readonly partial struct ApplicationGatewayClientRevocationOption
    {
        /// <summary> Gets or sets the Ocsp compatibility property. </summary>
        public static ApplicationGatewayClientRevocationOption Ocsp { get; } = OCSP;
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
        /// <summary> Gets or sets the IPHash compatibility property. </summary>
        public static ApplicationGatewayLoadDistributionAlgorithm IPHash { get; } = IpHash;
    }

    /// <summary> Compatibility declaration for the ApplicationGatewaySslCipherSuite type. </summary>
    public readonly partial struct ApplicationGatewaySslCipherSuite
    {
        /// <summary> Gets or sets the TlsDHERsaWithAes128CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes128CbcSha { get; } = TLSDHERSAWITHAES128CBCSHA;
        /// <summary> Gets or sets the TlsDHERsaWithAes128GcmSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes128GcmSha256 { get; } = TLSDHERSAWITHAES128GCMSHA256;
        /// <summary> Gets or sets the TlsDHERsaWithAes256CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes256CbcSha { get; } = TLSDHERSAWITHAES256CBCSHA;
        /// <summary> Gets or sets the TlsDHERsaWithAes256GcmSha384 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes256GcmSha384 { get; } = TLSDHERSAWITHAES256GCMSHA384;
        /// <summary> Gets or sets the TlsDheDssWith3DesEdeCbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDheDssWith3DesEdeCbcSha { get; } = TLSDHEDSSWITH3DESEDECBCSHA;
        /// <summary> Gets or sets the TlsDheDssWithAes128CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes128CbcSha { get; } = TLSDHEDSSWITHAES128CBCSHA;
        /// <summary> Gets or sets the TlsDheDssWithAes128CbcSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes128CbcSha256 { get; } = TLSDHEDSSWITHAES128CBCSHA256;
        /// <summary> Gets or sets the TlsDheDssWithAes256CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes256CbcSha { get; } = TLSDHEDSSWITHAES256CBCSHA;
        /// <summary> Gets or sets the TlsDheDssWithAes256CbcSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes256CbcSha256 { get; } = TLSDHEDSSWITHAES256CBCSHA256;
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
        /// <summary> Gets or sets the TlsRsaWith3DesEdeCbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWith3DesEdeCbcSha { get; } = TLSRSAWITH3DESEDECBCSHA;
        /// <summary> Gets or sets the TlsRsaWithAes128CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128CbcSha { get; } = TLSRSAWITHAES128CBCSHA;
        /// <summary> Gets or sets the TlsRsaWithAes128CbcSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128CbcSha256 { get; } = TLSRSAWITHAES128CBCSHA256;
        /// <summary> Gets or sets the TlsRsaWithAes128GcmSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128GcmSha256 { get; } = TLSRSAWITHAES128GCMSHA256;
        /// <summary> Gets or sets the TlsRsaWithAes256CbcSha compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256CbcSha { get; } = TLSRSAWITHAES256CBCSHA;
        /// <summary> Gets or sets the TlsRsaWithAes256CbcSha256 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256CbcSha256 { get; } = TLSRSAWITHAES256CBCSHA256;
        /// <summary> Gets or sets the TlsRsaWithAes256GcmSha384 compatibility property. </summary>
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256GcmSha384 { get; } = TLSRSAWITHAES256GCMSHA384;
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
        /// <summary> Gets or sets the Waf compatibility property. </summary>
        public static ApplicationGatewayTierType Waf { get; } = WAF;
        /// <summary> Gets or sets the WafV2 compatibility property. </summary>
        public static ApplicationGatewayTierType WafV2 { get; } = WAFV2;
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
        /// <summary> Gets or sets the Icmp compatibility property. </summary>
        public static AzureFirewallNetworkRuleProtocol Icmp { get; } = ICMP;
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static AzureFirewallNetworkRuleProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static AzureFirewallNetworkRuleProtocol Udp { get; } = UDP;
    }

    /// <summary> Compatibility declaration for the AzureFirewallSkuName type. </summary>
    public readonly partial struct AzureFirewallSkuName
    {
        /// <summary> Gets or sets the AzfwHub compatibility property. </summary>
        public static AzureFirewallSkuName AzfwHub { get; } = AZFWHub;
        /// <summary> Gets or sets the AzfwVnet compatibility property. </summary>
        public static AzureFirewallSkuName AzfwVnet { get; } = AZFWVNet;
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
        /// <summary> Gets or sets the Ecp256 compatibility property. </summary>
        public static DHGroup Ecp256 { get; } = ECP256;
        /// <summary> Gets or sets the Ecp384 compatibility property. </summary>
        public static DHGroup Ecp384 { get; } = ECP384;
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
        /// <summary> Gets or sets the RequestUri compatibility property. </summary>
        public static ExceptionEntryMatchVariable RequestUri { get; } = RequestURI;
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
        /// <summary> Gets or sets the Any compatibility property. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol Any { get; } = ANY;
        /// <summary> Gets or sets the Icmp compatibility property. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol Icmp { get; } = ICMP;
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol Udp { get; } = UDP;
    }

    /// <summary> Compatibility declaration for the FirewallPolicyNatRuleCollectionActionType type. </summary>
    public readonly partial struct FirewallPolicyNatRuleCollectionActionType
    {
        /// <summary> Gets or sets the Dnat compatibility property. </summary>
        public static FirewallPolicyNatRuleCollectionActionType Dnat { get; } = DNAT;
    }

    /// <summary> Compatibility declaration for the FirewallPolicyRuleNetworkProtocol type. </summary>
    public readonly partial struct FirewallPolicyRuleNetworkProtocol
    {
        /// <summary> Gets or sets the Icmp compatibility property. </summary>
        public static FirewallPolicyRuleNetworkProtocol Icmp { get; } = ICMP;
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static FirewallPolicyRuleNetworkProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static FirewallPolicyRuleNetworkProtocol Udp { get; } = UDP;
    }

    /// <summary> Compatibility declaration for the FlowLogFormatType type. </summary>
    public readonly partial struct FlowLogFormatType
    {
        /// <summary> Gets or sets the Json compatibility property. </summary>
        public static FlowLogFormatType Json { get; } = JSON;
    }

    /// <summary> Compatibility declaration for the GatewayLoadBalancerTunnelProtocol type. </summary>
    public readonly partial struct GatewayLoadBalancerTunnelProtocol
    {
        /// <summary> Gets or sets the Vxlan compatibility property. </summary>
        public static GatewayLoadBalancerTunnelProtocol Vxlan { get; } = VXLAN;
    }

    /// <summary> Compatibility declaration for the IPFlowProtocol type. </summary>
    public readonly partial struct IPFlowProtocol
    {
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static IPFlowProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static IPFlowProtocol Udp { get; } = UDP;
    }

    /// <summary> Compatibility declaration for the IPsecEncryption type. </summary>
    public readonly partial struct IPsecEncryption
    {
        /// <summary> Gets or sets the Aes128 compatibility property. </summary>
        public static IPsecEncryption Aes128 { get; } = AES128;
        /// <summary> Gets or sets the Aes192 compatibility property. </summary>
        public static IPsecEncryption Aes192 { get; } = AES192;
        /// <summary> Gets or sets the Aes256 compatibility property. </summary>
        public static IPsecEncryption Aes256 { get; } = AES256;
        /// <summary> Gets or sets the Des compatibility property. </summary>
        public static IPsecEncryption Des { get; } = DES;
        /// <summary> Gets or sets the Des3 compatibility property. </summary>
        public static IPsecEncryption Des3 { get; } = DES3;
        /// <summary> Gets or sets the GcmAes128 compatibility property. </summary>
        public static IPsecEncryption GcmAes128 { get; } = GCMAES128;
        /// <summary> Gets or sets the GcmAes192 compatibility property. </summary>
        public static IPsecEncryption GcmAes192 { get; } = GCMAES192;
        /// <summary> Gets or sets the GcmAes256 compatibility property. </summary>
        public static IPsecEncryption GcmAes256 { get; } = GCMAES256;
    }

    /// <summary> Compatibility declaration for the IPsecIntegrity type. </summary>
    public readonly partial struct IPsecIntegrity
    {
        /// <summary> Gets or sets the GcmAes128 compatibility property. </summary>
        public static IPsecIntegrity GcmAes128 { get; } = GCMAES128;
        /// <summary> Gets or sets the GcmAes256 compatibility property. </summary>
        public static IPsecIntegrity GcmAes256 { get; } = GCMAES256;
        /// <summary> Gets or sets the Sha1 compatibility property. </summary>
        public static IPsecIntegrity Sha1 { get; } = SHA1;
        /// <summary> Gets or sets the Sha256 compatibility property. </summary>
        public static IPsecIntegrity Sha256 { get; } = SHA256;
        /// <summary> Invokes the IPsecIntegrity compatibility operation. </summary>
        public static IPsecIntegrity Sha384 { get; } = new IPsecIntegrity("SHA384");
    }

    /// <summary> Compatibility declaration for the IkeEncryption type. </summary>
    public readonly partial struct IkeEncryption
    {
        /// <summary> Gets or sets the Aes128 compatibility property. </summary>
        public static IkeEncryption Aes128 { get; } = AES128;
        /// <summary> Gets or sets the Aes192 compatibility property. </summary>
        public static IkeEncryption Aes192 { get; } = AES192;
        /// <summary> Gets or sets the Aes256 compatibility property. </summary>
        public static IkeEncryption Aes256 { get; } = AES256;
        /// <summary> Gets or sets the Des compatibility property. </summary>
        public static IkeEncryption Des { get; } = DES;
        /// <summary> Gets or sets the Des3 compatibility property. </summary>
        public static IkeEncryption Des3 { get; } = DES3;
        /// <summary> Gets or sets the GcmAes128 compatibility property. </summary>
        public static IkeEncryption GcmAes128 { get; } = GCMAES128;
        /// <summary> Gets or sets the GcmAes256 compatibility property. </summary>
        public static IkeEncryption GcmAes256 { get; } = GCMAES256;
    }

    /// <summary> Compatibility declaration for the IkeIntegrity type. </summary>
    public readonly partial struct IkeIntegrity
    {
        /// <summary> Gets or sets the GcmAes128 compatibility property. </summary>
        public static IkeIntegrity GcmAes128 { get; } = GCMAES128;
        /// <summary> Gets or sets the GcmAes256 compatibility property. </summary>
        public static IkeIntegrity GcmAes256 { get; } = GCMAES256;
        /// <summary> Gets or sets the Sha1 compatibility property. </summary>
        public static IkeIntegrity Sha1 { get; } = SHA1;
        /// <summary> Gets or sets the Sha256 compatibility property. </summary>
        public static IkeIntegrity Sha256 { get; } = SHA256;
        /// <summary> Gets or sets the Sha384 compatibility property. </summary>
        public static IkeIntegrity Sha384 { get; } = SHA384;
    }

    /// <summary> Compatibility declaration for the InboundSecurityRulesProtocol type. </summary>
    public readonly partial struct InboundSecurityRulesProtocol
    {
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static InboundSecurityRulesProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static InboundSecurityRulesProtocol Udp { get; } = UDP;
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
        /// <summary> Gets or sets the EapmschaPv2 compatibility property. </summary>
        public static NetworkAuthenticationMethod EapmschaPv2 { get; } = EAPMSCHAPv2;
        /// <summary> Gets or sets the Eaptls compatibility property. </summary>
        public static NetworkAuthenticationMethod Eaptls { get; } = EAPTLS;
    }

    /// <summary> Compatibility declaration for the NetworkProtocol type. </summary>
    public readonly partial struct NetworkProtocol
    {
        /// <summary> Gets or sets the Icmp compatibility property. </summary>
        public static NetworkProtocol Icmp { get; } = ICMP;
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static NetworkProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static NetworkProtocol Udp { get; } = UDP;
    }

    /// <summary> Compatibility declaration for the PcProtocol type. </summary>
    public readonly partial struct PcProtocol
    {
        /// <summary> Gets or sets the Tcp compatibility property. </summary>
        public static PcProtocol Tcp { get; } = TCP;
        /// <summary> Gets or sets the Udp compatibility property. </summary>
        public static PcProtocol Udp { get; } = UDP;
    }

    /// <summary> Compatibility declaration for the PfsGroup type. </summary>
    public readonly partial struct PfsGroup
    {
        /// <summary> Gets or sets the Ecp256 compatibility property. </summary>
        public static PfsGroup Ecp256 { get; } = ECP256;
        /// <summary> Gets or sets the Ecp384 compatibility property. </summary>
        public static PfsGroup Ecp384 { get; } = ECP384;
        /// <summary> Invokes the PfsGroup compatibility operation. </summary>
        public static PfsGroup Pfs { get; } = new PfsGroup("PFS");
        /// <summary> Gets or sets the Pfs1 compatibility property. </summary>
        public static PfsGroup Pfs1 { get; } = PFS1;
        /// <summary> Gets or sets the Pfs14 compatibility property. </summary>
        public static PfsGroup Pfs14 { get; } = PFS14;
        /// <summary> Gets or sets the Pfs2 compatibility property. </summary>
        public static PfsGroup Pfs2 { get; } = PFS2;
        /// <summary> Gets or sets the Pfs2048 compatibility property. </summary>
        public static PfsGroup Pfs2048 { get; } = PFS2048;
        /// <summary> Gets or sets the Pfs24 compatibility property. </summary>
        public static PfsGroup Pfs24 { get; } = PFS24;
    }

    /// <summary> Compatibility declaration for the RuleMatchActionType type. </summary>
    public readonly partial struct RuleMatchActionType
    {
        /// <summary> Gets or sets the Captcha compatibility property. </summary>
        public static RuleMatchActionType Captcha { get; } = CAPTCHA;
    }

    /// <summary> Compatibility declaration for the ScrubbingRuleEntryMatchVariable type. </summary>
    public readonly partial struct ScrubbingRuleEntryMatchVariable
    {
        /// <summary> Gets or sets the RequestJsonArgNames compatibility property. </summary>
        public static ScrubbingRuleEntryMatchVariable RequestJsonArgNames { get; } = RequestJSONArgNames;
    }

    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionProtocol type. </summary>
    public readonly partial struct VirtualNetworkGatewayConnectionProtocol
    {
        /// <summary> Gets or sets the IkeV1 compatibility property. </summary>
        public static VirtualNetworkGatewayConnectionProtocol IkeV1 { get; } = IKEv1;
        /// <summary> Gets or sets the IkeV2 compatibility property. </summary>
        public static VirtualNetworkGatewayConnectionProtocol IkeV2 { get; } = IKEv2;
    }

    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionType type. </summary>
    public readonly partial struct VirtualNetworkGatewayConnectionType
    {
        /// <summary> Gets or sets the VpnClient compatibility property. </summary>
        public static VirtualNetworkGatewayConnectionType VpnClient { get; } = VPNClient;
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
        /// <summary> Gets or sets the OpenVpn compatibility property. </summary>
        public static VpnClientProtocol OpenVpn { get; } = OpenVPN;
        /// <summary> Gets or sets the Sstp compatibility property. </summary>
        public static VpnClientProtocol Sstp { get; } = SSTP;
    }

    /// <summary> Compatibility declaration for the VpnGatewayTunnelingProtocol type. </summary>
    public readonly partial struct VpnGatewayTunnelingProtocol
    {
        /// <summary> Gets or sets the OpenVpn compatibility property. </summary>
        public static VpnGatewayTunnelingProtocol OpenVpn { get; } = OpenVPN;
    }

    /// <summary> Compatibility declaration for the VpnPolicyMemberAttributeType type. </summary>
    public readonly partial struct VpnPolicyMemberAttributeType
    {
        /// <summary> Gets or sets the AadGroupId compatibility property. </summary>
        public static VpnPolicyMemberAttributeType AadGroupId { get; } = AADGroupId;
    }

    /// <summary> Compatibility declaration for the WebApplicationFirewallAction type. </summary>
    public readonly partial struct WebApplicationFirewallAction
    {
        /// <summary> Gets or sets the Captcha compatibility property. </summary>
        public static WebApplicationFirewallAction Captcha { get; } = CAPTCHA;
    }
}
