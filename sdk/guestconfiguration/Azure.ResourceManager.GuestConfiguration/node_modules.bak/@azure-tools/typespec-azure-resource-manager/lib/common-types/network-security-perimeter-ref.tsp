import "./network-security-perimeter.tsp";

using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

/** Direction of Access Rule */
@@armCommonDefinition(AccessRuleDirection,
  "AccessRuleDirection",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(AccessRuleDirection,
  "AccessRuleDirection",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Provisioning state of a network security perimeter configuration that is being created or updated. */
@@armCommonDefinition(NetworkSecurityPerimeterConfigurationProvisioningState,
  "NetworkSecurityPerimeterConfigurationProvisioningState",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(NetworkSecurityPerimeterConfigurationProvisioningState,
  "NetworkSecurityPerimeterConfigurationProvisioningState",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Type of issue */
@@armCommonDefinition(IssueType,
  "IssueType",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(IssueType,
  "IssueType",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Severity of the issue. */
@@armCommonDefinition(Severity,
  "Severity",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(Severity,
  "Severity",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Access mode of the resource association */
@@armCommonDefinition(ResourceAssociationAccessMode,
  "ResourceAssociationAccessMode",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(ResourceAssociationAccessMode,
  "ResourceAssociationAccessMode",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Allow, disallow, or let network security perimeter configuration control public network access to the protected resource. */
@@armCommonDefinition(PublicNetworkAccess,
  "PublicNetworkAccess",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(PublicNetworkAccess,
  "PublicNetworkAccess",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Access rule in a network security perimeter configuration profile */
@@armCommonDefinition(AccessRule,
  "AccessRule",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(AccessRule,
  "AccessRule",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Properties of Access Rule */
@@armCommonDefinition(AccessRuleDirection,
  "AccessRuleDirection",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(AccessRuleDirection,
  "AccessRuleDirection",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Information about a network security perimeter */
@@armCommonDefinition(NetworkSecurityPerimeter,
  "NetworkSecurityPerimeter",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(NetworkSecurityPerimeter,
  "NetworkSecurityPerimeter",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

@@Versioning.added(NetworkSecurityPerimeterConfiguration, Versions.v5);
/** Network security perimeter configuration resource */
@@armCommonDefinition(NetworkSecurityPerimeterConfiguration,
  "NetworkSecurityPerimeterConfiguration",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(NetworkSecurityPerimeterConfiguration,
  "NetworkSecurityPerimeterConfiguration",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Network security configuration properties. */
@@armCommonDefinition(NetworkSecurityPerimeterConfigurationProperties,
  "NetworkSecurityPerimeterConfigurationProperties",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(NetworkSecurityPerimeterConfigurationProperties,
  "NetworkSecurityPerimeterConfigurationProperties",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Describes a provisioning issue for a network security perimeter configuration */
@@armCommonDefinition(ProvisioningIssue,
  "ProvisioningIssue",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(ProvisioningIssue,
  "ProvisioningIssue",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Details of a provisioning issue for a network security perimeter configuration. */
@@armCommonDefinition(ProvisioningIssueProperties,
  "ProvisioningIssueProperties",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(ProvisioningIssueProperties,
  "ProvisioningIssueProperties",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Information about resource association */
@@armCommonDefinition(ResourceAssociation,
  "ResourceAssociation",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(ResourceAssociation,
  "ResourceAssociation",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Network security perimeter configuration profile */
@@armCommonDefinition(NetworkSecurityProfile,
  "NetworkSecurityProfile",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(NetworkSecurityProfile,
  "NetworkSecurityProfile",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);

/** Result of a list NSP (network security perimeter) configurations request. */
@@armCommonDefinition(NetworkSecurityPerimeterConfigurationListResult,
  "NetworkSecurityPerimeterConfigurationListResult",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "networksecurityperimeter.json"
);
@@armCommonDefinition(NetworkSecurityPerimeterConfigurationListResult,
  "NetworkSecurityPerimeterConfigurationListResult",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "networksecurityperimeter.json"
);
