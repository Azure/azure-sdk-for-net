using Http;
using Versioning;
using Azure.Core;

@server(
  "https://management.azure.com",
  "The endpoint for network security perimeter common type definitions"
)
namespace Azure.ResourceManager.CommonTypes;

/** Direction of Access Rule */
@added(Versions.v5)
union AccessRuleDirection {
  string,

  /** Applies to inbound network traffic to the secured resources. */
  Inbound: "Inbound",

  /** Applies to outbound network traffic from the secured resources */
  Outbound: "Outbound",
}

/** Provisioning state of a network security perimeter configuration that is being created or updated. */
@added(Versions.v5)
union NetworkSecurityPerimeterConfigurationProvisioningState {
  string,
  Succeeded: "Succeeded",
  Creating: "Creating",
  Updating: "Updating",
  Deleting: "Deleting",
  Accepted: "Accepted",
  Failed: "Failed",
  Canceled: "Canceled",
}

/** Type of issue */
@added(Versions.v5)
union IssueType {
  string,

  /** Unknown issue type */
  Unknown: "Unknown",

  /** An error occurred while applying the network security perimeter (NSP) configuration. */
  ConfigurationPropagationFailure: "ConfigurationPropagationFailure",

  /** A network connectivity issue is happening on the resource which could be addressed either by adding new resources to the network security perimeter (NSP) or by modifying access rules. */
  MissingPerimeterConfiguration: "MissingPerimeterConfiguration",

  /** An managed identity hasn't been associated with the resource. The resource will still be able to validate inbound traffic from the network security perimeter (NSP) or matching inbound access rules, but it won't be able to perform outbound access as a member of the NSP. */
  MissingIdentityConfiguration: "MissingIdentityConfiguration",
}

/** Severity of the issue. */
@added(Versions.v5)
union Severity {
  string,
  Warning: "Warning",
  Error: "Error",
}

/** Access mode of the resource association */
@added(Versions.v5)
union ResourceAssociationAccessMode {
  string,

  /** Enforced access mode - traffic to the resource that failed access checks is blocked */
  Enforced: "Enforced",

  /** Learning access mode - traffic to the resource is enabled for analysis but not blocked */
  Learning: "Learning",

  /** Audit access mode - traffic to the resource that fails access checks is logged but not blocked */
  Audit: "Audit",
}

/** Allow, disallow, or let network security perimeter configuration control public network access to the protected resource. Value is optional but if passed in, it must be 'Enabled', 'Disabled' or 'SecuredByPerimeter'. */
@added(Versions.v5)
union PublicNetworkAccess {
  string,

  /** Allows public network access to the resource */
  Enabled: "Enabled",

  /** Disallows public network access to the resource */
  Disabled: "Disabled",

  /** The network security perimeter configuration rules allow or disallow public network access to the resource. Requires an associated network security perimeter. */
  SecuredByPerimeter: "SecuredByPerimeter",
}

/** Access rule in a network security perimeter configuration profile */
@added(Versions.v5)
model AccessRule {
  /** Name of the access rule */
  name?: string;

  properties?: AccessRuleProperties;
}

/** Properties of Access Rule */
@added(Versions.v5)
model AccessRuleProperties {
  direction?: AccessRuleDirection;

  /** Address prefixes in the CIDR format for inbound rules */
  addressPrefixes?: string[];

  /** Subscriptions for inbound rules */
  subscriptions?: {
    /** The fully qualified Azure resource ID of the subscription e.g. ('/subscriptions/00000000-0000-0000-0000-000000000000') */
    id?: Azure.Core.armResourceIdentifier;
  }[];

  /** Network security perimeters for inbound rules */
  networkSecurityPerimeters?: NetworkSecurityPerimeter[];

  /** Fully qualified domain names (FQDN) for outbound rules */
  fullyQualifiedDomainNames?: string[];

  /** Email addresses for outbound rules */
  emailAddresses?: string[];

  /** Phone numbers for outbound rules */
  phoneNumbers?: string[];
}

