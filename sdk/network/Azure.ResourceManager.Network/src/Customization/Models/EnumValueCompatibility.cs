// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct ApplicationGatewayClientRevocationOption
    {
    }

    public readonly partial struct ApplicationGatewayCustomErrorStatusCode
    {
        /// <summary> Invokes the ApplicationGatewayCustomErrorStatusCode compatibility operation. </summary>
        [System.ObsoleteAttribute("This status is obsolete and will be removed in a future release", false)]
        public static ApplicationGatewayCustomErrorStatusCode HttpStatus499 { get; } = new ApplicationGatewayCustomErrorStatusCode("HttpStatus499");
    }

    public readonly partial struct ApplicationGatewayLoadDistributionAlgorithm
    {
    }

    /// <summary> Compatibility declaration for the ApplicationGatewayTierType type. </summary>
    public readonly partial struct ApplicationGatewayTierType
    {
    }

    public readonly partial struct ApplicationGatewayWafRuleSensitivityType
    {
        /// <summary> Invokes the ApplicationGatewayWafRuleSensitivityType compatibility operation. </summary>
        public static ApplicationGatewayWafRuleSensitivityType None { get; } = new ApplicationGatewayWafRuleSensitivityType("None");
    }

    public readonly partial struct AzureFirewallNetworkRuleProtocol
    {
    }

    public readonly partial struct AzureFirewallSkuName
    {
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

    public readonly partial struct DHGroup
    {
    }

    [System.ObsoleteAttribute("This struct is obsolete and will be removed in a future release", false)]
    public readonly partial struct DdosCustomPolicyProtocol
    {
        /// <summary> Invokes the DdosCustomPolicyProtocol compatibility operation. </summary>
        public static DdosCustomPolicyProtocol Syn { get; } = new DdosCustomPolicyProtocol("Syn");
    }

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

    public readonly partial struct ExceptionEntryMatchVariable
    {
    }

    public readonly partial struct FirewallPolicyIntrusionDetectionProfileType
    {
        /// <summary> Invokes the FirewallPolicyIntrusionDetectionProfileType compatibility operation. </summary>
        public static FirewallPolicyIntrusionDetectionProfileType Advanced { get; } = new FirewallPolicyIntrusionDetectionProfileType("Advanced");
        /// <summary> Invokes the FirewallPolicyIntrusionDetectionProfileType compatibility operation. </summary>
        public static FirewallPolicyIntrusionDetectionProfileType Basic { get; } = new FirewallPolicyIntrusionDetectionProfileType("Basic");
        /// <summary> Invokes the FirewallPolicyIntrusionDetectionProfileType compatibility operation. </summary>
        public static FirewallPolicyIntrusionDetectionProfileType Standard { get; } = new FirewallPolicyIntrusionDetectionProfileType("Standard");
    }

    public readonly partial struct FirewallPolicyIntrusionDetectionProtocol
    {
    }

    public readonly partial struct FirewallPolicyNatRuleCollectionActionType
    {
    }

    public readonly partial struct FirewallPolicyRuleNetworkProtocol
    {
    }

    public readonly partial struct FlowLogFormatType
    {
    }

    public readonly partial struct GatewayLoadBalancerTunnelProtocol
    {
    }

    public readonly partial struct IPFlowProtocol
    {
    }

    public readonly partial struct IPsecEncryption
    {
    }

    public readonly partial struct IPsecIntegrity
    {
        /// <summary> Invokes the IPsecIntegrity compatibility operation. </summary>
        public static IPsecIntegrity Sha384 { get; } = new IPsecIntegrity("SHA384");
    }

    public readonly partial struct IkeEncryption
    {
    }

    public readonly partial struct IkeIntegrity
    {
    }

    public readonly partial struct InboundSecurityRulesProtocol
    {
    }

    public readonly partial struct LoadBalancerBackendAddressAdminState
    {
        /// <summary> Invokes the LoadBalancerBackendAddressAdminState compatibility operation. </summary>
        [System.ObsoleteAttribute("This state is obsolete and will be removed in a future release", false)]
        public static LoadBalancerBackendAddressAdminState Drain { get; } = new LoadBalancerBackendAddressAdminState("Drain");
    }

    public readonly partial struct ManagedRuleSensitivityType
    {
        /// <summary> Invokes the ManagedRuleSensitivityType compatibility operation. </summary>
        public static ManagedRuleSensitivityType None { get; } = new ManagedRuleSensitivityType("None");
    }

    public readonly partial struct NetworkAuthenticationMethod
    {
    }

    public readonly partial struct NetworkProtocol
    {
    }

    public readonly partial struct PcProtocol
    {
    }

    public readonly partial struct RuleMatchActionType
    {
    }

    public readonly partial struct ScrubbingRuleEntryMatchVariable
    {
    }

    public readonly partial struct VirtualNetworkGatewayConnectionProtocol
    {
    }

    public readonly partial struct VirtualNetworkGatewayConnectionType
    {
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AAD")]
    public readonly partial struct VpnAuthenticationType
    {
        /// <summary> Invokes the VpnAuthenticationType compatibility operation. </summary>
        [System.ObsoleteAttribute("This value is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public static VpnAuthenticationType AAD { get; } = new VpnAuthenticationType("AAD");
        /// <summary> Invokes the VpnAuthenticationType compatibility operation. </summary>
        public static VpnAuthenticationType Aad { get; } = new VpnAuthenticationType("AAD");
    }

    public readonly partial struct VpnClientProtocol
    {
    }

    public readonly partial struct VpnGatewayTunnelingProtocol
    {
    }

    public readonly partial struct VpnPolicyMemberAttributeType
    {
    }

    public readonly partial struct WebApplicationFirewallAction
    {
    }
}
