// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402 // Compatibility shims for multiple enum-like types are grouped intentionally.

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct ApplicationGatewayClientRevocationOption
    {
        public static ApplicationGatewayClientRevocationOption Ocsp { get; } = OCSP;
    }

    public readonly partial struct ApplicationGatewayCustomErrorStatusCode
    {
        [System.ObsoleteAttribute("This status is obsolete and will be removed in a future release", false)]
        public static ApplicationGatewayCustomErrorStatusCode HttpStatus499 { get; } = new ApplicationGatewayCustomErrorStatusCode("HttpStatus499");
    }

    public readonly partial struct ApplicationGatewayLoadDistributionAlgorithm
    {
        public static ApplicationGatewayLoadDistributionAlgorithm IPHash { get; } = IpHash;
    }

    public readonly partial struct ApplicationGatewaySslCipherSuite
    {
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes128CbcSha { get; } = TLSDHERSAWITHAES128CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes128GcmSha256 { get; } = TLSDHERSAWITHAES128GCMSHA256;
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes256CbcSha { get; } = TLSDHERSAWITHAES256CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes256GcmSha384 { get; } = TLSDHERSAWITHAES256GCMSHA384;
        public static ApplicationGatewaySslCipherSuite TlsDheDssWith3DesEdeCbcSha { get; } = TLSDHEDSSWITH3DESEDECBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes128CbcSha { get; } = TLSDHEDSSWITHAES128CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes128CbcSha256 { get; } = TLSDHEDSSWITHAES128CBCSHA256;
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes256CbcSha { get; } = TLSDHEDSSWITHAES256CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes256CbcSha256 { get; } = TLSDHEDSSWITHAES256CBCSHA256;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128CbcSha { get; } = TLSECDHEECDSAWITHAES128CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128CbcSha256 { get; } = TLSECDHEECDSAWITHAES128CBCSHA256;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128GcmSha256 { get; } = TLSECDHEECDSAWITHAES128GCMSHA256;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256CbcSha { get; } = TLSECDHEECDSAWITHAES256CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256CbcSha384 { get; } = TLSECDHEECDSAWITHAES256CBCSHA384;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256GcmSha384 { get; } = TLSECDHEECDSAWITHAES256GCMSHA384;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128CbcSha { get; } = TLSECDHERSAWITHAES128CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128CbcSha256 { get; } = TLSECDHERSAWITHAES128CBCSHA256;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128GcmSha256 { get; } = TLSECDHERSAWITHAES128GCMSHA256;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256CbcSha { get; } = TLSECDHERSAWITHAES256CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256CbcSha384 { get; } = TLSECDHERSAWITHAES256CBCSHA384;
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256GcmSha384 { get; } = TLSECDHERSAWITHAES256GCMSHA384;
        public static ApplicationGatewaySslCipherSuite TlsRsaWith3DesEdeCbcSha { get; } = TLSRSAWITH3DESEDECBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128CbcSha { get; } = TLSRSAWITHAES128CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128CbcSha256 { get; } = TLSRSAWITHAES128CBCSHA256;
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128GcmSha256 { get; } = TLSRSAWITHAES128GCMSHA256;
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256CbcSha { get; } = TLSRSAWITHAES256CBCSHA;
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256CbcSha256 { get; } = TLSRSAWITHAES256CBCSHA256;
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256GcmSha384 { get; } = TLSRSAWITHAES256GCMSHA384;
    }

    public readonly partial struct ApplicationGatewaySslProtocol
    {
        public static ApplicationGatewaySslProtocol Tls1_0 { get; } = TLSv10;
        public static ApplicationGatewaySslProtocol Tls1_1 { get; } = TLSv11;
        public static ApplicationGatewaySslProtocol Tls1_2 { get; } = TLSv12;
    }

    public readonly partial struct ApplicationGatewayTierType
    {
        public static ApplicationGatewayTierType Waf { get; } = WAF;
        public static ApplicationGatewayTierType WafV2 { get; } = WAFV2;
    }

    public readonly partial struct ApplicationGatewayWafRuleSensitivityType
    {
        public static ApplicationGatewayWafRuleSensitivityType None { get; } = new ApplicationGatewayWafRuleSensitivityType("None");
    }

    public readonly partial struct AzureFirewallNetworkRuleProtocol
    {
        public static AzureFirewallNetworkRuleProtocol Icmp { get; } = ICMP;
        public static AzureFirewallNetworkRuleProtocol Tcp { get; } = TCP;
        public static AzureFirewallNetworkRuleProtocol Udp { get; } = UDP;
    }

    public readonly partial struct AzureFirewallSkuName
    {
        public static AzureFirewallSkuName AzfwHub { get; } = AZFWHub;
        public static AzureFirewallSkuName AzfwVnet { get; } = AZFWVNet;
    }

    public readonly partial struct ConnectionMonitorEndpointType
    {
        public static ConnectionMonitorEndpointType AzureArcNetwork { get; } = new ConnectionMonitorEndpointType("AzureArcNetwork");
        public static ConnectionMonitorEndpointType AzureArcVm { get; } = new ConnectionMonitorEndpointType("AzureArcVM");
        public static ConnectionMonitorEndpointType AzureSubnet { get; } = new ConnectionMonitorEndpointType("AzureSubnet");
        public static ConnectionMonitorEndpointType AzureVNet { get; } = new ConnectionMonitorEndpointType("AzureVNet");
        public static ConnectionMonitorEndpointType AzureVm { get; } = new ConnectionMonitorEndpointType("AzureVM");
        public static ConnectionMonitorEndpointType AzureVmss { get; } = new ConnectionMonitorEndpointType("AzureVMSS");
        public static ConnectionMonitorEndpointType ExternalAddress { get; } = new ConnectionMonitorEndpointType("ExternalAddress");
        public static ConnectionMonitorEndpointType MMAWorkspaceMachine { get; } = new ConnectionMonitorEndpointType("MMAWorkspaceMachine");
        public static ConnectionMonitorEndpointType MMAWorkspaceNetwork { get; } = new ConnectionMonitorEndpointType("MMAWorkspaceNetwork");
    }

    public readonly partial struct ConnectionMonitorSourceStatus
    {
        public static ConnectionMonitorSourceStatus Active { get; } = new ConnectionMonitorSourceStatus("Active");
        public static ConnectionMonitorSourceStatus Inactive { get; } = new ConnectionMonitorSourceStatus("Inactive");
        public static ConnectionMonitorSourceStatus Unknown { get; } = new ConnectionMonitorSourceStatus("Unknown");
    }

    public readonly partial struct DHGroup
    {
        public static DHGroup Ecp256 { get; } = ECP256;
        public static DHGroup Ecp384 { get; } = ECP384;
    }

    [System.ObsoleteAttribute("This struct is obsolete and will be removed in a future release", false)]
    public readonly partial struct DdosCustomPolicyProtocol
    {
        public static DdosCustomPolicyProtocol Syn { get; } = new DdosCustomPolicyProtocol("Syn");
    }

    public readonly partial struct DdosSettingsProtectionCoverage
    {
        public static DdosSettingsProtectionCoverage Basic { get; } = new DdosSettingsProtectionCoverage("Basic");
        public static DdosSettingsProtectionCoverage Standard { get; } = new DdosSettingsProtectionCoverage("Standard");
    }

    public readonly partial struct EvaluationState
    {
        public static EvaluationState Completed { get; } = new EvaluationState("Completed");
        public static EvaluationState InProgress { get; } = new EvaluationState("InProgress");
        public static EvaluationState NotStarted { get; } = new EvaluationState("NotStarted");
    }

    public readonly partial struct ExceptionEntryMatchVariable
    {
        public static ExceptionEntryMatchVariable RequestUri { get; } = RequestURI;
    }

    public readonly partial struct FirewallPolicyIntrusionDetectionProfileType
    {
        public static FirewallPolicyIntrusionDetectionProfileType Advanced { get; } = new FirewallPolicyIntrusionDetectionProfileType("Advanced");
        public static FirewallPolicyIntrusionDetectionProfileType Basic { get; } = new FirewallPolicyIntrusionDetectionProfileType("Basic");
        public static FirewallPolicyIntrusionDetectionProfileType Standard { get; } = new FirewallPolicyIntrusionDetectionProfileType("Standard");
    }

    public readonly partial struct FirewallPolicyIntrusionDetectionProtocol
    {
        public static FirewallPolicyIntrusionDetectionProtocol Any { get; } = ANY;
        public static FirewallPolicyIntrusionDetectionProtocol Icmp { get; } = ICMP;
        public static FirewallPolicyIntrusionDetectionProtocol Tcp { get; } = TCP;
        public static FirewallPolicyIntrusionDetectionProtocol Udp { get; } = UDP;
    }

    public readonly partial struct FirewallPolicyNatRuleCollectionActionType
    {
        public static FirewallPolicyNatRuleCollectionActionType Dnat { get; } = DNAT;
    }

    public readonly partial struct FirewallPolicyRuleNetworkProtocol
    {
        public static FirewallPolicyRuleNetworkProtocol Icmp { get; } = ICMP;
        public static FirewallPolicyRuleNetworkProtocol Tcp { get; } = TCP;
        public static FirewallPolicyRuleNetworkProtocol Udp { get; } = UDP;
    }

    public readonly partial struct FlowLogFormatType
    {
        public static FlowLogFormatType Json { get; } = JSON;
    }

    public readonly partial struct GatewayLoadBalancerTunnelProtocol
    {
        public static GatewayLoadBalancerTunnelProtocol Vxlan { get; } = VXLAN;
    }

    public readonly partial struct IPFlowProtocol
    {
        public static IPFlowProtocol Tcp { get; } = TCP;
        public static IPFlowProtocol Udp { get; } = UDP;
    }

    public readonly partial struct IPsecEncryption
    {
        public static IPsecEncryption Aes128 { get; } = AES128;
        public static IPsecEncryption Aes192 { get; } = AES192;
        public static IPsecEncryption Aes256 { get; } = AES256;
        public static IPsecEncryption Des { get; } = DES;
        public static IPsecEncryption Des3 { get; } = DES3;
        public static IPsecEncryption GcmAes128 { get; } = GCMAES128;
        public static IPsecEncryption GcmAes192 { get; } = GCMAES192;
        public static IPsecEncryption GcmAes256 { get; } = GCMAES256;
    }

    public readonly partial struct IPsecIntegrity
    {
        public static IPsecIntegrity GcmAes128 { get; } = GCMAES128;
        public static IPsecIntegrity GcmAes256 { get; } = GCMAES256;
        public static IPsecIntegrity Sha1 { get; } = SHA1;
        public static IPsecIntegrity Sha256 { get; } = SHA256;
        public static IPsecIntegrity Sha384 { get; } = new IPsecIntegrity("SHA384");
    }

    public readonly partial struct IkeEncryption
    {
        public static IkeEncryption Aes128 { get; } = AES128;
        public static IkeEncryption Aes192 { get; } = AES192;
        public static IkeEncryption Aes256 { get; } = AES256;
        public static IkeEncryption Des { get; } = DES;
        public static IkeEncryption Des3 { get; } = DES3;
        public static IkeEncryption GcmAes128 { get; } = GCMAES128;
        public static IkeEncryption GcmAes256 { get; } = GCMAES256;
    }

    public readonly partial struct IkeIntegrity
    {
        public static IkeIntegrity GcmAes128 { get; } = GCMAES128;
        public static IkeIntegrity GcmAes256 { get; } = GCMAES256;
        public static IkeIntegrity Sha1 { get; } = SHA1;
        public static IkeIntegrity Sha256 { get; } = SHA256;
        public static IkeIntegrity Sha384 { get; } = SHA384;
    }

    public readonly partial struct InboundSecurityRulesProtocol
    {
        public static InboundSecurityRulesProtocol Tcp { get; } = TCP;
        public static InboundSecurityRulesProtocol Udp { get; } = UDP;
    }

    public readonly partial struct LoadBalancerBackendAddressAdminState
    {
        [System.ObsoleteAttribute("This state is obsolete and will be removed in a future release", false)]
        public static LoadBalancerBackendAddressAdminState Drain { get; } = new LoadBalancerBackendAddressAdminState("Drain");
    }

    public readonly partial struct ManagedRuleSensitivityType
    {
        public static ManagedRuleSensitivityType None { get; } = new ManagedRuleSensitivityType("None");
    }

    public readonly partial struct NetworkAuthenticationMethod
    {
        public static NetworkAuthenticationMethod EapmschaPv2 { get; } = EAPMSCHAPv2;
        public static NetworkAuthenticationMethod Eaptls { get; } = EAPTLS;
    }

    public readonly partial struct NetworkProtocol
    {
        public static NetworkProtocol Icmp { get; } = ICMP;
        public static NetworkProtocol Tcp { get; } = TCP;
        public static NetworkProtocol Udp { get; } = UDP;
    }

    public readonly partial struct PcProtocol
    {
        public static PcProtocol Tcp { get; } = TCP;
        public static PcProtocol Udp { get; } = UDP;
    }

    public readonly partial struct PfsGroup
    {
        public static PfsGroup Ecp256 { get; } = ECP256;
        public static PfsGroup Ecp384 { get; } = ECP384;
        public static PfsGroup Pfs { get; } = new PfsGroup("PFS");
        public static PfsGroup Pfs1 { get; } = PFS1;
        public static PfsGroup Pfs14 { get; } = PFS14;
        public static PfsGroup Pfs2 { get; } = PFS2;
        public static PfsGroup Pfs2048 { get; } = PFS2048;
        public static PfsGroup Pfs24 { get; } = PFS24;
    }

    public readonly partial struct RuleMatchActionType
    {
        public static RuleMatchActionType Captcha { get; } = CAPTCHA;
    }

    public readonly partial struct ScrubbingRuleEntryMatchVariable
    {
        public static ScrubbingRuleEntryMatchVariable RequestJsonArgNames { get; } = RequestJSONArgNames;
    }

    public readonly partial struct VirtualNetworkGatewayConnectionProtocol
    {
        public static VirtualNetworkGatewayConnectionProtocol IkeV1 { get; } = IKEv1;
        public static VirtualNetworkGatewayConnectionProtocol IkeV2 { get; } = IKEv2;
    }

    public readonly partial struct VirtualNetworkGatewayConnectionType
    {
        public static VirtualNetworkGatewayConnectionType VpnClient { get; } = VPNClient;
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AAD")]
    public readonly partial struct VpnAuthenticationType
    {
        [System.ObsoleteAttribute("This value is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public static VpnAuthenticationType AAD { get; } = new VpnAuthenticationType("AAD");
        public static VpnAuthenticationType Aad { get; } = new VpnAuthenticationType("AAD");
    }

    public readonly partial struct VpnClientProtocol
    {
        public static VpnClientProtocol OpenVpn { get; } = OpenVPN;
        public static VpnClientProtocol Sstp { get; } = SSTP;
    }

    public readonly partial struct VpnGatewayTunnelingProtocol
    {
        public static VpnGatewayTunnelingProtocol OpenVpn { get; } = OpenVPN;
    }

    public readonly partial struct VpnPolicyMemberAttributeType
    {
        public static VpnPolicyMemberAttributeType AadGroupId { get; } = AADGroupId;
    }

    public readonly partial struct WebApplicationFirewallAction
    {
        public static WebApplicationFirewallAction Captcha { get; } = CAPTCHA;
    }
}