/** Information about a network security perimeter (NSP) */
@added(Versions.v5)
model NetworkSecurityPerimeter {
  /** Fully qualified Azure resource ID of the NSP resource */
  id?: Azure.Core.armResourceIdentifier<[
    {
      type: "Microsoft.Network/networkSecurityPerimeters";
    }
  ]>;

  /** Universal unique ID (UUID) of the network security perimeter */
  perimeterGuid?: uuid;

  /** Location of the network security perimeter */
  @visibility(Lifecycle.Read, Lifecycle.Create)
  location?: string;
}

/** Network security perimeter (NSP) configuration resource */
@added(Versions.v5)
model NetworkSecurityPerimeterConfiguration extends ProxyResource {
  properties?: NetworkSecurityPerimeterConfigurationProperties;
}

/** Network security configuration properties. */
@added(Versions.v5)
model NetworkSecurityPerimeterConfigurationProperties {
  @visibility(Lifecycle.Read)
  provisioningState?: NetworkSecurityPerimeterConfigurationProvisioningState;

  /** List of provisioning issues, if any */
  @visibility(Lifecycle.Read)
  @Azure.ResourceManager.identifiers(#[])
  provisioningIssues?: ProvisioningIssue[];

  networkSecurityPerimeter?: NetworkSecurityPerimeter;
  resourceAssociation?: ResourceAssociation;
  profile?: NetworkSecurityProfile;
}

/** Describes a provisioning issue for a network security perimeter configuration */
@added(Versions.v5)
model ProvisioningIssue {
  /** Name of the issue */
  @visibility(Lifecycle.Read)
  name?: string;

  @visibility(Lifecycle.Read)
  properties?: ProvisioningIssueProperties;
}

/** Details of a provisioning issue for a network security perimeter (NSP) configuration. Resource providers should generate separate provisioning issue elements for each separate issue detected, and include a meaningful and distinctive description, as well as any appropriate suggestedResourceIds and suggestedAccessRules */
@added(Versions.v5)
model ProvisioningIssueProperties {
  /** Type of issue */
  @visibility(Lifecycle.Read)
  issueType?: IssueType;

  /** Severity of the issue. */
  @visibility(Lifecycle.Read)
  severity?: Severity;

  /** Description of the issue */
  @visibility(Lifecycle.Read)
  description?: string;

  /** Fully qualified resource IDs of suggested resources that can be associated to the network security perimeter (NSP) to remediate the issue. */
  @visibility(Lifecycle.Read)
  suggestedResourceIds?: Azure.Core.armResourceIdentifier[];

  /** Access rules that can be added to the network security profile (NSP) to remediate the issue. */
  @visibility(Lifecycle.Read)
  @Azure.ResourceManager.identifiers(#[])
  suggestedAccessRules?: AccessRule[];
}

/** Information about resource association */
@added(Versions.v5)
model ResourceAssociation {
  /** Name of the resource association */
  name?: string;

  accessMode?: ResourceAssociationAccessMode;
}

/** Network security perimeter configuration profile */
@added(Versions.v5)
model NetworkSecurityProfile {
  /** Name of the profile */
  name?: string;

  /** Current access rules version */
  accessRulesVersion?: int32;

  /** List of Access Rules */
  @Azure.ResourceManager.identifiers(#["name"])
  accessRules?: AccessRule[];

  /** Current diagnostic settings version */
  diagnosticSettingsVersion?: int32;

  /** List of log categories that are enabled */
  enabledLogCategories?: string[];
}

/** Result of a list NSP (network security perimeter) configurations request. */
@added(Versions.v5)
model NetworkSecurityPerimeterConfigurationListResult {
  /** Array of network security perimeter results. */
  value?: NetworkSecurityPerimeterConfiguration[];

  /** The link used to get the next page of results. */
  nextLink?: url;
}

/**
 * The name for a network security perimeter configuration
 */
@added(Versions.v5)
model NetworkSecurityPerimeterConfigurationNameParameter {
  /** The name for a network security perimeter configuration */
  @path
  @minLength(1)
  @maxLength(512)
  @TypeSpec.Rest.segment("networkSecurityPerimeterConfigurations")
  @key("networkSecurityPerimeterConfigurationName")
  networkSecurityPerimeterConfigurationName: string;
}
